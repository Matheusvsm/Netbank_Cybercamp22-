using System;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserCredentialLogRepository
    {
        void Save(string login, long? UserId);
    }
}
