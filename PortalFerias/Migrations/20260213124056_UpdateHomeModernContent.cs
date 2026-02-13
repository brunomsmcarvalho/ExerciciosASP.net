using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalFerias.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHomeModernContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apresentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pagina = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apresentacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Apresentacao",
                columns: new[] { "Id", "Pagina", "Texto" },
                values: new object[] { 1, "Home", "<div class='main-wrapper'>\r\n    <h1 class='titulo-home'>Bem-vindo!</h1>\r\n    \r\n    <div style='width:60px; height:4px; background-color:#0d6efd; margin:0 auto 25px auto; border-radius:2px;'></div>\r\n\r\n    <p class='subtitulo-home'>\r\n        Esta é uma página onde pode pesquisar o local ideal para passar as suas férias.\r\n    </p>\r\n\r\n    <div class='img-container-ferias'>\r\n        <img src='/images/ferias.jpg' alt='Destino de Férias'>\r\n    </div>\r\n\r\n    <p style='margin-top: 30px; color: #888; font-style: italic;'>\r\n        Obrigado pela preferência.\r\n    </p>\r\n\r\n    <div class='mt-4'>\r\n        <a href='/Home/Destinos' class='btn btn-primary btn-lg px-5 shadow-sm' \r\n           style='border-radius:50px; font-weight:600; transition: 0.3s;'>\r\n           Explorar Destinos\r\n        </a>\r\n    </div>\r\n</div>" });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "Descricao", "Pais", "Preco" },
                values: new object[,]
                {
                    { 1, "Venha conhecer a capital de um dos países mais ricos a nível cultural e natural da América do Sul, a Argentina. Visite Buenos Aires, durante 9dias/ 7noites com partidas diárias de Lisboa em voo regular, via Madrid.", "Argentina", 1321.0 },
                    { 2, "Natal ou Pipa! A escolha é sua! Aproveite esta super promoção e faça já a sua reserva. Partidas aos domingos em Julho a Setembro.", "Brasil", 680.0 },
                    { 3, "Aproveite esta super promoção e marque umas férias em Porto Seguro ou em Arraial d'Ajuda! Válido para partidas de Lisboa em voo especial terra Brasil aos domingos.", "Brasil", 750.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apresentacao");

            migrationBuilder.DropTable(
                name: "Destinos");
        }
    }
}
