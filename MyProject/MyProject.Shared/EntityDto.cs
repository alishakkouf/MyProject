using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared
{
    public class EntityDto<T>
    {
        public required T Id { get; set; }
    }
}
