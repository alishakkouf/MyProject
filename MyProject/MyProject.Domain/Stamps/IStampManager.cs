using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Stamps
{
    public interface IStampManager
    {
        Task AddStampAsync(long couponId, string qrCode);
    }
}
