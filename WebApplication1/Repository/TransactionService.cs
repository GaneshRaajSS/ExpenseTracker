using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;
using WebApplication1.Models;
using System.Linq;
using WebApplication1.DTO;

namespace WebApplication1.Repository
{
    public class TransactionService : ITransaction
    {
        private readonly DataContext _context;
        public TransactionService(DataContext context) 
        {
            _context = context;
        }

        public async Task<Transaction> addTransaction(Transaction txn)
        {
            try
            {
                await _context.Transactions.AddAsync(txn);
                await Save();
            }
            catch (Exception ex) 
            { 
                throw(ex);
            }
            return txn;
        }

        public async Task DeleteTransaction(int transactionId )
        {
            var txn = await GetTransactionById(transactionId);

            try
            {
                _context.Transactions.Remove(txn);
                await Save();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public async Task<List<TransactionDTO>> Get5Transaction()
        {
            return await _context.Transactions
                          .OrderByDescending(t => t.txnDate)
                          .Take(5)
                          .Select(t=> new TransactionDTO
                          {
                              transactionId = t.transactionId,
                              userId = t.userId,
                              categoriesId = t.categoriesId,
                              txn_Type = t.txn_Type,
                              amount = t.amount,
                              txnDate = t.txnDate,
                              description = t.description,
                              recurring = t.recurring,
                              payment_Method = t.payment_Method,
                              currencyCode = t.currencyCode
                          })
                          .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransaction()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetTransactionByAmt(int amount)
        {
            return await _context.Transactions.FirstOrDefaultAsync(u => u.amount == amount);
        }

        public async Task<Transaction?> GetTransactionById(int transactionId)
        {
            return await _context.Transactions.FirstOrDefaultAsync(u => u.transactionId == transactionId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransaction(Transaction txn)
        {
            try
            {
                _context.Entry(txn).State = EntityState.Modified;
                await Save();
            }
            catch (Exception ex) 
            {
                throw(ex);
            }
        }
    }
}
