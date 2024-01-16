using System.Security.Claims;
using MyProject.Shared;
using Microsoft.AspNetCore.Http;

namespace MyProject.Common.Extensions
{
    public static class IdentityUserExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal user)
        {
            var id = user?.FindFirstValue(ClaimTypes.NameIdentifier);
            return string.IsNullOrEmpty(id) ? (int?)null : int.Parse(id);
        }

        public static string? GetUserName(this ClaimsPrincipal user)
            => user?.FindFirstValue(ClaimTypes.Name);

        public static int? GetBusinessId(this ClaimsPrincipal user)
        {
            var BusinessId = user?.FindFirstValue(Constants.BusinessIdClaimType);
            return string.IsNullOrEmpty(BusinessId) ? (int?)null : int.Parse(BusinessId);
        }

        public static List<string> GetPermissions(this ClaimsPrincipal user)
        {
            return user?.Claims.Where(c => c.Type == Constants.PermissionsClaimType).Select(c => c.Value).ToList() ?? [];
        }

        public static bool IsWithoutRole(this ClaimsPrincipal user)
        {
            var role = user?.FindFirstValue(ClaimTypes.Role);
            return string.IsNullOrEmpty(role);
        }

        //public static string GetAccessToken(this HttpRequest request)
        //{
        //    return request.Headers.Authorization[0]["bearer ".Length..];
        //}
    }
}
