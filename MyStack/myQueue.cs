using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class myQueue
    {
        int[] queueArray;
        int arrayLength;

        public int Length
        {
            get { return arrayLength; }
        }

        public myQueue()
        {
            queueArray = new int[100];
            arrayLength = 0;
        }

        public int GetItem(int i)
        {
            return queueArray[i];
        }

        public bool isEmpty()
        {
            if (arrayLength == 0)
                return true;
            else
                return false;
        }

        public bool isFull()
        {
            if (queueArray.Length == arrayLength)
                return true;
            else
                return false;
        }

        public int Dequeue()
        {
            try
            {
                if (isEmpty())
                    throw new StackEmptyException("Empty");
                else
                {
                    int first = queueArray[0];
                    for (int i = 1; i < arrayLength; i++)
                    {
                        queueArray[i - 1] = queueArray[i];
                    }
                    arrayLength--;
                    return first;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Enqueue(int x)
        {
            try
            {
                if (isFull())
                    throw new StackFullException("Full");
                else
                {
                    queueArray[arrayLength] = x;
                    arrayLength++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
