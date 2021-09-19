using Pera.UtangApi.Models;
using Pera.UtangApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Services
{
    public class BalanceService : IBalanceService
    {
        private IBalanceRepository _repository;

        public BalanceService(IBalanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Balance>> GetBalances(string accountNumber)
        {
            return await _repository.GetBalances(accountNumber);
        }
    }
}
