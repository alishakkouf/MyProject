using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.BusinessOwner
{
    [Area("BusinessOwner")]
    public class BaseBusinessController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
