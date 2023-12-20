using DesafioBackEndPL.Models;

using Microsoft.EntityFrameworkCore;

namespace DesafioBackEndPL.Data.Context
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
