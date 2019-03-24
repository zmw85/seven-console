using Microsoft.Extensions.DependencyInjection;
using SevenConsole.Reports.DataAccess;
using SevenConsole.Reports.Producers;

namespace SevenConsole.Reports.Extensions
{
    public static class ReportsServiceExtension
    {
        public static IServiceCollection AddReports(this IServiceCollection services)
        {
            services.AddTransient(typeof(IDataAccess), typeof(LocalDataAccess));
            services.AddTransient(typeof(IProducer<>), typeof(JsonProducer<>));
            services.AddTransient(typeof(IDataAccessFactory), typeof(DataAccessFactory));
            services.AddSingleton(typeof(IProducerFactory<>), typeof(ProducerFactory<>));

            return services;
        }
    }
}
