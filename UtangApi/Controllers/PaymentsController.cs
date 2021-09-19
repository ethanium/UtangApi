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
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetPayments(string accountNumber)
        {
            IEnumerable<Payment> payments = await _service.GetPayments(accountNumber);
            if (payments is null)
                return NotFound();

            return Ok(payments);
        }
    }
}
