using Exercicio14ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio14ASP.Data
{
    public class DbMiniCMSContext : DbContext
    {
        public DbMiniCMSContext(DbContextOptions<DbMiniCMSContext> options) : base(options)
        {
        }
        public DbSet<Conteudo> Conteudos { get; set; }
    }

}
