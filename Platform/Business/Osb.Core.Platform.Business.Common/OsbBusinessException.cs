namespace Osb.Core.Platform.Business.Common
{
    [System.Serializable]
    public class OsbBusinessException : System.Exception
    {
        public OsbBusinessException() { }
        public OsbBusinessException(string message) : base(message) { }
        public OsbBusinessException(string message, System.Exception inner) : base(message, inner) { }
        protected OsbBusinessException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) : base(info, context) { }
    }
}