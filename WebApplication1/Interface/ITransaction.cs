using static WebApplication1.Constants.MultiValues;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface ITransaction
    {
        Task<Transaction> addTransaction(Transaction txn);
        Task<List<Transaction>> GetTransaction();
        Task<Transaction?> GetTransactionById(int transactionId);
        Task<Transaction?> GetTransactionByAmt (int amount);
        Task UpdateTransaction (Transaction txn);
        Task DeleteTransaction (int transactionId);
        Task Save();
    }
}
