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
        public Form1()
        {
            InitializeComponent();
            ThisStack = new MyStack();
            myPalindrome = new Palindrome();
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
    }
}
