using System.Net.Http;

namespace Phoebe.Exceptions;

public class Phoebe4xxException : PhoebeApiException
{
    public Phoebe4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
