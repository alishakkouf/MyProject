using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Authorization
{
    /// <summary>
    /// Static roles and permissions for them are defined here.
    /// System will seed them on startup.
    /// </summary>
    public static class StaticRolePermissions
    {
        public static readonly Dictionary<string, string[]> Roles =
            new Dictionary<string, string[]>
            {
                {
                    StaticRoleNames.Administrator,
                    Permissions.ListAll
                }
            };
    }
}
