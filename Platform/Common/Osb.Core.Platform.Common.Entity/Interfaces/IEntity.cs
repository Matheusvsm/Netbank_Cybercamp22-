using System;

namespace Osb.Core.Platform.Common.Entity.Interfaces
{
    public interface IEntity
    {
        long CreationUserId { get; set; }
        long UpdateUserId { get; set; }
        DateTime CreationDate { get; set; }
        DateTime? DeletionDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}