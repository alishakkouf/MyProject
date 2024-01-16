using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared
{
    /// <summary>
    /// This attribute is used to apply audit logging for a class.
    /// If entity is weak, a parameter KeyName must be specified to audit master key.
    /// ex: AppointmentService master key is 'AppointmentId'.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditedAttribute : Attribute
    {
        public string KeyName { get; }

        public AuditedAttribute() : this(string.Empty)
        {
        }

        public AuditedAttribute(string keyName)
        {
            KeyName = keyName;
        }
    }
}
