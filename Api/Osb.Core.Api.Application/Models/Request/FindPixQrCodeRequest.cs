using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindPixQrCodeRequest : BaseRequest
    {
        public long ExternalIdentifier { get; set; }
        public string TaxId { get; set; }
    }
}