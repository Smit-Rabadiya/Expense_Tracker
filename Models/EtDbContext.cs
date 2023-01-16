using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class EtDbContext :DbContext
    {
        public EtDbContext(DbContextOptions<EtDbContext> options) :base(options) 
        {}

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ExpenseLimit> Expense_Limit { get; set; }
    }
}
