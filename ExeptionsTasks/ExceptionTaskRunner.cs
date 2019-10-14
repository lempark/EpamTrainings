using System;
using UserInterface;
using ExceptionsTasks;

namespace ExeptionsTasks
{
    public class ExceptionTaskRunner : IRunner
    {
        public IPrinter Printer { get; set; }

        public ExceptionTaskRunner(IPrinter printer)
        {
            Printer = printer;
        }

        public void DoTask1_2()
        {
            Printer.Write("\nTask 1-2  ----------------------------------------------\n");

            Printer.Write("Do you want to generate exeptions? (the program will be crashed) y/n ");
            if (Printer.Read() == "y")
            {
                ExceptionGenerator generator = new ExceptionGenerator();

                Printer.Write("type 1 to generate StackOverFlowExeption , and 2 to generate IndexOutOfRangeExeption");
                string answer1 = Printer.Read();

                switch (answer1)
                {
                    case "1":
                        generator.GenerateStackOverFlowExeption();
                        break;
                    case "2":
                        generator.GenerateIndexOutOfRangeExeption();
                        break;
                }
            }
        }
                
        public void DoTask4()
        {
            Printer.Write("\nTask 4  ----------------------------------------------\n");

            ExceptionHandler handler = new ExceptionHandler();
            Printer.Write("type 1 to handle StackOverFlowExeption , and 2 to handle IndexOutOfRangeExeption");

            string answer2 = Printer.Read();
            try
            {
                switch(answer2)
                {
                    case "1":
                        handler.HandleStackOverFlowExeption();
                        break;
                    case "2":
                        handler.HandleIndexOutOfRangeExeption();
                        break;
                }
            }
            catch (StackOverflowException e)
            {
                Printer.Write(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Printer.Write(e.Message);
            }
            catch(Exception e)
            {
                Printer.Write(e.Message);
            }
        }

        public void DoTask5()
        {
            Printer.Write("\nTask 5  ----------------------------------------------\n");

            Calculator calculator = new Calculator();

            Printer.Write("Input a , b ");
            try
            {
                calculator.DoSomeMath(int.Parse(Printer.Read()), int.Parse(Printer.Read()));
            }
            catch (ArgumentException e)
            when(e.ParamName == "a")
            {
                Printer.Write(e.Message);
            }
            catch (ArgumentException e)
            when (e.ParamName == "b")
            {
                Printer.Write(e.Message);
            }
            catch(Exception e)
            {
                Printer.Write(e.Message);
            }
        }
            
        public void Run()
        {
            Printer.Write("\nExeptionTasks\n#################################################");
            DoTask1_2();
            DoTask4();
            DoTask5();
        }
    }
}
