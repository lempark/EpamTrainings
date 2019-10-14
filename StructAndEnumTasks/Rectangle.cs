using System;

namespace StructAndEnumTasks
{
    public struct Rectangle : ISize , ICoordinates
    {
        #region Fields
        int width;
        int height;
        #endregion
        #region Properties  
        public int Width {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weidth must be heigher than 0");
               
                width = value;
            }
        }
    
        public int Height { get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Height must be heigher than 0");
    
                height = value; 
            }
        }
    
        public int X { get; set; }
        public int Y { get; set; }
        #endregion
    
        #region Methods
        public int Perimeter()
        {
            return 2 * Width + 2 * Height;
        }
        #endregion
    }
}

