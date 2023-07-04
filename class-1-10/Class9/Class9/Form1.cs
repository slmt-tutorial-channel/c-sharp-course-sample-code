using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class9
{
    public partial class Form1 : Form
    {
        int times = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            times++;
            timesLabel.Text = "你已經按了 ... " + times + " 下";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            times = 0;
            timesLabel.Text = "你已經按了 ... " + times + " 下";
        }
    }
}
