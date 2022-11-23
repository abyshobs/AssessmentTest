using ClearBank.DeveloperTest.Services.Enums;

namespace ClearBank.DeveloperTest.Services.Models
{
    public class PaymentRequest
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentScheme PaymentScheme { get; set; }
    }
}
