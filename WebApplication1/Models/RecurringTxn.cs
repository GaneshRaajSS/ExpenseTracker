using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Models
{
    public class RecurringTxn
    {
        [Key]
        [Required]
        public int recurringTxnId { get; set; }
        [Required]
        public int userId {  get; set; }
        [Required]
        public int transactionId { get; set; }
        [Required]
        [DefaultValue(Frequency_Status.Daily)]
        public Frequency_Status? frequencyStatus { get; set; } = Frequency_Status.Daily;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime recurrableDate { get; set; }

        public User? Users { get; set; }
        public Transaction? Transactions { get; set; }
    }
}
