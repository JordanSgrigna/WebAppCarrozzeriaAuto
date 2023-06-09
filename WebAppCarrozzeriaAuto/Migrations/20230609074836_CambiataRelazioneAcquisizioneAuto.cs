using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class CambiataRelazioneAcquisizioneAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auto_AcquisizioniAuto_AutoDaAcquisireId",
                table: "Auto");

            migrationBuilder.DropIndex(
                name: "IX_Auto_AutoDaAcquisireId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "AutoDaAcquisireId",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "IdAcquisizione",
                table: "Auto");

            migrationBuilder.AddColumn<int>(
                name: "AutoDaAcquisireId",
                table: "AcquisizioniAuto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAuto",
                table: "AcquisizioniAuto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AcquisizioniAuto_AutoDaAcquisireId",
                table: "AcquisizioniAuto",
                column: "AutoDaAcquisireId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcquisizioniAuto_Auto_AutoDaAcquisireId",
                table: "AcquisizioniAuto",
                column: "AutoDaAcquisireId",
                principalTable: "Auto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcquisizioniAuto_Auto_AutoDaAcquisireId",
                table: "AcquisizioniAuto");

            migrationBuilder.DropIndex(
                name: "IX_AcquisizioniAuto_AutoDaAcquisireId",
                table: "AcquisizioniAuto");

            migrationBuilder.DropColumn(
                name: "AutoDaAcquisireId",
                table: "AcquisizioniAuto");

            migrationBuilder.DropColumn(
                name: "IdAuto",
                table: "AcquisizioniAuto");

            migrationBuilder.AddColumn<int>(
                name: "AutoDaAcquisireId",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAcquisizione",
                table: "Auto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Auto_AutoDaAcquisireId",
                table: "Auto",
                column: "AutoDaAcquisireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auto_AcquisizioniAuto_AutoDaAcquisireId",
                table: "Auto",
                column: "AutoDaAcquisireId",
                principalTable: "AcquisizioniAuto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
