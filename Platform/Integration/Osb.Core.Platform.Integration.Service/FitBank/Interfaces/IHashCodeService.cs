using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IHashCodeService
    {
        GenerateHashCodeResponse GenerateHashCode(GenerateHashCodeRequest generateHashCodeRequest);
        ReadHashCodeResponse ReadHashCode(ReadHashCodeRequest readHashCodeRequest);
    }
}