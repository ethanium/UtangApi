using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pera.UtangApi.Repositories
{
    public interface IBalanceRepository
    {
        public Task<IEnumerable<Balance>> GetBalances(string accountNumber);
    }
}