using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Data
{
    public class BackupAccountDataStore : IAccountDataStore
    {
        public AccountDataStoreType AccountDataStoreType { get; set; } = AccountDataStoreType.BackupAccount;

        public Account GetAccount(string accountNumber)
        {
            // Access backup data base to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in backup database, code removed for brevity
        }
    }
}
