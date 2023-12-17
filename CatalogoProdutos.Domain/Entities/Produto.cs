using CatalogoProdutos.Domain.Enums;

namespace CatalogoProdutos.Domain.Entities;

public class Produto
{
   

    public int ProdutoId { get; private set; }
    public string? Nome { get; private set; }
    public decimal Preco { get; private set;}
    public string? Descricao { get; private set; }
    public int  Quantidade { get; private set; }
    public Tipo Tipo  { get; private set; }
    public DateTime DataCadastro { get; private set; } = DateTime.Now; 


}
