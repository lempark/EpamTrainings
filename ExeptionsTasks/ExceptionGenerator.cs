using System;

namespace ExceptionsTasks
{ 
    public class ExceptionGenerator
    {
        public void GenerateStackOverFlowExeption()
        {
            throw new StackOverflowException();
        }
    
        public void GenerateIndexOutOfRangeExeption()
        {
            int[] array = new int[2] { 0, 1 };
            array[3] = 4;
        }
    } 
}
