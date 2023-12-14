namespace CatalogoProdutos.Domain.Entities
{
    public class Produtos 
    {
        public Produtos(int produtoId, string? nome, int precoDeVenda, string? descricao, int quantidade, string? tipo, DateTime dataCadastro)
        {
            ProdutoId = produtoId;
            Nome = nome;
            PrecoDeVenda = precoDeVenda;
            Descricao = descricao;
            Quantidade = quantidade;
            Tipo = tipo;
            DataCadastro = dataCadastro;
        }

        public int ProdutoId { get; protected set; }
        public string? Nome { get; private set; }
        public int PrecoDeVenda { get; private set;}
        public string? Descricao { get; private set; }
        public int  Quantidade { get; private set; }
        public string? Tipo  { get; private set; }
        public DateTime DataCadastro { get; private set; } 

        

    }
}
