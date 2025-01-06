using Database.Enums;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class Context(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    private readonly DbContextOptions dbContextOptions = dbContextOptions;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<PlayerCharacter>()
            .HasOne(pc => pc.User)
            .WithMany(u => u.PlayerCharacters)
            .HasForeignKey(pc => pc.UserId)
            .IsRequired();
        
        modelBuilder.Entity<Building>()
            .HasIndex(b => b.Name)
            .IsUnique();
        
        modelBuilder.Entity<Clothing>()
            .HasIndex(c => c.Name)
            .IsUnique();
        
        modelBuilder.Entity<Weapon>()
            .HasIndex(w => w.Name)
            .IsUnique();
        
        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.Name)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .Property(u => u.RegistrationDate)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        
        base.OnModelCreating(modelBuilder);

        // Seed data beyond this point
        // Seed data for buildings
        modelBuilder.Entity<Building>().HasData(
            new Building {
                Id = -1,
                Name = "Richards Majestic, Apt. 2",
                Address = "Richards Majestic, Apt. 2, Rockford Hills",
                GarageSpaces = 10,
                Type = BuildingType.Apartment,
                Price = 484_000 },
            new Building {
                Id = -2,
                Name = "Del Perro Heights, Apt. 4",
                Address = "Del Perro Heights, Apt. 4, Del Perro",
                GarageSpaces = 10,
                Type = BuildingType.Apartment,
                Price = 468_000},
            new Building {
                Id = -3,
                Name = "Maze Bank Tower Office",
                Address = "Maze Bank Tower, Pillbox Hill",
                GarageSpaces = 0,
                Type = BuildingType.Business,
                Price = 4_000_000}
            );
        
        // Seed data for clothing
        modelBuilder.Entity<Clothing>().HasData(
            new Clothing {
                Id = -1,
                Name = "Black Suit",
                Color = "Black",
                Type = ClothingType.Shirt,
                Gender = "Male",
                Price = 1_000},
            new Clothing {
                Id = -2,
                Name = "White T-Shirt",
                Color = "White",
                Type = ClothingType.Shirt,
                Gender = "Male",
                Price = 100},
            new Clothing {
                Id = -3,
                Name = "Blue Jeans",
                Color = "Blue",
                Type = ClothingType.Pants,
                Gender = "Female",
                Price = 200}
            );
        
        // Seed data for weapons
        modelBuilder.Entity<Weapon>().HasData(
            new Weapon {
                Id = -1,
                Name = "Pistol",
                Type = WeaponType.Pistol,
                Damage = 25,
                RangeInMeters = 50,
                MagazineSize = 12,
                FireRate = 220,
                ReloadTime = 1.5f,
                SupportedAmmoTypes = AmmoTypes.Normal,
                SupportedAttachments = WeaponAttachments.Silencer | WeaponAttachments.ExtendedMagazine | WeaponAttachments.LaserSight,
                Price = 500},
            new Weapon {
                Id = -2,
                Name = "Assault Rifle",
                Type = WeaponType.AssaultRifle,
                Damage = 19,
                RangeInMeters = 100,
                MagazineSize = 30,
                FireRate = 600,
                ReloadTime = 2.5f,
                SupportedAmmoTypes = AmmoTypes.Normal | AmmoTypes.ArmorPiercing | AmmoTypes.HollowPoint | AmmoTypes.Tracer | AmmoTypes.Incendiary | AmmoTypes.FullMetalJacket,
                SupportedAttachments = WeaponAttachments.All,
                Price = 1_000},
            new Weapon {
                Id = -3,
                Name = "Knife",
                Type = WeaponType.Melee,
                Damage = 50,
                MagazineSize = 0,
                Price = 50}
            );
        
        // Seed data for vehicles
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle {
                Id = -1,
                Name = "Zentorno",
                TypeOrClass = VehicleTypeOrClass.Super,
                TopSpeed = 350,
                MaxOccupants = 2,
                Price = 725_000},
            new Vehicle {
                Id = -2,
                Name = "Bati 801",
                TypeOrClass = VehicleTypeOrClass.Motorcycle,
                TopSpeed = 200,
                MaxOccupants = 1,
                Price = 15_000},
            new Vehicle {
                Id = -3,
                Name = "Lazer",
                TypeOrClass = VehicleTypeOrClass.Plane,
                TopSpeed = 900,
                MaxOccupants = 1,
                Price = 6_500_000}
            );
        
        // Seed data for users
        modelBuilder.Entity<User>().HasData(
            new User {
                Id = -1,
                Username = "admin",
                Email = "admin@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd")},
            new User {
                Id = -2,
                Username = "LobaDK",
                Email = "lobadk@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd")}
            );
        
        // Seed data for player characters
        modelBuilder.Entity<PlayerCharacter>().HasData(
            new PlayerCharacter {
                Id = -1,
                Name = "John Doe",
                UserId = -1},
            new PlayerCharacter {
                Id = -2,
                Name = "Jane Doe",
                UserId = -2}
            );
    }

    public required DbSet<Building> Buildings { get; set; }
    public required DbSet<Clothing> Clothing { get; set; }
    public required DbSet<PlayerCharacter> PlayerCharacters { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<Vehicle> Vehicles { get; set; }
    public required DbSet<Weapon> Weapons { get; set; }

}
