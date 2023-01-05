using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.AccountExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class AccountValidator
    {
        public void Validate(FindAccountDashboardRequest request)
        {
            if (string.IsNullOrEmpty(request.Login))
                throw new OsbBusinessException(AccountExcMsg.EXC0001);
        }

        public void Validate(FindAccountBalanceRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);

            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);
        }

        public void Validate(FindBankStatementRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);

            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (request.StartDate == null)
                throw new OsbBusinessException(AccountExcMsg.EXC0004);

            if (request.EndDate == null)
                throw new OsbBusinessException(AccountExcMsg.EXC0005);
        }

        public void Validate(FindBankStatementDetailsRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(AccountExcMsg.EXC0006);
        }
        public void Validate(FindAccountOperationRequest request)
        {
            if (request.OperationId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0001);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(AccountExcMsg.EXC0006);
        }

        public void Validate(AccountRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);

            if (string.IsNullOrEmpty(request.Name))
                throw new OsbBusinessException(AccountExcMsg.EXC0007);

            if (request.Type == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0008);

            if (request.Status == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0009);
        }

        public void Validate(FindAccountListByLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Login))
                throw new OsbBusinessException(AccountExcMsg.EXC0001);
        }

        public void Validate(long userId)
        {
            if (userId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0010);
        }

        public void Validate(FindBankStatementMonthlySummaryRequest request)
        {
            if (request.DateMonthly == null)
                throw new OsbBusinessException(AccountExcMsg.EXC0012);
        }

        public void Validate(FindAccountListByTaxIdRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);
        }

        public void Validate(AccountWebhookRequest request)
        {
            if (String.IsNullOrEmpty(request.AccountKey))
                throw new OsbBusinessException(AccountExcMsg.EXC0011);
        }

        public void Validate(ChangeAccountOperationLimitRequest request)
        {
            if (request.UserId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0016);

            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0017);

            if (request.CompanyId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0018);

            if (request.OperationType < 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0006);

            if (request.AccountOperationLimitType < 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0019);

            if (request.AccountOperationLimitSubType < 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0020);

            if (request.MinLimitValue < 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0021);

            if (request.MaxLimitValue < 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0022);

        }

        public void Validate(FindAccountOperationLimitRequest request)
        {
            if (request.UserId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0010);

            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(AccountExcMsg.EXC0006);

            if (!Enum.IsDefined(typeof(AccountOperationLimitType), request.AccountOperationLimitType))
                throw new OsbBusinessException(AccountExcMsg.EXC0019);

            if (!Enum.IsDefined(typeof(AccountOperationLimitSubType), request.AccountOperationLimitSubType))
                throw new OsbBusinessException(AccountExcMsg.EXC0020);

        }

        public void Validate(FindAccountOperationLimitListRequest request)
        {
            if (request.UserId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0010);

            if (request.AccountId == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(AccountExcMsg.EXC0002);
        }
    }
}