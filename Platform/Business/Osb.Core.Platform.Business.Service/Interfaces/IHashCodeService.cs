using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;


namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface  IHashCodeService
    {
        /// <summary>
        /// Salva um hash code no banco de dados.
        /// </summary>
        /// <param name="generateHashCodeRequest">Body da requisição</param>
        /// <returns>Confirmação da criação de um hash code bem-sucedida</returns>

        GenerateHashCodeResult GenerateHashCode(GenerateHashCodeRequest generateHashCodeRequest);

        /// <summary>
        /// Lê um hash code enviado pelo usuário.
        /// </summary>
        /// <param name="readHashCodeRequest">Body da requisição</param>
        /// <returns>Retorno dos dados associados ao hash code</returns>

        ReadHashCodeResult ReadHashCode(ReadHashCodeRequest readHashCodeRequest);
    }    
}