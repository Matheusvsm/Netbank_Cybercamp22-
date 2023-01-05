using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.TagExcMsg;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class TagValidator
    {
        public void Validate(FindSuggestionTagListRequest request)
        {
            if (request.AccountId.Equals(default(long)))
                throw new OsbBusinessException(TagExcMsg.EXC0001);

            if (request.TagAmount <= 0)
                throw new OsbBusinessException(TagExcMsg.EXC0002);
        }
    }
}