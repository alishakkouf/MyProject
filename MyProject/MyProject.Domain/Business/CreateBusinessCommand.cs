using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Business
{
    public class CreateBusinessCommand
    {
        public string Name { get; set; }

        public string DomainName { get; set; }

        public string AdminPassword { get; set; }

        public string BusinessEmail { get; set; }

        public string BusinessCountry { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessPhoneCode { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessOwner { get; set; }
        public string BusinessType { get; set; }
        public string BusinessCurrency { get; set; }
    }
}
