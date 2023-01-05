using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class SendSmsRequest : BaseRequest
    {
        public new string Method { get => "SendSms"; }

        public string To { get; set; }

        public string Content { get; set; }
    }
}