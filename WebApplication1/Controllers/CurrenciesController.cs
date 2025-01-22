using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrency _currencyService;

        public CurrenciesController(ICurrency currencyService)
        {
            _currencyService = currencyService;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            return Ok(await _currencyService.GetCurrenciesAsync());
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(string id)
        {
            var currency = await _currencyService.GetCurrencyAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(string id, Currency currency)
        {
            if (!await _currencyService.PutCurrencyAsync(id, currency))
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Currencies
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            var createdCurrency = await _currencyService.PostCurrencyAsync(currency);
            return CreatedAtAction("GetCurrency", new { id = createdCurrency.currencyCode }, createdCurrency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(string id)
        {
            if (!await _currencyService.DeleteCurrencyAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
