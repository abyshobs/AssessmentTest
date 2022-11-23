using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Enums;
using ClearBank.DeveloperTest.Services.Models;

namespace ClearBank.DeveloperTest.Services.Factories.PaymentFactories
{
    public interface IPaymentScheme
    {
        PaymentScheme PaymentScheme { get; set; }
        PaymentResult ValidateAccount(Account account, PaymentResult paymentResult, PaymentRequest? paymentRequest = null);
    }
}
