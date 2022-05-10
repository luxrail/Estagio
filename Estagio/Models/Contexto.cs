using Microsoft.EntityFrameworkCore;
namespace Estagio.Models
{
        public class Contexto : DbContext
        {
            public Contexto(DbContextOptions<Contexto> options) : base(options)
            {

            }
            public DbSet<estagio.Models.Funcionarios> Funcionarios { get; set; }

        }
}


