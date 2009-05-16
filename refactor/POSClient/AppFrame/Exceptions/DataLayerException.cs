using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AppFrame.Exceptions
{
    public class DataLayerException : System.Exception
    {
        public DataLayerException()
        {
        }

        public DataLayerException(string message) : base(message)
        {
        }

        public DataLayerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
