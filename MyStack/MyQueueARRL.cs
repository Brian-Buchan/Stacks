using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MyQueueARRL
    {
        ArrayList queueArray;

        public int Length
        {
            get { return queueArray.Count; }
        }

        public MyQueueARRL()
        {
            queueArray = new ArrayList();
        }

        public int GetItem(int i)
        {
            return (int)queueArray[i];
        }

        public int Dequeue()
        {
            int first = (int)queueArray[0];
            queueArray.RemoveAt(0);
            return first;
        }

        public void Enqueue(int x)
        {
            queueArray.Add(x);
        }
    }
}
