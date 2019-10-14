using System;
using System.IO;
using System.Collections.Generic;
using UserInterface;
using FileTasks;


namespace FileTasks
{
    public class FilesTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }

        public FilesTasksRunner(IPrinter printer)
        {
            Printer = printer;
        }

        public void DoTask1()
        {
            Printer.Write("\nTask 1  ----------------------------------------------\n");
            try
            {
                DirectoryInfo directory = new DirectoryInfo(@"C:\Windows\Branding");
                DirectoryVisualizer.VisualizeFilesAndDirectories(directory, new ConsolePrinter(), 0);
            }
            catch (Exception e)
            {
                Printer.Write(e.Message);
            }
        }

        public void DoTask2()
        {
            Printer.Write("\nTask 2  ----------------------------------------------\n");
            try
            {
                DirectoryInfo newDir = new DirectoryInfo(@"C:\ddff");
                TxtSearcher searcher = new TxtSearcher(newDir);
                searcher.Search("r", Printer);
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

        public void Run()
        {
            Printer.Write("\nFilesTasks\n#################################################");
            DoTask1();
            DoTask2();

        }
    }
}
