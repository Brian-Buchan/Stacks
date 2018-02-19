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
        int arrayLenth;

        public int Length
        {
            get { return arrayLenth; }
        }

        public int GetItem(int i)
        {
            return stackArray[i];
        }

        public MyStack()
        {
            stackArray = new int[100];
            arrayLenth = 0;
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
                    stackArray[arrayLenth] = p;
                    arrayLenth++;
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
                    int p = stackArray[arrayLenth - 1];
                    stackArray[arrayLenth - 1] = 0;
                    arrayLenth--;
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
                    int TopINT = stackArray[arrayLenth - 1];
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
            if (arrayLenth == 0)
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
            if (arrayLenth == stackArray.Length)
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
