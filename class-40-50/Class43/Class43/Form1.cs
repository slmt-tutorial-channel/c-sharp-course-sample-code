using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class43
{
     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //表單背景圖片
            BackgroundImage = Properties.Resources.board;
            ////掛上表單事件連結
            //Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            MouseDown+=Form1_MouseDown;
            //設定表單長寬為棋盤圖檔的長寬
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Width;
            //設定表單出現在螢幕的正中央
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //當對表單（視窗）按下Esc鍵時，關閉表單
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private bool isBlack = true;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBlack)
            {
                Controls.Add(new BlackPiece(e.X, e.Y));
                isBlack = false;
            }
            else if (!isBlack)
            {
                Controls.Add(new WhitePiece(e.X, e.Y));
                isBlack = true;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //可見果然不必再用new做個執行個體才行(重構小山老師菩薩的)
            if (Board.CanBePlaced(e.X, e.Y))
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;

        }
    }

}
