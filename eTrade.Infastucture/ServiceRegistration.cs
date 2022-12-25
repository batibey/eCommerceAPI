using eTrade.Application.Abstraction.Services;
using eTrade.Application.Abstraction.Services.Configurations;
using eTrade.Application.Abstraction.Storage;
using eTrade.Application.Abstraction.Token;
using eTrade.Infastucture.Enums;
using eTrade.Infastucture.Services;
using eTrade.Infastucture.Services.Configurations;
using eTrade.Infastucture.Services.Storage;
using eTrade.Infastucture.Services.Storage.Local;
using eTrade.Infastucture.Services.Storage.Local.Azure;
using eTrade.Infastucture.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace eTrade.Infastucture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
            serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
