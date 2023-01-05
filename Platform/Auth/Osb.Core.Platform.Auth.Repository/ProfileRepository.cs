using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private IDbContext<Profile> _profileContext;
        private IDbContext<ProfileActionFunction> _profileActionFunctionContext;


        public ProfileRepository
        (
            IDbContext<Profile> profileContext,
            IDbContext<ProfileActionFunction> profileActionFunctionContext

        )
        {
            _profileContext = profileContext;
            _profileActionFunctionContext = profileActionFunctionContext;
        }
        public Profile Save(Profile profileEntity, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = profileEntity.Name,
                ["paramUserId"] = profileEntity.CreationUserId
            };

            Profile profile = _profileContext.ExecuteWithSingleResult("insertprofile", parameters, transactionScope);
            return profile;
        }

        public void InsertUserAccountProfile(long profileId, long userAccountId, long userId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramUserAccountId"] = userAccountId,
                ["paramUserId"] = userId
            };

            _profileContext.ExecuteWithSingleResult("insertuseraccountprofile", parameters, transactionScope);
        }

        public void InsertProfileActionFunction(long profileId, long actionFunctionId, long userId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramActionFunctionId"] = actionFunctionId,
                ["paramUserId"] = userId
            };

            _profileContext.ExecuteWithSingleResult("insertprofileactionfunction", parameters, transactionScope);
        }

        public Profile GetUserAccountProfile(long userAccountId, string name)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = name,
                ["paramUserAccountId"] = userAccountId
            };

            Profile profile = _profileContext.ExecuteWithSingleResult("getuseraccountprofile", parameters);
            return profile;
        }

        public Profile Update(long profileId, long userId, string name, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramName"] = name,
                ["paramUserId"] = userId
            };

            Profile profile = _profileContext.ExecuteWithSingleResult("updateprofile", parameters, transactionScope);
            return profile;
        }

        public Profile GetProfileByNameAndUserId(long userId, string name)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = name,
                ["paramUserId"] = userId
            };

            Profile profile = _profileContext.ExecuteWithSingleResult("getprofilebynameanduserid", parameters);
            return profile;
        }

        public Profile GetProfileById(long profileId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId
            };

            Profile profile = _profileContext.ExecuteWithSingleResult("getprofilebyid", parameters);
            return profile;
        }

        public void UpdateProfileActionFunction(long profileId, long actionFunctionId, long userId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramActionFunctionId"] = actionFunctionId,
                ["paramUserId"] = userId
            };

            _profileContext.ExecuteWithSingleResult("updateprofileactionfunction", parameters, transactionScope);
        }

        public void Delete(long profileId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId
            };

            _profileContext.ExecuteWithNoResult("deleteprofile", parameters, transactionScope);
        }

        public IEnumerable<Profile> GetProfileByUserAccountId(long userAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserAccountId"] = userAccountId
            };

            IEnumerable<Profile> profile = _profileContext.ExecuteWithMultipleResults("getprofilebyuseraccountid", parameters);
            return profile;
        }

        public void DeleteUserAccountProfile(long profileId, long userAccountId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramUserAccountId"] = userAccountId
            };

            _profileContext.ExecuteWithNoResult("deleteuseraccountprofile", parameters, transactionScope);
        }

        public void DeleteProfileActionFunctionByProfileIdAndActionFunctionId(long profileId, long actionFunctionId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramActionFunctionId"] = actionFunctionId
            };

            _profileActionFunctionContext.ExecuteWithSingleResult("deleteprofileactionfunctionbyprofileidandactionfunctionid", parameters, transactionScope);
        }

        public IEnumerable<ProfileActionFunction> GetProfileActionFunctionByProfileId(long profileId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId
            };

            IEnumerable<ProfileActionFunction> profileActionFunction = _profileActionFunctionContext.ExecuteWithMultipleResults("getprofileactionfunctionbyprofileid", parameters);
            return profileActionFunction;
        }

        public ProfileActionFunction GetProfileActionFunctionByProfileIdAndActionFunctionId(long profileId, long actionFunctionId, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProfileId"] = profileId,
                ["paramActionFunctionId"] = actionFunctionId
            };

            ProfileActionFunction profileActionFunction = _profileActionFunctionContext.ExecuteWithSingleResult("getprofileactionfunctionbyprofileidandactionfunctionid", parameters, transactionScope);
            return profileActionFunction;
        }
    }
}