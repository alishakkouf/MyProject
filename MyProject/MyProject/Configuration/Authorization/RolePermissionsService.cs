using Microsoft.AspNetCore.Identity;
using MyProject.Data.Models;
using MyProject.Shared;
using System.Security.Claims;

namespace MyProject.Configuration.Authorization
{
    internal interface IRolePermissionsService
    {
        /// <summary>
        /// Get ClaimsIdentity that contains all permission claims of the roles of the user.
        /// </summary>
        Task<ClaimsIdentity> GetUserPermissionsIdentity(int userId, CancellationToken cancellationToken);
    }

    internal class RolePermissionsService : IRolePermissionsService
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<UserRole> _roleManager;

        public RolePermissionsService(UserManager<UserAccount> userManager, RoleManager<UserRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ClaimsIdentity> GetUserPermissionsIdentity(int userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var permissionClaims = new List<Claim>();
            if (user != null && user.IsActive && user.IsDeleted != true)
            {
                var userHasActiveRole = false;

                var roleNames = await _userManager.GetRolesAsync(user);
                foreach (var roleName in roleNames)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (!role.IsActive)
                        continue;

                    userHasActiveRole = true;

                    var claims = await _roleManager.GetClaimsAsync(role);
                    permissionClaims.AddRange(claims.Where(x => x.Type == Constants.PermissionsClaimType));
                }

                // Add claim UserIsActive to be tested by default policy 
                if (userHasActiveRole)
                    permissionClaims.Add(new Claim(Constants.ActiveUserClaimType, "true"));
            }

            var userPermissions = permissionClaims.Distinct().ToList();

            return CreatePermissionsIdentity(userPermissions);
        }

        private ClaimsIdentity CreatePermissionsIdentity(IReadOnlyCollection<Claim> claimPermissions)
        {
            if (!claimPermissions.Any())
                return null;

            var permissionsIdentity = new ClaimsIdentity(nameof(PermissionsMiddleware));
            permissionsIdentity.AddClaims(claimPermissions);

            return permissionsIdentity;
        }
    }
}
