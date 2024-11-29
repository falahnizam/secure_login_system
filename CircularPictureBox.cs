using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace login
{
     internal class CircularPictureBox: PictureBox
    {
        public CircularPictureBox() {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath path = new GraphicsPath(); 
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(pe);
        }
    }
}
