using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Stodk
{
    public class CreateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol no puede tener mas de 10 caracateres")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "Company name no puede tener mas de 50 caracateres")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Nombre de industria no puede estar por encima de 50 caracteres")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 50000000000)]
        public long MarketCap { get; set; }
    }
}
