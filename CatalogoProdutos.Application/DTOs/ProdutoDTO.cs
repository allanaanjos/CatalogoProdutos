using CatalogoProdutos.Domain.Entities;
using CatalogoProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Application.DTOs
{
    public class ProdutoDTO
    {
        public ProdutoDTO(Produto produto)
        {
            Id = produto.ProdutoId;
            Nome = produto.Nome;
            Preco = produto.Preco;
            Descricao = produto.Descricao;
            Tipo = produto.Tipo;
            Quantidade = produto.Quantidade;
            DataCadastro = produto.DataCadastro;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o Preço da Venda")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public int Preco { get; set; }

        [Required(ErrorMessage = "Descriçao é Obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
