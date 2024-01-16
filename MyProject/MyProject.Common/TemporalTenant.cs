using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public class TemporalTenant
    {
        private int? _tenantId;

        public int? TenantId => _tenantId;

        public void SetTemporalTenant(int tenantId)
        {
            _tenantId = tenantId;
        }
    }
}
