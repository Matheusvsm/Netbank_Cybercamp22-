using Osb.Core.Webhook.Entity;

namespace Osb.Core.Webhook.Repository
{
    public interface IOutputRepository
    {
        void InsertOutputLog(Output response, long? userId);
    }
}