using CatalogoProdutos.Domain.Entities;

namespace CatalogoProdutos.Domain.Interface
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produtos>> GetProdutosAsync();
        Task<Produtos?> GetByIdAsync(int id);
        Task<Produtos> CreateAsync(Produtos produtos);
        Task<Produtos> UpdateAsync(Produtos produtos);
        Task<Produtos> RemoveAsync(Produtos produtos);
    }
}
