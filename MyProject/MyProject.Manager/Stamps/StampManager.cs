using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MyProject.Domain;
using MyProject.Domain.Categories;
using MyProject.Domain.Stamps;
using MyProject.Shared;

namespace MyProject.Manager.Stamps
{
    internal class StampManager(IStampProvider stampProvider, ICurrentUserService currentUserService,
        IStringLocalizerFactory factory) : IStampManager
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;
        private readonly IStampProvider _stampProvider = stampProvider;
        private readonly IStringLocalizer _localizer = factory.Create(typeof(CommonResource));

        public async Task AddStampAsync(long couponId, string qrCode)
        {
            var clientId = _currentUserService.GetUserId();

            await _stampProvider.AddStampAsync(couponId, qrCode, clientId);
        }
    }
}
