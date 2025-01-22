using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IRecurringTxn
    {
        Task<RecurringTxn> AddRecurringTxn(RecurringTxn recurringTxn);
        Task<List<RecurringTxn>> GetRecurringTxns();
        Task<RecurringTxn?> GetRecurringTxnById(int recurringTxnId);
        Task UpdateRecurringTxn(RecurringTxn recurringTxn);
        Task DeleteRecurringTxn(int recurringTxnId);
        Task Save();
    }
}
