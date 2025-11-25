using System;
using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeIOException : PhoebeException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public PhoebeIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
