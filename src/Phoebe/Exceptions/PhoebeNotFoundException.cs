using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeNotFoundException : Phoebe4xxException
{
    public PhoebeNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
