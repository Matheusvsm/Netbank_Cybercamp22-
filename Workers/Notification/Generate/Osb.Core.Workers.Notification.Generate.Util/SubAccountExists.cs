namespace Osb.Core.Workers.Notification.Generate.Util
{
    public class SubAccountExists
    {
        public static bool ValidateSubAccount(string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            bool subAccountExists = (bank != null && bankBranch != null && bankAccount != null && bankAccountDigit != null);

            return subAccountExists;
        }
    }
}
