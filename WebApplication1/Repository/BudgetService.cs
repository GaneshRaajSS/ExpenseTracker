using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BudgetService : IBudget
    {
        private readonly DataContext _context;

        public BudgetService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task<Budget> GetBudgetAsync(int id)
        {
            return await _context.Budgets.FindAsync(id);
        }

        public async Task<bool> PutBudgetAsync(int id, Budget budget)
        {
            if (id != budget.budgetId)
            {
                return false;
            }

            _context.Entry(budget).State = EntityState.Modified;

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

        public async Task<Budget> PostBudgetAsync(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();
            return budget;
        }

        public async Task<bool> DeleteBudgetAsync(int id)
        {
            var budget = await _context.Budgets.FindAsync(id);
            if (budget == null)
            {
                return false;
            }

            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
