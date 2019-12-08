using System;
using System.Collections.Generic;
using UserInterface;
using Logger;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace InspectTasks.Directories
{
    public class DirectoriesInspectRunner : IRunner
    {
        public IPrinter Printer { get; set; }

        public ILogger Logger { get; set; }

        public DirectoriesInspectRunner(IPrinter printer, ILogger logger)
        {
            this.Printer = printer;
            this.Logger = logger;
        }

        public void Run()
        {
            try
            {
                List<DirectoryInfo> directories = new List<DirectoryInfo>();
                directories.Add(new DirectoryInfo(ConfigurationManager.AppSettings["DirectoriesInspectPathDir1"]));
                directories.Add(new DirectoryInfo(ConfigurationManager.AppSettings["DirectoriesInspectPathDir2"]));

                DirectoriesInspector inspector = new DirectoriesInspector(directories);

                var startTime = Stopwatch.StartNew();

                this.Printer.Write(ConfigurationManager.AppSettings["DuplicatesStr"]);
                FilesWriter.Write(inspector.GetDuplicates(), this.Printer);

                this.Printer.Write(ConfigurationManager.AppSettings["UniquesStr"]);
                FilesWriter.Write(inspector.GetUniques(), this.Printer);

                startTime.Stop();

                var resultTime = startTime.Elapsed;
                string elapsedTime = string.Format(
                    "{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                this.Printer.Write(elapsedTime);
            }
            catch (IOException e)
            {
                this.Printer.Write(e.Message);
                this.Logger.LogException(e);
            }
            catch (ArgumentNullException e)
            {
                this.Printer.Write(e.Message);
                this.Logger.LogException(e);
            }
            catch (ArgumentException e)
            {
                this.Printer.Write(e.Message);
                this.Logger.LogException(e);
            }
            catch (Exception e)
            {
                this.Printer.Write(e.Message);
                this.Logger.LogException(e);
            }

        }
    }
}
