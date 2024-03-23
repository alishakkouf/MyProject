using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MyProject.Domain.Business;
using MyProject.Shared;

namespace MyProject.Manager.Business
{
    public class BusinessManager(IBusinessProvider provider, IStringLocalizerFactory factory,
        ILogger<BusinessManager> logger) : IBusinessManager
    {
        private readonly IBusinessProvider _provider = provider;
        private readonly IStringLocalizer _localizer = factory.Create(typeof(CommonResource));
        private readonly ILogger<BusinessManager> _logger = logger;

        public async Task<BusinessDomain> CreateBusinessAsync(CreateBusinessCommand command)
        {
            return await _provider.CreateBusinessAsync(command);
        }

        public async Task<List<BusinessDomain>> GetAllAsync(GetAllBusinessQuery query)
        {
            return await _provider.GetAllAsync(query);
        }

        public async Task<BusinessDomain> GetAsync(long id)
        {
            return await _provider.GetAsync(id);
        }

        public async Task<BusinessDomain> GetCurrentBusinessAsync()
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
