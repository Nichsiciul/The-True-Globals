using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiClient
{
    public class UnexpectedClientException : Exception
    {
        public UnexpectedClientException(String message) : base(message)
        {
        }
        public UnexpectedClientException(String message, Exception cause) : base(message, cause)
        {
        }
    }
}
