namespace MagicHamster.GrocerySamurai.PresentationLayer.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    [Serializable]
    public class TooManyRecordsFoundException : Exception
    {
        public TooManyRecordsFoundException()
        {
        }

        [UsedImplicitly]
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