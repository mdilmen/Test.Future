using Test.Future.Data.Entities;

namespace Test.Future.Data
{
    public interface IRepository
    {
        Task<bool> AddEntityAsync(object model);
        Task<bool> SaveAllAsync();
        Task<List<HS_Expense>> GetExpenses();
        Task<HS_Expense?> GetExpense(int id);
        Task<HS_CostOfFuture?> GetFuture(int id);
    }
}
