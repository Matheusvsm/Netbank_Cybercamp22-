using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IBoletoPaymentService
    {
        OperationResult Save(BoletoPaymentRequest boletoPaymentRequest);
        FindBoletoInfoResult FindBoletoInfo(FindBoletoInfoRequest findBoletoInfoRequest);
        void GenerateBoletoPayment(BoletoPayment boletoPayment);
        void UpdateBoletoPayment(BoletoPayment boletoPayment);
        void UpdateBoletoPaymentStatus(UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest);
        IEnumerable<BoletoPayment> FindBoletoPaymentListByStatus(BoletoPaymentStatus status);
        FindExpectedBoletoPaymentDateResult FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest);
        FindScanLicenseKeyResult FindScanLicenseKey(FindScanLicenseKeyRequest findScanLicenseKeyRequest);
    }
}