using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Models
{
    public class User
    {
        [Required]
        [Key]
        public int userId { get; set; }
        public string? userName { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain Uppercase, alphanumeric and special characters")]
        public string? password { get; set; }
        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? phone { get; set; }

        [Required]
        [DefaultValue(UserRole.User)]
        public UserRole? Role { get; set; } = UserRole.User;

        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<RecurringTxn>? RecurringTxns { get; set; }
        public ICollection<Budget>? Budgets { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
