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
            //count記下連成幾子
            int count = 1;
            int targetX = 0, targetY = 0;
            //PieceType currChkNodePiecType = PieceType.NONE;
            while (count < 5)
            {
                for (int xDir = -1; xDir <= 1; xDir++)
                {
                    for (int yDir = -1; yDir <= 1; yDir++)
                    {
                        targetX = lastPlaceNode.X + xDir * count;
                        targetY = lastPlaceNode.Y + yDir * count;
                        //略過中心點（自己位置）不檢查，當然要輻射出去八方
                        if (xDir == 0 && yDir == 0)
                            continue;
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE || 
                            Board.GetPieceType(targetX, targetY)== PieceType.NONE)                        
                            continue;
                        if (targetX < 0 || targetY < 0 || targetX >= Board.NODE_COUNT_ONESIDE ||
                            targetY >= Board.NODE_COUNT_ONESIDE ||
                             Board.GetPieceType(targetX, targetY) != currentPlayer)
                            return;
                        //要五子連棋
                        count++;
                    }
                }
                return;
            }
            if (count == 5)
                winner = currentPlayer;

        }

    }
}
