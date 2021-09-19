using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Repositories
{
    public interface IPaymentRepository
    {
        public Task<IEnumerable<Payment>> GetPayments();
        public Task<bool> PutPayment(Payment payment);
    }
}
