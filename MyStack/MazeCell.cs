using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class MazeCell
    {
        private int[] cellIndex;

        public int[] CellIndex
        {
            get { return cellIndex; }
            set { cellIndex = value; }
        }

        public int Row
        {
            get { return cellIndex[1]; }
            set { cellIndex[1] = value; }
        }

        public int Column
        {
            get { return cellIndex[0]; }
            set { cellIndex[0] = value; }
        }

        public MazeCell()
        {
            cellIndex = new int[2] { 1, 1 };
        }

        public MazeCell(int c, int r)
        {
            cellIndex = new int[2] { c, r };
        }

        public void MoveNorth()
        {
            cellIndex[1]--;
        }

        public void MoveSouth()
        {
            cellIndex[1]++;
        }

        public void MoveEast()
        {
            cellIndex[0]++;
        }

        public void MoveWest()
        {
            cellIndex[0]--;
        }
    }
}
