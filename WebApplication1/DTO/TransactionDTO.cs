using Microsoft.EntityFrameworkCore;
using static WebApplication1.Constants.MultiValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class TransactionDTO
    {
        public int transactionId { get; set; }
        public int userId { get; set; }
        public int categoriesId { get; set; }
        [DefaultValue(Txn_Type_Status.Debit)]
        public Txn_Type_Status txn_Type { get; set; }
        [Precision(18, 2)]
        public decimal amount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime txnDate { get; set; }
        public string description { get; set; }
        public bool? recurring { get; set; }
        public Txn_Method_Status payment_Method { get; set; }
        public string currencyCode { get; set; }
    }
}
