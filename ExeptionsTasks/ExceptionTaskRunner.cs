using System;
using UserInterface;
using ExceptionsTasks;
using Logger;
using System.Configuration;

namespace ExeptionsTasks
{
    public class ExceptionTaskRunner : IRunner
    {
        public IPrinter Printer { get; set; }
        public ILogger Logger { get; set; }

        public ExceptionTaskRunner(IPrinter printer, ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }
      
        public void DoTask4()
        {
            Printer.Write(ConfigurationManager.AppSettings["ExceptionTask4Str"]);

            ExceptionHandler handler = new ExceptionHandler();
            try
            {
                handler.HandleStackOverFlowExeption();
                handler.HandleIndexOutOfRangeExeption();       
            }
            catch (StackOverflowException e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch(Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
        }

        public void DoTask5()
        {
            Printer.Write(ConfigurationManager.AppSettings["ExceptionTask5Str"]);

            Calculator calculator = new Calculator();

            Printer.Write("Input a , b ");
            try
            {
                calculator.DoSomeMath(int.Parse(Printer.Read()), int.Parse(Printer.Read()));
            }
            catch (ArgumentException e)
            when(e.ParamName == "a")
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch(Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
        }
            
        public void Run()
        {
            Printer.Write(ConfigurationManager.AppSettings["ExceptionTasksStr"]);
            DoTask4();
            DoTask5();
        }
    }
}
