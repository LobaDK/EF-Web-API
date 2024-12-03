using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class Context(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    private readonly DbContextOptions dbContextOptions = dbContextOptions;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Aircraft>()
            .ToTable("Aircrafts");
        
        modelBuilder.Entity<Landcraft>()
            .ToTable("Landcrafts");
        
        modelBuilder.Entity<Seacraft>()
            .ToTable("Seacrafts");

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
            .HasIndex(u => u.Email)
            .IsUnique();

        
        base.OnModelCreating(modelBuilder);
    }

    public required DbSet<Building> Buildings { get; set; }
    public required DbSet<Clothing> Clothing { get; set; }
    public required DbSet<Landcraft> LandVehicles { get; set; }
    public required DbSet<Aircraft> Helicopters { get; set; }
    public required DbSet<Seacraft> Seacrafts { get; set; }
    public required DbSet<PlayerCharacter> PlayerCharacters { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<Vehicle> Vehicles { get; set; }
    public required DbSet<Weapon> Weapons { get; set; }

}
