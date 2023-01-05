using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.BoletoPaymentMsg;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class BoletoPaymentValidator
    {
        public void Validate(FindExpectedBoletoPaymentDateRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0001);

            if (!request.ActualDatePayment.HasValue)
                throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0002);

            if (string.IsNullOrEmpty(request.BarCode))
                throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0003);
        }

        public void Validate(FindBoletoInfoRequest request)
        {
            if (string.IsNullOrEmpty(request.NumericSequence))
                throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0003);
        }

        public void Validate(BoletoPaymentRequest boletoPaymentRequest)
        {
            if (boletoPaymentRequest.PaymentDate.Date < DateTime.Today)
                throw new OsbBusinessException(string.Format(BoletoPaymentExcMsg.EXC0004));

            if (!(Convert.ToInt32(boletoPaymentRequest.Barcode.Substring(0, 1)) < 9))
                throw new OsbBusinessException(string.Format(BoletoPaymentExcMsg.EXC0005));

            if (!(boletoPaymentRequest.Barcode.Length.Equals(44)))
                throw new OsbBusinessException(string.Format(BoletoPaymentExcMsg.EXC0006));
        }
    }
}