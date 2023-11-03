using System.ComponentModel.DataAnnotations;
using Test.Future.Data.Enums;

namespace Test.Future.Models
{
    public class FutureViewModel
    {
        public int ExpenseId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [MinLength(3, ErrorMessage = "en az 3 hane olmalı")]
        [MaxLength(11, ErrorMessage = "En fazla 11 hane olmalı")]
        public string? CardName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [MinLength(3, ErrorMessage = "en az 3 hane olmalı")]
        [MaxLength(11, ErrorMessage = "En fazla 11 hane olmalı")]
        public string? CardLastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [MinLength(5, ErrorMessage = "en az 5 hane olmalı")]
        [MaxLength(5, ErrorMessage = "En fazla 5 hane olmalı")]
        public string? PolicyNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [DataType(DataType.Date)]
        public DateTime? PolicyStartDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [DataType(DataType.Date)]
        public DateTime? PolicyEndDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [RegularExpression(@"^(?!0$)([1-9]|1[0-9]|2[0-4])$", ErrorMessage = "The value must be greater than 0 and less than or equal to 24.")]
        public int InstallmentCount { get; set; }        
        [MaxLength(100, ErrorMessage = "En fazla 100 hane olmalı")]
        public string? Comment { get; set; }
        
        public PaymentMethodType PaymentMethodType { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan gereklidir!")]
        [RegularExpression(@"^(?=.*[1-9])\d{1,7}(?:\.\d{1,2})?$", ErrorMessage = "Invalid decimal number. It must be greater than 0 and less than 10,000,000 with up to 2 decimal places.")]
        public decimal Amount { get; set; }
    }
}
