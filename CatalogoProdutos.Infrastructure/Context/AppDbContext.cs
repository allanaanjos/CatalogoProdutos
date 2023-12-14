using CatalogoProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Produtos>().HasKey(c => c.ProdutoId);
            
            mb.Entity<Produtos>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produtos>().Property(c => c.PrecoDeVenda).HasPrecision(14, 2);
            mb.Entity<Produtos>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();
            mb.Entity<Produtos>().Property(c => c.Tipo).IsRequired();
            mb.Entity<Produtos>().Property(c => c.Quantidade).IsRequired();
            mb.Entity<Produtos>().Property(c => c.DataCadastro).IsRequired();
        }
    }
}
