using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Class44
{

    public abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 50;
        public Piece(int x, int y)
        {
            InitializeComponent();
            Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2);            
        }

        public Piece(Point point)
        {
            InitializeComponent();
            Location = new Point(point.X - IMAGE_WIDTH / 2, point.Y - IMAGE_WIDTH / 2);
        }

        
        private void InitializeComponent()
        {
            Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
            BackColor = Color.Transparent;
        }
    }
}
