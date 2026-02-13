using Microsoft.EntityFrameworkCore;
using PortalFerias.Models;

namespace PortalFerias.Data
{
    public class DbPortalFeriasContext : DbContext
    {
        
        public DbPortalFeriasContext(DbContextOptions<DbPortalFeriasContext> options)
            : base(options) 
        {
        }

        public DbSet<Apresentacao_BC> Apresentacao { get; set; }
        public DbSet<Destino_BC> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Nutre o banco de dados com dados iniciais para Apresentacao
            modelBuilder.Entity<Apresentacao_BC>().HasData(
                new Apresentacao_BC
                {
                    Id = 1,
                    Pagina = "Home",
                    Texto = @"<div class='main-wrapper'>
    <h1 class='titulo-home'>Bem-vindo!</h1>
    
    <div style='width:60px; height:4px; background-color:#0d6efd; margin:0 auto 25px auto; border-radius:2px;'></div>

    <p class='subtitulo-home'>
        Esta é uma página onde pode pesquisar o local ideal para passar as suas férias.
    </p>

    <div class='img-container-ferias'>
        <img src='/images/ferias.jpg' alt='Destino de Férias'>
    </div>

    <p style='margin-top: 30px; color: #888; font-style: italic;'>
        Obrigado pela preferência.
    </p>

    <div class='mt-4'>
        <a href='/Home/Destinos' class='btn btn-primary btn-lg px-5 shadow-sm' 
           style='border-radius:50px; font-weight:600; transition: 0.3s;'>
           Explorar Destinos
        </a>
    </div>
</div>"
                }
            );

            // NUtre o banco de dados com dados iniciais para Destinos
            modelBuilder.Entity<Destino_BC>().HasData(
                new Destino_BC
                {
                    Id = 1,
                    Pais = "Argentina",
                    Descricao = "Venha conhecer a capital de um dos países mais ricos a nível cultural e natural da América do Sul, a Argentina. Visite Buenos Aires, durante 9dias/ 7noites com partidas diárias de Lisboa em voo regular, via Madrid.",
                    Preco = 1321
                },
                new Destino_BC
                {
                    Id = 2,
                    Pais = "Brasil",
                    Descricao = "Natal ou Pipa! A escolha é sua! Aproveite esta super promoção e faça já a sua reserva. Partidas aos domingos em Julho a Setembro.",
                    Preco = 680
                },
                new Destino_BC
                {
                    Id = 3,
                    Pais = "Brasil",
                    Descricao = "Aproveite esta super promoção e marque umas férias em Porto Seguro ou em Arraial d'Ajuda! Válido para partidas de Lisboa em voo especial terra Brasil aos domingos.",
                    Preco = 750
                }
            );
        }
    }
}

