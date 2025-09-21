using Microsoft.EntityFrameworkCore;
using AuthFinance.Models;

namespace AuthFinance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<CompletedGoal> CompletedGoals { get; set; }
    }
}
