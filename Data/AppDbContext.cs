using Microsoft.EntityFrameworkCore;
using Coontrera.Models; // Ajuste conforme onde estão seus Models

namespace Coontrera.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Agenda> Agendas { get; set; } = null!;
        public DbSet<AulaTeste> AulasTeste { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Foto> Fotos { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<NivelUsuario> NiveisUsuario { get; set; } = null!;
        public DbSet<Pagina> Paginas { get; set; } = null!;
        public DbSet<Servico> Servicos { get; set; } = null!;
    }
}
