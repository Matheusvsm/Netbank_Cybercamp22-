using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.LimitedAccountExcMsg;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class LimitedAccountValidator
    {
        public void Validate(LimitedAccountRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new OsbBusinessException(LimitedAccountExcMsg.EXC0001);

            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(LimitedAccountExcMsg.EXC0002);

            if (request.BankAccountDigit != null && request.BankAccountDigit.Length > 2)
                throw new OsbBusinessException(LimitedAccountExcMsg.EXC0003);

            if (request.BirthDate.Equals(default(DateTime)))
                throw new OsbBusinessException(LimitedAccountExcMsg.EXC0004);

            if (request.TaxId.Length == 14)
            {
                if (string.IsNullOrEmpty(request.TradingName))
                    throw new OsbBusinessException(LimitedAccountExcMsg.EXC0005);

                if (string.IsNullOrEmpty(request.LegalName))
                    throw new OsbBusinessException(LimitedAccountExcMsg.EXC0006);

                if (request.ConstitutionDate.Equals(default(DateTime)))
                    throw new OsbBusinessException(LimitedAccountExcMsg.EXC0007);

                if (request.Persons.Count == 0)
                    throw new OsbBusinessException(LimitedAccountExcMsg.EXC0008);
            }
        }
    }
}