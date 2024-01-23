using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.Client.Controllers
{
    [Area("Client")]
    public class BaseBusinessController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
