using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.Client
{
    [Area("Client")]
    public class BaseClientController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
