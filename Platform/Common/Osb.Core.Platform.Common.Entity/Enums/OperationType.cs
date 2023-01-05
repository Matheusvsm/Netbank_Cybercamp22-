namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum OperationType
    {
        BoletoPurchase = 0,
        BoletoPayment = 2,
        MoneyTransfer = 3,
        MoneyTransferIn = 4,
        InternalTransfer = 6,
        GAREPayment = 8,
        FGTSPayment = 11,
        DARJPayment = 12,
        PendingInternalTransfer = 13,
        BlockCard = 20,
        BindCard = 21,
        ChangePinCard = 22,
        InactivateAndReissueCard = 23,
        CancelCard = 24,
        ActivateCard = 36,
        PurchaseTopUp = 37,
        PixOut = 40,
        PixIn = 41,
        RefundPixIn = 42
    }
}