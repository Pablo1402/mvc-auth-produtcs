using App.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext( DbContextOptions options): base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos  { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MvcDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
