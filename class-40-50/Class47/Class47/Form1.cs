using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class47
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player p = new Player("小山貓");
            Villager v = new Villager();

            Monster m = new Monster();
            m.attack(p);
            m.attack(v);

            MessageBox.Show(p.say());
            MessageBox.Show(v.say());
        }
    }
}
