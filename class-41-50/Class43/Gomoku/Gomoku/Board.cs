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

        public bool CanBePlaced(int x, int y)
        {
            // 找出最近的節點 (Node)
            Point nodeId = FindTheClosetNode(x, y);

            // 如果沒有的話，回傳 false
            if (nodeId == NO_MATCH_NODE)
                return false;

            // TODO: 如果有的話，檢查是否已經棋子存在

            return true;
        }

        private Point FindTheClosetNode(int x, int y)
        {
            int nodeIdX = FindTheClosetNode(x);
            if (nodeIdX == -1)
                return NO_MATCH_NODE;

            int nodeIdY = FindTheClosetNode(y);
            if (nodeIdY == -1)
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }

        private int FindTheClosetNode(int pos)
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
