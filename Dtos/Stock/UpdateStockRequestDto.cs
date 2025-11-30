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
        [MinLength(5, ErrorMessage = "Symbol must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Symbol must be not be greater than 250 characters")]        
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "CompanyName must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "CompanyName must be not be greater than 250 characters")]
        public string CompanyName { get; set; } = string.Empty;
        
        [Required]
        [MinLength(5, ErrorMessage = "Content must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Content must be not be greater than 250 characters")]
        public decimal Purchase { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "LastDiv must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "LastDiv must be not be greater than 250 characters")]
        public decimal LastDiv { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Industry must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "Industry must be not be greater than 250 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "MarketCap must be greater than 5 characters")]
        [MaxLength(250, ErrorMessage = "MarketCap must be not be greater than 250 characters")]
        public long MarketCap { get; set; }
    }
}