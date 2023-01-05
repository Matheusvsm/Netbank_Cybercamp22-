namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class ChangeAccountOperationLimitResult
    {
        public string Message { get; set; }
        public decimal PreviousMinLimit { get; set; }
        public decimal PreviousMaxLimit { get; set; }
        public decimal NewMinLimit { get; set; }
        public decimal NewMaxLimit { get; set; }
    }
}