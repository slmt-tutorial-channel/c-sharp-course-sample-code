using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class46Ex_2
{
    public class Game
    {
        private static PieceType currentPlayer = PieceType.BLACK;

        //要給form1呼叫的
        internal static Piece PlaceAPiece(int x, int y)
        {
            Piece piece = Board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {

                CheckWinner(Board.LastPlaceNode);
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;
            }
            return piece;
        }

        //要給form1呼叫的
        internal static bool CanBePlaced(int x, int y)
        {
            return Board.CanBePlaced(x, y);
        }

        private static PieceType winner = PieceType.NONE;
        internal static PieceType Winner { get { return winner; } }
        //重啟遊戲
        internal static void ReBootGame() {
            //重設winner值
            winner = PieceType.NONE;
            //清除棋盤上棋子的分布記錄
            Board.PiecesClear();
        }

        private static void CheckWinner(Point lastPlaceNode)
        {
            //count記下連成幾子-//記錄現在看到幾顆相同的棋子，「=1」表現在下的這子
            int count = 1, countReverse = 0;//反方向檢查是不包括自己，故初始值為0
            int targetX = 0, targetY = 0;
            //PieceType currChkNodePiecType = PieceType.NONE;
            //while (count < 5)
            //{
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //略過中心點（自己位置）不檢查，當然要輻射出去八方
                    if (xDir == 0 && yDir == 0)
                        continue;//若是現在下的這一子則略過後面的程式碼，換下個方向檢查
                    while (count < 5)
                    {
                        //int centerX = lastPlaceNode.X;
                        //int centerY= lastPlaceNode.Y;

                        targetX = lastPlaceNode.X + xDir * count;
                        targetY = lastPlaceNode.Y + yDir * count;                        
                        //檢查是否有子、且顏色是否相同
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE ||
                            Board.GetPieceType(targetX, targetY) == PieceType.NONE ||
                            Board.GetPieceType(targetX, targetY) != currentPlayer)
                        //如果此方向已沒有棋子或換色時，就調頭去看還有沒有同色棋子
                        {
                            countReverse = 0;
                            while (countReverse + count < 5)
                            {
                                countReverse++;
                                targetX = lastPlaceNode.X + xDir * countReverse * -1;//調頭即*-1，即可反方向
                                targetY = lastPlaceNode.Y + yDir * countReverse * -1;                                
                                if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                                    targetY >= Board.NODE_COUNT_ONESIDE ||
                                    Board.GetPieceType(targetX, targetY) == PieceType.NONE ||
                                    Board.GetPieceType(targetX, targetY) != currentPlayer)
                                //如果反方向已沒有棋子或換色時，就結束此方向的檢查
                                {
                                    goto nextdir;//若該位置無子，或連不到五子則跳出最接近這個break的封閉式迴圈while                            

                                }
                                if (countReverse + count == 5)
                                {
                                    winner = currentPlayer;
                                    return;//贏家確定了，就不用再找了
                                }
                            }
                        }
                        //要五子連棋,找到同色子就加1
                        count++;
                    }
                    nextdir:
                    if (count == 5)
                    {
                        winner = currentPlayer;
                        return;//決定了贏家之後，就不用再找了
                    }
                    else
                        count = 1;
                }
            }
            //}
            //if (count == 5)
            //    winner = currentPlayer;

        }

    }
}
