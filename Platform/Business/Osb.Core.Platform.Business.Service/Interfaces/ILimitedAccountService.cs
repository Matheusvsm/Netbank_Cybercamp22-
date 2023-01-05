using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ILimitedAccountService
    {
        void Save(LimitedAccountRequest limitedAccountRequest);
        void Update(LimitedAccount limitedAccount, TransactionScope transctionScope = null);
        void GenerateLimitedAccount(LimitedAccount limitedAccount);
        IEnumerable<LimitedAccount> FindLimitedAccountListByStatus(LimitedAccountStatus status);

    }
}