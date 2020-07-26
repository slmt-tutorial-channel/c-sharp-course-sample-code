using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class42
{
    public class BlackPiece:Piece
    {
        public BlackPiece(int x,int y) : base(x, y)
        {
            Image = Properties.Resources.black;
        }
    }
}
