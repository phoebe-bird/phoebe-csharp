using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeUnexpectedStatusCodeException : PhoebeApiException
{
    public PhoebeUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
