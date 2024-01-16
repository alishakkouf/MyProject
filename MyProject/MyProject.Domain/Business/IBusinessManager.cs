using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Business
{
    public interface IBusinessManager
    {
        /// <summary>
        /// Get all Businesss.
        /// Filtered by isActive.
        /// </summary>
        Task<List<BusinessDomain>> GetAllAsync(bool? isActive);

        /// <summary>
        /// Get Business data.
        /// </summary>
        Task<BusinessDomain> GetAsync(int id);

        /// <summary>
        ///  Get Business data for unauthorized request.
        /// </summary>
        Task<BusinessDomain> GetWithoutBusinessAsync(int id);

        /// <summary>
        /// Get current Business.
        /// Return nulls if no Business is provided.
        /// </summary>
        Task<BusinessDomain> GetCurrentBusinessAsync();

        /// <summary>
        /// Check if Business with id is active.
        /// </summary>
        Task<bool> IsActiveBusinessAsync(int id);

        /// <summary>
        /// Create new clinic
        /// </summary>
        Task<BusinessDomain> CreateBusinessAsync(CreateBusinessCommand command);

        /// <summary>
        /// Get active list of clinics with their settings
        /// </summary>
        //Task<PagedResultDto<YoloClinicDomain>> GetActiveListAsync(ActiveClinicListQuery query);

        //Task UpdateBusinessAsync(UpdateBusinessInfoCommand command, IFormFile coverImage);

        /// <summary>
        /// Update Business specialty if changed
        /// </summary>
        Task UpdateSpecialtyAsync(int BusinessId, string specialty);

        Task UpdateNameAsync(int id, string clinicName);

        /// <summary>
        /// Update Business city if changes
        /// </summary>
        Task UpdateCityAsync(int id, string cityName);
    }
}
