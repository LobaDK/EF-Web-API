using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSchemaUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GarageSpaces = table.Column<int>(type: "int", nullable: false),
                    CharacterLevelRequirement = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CharacterLevelRequirement = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxSpeed = table.Column<float>(type: "real", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    CharacterLevelRequirement = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Damage = table.Column<float>(type: "real", nullable: false),
                    RangeInMeters = table.Column<float>(type: "real", nullable: false),
                    MagazineSize = table.Column<int>(type: "int", nullable: false),
                    FireRate = table.Column<float>(type: "real", nullable: false),
                    ReloadTime = table.Column<float>(type: "real", nullable: false),
                    SupportedAmmoTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportedAttachments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterLevelRequirement = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helicopters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiftRotorCount = table.Column<int>(type: "int", nullable: false),
                    TailRotorCount = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helicopters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Helicopters_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Acceleration0To60 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropulsionTypes = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PropellerCount = table.Column<int>(type: "int", nullable: false),
                    JetEngineCount = table.Column<int>(type: "int", nullable: false),
                    ExtraAbilities = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingPlayerCharacter",
                columns: table => new
                {
                    OwnedBuildingsId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingPlayerCharacter", x => new { x.OwnedBuildingsId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_BuildingPlayerCharacter_Buildings_OwnedBuildingsId",
                        column: x => x.OwnedBuildingsId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingPlayerCharacter_PlayerCharacters_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothingPlayerCharacter",
                columns: table => new
                {
                    OwnedClothingId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingPlayerCharacter", x => new { x.OwnedClothingId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_ClothingPlayerCharacter_Clothing_OwnedClothingId",
                        column: x => x.OwnedClothingId,
                        principalTable: "Clothing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingPlayerCharacter_PlayerCharacters_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacterVehicle",
                columns: table => new
                {
                    OwnedVehiclesId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterVehicle", x => new { x.OwnedVehiclesId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_PlayerCharacterVehicle_PlayerCharacters_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterVehicle_Vehicles_OwnedVehiclesId",
                        column: x => x.OwnedVehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacterWeapon",
                columns: table => new
                {
                    OwnedWeaponsId = table.Column<int>(type: "int", nullable: false),
                    OwnersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterWeapon", x => new { x.OwnedWeaponsId, x.OwnersId });
                    table.ForeignKey(
                        name: "FK_PlayerCharacterWeapon_PlayerCharacters_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterWeapon_Weapons_OwnedWeaponsId",
                        column: x => x.OwnedWeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingPlayerCharacter_OwnersId",
                table: "BuildingPlayerCharacter",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingPlayerCharacter_OwnersId",
                table: "ClothingPlayerCharacter",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Helicopters_VehicleId",
                table: "Helicopters",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_LandVehicles_VehicleId",
                table: "LandVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_VehicleId",
                table: "Planes",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_UserId",
                table: "PlayerCharacters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterVehicle_OwnersId",
                table: "PlayerCharacterVehicle",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterWeapon_OwnersId",
                table: "PlayerCharacterWeapon",
                column: "OwnersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingPlayerCharacter");

            migrationBuilder.DropTable(
                name: "ClothingPlayerCharacter");

            migrationBuilder.DropTable(
                name: "Helicopters");

            migrationBuilder.DropTable(
                name: "LandVehicles");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "PlayerCharacterVehicle");

            migrationBuilder.DropTable(
                name: "PlayerCharacterWeapon");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Clothing");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
