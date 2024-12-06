using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace login
{
    [DefaultEvent("Click")]
    public partial class CustomButton : UserControl
    {
        int wh = 20;
        float ang = 45;
        Color cl0 = Color.Blue, cl1 = Color.Orange;
        Timer t = new Timer();

        // Icon and Text properties
        private Image icon; // To hold the icon
        private string buttonText = "Custom Button"; // Default text

        public CustomButton()
        {
            DoubleBuffered = true;
            t.Interval = 60;
            t.Start();
            t.Tick += (s, e) => { Angle = ang % 360 + 1; };
        }

        public float Angle
        {
            get { return ang; }
            set { ang = value; Invalidate(); }
        }

        public int BorderRadius
        {
            get { return wh; }
            set { wh = value; Invalidate(); }
        }

        public Color Color0
        {
            get { return cl0; }
            set { cl0 = value; Invalidate(); }
        }

        public Color Color1
        {
            get { return cl1; }
            set { cl1 = value; Invalidate(); }
        }

        // Property to set the Icon (small image or icon)
        [Category("Appearance")]
        public Image Icon
        {
            get { return icon; }
            set { icon = value; Invalidate(); } // Invalidate to refresh the control
        }

        // Property to set the Text on the button
        [Category("Appearance")]
        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value; Invalidate(); }
        }

        private void CustomButton_Load(object sender, EventArgs e)
        {
            Console.WriteLine("CustomButton Loaded");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(new Rectangle(0, 0, wh, wh), 180, 90);
            path.AddArc(new Rectangle(Width - wh, 0, wh, wh), -90, 90);
            path.AddArc(new Rectangle(Width - wh, Height - wh, wh, wh), 0, 90);
            path.AddArc(new Rectangle(0, Height - wh, wh, wh), 90, 90);

            // Draw the background with gradient colors
            e.Graphics.FillPath(new LinearGradientBrush(ClientRectangle, cl0, cl1, ang), path);

            // Draw the icon if available
            if (icon != null)
            {
                // Icon is placed on the left side of the text
                int iconSize = 24; // Set a fixed size for the icon
                Rectangle iconRect = new Rectangle(10, (Height - iconSize) / 2, iconSize, iconSize);
                e.Graphics.DrawImage(icon, iconRect);
            }

            // Draw the text next to the icon
            using (Brush textBrush = new SolidBrush(ForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = icon == null ? StringAlignment.Center : StringAlignment.Near
                };

                // If icon is present, adjust text position
                float textXPos = icon != null ? 40 : 10;
                RectangleF textRect = new RectangleF(textXPos, 0, Width - textXPos, Height);

                e.Graphics.DrawString(buttonText, Font, textBrush, textRect, sf);
            }

            base.OnPaint(e);
        }
    }
}
