using System;

namespace SimpleORM.Exceptions
{
    [Serializable]
    public class ConnectionException : Exception
    {
        public string ErrorCode { get; }
        public ConnectionException()
        {

        }

        public ConnectionException(string errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
            
        }
    }
}
