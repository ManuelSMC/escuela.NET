using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace escuela.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Padres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PadreId = table.Column<int>(type: "int", nullable: false),
                    MadreId = table.Column<int>(type: "int", nullable: false),
                    EscuelaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Escuelas_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "Escuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_Padres_MadreId",
                        column: x => x.MadreId,
                        principalTable: "Padres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alumnos_Padres_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Padres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_EscuelaId",
                table: "Alumnos",
                column: "EscuelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_MadreId",
                table: "Alumnos",
                column: "MadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_PadreId",
                table: "Alumnos",
                column: "PadreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Escuelas");

            migrationBuilder.DropTable(
                name: "Padres");
        }
    }
}
