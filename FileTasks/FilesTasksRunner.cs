using System;
using System.IO;
using UserInterface;
using Logger;
using System.Configuration;


namespace FileTasks
{
    public class FilesTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }
        public ILogger Logger { get; set; }

        public FilesTasksRunner(IPrinter printer , ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }

        public void DoTask1()
        {
            Printer.Write(ConfigurationManager.AppSettings["FilesTask1Str"]);
            try
            {
                DirectoryInfo directory = new DirectoryInfo(ConfigurationManager.AppSettings["DirectoryForVisualize"]);
                DirectoryVisualizer.VisualizeFilesAndDirectories(directory, new ConsolePrinter(), 0);
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                Printer.Write(e.Message);
            }
        }

        public void DoTask2()
        {
            Printer.Write(ConfigurationManager.AppSettings["FilesTask2Str"]);
            try
            {
                DirectoryInfo newDir = new DirectoryInfo(ConfigurationManager.AppSettings["DirectoryForTxtSearch"]);
                TxtSearcher searcher = new TxtSearcher(newDir);
                searcher.Search("L", Printer);
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

        public void Run()
        {
            Printer.Write(ConfigurationManager.AppSettings["FilesTasksStr"]);
            DoTask1();
            DoTask2();
        }
    }
}
