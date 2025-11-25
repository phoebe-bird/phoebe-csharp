using System.Net.Http;

namespace Phoebe.Exceptions;

public class Phoebe5xxException : PhoebeApiException
{
    public Phoebe5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
