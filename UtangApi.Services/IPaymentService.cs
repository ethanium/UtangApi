using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> GetPayments(string accountNumber);
    }
}