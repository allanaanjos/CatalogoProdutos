using CatalogoProdutos.Domain.Entities;

namespace CatalogoProdutos.Domain.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetByIdAsync(int? id);
        Task<Produto> CreateAsync(Produto produtos);
        Task<Produto> UpdateAsync(Produto produtos);
        Task<Produto> RemoveAsync(Produto produtos);
        void SaveChangesAsync();
    }
}
