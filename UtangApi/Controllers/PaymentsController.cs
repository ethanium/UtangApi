using Microsoft.AspNetCore.Mvc;
using Pera.UtangApi.Models;
using Pera.UtangApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<IEnumerable<Payment>> GetPayments(string accountNumber)
        {
            return await _service.GetPayments(accountNumber);
        }
    }
}
