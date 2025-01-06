using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddDamageToWeaponKnifeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "PasswordHash",
                value: "$2a$11$8YjKg0yT3YxIOHsW1R5D1.t0a9yEorVtozgzdbjXRqalI.ukLyCbG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$11$NyEoWZd4u.ErqIzREDN2TeLoyHIcMli.SWigUNKaINruF4Sq4w2Gu");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -3,
                column: "Damage",
                value: 50f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "PasswordHash",
                value: "$2a$11$NomYzvDxJDy/PpzYGsAE1eTMsrCoyOZoOm.NZMijmDYaGZhca0Uqi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$11$OVKi2NRoeUuDJT8p240rz.1Ug75FarF2jUdrzM8blG2E6u3TAc0n.");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -3,
                column: "Damage",
                value: 0f);
        }
    }
}
