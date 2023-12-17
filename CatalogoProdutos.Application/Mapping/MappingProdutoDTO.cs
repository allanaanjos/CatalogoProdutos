using AutoMapper;
using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Domain.Entities;

namespace CatalogoProdutos.Application.Mapping
{
    public  class MappingProdutoDTO : Profile
    {
        public MappingProdutoDTO()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap().ForMember(d => d.DataCadastro, o => o.MapFrom(o => DateTime.Now));
        }
    }
}
