using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeUnauthorizedException : Phoebe4xxException
{
    public PhoebeUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
