using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Enums;
using ClearBank.DeveloperTest.Services.Models;

namespace ClearBank.DeveloperTest.Services.Factories.PaymentFactories
{
    public class ChapsPaymentScheme : IPaymentScheme
    {
        public PaymentScheme PaymentScheme { get; set; } = PaymentScheme.Chaps;

        public PaymentResult ValidateAccount(Account account, PaymentResult paymentResult, PaymentRequest? paymentRequest = null)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                paymentResult.Success = false;
            }
            else if (account.Status != AccountStatus.Live)
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
