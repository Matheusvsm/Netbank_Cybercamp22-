namespace Osb.Core.Platform.Integration.Entity.Models.Request.Base
{
    public class ExternalRequest
    {
        public object Body { get; set; }
        public string Url { get; set; }
        public Headers Headers { get; set; }
    }
}