using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        /// <summary>
        /// Exception for business rules conflicts. 
        /// </summary>
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
