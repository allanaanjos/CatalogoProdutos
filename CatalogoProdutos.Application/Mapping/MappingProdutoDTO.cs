using AutoMapper;
using CatalogoProdutos.Application.DTOs;
using CatalogoProdutos.Domain.Entities;

namespace CatalogoProdutos.Application.Mapping
{
    public  class MappingProdutoDTO : Profile
    {
        public MappingProdutoDTO()
        {
            CreateMap<Produto, ProdutoDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProdutoId));


            CreateMap<ProdutoDTO, Produto>()
           .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src=>  DateTime.Now));

        }
    }
}
