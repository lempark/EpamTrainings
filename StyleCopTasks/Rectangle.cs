using System;
using System.Drawing;

namespace StyleCopTasks
{
    class Rectangle : IRectangle
    {
        private Point rightBottom;

        public Point LeftTop { get; set; }

        public Point RightBottom
        {
            get
            {
                return this.rightBottom;
            }

            set
            {
                if (value.X <= this.LeftTop.X || value.Y >= this.LeftTop.Y)
                {
                    throw new ArgumentException("invalid parameter of rightBottom");
                }
                else
                {
                    this.rightBottom = value;
                }
            }
        }

        public void Move(int xDistance, int yDistance)
        {
            this.LeftTop = new Point(this.LeftTop.X + xDistance, this.LeftTop.Y + yDistance);
            this.RightBottom = new Point(this.RightBottom.X + xDistance, this.RightBottom.Y + yDistance);
        }

        public void ReSize(int xSize , int ySize)
        {
            this.RightBottom = new Point(this.LeftTop.X + xSize, this.LeftTop.Y + ySize);
        } 
    }
}
