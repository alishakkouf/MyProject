using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Localization;
using MyProject.Areas.Client.StampsDto;
using MyProject.Domain.Authorization;
using MyProject.Domain.Coupons;
using MyProject.Domain.Stamps;
using MyProject.Shared;

namespace MyProject.Areas.Client
{
    public class StampsController(IStringLocalizerFactory factory,
    ILogger<ClientCouponController> logger,
           IStampManager stampManager, IMapper Mapper) : BaseClientController(factory)
    {
        private readonly ILogger<ClientCouponController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly IStampManager _stampManager = stampManager;

        /// <summary>
        ///  Add stamp to Coupon
        /// </summary>
        [Authorize(Permissions.Coupun.View)]
        [HttpGet("AddStampToCoupon")]
        public async Task<ActionResult<CouponListResult>> AddStampToCouponAsync(AddStampRequestDto input)
        {
            _logger.LogInformation($"Add a Stamp via {nameof(AddStampToCouponAsync)} API");

            await _stampManager.AddStampAsync(input.CouponId, input.QR);

            return Ok();
        }

    }
}
