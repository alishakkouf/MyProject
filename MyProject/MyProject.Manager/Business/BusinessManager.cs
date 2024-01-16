using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Business;

namespace MyProject.Manager.Business
{
    public class BusinessManager : IBusinessManager
    {
        public Task<BusinessDomain> CreateBusinessAsync(CreateBusinessCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusinessDomain>> GetAllAsync(bool? isActive)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessDomain> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessDomain> GetCurrentBusinessAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BusinessDomain> GetWithoutBusinessAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsActiveBusinessAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCityAsync(int id, string cityName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNameAsync(int id, string clinicName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSpecialtyAsync(int BusinessId, string specialty)
        {
            throw new NotImplementedException();
        }
    }
}
