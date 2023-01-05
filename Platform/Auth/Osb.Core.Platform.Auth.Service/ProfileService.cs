using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Util.Resources.AuthExcMsg;
using System;
using System.Linq;
using System.Collections.Generic;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepositoryFactory _profileRepositoryFactory;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IUserAccountRepositoryFactory _userAccountRepositoryFactory;
        private readonly IActionFunctionRepositoryFactory _actionfunctionRepositoryFactory;
        private readonly ProfileMapper _mapper;

        public ProfileService(
            IProfileRepositoryFactory profileRepositoryFactory,
            IConnectionFactory connectionFactory,
            IUserAccountRepositoryFactory userAccountRepositoryFactory,
            IActionFunctionRepositoryFactory actionfunctionRepositoryFactory
        )
        {
            _profileRepositoryFactory = profileRepositoryFactory;
            _connectionFactory = connectionFactory;
            _userAccountRepositoryFactory = userAccountRepositoryFactory;
            _actionfunctionRepositoryFactory = actionfunctionRepositoryFactory;
            _mapper = new ProfileMapper();
        }

        public Profile Save(ProfileRequest profileRequest)
        {
            List<ActionFunction> actionFunctionList = new List<ActionFunction>();

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                if (String.IsNullOrEmpty(profileRequest.Name))
                    throw new OsbAuthException(AuthExcMsg.EXC0012);

                IProfileRepository profileRepository = _profileRepositoryFactory.Create();
                Profile profile = profileRepository.GetProfileByNameAndUserId(profileRequest.UserId, profileRequest.Name);

                if (profile != null)
                    throw new OsbAuthException(AuthExcMsg.EXC0014);

                profile = Profile.Create(profileRequest.UserId, profileRequest.Name);
                profile = profileRepository.Save(profile, transactionScope);

                IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();
                UserAccount userAccount = userAccountRepository.GetUserAccountByUserIdAndAccountId(profileRequest.UserId, profileRequest.AccountId);

                if (userAccount == null)
                    throw new OsbAuthException(AuthExcMsg.EXC0015);

                Profile profileValidate = profileRepository.GetUserAccountProfile(userAccount.UserAccountId, profileRequest.Name);

                if (profileValidate != null)
                    throw new OsbAuthException(AuthExcMsg.EXC0014);

                profileRepository.InsertUserAccountProfile(profile.ProfileId, userAccount.UserAccountId, profileRequest.UserId, transactionScope);

                var actionFunctionListDistinct = profileRequest.ActionFunctions.Distinct();

                if (actionFunctionListDistinct != null)
                {
                    IActionFunctionRepository actionFunctionRepository = _actionfunctionRepositoryFactory.Create();
                    foreach (long actionFunctionId in actionFunctionListDistinct)
                    {
                        ActionFunction actionFunction = actionFunctionRepository.GetActionFunctionById(actionFunctionId);

                        if (actionFunction == null)
                            throw new OsbAuthException(AuthExcMsg.EXC0013);

                        actionFunctionList.Add(actionFunction);
                    }

                    foreach (ActionFunction actionFunction in actionFunctionList)
                    {
                        profileRepository.InsertProfileActionFunction(profile.ProfileId, actionFunction.ActionFunctionId, profileRequest.UserId, transactionScope);
                    }
                }
                transactionScope.Transaction.Commit();
                return profile;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public Profile Update(ProfileUpdateRequest profileUpdateRequest)
        {
            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                if (String.IsNullOrEmpty(profileUpdateRequest.Name))
                    throw new OsbAuthException(AuthExcMsg.EXC0012);

                IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();
                UserAccount userAccount = userAccountRepository.GetUserAccountByUserIdAndAccountId(profileUpdateRequest.UserId, profileUpdateRequest.AccountId);

                if (userAccount == null)
                    throw new OsbAuthException(AuthExcMsg.EXC0015);

                IProfileRepository profileRepository = _profileRepositoryFactory.Create();
                Profile profile = profileRepository.GetProfileById(profileUpdateRequest.ProfileId);

                if (profile == null)
                    throw new OsbAuthException(AuthExcMsg.EXC0016);

                profile = profileRepository.Update(profile.ProfileId, profileUpdateRequest.UserId, profileUpdateRequest.Name, transactionScope);

                IProfileRepository profileActionFunctionRepository = _profileRepositoryFactory.Create();
                IEnumerable<ProfileActionFunction> profileActionFunction = profileActionFunctionRepository.GetProfileActionFunctionByProfileId(profileUpdateRequest.ProfileId);

                List<long> insertProfileActionFunctionList = new List<long>();
                List<long> deleteProfileActionFunctionList = new List<long>();
                List<long> profileActionFunctionIdList = new List<long>();

                if (profileUpdateRequest.ActionFunctions == null)
                    profileUpdateRequest.ActionFunctions = new List<long>();

                if (profileUpdateRequest.ActionFunctions.Contains(0))
                    throw new OsbAuthException(AuthExcMsg.EXC0017);

                foreach (ProfileActionFunction profileActionFunctionId in profileActionFunction)
                {
                    profileActionFunctionIdList.Add(profileActionFunctionId.ActionFunctionId);
                }

                IActionFunctionRepository actionFunctionRepository = _actionfunctionRepositoryFactory.Create();

                foreach (long actionFunctionId in profileUpdateRequest.ActionFunctions)
                {
                    ActionFunction actionFunction = actionFunctionRepository.GetActionFunctionById(actionFunctionId);

                    if (actionFunction == null)
                        throw new OsbAuthException(AuthExcMsg.EXC0013);

                    if (profileActionFunctionIdList.Contains(actionFunctionId) == false || profileActionFunctionIdList.Contains(actionFunctionId) == true)
                    {
                        if (insertProfileActionFunctionList.Contains(actionFunctionId) == false)
                        {
                            insertProfileActionFunctionList.Add(actionFunctionId);
                        }
                    }
                }

                foreach (long actionFunctionId in profileActionFunctionIdList)
                {
                    if (insertProfileActionFunctionList.Contains(actionFunctionId) == false)
                        deleteProfileActionFunctionList.Add(actionFunctionId);
                }

                foreach (long actionFunctionId in insertProfileActionFunctionList)
                {
                    ProfileActionFunction validate = profileActionFunctionRepository.GetProfileActionFunctionByProfileIdAndActionFunctionId(profileUpdateRequest.ProfileId, actionFunctionId, transactionScope);

                    if (validate == null)
                        profileRepository.InsertProfileActionFunction(profileUpdateRequest.ProfileId, actionFunctionId, profileUpdateRequest.UserId, transactionScope);
                }
                foreach (long actionFunctionId in deleteProfileActionFunctionList)
                {
                    profileActionFunctionRepository.DeleteProfileActionFunctionByProfileIdAndActionFunctionId(profileUpdateRequest.ProfileId, actionFunctionId, transactionScope);
                }
                transactionScope.Transaction.Commit();
                return profile;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public void Delete(ProfileDeleteRequest profileDeleteRequest)
        {
            TransactionScope transactionScope = _connectionFactory.CreateTransaction();
            try
            {
                IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();
                UserAccount userAccount = userAccountRepository.GetUserAccountByUserIdAndAccountId(profileDeleteRequest.UserId, profileDeleteRequest.AccountId);

                IProfileRepository profileRepository = _profileRepositoryFactory.Create();
                IEnumerable<Profile> profile = profileRepository.GetProfileByUserAccountId(userAccount.UserAccountId);

                Profile profileDelete = null;
                foreach (Profile profiles in profile)
                {
                    if (profiles.ProfileId == profileDeleteRequest.ProfileId)
                        profileDelete = profiles;
                }

                if (profileDelete == null)
                    throw new OsbAuthException(AuthExcMsg.EXC0016);

                IProfileRepository profileActionFunctionRepository = _profileRepositoryFactory.Create();
                IEnumerable<ProfileActionFunction> profileActionFunction = profileActionFunctionRepository.GetProfileActionFunctionByProfileId(profileDeleteRequest.ProfileId);
                if (profileActionFunction != null)
                {
                    foreach (ProfileActionFunction inProfileActionFunction in profileActionFunction)
                    {
                        profileActionFunctionRepository.DeleteProfileActionFunctionByProfileIdAndActionFunctionId(profileDeleteRequest.ProfileId, inProfileActionFunction.ActionFunctionId, transactionScope);
                    }
                }

                profileRepository.DeleteUserAccountProfile(profileDeleteRequest.ProfileId, userAccount.UserAccountId);
                profileRepository.Delete(profileDeleteRequest.ProfileId, transactionScope);

                transactionScope.Transaction.Commit();
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public FindProfileListResult FindProfileList(FindProfileListRequest findProfileListRequest)
        {
            TransactionScope transactionScope = _connectionFactory.CreateTransaction();
            try
            {
                IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();
                UserAccount userAccount = userAccountRepository.GetUserAccountByUserIdAndAccountId(findProfileListRequest.UserId, findProfileListRequest.AccountId);

                IProfileRepository profileRepository = _profileRepositoryFactory.Create();
                IEnumerable<Profile> profileList = profileRepository.GetProfileByUserAccountId(userAccount.UserAccountId);

                if (profileList == null)
                    throw new OsbAuthException(AuthExcMsg.EXC0016);

                FindProfileListResult result = _mapper.Map(profileList);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
