using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppCarrozzeriaAuto.Migrations
{
    /// <inheritdoc />
    public partial class KilometraggioAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Kilometraggio",
                table: "Auto",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometraggio",
                table: "Auto");
        }
    }
}
