using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtangApi.Models;

namespace UtangApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UtangContext _context;

        public PaymentRepository(UtangContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _context.Payments.OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<bool> PutPayment(Payment payment)
        {
            try
            {
                _context.Entry(payment).State = EntityState.Modified;
                int entries = await _context.SaveChangesAsync();
                return entries > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
