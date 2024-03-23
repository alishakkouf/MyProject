using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Settings
{
    public interface ISettingsManager
    {
        Task<SettingsDomain> GetAllAsync();

        Task UpdateAsync(UpdateSettingsCommand command);
    }
}
