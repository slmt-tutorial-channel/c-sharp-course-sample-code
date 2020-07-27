using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class45
{
    //棋盤總承-整個五子棋遊戲在結束前，棋盤都只有一個，故不必產生其類別的執行個體(重構小山老師菩薩的)https://youtu.be/apQrPURLYZU
    public abstract class Board
    {
        //棋盤邊欄之寬徑
        private static readonly int OFFSET = 75;
        //節結適當的勢力範圍
        private static readonly int NODE_RADIUS = 10;
        //節點之間的距離
        private static readonly int NODE_DISTRANCE = 75;
        //沒有適當下棋子的位置（節點）
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        //棋盤節點數
        internal static readonly int NODE_COUNT_ONESIDE = 9;
        //二維陣列，記錄棋盤上的棋子及其位置
        private static Piece[,] pieces = new Piece[NODE_COUNT_ONESIDE, NODE_COUNT_ONESIDE];

        //定義轉換節點為棋盤上座標的函式（方法）： 
        private static Point convertToFormPosition(Point nodeId)
        {
            //Point formPositon = new Point();
            //此處我想要重構，在return時再用new 建構一個Point物件回傳即可
            return new Point(nodeId.X * NODE_DISTRANCE + OFFSET, nodeId.Y * NODE_DISTRANCE + OFFSET);
        }

        internal static Piece PlaceAPiece(int x, int y, PieceType pieceColor)
        {

            if (CanBePlaced(x, y))
            {
                Point p;
                if (pieceColor == PieceType.BLACK)
                {
                    p = findTheClosestNode(x, y);
                    pieces[p.X, p.Y] = new BlackPiece(convertToFormPosition(p));
                    return pieces[p.X, p.Y];
                }
                else if (pieceColor == PieceType.WHITE)
                {
                    p = findTheClosestNode(x, y);
                    pieces[p.X, p.Y] = new WhitePiece(convertToFormPosition(p));
                    return pieces[p.X, p.Y];

                }

            }
            return null;
        }

        //指定static則不必再用new創建執行個體才能用此成員函式(重構小山老師菩薩的)        
        internal static bool CanBePlaced(int x, int y)
        {
            //TODO:找出最近的節點
            Point nodeId = findTheClosestNode(x, y);

            //TODO:如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;

            //TODO:如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeId.X, nodeId.Y] == null)
                return true;
            else
                return false;

        }

        private static Point findTheClosestNode(int x, int y)
        {
            int nodeIdX = findTheClosestNode(x);
            if (nodeIdX == -1)
                return NO_MATCH_NODE;
            int nodeIdY = findTheClosestNode(y);
            if (nodeIdY == -1)
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }


        private static int findTheClosestNode(int pos)
        {
            //如果游標在棋盤邊欄則回傳 - 1//小山老師菩薩作「pos < OFFSET- NODE_RADIUS」https://youtu.be/apQrPURLYZU
            if (pos + NODE_RADIUS < OFFSET)
                return -1;
            pos -= OFFSET;
            int quotient = pos / NODE_DISTRANCE;
            int remainder = pos % NODE_DISTRANCE;
            //若大於可下棋子的節點數
            if (quotient >= NODE_COUNT_ONESIDE)
                return -1;
            if (remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS)
                //利用條件運算子?:來確保回傳的值不會大於節點數
                return quotient + 1 >= NODE_COUNT_ONESIDE ? -1 : quotient + 1;
            else
                //沒有節點符合下棋子的適當位置
                return -1;
        }

        //Game類別要用，而其非Board的子類別，故不可低於internal；不必建構執行個體便可調用，就指定static。
        internal static PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            Piece piece = pieces[nodeIdX, nodeIdY];
            if (piece == null)
                return PieceType.NONE;
            else
                return piece.GetPieceTyep();
        }
    }

}
