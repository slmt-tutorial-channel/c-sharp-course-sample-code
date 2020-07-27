using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Class46
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

        //因為Board類別要存取，而該類並不是Piece的衍生類別，故不能用protected，只能用internal以上的存取層級
        internal abstract PieceType GetPieceTyep();
        
        private void InitializeComponent()
        {
            Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
            BackColor = Color.Transparent;
        }
    }
}
