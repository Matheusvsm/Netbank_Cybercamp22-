using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Entity.Models;
using System.Collections.Generic;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IProfileRepository
    {
        Profile Save(Profile profileEntity, TransactionScope transactionScope = null);
        Profile Update(long profileId, long userId, string name, TransactionScope transactionScope = null);
        public void Delete(long profileId, TransactionScope transactionScope = null);
        IEnumerable<Profile> GetProfileByUserAccountId(long userAccountId);
        public Profile GetProfileById(long profileId);
        public Profile GetUserAccountProfile(long userAccountId, string name);
        public Profile GetProfileByNameAndUserId(long userId, string name);
        public void InsertUserAccountProfile(long profileId, long userAccountId, long userId, TransactionScope transactionScope = null);
        public void InsertProfileActionFunction(long profileId, long actionFunctionId, long userId, TransactionScope transactionScope = null);
        public void UpdateProfileActionFunction(long profileId, long actionFunctionId, long userId, TransactionScope transactionScope = null);
        public void DeleteUserAccountProfile(long profileId, long userAccountId, TransactionScope transactionScope = null);
        public IEnumerable<ProfileActionFunction> GetProfileActionFunctionByProfileId(long profileId);
        public void DeleteProfileActionFunctionByProfileIdAndActionFunctionId(long profileId, long actionFunctionId, TransactionScope transactionScope = null);
        public ProfileActionFunction GetProfileActionFunctionByProfileIdAndActionFunctionId(long profileId, long actionFunctionId, TransactionScope transactionScope = null);
    }
}