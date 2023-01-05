using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class NewAccountPersonRepository : INewAccountPersonRepository
    {
        private readonly IDbContext<NewAccountPerson> _context;

        public NewAccountPersonRepository(IDbContext<NewAccountPerson> context)
        {
            this._context = context;
        }

        public NewAccountPerson Save(NewAccountPerson newAccountPerson, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountPerson.NewAccountId,
                ["paramTaxId"] = newAccountPerson.TaxId,
                ["paramName"] = newAccountPerson.Name,
                ["paramMail"] = newAccountPerson.Mail,
                ["paramOccupation"] = newAccountPerson.Occupation,
                ["paramPhone"] = newAccountPerson.Phone,
                ["paramPersonRoleType"] = newAccountPerson.PersonRoleType,
                ["paramMotherFullName"] = newAccountPerson.MotherFullName,
                ["paramFatherFullName"] = newAccountPerson.FatherFullName,
                ["paramNationality"] = newAccountPerson.Nationality,
                ["paramBirthCity"] = newAccountPerson.BirthCity,
                ["paramBirthState"] = newAccountPerson.BirthState,
                ["paramGender"] = newAccountPerson.Gender,
                ["paramMaritalStatus"] = newAccountPerson.MaritalStatus,
                ["paramSpouseName"] = newAccountPerson.SpouseName,
                ["paramIdentityDocument"] = newAccountPerson.IdentityDocument,
                ["paramCompanyType"] = newAccountPerson.CompanyType,
                ["paramCompanyActivity"] = newAccountPerson.CompanyActivity,
                ["paramConstitutionDate"] = newAccountPerson.ConstitutionDate,
                ["paramCheckPendingTransfers"] = newAccountPerson.CheckPendingTransfers,
                ["paramBirthDate"] = newAccountPerson.BirthDate,
                ["paramPersonName"] = newAccountPerson.PersonName,
                ["paramPhoneNumber"] = newAccountPerson.PhoneNumber,
                ["paramNickname"] = newAccountPerson.Nickname,
                ["paramPubliclyExposedPerson"] = newAccountPerson.PubliclyExposedPerson,
                ["paramUserId"] = newAccountPerson.CreationUserId
            };

            NewAccountPerson bankingDataResult = _context.ExecuteWithSingleResult("InsertNewAccountPerson", parameters, transactionScope);
            return bankingDataResult;
        }

        public IEnumerable<NewAccountPerson> GetByNewAccountId(long newAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountId
            };

            IEnumerable<NewAccountPerson> newAccountPersonList = _context.ExecuteWithMultipleResults("GetNewAccountPersonByNewAccountId", parameters);

            return newAccountPersonList;
        }
    }
}