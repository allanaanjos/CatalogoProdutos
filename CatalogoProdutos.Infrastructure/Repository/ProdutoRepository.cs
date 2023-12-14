using CatalogoProdutos.Domain.Entities;
using CatalogoProdutos.Domain.Interface;
using CatalogoProdutos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produtos> CreateAsync(Produtos produtos)
        {
            _context.Add(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produtos> RemoveAsync(Produtos produtos)
        {
            _context.Remove(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produtos?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produtos>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produtos> UpdateAsync(Produtos produtos)
        {
            _context.Update(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }
    }
}
