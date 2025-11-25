using System.Net.Http;

namespace Phoebe.Exceptions;

public class PhoebeUnprocessableEntityException : Phoebe4xxException
{
    public PhoebeUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
