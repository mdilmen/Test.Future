using Test.Future.Data.Entities;
using Test.Future.Data.Enums;
using Test.Future.Services.FutureCostService.Models;

namespace Test.Future.Services.FutureCostService
{
    public class FutureCostService : IFutureCostService
    {
        public async Task<FutureCostModel> GetCost(HS_CostOfFuture future)
        {
            var costs = await CalculateCosts(future);
            return new FutureCostModel { Costs = costs };
        }

        private static async Task<List<CostModel>> CalculateCosts(HS_CostOfFuture future)
        {
            var costs = new List<CostModel>();
            DateTime? start = future.PolicyBeginDate;
            int installmentCount = future.InstallmentCount;

            if (start.HasValue && installmentCount > 0)
            {
                for (int i = 0; i < installmentCount; i++)
                {
                    DateTime costDate = start.Value.AddMonths(i);
                    CostModel cost = new CostModel
                    {
                        Id = i + 1,
                        PayDay = new DateTime(costDate.Year, costDate.Month, 1),
                        DayCount = DateTime.DaysInMonth(costDate.Year, costDate.Month)
                    };
                    costs.Add(cost);
                }

                var totalDayCount = costs.Sum(cost => cost.DayCount);
                var methodType = future.PaymentMethodType;
                var amount = future.Amount;

                foreach (var cost in costs)
                {
                    cost.Amount = await CalculateAmountForCost(cost, totalDayCount, methodType, amount, installmentCount);
                }
            }

            return costs;
        }

        private static Task<decimal> CalculateAmountForCost(CostModel model, int totalDays, PaymentMethodType methodType, decimal amount, int installmentCount)
        {
            decimal result = 0;

            switch (methodType)
            {
                case PaymentMethodType.Günlük:
                    result = ((decimal)model.DayCount / totalDays) * amount;
                    break;
                case PaymentMethodType.Aylık:
                    result = amount / installmentCount;
                    break;
            }

            return Task.FromResult(result);
        }
    }

}
