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
        Task<List<BusinessDomain>> GetAllAsync(GetAllBusinessQuery query);

        /// <summary>
        /// Get Business data.
        /// </summary>
        Task<BusinessDomain> GetAsync(int id);

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
        /// Update existed business
        /// </summary>
        Task UpdateBusinessAsync(UpdateBusinessCommand command);

    }
}
