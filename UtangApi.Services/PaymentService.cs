using System.Collections.Generic;
using System.Threading.Tasks;
using UtangApi.Models;
using UtangApi.Repositories;

namespace UtangApi.Services
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
