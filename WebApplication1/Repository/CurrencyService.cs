using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CurrencyService : ICurrency
    {
        private readonly DataContext _context;

        public CurrencyService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetCurrencyAsync(string id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<bool> PutCurrencyAsync(string id, Currency currency)
        {
            if (id != currency.currencyCode)
            {
                return false;
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<Currency> PostCurrencyAsync(Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();
            return currency;
        }

        public async Task<bool> DeleteCurrencyAsync(string id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return false;
            }

            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
