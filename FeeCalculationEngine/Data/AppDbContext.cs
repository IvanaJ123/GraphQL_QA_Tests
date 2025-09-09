using Microsoft.EntityFrameworkCore;
using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
