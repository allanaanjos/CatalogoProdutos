using CatalogoProdutos.Application.DTOs;

namespace CatalogoProdutos.Application.Interface
{
    public interface IProdutoService  
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetProdutoById(int id);
        Task Add(ProdutoDTO produtoDTO);
        Task Update(ProdutoDTO produtoDTO);
        Task Remove(int id);
    }
}
