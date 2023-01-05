using System;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class NewAccountPersonDocumentRequest
    {
        public byte[] DocumentFile { get; set; }
        public DocumentFormat? DocumentFormat { get; set; }
        public string DocumentName { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}