using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeRateLimitException : Phoebe4xxException
{
    public PhoebeRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
