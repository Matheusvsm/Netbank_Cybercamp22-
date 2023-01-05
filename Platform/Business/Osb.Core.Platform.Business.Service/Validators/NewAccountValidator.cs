using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.NewAccountExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class NewAccountValidator
    {
        public void Validate(NewAccountRequest request)
        {
            if (string.IsNullOrEmpty(request.PersonName))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0001);

            if (string.IsNullOrEmpty(request.PhoneNumber))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0002);

            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0003);

            if (string.IsNullOrEmpty(request.Mail))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0004);

            if (request.BirthDate.Equals(default(DateTime)))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0005);

            if (string.IsNullOrEmpty(request.Nationality))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0006);

            if (string.IsNullOrEmpty(request.BirthCity))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0007);

            if (string.IsNullOrEmpty(request.BirthState))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0008);

            if (!Enum.IsDefined(typeof(Gender), request.Gender))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0009);

            if (!Enum.IsDefined(typeof(MaritalStatus), request.MaritalStatus))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0010);

            if (string.IsNullOrEmpty(request.IdentityDocument))
                throw new OsbBusinessException(NewAccountExcMsg.EXC0011);

            if (request.Addresses.Count == 0)
                throw new OsbBusinessException(NewAccountExcMsg.EXC0012);

            if (request.Documents.Count == 0)
                throw new OsbBusinessException(NewAccountExcMsg.EXC0013);

            if (request.TaxId.Length == 14)
            {
                if (!Enum.IsDefined(typeof(CompanyType), request.CompanyType))
                    throw new OsbBusinessException(NewAccountExcMsg.EXC0014);

                if (string.IsNullOrEmpty(request.CompanyActivity))
                    throw new OsbBusinessException(NewAccountExcMsg.EXC0015);

                if (request.ConstitutionDate.Equals(default(DateTime)))
                    throw new OsbBusinessException(NewAccountExcMsg.EXC0016);
            }
        }
    }
}