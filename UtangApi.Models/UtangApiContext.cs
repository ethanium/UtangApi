using Microsoft.EntityFrameworkCore;

namespace Pera.UtangApi.Models
{
    public class UtangContext : DbContext
    {
        public UtangContext(DbContextOptions<UtangContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
