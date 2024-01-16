using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;
using MyProject.Controllers.BuisnessController.Dtos;
using NLog.Config;

namespace MyProject.Controllers.BuisnessController
{
    public class BusinessController(IStringLocalizerFactory factory,
           ILogger<BusinessController> logger, IMapper _mapper) : BaseApiController(factory)
    {
        private readonly ILogger<BusinessController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;

        /// <summary>
        /// Get all trips
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BusinessDto>>> GetAllAsync()
        {
            _logger.LogInformation("Executing {ClassName}", nameof(BusinessController));

            return Ok();
        }
    }
}
