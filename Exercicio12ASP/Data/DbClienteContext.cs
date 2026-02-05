using Microsoft.EntityFrameworkCore;
using Exercicio12ASP.Models;

namespace Exercicio12ASP.Data;

    public class DbClienteContext : DbContext
    {
        public DbClienteContext(DbContextOptions<DbClienteContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }

