using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurringTxnsController : ControllerBase
    {
        private readonly IRecurringTxn _recurringTxn;

        public RecurringTxnsController(IRecurringTxn recurringTxn)
        {
            _recurringTxn = recurringTxn;
        }

        // GET: api/RecurringTxns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecurringTxn>>> GetRecurringTxns()
        {
            return await _recurringTxn.GetRecurringTxns();
        }

        // GET: api/RecurringTxns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecurringTxn>> GetRecurringTxn(int id)
        {
            var recurringTxn = await _recurringTxn.GetRecurringTxnById(id);

            if (recurringTxn == null)
            {
                return NotFound();
            }

            return recurringTxn;
        }

        // PUT: api/RecurringTxns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurringTxn(int id, RecurringTxn recurringTxn)
        {
            if (id != recurringTxn.recurringTxnId)
            {
                return BadRequest();
            }

            try
            {
                await _recurringTxn.UpdateRecurringTxn(recurringTxn);
            }
            catch
            {
                if (await _recurringTxn.GetRecurringTxnById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RecurringTxns
        [HttpPost]
        public async Task<ActionResult<RecurringTxn>> PostRecurringTxn(RecurringTxn recurringTxn)
        {
            try
            {
                await _recurringTxn.AddRecurringTxn(recurringTxn);
                return CreatedAtAction("GetRecurringTxn", new { id = recurringTxn.recurringTxnId }, recurringTxn);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating recurring transaction: {ex.Message}");
            }
        }

        // DELETE: api/RecurringTxns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurringTxn(int id)
        {
            try
            {
                var recurringTxn = await _recurringTxn.GetRecurringTxnById(id);
                if (recurringTxn == null)
                {
                    return NotFound();
                }
                await _recurringTxn.DeleteRecurringTxn(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting recurring transaction: {ex.Message}");
            }
        }
    }
}
