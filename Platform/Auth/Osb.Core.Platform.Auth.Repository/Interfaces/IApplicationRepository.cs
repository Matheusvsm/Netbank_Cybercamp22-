using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IApplicationRepository
    {
        /// <summary>
        /// Busca uma Application a partir de uma Key
        /// </summary>
        /// <param name="key">Key da application</param>
        /// <returns>Instância de Application</returns>
        Application GetApplicationByKey(string key, TransactionScope transactionScope = null);
    }
}