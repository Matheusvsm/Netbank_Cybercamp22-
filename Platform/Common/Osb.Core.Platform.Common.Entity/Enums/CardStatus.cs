namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum CardStatus
    {
        Created = 0,
        Requested = 1,
        Generated = 2,
        Bound = 3,
        Active = 4,
        ErrorBinding = 5,
        ErrorRequested = 6,
        Inactive = 7,
        Binding = 8,
        PreError = 9,
        PreCreated = 10,
        Canceled = 11,
        AwaitingKYC = 12,
        CancellationError = 13
    }
}