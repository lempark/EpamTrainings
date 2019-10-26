﻿using System;
using UserInterface;
using StructAndEnumTasks;
using System.IO;
using ExeptionsTasks;
using FileTasks;
using Logger;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            MyLogger logger = new MyLogger();
            logger.Configuration(new FileSrc(@"C:\Users\SIB\Desktop\Logs.txt"), LevelOfDetalization.info);

            StructAndEnumTasksRunner structRunner = new StructAndEnumTasksRunner(printer , logger);
            ExceptionTaskRunner exeptionRunner = new ExceptionTaskRunner(printer, logger);
            FilesTasksRunner filesRunner = new FilesTasksRunner(printer, logger);

            structRunner.Run();
            exeptionRunner.Run();
            filesRunner.Run();

            Console.Read();
        }
    }
}
