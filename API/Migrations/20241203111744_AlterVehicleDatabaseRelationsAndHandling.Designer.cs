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
    [Migration("20241203111744_AlterVehicleDatabaseRelationsAndHandling")]
    partial class AlterVehicleDatabaseRelationsAndHandling
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

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Buildings");
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

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clothing");
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
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("RegistrationDate")
                        .HasColumnType("date");

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

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Vehicles");

                    b.UseTptMappingStrategy();
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

            modelBuilder.Entity("Database.Models.Aircraft", b =>
                {
                    b.HasBaseType("Database.Models.Vehicle");

                    b.Property<int?>("ExtraAbilities")
                        .HasColumnType("int");

                    b.Property<int>("MaxAltitude")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.ToTable("Aircrafts", (string)null);
                });

            modelBuilder.Entity("Database.Models.Landcraft", b =>
                {
                    b.HasBaseType("Database.Models.Vehicle");

                    b.Property<string>("Acceleration0To60")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsElectric")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("WheelCount")
                        .HasColumnType("int");

                    b.ToTable("Landcrafts", (string)null);
                });

            modelBuilder.Entity("Database.Models.Seacraft", b =>
                {
                    b.HasBaseType("Database.Models.Vehicle");

                    b.Property<float>("RudderTurnCircle")
                        .HasColumnType("real");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Seacrafts", (string)null);
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

            modelBuilder.Entity("Database.Models.Aircraft", b =>
                {
                    b.HasOne("Database.Models.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("Database.Models.Aircraft", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Landcraft", b =>
                {
                    b.HasOne("Database.Models.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("Database.Models.Landcraft", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Seacraft", b =>
                {
                    b.HasOne("Database.Models.Vehicle", null)
                        .WithOne()
                        .HasForeignKey("Database.Models.Seacraft", "Id")
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
