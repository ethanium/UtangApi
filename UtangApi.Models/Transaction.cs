using System;
using System.ComponentModel.DataAnnotations;

namespace UtangApi.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        [MaxLength(12)]
        public string AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
