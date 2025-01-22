using static WebApplication1.Constants.MultiValues;
using WebApplication1.Models;
using WebApplication1.DTO;

namespace WebApplication1.Interface
{
    public interface ITransaction
    {
        Task<Transaction> addTransaction(Transaction txn);
        Task<List<Transaction>> GetTransaction();
        Task<List<TransactionDTO>> Get5Transaction();
        Task<Transaction?> GetTransactionById(int transactionId);
        Task<Transaction?> GetTransactionByAmt (int amount);
        Task UpdateTransaction (Transaction txn);
        Task DeleteTransaction (int transactionId);
        Task Save();
    }
}
