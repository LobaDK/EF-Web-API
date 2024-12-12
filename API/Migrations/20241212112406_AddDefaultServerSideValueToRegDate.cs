using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultServerSideValueToRegDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "RegistrationDate",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "RegistrationDate",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "PasswordHash",
                value: "$2a$11$INNYJ290kpPjNzcN6EJWDeuzqEEFwf/Wv7YvZ6WWu5JOa6j.8840q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "PasswordHash",
                value: "$2a$11$i/FhDaald2iEKey9bWrj.u7.GA/Bb9F5knCCV.UaZICJf//cep2FW");
        }
    }
}
