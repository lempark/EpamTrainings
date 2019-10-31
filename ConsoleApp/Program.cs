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
            IPrinter printer = new ConsolePrinter();
            IPrinter excelPrinter = new ExcelPrinter(
                1,
                1,
                ConfigurationManager.AppSettings["DirectoriesInspectOutputPath"],
                ConfigurationManager.AppSettings["ExcelTableName"],
                false);

            MyLogger logger = new MyLogger();
            logger.Configuration(new FileSrc(ConfigurationManager.AppSettings["LogFilePath"]), LevelOfDetalization.info);

            IRunner structRunner = new StructAndEnumTasksRunner(printer , logger);
            IRunner exeptionRunner = new ExceptionTaskRunner(printer, logger);
            IRunner filesRunner = new FilesTasksRunner(printer, logger);
            IRunner serializationRunner = new SerializationTasksRunner(printer, logger);
            IRunner reflectionRunner = new ReflectionTasksRunner(printer, logger);
            IRunner dirInspectRunner = new DirectoriesInspectRunner(excelPrinter, logger);
            IRunner excelInspectRunner = new ExcelsInspectorRunner(new ExcelPrinter(
                                                                                    1,
                                                                                    1,
                                                                                    ConfigurationManager.AppSettings["DirectoriesInspectOutputPath"],
                                                                                    "123",
                                                                                    false) , logger);

            structRunner.Run();
            exeptionRunner.Run();
            filesRunner.Run();
            serializationRunner.Run();
            reflectionRunner.Run();
            dirInspectRunner.Run();
            excelInspectRunner.Run();
            Console.Read();
        }
    }
}
