using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Class46
{
    public class WhitePiece:Piece
    {
        public WhitePiece(int x, int y) : base(x, y) {
            Image = Properties.Resources.white;
        }
        public WhitePiece(Point point) : base(point)
        {
            Image = Properties.Resources.white;
        }

        internal override PieceType GetPieceTyep()
        {
            return PieceType.WHITE;
        }
    }
}
