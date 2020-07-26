using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class41
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //設定表單長寬為棋盤圖檔的長寬
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Width;
            //設定表單出現在螢幕的正中央
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(new WhitePiece(75*2,75*3));
            Controls.Add(new BlackPiece(75*2,75*4));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {            
            //當對表單（視窗）按下Esc鍵時，關閉表單
            if (e.KeyCode ==Keys.Escape)
                this.Close();
        }
    }
}
