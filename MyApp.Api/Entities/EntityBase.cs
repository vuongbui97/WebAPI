using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTimeOffset CreatedOn { get; set; }
        public virtual string? UpdatedBy { get; set; }
        public virtual DateTimeOffset? UpdatedOn { get; set; }
    }
}