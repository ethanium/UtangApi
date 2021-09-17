using System.Collections.Generic;
using System.Threading.Tasks;
using UtangApi.Models;

namespace UtangApi.Repositories
{
    public interface IPaymentRepository
    {
        public Task<IEnumerable<Payment>> GetPayments();
        public Task<bool> PutPayment(Payment payment);
    }
}
