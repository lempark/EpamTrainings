using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilites.Printers;

namespace StructAndEnumTasks
{
    namespace Task4
    {
        public enum Colors
        {
            Red = 10,
            Blue = 3,
            Green = 87,
            Yellow = 2
        }
        public static class ColorExtensions
        {
            public static void ShowAllValuesOfColors(this Colors someColor, IPrinter printer)
            {
                Array values = Enum.GetValues(someColor.GetType());
                Array.Sort(values);

                foreach(int value in values)
                {
                    printer.Write($"{Enum.GetName(someColor.GetType(), value)} = {value}");
                }
            }
        }
    }
}
