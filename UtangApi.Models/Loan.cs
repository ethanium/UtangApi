namespace Pera.UtangApi.Models
{
    public class Loan : Transaction
    {
        public sbyte Year { get; set; }
        public decimal InterestRate { get; set; }
        public string ClosedReason { get; set; }
    }
}
