using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
  public class DynamicPixQrCode : BaseEntity
  {
    public long AccountId { get; set; }
    public long ExternalIdentifier { get; set; }
    public string QRCode { get; set; }
    public static DynamicPixQrCode Create(long accountId, long externalIdentifier)
    {
      return new DynamicPixQrCode
      {
        AccountId = accountId,
        ExternalIdentifier = externalIdentifier,
        QRCode = null
      };
    }
  }
}