using System;

namespace Osb.Core.Platform.Integration.Common
{
    [System.Serializable]
    public class OsbIntegrationException : System.Exception
    {
        public OsbIntegrationException() { }
        public OsbIntegrationException(string message) : base(message) { }
        public OsbIntegrationException(string message, System.Exception inner) : base(message, inner) { }
        protected OsbIntegrationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) : base(info, context) { }
    }
}
