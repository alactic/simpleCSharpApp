using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Symbol must be not be greater than 15 characters")]        
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "CompanyName must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "CompanyName must be not be greater than 250 characters")]
        public string CompanyName { get; set; } = string.Empty;
        
        [Required]
        [Range(1, 100000000, ErrorMessage = "Purchase must be within 1 and 100000000")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100, ErrorMessage = "Last Divident must be between 0.001 and 100")]
        public decimal LastDiv { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Industry must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Industry must be not be greater than 250 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000000, ErrorMessage ="Market Cap must be within 1 and 100000000")]
        public long MarketCap { get; set; }
    }
}