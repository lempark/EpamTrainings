using System;
using System.Collections.Generic;
using UserInterface;
using Logger;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace DirectoriesInspect
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
            List<DirectoryInfo> directories = new List<DirectoryInfo>();
            directories.Add(new DirectoryInfo(ConfigurationManager.AppSettings["DirectoriesInspectPathDir1"]));
            directories.Add(new DirectoryInfo(ConfigurationManager.AppSettings["DirectoriesInspectPathDir2"]));

            DirectoriesInspector inspector = new DirectoriesInspector();
            inspector.Directories = directories;
            try
            {
                var startTime = Stopwatch.StartNew();

                this.Printer.Write(ConfigurationManager.AppSettings["DuplicatesStr"]);
                FilesWriter.Write(inspector.GetDuplicates(), this.Printer);

                this.Printer.Write(ConfigurationManager.AppSettings["UniquesStr"]);
                FilesWriter.Write(inspector.GetUniques(), this.Printer);

                startTime.Stop();

                var resultTime = startTime.Elapsed;
                string elapsedTime = string.Format(
                    ConfigurationManager.AppSettings["TimeFormatStr"],
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                this.Printer.Write(elapsedTime);
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
