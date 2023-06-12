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
    public partial class Form3 : Form
    {

        public bool resuilt=true;

        public Form3()
        {
            InitializeComponent();
            Score();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Score()
        {
            label2.Text = Form1.score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resuilt = false;
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
