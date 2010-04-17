using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AppFrame.Exceptions
{
    public class PresentationException : System.Exception
    {
        public PresentationException()
        {
        }

        public PresentationException(string message) : base(message)
        {
        }

        public PresentationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected PresentationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
