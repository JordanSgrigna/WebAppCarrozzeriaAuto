using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class RelazioniMarcaModelloAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Modelli_ModelloAutoId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_ModelloAutoId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "IdSpecificaTecnica",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "ModelloAutoId",
                table: "Auto");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Modelli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelli_Marche_MarcaId",
                table: "Modelli",
                column: "MarcaId",
                principalTable: "Marche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelli_Marche_MarcaId",
                table: "Modelli");

            migrationBuilder.DropIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Modelli");

            migrationBuilder.AddColumn<int>(
                name: "IdSpecificaTecnica",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelloAutoId",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_ModelloAutoId",
                table: "Auto",
                column: "ModelloAutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Modelli_ModelloAutoId",
                table: "Auto",
                column: "ModelloAutoId",
                principalTable: "Modelli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
