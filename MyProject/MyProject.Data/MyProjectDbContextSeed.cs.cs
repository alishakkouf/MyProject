using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyProject.Data.Models;
using MyProject.Domain.Authorization;
using MyProject.Domain.Business;
using MyProject.Domain.Settings;
using MyProject.Shared;

namespace MyProject.Data
{
    internal static class MyProjectDbContextSeed
    {
        /// <summary>
        /// Seed default and first Business with id = 1
        /// </summary>
        public static async Task SeedDefaultBusinessAsync(MyProjectDbContext context)
        {
            if (!context.Businesses.Any(x => x.Id == Constants.DefaultBusinessId))
            {
                await context.Database.OpenConnectionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Businesses ON");

                    var Business = new Business
                    {
                        Id = Constants.DefaultBusinessId,
                        Name = "Shakkouf Store",
                        AdminEmail = Constants.DefaultBusinessAdmin,
                        DomainName = Constants.DefaultBusinessDomain,
                        IsActive = true,
                        IsDeleted = false,
                        Country = "Syria",
                        City = "Safita",
                        EncryptedId = string.Empty,
                        Token = string.Empty,
                        Category = Shared.Enums.Category.None,
                        Description = string.Empty,
                        Logo = string.Empty,
                        MobilePhones = string.Empty
                    };

                    await context.Businesses.AddAsync(Business);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Businesses OFF");
                }
                finally
                {
                    await context.Database.CloseConnectionAsync();
                }
            }
        }

        /// <summary>
        /// Seed super admin user.
        /// </summary>
        internal static async Task SeedSuperAdminAsync(MyProjectDbContext context, RoleManager<UserRole> roleManager, UserManager<UserAccount> userManager)
        {
            var role = await context.Roles.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Name == Constants.SuperAdminRoleName);
            if (role == null)
            {
                role = new UserRole(Constants.SuperAdminRoleName) { IsActive = true, BusinessId = null };
                await roleManager.CreateAsync(role);
            }

