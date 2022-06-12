using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                // 檢查是否現在下棋的人獲勝
                CheckWinner();

                // 交換選手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }

            return null;
        }

        private void CheckWinner()
        {
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            // 檢查八個不同方向
            for (int xDir = -1; xDir <= 1; xDir++) {
                for (int yDir = -1; yDir <= 1; yDir++) {
                    // 排除中間的情況
                    if (xDir == 0 && yDir == 0)
                        continue;

                    // 紀錄現在看到幾顆相同的棋子
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        // 檢查顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    // 檢查是否看到五顆棋子
                    if (count == 5)
                        winner = currentPlayer;
                }
            }
        }
    }
}
