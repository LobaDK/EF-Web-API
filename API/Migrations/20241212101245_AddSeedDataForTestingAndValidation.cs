using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForTestingAndValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Clothing",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Buildings",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "Address", "CharacterLevelRequirement", "GarageSpaces", "Name", "OwnerId", "Price", "Type" },
                values: new object[,]
                {
                    { -3, "Maze Bank Tower, Pillbox Hill", 0, 0, "Maze Bank Tower Office", 0, 4000000, 2 },
                    { -2, "Del Perro Heights, Apt. 4, Del Perro", 0, 10, "Del Perro Heights, Apt. 4", 0, 468000, 0 },
                    { -1, "Richards Majestic, Apt. 2, Rockford Hills", 0, 10, "Richards Majestic, Apt. 2", 0, 484000, 0 }
                });

            migrationBuilder.InsertData(
                table: "Clothing",
                columns: new[] { "Id", "CharacterLevelRequirement", "Color", "Gender", "Name", "OwnerId", "Price", "Type" },
                values: new object[,]
                {
                    { -3, 0, "Blue", "Female", "Blue Jeans", 0, 200, 2 },
                    { -2, 0, "White", "Male", "White T-Shirt", 0, 100, 1 },
                    { -1, 0, "Black", "Male", "Black Suit", 0, 1000, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "PasswordHash", "RegistrationDate", "Username" },
                values: new object[,]
                {
                    { -2, new DateOnly(1, 1, 1), "lobadk@test.com", "$2a$11$INNYJ290kpPjNzcN6EJWDeuzqEEFwf/Wv7YvZ6WWu5JOa6j.8840q", new DateOnly(1, 1, 1), "LobaDK" },
                    { -1, new DateOnly(1, 1, 1), "admin@test.com", "$2a$11$i/FhDaald2iEKey9bWrj.u7.GA/Bb9F5knCCV.UaZICJf//cep2FW", new DateOnly(1, 1, 1), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CharacterLevelRequirement", "MaxOccupants", "Name", "OwnerId", "Price", "TopSpeed", "TypeOrClass" },
                values: new object[,]
                {
                    { -3, 0, 1, "Lazer", 0, 6500000, 900f, 0 },
                    { -2, 0, 1, "Bati 801", 0, 15000, 200f, 12 },
                    { -1, 0, 2, "Zentorno", 0, 725000, 350f, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterLevelRequirement", "Damage", "FireRate", "MagazineSize", "Name", "OwnerId", "Price", "RangeInMeters", "ReloadTime", "SupportedAmmoTypes", "SupportedAttachments", "Type" },
                values: new object[,]
                {
                    { -3, 0, 0f, 0f, 0, "Knife", 0, 50, 0f, 0f, 0, 0, 0 },
                    { -2, 0, 19f, 600f, 30, "Assault Rifle", 0, 1000, 100f, 2.5f, 47, 63, 4 },
                    { -1, 0, 25f, 220f, 12, "Pistol", 0, 500, 50f, 1.5f, 0, 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "PlayerCharacters",
                columns: new[] { "Id", "Experience", "Money", "Name", "UserId" },
                values: new object[,]
                {
                    { -2, 0L, 0, "Jane Doe", -2 },
                    { -1, 0L, 0, "John Doe", -1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Clothing",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "PlayerCharacters",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "PlayerCharacters",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Clothing",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Buildings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }
    }
}
