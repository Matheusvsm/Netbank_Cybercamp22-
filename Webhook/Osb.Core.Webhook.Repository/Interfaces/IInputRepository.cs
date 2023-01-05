using Osb.Core.Webhook.Entity;

namespace Osb.Core.Webhook.Repository
{
    public interface IInputRepository
    {
        Input InsertInputLog(Input input, long userId);
    }
}