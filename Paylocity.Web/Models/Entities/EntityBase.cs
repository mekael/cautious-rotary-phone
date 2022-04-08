using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paylocity.Web.Models.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; } // allows for client level filtering
        public bool IsDeleted { get; set; } //compliance! 
        public string CreatedByUser { get; set; } 
        public string LastModifiedByUser { get; set; }
        public DateTime CreationTimestamp { get; set; } = DateTime.Now;
        public DateTime LastModificationTimestamp { get; set; } = DateTime.Now;
    }
}
