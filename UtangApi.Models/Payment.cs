namespace Pera.UtangApi.Models
{
    public class Payment : Transaction
    {
        public long LoanId { get; set; }
    }
}
