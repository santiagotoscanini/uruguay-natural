using System;

namespace Exceptions
{
    [Serializable]
    public class InvalidAttributeValuesException : Exception
    {
        public InvalidAttributeValuesException(string message) : base(message) { }
    }
}
