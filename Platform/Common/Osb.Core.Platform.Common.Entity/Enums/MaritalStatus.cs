using System.ComponentModel;

namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum MaritalStatus
    {
        [Description("União Estável")]
        NotMarried = 0,
        [Description("Casado")]
        Married = 1,
        [Description("Divorciado")]
        Divorced = 2,
        [Description("Separado")]
        Separate = 3,
        [Description("Viúvo")]
        Widower = 4,
        [Description("Solteiro")]
        Single = 5,
        [Description("Outros")]
        Other = 6
    }
}