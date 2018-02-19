using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyStack
    {
        int[] stackArray;
        int arrayLength;

        public int Length
        {
            get { return arrayLength; }
        }

        public int GetItem(int i)
        {
            return stackArray[i];
        }

        public MyStack()
        {
            stackArray = new int[100];
            arrayLength = 0;
        }

        public void Push(int p)
        {
            try
            {
                if (IsFull())
                {
                    throw new StackFullException("Full");
                }
                else
                {
                    stackArray[arrayLength] = p;
                    arrayLength++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Pop()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new StackEmptyException("Empty");
                }
                else
                {
                    int p = stackArray[arrayLength - 1];
                    stackArray[arrayLength - 1] = 0;
                    arrayLength--;
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Top()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new StackEmptyException("Empty");
                }
                else
                {
                    int TopINT = stackArray[arrayLength - 1];
                    return TopINT;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsEmpty()
        {
            if (arrayLength == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFull()
        {
            if (arrayLength == stackArray.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
