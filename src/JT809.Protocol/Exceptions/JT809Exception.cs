using JT809.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.Exceptions
{
    public class JT809Exception:Exception
    {
        private readonly ErrorCode errorCode;

        public JT809Exception(ErrorCode errorCode) : base(errorCode.ToString())
        {
            this.errorCode = errorCode;
        }

        public JT809Exception(ErrorCode errorCode, string message) : base(message)
        {
            this.errorCode = errorCode;
        }


        public ErrorCode ErrorCode => errorCode;
    }
}
