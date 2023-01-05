using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IMoneyTransferService
    {
        OperationResult Save(MoneyTransferRequest moneyTransferRequest);
        FindExpectedTransferDateResult FindExpectedTransferDate(FindExpectedTransferDateRequest findExpectedTransferDateRequest);
        IEnumerable<MoneyTransfer> FindMoneyTransferListByStatus(MoneyTransferStatus status);
        void GenerateMoneyTransfer(MoneyTransfer moneyTransfer);
        void Update(MoneyTransfer moneyTransfer);
        void UpdateStatus(UpdateMoneyTransferRequest updateMoneyTransferRequest);
        void NotificationMoneyTransferIn(NotificationMoneyTransferInRequest notificationMoneyTransferInRequest);
    }
}