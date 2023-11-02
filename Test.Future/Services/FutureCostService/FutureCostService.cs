using Test.Future.Data.Entities;
using Test.Future.Services.FutureCostService.Models;

namespace Test.Future.Services.FutureCostService
{
    public class FutureCostService : IFutureCostService
    {
        public async Task<FutureCostModel> GetCost(HS_CostOfFuture future)
        {
            // Mocking here ..
            FutureCostModel model = new FutureCostModel();

            CostModel cost1 = new CostModel() { Id = 1, Amount= 100, Order = 1 };
            CostModel cost2 = new CostModel() { Id = 2, Amount= 200, Order = 2 };
            CostModel cost3 = new CostModel() { Id = 3, Amount= 300, Order = 3 };

            model.Costs.Add(cost1);
            model.Costs.Add(cost2); 
            model.Costs.Add(cost3);

            return model;            
        }
    }
}
