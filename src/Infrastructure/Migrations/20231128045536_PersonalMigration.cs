using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PersonalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                schema: "USUARIOS",
                table: "USUARIOS",
                keyColumn: "Id",
                keyValue: new Guid("0499c359-107f-47c1-a118-684ba16c83b2"));

            migrationBuilder.CreateTable(
                name: "PERSONAL",
                schema: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    registerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    businessLocation = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONAL", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                columns: new[] { "Id", "Descripcion", "Direccion", "Estado", "Fecha", "FechaCreacion", "Localidad", "Pais", "Provincia", "Tipo" },
                values: new object[,]
                {
                    { new Guid("666b3523-ce67-4122-b8e4-9a6e573e2282"), "Me chocaron 😔", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 },
                    { new Guid("c9015d5e-eb49-4896-a525-6e8cf8d5dff6"), "Lo choqué 😨", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 }
                });

            migrationBuilder.InsertData(
                schema: "USUARIOS",
                table: "USUARIOS",
                columns: new[] { "Id", "Numero", "Password", "User" },
                values: new object[] { new Guid("ed88bfeb-17b4-43ff-b939-34091e908d30"), 1, "1234", "a@a.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERSONAL",
                schema: "USUARIOS");

            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("666b3523-ce67-4122-b8e4-9a6e573e2282"));

            migrationBuilder.DeleteData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                keyColumn: "Id",
                keyValue: new Guid("c9015d5e-eb49-4896-a525-6e8cf8d5dff6"));

            migrationBuilder.DeleteData(
                schema: "USUARIOS",
                table: "USUARIOS",
                keyColumn: "Id",
                keyValue: new Guid("ed88bfeb-17b4-43ff-b939-34091e908d30"));

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
    }
}
