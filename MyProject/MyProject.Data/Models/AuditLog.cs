using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Xml;
using MyProject.Shared.Enums;
using Newtonsoft.Json;

namespace MyProject.Data.Models
{
    internal class AuditLog
    {
        public long Id { get; set; }

        [StringLength(500)]
        public string EntityName { get; set; }

        public long? EntityId { get; set; }

        public AuditOperationType Operation { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public long? UserId { get; set; }

        [StringLength(1000)]
        public string EntityKeys { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

        public string EntityObject { get; set; }
    }

    internal class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }

        public string EntityName { get; set; }

        public string EntityKeyName { get; set; }

        public AuditOperationType Operation { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAudit(long? userId)
        {
            var audit = new AuditLog
            {
                EntityName = EntityName,
                Operation = Operation,
                DateTime = DateTime.UtcNow,
                UserId = userId
            };

            if (KeyValues.Count == 1 && long.TryParse(KeyValues.First().Value.ToString(), out var entityId))
                audit.EntityId = entityId;
            else
            {
                var keyValue = KeyValues[EntityKeyName];
                if (keyValue != null && long.TryParse(keyValue.ToString(), out var masterId))
                    audit.EntityId = masterId;
            }

            audit.EntityKeys = JsonConvert.SerializeObject(KeyValues);

            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);

            audit.EntityObject = JsonConvert.SerializeObject(Entry.Entity, Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return audit;
        }
    }
}
