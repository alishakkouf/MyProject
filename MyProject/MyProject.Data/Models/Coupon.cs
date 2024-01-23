﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Models
{
    internal class Coupon : IHaveBusinessId, IAuditedEntity
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Code { get; set; }

        public string? Tag { get; set; }

        public string? Image { get; set; }

        public required string Description { get; set; }

        public DateTime EXP { get; set; }

        /// <summary>
        /// visits count
        /// </summary>
        public int NumOfRequests { get; set; }

        public int? BusinessId { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public long? ModifierUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
