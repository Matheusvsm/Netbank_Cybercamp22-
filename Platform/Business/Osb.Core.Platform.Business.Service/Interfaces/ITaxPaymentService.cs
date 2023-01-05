using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface ITaxPaymentService
    {
        OperationResult SaveFGTSPayment(FGTSPaymentRequest fgtsPaymentRequest);
        void GenerateFGTSPayment(FGTSPayment fgtsPayment);
        void UpdateFGTSpayment(FGTSPayment FGTSPayment);
        IEnumerable<FGTSPayment> FindFGTSPaymentListByStatus(FGTSPaymentStatus Status);

        OperationResult SaveDARJPayment(DARJPaymentRequest darjPaymentRequest);
        void GenerateDARJPayment(DARJPayment DARJPayment);
        void UpdateDARJPayment(DARJPayment darjPayment);
        IEnumerable<DARJPayment> FindDARJPaymentByStatus(DARJPaymentStatus status);

        OperationResult SaveGAREPayment(GAREPaymentRequest garePaymentRequest);
        void GenerateGAREPayment(GAREPayment garePayment);
        void UpdateGAREPayment(GAREPayment garePayment);
        IEnumerable<GAREPayment> FindGAREPaymentListByStatus(GAREPaymentStatus status);
    }
}