using Pera.UtangApi.Models;
using System.Threading.Tasks;

namespace Pera.UtangApi.Repositories
{
    public interface IBalanceRepository
    {
        public Task<Balance> GetBalance(string accountNumber);
    }
}