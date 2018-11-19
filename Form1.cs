using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriorityQueue
{
    public partial class Form1 : Form
    {
        private PriorityQueue <int,HashTable<int>> body;
        private TextBox[] Boxes;

        public Form1()
        {
            InitializeComponent();
            HashTable<int> hash = new HashTable<int>();
            body = new PriorityQueue <int, HashTable<int>>(hash);
            Boxes = new TextBox[9];
            Boxes[0] = textBox1;
            Boxes[1] = textBox2;
            Boxes[2] = textBox3;
            Boxes[3] = textBox4;
            Boxes[4] = textBox5;
            Boxes[5] = textBox6;
            Boxes[6] = textBox7;
            Boxes[7] = textBox8;
            Boxes[8] = textBox9;
            body.Put(1);
        }



        #region Oups
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (body.Empty())
                MessageBox.Show("Empty hash table");
            else
            {
                for (int i = 0; i < 9; i++)
                    Boxes[i].Clear();
                body.Clear();
                label3.Text = Convert.ToString(body.Count);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (body.Empty())
                MessageBox.Show("Hash table is empty");
            else
            {
                highestBox.Text = Convert.ToString(body.Item());
            }
            
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (body.Empty())
                MessageBox.Show("HashTable is empty");
            else
            {
                string str = Boxes[body.Item()-1].Text;
                int i = str.IndexOf(',');
                str = str.Substring(i+1);
                Boxes[body.Item()-1].Text = str;
                body.Remove();
            }
            label3.Text = Convert.ToString(body.Count);
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            if (AddBox.Text == "")
                MessageBox.Show("Enter number");
            else
            {
                int numb = Convert.ToInt32(AddBox.Text);
                if (numb > 9)
                    MessageBox.Show("Invalid number");
                else
                {
                    body.Put(numb);
                    Boxes[numb-1].Text += $"{numb},";
                    AddBox.Clear();
                    label3.Text = Convert.ToString(body.Count);
                }
            }
        }
    }

}
