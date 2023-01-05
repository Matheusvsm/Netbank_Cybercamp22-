using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class OperationAttachment : BaseEntity
    {
        public long OperationAttachmentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Extension { get; set; }
        public long OperationId { get; set; }

        public static OperationAttachment Create(string content, string extension, long operationId, long userId)
        {
            return new OperationAttachment
            {
                Name = $"{DateTime.Now:yyyyMMddHHmmssffff}".ToLower(),
                Content = content,
                Extension = extension,
                OperationId = operationId,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}