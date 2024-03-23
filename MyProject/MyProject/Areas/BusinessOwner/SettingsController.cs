using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Areas.BusinessOwner.SettingsDtos;
using MyProject.Domain.Coupons;
using MyProject.Domain.Products;
using MyProject.Domain.Settings;

namespace MyProject.Areas.BusinessOwner
{
    public class SettingsController(IStringLocalizerFactory factory,
           ILogger<SettingsController> logger,
           ISettingsManager settingsManager, IMapper Mapper) : BaseBusinessController(factory)
    {
        private readonly ILogger<SettingsController> _logger = logger ?? throw new ArgumentNullException(nameof(factory));
        private readonly IMapper _mapper;
        private readonly ISettingsManager _settingsManager = settingsManager;

        /// <summary>
        /// Get all Settings
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SettingsDto>>> GetAllAsync()
        {
            _logger.LogInformation($"Getting list of Settings via {nameof(GetAllAsync)} API");

            var data = await _settingsManager.GetAllAsync();

            return Ok(_mapper.Map<List<SettingsDto>>(data));
        }

        /// <summary>
        /// Update existed Settings
        /// </summary>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateAsync(UpdateSettingsRequestDto requestDto)
        {
            _logger.LogInformation("Executing {ClassName}", nameof(SettingsController));

            await _settingsManager.UpdateAsync(_mapper.Map<UpdateSettingsCommand>(requestDto));

            return Ok();
        }

    }
}
