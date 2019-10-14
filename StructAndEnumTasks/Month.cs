using System;

namespace StructAndEnumTasks
{
    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public static class MonthExtensions
    {
        public static string GetMonthNameWithValue(this Month someMonth , int n)
        {
            if (n < 0 || n > 11)
                throw new ArgumentException("value of month should be greater than 0 and less than 12");
            return Enum.GetName(typeof(Month), n);
        }
    } 
}
