using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Returns Tenant Id of current logged user
        /// </summary>
        int? GetTenantId();

        /// <summary>
        /// Returns User Id of current logged user
        /// </summary>
        int? GetUserId();

        /// <summary>
        /// Returns current User Name_en from Claims
        /// </summary>
        string? GetUserName();

        /// <summary>
        /// Returns current User Full Name_en from Claims
        /// </summary>
        string? GetUserFullName();

        /// <summary>
        /// Checks if current user has a specific role
        /// </summary>
        bool IsInRole(string role);

        /// <summary>
        /// get user role.
        /// </summary>
        string? GetUserRole();

        /// <summary>
        /// Check if user has permission save in his claims
        /// </summary>
        bool HasPermission(string permission);
    }
}
