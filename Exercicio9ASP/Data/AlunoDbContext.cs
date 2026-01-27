using Microsoft.EntityFrameworkCore;
using Exercicio9ASP.Models;

namespace Exercicio9ASP.Data
{
    public class AlunoDbContext : DbContext 
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
