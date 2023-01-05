using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserCredentialRepository
    {
        public UserCredential GetUserCredentialByUserId(long? userId);
        void Save(UserCredential userCredential, TransactionScope transactionScope = null);
        void Update(UserCredential userCredential, TransactionScope transactionScope = null);
    }
}