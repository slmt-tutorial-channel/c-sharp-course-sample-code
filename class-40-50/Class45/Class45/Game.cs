using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class45
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


        private static void CheckWinner()
        {

        }

    }
}
