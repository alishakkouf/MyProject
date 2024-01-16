using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Shared;

namespace MyProject.Domain.Authorization
{
    /// <summary>
    /// Static permissions of the system are defined here, and they will be added as claims (of type <see cref="Constants.PermissionsClaimType"/>)
    /// to the corresponding roles. Static role permissions are defined in <see cref="StaticRolePermissions"/>.
    /// </summary>
    public static class Permissions
    {
        private const string PermissionsPrefix = Constants.PermissionsClaimType + ".";

        public static readonly string[] ListAll =
        {

            Product.Create,
            Product.Delete,
            Product.Update,
            Product.View
        };


        #region Product Permissions
        public static class Product
        {
            public const string View = PermissionsPrefix + "Product.View";
            public const string Create = PermissionsPrefix + "Product.Create";
            public const string Update = PermissionsPrefix + "Product.Update";
            public const string Delete = PermissionsPrefix + "Product.Delete";
        }
        #endregion

       
    }
}
