using System;

namespace RotmgNetworkingLib
{
    public class RotmgNetworkingException : Exception
    {
        public RotmgNetworkingException() : base("unknown") { }

        public RotmgNetworkingException(string message) : base(message) { }
    }
}
