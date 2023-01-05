using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IProfileService
    {
        Profile Save(ProfileRequest profileRequest);
        Profile Update(ProfileUpdateRequest profileUpdateRequest);
        void Delete(ProfileDeleteRequest profileDeleteRequest);
        FindProfileListResult FindProfileList(FindProfileListRequest findProfileListRequest);
    }
}