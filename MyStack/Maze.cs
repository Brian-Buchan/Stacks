using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Maze
    {
        public MazeType[,] maze;

        public Maze()
        {
            maze = new MazeType[10, 10];
            ResetMaze();
        }

        public void ResetMaze()
        {
            for (int c = 0; c < maze.GetLength(0); c++)
            {
                for (int r = 0; r < maze.GetLength(1); r++)
                {
                    maze[c, r] = MazeType.Open;
                }
            }
            AddOuterWalls();
            maze[1, 1] = MazeType.Start;
            maze[8, 8] = MazeType.Finish;
        }

        public void AddOuterWalls()
        {
            for (int i = 0; i < 10; i++)
            {
                maze[i, 0] = MazeType.Wall;
                maze[i, 9] = MazeType.Wall;
            }
            for (int i = 0; i < 10; i++)
            {
                maze[0, i] = MazeType.Wall;
                maze[9, i] = MazeType.Wall;
            }
        }

        public void SetNext(int column, int row)
        {
            switch (maze[column, row])
            {
                case MazeType.Open:
                    maze[column, row] = MazeType.Wall;
                    break;
                case MazeType.Wall:
                    maze[column, row] = MazeType.Start;
                    break;
                case MazeType.Start:
                    maze[column, row] = MazeType.Finish;
                    break;
                case MazeType.Finish:
                    maze[column, row] = MazeType.Open;
                    break;
                default:
                    maze[column, row] = MazeType.Open;
                    break;
            }
        }
    }

    enum MazeType { Open, Wall, Start, Finish, Attempted }
}
