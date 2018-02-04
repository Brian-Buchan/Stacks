using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class StackFullException : Exception
    {
        public StackFullException()
        {

        }

        public StackFullException(string message) : base(message)
        {

        }

        public StackFullException(string message, Exception inner) : base(message)
        {

        }
    }

    class StackEmptyException : Exception
    {
        public StackEmptyException()
        {

        }

        public StackEmptyException(string message) : base(message)
        {

        }

        public StackEmptyException(string message, Exception inner) : base(message)
        {

        }
    }
}
