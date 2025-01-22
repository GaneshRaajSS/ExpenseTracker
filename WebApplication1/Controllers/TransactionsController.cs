using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITransaction _transaction;

        public TransactionsController(DataContext context, ITransaction iTxn)
        {
            _context = context;
            _transaction = iTxn;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _transaction.GetTransaction();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _transaction.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.transactionId)
            {
                return BadRequest();
            }

            try
            {
                await _transaction.UpdateTransaction(transaction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            try
            {
                _transaction.addTransaction(transaction);
                return CreatedAtAction("GetTransaction", new { id = transaction.transactionId }, transaction);
            }
            catch (Exception ex)
            {
                return BadRequest($"error Updating:{ ex}");
            }
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                var txn = await _transaction.GetTransactionById(id);
                if (txn == null)
                {
                    return NotFound();
                }
                await _transaction.DeleteTransaction(id);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest($"Failed to delete the transaction {ex}");
            }
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.transactionId == id);
        }
    }
}
