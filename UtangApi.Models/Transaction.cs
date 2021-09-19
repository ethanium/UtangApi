using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pera.UtangApi.Models
{
    public class Transaction
    {
        [Key]
        public long TransactionId { get; set; }
        [MaxLength(12)]
        public string AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
