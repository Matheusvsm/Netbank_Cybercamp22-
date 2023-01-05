using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Save(User userEntity, TransactionScope transactionScope = null);
        void Save(UserInformation userInformation, TransactionScope transactionScope = null);
        User GetUserByLogin(string login);
        User GetById(long userId);
        UserInformation GetByUserId(long userId);
        void Update(User user, TransactionScope transactionScope = null);
        void Update(UserInformation userInformation);
        User GetUserByLoginAndCompanyId(string login, long companyId);
        User GetUserByTokenAccessAndCompanyId(string tokenAccess, long companyId);
        void Delete(User user, TransactionScope transactionScope = null);
        void DeleteUserInformation(UserInformation userInformation, TransactionScope transactionScope = null);
    }
}