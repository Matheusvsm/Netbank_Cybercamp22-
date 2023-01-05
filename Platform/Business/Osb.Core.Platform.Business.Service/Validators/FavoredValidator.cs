using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.FavoredExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class FavoredValidator
    {
        public void Validate(FindFavoredListByAccountIdRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(FavoredExcMsg.EXC0001);

            if (request.UserId == 0)
                throw new OsbBusinessException(FavoredExcMsg.EXC0002);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(FavoredExcMsg.EXC0006);
        }

        public void Validate(FavoredRequest favoredRequest)
        {
            if (favoredRequest.AccountId == 0)
                throw new OsbBusinessException(FavoredExcMsg.EXC0001);

            if (string.IsNullOrEmpty(favoredRequest.TaxId))
                throw new OsbBusinessException(FavoredExcMsg.EXC0003);

            if (favoredRequest.TaxId.Length != 11 & favoredRequest.TaxId.Length != 14)
                throw new OsbBusinessException(FavoredExcMsg.EXC0004);

            if (string.IsNullOrEmpty(favoredRequest.Name))
                throw new OsbBusinessException(FavoredExcMsg.EXC0005);

            if (!Enum.IsDefined(typeof(OperationType), favoredRequest.Type))
                throw new OsbBusinessException(FavoredExcMsg.EXC0006);

            if (favoredRequest.UserId == 0)
                throw new OsbBusinessException(FavoredExcMsg.EXC0007);
        }
    }
}