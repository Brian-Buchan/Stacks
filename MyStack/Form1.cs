using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MyStack
{
    public partial class Form1 : Form
    {
        MyStack ThisStack;
        myQueue ThisQueue;
        MyQueueARRL ThisQueueArrL;
        MyStack ReverseStack;
        MyStackARRL ReverseStackArrL;
        Palindrome myPalindrome;
        Maze myMaze;
        Stopwatch Stopwatch;
        bool ArrayListChecked;

        public Form1()
        {
            InitializeComponent();
            ThisStack = new MyStack();
            ThisQueue = new myQueue();
            ThisQueueArrL = new MyQueueARRL();
            ReverseStack = new MyStack();
            ReverseStackArrL = new MyStackARRL();
            myPalindrome = new Palindrome();
            myMaze = new Maze();
            Stopwatch = new Stopwatch();

            GenerateMaze();
            UpdateMaze();
            numericUpDown5.Maximum = 0;
            numericUpDown5.Minimum = decimal.MinValue;
            numericUpDown6.Maximum = decimal.MaxValue;
            numericUpDown6.Minimum = 0;
            numericUpDown7.Minimum = decimal.MinValue;
            numericUpDown7.Maximum = decimal.MaxValue;
            radioButton1.Checked = true;
            ArrayListChecked = false;
        }

        #region Previous Assignments
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
        #endregion

        #region Assignment 3
        #region Q1

        #region Form Methods
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

        private void UpdateRewindCell(int c, int r)
        {
            dataGridView1.Rows[r].Cells[c].Style.BackColor = Color.Pink;
        }

        private void GenerateMaze()
        {
            dataGridView1.Rows.Add(10);
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

        #endregion

        private void CalculatePath(ref List<string> Path)
        {
            if (IsMazeValid())
            {
                MyStack pathStack = new MyStack();

                // 0 Represents the Starting Point
                pathStack.Push(0);

                bool isSearching = true;

                // TODO: Set From Form
                MazeCell Current = new MazeCell();

                int[] Next = new int[2] { 1, 1 };

                while (isSearching)
                {
                    SetNextStep(Current, ref Next, ref pathStack);
                    TakeNextStep(ref Current, Next, ref pathStack);
                    UpdatePathCell(Current.Column, Current.Row);

                    CheckFinished(ref isSearching, Current);
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

        private void SetNextStep(MazeCell mazeCell, ref int[] Next, ref MyStack stack)
        {
            int choices = 0;
            // IF statements check if the spot is open or the finish
            // and sets the step to be taken
            int currentColumn = mazeCell.Column;
            int currentRow = mazeCell.Row;

            // NORTH
            if (myMaze.North(currentColumn, currentRow) == MazeType.Finish || myMaze.North(currentColumn, currentRow) == MazeType.Open)
            {
                Next[0] = currentColumn;
                Next[1] = currentRow - 1;
                choices++;
            }
            // EAST
            if (myMaze.East(currentColumn, currentRow) == MazeType.Finish || myMaze.East(currentColumn, currentRow) == MazeType.Open)
            {
                Next[0] = currentColumn + 1;
                Next[1] = currentRow;
                choices++;
            }
            // SOUTH
            if (myMaze.South(currentColumn, currentRow) == MazeType.Finish || myMaze.South(currentColumn, currentRow) == MazeType.Open)
            {
                Next[0] = currentColumn;
                Next[1] = currentRow + 1;
                choices++;
            }
            // WEST
            if (myMaze.West(currentColumn, currentRow) == MazeType.Finish || myMaze.West(currentColumn, currentRow) == MazeType.Open)
            {
                Next[0] = currentColumn - 1;
                Next[1] = currentRow;
                choices++;
            }

            switch (choices)
            {
                case 0:
                    // NO PATHS
                    Next[0] = -1;
                    Next[1] = -1;
                    break;

                default:
                    // Pushes "Choice" Tracker onto the Stack
                    if (choices > 1)
                    {
                        // Multiple Paths / -1 Means this choice has been made before so there is no need to add another -1 on the stack
                        if (stack.Top() != -1)
                        {
                            stack.Push(-1);
                        }
                    }
                    break;
            }
        }

        private void ChangeTile(MazeCell Current)
        {
            if (myMaze.maze[Current.Column, Current.Row] != MazeType.Start)
            {
                myMaze.maze[Current.Column, Current.Row] = MazeType.Attempted;
            }
        }

        private void TakeNextStep(ref MazeCell Current, int[] next, ref MyStack stack)
        {
            // Directions are based off of how NEXT is set during CHECK-AROUND method
            if (Current.Column > next[0] && Current.Row == next[1])
            {
                // Go West = 1
                stack.Push(1);
                ChangeTile(Current);
                Current.MoveWest();
            }
            else if (Current.Column == next[0] && Current.Row < next[1])
            {
                // Go South = 2
                stack.Push(2);
                ChangeTile(Current);
                Current.MoveSouth();
            }
            else if (Current.Column < next[0] && Current.Row == next[1])
            {
                // Go East = 3
                stack.Push(3);
                ChangeTile(Current);
                Current.MoveEast();
            }
            else if (Current.Column == next[0] && Current.Row > next[1])
            {
                // Go North = 4
                stack.Push(4);
                ChangeTile(Current);
                Current.MoveNorth();
            }
            else
            {
                if (next[0] == -1 || next[1] == -1)
                {
                    // NO PATH
                    RewindPath(ref stack, ref Current);
                }
                else
                {
                    // Error in Path
                }
            }
        }

        private void RewindPath(ref MyStack stack, ref MazeCell Current)
        {
            int ThisPop = stack.Pop();
            bool revearsing = true;
            while (revearsing)
            {
                // Check For Start
                if (ThisPop != 0)
                {
                    // IS NOT START

                    // Check Step
                    if (ThisPop == -1)
                    {
                        // IS CHOICE - Try New Path
                        revearsing = false;
                        // Put Pop back on Stack to signify a choice
                        stack.Push(-1);
                    }
                    else
                    {
                        // IS NOT CHOICE - Keep Popping
                        ThisPop = stack.Pop();
                        UpdateRewindCell(Current.Column, Current.Row);
                        MoveCurrent(ThisPop, ref Current, ref stack);
                    }
                }
                else
                {
                    // IS START - No Path
                    revearsing = false;
                    stack.Push(0);
                }
            }
        }

        private void MoveCurrent(int ThisPop, ref MazeCell Current, ref MyStack stack)
        {
            // SET CURRENT - setMove in opposite direction because we are revearsing
            // 1 = W, 2 = S, 3 = E, 4 = N
            switch (ThisPop)
            {
                case -1:
                    // TODO: Fix recursion loop if stack.Top() fails to be a listed case
                    MoveCurrent(stack.Top(), ref Current, ref stack);
                    break;
                case 1:
                    Current.MoveEast();
                    break;
                case 2:
                    Current.MoveNorth();
                    break;
                case 3:
                    Current.MoveWest();
                    break;
                case 4:
                    Current.MoveSouth();
                    break;
                default:
                    // ERROR - Unidentified Direction or Choice
                    break;
            }
        }

        private void CheckFinished(ref bool searching, MazeCell Current)
        {
            if (myMaze.maze[Current.Column, Current.Row] == MazeType.Finish)
            {
                searching = false;
            }
        }

        #endregion

        #region Q2
        // Assignment 4 - Q3 and Q4 additions are noted above methods

        // Needed for Assignment 4
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ArrayListChecked = false;
            showQueue();
        }

        // Needed for Assignment 4
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ArrayListChecked = true;
            showQueue();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (ArrayListChecked)
                {
                    ThisQueueArrL.Enqueue((int)numericUpDown2.Value);
                }
                else
                {
                    ThisQueue.Enqueue((int)numericUpDown2.Value);
                }
                showQueue();
            }
            catch (Exception)
            {
                MessageBox.Show("The Queue is full.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ArrayListChecked)
                {
                    ThisQueueArrL.Dequeue();
                }
                else
                {
                    ThisQueue.Dequeue();
                }
                showQueue();
            }
            catch (Exception)
            {
                MessageBox.Show("The Queue is empty.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ReverseQueue();
                showReverse();
            }
            catch (Exception)
            {
                MessageBox.Show("The Queue is empty.");
            }
        }

        // Ass4 - Q3 Q4
        private void ReverseQueue()
        {
            // Updated to choose Array or ArrayList
            if (ArrayListChecked)
            {
                for (int i = 0; i < ThisQueueArrL.Length;)
                {
                    ReverseStackArrL.Push(ThisQueueArrL.Dequeue());
                }
                for (int i = 0; i < ReverseStackArrL.Length;)
                {
                    ThisQueueArrL.Enqueue(ReverseStackArrL.Pop());
                }
            }
            else
            {
                for (int i = 0; i < ThisQueue.Length;)
                {
                    ReverseStack.Push(ThisQueue.Dequeue());
                }
                for (int i = 0; i < ReverseStack.Length;)
                {
                    ThisQueue.Enqueue(ReverseStack.Pop());
                }
            }

            // Original for Assignment 3
            //for (int i = 0; i < ThisQueue.Length;)
            //{
            //    ReverseStack.Push(ThisQueue.Dequeue());
            //}
            //for (int i = 0; i < ReverseStack.Length;)
            //{
            //    ThisQueue.Enqueue(ReverseStack.Pop());
            //}
        }

        // Ass4 - Q3 Q4
        private void showQueue()
        {
            // Updated to choose Array or ArrayList
            if (ArrayListChecked)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < ThisQueueArrL.Length; i++)
                {
                    listBox1.Items.Add(ThisQueueArrL.GetItem(i));
                }
            }
            else
            {
                listBox1.Items.Clear();
                for (int i = 0; i < ThisQueue.Length; i++)
                {
                    listBox1.Items.Add(ThisQueue.GetItem(i));
                }
            }

            // Original for Assignment 3
            //listBox1.Items.Clear();
            //for (int i = 0; i < ThisQueue.Length; i++)
            //{
            //    listBox1.Items.Add(ThisQueue.GetItem(i));
            //}
        }

        // Ass4 - Q3 Q4
        private void showReverse()
        {
            // Updated to choose Array or ArrayList
            if (ArrayListChecked)
            {
                listBox2.Items.Clear();
                for (int i = 0; i < ThisQueueArrL.Length; i++)
                {
                    listBox2.Items.Add(ThisQueueArrL.GetItem(i));
                }
            }
            else
            {
                listBox2.Items.Clear();
                for (int i = 0; i < ThisQueue.Length; i++)
                {
                    listBox2.Items.Add(ThisQueue.GetItem(i));
                }
            }

            // Original for Assignment 3
            //listBox2.Items.Clear();
            //for (int i = 0; i < ThisQueue.Length; i++)
            //{
            //    listBox2.Items.Add(ThisQueue.GetItem(i));
            //}
        }
        #endregion
        #endregion

        #region Assignment 4
        #region Q1
        private void button9_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            int i = (int)numericUpDown3.Value;
            int square = 0;

            while (i > 0)
            {
                listBox3.Items.Add(i.ToString());
                square = DoSquare(ref i);
                numericUpDown3.Value = i;
                listBox4.Items.Add(square.ToString());
            }
        }

        private int DoSquare(ref int n)
        {
            int square = n * n;
            n = n / 2;
            return square;
        }

        #endregion

        #region Q2
        int[] SearchArray;

        private void button10_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            Random r = new Random(DateTime.Now.Second);
            SearchArray = new int[(int)numericUpDown4.Value];

            for (int i = 0; i < SearchArray.Length; i++)
            {
                SearchArray[i] = r.Next((int)numericUpDown5.Value, (int)numericUpDown6.Value);
            }

            BubbleSortArray(ref SearchArray);

            for (int i = 0; i < SearchArray.Length; i++)
            {
                listBox5.Items.Add(SearchArray[i]);
            }
        }

        private static void BubbleSortArray(ref int[] SortArray)
        {
            for (int i = SortArray.Length; i > -1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (SortArray[j] > SortArray[j + 1])
                    {
                        int key = SortArray[j + 1];
                        SortArray[j + 1] = SortArray[j];
                        SortArray[j] = key;
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtIndex.Text = DoBianarySearch(SearchArray, (int)numericUpDown7.Value).ToString();
            txtStopWatch.Text = Stopwatch.Elapsed.ToString();
            Stopwatch.Reset();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtIndex.Text = DoLinearSearch(SearchArray, (int)numericUpDown7.Value).ToString();
            txtStopWatch.Text = Stopwatch.Elapsed.ToString();
            Stopwatch.Reset();
        }

        private int DoBianarySearch(int[] searchArray, int value)
        {
            Stopwatch.Start();
            int min = 0;
            int max = searchArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if (searchArray[mid] == value)
                {
                    return mid;
                }
                else if (value < searchArray[mid])
                {
                    // Half is too big, search lower half
                    max = mid - 1;
                }
                else
                {
                    // Half is too small, search upper half
                    min = mid + 1;
                }
            }
            Stopwatch.Stop();
            return -1;
        }

        private int DoLinearSearch(int[] searchArray, int value)
        {
            Stopwatch.Start();
            for (int i = 0; i < searchArray.Length; i++)
            {
                if (searchArray[i] == value)
                {
                    return i;
                }
            }
            Stopwatch.Stop();
            return -1;
        }

        #endregion

        // Q3 & Q4 code will be located in Assignment 3 - Q2
        #endregion

    }
}
