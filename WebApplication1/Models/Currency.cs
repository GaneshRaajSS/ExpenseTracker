using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Currency
    {
        [Key]
        [Required]
        public int currencyId {  get; set; }
        [Required]
        public string currencyCode { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal exchangeRate {  get; set; } 
    }
}
