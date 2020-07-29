﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class46Ext
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
        //黑子、白子，半徑一樣
        //可下棋子的範圍
        private static readonly int PIECE_AVAILABLE = (NODE_COUNT_ONESIDE-1) *
            NODE_DISTRANCE+OFFSET;
        internal static readonly int PIECE_RADIUS = Properties.Resources.black.Height / 2;
        //二維陣列，記錄棋盤上的棋子及其位置
        private static Piece[,] pieces = new Piece[NODE_COUNT_ONESIDE, NODE_COUNT_ONESIDE];


        //清除記錄棋盤上棋子位置的二維陣列
        internal static void PiecesClear()
        {
            Array.Clear(pieces, 0, pieces.Length);            

            /*for (int i = 0; i < Board.NODE_COUNT_ONESIDE; i++)
            {
                for (int j = 0; j < Board.NODE_COUNT_ONESIDE; j++)
                {
                    pieces[i, j] = null;
                }
            }*/
        }

        //和C++一樣 Class內之成員若沒有存取修飾詞，預設即為private
        static Piece pcCurrPlayer=null;
        internal static Piece CurrPiece { get { return pcCurrPlayer; }  }

        static int xPos= OFFSET+ Board.NODE_COUNT_ONESIDE / 2 * NODE_DISTRANCE;
        //控制棋盤上方提示現在輪到誰下棋子了
        internal static void PcCurrPlayer() {
            if (Game.CurrentPlayer==PieceType.BLACK)
                pcCurrPlayer = new BlackPiece(xPos, PIECE_RADIUS);
            else if (Game.CurrentPlayer == PieceType.WHITE)
                pcCurrPlayer = new WhitePiece(xPos, PIECE_RADIUS);                     

        }

        internal static Piece PlaceCurrPlayerPiece()
        {
            PcCurrPlayer();                  
            return pcCurrPlayer;
        }
        //internal static Piece PlaceNextPlayerPiece()
        //{
        //    Piece pcNextPlayer=null;
        //    if (Game.CurrentPlayer==PieceType.WHITE)
        //        pcNextPlayer = new BlackPiece(xPos, PIECE_RADIUS);
        //    else if (Game.CurrentPlayer == PieceType.BLACK)
        //        pcNextPlayer = new WhitePiece(xPos, PIECE_RADIUS);
        //    return pcNextPlayer;
        //}

        //記下（最後）下棋子的位置
        private static Point lastPlaceNode;
        internal static Point LastPlaceNode { get { return lastPlaceNode; } }

        //定義轉換節點為棋盤上座標的函式（方法）： 
        internal static Point convertToFormPosition(Point nodeId)
        {//Game類別要用
            //Point formPositon = new Point();
            //此處我想要重構，在return時再用new 建構一個Point物件回傳即可
            return new Point(nodeId.X * NODE_DISTRANCE + OFFSET, nodeId.Y * NODE_DISTRANCE + OFFSET);
        }

        internal static Piece PlaceAPiece(int x, int y, PieceType pieceColor)
        {

            if (CanBePlaced(x, y))//可以下棋子的位置
            {
                lastPlaceNode = findTheClosestNode(x, y);
                if (pieceColor == PieceType.BLACK)
                {
                    pieces[lastPlaceNode.X, lastPlaceNode.Y] = new BlackPiece(convertToFormPosition(lastPlaceNode));
                }
                else if (pieceColor == PieceType.WHITE)
                {
                    pieces[lastPlaceNode.X, lastPlaceNode.Y] = new WhitePiece(convertToFormPosition(lastPlaceNode));

                }
                //PcCurrPlayer();
                return pieces[lastPlaceNode.X, lastPlaceNode.Y];

            }
            return null;
        }

        internal static Point autoPlayAvailable()
        {
            Random randomX = new Random(Board.CurrPiece.Location.X);
            Random randomY = new Random(Board.CurrPiece.Location.Y);
            //一直找到可以放棋子的位置
            int randomXpos = randomX.Next() % PIECE_AVAILABLE;
            int randomYpos = randomY.Next() % PIECE_AVAILABLE;
            //小心成為無窮迴圈：先檢查有沒有位置可下棋子
            bool chkPos=false;
            foreach (Piece item in pieces)
            {
                if (item==null)
                {
                    chkPos = true;
                    break;
                }
            }
            if (chkPos)
            {
                while (!CanBePlaced(randomXpos, randomYpos))
                {
                    randomXpos = randomX.Next() % PIECE_AVAILABLE;
                    randomYpos = randomY.Next() % PIECE_AVAILABLE;
                }
                return new Point(randomXpos, randomYpos);

            }
            else//沒有位置可下棋了
                return new Point(-1,-1);
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
