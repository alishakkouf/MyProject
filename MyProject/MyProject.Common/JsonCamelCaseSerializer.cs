using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace MyProject.Common
{
    public static class JsonCamelCaseSerializer
    {
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
