using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UserInterface;
using Logger;

namespace ReflectionTasks
{
    public class ReflectionTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }

        public ILogger Logger { get; set; }

        public ReflectionTasksRunner(IPrinter printer , ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }

        public void DoTask1()
        {
            Printer.Write("\nTask 1-2  ----------------------------------------------\n");
            AssemblyInvestigator investigator = new AssemblyInvestigator();
            investigator.Printer = Printer;
            try
            {
                investigator.Assembly = Assembly.LoadFrom(@"..\..\..\FilesTasks\bin\Debug\FilesTasks.dll");
                investigator.Investigate();
            }
            catch (System.IO.FileNotFoundException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch (System.IO.FileLoadException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch(ReflectionTypeLoadException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch(Exception e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
        }

        public void Run()
        {
            Printer.Write("\nReflectionTasks\n#################################################");
            DoTask1();
        }
    }
}
