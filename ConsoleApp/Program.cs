using System;
using UserInterface;
using StructAndEnumTasks;
using System.IO;
using ExeptionsTasks;
using FileTasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            StructAndEnumTasksRunner structRunner = new StructAndEnumTasksRunner(printer);
            ExceptionTaskRunner exeptionRunner = new ExceptionTaskRunner(printer);
            FilesTasksRunner filesRunner = new FilesTasksRunner(printer);
            structRunner.Run();
            exeptionRunner.Run();
            filesRunner.Run();
            Console.Read();
        }
    }
}
