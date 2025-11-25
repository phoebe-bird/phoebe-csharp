using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeForbiddenException : Phoebe4xxException
{
    public PhoebeForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
