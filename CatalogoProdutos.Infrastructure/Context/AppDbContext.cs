using CatalogoProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
           
            mb.Entity<Produto>().HasKey(c => c.ProdutoId);
            mb.Entity<Produto>().Property(x => x.ProdutoId).ValueGeneratedOnAdd();

            mb.Entity<Produto>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produto>().Property(c => c.Preco).HasPrecision(14, 2);
            mb.Entity<Produto>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();
            mb.Entity<Produto>().Property(c => c.Tipo).IsRequired();
            mb.Entity<Produto>().Property(c => c.Quantidade).IsRequired(); 

           
        }
    }
}
