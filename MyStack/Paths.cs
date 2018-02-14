using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Paths
    {
        public int NumberOf;
        public bool North { set { if (value == true) NumberOf++; } }
        public bool East { set { if (value == true) NumberOf++; } }
        public bool South { set { if (value == true) NumberOf++; } }
        public bool West { set { if (value == true) NumberOf++; } }

        public Paths()
        {
            NumberOf = 0;
            North = false;
            East = false;
            South = false;
            West = false;
        }
    }
}
