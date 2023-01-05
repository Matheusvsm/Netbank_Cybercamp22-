using Osb.Core.Api.Entity;
namespace Osb.Core.Api.Repository
{
    public interface IInputRepository
    {
        Input InsertInputLog(Input input, long? userId);
    }
}