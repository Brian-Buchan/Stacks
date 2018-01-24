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
        public Form1()
        {
            InitializeComponent();
            ThisStack = new MyStack();
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
            ThisStack.Push(i);
        }

        private void PopNumber()
        {
            int i = ThisStack.Pop();
            if (i == -1)
            {
                textBox1.Text = "Stack Empty";
            }
            else
            {
                textBox1.Text = i.ToString();
            }
        }

        private void TakeTop()
        {
            int i = ThisStack.Top();
            if (i == -1)
            {
                textBox1.Text = "Stack Empty";
            }
            else
            {
                textBox1.Text = i.ToString();
            }
        }

        private void ClearText()
        {
            textBox1.Clear();
        }

        private void showStack()
        {
            StackArrayView.Items.Clear();
            for (int i = 0; i < ThisStack.Length; i++)
            {
                StackArrayView.Items.Add(ThisStack.GetItem(i));
            }
        }
    }
}
