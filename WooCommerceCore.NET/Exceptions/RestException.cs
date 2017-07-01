using System;

namespace WooCommerceCore.NET.Exceptions
{
    public sealed class RestException : Exception
    {
        public string Code { get; }
        public string Operation { get; }

        public RestException(string message, string code, string operation) : base($"{operation} - {code}\r\n{message}")
        {
            Code = code;
            Operation = operation;
        }
    }
}
