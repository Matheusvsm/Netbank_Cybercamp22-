using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IBoletoPaymentService
    {
        BoletoPaymentResponse GenerateBoletoPayment(BoletoPaymentRequest boletoPaymentRequest);
        VerifyBoletoCanBePaidResponse VerifyBoletoCanBePaid(VerifyBoletoCanBePaidRequest verifyBoletoCanBePaidRequest);
        FindInfosPaymentCIPByBarcodeResponse FindInfosPaymentCIPByBarcode(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest);
        FindInfosPaymentByBarcodeReponse FindInfosPaymentByBarcode(FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest);
        FindExpectedBoletoPaymentDateResponse FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest);
    }
}