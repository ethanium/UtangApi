using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pera.UtangApi.Models;
using Pera.UtangApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IBalanceService _service;

        public BalancesController(IBalanceService service)
        {
            _service = service;
        }

        // GET: api/Balances
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
