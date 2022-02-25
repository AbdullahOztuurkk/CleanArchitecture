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

        public AppResponse(bool isSucceed, string message)
        {
            IsSucceed = isSucceed;
            Message = message;
        }
    }
    
    public class ErrorResponse : AppResponse
    {
        public ErrorResponse(string Message) : base(false, Message) { }
    }

    public class SuccessResponse : AppResponse
    {
        public SuccessResponse(string Message) : base(true, Message) { }
    }
}
