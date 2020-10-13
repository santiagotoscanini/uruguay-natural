using System;

namespace Exceptions
{
    [Serializable]
    public class ObjectAlreadyExistException : Exception
    {
        public ObjectAlreadyExistException(string message) : base(message) { }
    }
}
