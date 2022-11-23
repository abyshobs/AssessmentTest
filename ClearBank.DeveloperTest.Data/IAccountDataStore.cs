using ClearBank.DeveloperTest.Common.Enums;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Data
{
    public interface IAccountDataStore
    {
        public AccountDataStoreType AccountDataStoreType { get; set; }
        Account GetAccount(string accountNumber);
        void UpdateAccount(Account account);
    }
}
