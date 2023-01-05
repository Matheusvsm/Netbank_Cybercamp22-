using System;
using Osb.Core.Platform.Common.Entity.Interfaces;

namespace Osb.Core.Platform.Common.Entity.Models
{
    public class BaseEntity : IEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public long CreationUserId { get; set; }
        public long UpdateUserId { get; set; }

    }
}