using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Factories.PaymentFactories;
using ClearBank.DeveloperTest.Services.Models;
using Shouldly;

namespace ClearBankDeveloperTest.UnitTests.PaymentSchemeTests
{
    public class WhenPaymentSchemeIsChaps
    {
        private readonly ChapsPaymentScheme _sut;

        public WhenPaymentSchemeIsChaps()
        {
            _sut = new ChapsPaymentScheme();
        }

        [Fact]
        public void AndAccountDoesNotAllowChapsPaymentScheme_ThenPaymentResultIsNotSuccessful()
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
        public void AndAccountStatusIsNotLive_ThenPaymentResultIsNotSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Disabled
            };

            var paymentResult = new PaymentResult();

            // Act
            var result = _sut.ValidateAccount(account, paymentResult);

            //Assert
            result.Success.ShouldBe(false);
        }


        [Fact]
        public void AndAccountAllowsChapsPaymentScheme_ThenPaymentResultIsSuccessful()
        {
            // Arrange
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps
            };

            var paymentResult = new PaymentResult();

            // Act
            var result = _sut.ValidateAccount(account, paymentResult);

            //Assert
            result.Success.ShouldBe(true);
        }
    }
}
