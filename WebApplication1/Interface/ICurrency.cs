using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICurrency
    {
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
        Task<Currency> GetCurrencyAsync(string id);
        Task<bool> PutCurrencyAsync(string id, Currency currency);
        Task<Currency> PostCurrencyAsync(Currency currency);
        Task<bool> DeleteCurrencyAsync(string id);
    }
}
