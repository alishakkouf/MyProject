﻿using System;
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
