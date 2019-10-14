using System;
using UserInterface;

namespace StructAndEnumTasks
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
