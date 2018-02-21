using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyStackARRL
    {
        ArrayList stackArray;

        public int Length
        {
            get { return stackArray.Count; }
        }

        public int GetItem(int i)
        {
            return (int)stackArray[i];
        }

        public MyStackARRL()
        {
            stackArray = new ArrayList();
        }

        public void Push(int p)
        {
            stackArray.Insert(stackArray.Count, p);
        }

        public int Pop()
        {
            int p = (int)stackArray[stackArray.Count - 1];
            stackArray.RemoveAt(stackArray.Count - 1);
            return p;
        }

        public int Top()
        {
            int TopINT = (int)stackArray[stackArray.Count - 1];
            return TopINT;
        }
    }
}
