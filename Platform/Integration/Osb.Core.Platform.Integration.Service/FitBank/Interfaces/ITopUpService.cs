using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface ITopUpService
    {
        FindTopUpProductListResponse FindTopUpProductList(FindTopUpProductListRequest findTopUpProductsRequest);
        TopUpAuthorizeResponse TopUpAuthorize(TopUpAuthorizeRequest topUpAuthorizeRequest);
        GenerateTopUpResponse GenerateTopUp(GenerateTopUpRequest integrationRequest);
        FindTopUpProductListByPhoneNumberResponse FindTopUpProductListByPhoneNumber(FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest);
    }
}
