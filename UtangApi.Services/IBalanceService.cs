using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Services
{
    public interface IBalanceService
    {
        public Task<IEnumerable<Balance>> GetBalances(string accountNumber);
    }
}