using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class46Ext
{
    public class YellowPiece:Piece
    {
        
            public YellowPiece(int x, int y) : base(x, y)
            {
                Image = Properties.Resources.yellow;
            }
            public YellowPiece(Point point) : base(point)
            {
                Image = Properties.Resources.yellow;
            }

            internal override PieceType GetPieceTyep()
            {
                return PieceType.YELLOW;
            }
        

    }
}
