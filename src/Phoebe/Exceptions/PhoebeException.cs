using System;
using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeException : Exception
{
    public PhoebeException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected PhoebeException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
