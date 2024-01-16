using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared.Enums
{
    public enum Gender : byte
    {
        [Description("1:Male")]
        Male = 1,
        [Description("2:Female")]
        Female = 2,
        [Description("3:Ambiguous")]
        Other = 3
    }
}
