using CatalogoProdutos.Domain.Enums;

namespace CatalogoProdutos.Domain.Entities
{
    public class Produto
    {
        public Produto(int produtoId, string? nome, int preco, string? descricao, int quantidade, Tipo tipo, DateTime dataCadastro)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Quantidade = quantidade;
            Tipo = tipo;
            DataCadastro = dataCadastro;
        }

        public int ProdutoId { get; protected set; }
        public string? Nome { get; private set; }
        public int Preco { get; private set;}
        public string? Descricao { get; private set; }
        public int  Quantidade { get; private set; }
        public Tipo Tipo  { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now; 

        public void AlterarProduto(string? nome, int preco, string? descricao, int quantidade, Tipo tipo, DateTime dataCadastro) { }

        

    }
}
