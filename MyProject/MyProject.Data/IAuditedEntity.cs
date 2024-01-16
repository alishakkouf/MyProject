using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data
{
    public interface IAuditedEntity
    {
        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
