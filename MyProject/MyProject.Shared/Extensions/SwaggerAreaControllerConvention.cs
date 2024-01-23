using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MyProject.Shared.Extensions
{
    public class SwaggerAreaControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace;
            var nameSpaceSections = controllerNamespace.Split(".").ToList();
            var areaSectionIndex = nameSpaceSections.IndexOf("Areas");
            if (areaSectionIndex == -1)
                controller.ApiExplorer.GroupName = "Store";
            else
                controller.ApiExplorer.GroupName = nameSpaceSections[areaSectionIndex + 1].Replace("App", "");
        }
    }
}
