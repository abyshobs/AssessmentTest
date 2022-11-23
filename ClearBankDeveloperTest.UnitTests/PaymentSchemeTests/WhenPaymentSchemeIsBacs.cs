using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Factories.PaymentFactories;
using ClearBank.DeveloperTest.Services.Models;
using Shouldly;

namespace ClearBankDeveloperTest.UnitTests.PaymentSchemeTests
{
    public class WhenPaymentSchemeIsBacs
    {
        private readonly BacsPaymentScheme _sut;

        public WhenPaymentSchemeIsBacs()
        {
            _sut = new BacsPaymentScheme();
        }

        [Fact]
        public void AndAccountDoesNotAllowBacsPaymentScheme_ThenPaymentResultIsNotSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
            };

            var paymentResult = new PaymentResult();

            // Act
            var result = _sut.ValidateAccount(account, paymentResult);

            //Assert
            result.Success.ShouldBe(false);
        }

        [Fact]
        public void AndAccountAllowsBacsPaymentScheme_ThenPaymentResultIsSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            var paymentResult = new PaymentResult();

            // Act
            var result = _sut.ValidateAccount(account, paymentResult);

            //Assert
            result.Success.ShouldBe(true);
        }
    }
}
