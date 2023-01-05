using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class NewAccountAddressRepository : INewAccountAddressRepository
    {
        private readonly IDbContext<NewAccountAddress> _context;

        public NewAccountAddressRepository(IDbContext<NewAccountAddress> context)
        {
            this._context = context;
        }

        public void Save(NewAccountAddress newAccountAddress, TransactionScope transactionScope = null)
        {

            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountAddress.NewAccountId,
                ["paramAddressLine"] = newAccountAddress.AddressLine,
                ["paramAddressLine2"] = newAccountAddress.AddressLine2,
                ["paramZipCode"] = newAccountAddress.ZipCode,
                ["paramNeighborhood"] = newAccountAddress.Neighborhood,
                ["paramCityCode"] = newAccountAddress.CityCode,
                ["paramCityName"] = newAccountAddress.CityName,
                ["paramState"] = newAccountAddress.State,
                ["paramAddressType"] = newAccountAddress.AddressType,
                ["paramCountry"] = newAccountAddress.Country,
                ["paramComplement"] = newAccountAddress.Complement,
                ["paramUserId"] = newAccountAddress.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertNewAccountAddress", parameters, transactionScope);
        }

        public IEnumerable<NewAccountAddress> GetByNewAccountId(long newAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountId
            };

            IEnumerable<NewAccountAddress> newAccountAddressList = _context.ExecuteWithMultipleResults("GetNewAccountAddressByNewAccountId", parameters);

            return newAccountAddressList;
        }
    }
}