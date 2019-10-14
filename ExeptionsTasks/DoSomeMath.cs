using System;

namespace ExceptionsTasks
{
    public class Calculator
    {
        public void DoSomeMath(int a, int b)
        {
            if (a < 0)
                throw new ArgumentException("Parameter should be greater than 0", nameof(a));
            if (b > 0)
                throw new ArgumentException("Parameter should be less than 0", nameof(b));            }
    } 
}
