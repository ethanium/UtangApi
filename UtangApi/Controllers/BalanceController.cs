using Microsoft.AspNetCore.Mvc;
using Pera.UtangApi.Models;
using Pera.UtangApi.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pera.UtangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _service;

        public BalanceController(IBalanceService service)
        {
            _service = service;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult> GetBalances(string accountNumber)
        {
            IEnumerable<Balance> balances = await _service.GetBalances(accountNumber);
            if (balances is null)
                return NotFound();

            return Ok(balances);
        }
    }
}
