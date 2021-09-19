using Pera.UtangApi.Models;
using Pera.UtangApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _repository.GetPayments();
        }
    }
}
