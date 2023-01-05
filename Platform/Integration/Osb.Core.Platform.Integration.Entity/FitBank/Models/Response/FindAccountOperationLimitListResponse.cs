using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindAccountOperationLimitListResponse : BaseResponse
    {
        public IEnumerable<AccountLimit> Limits { get; set; }

        public static FindAccountOperationLimitListResponse Create(IEnumerable<AccountLimit> Limits)
        {
            return new FindAccountOperationLimitListResponse
            {
                Limits = Limits
            };
        }

    }
}