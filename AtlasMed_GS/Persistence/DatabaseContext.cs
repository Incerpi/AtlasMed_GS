using AtlasMed_GS.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlasMed_GS.Persistence
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Prontuario> Prontuario { get; set; }

        public DbSet<Medicacao> Medicacao { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
