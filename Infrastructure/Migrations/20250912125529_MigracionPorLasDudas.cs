using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPorLasDudas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocentesCurso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    LegajoDocente = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cargo = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocentesCurso", x => new { x.IdCurso, x.LegajoDocente });
                    table.ForeignKey(
                        name: "FK_DocentesCurso_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocentesCurso_Usuarios_LegajoDocente",
                        column: x => x.LegajoDocente,
                        principalTable: "Usuarios",
                        principalColumn: "Legajo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    LegajoAlumno = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    Condicion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => new { x.IdCurso, x.LegajoAlumno });
                    table.ForeignKey(
                        name: "FK_Inscripciones_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_LegajoAlumno",
                        column: x => x.LegajoAlumno,
                        principalTable: "Usuarios",
                        principalColumn: "Legajo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PlanId",
                table: "Usuarios",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DocentesCurso_LegajoDocente",
                table: "DocentesCurso",
                column: "LegajoDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_LegajoAlumno",
                table: "Inscripciones",
                column: "LegajoAlumno");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Planes_PlanId",
                table: "Usuarios",
                column: "PlanId",
                principalTable: "Planes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Planes_PlanId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "DocentesCurso");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PlanId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Usuarios");
        }
    }
}
