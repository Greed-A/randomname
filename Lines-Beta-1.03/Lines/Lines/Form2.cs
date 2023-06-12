using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lines
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int res;

        private void button1_Click(object sender, EventArgs e)
        {
            res = int.Parse(textBox1.Text);
            Form1.max = res;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
