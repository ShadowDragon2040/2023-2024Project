using System;
using System.Net;
using System.Net.Http;

namespace AdatKarbantarto.Exceptions
{
    public class ProductionsExceptions : Exception
    {
        public string ErrorDetails { get; }
        public ProductionsExceptions() { }

        public ProductionsExceptions(string message) : base(message) { }

        public ProductionsExceptions(string message, Exception inner) : base(message, inner) { }

        protected ProductionsExceptions(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ProductionsExceptions(string message, string errorDetails, Exception innerException) : base(message, innerException)
        {
            ErrorDetails = errorDetails;
        }
    }
}
