using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ITopUpRepository
    {
        void Save(TopUp topUp, TransactionScope transactionScope = null);
        IEnumerable<TopUp> GetByStatus(TopUpStatus status);
        IEnumerable<TopUp> GetByStatusAndDate(TopUpStatus status, DateTime date);
        TopUp GetTopUpByExternalIdentifierAndProductkey(string productKey, long externalIdentifier);
        void Update(TopUp topUp);
        IEnumerable<TopUp> GetTopUpPeriodicList (long accountId, TopUpStatus topUpStatus);
    
    }
}