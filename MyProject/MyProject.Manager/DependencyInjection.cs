using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Domain.Business;
using MyProject.Domain.Categories;
using MyProject.Domain.Coupons;
using MyProject.Domain.Products;
using MyProject.Manager.Business;
using MyProject.Manager.Categories;
using MyProject.Manager.Coupons;
using MyProject.Manager.Products;

namespace MyProject.Manager
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureManagerModule(this IServiceCollection services,
                                                                     IConfiguration configuration)
        {
            services.AddTransient<IBusinessManager, BusinessManager>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<ICategoriesManager, CategoriesManager>();
            services.AddTransient<ICouponManager, CouponManager>();

            return services;
        }
    }
}
