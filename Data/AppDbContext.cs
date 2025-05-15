using Microsoft.EntityFrameworkCore;
using Coontrera.Models; // Ajuste conforme onde estão seus Models

namespace Coontrera.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<AulaTeste> AulasTeste { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<NivelUsuario> NiveisUsuario { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
