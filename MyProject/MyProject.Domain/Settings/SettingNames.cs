using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Settings
{
    public static class SettingNames
    {
        public const string AppTimeZone = "App.TimeZone";
        public const string AppCountryPhoneCode = "App.CountryPhoneCode";
        public const string AppLanguage = "App.Language";
        public const string AppSmsLanguage = "App.SmsLanguage";
        public const string AppSmsFromPhone = "App.SmsFromPhone";
        /// <summary>
        /// Set whether the sms functionality enabled or not
        /// </summary>
        public const string AppSmsEnabled = "App.SmsEnabled";
        /// <summary>
        /// Time of day (HH:mm) to send sms to clients 
        /// </summary>
        public const string AppSmsSendTimeOfDay = "App.SmsSendTimeOfDay";


        public const string AppSendEmailNotificationEnabled = "App.SendEmailNotificationEnabled";

        public const string BusinessName = "Business.Name";

        /// <summary>
        /// Used by user name to be 'user@domain-name'
        /// </summary>
        public const string BusinessDomainName = "Business.DomainName";

        /// <summary>
        /// Serialized address as JsonAddress
        /// </summary>
        public const string BusinessAddressInfo = "Business.AddressInfo";

        public const string BusinessLogoBase64 = "Business.LogoBase64";
        public const string LogoUrl = "Business.LogoUrl";

        public const string BusinessOwner = "Business.Owner";

        public const string Country = "Business.Country";
        public const string City = "Business.City";
        public const string IBAN = "Business.IBAN";
        public const string TaxNr = "Business.Tax_Nr";
        public const string BusinessEmail = "Business.Email";
        public const string BusinessPhone = "Business.Phone";
        public const string BusinessCurrency = "Business.Currency";
        public const string BusinessOpeningTime = "Business.OpeningTime";
        public const string BusinessClosingTime = "Business.ClosingTime";

        public const string Is24Hour = "Business.Is24Hour";

        public const string WhatsAppEnabled = "WhatsApp.Enabled";
        public const string WhatsAppAccessToken = "WhatsApp.AccessToken";
        public const string WhatsAppChannelId = "WhatsApp.ChannelId";

        public const string BusinessCoverImageUrl = "Business.CoverImageUrl";
        public const string BusinessDescription = "Business.Description";
        public const string BusinessIsOpen = "Business.IsOpen";
               

        // Engine settings
        public const string MsgEngChannels = "Business.ChannelsEnabled";
        public const string MsgEngWhatsAppAccessToken = "Business.WhatsApp.AccessToken";
        public const string MsgEngWhatsAppChannelId = "Business.WhatsApp.ChannelId";
        public const string MsgEngSmsConfiguration = "Business.Sms.Configuration";
        public const string MsgEngEmailConfiguration = "Business.Email.Configuration";
        public const string MsgEngWhatsAppConfiguration = "Business.WhatsApp.Configuration";
        // End Engine settings

        public const string BusinessEnableExport = "Business.EnableExport";
    }

    public static class SettingDefaults
    {
        public static readonly Dictionary<string, string> Defaults =
            new Dictionary<string, string>
            {
                { SettingNames.AppTimeZone, "Europe/Berlin" },
                { SettingNames.AppCountryPhoneCode, "+49" },
                { SettingNames.AppLanguage, SupportedLanguages.English },
                { SettingNames.AppSmsLanguage, SupportedLanguages.English },
                 { SettingNames.AppSmsFromPhone, "YoloBusiness" },
                { SettingNames.AppSmsEnabled, "true" },
                { SettingNames.AppSmsSendTimeOfDay, "08:00" },
                { SettingNames.AppSendEmailNotificationEnabled, "false" },

                { SettingNames.BusinessName, "YOLO" },
                { SettingNames.BusinessDomainName, "yolo.Business" },
                { SettingNames.BusinessAddressInfo, "" },
                { SettingNames.BusinessLogoBase64, "" },
                { SettingNames.LogoUrl, "" },
                { SettingNames.Country, "" },
                { SettingNames.City, "" },
                { SettingNames.IBAN, "" },
                { SettingNames.TaxNr, "" },
                { SettingNames.BusinessEmail, "" },
                { SettingNames.BusinessPhone, "" },
                { SettingNames.BusinessCurrency, "" },
                { SettingNames.BusinessOpeningTime, "08:00" },
                { SettingNames.BusinessClosingTime, "22:00" },

                { SettingNames.WhatsAppEnabled, "false" },
                { SettingNames.WhatsAppAccessToken, "" },
                { SettingNames.WhatsAppChannelId, "" },
                { SettingNames.BusinessCoverImageUrl, "" },
                { SettingNames.BusinessDescription, "" },
                { SettingNames.BusinessIsOpen, "true" },
                { SettingNames.Is24Hour, "true" },
               
                
                { SettingNames.MsgEngChannels, "{'sms':0,'whatsapp':0,'email':0,'patientapp':1}" },
                { SettingNames.MsgEngWhatsAppAccessToken, "" },
                { SettingNames.MsgEngWhatsAppChannelId, "" },
                { SettingNames.MsgEngSmsConfiguration, "{'provider':'','configuration':null}" },
                { SettingNames.MsgEngEmailConfiguration, "{'provider':'','configuration':null}" },
                { SettingNames.MsgEngWhatsAppConfiguration, "{'provider':'','configuration':null}" },

               

               { SettingNames.BusinessEnableExport, "true" }
            };
    }
}
