using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileTasks
{
    namespace Task1
    {
        public class ConsolePrinter : Printers.IPrinter
        {
            public void Print(string msg)
            {
                Console.WriteLine(msg);
            }
        }

        public static class DirectoryVisualiser
        {
            public static void ShowFiles(DirectoryInfo dir , Printers.IPrinter printer)
            {
                FileInfo[] files = dir.GetFiles();
                foreach(FileInfo file in files)
                {
                    printer.Print(file.Name);
                }

                DirectoryInfo[] subDirectories = dir.GetDirectories();
                if(subDirectories.Any())
                {

                    foreach (DirectoryInfo d in subDirectories)
                    {
                        printer.Print(d.Name);
                        ShowFiles(d, printer);
                    }
                }
                
            }
        }
    }
}
