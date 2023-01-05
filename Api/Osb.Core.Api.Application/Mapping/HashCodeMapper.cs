using System.Text.RegularExpressions;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class HashCodeMapper
    {
        public BusinessRequest.GenerateHashCodeRequest Map(GenerateHashCodeRequest generateHashCodeRequest)
        {
            return new BusinessRequest.GenerateHashCodeRequest
            {
                AccountId = (long)generateHashCodeRequest.AccountId,
                UserId = (long)generateHashCodeRequest.UserId,
                Identifier = generateHashCodeRequest.Identifier,
                Value = generateHashCodeRequest.Value
            };
        }

        public BusinessRequest.ReadHashCodeRequest Map(ReadHashCodeRequest readHashCodeRequest)
        {
            return new BusinessRequest.ReadHashCodeRequest
            {
                AccountId = (long)readHashCodeRequest.AccountId,
                UserId = (long)readHashCodeRequest.UserId,
                HashCode = readHashCodeRequest.HashCode
            };
        }
    }
}