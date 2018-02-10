namespace MagicHamster.GrocerySamurai.PresentationLayer.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    [Serializable]
    [UsedImplicitly]
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