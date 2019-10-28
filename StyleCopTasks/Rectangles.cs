using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StyleCopTasks
{
    public class Rectangles
    {
        public Rectangle Rectangle1 { get; set; }
        public Rectangle Rectangle2 { get; set; }

        public Rectangle RectanglesCombining()
        {
            int xLeftTop = Math.Min(this.Rectangle1.LeftTop.X, this.Rectangle2.LeftTop.X);
            int yLeftTop = Math.Max(this.Rectangle1.LeftTop.Y, this.Rectangle2.LeftTop.Y);

            int xRightBottom = Math.Max(this.Rectangle1.RightBottom.X, this.Rectangle2.RightBottom.X);
            int yRightBottom = Math.Min(this.Rectangle1.RightBottom.Y, this.Rectangle2.RightBottom.Y);

            return new Rectangle(new Point(xLeftTop, yLeftTop), new Point(xRightBottom, yRightBottom));
        }

        public Rectangle RectanglesIntersection()
        {
            int xLeftTop = Math.Max(this.Rectangle1.LeftTop.X, this.Rectangle2.LeftTop.X);
            int yLeftTop = Math.Min(this.Rectangle1.LeftTop.Y, this.Rectangle2.LeftTop.Y);

            int xRightBottom = Math.Min(this.Rectangle1.RightBottom.X, this.Rectangle2.RightBottom.X);
            int yRightBottom = Math.Max(this.Rectangle1.RightBottom.Y, this.Rectangle2.RightBottom.Y);

            return new Rectangle(new Point(xLeftTop, yLeftTop), new Point(xRightBottom, yRightBottom));
        }
    }
}
