using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Enums;
using ClearBank.DeveloperTest.Services.Models;

namespace ClearBank.DeveloperTest.Services.Factories.PaymentFactories
{
    public class BacsPaymentScheme : IPaymentScheme
    {
        public PaymentScheme PaymentScheme { get; set; } = PaymentScheme.Bacs;

        public PaymentResult ValidateAccount(Account account, PaymentResult paymentResult, PaymentRequest? paymentRequest = null)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
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
