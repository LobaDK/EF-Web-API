﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250106074248_AddDamageToWeaponKnifeSeedData")]
    partial class AddDamageToWeaponKnifeSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuildingPlayerCharacter", b =>
                {
                    b.Property<int>("OwnedBuildingsId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.HasKey("OwnedBuildingsId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("BuildingPlayerCharacter");
                });

            modelBuilder.Entity("ClothingPlayerCharacter", b =>
                {
                    b.Property<int>("OwnedClothingId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.HasKey("OwnedClothingId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("ClothingPlayerCharacter");
                });

            modelBuilder.Entity("Database.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CharacterLevelRequirement")
                        .HasColumnType("int");

                    b.Property<int>("GarageSpaces")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Buildings");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Address = "Richards Majestic, Apt. 2, Rockford Hills",
                            CharacterLevelRequirement = 0,
                            GarageSpaces = 10,
                            Name = "Richards Majestic, Apt. 2",
                            OwnerId = 0,
                            Price = 484000,
                            Type = 0
                        },
                        new
                        {
                            Id = -2,
                            Address = "Del Perro Heights, Apt. 4, Del Perro",
                            CharacterLevelRequirement = 0,
                            GarageSpaces = 10,
                            Name = "Del Perro Heights, Apt. 4",
                            OwnerId = 0,
                            Price = 468000,
                            Type = 0
                        },
                        new
                        {
                            Id = -3,
                            Address = "Maze Bank Tower, Pillbox Hill",
                            CharacterLevelRequirement = 0,
                            GarageSpaces = 0,
                            Name = "Maze Bank Tower Office",
                            OwnerId = 0,
                            Price = 4000000,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Database.Models.Clothing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterLevelRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clothing");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CharacterLevelRequirement = 0,
                            Color = "Black",
                            Gender = "Male",
                            Name = "Black Suit",
                            OwnerId = 0,
                            Price = 1000,
                            Type = 1
                        },
                        new
                        {
                            Id = -2,
                            CharacterLevelRequirement = 0,
                            Color = "White",
                            Gender = "Male",
                            Name = "White T-Shirt",
                            OwnerId = 0,
                            Price = 100,
                            Type = 1
                        },
                        new
                        {
                            Id = -3,
                            CharacterLevelRequirement = 0,
                            Color = "Blue",
                            Gender = "Female",
                            Name = "Blue Jeans",
                            OwnerId = 0,
                            Price = 200,
                            Type = 2
                        });
                });

            modelBuilder.Entity("Database.Models.PlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Experience")
                        .HasColumnType("bigint");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PlayerCharacters");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Experience = 0L,
                            Money = 0,
                            Name = "John Doe",
                            UserId = -1
                        },
                        new
                        {
                            Id = -2,
                            Experience = 0L,
                            Money = 0,
                            Name = "Jane Doe",
                            UserId = -2
                        });
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            BirthDate = new DateOnly(1, 1, 1),
                            Email = "admin@test.com",
                            PasswordHash = "$2a$11$NyEoWZd4u.ErqIzREDN2TeLoyHIcMli.SWigUNKaINruF4Sq4w2Gu",
                            RegistrationDate = new DateOnly(1, 1, 1),
                            Username = "admin"
                        },
                        new
                        {
                            Id = -2,
                            BirthDate = new DateOnly(1, 1, 1),
                            Email = "lobadk@test.com",
                            PasswordHash = "$2a$11$8YjKg0yT3YxIOHsW1R5D1.t0a9yEorVtozgzdbjXRqalI.ukLyCbG",
                            RegistrationDate = new DateOnly(1, 1, 1),
                            Username = "LobaDK"
                        });
                });

            modelBuilder.Entity("Database.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterLevelRequirement")
                        .HasColumnType("int");

                    b.Property<int>("MaxOccupants")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<float>("TopSpeed")
                        .HasColumnType("real");

                    b.Property<int>("TypeOrClass")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CharacterLevelRequirement = 0,
                            MaxOccupants = 2,
                            Name = "Zentorno",
                            OwnerId = 0,
                            Price = 725000,
                            TopSpeed = 350f,
                            TypeOrClass = 3
                        },
                        new
                        {
                            Id = -2,
                            CharacterLevelRequirement = 0,
                            MaxOccupants = 1,
                            Name = "Bati 801",
                            OwnerId = 0,
                            Price = 15000,
                            TopSpeed = 200f,
                            TypeOrClass = 12
                        },
                        new
                        {
                            Id = -3,
                            CharacterLevelRequirement = 0,
                            MaxOccupants = 1,
                            Name = "Lazer",
                            OwnerId = 0,
                            Price = 6500000,
                            TopSpeed = 900f,
                            TypeOrClass = 0
                        });
                });

            modelBuilder.Entity("Database.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterLevelRequirement")
                        .HasColumnType("int");

                    b.Property<float>("Damage")
                        .HasColumnType("real");

                    b.Property<float>("FireRate")
                        .HasColumnType("real");

                    b.Property<int>("MagazineSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<float>("RangeInMeters")
                        .HasColumnType("real");

                    b.Property<float>("ReloadTime")
                        .HasColumnType("real");

                    b.Property<int>("SupportedAmmoTypes")
                        .HasColumnType("int");

                    b.Property<int>("SupportedAttachments")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CharacterLevelRequirement = 0,
                            Damage = 25f,
                            FireRate = 220f,
                            MagazineSize = 12,
                            Name = "Pistol",
                            OwnerId = 0,
                            Price = 500,
                            RangeInMeters = 50f,
                            ReloadTime = 1.5f,
                            SupportedAmmoTypes = 0,
                            SupportedAttachments = 14,
                            Type = 1
                        },
                        new
                        {
                            Id = -2,
                            CharacterLevelRequirement = 0,
                            Damage = 19f,
                            FireRate = 600f,
                            MagazineSize = 30,
                            Name = "Assault Rifle",
                            OwnerId = 0,
                            Price = 1000,
                            RangeInMeters = 100f,
                            ReloadTime = 2.5f,
                            SupportedAmmoTypes = 47,
                            SupportedAttachments = 63,
                            Type = 4
                        },
                        new
                        {
                            Id = -3,
                            CharacterLevelRequirement = 0,
                            Damage = 50f,
                            FireRate = 0f,
                            MagazineSize = 0,
                            Name = "Knife",
                            OwnerId = 0,
                            Price = 50,
                            RangeInMeters = 0f,
                            ReloadTime = 0f,
                            SupportedAmmoTypes = 0,
                            SupportedAttachments = 0,
                            Type = 0
                        });
                });

            modelBuilder.Entity("PlayerCharacterVehicle", b =>
                {
                    b.Property<int>("OwnedVehiclesId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.HasKey("OwnedVehiclesId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("PlayerCharacterVehicle");
                });

            modelBuilder.Entity("PlayerCharacterWeapon", b =>
                {
                    b.Property<int>("OwnedWeaponsId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.HasKey("OwnedWeaponsId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("PlayerCharacterWeapon");
                });

            modelBuilder.Entity("BuildingPlayerCharacter", b =>
                {
                    b.HasOne("Database.Models.Building", null)
                        .WithMany()
                        .HasForeignKey("OwnedBuildingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.PlayerCharacter", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClothingPlayerCharacter", b =>
                {
                    b.HasOne("Database.Models.Clothing", null)
                        .WithMany()
                        .HasForeignKey("OwnedClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.PlayerCharacter", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.PlayerCharacter", b =>
                {
                    b.HasOne("Database.Models.User", "User")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlayerCharacterVehicle", b =>
                {
                    b.HasOne("Database.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("OwnedVehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.PlayerCharacter", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerCharacterWeapon", b =>
                {
                    b.HasOne("Database.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("OwnedWeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.PlayerCharacter", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Navigation("PlayerCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}
