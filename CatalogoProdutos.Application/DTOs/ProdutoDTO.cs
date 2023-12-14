using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Application.DTOs
{
    public class ProdutoDTO
    {
        public ProdutoDTO(int id, string nome, int preco, string descricao, string tipo, int quantidade, DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Tipo = tipo;
            Quantidade = quantidade;
            DataCadastro = dataCadastro;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Preço da Venda")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public int Preco { get; set; }

        [Required(ErrorMessage = "Descriçao é Obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required]
        public string Tipo { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
