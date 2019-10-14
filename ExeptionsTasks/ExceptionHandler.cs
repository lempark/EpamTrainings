using System;

namespace ExceptionsTasks
{
    public class ExceptionHandler
    {
        ExceptionGenerator exG = new ExceptionGenerator();
    
        public void HandleStackOverFlowExeption()
        { 
            try
            {
                exG.GenerateStackOverFlowExeption();
            }
            catch(StackOverflowException)
            {
                throw;
            }  
        }
    
        public void HandleIndexOutOfRangeExeption()
        {
            try
            {
                exG.GenerateIndexOutOfRangeExeption();
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            
        }
    }
}
