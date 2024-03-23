using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.Common
{
    [Area("Common")]
    public class BaseCommonController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
