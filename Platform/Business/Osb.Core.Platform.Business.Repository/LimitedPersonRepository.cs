using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class LimitedPersonRepository : ILimitedPersonRepository
    {
        private readonly IDbContext<LimitedPerson> _context;

        public LimitedPersonRepository(IDbContext<LimitedPerson> context)
        {
            this._context = context;
        }

        public LimitedPerson Save(LimitedPerson limitedPerson, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimitedAccountId"] = limitedPerson.LimitedAccountId,
                ["paramName"] = limitedPerson.Name,
                ["paramTaxNumber"] = limitedPerson.TaxNumber,
                ["paramMail"] = limitedPerson.Mail,
                ["paramPhone"] = limitedPerson.Phone,
                ["paramPersonRoleType"] = limitedPerson.PersonRoleType,
                ["paramBirthDate"] = limitedPerson.BirthDate,
                ["paramUserId"] = limitedPerson.CreationUserId
            };

            LimitedPerson bankingResult = _context.ExecuteWithSingleResult("InsertLimitedPerson", parameters, transactionScope);

            return bankingResult;
        }

        public IEnumerable<LimitedPerson> GetByLimitedAccountId(long limitedAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimitedAccountId"] = limitedAccountId
            };

            IEnumerable<LimitedPerson> limitedPersons = _context.ExecuteWithMultipleResults("GetLimitedPersonByLimitedAccountId", parameters);

            return limitedPersons;

        }
    }
}