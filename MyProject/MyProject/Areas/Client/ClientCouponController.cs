using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.Client.Dtos;
using MyProject.Common;
using MyProject.Domain.Authorization;
using MyProject.Domain.Business;
using MyProject.Domain.Coupons;
using MyProject.Manager.Business;
using MyProject.Shared;

namespace MyProject.Areas.Client
{
    public class ClientCouponController(IStringLocalizerFactory factory,
           ILogger<ClientCouponController> logger,
           ICouponManager couponManager, IMapper Mapper) : BaseClientController(factory)
    {
        private readonly ILogger<ClientCouponController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly ICouponManager _couponManager = couponManager;

        /// <summary>
        /// Get all Coupons
        /// </summary>
        [Authorize(Permissions.Coupun.View)]
        [HttpGet("GetAll")]
        public async Task<ActionResult<CouponListResult>> GetAllAsync(GetAllCouponsQuery query)
        {
            _logger.LogInformation($"Getting list of coupons via {nameof(GetAllAsync)} API");

            query.IsFromClient = true;

            var data = await _couponManager.GetAllAsync(query);

            return Ok(data);
        }

        /// <summary>
        /// Get a Coupon
        /// </summary>
        [Authorize(Permissions.Coupun.View)]
        [HttpGet("Get")]
        public async Task<ActionResult<CouponListResult>> GetAsync([FromQuery] EntityDto<long> input)
        {
            _logger.LogInformation($"Getting a coupon via {nameof(GetAsync)} API");

            var data = await _couponManager.GetAsync(input.Id, true);

            return Ok(data);
        }

    }
}
