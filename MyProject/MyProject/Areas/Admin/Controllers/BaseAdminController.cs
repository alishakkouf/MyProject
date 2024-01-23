using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyProject.Common;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseAdminController(IStringLocalizerFactory factory) : BaseApiController(factory)
    {
    }
}
