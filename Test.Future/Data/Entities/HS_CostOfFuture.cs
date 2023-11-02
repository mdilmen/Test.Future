using Test.Future.Data.Enums;

namespace Test.Future.Data.Entities
{
    public class HS_CostOfFuture
    {
        public int Id { get; set; } // DocNumber
        public HS_Expense? HS_Expense { get; set; }
        public string? CardName { get; set; }
        public string? CardLastName { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? PolicyBeginDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }

        public int InstallmentCount { get; set; }
        public string? Comment { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public decimal Amount { get; set; }
    }
}
