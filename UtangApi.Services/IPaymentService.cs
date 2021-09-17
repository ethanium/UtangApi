using System.Collections.Generic;
using System.Threading.Tasks;
using UtangApi.Models;

namespace UtangApi.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<Payment>> GetPayments();
    }
}