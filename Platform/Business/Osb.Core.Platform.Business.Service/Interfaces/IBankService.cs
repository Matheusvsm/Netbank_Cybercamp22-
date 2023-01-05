using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IBankService
    {
        /// <summary>
        /// Busca lista de bancos.
        /// </summary>
        /// <param name="FindBanksRequest">Body da requisição</param>
        /// <returns>Lisa de bancos</returns>

        FindBanksResult FindBanks(FindBanksRequest findBanksRequest);

    }
}