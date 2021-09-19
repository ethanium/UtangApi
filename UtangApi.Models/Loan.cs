namespace Pera.UtangApi.Models
{
    public class Loan : Transaction
    {
        public long LoanId { get; set; }
        public sbyte Year { get; set; }
        public decimal InterestRate { get; set; }
        public string ClosedReason { get; set; }
    }
}
