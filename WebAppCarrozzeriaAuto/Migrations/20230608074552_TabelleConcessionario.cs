using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class TabelleConcessionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcquisizioniAuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAcquisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeFornitore = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Usata = table.Column<bool>(type: "bit", nullable: false),
                    PrezzoUnitarioMacchina = table.Column<decimal>(type: "DECIMAL(15,4)", nullable: false),
                    PrezzoTotale = table.Column<decimal>(type: "DECIMAL(15,4)", nullable: false),
                    NumeroMacchineAcquistate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcquisizioniAuto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaeseOrigine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usata = table.Column<bool>(type: "bit", nullable: false),
                    UrlImmagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colore = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prezzo = table.Column<decimal>(type: "DECIMAL(15,4)", nullable: false),
                    AnnoProduzione = table.Column<int>(type: "int", nullable: false),
                    AnnoImmatricolazione = table.Column<int>(type: "int", nullable: true),
                    NumeroAutoNelConcessionario = table.Column<int>(type: "int", nullable: false),
                    NumeroLikeUtenti = table.Column<int>(type: "int", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    MarcaAutoId = table.Column<int>(type: "int", nullable: false),
                    idSpecificaTecnica = table.Column<int>(type: "int", nullable: false),
                    IdAcquisizione = table.Column<int>(type: "int", nullable: false),
                    AutoDaAcquisireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auto_AcquisizioniAuto_AutoDaAcquisireId",
                        column: x => x.AutoDaAcquisireId,
                        principalTable: "AcquisizioniAuto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auto_Marche_MarcaAutoId",
                        column: x => x.MarcaAutoId,
                        principalTable: "Marche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    AnnoInizioProduzione = table.Column<int>(type: "int", nullable: false),
                    AnnoFineProduzione = table.Column<int>(type: "int", nullable: true),
                    IdTipoMacchina = table.Column<int>(type: "int", nullable: false),
                    TipoMacchinaId = table.Column<int>(type: "int", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Modelli_Tipi_TipoMacchinaId",
                        column: x => x.TipoMacchinaId,
                        principalTable: "Tipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificheTecniche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alimentazione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Potenza = table.Column<short>(type: "smallint", nullable: false),
                    Cambio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Trazione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClasseEmissioni = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConsumoUrbano = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: true),
                    ConsumoExtraUrbano = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: true),
                    ConsumoMisto = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: true),
                    AutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificheTecniche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificheTecniche_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenditeAuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrarioVendita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeUtente = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CognomeUtente = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    EmailUtente = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    QuantitaAuto = table.Column<byte>(type: "tinyint", nullable: false),
                    PrezzoTotale = table.Column<float>(type: "real", nullable: false),
                    AutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenditeAuto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenditeAuto_Auto_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Auto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auto_AutoDaAcquisireId",
                table: "Auto",
                column: "AutoDaAcquisireId");

            migrationBuilder.CreateIndex(
                name: "IX_Auto_MarcaAutoId",
                table: "Auto",
                column: "MarcaAutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_MarcaId",
                table: "Modelli",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelli_TipoMacchinaId",
                table: "Modelli",
                column: "TipoMacchinaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificheTecniche_AutoId",
                table: "SpecificheTecniche",
                column: "AutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VenditeAuto_AutoId",
                table: "VenditeAuto",
                column: "AutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelli");

            migrationBuilder.DropTable(
                name: "SpecificheTecniche");

            migrationBuilder.DropTable(
                name: "VenditeAuto");

            migrationBuilder.DropTable(
                name: "Tipi");

            migrationBuilder.DropTable(
                name: "Auto");

            migrationBuilder.DropTable(
                name: "AcquisizioniAuto");

            migrationBuilder.DropTable(
                name: "Marche");
        }
    }
}
