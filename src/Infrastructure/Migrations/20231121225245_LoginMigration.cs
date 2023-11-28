using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LoginMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("96655240-3bd8-4d8c-8825-6fe9fb78e50d"));

            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("9de2158e-a833-4352-8a1f-fb523242a558"));

            migrationBuilder.EnsureSchema(
                name: "USUARIOS");

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                schema: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                columns: new[] { "Id", "Descripcion", "Direccion", "Estado", "Fecha", "FechaCreacion", "Localidad", "Pais", "Provincia", "Tipo" },
                values: new object[,]
                {
                    { new Guid("37c61b4e-d2bb-4422-bbdf-90c8bb57dbd5"), "Me chocaron 😔", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 },
                    { new Guid("63843d61-3e2c-44d1-b58f-b14ca5c34a82"), "Lo choqué 😨", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 }
                });

            migrationBuilder.InsertData(
                schema: "USUARIOS",
                table: "USUARIOS",
                columns: new[] { "Id", "Numero", "Password", "User" },
                values: new object[] { new Guid("0499c359-107f-47c1-a118-684ba16c83b2"), 1, "1234", "a@a.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS",
                schema: "USUARIOS");

            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("37c61b4e-d2bb-4422-bbdf-90c8bb57dbd5"));

            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("63843d61-3e2c-44d1-b58f-b14ca5c34a82"));

            migrationBuilder.InsertData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                columns: new[] { "Id", "Descripcion", "Direccion", "Estado", "Fecha", "FechaCreacion", "Localidad", "Pais", "Provincia", "Tipo" },
                values: new object[,]
                {
                    { new Guid("96655240-3bd8-4d8c-8825-6fe9fb78e50d"), "Lo choqué 😨", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 },
                    { new Guid("9de2158e-a833-4352-8a1f-fb523242a558"), "Me chocaron 😔", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 }
                });
        }
    }
}
