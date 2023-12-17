using AutoMapper;
using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Domain.Entities;
using CatalogoProdutos.Domain.Interface;
using System.Collections;

namespace CatalogoProdutos.Application.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetProdutoById(int? id);
        Task Add(ProdutoDTO produtoDTO);
        Task Update(ProdutoDTO produtoDTO);
        Task Remove(int? id);
    }

    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _mapper = mapper;
        }

        public async Task Add(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.CreateAsync(produto);
        }

        public async Task<ProdutoDTO> GetProdutoById(int? id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);

        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produto = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
        }
        
        public async Task Remove(int? id)
        {
            var produto = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produto);

        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            var produto = await _produtoRepository.GetByIdAsync(produtoDTO.Id);
            _mapper.Map<ProdutoDTO>(produto);
        }
    }
}
