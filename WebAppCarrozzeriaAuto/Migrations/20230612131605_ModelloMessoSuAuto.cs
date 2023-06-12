using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class ModelloMessoSuAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelli");

            migrationBuilder.DropColumn(
                name: "Allestimento",
                table: "Auto");

            migrationBuilder.RenameColumn(
                name: "AnnoProduzione",
                table: "Auto",
                newName: "AnnoInizioProduzione");

            migrationBuilder.AddColumn<int>(
                name: "AnnoFineProduzione",
                table: "Auto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeModello",
                table: "Auto",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnoFineProduzione",
                table: "Auto");

            migrationBuilder.DropColumn(
                name: "NomeModello",
                table: "Auto");

            migrationBuilder.RenameColumn(
                name: "AnnoInizioProduzione",
                table: "Auto",
                newName: "AnnoProduzione");

            migrationBuilder.AddColumn<string>(
                name: "Allestimento",
                table: "Auto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Modelli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    AnnoFineProduzione = table.Column<int>(type: "int", nullable: true),
                    AnnoInizioProduzione = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelli_Marche_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli",
                column: "MarcaId");
        }
    }
}
