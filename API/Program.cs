using Asp.Versioning;
using Database;
using Database.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Localhost", builder => builder
        .WithOrigins("http://localhost", "https://localhost")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseAllOfToExtendReferenceSchemas();
    c.UseOneOfForPolymorphism();
});

// Add Newtonsoft.Json support for Swagger. Used by the StringEnumConverter.
builder.Services.AddSwaggerGenNewtonsoftSupport();

// Add the database context to the container.
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("API")));

// Add repositories to the container.
builder.Services.AddScoped<IBuildingRepository, SQLBuildingRepository>();
builder.Services.AddScoped<IClothingRepository, SQLClothingRepository>();
builder.Services.AddScoped<IWeaponRepository, SQLWeaponRepository>();
builder.Services.AddScoped<IVehicleRepository, SQLVehicleRepository>();
builder.Services.AddScoped<IPlayerCharacterRepository, SQLPlayerCharacterRepository>();
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();

// Add additional services to the container.
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// Set up API versioning.
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
})
.AddMvc()
.AddApiExplorer(options => 
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Ensure the database exists and is created if it doesn't.
using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    Context context = services.GetRequiredService<Context>();
    if (context.Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator && !databaseCreator.Exists())
    {
        context.Database.EnsureCreated();
    }
}

app.UseCors("Localhost");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
