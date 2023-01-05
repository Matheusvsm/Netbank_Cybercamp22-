using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbContext<User> _userContext;
        private IDbContext<UserInformation> _userInformationContext;

        public UserRepository
        (
            IDbContext<User> userContext,
            IDbContext<UserInformation> userInformationContext
        )
        {
            _userContext = userContext;
            _userInformationContext = userInformationContext;
        }

        public User Save(User userEntity, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = userEntity.Login,
                ["paramStatus"] = userEntity.Status,
                ["paramIsFirstAccess"] = userEntity.IsFirstAccess
            };

            User user = _userContext.ExecuteWithSingleResult("InsertUser", parameters, transactionScope);

            return user;
        }

        public User GetUserByLogin(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            User user = _userContext.ExecuteWithSingleResult("GetUserByLogin", parameters);

            return user;
        }

        public User GetById(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            User user = _userContext.ExecuteWithSingleResult("GetUserById", parameters);

            return user;
        }

        public void Update(User user, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = user.UserId,
                ["paramLogin"] = user.Login,
                ["paramStatus"] = user.Status,
                ["paramIsFirstAccess"] = user.IsFirstAccess,
                ["paramLoginAttempts"] = user.LoginAttempts,
                ["paramDeletionDate"] = user.DeletionDate,
                ["paramAcceptedTerms"] = user.AcceptedTerms,
            };

            _userContext.ExecuteWithNoResult("UpdateUser", parameters, transactionScope);
        }

        public void Save(UserInformation userInformation, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = userInformation.Name,
                ["paramMail"] = userInformation.Mail,
                ["paramPhoneNumber"] = userInformation.PhoneNumber,
                ["paramZipCode"] = userInformation.ZipCode,
                ["paramStreet"] = userInformation.Street,
                ["paramNumber"] = userInformation.Number,
                ["paramDistrict"] = userInformation.District,
                ["paramComplement"] = userInformation.Complement,
                ["paramReference"] = userInformation.Reference,
                ["paramCity"] = userInformation.City,
                ["paramState"] = userInformation.State,
                ["paramCountry"] = userInformation.Country,
                ["paramUserId"] = userInformation.UserId,
            };

            _userInformationContext.ExecuteWithNoResult("insertuserinformation", parameters, transactionScope);
        }

        public void Update(UserInformation userInformation)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userInformation.UserId,
                ["paramName"] = userInformation.Name,
                ["paramMail"] = userInformation.Mail,
                ["paramPhoneNumber"] = userInformation.PhoneNumber,
                ["paramZipCode"] = userInformation.ZipCode,
                ["paramStreet"] = userInformation.Street,
                ["paramNumber"] = userInformation.Number,
                ["paramDistrict"] = userInformation.District,
                ["paramComplement"] = userInformation.Complement,
                ["paramReference"] = userInformation.Reference,
                ["paramCity"] = userInformation.City,
                ["paramState"] = userInformation.State,
                ["paramCountry"] = userInformation.Country
            };

            _userInformationContext.ExecuteWithNoResult("updateuserinformation", parameters);
        }

        public void Delete(User user, TransactionScope transactionScope)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = user.UserId
            };
            _userContext.ExecuteWithNoResult("deleteuser", parameters, transactionScope);
        }
        public void DeleteUserInformation(UserInformation userInformation, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userInformation.UserId
            };
            _userContext.ExecuteWithNoResult("deleteuserinformation", parameters, transactionScope);
        }

        public UserInformation GetByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            UserInformation userInformation = _userInformationContext.ExecuteWithSingleResult("getuserinformationbyuserid", parameters);

            return userInformation;
        }

        public User GetUserByLoginAndCompanyId(string login, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login,
                ["paramCompanyId"] = companyId
            };

            User user = _userContext.ExecuteWithSingleResult("GetUserByLoginAndCompanyId", parameters);

            return user;
        }

        public User GetUserByTokenAccessAndCompanyId(string tokenAccess, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTokenAccess"] = tokenAccess,
                ["paramCompanyId"] = companyId
            };

            User user = _userContext.ExecuteWithSingleResult("GetUserByTokenAccessAndCompanyId", parameters);

            return user;
        }
    }
}