using Osb.Core.Platform.Common.Entity;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ITaxPaymentRepository
    {
        void Save(FGTSPayment fgtsPayment, TransactionScope transactionScope = null);
        void Update(FGTSPayment fgtsPayment);
        IEnumerable<FGTSPayment> GetListByStatus(FGTSPaymentStatus status);
        
        void Save(DARJPayment darjPayment, TransactionScope transactionScope = null);
        IEnumerable<DARJPayment> GetDARJPaymentListByStatus(DARJPaymentStatus darjPaymentStatus);
        void Update(DARJPayment darjPayment);

        void Save(GAREPayment garePayment, TransactionScope transactionScope = null);
        void Update(GAREPayment garePayment);
        IEnumerable<GAREPayment> GetListByStatus(GAREPaymentStatus status);
    }
}