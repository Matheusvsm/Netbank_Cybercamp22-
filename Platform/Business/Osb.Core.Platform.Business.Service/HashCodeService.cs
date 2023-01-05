using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Util.Resources.HashCodeExcMsg;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.Response;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Business.Service
{
    public class HashCodeService : IHashCodeService
    {
        private readonly HashCodeMapper _mapper;
        private readonly HashCodeValidator _validator;
        private readonly IHashCodeRepositoryFactory _hashCodeRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IHashCodeServiceFactory _hashCodeIntegrationServiceFactory;


        public HashCodeService(
            IHashCodeRepositoryFactory hashCodeRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IHashCodeServiceFactory hashCodeIntegrationServiceFactory
        )
        {
            _hashCodeRepositoryFactory = hashCodeRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _hashCodeIntegrationServiceFactory = hashCodeIntegrationServiceFactory;
            _mapper = new HashCodeMapper();
            _validator = new HashCodeValidator();
        }

        public GenerateHashCodeResult GenerateHashCode(GenerateHashCodeRequest generateHashCodeRequest)
        {
            _validator.Validate(generateHashCodeRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(generateHashCodeRequest.AccountId);
            if (account == null)
                throw new OsbBusinessException(string.Format(HashCodeExcMsg.EXC0004));

            IntegrationRequest.GenerateHashCodeRequest integrationRequest = _mapper.Map(account, generateHashCodeRequest);

            IntegrationService.IHashCodeService hashCodeIntegrationService = _hashCodeIntegrationServiceFactory.Create();
            IntegrationResponse.GenerateHashCodeResponse generateHashCodeResponse = hashCodeIntegrationService.GenerateHashCode(integrationRequest);

            HashCode hashCode = HashCode.Create(generateHashCodeResponse.HashCode, generateHashCodeRequest.UserId);

            IHashCodeRepository hashCodeRepository = _hashCodeRepositoryFactory.Create();
            hashCodeRepository.Save(hashCode);

            GenerateHashCodeResult result = _mapper.Map(generateHashCodeResponse);
            return result;
        }

        public ReadHashCodeResult ReadHashCode(ReadHashCodeRequest readHashCodeRequest)
        {
            _validator.Validate(readHashCodeRequest);

            IntegrationRequest.ReadHashCodeRequest integrationRequest = _mapper.Map(readHashCodeRequest);

            IntegrationService.IHashCodeService hashCodeIntegrationService = _hashCodeIntegrationServiceFactory.Create();
            IntegrationResponse.ReadHashCodeResponse readHashCodeResponse = hashCodeIntegrationService.ReadHashCode(integrationRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByTaxId(
                readHashCodeResponse.TaxId,
                readHashCodeResponse.Bank,
                readHashCodeResponse.BankBranch,
                readHashCodeResponse.BankAccount,
                readHashCodeResponse.BankAccountDigit);

            if (account == null)
                throw new OsbBusinessException(string.Format(HashCodeExcMsg.EXC0005));

            ReadHashCodeResult result = _mapper.Map(readHashCodeResponse, account);
            return result;
        }
    }
}