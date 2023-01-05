using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.HashCodeExcMsg;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class HashCodeValidator
    {
        public void Validate(GenerateHashCodeRequest generateHashCodeRequest)
        {
            if (generateHashCodeRequest.AccountId == 0)
                throw new OsbBusinessException(string.Format(HashCodeExcMsg.EXC0001));

            if (string.IsNullOrEmpty(generateHashCodeRequest.Identifier))
                throw new OsbBusinessException(string.Format(HashCodeExcMsg.EXC0002));
        }

        public void Validate(ReadHashCodeRequest readHashCodeRequest)
        {
            if (string.IsNullOrEmpty(readHashCodeRequest.HashCode))
                throw new OsbBusinessException(string.Format(HashCodeExcMsg.EXC0003));
        }
    }
}