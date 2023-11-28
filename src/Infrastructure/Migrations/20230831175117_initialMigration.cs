using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SINIESTROS");

            migrationBuilder.CreateTable(
                name: "SINIESTROS",
                schema: "SINIESTROS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINIESTROS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TERCEROS",
                schema: "SINIESTROS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    SiniestroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TERCEROS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TERCEROS_SINIESTROS_SiniestroId",
                        column: x => x.SiniestroId,
                        principalSchema: "SINIESTROS",
                        principalTable: "SINIESTROS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "SINIESTROS",
                table: "SINIESTROS",
                columns: new[] { "Id", "Descripcion", "Direccion", "Estado", "Fecha", "FechaCreacion", "Localidad", "Pais", "Provincia", "Tipo" },
                values: new object[,]
                {
                    { new Guid("96655240-3bd8-4d8c-8825-6fe9fb78e50d"), "Lo choqué 😨", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 },
                    { new Guid("9de2158e-a833-4352-8a1f-fb523242a558"), "Me chocaron 😔", "Av. Corrientes 1234", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CABA", "Argentina", "CABA", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TERCEROS_SiniestroId",
                schema: "SINIESTROS",
                table: "TERCEROS",
                column: "SiniestroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TERCEROS",
                schema: "SINIESTROS");

            migrationBuilder.DropTable(
                name: "SINIESTROS",
                schema: "SINIESTROS");
        }
    }
}
