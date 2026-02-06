using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio13ASP.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSegmentos",
                table: "Destinos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSegmentos",
                table: "Destinos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
