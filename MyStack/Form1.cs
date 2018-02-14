using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStack
{
    public partial class Form1 : Form
    {
        MyStack ThisStack;
        Palindrome myPalindrome;
        Maze myMaze;
        public Form1()
        {
            InitializeComponent();
            ThisStack = new MyStack();
            myPalindrome = new Palindrome();
            myMaze = new Maze();
            GenerateMaze();
            UpdateMaze();
        }

        private void UpdateMaze()
        {
            for (int c = 0; c < myMaze.maze.GetLength(0); c++)
            {
                for (int r = 0; r < myMaze.maze.GetLength(1); r++)
                {
                    UpdateCell(c, r);
                }
            }
        }

        private void UpdateCell(int c, int r)
        {
            switch (myMaze.maze[c, r])
            {
                case MazeType.Open:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.White;
                    break;
                case MazeType.Wall:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Gray;
                    break;
                case MazeType.Start:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Green;
                    break;
                case MazeType.Finish:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Red;
                    break;
                case MazeType.Attempted:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Pink;
                    break;
                default:
                    dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.White;
                    break;
            }
        }

        private void UpdatePathCell(int c, int r)
        {
            dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Cyan;
        }

        private void GenerateMaze()
        {
            dataGridView1.Rows.Add(10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNumberToStack((int)numericUpDown1.Value);
            ClearText();
            showStack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopNumber();
            showStack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TakeTop();
            showStack();
        }

        private void AddNumberToStack(int i)
        {
            try
            {
                ThisStack.Push(i);
            }
            catch (Exception)
            {
                MessageBox.Show("The stack is full.");
                textBox1.Text = "";
            }
        }

        private void PopNumber()
        {
            try
            {
                int i = ThisStack.Pop();
                textBox1.Text = i.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("The stack is empty.");
                textBox1.Text = "";
            }
        }

        private void TakeTop()
        {
            try
            {
                int i = ThisStack.Top();
                textBox1.Text = i.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("The stack is empty.");
                textBox1.Text = "";
            }
        }

        private void ClearText()
        {
            textBox1.Clear();
        }

        private void showStack()
        {
            IntStackArrayView.Items.Clear();
            for (int i = 0; i < ThisStack.Length; i++)
            {
                IntStackArrayView.Items.Add(ThisStack.GetItem(i));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PalindromeIN.Text = SpecialCharRemover.RemoveSpecialCharacters(PalindromeIN.Text);

            try
            {
                myPalindrome.FillPalindrome(PalindromeIN.Text.ToLower().Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("The string is too long. Max 20 chars.");
            }

            try
            {
                string palindromOUT = new string(myPalindrome.GetPalindrome());
                PalindromeOUT.Text = palindromOUT;
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error reading the String.");
            }

            if (PalindromeIN.Text == PalindromeOUT.Text)
            {
                PalindromeRESULT.Text = "Is a Palindrome!";
            }
            else
            {
                PalindromeRESULT.Text = "Is not a Palindrome.";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            myMaze.SetNext(e.ColumnIndex, e.RowIndex);
            UpdateCell(e.ColumnIndex, e.RowIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> Path = new List<string>();
            CalculatePath(ref Path);
            PrintPath(Path);
        }

        private void CalculatePath(ref List<string> Path)
        {
            if (IsMazeValid())
            {
                MyStack pathStack = new MyStack();

                // 0 Represents the Starting Point
                pathStack.Push(0);

                Paths path;
                bool finished = false;
                // TODO: Set From Form
                int[] Current = new int[2] { 1, 1 };

                // NEXT will get set in order of W, S, E, N if multiple paths are available
                int[] Next = new int[2];

                while (LookingForSolution(finished))
                {
                    // Resets NEXT during loop after each step is taken
                    Next[0] = -1;
                    Next[1] = -1;

                    //System.Threading.Thread.Sleep(50);
                    path = new Paths();
                    CheckAround(ref path, Current, ref Next, pathStack);
                    NEWTakeStep(Next, Current, ref pathStack);

                    #region old
                    //switch (path.NumberOf)
                    //{
                    //    case 0:
                    //        // No Paths
                    //        int NumberOfChoices = new int();
                    //        RewindPath(ref pathStack, ref NumberOfChoices);
                    //        TakeStepAfterNext(Next, Current, ref pathStack, NumberOfChoices);
                    //        break;
                    //    case 1:
                    //        // 1 Path
                    //        TakeNextStep(Next, Current, ref pathStack);
                    //        Current[0] = Next[0];
                    //        Current[1] = Next[1];
                    //        UpdatePathCell(Current[0], Current[1]);
                    //        break;
                    //    default:
                    //        // More than 1 Paths
                    //        pathStack.Push(-1);
                    //        TakeNextStep(Next, Current, ref pathStack);
                    //        Current[0] = Next[0];
                    //        Current[1] = Next[1];
                    //        UpdatePathCell(Current[0], Current[1]);
                    //        break;
                    //}

                    #endregion
                    CheckFinished(ref finished, Current);
                }
                for (int i = pathStack.Length; i > 0; i--)
                {
                    switch (pathStack.Pop())
                    {
                        case -1:
                            // Don't write that a decision was made
                            break;
                        case 0:
                            // Starting Location - Not Technically a Move
                            break;
                        case 1:
                            Path.Add("West");
                            break;
                        case 2:
                            Path.Add("South");
                            break;
                        case 3:
                            Path.Add("East");
                            break;
                        case 4:
                            Path.Add("North");
                            break;
                        default:
                            Path.Add("Error");
                            break;
                    }
                }
                Path.Reverse();
            }
            else
            {
                MessageBox.Show("The Maze isn't valid.");
            }
        }

        private void NEWTakeStep(int[] next, int[] Current, ref MyStack stack)
        {
            // Directions are based off of how NEXT is set during CHECK-AROUND method

            if (Current[0] > next[0] && Current[1] == next[1])
            {
                // Go West = 1
                stack.Push(1);
            }
            else if (Current[0] == next[0] && Current[1] < next[1])
            {
                // Go South = 2
                stack.Push(2);
            }
            else if (Current[0] < next[0] && Current[1] == next[1])
            {
                // Go East = 3
                stack.Push(3);
            }
            else if (Current[0] == next[0] && Current[1] > next[1])
            {
                // Go North = 4
                stack.Push(4);
            }
            else
            {
                RewindPath();
            }
        }

        private void RewindPath(ref MyStack stack, ref int NumberOfChoices)
        {
            int first;
            bool RewindingToChoice = true;
            while (RewindingToChoice)
            {
                first = stack.Pop();
                if (first == -1)
                {
                    bool CheckingHowManyChoices = true;
                    NumberOfChoices = 1;
                    int next;
                    while (CheckingHowManyChoices)
                    {
                        next = stack.Pop();
                        if (next == -1)
                            NumberOfChoices++;
                        else
                        {
                            CheckingHowManyChoices = false;
                            stack.Push(next);
                        }
                    }
                }
            }
        }

        private void CheckFinished(ref bool finished, int[] Current)
        {
            if (myMaze.maze[Current[0], Current[1]] == MazeType.Finish)
            {
                finished = true;
            }
        }

        private void CheckAround(ref Paths paths, int[] current, ref int[] Next, MyStack pathStack)
        {
            // TODO: Check if this works with triple or quadruple pathways

            // IF statements check if the spot is open AND if it is a previous location
            // Previous location directions are set in TAKE-NEXT-STEP method

            // Checks Top - 2 Is a South Direction
            if (myMaze.maze[current[0], current[1] - 1] != MazeType.Wall && pathStack.Top() != 2 && myMaze.maze[current[0], current[1] - 1] != MazeType.Attempted)
            {
                if (myMaze.maze[current[0], current[1] - 1] != MazeType.Start)
                {
                    paths.North = true;
                    Next[0] = current[0];
                    Next[1] = current[1] - 1;
                }
            }
            // Checks Right - 1 Is a West Direction
            if (myMaze.maze[current[0] + 1, current[1]] != MazeType.Wall && pathStack.Top() != 1 && myMaze.maze[current[0] + 1, current[1]] != MazeType.Attempted)
            {
                if (myMaze.maze[current[0] + 1, current[1]] != MazeType.Start)
                {
                    paths.East = true;
                    Next[0] = current[0] + 1;
                    Next[1] = current[1];
                }
            }
            // Checks Bottom - 4 Is a North Direction
            if (myMaze.maze[current[0], current[1] + 1] != MazeType.Wall && pathStack.Top() != 4 && myMaze.maze[current[0], current[1] + 1] != MazeType.Attempted)
            {
                if (myMaze.maze[current[0], current[1] + 1] != MazeType.Start)
                {
                    paths.South = true;
                    Next[0] = current[0];
                    Next[1] = current[1] + 1;
                }
            }
            // Checks Left - 3 Is a East Direction
            if (myMaze.maze[current[0] - 1, current[1]] != MazeType.Wall && pathStack.Top() != 3 && myMaze.maze[current[0] - 1, current[1]] != MazeType.Attempted)
            {
                if (myMaze.maze[current[0] - 1, current[1]] != MazeType.Start)
                {
                    paths.West = true;
                    Next[0] = current[0] - 1;
                    Next[1] = current[1];
                }
            }
        }

        private void TakeStepAfterNext(int[] Next, int[] Current, ref MyStack pathStack, int NumberOfChoices)
        {
            // Directions are based off of how NEXT is set during CHECK-AROUND method

            if (Current[0] > Next[0] && Current[1] == Next[1])
            {
                // Go West
                pathStack.Push(1);
            }
            else if (Current[0] == Next[0] && Current[1] < Next[1])
            {
                // Go South
                pathStack.Push(2);
            }
            else if (Current[0] < Next[0] && Current[1] == Next[1])
            {
                // Go East
                pathStack.Push(3);
            }
            else if (Current[0] == Next[0] && Current[1] > Next[1])
            {
                // Go North
                pathStack.Push(4);
            }
        }

        private void TakeNextStep(int[] Next, int[] Current, ref MyStack pathStack)
        {
            // Directions are based off of how NEXT is set during CHECK-AROUND method

            if (Current[0] > Next[0] && Current[1] == Next[1])
            {
                // Go West
                pathStack.Push(1);
            }
            else if (Current[0] == Next[0] && Current[1] < Next[1])
            {
                // Go South
                pathStack.Push(2);
            }
            else if (Current[0] < Next[0] && Current[1] == Next[1])
            {
                // Go East
                pathStack.Push(3);
            }
            else if (Current[0] == Next[0] && Current[1] > Next[1])
            {
                // Go North
                pathStack.Push(4);
            }
        }

        private bool LookingForSolution(bool finished)
        {
            if (finished)
                return false;
            else
                return true;
        }

        private bool IsMazeValid()
        {
            int starts = 0;
            int finishes = 0;
            foreach (MazeType cell in myMaze.maze)
            {
                if (cell == MazeType.Start)
                {
                    starts++;
                }
                else if (cell == MazeType.Finish)
                {
                    finishes++;
                }
            }

            if (starts != 1 || finishes != 1)
                return false;
            else
                return true;
        }

        private void PrintPath(List<string> Path)
        {
            listView1.Items.Clear();
            foreach (string step in Path)
            {
                listView1.Items.Add(step);
            }
            MessageBox.Show("Fin!");
            myMaze.ResetMaze();
            UpdateMaze();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.ClearSelection();
        }
    }
}
