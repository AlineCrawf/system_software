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
        private PriorityQueue<int, HashTable<int>> body;
        private TextBox[] Boxes;

        public Form1()
        {
            InitializeComponent();
            HashTable<int> hash = new HashTable<int>();
            body = new PriorityQueue<int, HashTable<int>>(hash);
        }

    }
}
