using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApplication1.Constants.MultiValues;

namespace WebApplication1.Models
{
    public class Transaction
    {
        [Required]
        [Key]
        public int transactionId {  get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int categoriesId {  get; set; }
        [Required]
        [DefaultValue(Txn_Type_Status.Debit)]
        public Txn_Type_Status txn_Type { get; set; }
        [Required]
        [Precision(18,2)]
        public decimal amount {  get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime txnDate { get; set; }
        public string description {  get; set; }
        public bool? recurring {  get; set; }
        [Required]
        public Txn_Method_Status payment_Method {  get; set; }
        [Required]
        public string currencyCode { get; set; } 
        public Currency? Currencies { get; set; }
        public User? Users { get; set; }
        public Category? Categories { get; set; }
    }
}
