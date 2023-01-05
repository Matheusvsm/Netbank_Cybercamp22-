using System.ComponentModel.DataAnnotations;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindBoletoInfoRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string NumericSequence { get; set; }
    }
}