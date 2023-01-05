using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface INewAccountService
    {
        void Save(NewAccountRequest NewAccountRequest);
        void GenerateNewAccount(NewAccount newAccount);
        void Update(NewAccount newAccount);
        IEnumerable<NewAccount> FindNewAccountByStatus(NewAccountStatus status);
    }
}