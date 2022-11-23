using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Factories.PaymentFactories;
using ClearBank.DeveloperTest.Services.Models;
using Shouldly;

namespace ClearBankDeveloperTest.UnitTests.PaymentSchemeTests
{
    public class WhenPaymentSchemeIsFasterPayments
    {
        private readonly FasterPaymentsPaymentScheme _sut;
        public WhenPaymentSchemeIsFasterPayments()
        {
            _sut = new FasterPaymentsPaymentScheme();
        }

        [Fact]
        public void AndAccountDoesNotAllowFasterPaymentScheme_ThenPaymentResultIsNotSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = 450
            };

            var paymentResult = new PaymentResult();
            var paymentRequest = new PaymentRequest { Amount = 100 };

            // Act
            var result = _sut.ValidateAccount(account, paymentResult, paymentRequest);

            // Assert
            result.Success.ShouldBe(false);
        }

        [Fact]
        public void AndAccountBalanceIsLowerThanPaymentRequest_ThenPaymentResultIsNotSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 45
            };

            var paymentResult = new PaymentResult();
            var paymentRequest = new PaymentRequest { Amount = 100 };

            // Act
            var result = _sut.ValidateAccount(account, paymentResult, paymentRequest);

            // Assert
            result.Success.ShouldBe(false);
        }


        [Fact]
        public void AndAccountAllowsFasterPaymentScheme_ThenPaymentResultIsSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 450
            };

            var paymentResult = new PaymentResult();
            var paymentRequest = new PaymentRequest { Amount = 100 };

            // Act
            var result = _sut.ValidateAccount(account, paymentResult, paymentRequest);

            // Assert
            result.Success.ShouldBe(true);
        }
    }
}
