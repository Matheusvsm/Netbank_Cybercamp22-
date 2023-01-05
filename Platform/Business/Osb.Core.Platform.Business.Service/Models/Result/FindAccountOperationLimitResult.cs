namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAccountOperationLimitResult
    {
        public string Message { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
    }
}