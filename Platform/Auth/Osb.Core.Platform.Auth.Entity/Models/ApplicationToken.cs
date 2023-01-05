using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class ApplicationToken : BaseEntity
    {
        public long ApplicationTokenId;
        public string Token;
        public string Nonce;
    }
}