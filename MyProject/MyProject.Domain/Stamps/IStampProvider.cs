using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Stamps
{
    public interface IStampProvider
    {
        Task AddStampAsync(long couponId, string qrCode, long clientId);
    }
}
