using CatalogoProdutos.Application.Mapping;
using CatalogoProdutos.Application.Service;
using CatalogoProdutos.Domain.Interface;
using CatalogoProdutos.Infrastructure.Context;
using CatalogoProdutos.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogoProdutos.CrossCutting.Ioc
{
    public static class DependencyInjectionApi
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services)
        {  

           services.AddScoped<ProdutoService>();
           services.AddScoped<IProdutoRepository, ProdutoRepository>();

           services.AddAutoMapper(typeof(MappingProdutoDTO));

            

            return services;
        }
    }
}
