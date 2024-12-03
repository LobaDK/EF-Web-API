using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AlterVehicleDatabaseRelationsAndHandling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Helicopters");

            migrationBuilder.DropTable(
                name: "LandVehicles");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.RenameColumn(
                name: "Occupancy",
                table: "Vehicles",
                newName: "MaxOccupants");

            migrationBuilder.RenameColumn(
                name: "MaxSpeed",
                table: "Vehicles",
                newName: "TopSpeed");

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaxAltitude = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExtraAbilities = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Landcrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Acceleration0To60 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landcrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landcrafts_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seacrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RudderTurnCircle = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seacrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seacrafts_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Landcrafts");

            migrationBuilder.DropTable(
                name: "Seacrafts");

            migrationBuilder.RenameColumn(
                name: "TopSpeed",
                table: "Vehicles",
                newName: "MaxSpeed");

            migrationBuilder.RenameColumn(
                name: "MaxOccupants",
                table: "Vehicles",
                newName: "Occupancy");

            migrationBuilder.CreateTable(
                name: "Helicopters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    LiftRotorCount = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TailRotorCount = table.Column<int>(type: "int", nullable: false)
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
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Acceleration0To60 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WheelCount = table.Column<int>(type: "int", nullable: false)
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
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ExtraAbilities = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    JetEngineCount = table.Column<int>(type: "int", nullable: false),
                    PropellerCount = table.Column<int>(type: "int", nullable: false),
                    PropulsionTypes = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
        }
    }
}
