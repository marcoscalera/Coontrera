using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Coontrera.Models;

namespace Coontrera.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
    }
}
