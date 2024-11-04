using ERP_InsightWise.API.Configuration;


namespace ERP_InsightWise.API.Extensions
{
    public static class ServiceColletionsExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, APPConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddOracle(configuration.OracleFIAP.Connection, name: configuration.OracleFIAP.Name)
                .AddUrlGroup(new Uri("https://viacep.com.br/"), name: "VIA CEP");

            return services;
        }
    }
}
