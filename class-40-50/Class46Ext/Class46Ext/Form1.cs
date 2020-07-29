using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class46Ext
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
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            //設定表單長寬為棋盤圖檔的長寬
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Width;
            //在表單上端安放提示現在該誰下的棋子
            Controls.Add(Board.PlaceCurrPlayerPiece());
            //設定表單出現在螢幕的正中央
            StartPosition = FormStartPosition.CenterScreen;
        }

        int pieceCount = 1;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //當對表單（視窗）按下Esc鍵時，關閉表單
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void reBootGame()
        {
            Game.ReBootGame();
            Controls.Clear();
            //在表單上端安放提示現在該誰下的棋子
            Controls.Add(Board.PlaceCurrPlayerPiece());
            pieceCount = 1;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = Game.PlaceAPiece(e.X, e.Y);
            if (piece != null)//如果可以下棋子
            {
                //移除頂端提示之棋子
                Controls.RemoveAt(--pieceCount);
                //加入現在下的棋子
                Controls.Add(piece);
                pieceCount++;

                Piece pieceAuto = Game.autoPlay();
                //以上自動下棋，不要自動下棋把此行至75行「MessageBox.Show("棋盤已滿！");」拿掉即可
                this.Refresh();
                //要做個延遲
                Thread.Sleep(200);
                //自動下棋
                if (pieceAuto != null)
                {
                    Controls.Add(pieceAuto);
                    pieceCount++;
                }
                else
                    MessageBox.Show("棋盤已滿！");

                //加入頂端提示的棋子
                Controls.Add(Board.PlaceCurrPlayerPiece());
                pieceCount++;
                //檢查是否有人獲勝，若有即出現提示訊息並重啟遊戲
                if (Game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑子獲勝！");
                    reBootGame();
                }
                else if (Game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白子獲勝！");
                    reBootGame();
                }

                //檢查是否有人快贏了，若有即出現提示訊息
                
                if (Game.AlmostWinner == PieceType.BLACK)
                {
                    //markPieceCtr = Game.markAlmostWinPiecesYellow();
                    pieceCount += Game.MarkPieceCtr;
                    MessageBox.Show("黑子快要贏了！");
                    //clearAlmostWinPiecesYellow(markPieceCtr, pieceCount);
                    //pieceCount -= markPieceCtr;
                    Game.Reset_almostWinner();
                }
                else if (Game.AlmostWinner == PieceType.WHITE)
                {
                    //markPieceCtr = Game.markAlmostWinPiecesYellow();
                    MessageBox.Show("白子快要贏了！");
                    //clearAlmostWinPiecesYellow(markPieceCtr, pieceCount);
                    Game.Reset_almostWinner();
                }
            }
        }

        
        void clearAlmostWinPiecesYellow(int ctr, int controlcnt)//controlcnt目前Control數
        {
            for (int i = 1; i <= ctr; i++)
            {
                Controls.RemoveAt(controlcnt - i);
                pieceCount--;
            }
            Array.Clear(Game.PiecesMarkYellow, 0, Game.PiecesMarkYellow.Length);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //可見果然不必再用new做個執行個體才行(重構小山老師菩薩的)
            if (Game.CanBePlaced(e.X, e.Y))
                Cursor = Cursors.Hand;//可以下棋子則游標呈手形
            else
                Cursor = Cursors.Default;

        }


    }
}
