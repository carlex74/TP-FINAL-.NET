using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HerenciaDeUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Planes_PlanId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Usuarios",
                newName: "IdPlan");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_PlanId",
                table: "Usuarios",
                newName: "IX_Usuarios_IdPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Planes_IdPlan",
                table: "Usuarios",
                column: "IdPlan",
                principalTable: "Planes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Planes_IdPlan",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "IdPlan",
                table: "Usuarios",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_IdPlan",
                table: "Usuarios",
                newName: "IX_Usuarios_PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Planes_PlanId",
                table: "Usuarios",
                column: "PlanId",
                principalTable: "Planes",
                principalColumn: "Id");
        }
    }
}
