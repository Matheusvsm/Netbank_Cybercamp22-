using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class NewAccountPersonDocument : BaseEntity
    {
        public long NewAccountPersonDocumentId { get; set;}
        public long? NewAccountId { get; set;}
        public long? NewAccountPersonId { get; set;}
        public byte[] DocumentFile { get; set; }
        public DocumentFormat? DocumentFormat { get; set; }
        public string DocumentName { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public static NewAccountPersonDocument Create(long? newAccountId, long? newAccountPersonId, byte[] documentFile, DocumentFormat? documentFormat, string documentName, DocumentType documentType,
            string description, DateTime? expirationDate, long userId)
        {
            return new NewAccountPersonDocument{
                NewAccountId = newAccountId,
                NewAccountPersonId = newAccountPersonId,
                DocumentFile = documentFile,
                DocumentFormat = documentFormat,
                DocumentName = documentName,
                DocumentType = documentType,
                Description = description,
                ExpirationDate = expirationDate,
                CreationUserId = userId
            };
        }
    }
}