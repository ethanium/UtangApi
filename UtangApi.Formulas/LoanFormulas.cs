namespace Pera.UtangApi.Formulas
{
    public static class LoanFormulas
    {
        /// <summary>
        /// Simple interest loan formula
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="interestRate"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static decimal CalcTotalFinanceCharge(decimal principal, decimal interestRate, sbyte year)
        {
            return principal + (principal * interestRate * year);
        }
    }
}
