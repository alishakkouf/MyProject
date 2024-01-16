using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProject.Data.Models;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using MyProject.Shared;
using Microsoft.AspNetCore.Builder;

namespace MyProject.Data
{
    public static class DependencyInjection
    {
        const string ConnectionStringName = "DefaultConnection";
        const bool SeedData = true;

        public static IServiceCollection ConfigureDataModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyProjectDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(ConnectionStringName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddProviders();

            return services;
        }

        public static async Task MigrateAndSeedDatabaseAsync(this IApplicationBuilder builder)
        {
            var scope = builder.ApplicationServices.CreateAsyncScope();

            try
            {
                var context = scope.ServiceProvider.GetRequiredService<MyProjectDbContext>();

                if (context.Database.IsSqlServer())
                {
                    await context.Database.MigrateAsync();
                }

                if (SeedData)
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserAccount>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<UserRole>>();
                    await MyProjectDbContextSeed.SeedSuperAdminAsync(context, roleManager, userManager);
                    await MyProjectDbContextSeed.SeedDefaultBusinessAsync(context);

                    foreach (var tenant in await context.Businesses.Where(x => x.IsActive && x.IsDeleted != true).ToListAsync())
                    {
                        await MyProjectDbContextSeed.SeedStaticRolesAsync(roleManager, tenant);
                        await MyProjectDbContextSeed.SeedDefaultUserAsync(userManager, roleManager, tenant, Constants.DefaultPassword);
                        await MyProjectDbContextSeed.SeedDefaultSettingsAsync(context, tenant);
                    }

                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<MyProjectDbContext>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                throw;
            }
        }

        private static void AddProviders(this IServiceCollection services)
        {
            //services.AddTransient<ISettingProvider, SettingProvider>();

            //services.AddTransient<IFireStoreProvider<IFirebaseEntity>, FireStoreProvider<IFirebaseEntity>>();
            //services.AddSingleton<FirestoreService>();


        }
    }
}
