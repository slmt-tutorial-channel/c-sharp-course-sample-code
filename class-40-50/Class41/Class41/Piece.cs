using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//指定Class41.Properties.Resources的別名為Rs
using Rs = Class41.Properties.Resources;

namespace Class41
{
    public abstract class Piece : PictureBox
    {
        public Piece(int x, int y)
        {
            //BackgroundImage = Rs.black;            
            BackColor = Color.Transparent;
            //Height = Rs.black.Height;
            //Width = Rs.black.Width;
            Size = new Size(Rs.black.Width, Rs.black.Height);
            //Left = x - Rs.black.Width / 2;
            //Top = y - Rs.black.Height / 2;
            Location = new Point(x, y);
        }
    }
}
