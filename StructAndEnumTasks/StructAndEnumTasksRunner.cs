using System;
using UserInterface;
using StructAndEnumTasks;

namespace StructAndEnumTasks
{
    public class StructAndEnumTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }

        public StructAndEnumTasksRunner(IPrinter printer)
        {
            Printer = printer;
        }

        public void DoTask1()
        {
            Printer.Write("\nTask 1  ----------------------------------------------\n");
            try
            {
                Person person = new Person("John", "Stark", 19);
                Printer.Write(person.CheckingAge(18));
            }
            catch (ArgumentException e)
            {
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Printer.Write(e.Message);
            }

        }

        public void DoTask2()
        {
            Printer.Write("\nTask 2  ----------------------------------------------\n");
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
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Printer.Write(e.Message);
            }
            
        }

        public void DoTask3()
        {
            Printer.Write("\nTask 3  ----------------------------------------------\n");
            Printer.Write("input number of month (0 <= n < 12)_ ");
            Month month = Month.April;
            try
            {
                int n = int.Parse(Printer.Read());
                Printer.Write(month.GetMonthNameWithValue(n));
            }
            catch(ArgumentException e)
            {
                Printer.Write(e.Message);
            }
            catch (Exception e)
            {
                Printer.Write(e.Message);
            }
        }

        public void DoTask4()
        {
            Printer.Write("\nTask 4  ----------------------------------------------\n");
            Colors color = Colors.Red;
            color.ShowAllValuesOfColors(new ConsolePrinter());
        }

        public void DoTask5()
        {
            Printer.Write("\nTask 5  ----------------------------------------------\n");
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
            Printer.Write("\nStructAndEnumTasks\n#################################################");
            DoTask1();
            DoTask2();
            DoTask3();
            DoTask4();
            DoTask5();
        }
    }
}
