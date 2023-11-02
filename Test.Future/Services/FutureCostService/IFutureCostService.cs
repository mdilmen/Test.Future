using Test.Future.Data.Entities;
using Test.Future.Services.FutureCostService.Models;

namespace Test.Future.Services.FutureCostService
{
    public interface IFutureCostService
    {
        Task<FutureCostModel> GetCost(HS_CostOfFuture future);
    }
}
