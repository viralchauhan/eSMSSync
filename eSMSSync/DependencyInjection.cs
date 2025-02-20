using BuildingBlocks.Common.DBHelper;
using Common.User.Access;
using eSMSSync.Infrastructure;
using eSMSSync.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace eSMSSync
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("EwealthConnectionString");
            // Register data database configuration layer with the specified connection string
            services.AddUserContextServices();
            services.AddDataDbConfigurationLayer(connectionString!,isCheckHealth: false);
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IBudgetTranscation, BudgetTranscation>();
            return services;
        }
    }
}
