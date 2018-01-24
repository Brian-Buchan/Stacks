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
            stackArray = new int[10];
            arrayLenth = 0;
        }

        public void Push(int p)
        {
            if (IsFull())
            {
                // Error : Stack Full
                
            }
            else
            {
                stackArray[arrayLenth] = p;
                arrayLenth++;
            }
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                // Error : Stack Empty
                return -1;
            }
            int p = stackArray[arrayLenth -1];
            arrayLenth--;
            return p;
        }

        public int Top()
        {
            if (IsEmpty())
            {
                // Error : Stack Empty
                return -1;
            }
            int TopINT = stackArray[arrayLenth -1];
            return TopINT;
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
            return false;
        }
    }
}
