using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class CambiateRelazioniTabelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelli_Marche_MarcaId",
                table: "Modelli");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelli_Tipi_TipoMacchinaId",
                table: "Modelli");

            migrationBuilder.DropIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli");

            migrationBuilder.DropIndex(
                name: "IX_Modelli_TipoMacchinaId",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "Allestimento",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "IdTipoMacchina",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Modelli");

            migrationBuilder.DropColumn(
                name: "TipoMacchinaId",
                table: "Modelli");

            migrationBuilder.RenameColumn(
                name: "idSpecificaTecnica",
                table: "Auto",
                newName: "IdSpecificaTecnica");

            migrationBuilder.AddColumn<string>(
                name: "Allestimento",
                table: "Auto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdModello",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
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

            migrationBuilder.AddColumn<int>(
                name: "TipoAutoId",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_ModelloAutoId",
                table: "Auto",
                column: "ModelloAutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Auto_TipoAutoId",
                table: "Auto",
                column: "TipoAutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Modelli_ModelloAutoId",
                table: "Auto",
                column: "ModelloAutoId",
                principalTable: "Modelli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_Tipi_TipoAutoId",
                table: "Auto",
                column: "TipoAutoId",
                principalTable: "Tipi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Modelli_ModelloAutoId",
                table: "Auto");

            migrationBuilder.DropForeignKey(
                name: "FK_Auto_Tipi_TipoAutoId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_ModelloAutoId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_TipoAutoId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "Allestimento",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "IdModello",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "ModelloAutoId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "TipoAutoId",
                table: "Auto");

            migrationBuilder.RenameColumn(
                name: "IdSpecificaTecnica",
                table: "Auto",
                newName: "idSpecificaTecnica");

            migrationBuilder.AddColumn<string>(
                name: "Allestimento",
                table: "Modelli",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "Modelli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoMacchina",
                table: "Modelli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Modelli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoMacchinaId",
                table: "Modelli",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_TipoMacchinaId",
                table: "Modelli",
                column: "TipoMacchinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelli_Marche_MarcaId",
                table: "Modelli",
                column: "MarcaId",
                principalTable: "Marche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelli_Tipi_TipoMacchinaId",
                table: "Modelli",
                column: "TipoMacchinaId",
                principalTable: "Tipi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
