using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class PixMapper : Mapper
    {
        public ExternalRequest Map(CreatePixKeyRequest createPIxKeyRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), createPIxKeyRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = createPIxKeyRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = createPIxKeyRequest.PixKey,
                    PixKeyType = createPIxKeyRequest.PixKeyType,
                    TaxNumber = createPIxKeyRequest.TaxId,
                    Bank = createPIxKeyRequest.Bank,
                    BankBranch = createPIxKeyRequest.BankBranch,
                    BankAccount = createPIxKeyRequest.BankAccount,
                    BankAccountDigit = createPIxKeyRequest.BankAccountDigit
                }
            };
        }

        public ExternalRequest Map(ResendPixKeyTokenRequest resendPixKeyTokenRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), resendPixKeyTokenRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = resendPixKeyTokenRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = resendPixKeyTokenRequest.PixKey,
                    PixKeyType = resendPixKeyTokenRequest.PixKeyType,
                    TaxNumber = resendPixKeyTokenRequest.TaxId
                }
            };
        }

        public ExternalRequest Map(GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), generateStaticPixQRCodeRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = generateStaticPixQRCodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PrincipalValue = generateStaticPixQRCodeRequest.PrincipalValue,
                    PixKey = generateStaticPixQRCodeRequest.PixKey,
                    TaxNumber = generateStaticPixQRCodeRequest.TaxNumber,
                    Address = generateStaticPixQRCodeRequest.Address,
                    Bank = generateStaticPixQRCodeRequest.Bank,
                    BankBranch = generateStaticPixQRCodeRequest.BankBranch,
                    BankAccount = generateStaticPixQRCodeRequest.BankAccount,
                    BankAccountDigit = generateStaticPixQRCodeRequest.BankAccountDigit,
                    AdditionalData = generateStaticPixQRCodeRequest.AdditionalData,
                    PixTransactionPurpose = generateStaticPixQRCodeRequest.PixTransactionPurpose,
                }
            };
        }

        public ExternalRequest Map(FindPixQRCodeRequest findPixQRCodeRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findPixQRCodeRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findPixQRCodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findPixQRCodeRequest.TaxId,
                    DocumentNumber = findPixQRCodeRequest.ExternalIdentifier
                }
            };
        }
        public ExternalRequest Map(ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), confirmPixKeyHoldRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = confirmPixKeyHoldRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = confirmPixKeyHoldRequest.PixKey,
                    TaxNumber = confirmPixKeyHoldRequest.TaxId,
                    PixKeyType = confirmPixKeyHoldRequest.PixKeyType,
                    ConfirmationCode = confirmPixKeyHoldRequest.ConfirmationCode
                }
            };
        }

        public ExternalRequest Map(CancelPixKeyRequest cancelPixKeyRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), cancelPixKeyRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = cancelPixKeyRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = cancelPixKeyRequest.PixKeyValue,
                    PixKeyType = cancelPixKeyRequest.PixKeyType,
                    TaxNumber = cancelPixKeyRequest.TaxId,
                    Bank = cancelPixKeyRequest.Bank,
                    BankBranch = cancelPixKeyRequest.BankBranch,
                    BankAccount = cancelPixKeyRequest.BankAccount,
                    BankAccountDigit = cancelPixKeyRequest.BankAccountDigit
                }
            };
        }

        public ExternalRequest Map(
            RefundPixInRequest refundPixInRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                refundPixInRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = refundPixInRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    ToName = refundPixInRequest.ToName,
                    ToTaxNumber = refundPixInRequest.ToTaxId,
                    ToBank = refundPixInRequest.ToBank,
                    ToBankBranch = refundPixInRequest.ToBankBranch,
                    ToBankAccount = refundPixInRequest.ToBankAccount,
                    ToBankAccountDigit = refundPixInRequest.ToBankAccountDigit,
                    TaxNumber = refundPixInRequest.TaxId,
                    Bank = refundPixInRequest.Bank,
                    BankBranch = refundPixInRequest.BankBranch,
                    BankAccount = refundPixInRequest.BankAccount,
                    BankAccountDigit = refundPixInRequest.BankAccountDigit,
                    RefundValue = refundPixInRequest.RefundValue,
                    CustomerMessage = refundPixInRequest.CustomerMessage,
                    DocumentNumber = refundPixInRequest.DocumentNumber,
                    Identifier = refundPixInRequest.Identifier,
                    Tags = refundPixInRequest.Tags
                }
            };
        }

        public ExternalRequest Map(
            FindInfosPixKeyRequest findInfosPixKeyRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findInfosPixKeyRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findInfosPixKeyRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = findInfosPixKeyRequest.PixKeyValue,
                    TaxNumber = findInfosPixKeyRequest.TaxId
                }
            };
        }

        public ExternalRequest Map(
          FindPixKeyListRequest findPIxKeyListRequest,
          CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findPIxKeyListRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findPIxKeyListRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = findPIxKeyListRequest.PixKey,
                    PixKeyType = findPIxKeyListRequest.PixKeyType,
                    TaxNumber = findPIxKeyListRequest.TaxId,
                    Bank = findPIxKeyListRequest.Bank,
                    BankBranch = findPIxKeyListRequest.BankBranch,
                    BankAccount = findPIxKeyListRequest.BankAccount,
                    BankAccountDigit = findPIxKeyListRequest.BankAccountDigit
                }
            };
        }

        public ExternalRequest Map(GeneratePixOutRequest generatePixOutRequest, CompanyAuthentication companyAuthentication)
        {

            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), generatePixOutRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = generatePixOutRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = generatePixOutRequest.TaxId,
                    Bank = generatePixOutRequest.Bank,
                    BankBranch = generatePixOutRequest.BankBranch,
                    BankAccount = generatePixOutRequest.BankAccount,
                    BankAccountDigit = generatePixOutRequest.BankAccountDigit,
                    ToTaxNumber = generatePixOutRequest.ToTaxId,
                    ToName = generatePixOutRequest.ToName,
                    ToBank = generatePixOutRequest.ToBank,
                    ToBankBranch = generatePixOutRequest.ToBankBranch,
                    ToBankAccount = generatePixOutRequest.ToBankAccount,
                    ToBankAccountDigit = generatePixOutRequest.ToBankAccountDigit,
                    AccountType = generatePixOutRequest.AccountType,
                    PixKey = generatePixOutRequest.PixKey,
                    PixKeyType = generatePixOutRequest.PixKeyType,
                    SearchProtocol = generatePixOutRequest.SearchProtocol,
                    Value = generatePixOutRequest.Value,
                    Identifier = generatePixOutRequest.Identifier,
                    PaymentDate = generatePixOutRequest.PaymentDate
                }
            };
        }

        public ExternalRequest Map(GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), generateDynamicPixQrCodeRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = generateDynamicPixQrCodeRequest.Method,
                    AccountId = generateDynamicPixQrCodeRequest.AccountId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PixKey = generateDynamicPixQrCodeRequest.PixKey,
                    TaxNumber = generateDynamicPixQrCodeRequest.TaxId,
                    PayerTaxNumber = generateDynamicPixQrCodeRequest.PayerTaxId,
                    PayerName = generateDynamicPixQrCodeRequest.PayerName,
                    PrincipalValue = generateDynamicPixQrCodeRequest.Value,
                    ExpirationDate = generateDynamicPixQrCodeRequest.ExpirationDate,
                    Bank = generateDynamicPixQrCodeRequest.Bank,
                    BankBranch = generateDynamicPixQrCodeRequest.BankBranch,
                    BankAccount = generateDynamicPixQrCodeRequest.BankAccount,
                    BankAccountDigit = generateDynamicPixQrCodeRequest.BankAccountDigit,
                    Address = generateDynamicPixQrCodeRequest.Address,
                    ChangeType = generateDynamicPixQrCodeRequest.ChangeType
                }
            };
        }

        public ExternalRequest Map(FindInfoPixQRCodeRequest findInfoPixQRCodeRequest, CompanyAuthentication companyAuthentication)
        {

            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findInfoPixQRCodeRequest.Headers);

            return new ExternalRequest
            {

                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findInfoPixQRCodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findInfoPixQRCodeRequest.TaxId,
                    Hash = findInfoPixQRCodeRequest.Hash


                }
            };
        }

        public ExternalRequest Map(ClaimPixKeyRequest claimPixKeyRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), claimPixKeyRequest.Headers);
            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = claimPixKeyRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = claimPixKeyRequest.TaxId,
                    PixKey = claimPixKeyRequest.PixKeyValue,
                    PixKeyType = claimPixKeyRequest.PixKeyType,
                    Bank = claimPixKeyRequest.Bank,
                    BankBranch = claimPixKeyRequest.BankBranch,
                    BankAccount = claimPixKeyRequest.BankAccount,
                    BankAccountDigit = claimPixKeyRequest.BankAccountDigit
                }
            };
        }
    }
}