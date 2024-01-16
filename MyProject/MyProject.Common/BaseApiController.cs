using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Shared;

namespace MyProject.Common
{
    /// <summary>
    /// Base api controller annotated with attribute [ApiController] and default
    /// base route("api/[controller]").
    /// Needs the service IStringLocalizerFactory to be injected for localization.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private readonly IStringLocalizer _localizer;

        protected BaseApiController(IStringLocalizerFactory factory)
        {
            _localizer = factory.Create(typeof(CommonResource));
        }

        /// <summary>
        /// Localize a message from <see cref="CommonResource"/>.
        /// </summary>
        protected string Localize(string message)
        {
            return _localizer[message];
        }

        /// <summary>
        /// Localize a message from <see cref="CommonResource"/> with arguments.
        /// </summary>
        protected string Localize(string message, params object[] arguments)
        {
            return _localizer[message, arguments];
        }
    }
}
