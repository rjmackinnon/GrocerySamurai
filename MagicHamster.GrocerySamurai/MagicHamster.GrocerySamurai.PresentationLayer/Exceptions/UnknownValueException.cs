namespace MagicHamster.GrocerySamurai.PresentationLayer.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnknownValueException : Exception
    {
        public UnknownValueException()
        {
        }

        public UnknownValueException(string message)
            : base(message)
        {
        }

        public UnknownValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}