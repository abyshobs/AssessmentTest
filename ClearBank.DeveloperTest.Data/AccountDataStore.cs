using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        public AccountDataStoreType AccountDataStoreType { get; set; } = AccountDataStoreType.Account;

        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
