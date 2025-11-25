using System;

namespace Phoebe.Exceptions;

public class PhoebeInvalidDataException : PhoebeException
{
    public PhoebeInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
