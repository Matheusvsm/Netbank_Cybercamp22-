using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface ICardService
    {
        FindCardResponse FindCard(FindCardRequest findtCardRequest);
        FindCardListResponse FindCardList(FindCardListRequest findCardListRequest);
        ActivateCardResponse Activate(ActivateCardRequest activateCardRequest);
        BlockCardResponse Block(BlockCardRequest blockCardRequest);
        UnblockCardResponse Unblock(UnblockCardRequest unblockRequest);
        ChangePinCardResponse ChangePin(ChangePinCardRequest changePinCardRequest);
        InactivateAndReissueCardResponse InactivateAndReissueCard(InactivateAndReissueCardRequest inactivateAndReissueCardRequest);
        BindUnnamedCardResponse BindUnnamedCard(BindUnnamedCardRequest bindUnnamedCardRequest);
        CancelCardResponse CancelCard(CancelCardRequest cancelCardRequest);
    }
}