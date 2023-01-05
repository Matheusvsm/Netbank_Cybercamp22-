using Osb.Core.Platform.Auth.Service.Models.Request;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;
using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Api.Application.Mapping
{
    public class ProfileMapper
    {
        public AuthRequest.ProfileRequest Map(ProfileRequest profileRequest)
        {
            return new AuthRequest.ProfileRequest
            {
                Name = profileRequest.Name,
                UserId = profileRequest.UserId,
                AccountId = profileRequest.AccountId,
                ActionFunctions = profileRequest.ActionFunctions
            };
        }
        public AuthRequest.ProfileUpdateRequest Map(ProfileUpdateRequest profileUpdateRequest)
        {
            return new AuthRequest.ProfileUpdateRequest
            {
                ProfileId = profileUpdateRequest.ProfileId,
                Name = profileUpdateRequest.Name,
                UserId = profileUpdateRequest.UserId,
                AccountId = profileUpdateRequest.AccountId,
                ActionFunctions = profileUpdateRequest.ActionFunctions
            };
        }
        public AuthRequest.ProfileDeleteRequest Map(ProfileDeleteRequest profileDeleteRequest)
        {
            return new AuthRequest.ProfileDeleteRequest
            {
                ProfileId = profileDeleteRequest.ProfileId,
                UserId = profileDeleteRequest.UserId,
                AccountId = profileDeleteRequest.AccountId
            };
        }
        public AuthRequest.FindProfileListRequest Map(FindProfileListRequest findProfileListRequest)
        {
            return new AuthRequest.FindProfileListRequest
            {
                UserId = findProfileListRequest.UserId,
                AccountId = findProfileListRequest.AccountId
            };
        }

        public FindProfileListResult Map(IEnumerable<Profile> profileList)
        {
            return new FindProfileListResult
            {
                ProfileList = profileList
            };
        }
    }
}