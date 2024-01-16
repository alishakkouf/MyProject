using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProject.Common.Filters
{
    public class NormalizeFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var dto in context.ActionArguments.Values.OfType<IShouldNormalize>())
            {
                dto.Normalize();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
