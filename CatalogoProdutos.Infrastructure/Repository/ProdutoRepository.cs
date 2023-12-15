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

        public async Task<Produto> CreateAsync(Produto produtos)
        {
            _context.Add(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produto> RemoveAsync(Produto produtos)
        {
            _context.Remove(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> UpdateAsync(Produto produtos)
        {
            _context.Update(produtos);
            await _context.SaveChangesAsync();
            return produtos;
        }

       
    }
}
