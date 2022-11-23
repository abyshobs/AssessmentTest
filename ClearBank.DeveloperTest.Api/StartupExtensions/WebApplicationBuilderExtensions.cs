using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Services.Factories.PaymentFactories;

namespace ClearBank.DeveloperTest.Api.StartupExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigurePaymentSchemeFactories(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPaymentScheme, BacsPaymentScheme>();
            builder.Services.AddTransient<IPaymentScheme, ChapsPaymentScheme>();
            builder.Services.AddTransient<IPaymentScheme, FasterPaymentsPaymentScheme>();
        }

        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPaymentService, PaymentService>();
        }

        public static void ConfigureDataStores(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAccountDataStore, AccountDataStore>();
            builder.Services.AddTransient<IAccountDataStore, BackupAccountDataStore>();
        }
    }
}
