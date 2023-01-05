using System.ComponentModel;

namespace Osb.Core.Platform.Common.Entity.Enums
{
    public enum DocumentType
    {
        [Description("RG Frente")]
        IdentityDocumentFront = 0,
        [Description("CPF")]
        TaxNumber = 1,
        [Description("Comprovante de Endereço")]
        ProofAddress = 2,
        [Description("CNH")]
        CNH = 3,
        [Description("CNPJ")]
        CNPJ = 4,
        [Description("Contrato Social")]
        Contract = 5,
        [Description("Procuração")]
        LetterOfAttorney = 6,
        [Description("RG Verso")]
        IdentityDocumentVerse = 7,
        [Description("Error")]
        DocumentError = 8       
    }
}