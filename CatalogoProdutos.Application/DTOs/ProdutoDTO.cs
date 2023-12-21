using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogoProdutos.Application.DTOs
{

    public class ProdutoDTO
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]      
        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o Preço da Venda")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [JsonPropertyName("Preco")]
        public decimal Preco { get; set; }

        [Required]    
        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [Required]
        [JsonPropertyName("Tipo")]
        public string? Tipo { get; set; }

        [Required]
        [JsonPropertyName("Quantidade")]
        public int Quantidade { get; set; }

    }
}
