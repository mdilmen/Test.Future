using Test.Future.Data.Enums;

namespace Test.Future.Models
{
    public class FutureViewModel
    {
        public int ExpenseId { get; set; }
        public string? CardName { get; set; }
        public string? CardLastName { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public int InstallmentCount { get; set; }
        public string? Comment { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }        
        public decimal Amount { get; set; }
    }
}
