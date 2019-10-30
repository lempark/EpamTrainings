using System;
using UserInterface;
using StructAndEnumTasks;
using System.IO;
using ExeptionsTasks;
using FileTasks;
using Logger;
using ReflectionTasks;
using SerializationTasks;
using InspectTasks;
using System.Configuration;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            ExcelPrinter excelPrinter = new ExcelPrinter(
                1,
                1,
                ConfigurationManager.AppSettings["DirectoriesInspectExcelPath"],
                ConfigurationManager.AppSettings["ExcelTableName"],
                false);

            MyLogger logger = new MyLogger();
            logger.Configuration(new FileSrc(ConfigurationManager.AppSettings["LogFilePath"]), LevelOfDetalization.info);

            StructAndEnumTasksRunner structRunner = new StructAndEnumTasksRunner(printer , logger);
            ExceptionTaskRunner exeptionRunner = new ExceptionTaskRunner(printer, logger);
            FilesTasksRunner filesRunner = new FilesTasksRunner(printer, logger);
            SerializationTasksRunner serializationRunner = new SerializationTasksRunner(printer, logger);
            ReflectionTasksRunner reflectionRunner = new ReflectionTasksRunner(printer, logger);
            DirectoriesInspectRunner dirInspectRunner = new DirectoriesInspectRunner(excelPrinter, logger);
            ExcelsInspectorRunner excelInspectRunner = new ExcelsInspectorRunner(new ExcelPrinter(
                                                                                                    1,
                                                                                                    1,
                                                                                                    ConfigurationManager.AppSettings["DirectoriesInspectExcelPath"],
                                                                                                    "123",
                                                                                                    false) , logger);

            //structRunner.Run();
            //exeptionRunner.Run();
            //filesRunner.Run();
            //serializationRunner.Run();
            //reflectionRunner.Run();
            dirInspectRunner.Run();
            excelInspectRunner.Run();
            Console.Read();
        }
    }
}
