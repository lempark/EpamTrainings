using System;
using UserInterface;
using StructAndEnumTasks;
using System.IO;
using ExeptionsTasks;
using FileTasks;
using Logger;
using ReflectionTasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            MyLogger logger = new MyLogger();
            logger.Configuration(new FileSrc(@"C:\Users\wentr\Desktop\Logs.txt"), LevelOfDetalization.info);

            StructAndEnumTasksRunner structRunner = new StructAndEnumTasksRunner(printer , logger);
            ExceptionTaskRunner exeptionRunner = new ExceptionTaskRunner(printer, logger);
            FilesTasksRunner filesRunner = new FilesTasksRunner(printer, logger);
            ReflectionTasksRunner reflectionRunner = new ReflectionTasksRunner(printer, logger);

            structRunner.Run();
            exeptionRunner.Run();
            filesRunner.Run();
            reflectionRunner.Run();

            Console.Read();
        }
    }
}
