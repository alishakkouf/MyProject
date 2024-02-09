using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.Client.Controllers.CouponController.Dtos;
using MyProject.Common;
using MyProject.Domain.Business;
using MyProject.Domain.Coupons;
using MyProject.Manager.Business;
using MyProject.Shared;

namespace MyProject.Areas.BusinessOwner.Controllers.CouponController
{
    public class BusinessCouponController(IStringLocalizerFactory factory,
           ILogger<BusinessCouponController> logger,
           ICouponManager couponManager, IMapper Mapper) : BaseBusinessController(factory)
    {
        private readonly ILogger<BusinessCouponController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly ICouponManager _couponManager = couponManager;

        /// <summary>
        /// Get all Coupons
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CouponDto>>> GetAllAsync()
        {
            _logger.LogInformation($"Getting list of admins(owner of businesses) via {nameof(GetAllAsync)} API");

            var data = await _couponManager.GetAllAsync();

            return Ok(_mapper.Map<List<CouponDto>>(data));
        }

        /// <summary>
        /// Create new Coupon
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(CreateCouponRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessCouponController));

            await _couponManager.CreateAsync(_mapper.Map<CreateCouponCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Update existed Coupon
        /// </summary>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateAsync(UpdateCouponRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessCouponController));

            await _couponManager.UpdateAsync(_mapper.Map<UpdateCouponCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Delete Coupon
        /// </summary>
        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteAsync(EntityDto<int> input)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessCouponController));

            await _couponManager.DeleteAsync(input.Id);

            return Ok();
        }
    }
}
