using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    static class SpecialCharRemover
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            // BORROWED FROM: https://stackoverflow.com/questions/1120198/most-efficient-way-to-remove-special-characters-from-string
            // User : Guffa
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }

                // ORIGINAL - didn't want '.' or '_' in my solution

                //if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                //{
                //    sb.Append(c);
                //}
            }
            return sb.ToString();
        }
    }
}
