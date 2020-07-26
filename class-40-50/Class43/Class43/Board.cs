using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class43
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

        //指定static則不必再用new創建執行個體才能用此成員函式(重構小山老師菩薩的)        
        internal static bool CanBePlaced(int x, int y)
        {
            //TODO:找出最近的節點
            Point nodeId = FindTheClosestNode(x, y);

            //TODO:如果沒有的話，回傳false
            if (nodeId==NO_MATCH_NODE)
                return false;

            //TODO:如果有的話，檢查是否已經有棋子存在
            return true;
        }

        private static Point FindTheClosestNode(int x, int y)
        {
            int nodeIdX = FindTheClosestNode(x);
                if (nodeIdX==-1)	
                    return NO_MATCH_NODE;    
            int nodeIdY = FindTheClosestNode(y);
                if (nodeIdY==-1)	
                    return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY);
        }


        private static int FindTheClosestNode(int pos)
        {
            //如果游標在棋盤邊欄則回傳 - 1//小山老師菩薩作「pos < OFFSET- NODE_RADIUS」https://youtu.be/apQrPURLYZU
            if (pos + NODE_RADIUS < OFFSET)
                return -1;
            pos -= OFFSET;
            int quotient = pos / NODE_DISTRANCE;
            int remainder = pos % NODE_DISTRANCE;

            if (remainder <= NODE_RADIUS)
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS)
                return quotient + 1;
            else
                //沒有節點符合下棋子的適當位置
                return -1;
        }

    }

}
