using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class SendMailRequest : BaseRequest
    {
        public new string Method { get => "SendMail"; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}