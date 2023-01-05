using System.ComponentModel;

namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum Gender
    {
        [Description("Masculino")]
        Male = 0,
        [Description("Feminino")]
        Female = 1,
        [Description("Outros")]
        Other = 2
    }
}