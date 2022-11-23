using ClearBank.DeveloperTest.Services.Models;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentService
    {
        PaymentResult MakePayment(PaymentRequest request);
    }
}
