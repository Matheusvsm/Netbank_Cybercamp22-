using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Util.Resources.FavoredExcMsg;

namespace Osb.Core.Platform.Business.Service
{
    public class FavoredService : IFavoredService
    {
        private readonly FavoredValidator _validator;
        private readonly FavoredMapper _mapper;
        private readonly IFavoredRepositoryFactory _favoredRepositoryFactory;

        public FavoredService(
            IFavoredRepositoryFactory favoredRepositoryFactory
        )
        {
            _favoredRepositoryFactory = favoredRepositoryFactory;
            _mapper = new FavoredMapper();
            _validator = new FavoredValidator();
        }

        public FindFavoredListResult FindFavoredListByAccountIdAndOperationType(FindFavoredListByAccountIdRequest findFavoredListByAccountIdRequest)
        {
            _validator.Validate(findFavoredListByAccountIdRequest);

            IFavoredRepository favoredRepository = _favoredRepositoryFactory.Create();
            IEnumerable<Favored> favoredList = favoredRepository.GetByAccountIdAndOperationType(findFavoredListByAccountIdRequest.AccountId, findFavoredListByAccountIdRequest.OperationType);

            FindFavoredListResult result = _mapper.Map(favoredList);

            return result;
        }

        public void Save(FavoredRequest favoredRequest)
        {
            _validator.Validate(favoredRequest);

            IFavoredRepository favoredRepository = _favoredRepositoryFactory.Create();

            Favored favoreds = favoredRepository.GetFavored(
                favoredRequest.AccountId,
                favoredRequest.TaxId,
                favoredRequest.Bank,
                favoredRequest.BankBranch,
                favoredRequest.BankAccount,
                favoredRequest.BankAccountDigit,
                favoredRequest.Type);

            if (favoreds == null)
            {
                Favored favored = Favored.Create(
                   favoredRequest.UserId,
                   favoredRequest.AccountId,
                   favoredRequest.TaxId,
                   favoredRequest.Name,
                   favoredRequest.Type,
                   favoredRequest.BankName,
                   favoredRequest.Bank,
                   favoredRequest.BankBranch,
                   favoredRequest.BankAccount,
                   favoredRequest.BankAccountDigit);

                favoredRepository.Save(favored);
            }
            else
                throw new OsbBusinessException(FavoredExcMsg.EXC0008);
        }

        public bool favoredExists(IEnumerable<Favored> favoreds)
        {
            ICollection<Favored> obj = favoreds as ICollection<Favored>;

            return Convert.ToBoolean(obj.Count);
        }
    }
}