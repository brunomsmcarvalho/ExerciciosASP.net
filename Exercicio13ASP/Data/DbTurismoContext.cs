using Exercicio13ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio13ASP.Data
{
    public class DbTurismoContext: DbContext
    {
        public DbTurismoContext(DbContextOptions<DbTurismoContext> options) : base(options)
        {
        }
        public DbSet<Destinos> Destinos { get; set; }
        public DbSet<Segmentos> Segmentos { get; set; }
        public DbSet<Apresentacao> Apresentacao { get; set; }

        //Se n utilizarmos o using 
        //public DbSet<Models.Apresentacao> Apresentacao { get; set; }
    }
}
