using LocacaoNetAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LocacaoNetAPI.Data.Context
{
    public class LocacaoNetAPIContext : DbContext
    {
        public LocacaoNetAPIContext(DbContextOptions<LocacaoNetAPIContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
