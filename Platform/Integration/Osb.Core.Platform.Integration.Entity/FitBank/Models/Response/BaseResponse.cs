using System;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class BaseResponse
    {
        public string Success { get; set; }
        public bool ResponseStatus { get { return Convert.ToBoolean(Success); } set { ResponseStatus = value; } }
        public string Message { get; set; }
    }
}