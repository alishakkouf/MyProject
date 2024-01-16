namespace MyProject.Shared
{
    public static class Constants
    {
        public const string AppIgnoreBusinessIdKey = "App:IgnoreBusinessId";

        /// <summary>
        /// The custom claim type for Business id
        /// </summary>
        public const string BusinessIdClaimType = "BusinessId";

        /// <summary>
        /// The custom claim type for the role permissions
        /// </summary>
        public const string PermissionsClaimType = "Permissions";

        public const string AppAuditedArrayKey = "App:NewAuditedArray";

        /// <summary>
        /// Id of the first seeded Business
        /// </summary>
        public const int DefaultBusinessId = 1;
        public const string DefaultBusinessAdmin = "admin@shakkouf.business";
        public const string DefaultBusinessDomain = "shakkouf.business";

        public const string AdministratorUserName = "Administrator";
        public const string DefaultPassword = "P@ssw0rd";
        public const string DefaultPhoneNumber = "0";

        public const string SuperAdminRoleName = "SuperAdmin";
        public const string SuperAdminUserName = "SuperAdmin";
        public const string SuperAdminEmail = "superadmin@shakkouf.business";

        /// <summary>
        /// The custom claim type to insure active user
        /// </summary>
        public const string ActiveUserClaimType = "UserIsActive";

        public const string GermanyCountryName = "Germany";
        public const string UAECountryName = "United Arab Emirates";
        public const string SyriaCountryName = "Syria";
        public const string EgyptCountryName = "Egypt";
        public const string JordanCountryName = "Jordan";
        public const string YemenCountryName = "Yemen";
        public const string LibyaCountryName = "Libya";
        public const string PalestineCountryName = "Palestine";
        public const string IraqCountryName = "Iraq";
        public const string TurkeyCountryName = "Turkey";
    }
}
