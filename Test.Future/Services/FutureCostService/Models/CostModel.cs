namespace Test.Future.Services.FutureCostService.Models
{
    public class CostModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Order { get; set; }
        public DateTime? PayDay { get; set; }
        public int DayCount { get; set; }
    }
}
