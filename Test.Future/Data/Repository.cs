using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Test.Future.Data.Entities;

namespace Test.Future.Data
{
    public class Repository : IRepository
    {
        private readonly FutureContext _context;

        public Repository(FutureContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEntityAsync(object model)
        {
            try
            {
                await _context.AddAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                // Log here..
                return false;
            }
        }

        public async Task<List<HS_Expense>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<HS_Expense?> GetExpense(int id)
        {
            return await _context.Expenses.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<HS_CostOfFuture?> GetFuture(int id)
        {
            return await _context.Futures.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;
    }
}
