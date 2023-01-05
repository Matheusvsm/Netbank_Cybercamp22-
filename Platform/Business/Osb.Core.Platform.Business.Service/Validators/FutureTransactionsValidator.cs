using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Business.Util.Resources.FutureTransactionsExcMsg;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class FutureTransactionsValidator
    {
        public void Validate(FindFutureTransactionsListRequest request)
        {
            if (request.InitialDate == null)
                throw new OsbBusinessException(FutureTransactionsExcMsg.EXC0001);

            if (request.FinalDate == null)
                throw new OsbBusinessException(FutureTransactionsExcMsg.EXC0002);
        }

        // public void Validate(FindFuturePaymentsListRequest request)
        // {
        //     if (request.InitialDate == null)
        //         throw new OsbBusinessException(BusinessExcMsg.EXC0006);

        //     if (request.FinalDate == null)
        //         throw new OsbBusinessException(BusinessExcMsg.EXC0007);
        // }
    }
}