            var user = await context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.UserName.StartsWith(Constants.SuperAdminUserName));
            if (user == null)
            {
                user = new UserAccount
                {
                    UserName = Constants.SuperAdminEmail,
                    Email = Constants.SuperAdminEmail,
                    FirstName = "Super Admin",
                    LastName = "Super Admin",
                    PhoneNumber = "935479586",
                    IsActive = true,
                    BusinessId = null,
                    City = string.Empty,
                    Country = string.Empty,
                    Nationality = string.Empty,
                    Gender = Shared.Enums.Gender.Male,
                    ConfirmationCode = string.Empty,
                    ImageRelativePath = string.Empty,
                    PhoneCountryCode = "+963",
                    
                };

                await userManager.CreateAsync(user, Constants.DefaultPassword);
                await userManager.AddToRolesAsync(user, new[] { Constants.SuperAdminRoleName });
            }
        }

        /// <summary>
        /// Seed static roles and add permissions claims to them.
        /// </summary>
        internal static async Task SeedStaticRolesAsync(RoleManager<UserRole> roleManager, Business Business)
        {
            foreach (var rolePermission in StaticRolePermissions.Roles)
            {
                var role = await roleManager.Roles.IgnoreQueryFilters().FirstOrDefaultAsync(x =>
                    x.NormalizedName == rolePermission.Key.ToUpper() && x.BusinessId == Business.Id);

                if (role == null)
                {
                    role = new UserRole(rolePermission.Key) 
                    { 
                        IsActive = true,
                        BusinessId = Business.Id,
                        Description = string.Empty,
                    };

                    await roleManager.CreateAsync(role);

                    //Add static role permissions to db
                    foreach (var permission in rolePermission.Value)
                    {
                        await roleManager.AddClaimAsync(role,
                            new Claim(Constants.PermissionsClaimType, permission));
                    }

                    continue;
                }

                if (rolePermission.Key == StaticRoleNames.Administrator)
                {
                    var dbRoleClaims = await roleManager.GetClaimsAsync(role);

                    //Remove any claim in db and not in static role permissions.
                    foreach (var dbPermission in dbRoleClaims.Where(x => x.Type == Constants.PermissionsClaimType &&
                                                                         !rolePermission.Value.Contains(x.Value)))
                    {
                        await roleManager.RemoveClaimAsync(role, dbPermission);
                    }

                    //Add static role permissions to db if they don't already exist.
                    foreach (var permission in rolePermission.Value)
                    {
                        if (!dbRoleClaims.Any(x => x.Type == Constants.PermissionsClaimType && x.Value == permission))
                        {
                            await roleManager.AddClaimAsync(role,
                                new Claim(Constants.PermissionsClaimType, permission));
                        }
                    }
                }
            }
        }

        internal static async Task SeedDefaultUserAsync(UserManager<UserAccount> userManager,
            RoleManager<UserRole> roleManager, Business Business, string adminPassword)
        {
            var adminRole = await roleManager.Roles.IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Name == StaticRoleNames.Administrator && x.BusinessId == Business.Id);

            var adminUser = await userManager.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.UserName == Business.AdminEmail && x.BusinessId == Business.Id);

            if (adminUser == null && adminRole != null)
            {
                adminUser = new UserAccount
                {
                    UserName = Business.AdminEmail,
                    Email = Business.AdminEmail,
                    FirstName = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "0123456789",
                    IsActive = true,
                    BusinessId = Business.Id,
                    City = string.Empty,
                    Country = string.Empty,
                    Nationality = string.Empty,
                    Gender = Shared.Enums.Gender.Male,
                    ConfirmationCode = string.Empty,
                    ImageRelativePath = string.Empty,
                    PhoneCountryCode = string.Empty
                };
                adminUser.UserRoles.Add(adminRole);
                await userManager.CreateAsync(adminUser, adminPassword);
            }
        }

        internal static async Task SeedDefaultSettingsAsync(MyProjectDbContext context, Business Business)
        {
            var save = false;
            foreach (var setting in SettingDefaults.Defaults)
            {
                if (!context.Settings.IgnoreQueryFilters()
                    .Any(x => x.Name == setting.Key && x.UserId == null && x.BusinessId == Business.Id))
                {
                    await context.Settings.AddAsync(new Setting 
                    { 
                        Name = setting.Key,
                        Value = setting.Value,
                        UserId = null,
                        BusinessId = Business.Id,
                        Description = string.Empty
                    });
                    save = true;
                }
            }

            if (save)
                await context.SaveChangesAsync();
        }

        public static async Task SeedDefaultSettingsAsync(MyProjectDbContext context, Business Business, CreateBusinessCommand command, bool isUAEBusiness, bool isEgyptionBusiness)
        {
            var save = false;
            foreach (var setting in SettingDefaults.Defaults)
            {
                var key = setting.Key;
                var value = setting.Value;

                switch (key)
                {
                    case SettingNames.BusinessName:
                        value = command.Name;
                        break;
                    case SettingNames.BusinessDomainName:
                        value = command.DomainName;
                        break;
                    case SettingNames.BusinessEmail:
                        value = command.BusinessEmail;
                        break;
                    case SettingNames.Country:
                        value = command.BusinessCountry;
                        break;
                    case SettingNames.City:
                        value = command.BusinessCity;
                        break;
                    case SettingNames.AppCountryPhoneCode:
                        value = command.BusinessPhoneCode;
                        break;
                    case SettingNames.BusinessPhone:
                        value = command.BusinessPhone;
                        break;
                    case SettingNames.BusinessOwner:
                        value = command.BusinessOwner;
                        break;
                    case SettingNames.BusinessCurrency:
                        value = command.BusinessCurrency;
                        break;
                    case SettingNames.AppSmsFromPhone:
                        value = command.DomainName.Length > 11 ? command.DomainName.Substring(0, 11) : command.DomainName;
                        break;
                    case SettingNames.AppTimeZone:
                        value = GetDefaultTimeZone(command.BusinessCountry) ?? value;
                        break;
                    
                }
                if (!context.Settings.IgnoreQueryFilters()
                        .Any(x => x.Name == key && x.UserId == null && x.BusinessId == Business.Id))
                {
                    await context.Settings.AddAsync(new Setting { Name = key, Value = value, UserId = null, BusinessId = Business.Id });
                    save = true;
                }
            }

            if (save)
                await context.SaveChangesAsync();
        }

        private static string GetDefaultTimeZone(string country)
        {
            switch (country)
            {
                case Constants.GermanyCountryName:
                    return "Europe/Berlin";
                case Constants.UAECountryName:
                    return "Asia/Dubai";
                case Constants.EgyptCountryName:
                    return "Africa/Cairo";
                case Constants.SyriaCountryName:
                    return "Asia/Damascus";
                case Constants.PalestineCountryName:
                    return "Asia/Gaza";
                case Constants.JordanCountryName:
                    return "Asia/Amman";
                case Constants.YemenCountryName:
                    return "Asia/Aden";
                case Constants.LibyaCountryName:
                    return "Africa/Tripoli";
                case Constants.IraqCountryName:
                    return "Asia/Baghdad";
                case Constants.TurkeyCountryName:
                    return "Europe/Istanbul";
            }

            return null;
        }
    }
}
