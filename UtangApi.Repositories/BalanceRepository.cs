using Microsoft.EntityFrameworkCore;
using Pera.UtangApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pera.UtangApi.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly UtangContext _context;

        public BalanceRepository(UtangContext context)
        {
            _context = context;
        }

        public async Task<Balance> GetBalance(string accountNumber)
        {
            Balance balance = new();
            return balance;
        }
    }
}
