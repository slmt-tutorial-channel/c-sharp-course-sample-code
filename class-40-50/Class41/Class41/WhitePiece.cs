using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rs = Class41.Properties.Resources;

namespace Class41
{
    public class WhitePiece : Piece
    {
        public WhitePiece(int x, int y) : base(x, y)
        {
            Image = Rs.white;
        }
    }
    
    
}
