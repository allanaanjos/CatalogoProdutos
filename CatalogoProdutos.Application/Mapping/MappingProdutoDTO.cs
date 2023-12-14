using AutoMapper;
using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Domain.Entities;

namespace CatalogoProdutos.Application.Mapping
{
    public  class MappingProdutoDTO : Profile
    {
        public MappingProdutoDTO()
        {
            CreateMap<Produtos, ProdutoDTO>().ReverseMap();
        }
    }
}
