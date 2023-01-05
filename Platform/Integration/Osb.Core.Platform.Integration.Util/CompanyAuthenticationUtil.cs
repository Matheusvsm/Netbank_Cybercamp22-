using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Util
{
    public static class CompanyAuthenticationUtil
    {
        /// <summary>
        /// Retorna a CompanyAuthentication com a senha descriptografada
        /// </summary>
        /// <param name="accountId">Id da conta</param>
        /// <param name="companyAuthenticationRepositoryFactory">Factory de CompanyAuthenticationRepository</param>
        /// <param name="encryptionSecret">Chave secreta do AES</param>
        /// <param name="encryptionIV">Vetor de inicialização do AES</param>
        /// <returns></returns>
        public static CompanyAuthentication GetCompanyAuthenticationByAccountId(
            long accountId,
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            string encryptionSecret,
            string encryptionIV
        )
        {
            ICompanyAuthenticationRepository companyAuthenticationRepository = companyAuthenticationRepositoryFactory.Create();
            CompanyAuthentication companyAuthentication = companyAuthenticationRepository.GetCompanyAuthenticationByAccountId(accountId);
            companyAuthentication.Password = AesProvider.Decrypt(
                companyAuthentication.Password,
                companyAuthentication.Salt,
                encryptionSecret,
                encryptionIV
            );

            return companyAuthentication;
        }
        public static CompanyAuthentication GetCompanyAuthenticationByCompanyId(
            long companyId,
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            string encryptionSecret,
            string encryptionIV
        )
        {
            ICompanyAuthenticationRepository companyAuthenticationRepository = companyAuthenticationRepositoryFactory.Create();
            CompanyAuthentication companyAuthentication = companyAuthenticationRepository.GetCompanyAuthenticationByCompanyId(companyId);
            companyAuthentication.Password = AesProvider.Decrypt(
                companyAuthentication.Password,
                companyAuthentication.Salt,
                encryptionSecret,
                encryptionIV
            );

            return companyAuthentication;
        }
    }
}