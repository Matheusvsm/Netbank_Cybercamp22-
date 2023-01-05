using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ICardService
    {
        FindCardListResult FindCardList(FindCardListRequest findCardListRequest);
        FindCardResult FindCard(FindCardRequest findCardListRequest);
        bool VerifyCard(VerifyCardRequest verifyCardRequest);
        CardResult Activate(ActivateCardRequest activateCardRequest);
        CardResult Block(BlockCardRequest blockCardRequest);
        CardResult Unblock(UnblockCardRequest unblockCardRequest);
        CardResult ChangePin(ChangePinCardRequest changePinCardRequest);
        CardResult BindUnnamedCard(BindCardRequest bindCardRequest);
        CardResult InactivateAndReissue(InactivateAndReissueCardRequest inactivateAndReissueCardRequest);
        CardResult Cancel(CancelCardRequest cancelCardRequest);
    }
}