using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared.Enums
{
    public enum AuditOperationType : byte
    {
        Create = 1,
        Update = 2,
        Delete = 3
    }
}
