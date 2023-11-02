using Test.Future.Data;
using Test.Future.Services.FutureCostService;

namespace Test.Future.Configuration
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository, Repository>();
            serviceCollection.AddScoped<IFutureCostService, FutureCostService>();
        }
    }
}
