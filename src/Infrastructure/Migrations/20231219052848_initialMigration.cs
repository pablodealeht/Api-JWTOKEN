using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "USUARIOS");

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

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                schema: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "USUARIOS",
                table: "USUARIOS",
                columns: new[] { "Id", "Numero", "Password", "Perfil", "User" },
                values: new object[] { new Guid("b00772e2-070b-470a-8ec2-899584191160"), 1, "1234", 1, "a@a.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERSONAL",
                schema: "USUARIOS");

            migrationBuilder.DropTable(
                name: "USUARIOS",
                schema: "USUARIOS");
        }
    }
}
