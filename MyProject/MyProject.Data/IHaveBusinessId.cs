﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public interface IHaveBusinessId
    {
        public long? BusinessId { get; set; }
    }
}
