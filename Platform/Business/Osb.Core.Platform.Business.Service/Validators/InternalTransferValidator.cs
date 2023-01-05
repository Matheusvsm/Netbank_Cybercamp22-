using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.InternalTransferMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class InternalTransferValidator
    {
        public void Validate(InternalTransferRequest internalTransferRequest)
        {
            if (internalTransferRequest.TransferDate.Date < DateTime.Today)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0001);
        }

        public void Validate(PreCancelInternalTransferRequest precancelInternalTransferRequest)
        {
            if (precancelInternalTransferRequest.ExternalIdentifier == 0)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0002);

            if (precancelInternalTransferRequest.UserId == 0)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0003);

            if (precancelInternalTransferRequest.AccountId == 0)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0004);
        }

        public void Validate(UpdateInternalTransferRequest updateInternalTransferRequest)
        {
            if (!Enum.IsDefined<InternalTransferStatus>(updateInternalTransferRequest.Status))
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0005);

            if (updateInternalTransferRequest.InternalTransferId == null && updateInternalTransferRequest.ExternalIdentifier == null)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0006);
        }

        public void Validate(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {
            if (string.IsNullOrEmpty(findPendingInternalTransferRequest.VerificationCode) && string.IsNullOrEmpty(findPendingInternalTransferRequest.PhoneNumber))
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0007);
        }

        public void Validate(PendingInternalTransferRequest pendingInternalTransferRequest)
        {
            if (string.IsNullOrEmpty(pendingInternalTransferRequest.PhoneNumber))
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0008);

            if (pendingInternalTransferRequest.Value <= 0)
                throw new OsbBusinessException(InternalTransferExcMsg.EXC0009);
        }
    }
}