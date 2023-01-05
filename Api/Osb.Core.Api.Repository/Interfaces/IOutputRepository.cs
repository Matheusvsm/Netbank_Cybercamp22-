using Osb.Core.Api.Entity;
namespace Osb.Core.Api.Repository
{
    public interface IOutputRepository
    {
        void InsertOutputLog(Output output, long? userId);
    }
}