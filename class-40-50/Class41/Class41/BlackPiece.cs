using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rs = Class41.Properties.Resources;

namespace Class41
{
    public class BlackPiece:Piece
    {
        public BlackPiece(int x, int y) : base(x, y) {
            Image = Rs.black;
        }
    }
}
