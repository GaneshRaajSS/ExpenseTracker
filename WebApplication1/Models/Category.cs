using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int categoriesId { get; set; }
        [Required]
        public int userId {get; set; }
        [Required]
        public string categoriesName { get; set; }

        public User? Users { get; set; }
    }
}
