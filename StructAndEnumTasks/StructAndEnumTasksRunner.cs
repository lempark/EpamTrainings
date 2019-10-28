using System;
using System.Configuration;
using UserInterface;
using StructAndEnumTasks;
using Logger;

namespace StructAndEnumTasks
{
    public class StructAndEnumTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }
        public ILogger Logger { get; set; }

        public StructAndEnumTasksRunner(IPrinter printer , ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }

        public void DoTask1()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTask1Str"]);
            try
            {
                Person person = new Person("John", "Stark", 19);
                Printer.Write(person.CheckingAge(18));
            }
            catch (ArgumentException e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }

        }

        public void DoTask2()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTask2Str"]);
            Rectangle rect = new Rectangle();    
            try
            {
                rect.Width = 3;
                rect.Height = 4;
                rect.X = -3;
                rect.Y = 4;
                Printer.Write($"Perimeter is {rect.Perimeter()}");
            }
            catch (ArgumentException e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            
        }

        public void DoTask3()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTask3Str"]);
            Printer.Write(ConfigurationManager.AppSettings["InputNumberStr"]);
            Month month = Month.April;
            try
            {
                int n = int.Parse(Printer.Read());
                Printer.Write(month.GetMonthNameWithValue(n));
            }
            catch(ArgumentException e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
        }

        public void DoTask4()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTask4Str"]);
            Colors color = Colors.Red;
            color.ShowAllValuesOfColors(new ConsolePrinter());
        }

        public void DoTask5()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTask5Str"]);
            Array range;
            range = Enum.GetValues(typeof(LongRange));
            Printer.Write("LongRange values : ");
            foreach (long value in range)
            {
                Printer.Write($"{value}");
            }
        }

        public void Run()
        {
            Printer.Write(ConfigurationManager.AppSettings["StructsTasksStr"]);
            DoTask1();
            DoTask2();
            DoTask3();
            DoTask4();
            DoTask5();
        }
    }
}
