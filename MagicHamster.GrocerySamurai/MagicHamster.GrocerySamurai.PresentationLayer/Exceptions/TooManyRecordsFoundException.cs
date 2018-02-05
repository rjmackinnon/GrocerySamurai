namespace MagicHamster.GrocerySamurai.PresentationLayer.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TooManyRecordsFoundException : Exception
    {
        public TooManyRecordsFoundException()
        {
        }

        public TooManyRecordsFoundException(string message)
            : base(message)
        {
        }

        public TooManyRecordsFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TooManyRecordsFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}