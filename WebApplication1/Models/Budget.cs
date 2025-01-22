using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Budget
    {
        [Key]
        [Required]
        public int budgetId {  get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int totalBudget {  get; set; }
        public int Threshold {  get; set; }

        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public User? Users { get; set; }
    }
}
