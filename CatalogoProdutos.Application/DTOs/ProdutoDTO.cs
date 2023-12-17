using CatalogoProdutos.Domain.Entities;
using CatalogoProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogoProdutos.Application.DTOs
{
    
    public class ProdutoDTO
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o Preço da Venda")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [JsonPropertyName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Descriçao é Obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        [JsonPropertyName("Descrição")]
        public string? Descricao { get; set; }

        [Required]
        [JsonPropertyName("Tipo")]
        public Tipo Tipo { get; set; }

        [Required]
        [JsonPropertyName("Quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("Data de Cadastro")]
        public DateTime DatadeCadastro { get; set; } = DateTime.Now.ToLocalTime();

    }
}
