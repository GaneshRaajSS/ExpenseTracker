using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IBudget
    {
        Task<IEnumerable<Budget>> GetBudgetsAsync();
        Task<Budget> GetBudgetAsync(int id);
        Task<bool> PutBudgetAsync(int id, Budget budget);
        Task<Budget> PostBudgetAsync(Budget budget);
        Task<bool> DeleteBudgetAsync(int id);
    }
}
