using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ExceptionLog : BaseEntity
    {
        public long ExceptionLogId { get; set; }
        public string Message { get; set; }
        public ExceptionType ExceptionType { get; set; }

        public static ExceptionLog Create(string message, ExceptionType exceptionType, long userId)
        {
            return new ExceptionLog
            {
                Message = message,
                ExceptionType = exceptionType,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}