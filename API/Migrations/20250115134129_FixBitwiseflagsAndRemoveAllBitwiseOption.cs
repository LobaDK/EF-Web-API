using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class FixBitwiseflagsAndRemoveAllBitwiseOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "PasswordHash",
                value: "$2a$11$pEFhEnlBVjciibc2Ufyiau2QsOHFsStGCMV0oszJ61GrGYuYTcTTi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$11$p86aIfk95g/vbTBXozWUYu1pPposAsx9NoqMlvu2cPvvt6JCKvwxO");

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 95, 126 });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 1, 28 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 47, 63 });

            migrationBuilder.UpdateData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "SupportedAmmoTypes", "SupportedAttachments" },
                values: new object[] { 0, 14 });
        }
    }
}
