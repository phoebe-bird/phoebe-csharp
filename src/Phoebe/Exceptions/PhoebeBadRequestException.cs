using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeBadRequestException : Phoebe4xxException
{
    public PhoebeBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
