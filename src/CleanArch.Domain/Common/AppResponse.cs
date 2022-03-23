using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Common
{
    public class AppResponse
    {
        public bool IsSucceed { get; internal set; }
        public string Message { get; internal set; }
        public int StatusCode { get; internal set; }

        public AppResponse(bool isSucceed, string message, int statusCode)
        {
            IsSucceed = isSucceed;
            Message = message;
            StatusCode = statusCode;
        }
    }

    public class ErrorResponse : AppResponse
    {
        public ErrorResponse(string Message) : base(false, Message,400) { }
    }

    public class SuccessResponse : AppResponse
    {
        public SuccessResponse(string Message) : base(true, Message,200) { }
    }
}
