using Microsoft.AspNetCore.Http;
using MyProject.Common.Extensions;
using MyProject.Data;
using MyProject.Shared;
using System.Security.Claims;

namespace MyProject.Common
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor, TemporalTenant temporalTenant) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly TemporalTenant _temporalTenant = temporalTenant;

        public int? GetTenantId()
        {
            if (_temporalTenant.TenantId != null) return _temporalTenant.TenantId;

            var tenantClaim = _httpContextAccessor.HttpContext?.User.FindFirstValue(Constants.BusinessIdClaimType);

            if (int.TryParse(tenantClaim, out var tenantId))
                return tenantId;

            return null;
        }

        public int? GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User.GetUserId();
        }

        public string? GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User.GetUserName();
        }

        public string? GetUserFullName()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.GivenName);
        }

        public bool IsInRole(string role)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(role) ?? false;
        }

        public bool HasPermission(string permission)
        {
            return _httpContextAccessor.HttpContext?.User.HasClaim(x => x.Type == Constants.PermissionsClaimType && x.Value == permission) ?? false;
        }

        public string? GetUserRole()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
        }
    }
}
