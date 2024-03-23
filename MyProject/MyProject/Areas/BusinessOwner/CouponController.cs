using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.BusinessOwner.CouponDtos;
using MyProject.Common;
using MyProject.Domain.Business;
using MyProject.Domain.Coupons;
using MyProject.Manager.Business;
using MyProject.Shared;

namespace MyProject.Areas.BusinessOwner
{
    public class CouponController(IStringLocalizerFactory factory,
           ILogger<CouponController> logger,
           ICouponManager couponManager, IMapper Mapper) : BaseBusinessController(factory)
    {
        private readonly ILogger<CouponController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly ICouponManager _couponManager = couponManager;

        /// <summary>
        /// Get all Coupons
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<CouponListResult>> GetAllAsync(GetAllCouponsQuery query)
        {
            _logger.LogInformation($"Getting list of admins(owner of businesses) via {nameof(GetAllAsync)} API");

            query.IsFromClient = false;

            var data = await _couponManager.GetAllAsync(query);

            return Ok(data);
        }

        /// <summary>
        /// Create new Coupon
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(CreateCouponRequestDto requestDto)
        {
            await _couponManager.CreateAsync(_mapper.Map<CreateCouponCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Update existed Coupon
        /// </summary>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateAsync(UpdateCouponRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(CouponController));

            await _couponManager.UpdateAsync(_mapper.Map<UpdateCouponCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Delete Coupon
        /// </summary>
        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] EntityDto<long> input)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(CouponController));

            await _couponManager.DeleteAsync(input.Id);

            return Ok();
        }

        /// <summary>
        /// Get QR code
        /// </summary>
        [HttpGet("GenerateQR")]
        public async Task<ActionResult<QrCodeDto>> GenerateQRAsync([FromQuery] EntityDto<long> input)
        {
            _logger.LogInformation($"Get QR code via {nameof(GenerateQRAsync)} API");

            var data = await _couponManager.GenerateQRAsync(new CreateQRCommand { CouponId = input.Id });

            return Ok(new QrCodeDto { QrCode = data });
        }
    }
}
