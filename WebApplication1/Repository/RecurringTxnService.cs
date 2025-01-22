using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class RecurringTxnService : IRecurringTxn
    {
        private readonly DataContext _context;

        public RecurringTxnService(DataContext context)
        {
            _context = context;
        }

        public async Task<RecurringTxn> AddRecurringTxn(RecurringTxn recurringTxn)
        {
            try
            {
                await _context.RecurringTxns.AddAsync(recurringTxn);
                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return recurringTxn;
        }

        public async Task DeleteRecurringTxn(int recurringTxnId)
        {
            var recurringTxn = await GetRecurringTxnById(recurringTxnId);

            if (recurringTxn == null) throw new Exception("Recurring Transaction not found");

            try
            {
                _context.RecurringTxns.Remove(recurringTxn);
                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RecurringTxn>> GetRecurringTxns()
        {
            return await _context.RecurringTxns.ToListAsync();
        }

        public async Task<RecurringTxn?> GetRecurringTxnById(int recurringTxnId)
        {
            return await _context.RecurringTxns.FirstOrDefaultAsync(r => r.recurringTxnId == recurringTxnId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecurringTxn(RecurringTxn recurringTxn)
        {
            try
            {
                _context.Entry(recurringTxn).State = EntityState.Modified;
                await Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
