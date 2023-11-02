using Microsoft.EntityFrameworkCore;
using Test.Future.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test.Future.Data
{
    public class FutureContext : DbContext
    {        
        public FutureContext(DbContextOptions<FutureContext> options)
    : base(options)
        {
        }
        public virtual DbSet<HS_Expense> Expenses { get; set; }
        public virtual DbSet<HS_CostOfFuture> Futures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HS_Expense>().
            HasData(
                    new HS_Expense { Id = 1, Name = "Sigorta",Order  = 1 },
                    new HS_Expense { Id = 2, Name = "Kasko", Order = 2 },
                    new HS_Expense { Id = 3, Name = "Kira", Order = 3 }
                    );
        }
    }
}
