using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.TaxPaymentExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Text.RegularExpressions;
using Osb.Core.Platform.Common.Util;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class TaxPaymentValidator
    {

        public void Validate(FGTSPaymentRequest fgtsPaymentRequest)
        {
            if (string.IsNullOrEmpty(fgtsPaymentRequest.TaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0001);

            if (String.IsNullOrEmpty(fgtsPaymentRequest.ContributorTaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0002);

            if (fgtsPaymentRequest.PrincipalValue <= decimal.Zero)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0003);

            if (string.IsNullOrEmpty(fgtsPaymentRequest.CodeRevenue))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0004);

            if ((string.IsNullOrEmpty(fgtsPaymentRequest.Barcode)) || (!Regex.IsMatch(fgtsPaymentRequest.Barcode, (@"^[0-9]+$"))) || (fgtsPaymentRequest.Barcode.Length != 44))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0005);

            if (fgtsPaymentRequest.SocialConnectivityCode <= 0)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0006);

            if (fgtsPaymentRequest.SocialConnectivityDigit <= 0)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0006);

            if ((fgtsPaymentRequest.PaymentDate.Equals(default(DateTime))))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0007);
        }

        public void Validate(DARJPaymentRequest darjPaymentRequest)
        {
            if (String.IsNullOrEmpty(darjPaymentRequest.TaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0001);

            if (String.IsNullOrEmpty(darjPaymentRequest.ContributorTaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0002);

            if ((darjPaymentRequest.ReferenceNumber.Length != 6) || (!Regex.IsMatch(darjPaymentRequest.ReferenceNumber, (@"^[0-9]+$"))))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0008);

            if (darjPaymentRequest.PrincipalValue <= decimal.Zero)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0003);

            if (darjPaymentRequest.TotalValue == decimal.Zero)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0009);

            if (darjPaymentRequest.DueDate.Equals(default(DateTime)))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0010);

            if ((darjPaymentRequest.PaymentDate.Equals(default(DateTime))) || (darjPaymentRequest.PaymentDate > Utility.AbsoluteEnd(darjPaymentRequest.DueDate)))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0007);

            if (String.IsNullOrEmpty(darjPaymentRequest.CodeRevenue))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0004);

            if (String.IsNullOrEmpty(darjPaymentRequest.StateRegistration) || (darjPaymentRequest.StateRegistration.Length > 8))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0011);
        }
        public void Validate(GAREPaymentRequest garePaymentRequest)
        {
            if (string.IsNullOrEmpty(garePaymentRequest.TaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0001);

            if (String.IsNullOrEmpty(garePaymentRequest.ContributorTaxId))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0002);

            if ((garePaymentRequest.ReferenceNumber.Length != 6) || (!Regex.IsMatch(garePaymentRequest.ReferenceNumber, (@"^[0-9]+$"))))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0008);

            if (garePaymentRequest.PrincipalValue <= decimal.Zero)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0003);

            if (garePaymentRequest.TotalValue == decimal.Zero)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0009);

            if (garePaymentRequest.DueDate.Equals(default(DateTime)))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0010);

            if ((garePaymentRequest.PaymentDate.Equals(default(DateTime))) || (garePaymentRequest.PaymentDate > Utility.AbsoluteEnd(garePaymentRequest.DueDate)))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0007);

            if (string.IsNullOrEmpty(garePaymentRequest.CodeRevenue))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0004);

            if (string.IsNullOrEmpty(garePaymentRequest.StateRegistration))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0011);

            if (!Enum.IsDefined(typeof(GAREType), garePaymentRequest.GAREType))
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0012);
        }
    }
}