using JT809.Protocol.JT809Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT809.Protocol.JT809Exceptions
{
    public class JT809Exception:Exception
    {
        public JT809Exception(JT809ErrorCode errorCode) : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
        }

        public JT809Exception(JT809ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public JT809Exception(JT809ErrorCode errorCode, Exception ex) : base(ex.Message, ex)
        {
            ErrorCode = errorCode;
        }

        public JT809Exception(JT809ErrorCode errorCode, string message, Exception ex) : base(ex.Message, ex)
        {
            ErrorCode = errorCode;
        }

        public JT809ErrorCode ErrorCode { get;}
    }
}
