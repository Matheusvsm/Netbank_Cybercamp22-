namespace Osb.Core.Platform.Auth.Common
{

    [System.Serializable]
    public class OsbAuthException : System.Exception
    {
        public OsbAuthException() { }
        public OsbAuthException(string message) : base(message) { }
        public OsbAuthException(string message, System.Exception inner) : base(message, inner) { }
        protected OsbAuthException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}