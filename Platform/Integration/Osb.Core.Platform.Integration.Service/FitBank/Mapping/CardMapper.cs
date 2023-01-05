using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class CardMapper : Mapper
    {
        public ExternalRequest Map(
            FindCardRequest findCardRequest,
            CompanyAuthentication companyAuthentication
        )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = findCardRequest.IdentifierCard,
                }
            };
        }

        public ExternalRequest Map(
            FindCardListRequest findCardListRequest,
            CompanyAuthentication companyAuthentication
        )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findCardListRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findCardListRequest.Method,
                    TaxNumber = findCardListRequest.TaxId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                }
            };
        }

        public ExternalRequest Map(
           ActivateCardRequest activateCardRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                activateCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = activateCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = activateCardRequest.IdentifierCard,
                }
            };
        }

        public ExternalRequest Map(
            InactivateAndReissueCardRequest cardRequest,
            CompanyAuthentication companyAuthentication
        )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                cardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = cardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = cardRequest.IdentifierCard,
                    Pin = cardRequest.Pin,
                    ReasonCode = cardRequest.ReasonCode,
                    CardDeliveryAddress = new { 
                        Line = cardRequest.CardDeliveryAddress.Street,
                        Number = cardRequest.CardDeliveryAddress.Number,
                        Complement = cardRequest.CardDeliveryAddress.Complement,
                        Reference = cardRequest.CardDeliveryAddress.Reference,
                        Neighborhood = cardRequest.CardDeliveryAddress.District,
                        ZipCode = cardRequest.CardDeliveryAddress.ZipCode,
                        City = cardRequest.CardDeliveryAddress.City,
                        State = cardRequest.CardDeliveryAddress.State, 
                        Country = cardRequest.CardDeliveryAddress.Country
                    }
                }
            };
        }

        public ExternalRequest Map(
           CancelCardRequest cancelCardRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                cancelCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = cancelCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = cancelCardRequest.IdentifierCard,
                }
            };
        }

        public ExternalRequest Map(
            BlockCardRequest blockCardRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                blockCardRequest.Headers
            );
            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = blockCardRequest.Method,
                    IdentifierCard = blockCardRequest.IdentifierCard,
                    Pin = blockCardRequest.Pin,
                    ReasonCode = blockCardRequest.ReasonCode,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                }
            };
        }

        public ExternalRequest Map(
               BindUnnamedCardRequest bindUnnamedCardRequest,
               CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                bindUnnamedCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = bindUnnamedCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    CardOwner = bindUnnamedCardRequest.CardOwner,
                    CardHolder = bindUnnamedCardRequest.CardHolder,
                    CardHolderContact = bindUnnamedCardRequest.CardHolderContact,
                    IdentifierCard = bindUnnamedCardRequest.IdentifierCard,
                    UsageType = bindUnnamedCardRequest.UsageType,
                }
            };
        }

        public ExternalRequest Map(ChangePinCardRequest changePinCardRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                changePinCardRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = changePinCardRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    IdentifierCard = changePinCardRequest.IdentifierCard,
                    Pin = changePinCardRequest.Pin,
                    CurrentPin = changePinCardRequest.CurrentPin,
                    PinCheck = changePinCardRequest.PinCheck,
                }
            };
        }

        public ExternalRequest Map(
           UnblockCardRequest unblockCardRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                unblockCardRequest.Headers
            );
            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = unblockCardRequest.Method,
                    IdentifierCard = unblockCardRequest.IdentifierCard,
                    Pin = unblockCardRequest.Pin,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId
                }
            };
        }
    }
}