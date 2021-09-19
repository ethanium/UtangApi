using Microsoft.EntityFrameworkCore;
using Pera.UtangApi.Formulas;
using Pera.UtangApi.Models;
using System;
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

        public async Task<IEnumerable<Balance>> GetBalances(string accountNumber)
        {
            List<Balance> balances = null;

            List<Loan> loans = await _context.Loans.Where(x => x.AccountNumber == accountNumber).ToListAsync();
            if (loans.Any())
            {
                List<Payment> payments = await _context.Payments.Where(
                    p => p.AccountNumber == accountNumber
                    && loans.Select(l => l.LoanId).Contains(p.LoanId))
                    .ToListAsync();

                balances = loans.Select(l =>
                {
                    decimal totalAmount = LoanFormulas.CalcTotalFinanceCharge(l.Amount, l.InterestRate, l.Year);

                    decimal paidAmount = 0;
                    IEnumerable<Payment> loanPayments = payments.Where(p => p.LoanId == l.LoanId && p.AccountNumber == l.AccountNumber);
                    if (loanPayments.Any())
                    {
                        paidAmount = loanPayments.Sum(lp => lp.Amount);
                    }

                    return new Balance()
                    {
                        LoanId = l.LoanId,
                        Year = l.Year,
                        InterestRate = l.InterestRate,
                        ClosedReason = l.ClosedReason,
                        AccountNumber = accountNumber,
                        Date = DateTime.Now,
                        Amount = totalAmount - paidAmount,
                        Status = l.Status
                    };
                }).ToList();

                _context.AddRange(balances);
            }

            if (balances is null || !balances.Any())
            {
                Balance balance = new();
                balance.AccountNumber = accountNumber;
                balance.Date = DateTime.Now;
                _context.Add(balance);
            } 

            return balances;
        }
    }
}
