using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace login
{
    class GradientPanel : FlowLayoutPanel
    {
        private Timer timer = new Timer(); // Timer for animation
        private float angleShift = 0; // Variable to change the gradient angle over time

        // Backing fields for ColorTop and ColorBottom
        private Color colorTop = Color.LightBlue;
        private Color colorBottom = Color.LightCoral;

        // Properties to set gradient colors
        [Browsable(true)]   // Makes the property appear in the Properties window
        [Category("Appearance")]  // Creates a category named "Appearance" in the Properties window
        [Description("The color at the top of the gradient.")]
        public Color ColorTop
        {
            get { return colorTop; }
            set { colorTop = value; Invalidate(); }  // Invalidate to force the panel to repaint when the color changes
        }

        [Browsable(true)]   // Makes the property appear in the Properties window
        [Category("Appearance")]  // Creates a category named "Appearance" in the Properties window
        [Description("The color at the bottom of the gradient.")]
        public Color ColorBottom
        {
            get { return colorBottom; }
            set { colorBottom = value; Invalidate(); }  // Invalidate to force the panel to repaint when the color changes
        }

        public GradientPanel()
        {
            // Enable double buffering to reduce flicker
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            // Timer interval to control the animation speed
            timer.Interval = 30; // Adjust the interval for smoother or faster animation
            timer.Tick += Timer_Tick;
            timer.Start(); // Start the animation
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Shift the gradient angle to create a moving effect
            angleShift = (angleShift + 1) % 360; // Keeps the angle within 360 degrees

            Invalidate(); // Redraw the panel with updated gradient angle
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Create a LinearGradientBrush with the fixed top and bottom colors, and an animated angle
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, angleShift);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
