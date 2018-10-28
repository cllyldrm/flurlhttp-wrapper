namespace FlurlHttpWrapper.Extensions
{
    using Flurl.Http.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddFlurlHttpWrapper(this IServiceCollection services)
        {
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
        }
    }
}