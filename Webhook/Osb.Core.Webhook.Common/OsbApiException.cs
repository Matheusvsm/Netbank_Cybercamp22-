namespace Osb.Core.Webhook.Common
{
    [System.Serializable]
    public class OsbApiException : System.Exception
    {
        public OsbApiException() { }
        public OsbApiException(string message) : base(message) { }
        public OsbApiException(string message, System.Exception inner) : base(message, inner) { }
        protected OsbApiException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) : base(info, context) { }
    }
}
