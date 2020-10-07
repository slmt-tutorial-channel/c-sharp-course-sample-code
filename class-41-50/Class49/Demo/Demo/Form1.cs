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
            List<int> list = new List<int>();

            list.Add(5124);
            list.Add(232);
            list.Add(161636);
            list.Add(34);

            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                MessageBox.Show("List 的第 " + i + " 個資料是: " + list[i]);
            }
        }
    }
}
