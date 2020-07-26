using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Class42
{
   
    public abstract class Piece:PictureBox
    {
        private static readonly int IMAGE_WIDTH=50;

        public Piece(int x, int y) {
            BackColor = Color.Transparent;
            Location = new Point(x- IMAGE_WIDTH / 2, y- IMAGE_WIDTH / 2);
            Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
        }

    }
}
