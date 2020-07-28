using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class46
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

        private static void CheckWinner(Point lastPlaceNode)
        {
            //count記下連成幾子-//記錄現在看到幾顆相同的棋子
            int count = 1;
            int targetX = 0, targetY = 0;
            //PieceType currChkNodePiecType = PieceType.NONE;
            //while (count < 5)
            //{
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    while (count < 5)
                    {
                        //int centerX = lastPlaceNode.X;
                        //int centerY= lastPlaceNode.Y;

                        targetX = lastPlaceNode.X + xDir * count;
                        targetY = lastPlaceNode.Y + yDir * count;
                        //略過中心點（自己位置）不檢查，當然要輻射出去八方
                        if (xDir == 0 && yDir == 0)
                            break;//若是現在下的這一子則跳出最接近這個break的封閉式迴圈while，換下個方向檢查
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE ||
                            Board.GetPieceType(targetX, targetY) == PieceType.NONE)
                            break;
                        //檢查顏色是否相同
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE ||
                             Board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;//若連不到五子則跳出最接近這個break的封閉式迴圈
                        //要五子連棋
                        count++;
                    }
                    if (count == 5)
                        winner = currentPlayer;
                }
            }
            return;
            //}
            //if (count == 5)
            //    winner = currentPlayer;

        }

    }
}
