using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private Piece[,] pieces = new Piece[9, 9];

        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點 (Node)
            Point nodeId = findTheClosetNode(x, y);

            // 如果沒有的話，回傳 false
            if (nodeId == NO_MATCH_NODE)
                return false;

            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;

            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            // 找出最近的節點 (Node)
            Point nodeId = findTheClosetNode(x, y);

            // 如果沒有的話，回傳 false
            if (nodeId == NO_MATCH_NODE)
                return null;

            // 如果有的話，檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            // 根據 type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);

            return pieces[nodeId.X, nodeId.Y];
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }

        private Point findTheClosetNode(int x, int y)
        {
            int nodeIdX = findTheClosetNode(x);
            if (nodeIdX == -1)
                return NO_MATCH_NODE;

            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1)
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }

        private int findTheClosetNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}
