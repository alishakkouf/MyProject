using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Domain.Business;
using MyProject.Manager.Business;

namespace MyProject.Manager
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureManagerModule(this IServiceCollection services,
                                                                     IConfiguration configuration)
        {
            services.AddTransient<IBusinessManager, BusinessManager>();

            return services;
        }
    }
}
