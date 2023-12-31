﻿using Test.Future.Data.Enums;
using Test.Future.Services.FutureCostService.Models;

namespace Test.Future.Models
{
    public class FutureDetailViewModel
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
        public FutureCostModel? FutureCostModel { get; set; }
    }
}
