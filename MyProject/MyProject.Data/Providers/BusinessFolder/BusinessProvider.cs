using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyProject.Data.Models;
using MyProject.Domain.Business;

namespace MyProject.Data.Providers.BusinessFolder
{
    internal class BusinessProvider : GenericProvider<Business>, IBusinessProvider
    {
        private readonly IMapper _mapper;

        public BusinessProvider(MyProjectDbContext dbContext,
            IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }
        public Task<BusinessDomain> CreateBusinessAsync(CreateBusinessCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<List<BusinessDomain>> GetAllAsync()
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

        public Task<bool> IsActiveBusinessAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBusinessAsync(UpdateBusinessCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
