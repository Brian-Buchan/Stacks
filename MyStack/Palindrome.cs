using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Palindrome
    {
        char[] stackArray;
        int arrayLenth;

        public int Length
        {
            get { return arrayLenth; }
        }

        public int GetItem(int i)
        {
            return stackArray[i];
        }

        public Palindrome()
        {
            stackArray = new char[20];
            arrayLenth = 0;
        }

        public void Clear()
        {
            for (int i = 0; i < stackArray.Length; i++)
            {
                stackArray[i] = ' ';
            }
            arrayLenth = 0;
        }

        public void Push(char c)
        {
            try
            {
                if (IsFull())
                {
                    throw new StackFullException("Full");
                }
                else
                {
                    stackArray[arrayLenth] = c;
                    arrayLenth++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public char Pop()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new StackEmptyException("Empty");
                }
                else
                {
                    char c = stackArray[arrayLenth - 1];
                    arrayLenth--;
                    return c;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FillPalindrome(string s)
        {
            Clear();
            char[] c = s.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                try
                {
                    Push(c[i]);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public char[] GetPalindrome()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new StackEmptyException("Empty");
                }
                else
                {
                    char[] c = new char[arrayLenth];
                    // THIS LINE MESSED ME UP FOR A WHILE BECAUSE POP() REDUCES THE PARAMETER ARRAYLENGTH WHICH WAS BEING CHECKED AGAINST I
                    // NEEDED TO BE CHECKED AGAINST 0 AND I NOT CHECKED AT ALL
                    for (int i = 0; arrayLenth > 0; i++)
                    {
                        c[i] = Pop();
                    }
                    return c;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public char Top()
        {
            try
            {
                if (IsEmpty())
                {
                    throw new StackEmptyException("Empty");
                }
                else
                {
                    char c = stackArray[arrayLenth - 1];
                    return c;
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
