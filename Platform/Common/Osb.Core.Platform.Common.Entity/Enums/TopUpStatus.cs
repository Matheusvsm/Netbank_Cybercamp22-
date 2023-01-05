namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum TopUpStatus
    {
        Created = 0,
        Generated = 1,
        CanBeRegister = 2,
        Authorized = 3,
        Error = 4,
        Registering = 5,
        Registered = 6,
        WaitingFee = 7,
        PreSettled = 8,
        Settlement = 9,
        PreCanceled = 10,
        Canceled = 11,
        ErrorBalance = 12,
        ErrorProcessing = 13,
        ToBeCanceled = 14
    }
}