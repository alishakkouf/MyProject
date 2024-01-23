using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.BusinessOwner.Controllers
{
    [Area("Business")]
    public class BaseBusinessController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
