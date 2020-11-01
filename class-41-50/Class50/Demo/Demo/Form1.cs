using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Building b = new Building();

            b.Add(new Worker("小山貓"));
            b.Add(new Worker("大山貓"));

            b.Add(new Resident("哈哈"));

            MessageBox.Show(b.WhoAreIn());
        }
    }
}
