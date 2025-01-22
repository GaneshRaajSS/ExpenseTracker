using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudget _budgetService;

        public BudgetsController(IBudget budgetService)
        {
            _budgetService = budgetService;
        }

        // GET: api/Budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetBudgets()
        {
            return Ok(await _budgetService.GetBudgetsAsync());
        }

        // GET: api/Budgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudget(int id)
        {
            var budget = await _budgetService.GetBudgetAsync(id);
            if (budget == null)
            {
                return NotFound();
            }

            return Ok(budget);
        }

        // PUT: api/Budgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudget(int id, Budget budget)
        {
            if (!await _budgetService.PutBudgetAsync(id, budget))
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Budgets
        [HttpPost]
        public async Task<ActionResult<Budget>> PostBudget(Budget budget)
        {
            var createdBudget = await _budgetService.PostBudgetAsync(budget);
            return CreatedAtAction("GetBudget", new { id = createdBudget.budgetId }, createdBudget);
        }

        // DELETE: api/Budgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            if (!await _budgetService.DeleteBudgetAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
