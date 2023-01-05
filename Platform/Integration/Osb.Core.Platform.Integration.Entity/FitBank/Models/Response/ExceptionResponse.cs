using System;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExceptionResponse
    {
        public string Success { get; set; }
        public bool Status { get { return Convert.ToBoolean(Success); } set { Status = value; } }
        public string Message { get; set; }
    }
}