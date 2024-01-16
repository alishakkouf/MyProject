using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Settings
{
    public static class SupportedLanguages
    {
        public static readonly List<string> ListAll = new List<string>
        {
            English,
            Arabic
        };

        public const string English = "en-GB";
        public const string Arabic = "ar-SY";
    }
}
