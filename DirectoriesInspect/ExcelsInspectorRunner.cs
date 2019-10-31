using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using UserInterface;
using Logger;
using InspectTasks;

namespace InspectTasks
{
    public class ExcelsInspectorRunner : IRunner
    {
        public IPrinter Printer { get; set; }
        public ILogger Logger { get; set; }

        public ExcelsInspectorRunner(IPrinter printer, ILogger logger)
        {
            this.Printer = printer;
            this.Logger = logger;
        }

        public void Run()
        {
            List<(string path, string tableName, int collIndex, int startRowIndex)> collumnAdresses = new List<(string path, string tableName, int collIndex, int startRowIndex)>();

            collumnAdresses.Add((ConfigurationManager.AppSettings["ExcelInspectFirstFilePath"],
                                 ConfigurationManager.AppSettings["ExcelInspectFirstTableName"], 
                                 int.Parse(ConfigurationManager.AppSettings["FirstTableCollumnIndex"]),
                                 int.Parse(ConfigurationManager.AppSettings["FirstTableStartRowIndex"])));

            collumnAdresses.Add((ConfigurationManager.AppSettings["ExcelInspectSecondFilePath"], 
                                 ConfigurationManager.AppSettings["ExcelInspectSecondTableName"],
                                 int.Parse(ConfigurationManager.AppSettings["SecondTableCollumnIndex"]),
                                 int.Parse(ConfigurationManager.AppSettings["SecondTableStartRowIndex"])));

            IInspector<string> inspector = new ExcelsInspector(collumnAdresses);

            try
            {
                var startTime = Stopwatch.StartNew();

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
