using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Вычисление_по_формулам
{
    public class RoundComboBox : ComboBox
    {
        public RoundComboBox()
        {

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint,
                true
            );
        }

        public int cornerRadius { get; set; } = 10;
        public Color gradientTop { get; set; }
        public Color gradientBottom { get; set; }
        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            Graphics graphics = paintEvent.Graphics;

            SolidBrush backgroundBrush = new SolidBrush(this.BackColor);
            graphics.FillRectangle(backgroundBrush, ClientRectangle);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            GraphicsPath graphicsPath = RoundedRectangle(rectangle, cornerRadius, 0);
            Brush brush = new LinearGradientBrush(rectangle, gradientTop, gradientBottom, LinearGradientMode.Horizontal);
            graphics.FillPath(brush, graphicsPath);

            rectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 100);
            graphicsPath = RoundedRectangle(rectangle, cornerRadius, 2);
            brush = new LinearGradientBrush(rectangle, gradientTop, gradientBottom, LinearGradientMode.Horizontal);
            graphics.FillPath(brush, graphicsPath);
        }

        private GraphicsPath RoundedRectangle(Rectangle rectangle, int cornerRadius, int margin)
        {
            GraphicsPath roundedRectangle = new GraphicsPath();
            roundedRectangle.AddArc(rectangle.X + margin, rectangle.Y + margin, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRectangle.AddArc(rectangle.X + rectangle.Width - margin - cornerRadius * 2, rectangle.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRectangle.AddArc(rectangle.X + rectangle.Width - margin - cornerRadius * 2, rectangle.Y + rectangle.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRectangle.AddArc(rectangle.X + margin, rectangle.Y + rectangle.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRectangle.CloseFigure();
            return roundedRectangle;
        }
    }
}
