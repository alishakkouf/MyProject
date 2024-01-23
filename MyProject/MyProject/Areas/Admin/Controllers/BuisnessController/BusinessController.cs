using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.Admin.Controllers.BuisnessController.Dtos;
using MyProject.Common;
using MyProject.Domain.Business;

namespace MyProject.Areas.Admin.Controllers.BuisnessController
{
    public class BusinessController(IStringLocalizerFactory factory,
           ILogger<BusinessController> logger,
           IBusinessManager businessManager, IMapper Mapper) : BaseAdminController(factory)
    {
        private readonly ILogger<BusinessController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly IBusinessManager _businessManager = businessManager;

        /// <summary>
        /// Get all Businesses
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BusinessDto>>> GetAllAsync()
        {
            _logger.LogInformation($"Getting list of admins(owner of businesses) via {nameof(GetAllAsync)} API");

            var data = await _businessManager.GetAllAsync();

            return Ok(_mapper.Map<List<BusinessDto>>(data));
        }

        /// <summary>
        /// Create new business
        /// </summary>
        [HttpGet("Create")]
        public async Task<ActionResult> CreateAsync(CreateBusinessRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessController));

            await _businessManager.CreateBusinessAsync(_mapper.Map<CreateBusinessCommand>(requestDto));

            return Ok();
        }

        /// <summary>
        /// Update existed business
        /// </summary>
        [HttpGet("Update")]
        public async Task<ActionResult> UpdateAsync(UpdateBusinessRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessController));

            await _businessManager.UpdateBusinessAsync(_mapper.Map<UpdateBusinessCommand>(requestDto));

            return Ok();
        }
    }
}
