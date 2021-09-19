﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _service.GetPayments();
        }

        //private readonly UtangContext _context;

        //public PaymentsController(UtangContext context)
        //{
        //    _context = context;
        //} 

        //// GET: api/Payments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        //{
        //    return await _context.Payments.ToListAsync();
        //}

        //// GET: api/Payments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Payment>> GetPayment(long id)
        //{
        //    var payment = await _context.Payments.FindAsync(id);

        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    return payment;
        //}

        //// PUT: api/Payments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPayment(long id, Payment payment)
        //{
        //    if (id != payment.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(payment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaymentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Payments
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        //{
        //    _context.Payments.Add(payment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        //}

        //// DELETE: api/Payments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePayment(long id)
        //{
        //    var payment = await _context.Payments.FindAsync(id);
        //    if (payment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Payments.Remove(payment);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PaymentExists(long id)
        //{
        //    return _context.Payments.Any(e => e.Id == id);
        //}
    }
}
