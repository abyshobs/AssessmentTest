using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services.Factories.PaymentFactories;
using ClearBank.DeveloperTest.Services.Models;
using Microsoft.Extensions.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IEnumerable<IAccountDataStore> _accountDataStores;
        private readonly IEnumerable<IPaymentScheme> _paymentSchemes;
        private readonly IConfiguration _configuration;

        public PaymentService(IEnumerable<IAccountDataStore> accountDataStores, IEnumerable<IPaymentScheme> paymentSchemes,
                                                                                              IConfiguration configuration)
        {
            _accountDataStores = accountDataStores;
            _paymentSchemes = paymentSchemes;
            _configuration = configuration;
        }
        public PaymentResult MakePayment(PaymentRequest paymentRequest)
        {
            var dataStoreType = _configuration["DataStoreType"];
            if (string.IsNullOrEmpty(dataStoreType))
            {
                throw new ArgumentNullException(nameof(dataStoreType));
            }
            var account = GetAccount(paymentRequest, dataStoreType);
            var result = GetPaymentResult(account, paymentRequest);

            UpdateAccount(account, result, paymentRequest, dataStoreType);

            return result;
        }

        private Account GetAccount(PaymentRequest paymentRequest, string dataStoreType)
        {
            IAccountDataStore? accountDataStore;

            if (dataStoreType == "Backup")
            {
                accountDataStore = GetAccountDataStore(AccountDataStoreType.BackupAccount);
                return accountDataStore.GetAccount(paymentRequest.DebtorAccountNumber);
            }

            accountDataStore = GetAccountDataStore(AccountDataStoreType.Account);
            return accountDataStore.GetAccount(paymentRequest.DebtorAccountNumber);
        }

        private PaymentResult GetPaymentResult(Account account, PaymentRequest paymentRequest)
        {
            var paymentResult = new PaymentResult();
            if (account == null)
            {
                paymentResult.Success = false;
                return paymentResult;
            }

            var paymentScheme = _paymentSchemes.SingleOrDefault(x => x.PaymentScheme == paymentRequest.PaymentScheme);
            if (paymentScheme == null)
            {
                throw new Exception($"{paymentRequest.PaymentScheme} PaymentScheme has not been implemented.");
            }

            return paymentScheme.ValidateAccount(account, paymentResult, paymentRequest);
        }

        private void UpdateAccount(Account account, PaymentResult result, PaymentRequest request, string dataStoreType)
        {
            if (result.Success)
            {
                account.Balance -= request.Amount;

                if (dataStoreType == "Backup")
                {
                    var accountDataStore = GetAccountDataStore(AccountDataStoreType.BackupAccount);
                    accountDataStore.UpdateAccount(account);
                }
                else
                {
                    var accountDataStore = GetAccountDataStore(AccountDataStoreType.Account);
                    accountDataStore.UpdateAccount(account);
                }
            }
        }

        private IAccountDataStore GetAccountDataStore(AccountDataStoreType accountDataStoreType)
        {
            var accountDataStore = _accountDataStores.SingleOrDefault(x => x.AccountDataStoreType == accountDataStoreType);
            if (accountDataStore == null)
            {
                throw new Exception($"{accountDataStoreType}DataStore has not been implemented.");
            }

            return accountDataStore;
        }
    }
}
