using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnumTasks
{
    namespace Task2
    {
        public interface ISize
        {
            int Weidth { get; set; }
            int Height { get; set; }

            int Perimeter();

        }

        public interface ICoordinates
        {
            int X { get; set; }
            int Y { get; set; }
        }

        public struct Rectangle : ISize , ICoordinates
        {
            public int Weidth { get { return Weidth; } set
                {
                    if (value <= 0)
                        throw new ArgumentException("Weidth must be heigher than 0");
                    else
                        Weidth = value;
                } }

            public int Height { get { return Height; } set
                {
                    if (value <= 0)
                        throw new ArgumentException("Height must be heigher than 0");
                    else
                        Height = value; 
                } }

            public int X { get { return X; } set { X = value; } }
            public int Y { get { return Y; } set { Y = value; } }

            public int Perimeter()
            {
                return 2 * Weidth + 2 * Height;
            }
        }
    }
}

