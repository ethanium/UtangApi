using Microsoft.EntityFrameworkCore;
using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pera.UtangApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly UtangContext _context;

        public PaymentRepository(UtangContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPayments(string accountNumber)
        {
            List<Payment> results = null;
            IQueryable<Payment> payments = _context.Payments.Where(x => x.AccountNumber == accountNumber);
            if (payments.Any())
            {
                results = await payments.OrderByDescending(x => x.Date).ToListAsync();
            }
            return results;
        }
    }
}
