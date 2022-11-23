using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Enums;
using ClearBank.DeveloperTest.Services.Models;

namespace ClearBank.DeveloperTest.Services.Factories.PaymentFactories
{
    public class FasterPaymentsPaymentScheme : IPaymentScheme
    {
        public PaymentScheme PaymentScheme { get; set; } = PaymentScheme.FasterPayments;

        public PaymentResult ValidateAccount(Account account, PaymentResult paymentResult, PaymentRequest? paymentRequest)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                paymentResult.Success = false;
            }
            else if (account.Balance < paymentRequest?.Amount)
            {
                paymentResult.Success = false;
            }
            else
            {
                paymentResult.Success = true;
            }
            return paymentResult;
        }
    }
}
