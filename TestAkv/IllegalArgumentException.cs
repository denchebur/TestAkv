using System;
using System.Collections.Generic;
using System.Text;

namespace TestAkv
{
    public class IllegalArgumentException : Exception
    {
        public char Character { get; }

        public IllegalArgumentException() { }
        public IllegalArgumentException(string message)
            :base(message)
        { }
        public IllegalArgumentException(string message, char ch)
            : base(message)
        {
            Character = ch;
        }

    }
}
