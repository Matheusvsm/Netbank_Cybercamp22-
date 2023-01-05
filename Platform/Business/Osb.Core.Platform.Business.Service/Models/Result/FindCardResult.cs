namespace Osb.Core.Platform.Business.Service.Models.Result
{
  public class FindCardResult
  {
    public string CardHolderName { get; set; }
    public string CardHolderTaxId { get; set; }
    public string CardOwnerName { get; set; }
    public string CardOwnerTaxId { get; set; }
    public long Type { get; set; }
    public long Status { get; set; }
    public string PanLastDigits { get; set; }
    public string ExpirationDate { get; set; }
    public string UnlockedDate { get; set; }
    public string LastBlockedDate { get; set; }
    public bool IsBlocked { get; set; }
  }
}