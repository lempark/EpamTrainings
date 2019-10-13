using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Utilites.Printers;


namespace FileTasks
{
    namespace Task1
    {
        

        public static class DirectoryVisualiser
        {
            public static void ShowFiles(DirectoryInfo dir , IPrinter printer)
            {
                FileInfo[] files = dir.GetFiles();
                foreach(FileInfo file in files)
                {
                    printer.Write(file.Name);
                }

                DirectoryInfo[] subDirectories = dir.GetDirectories();
                if(subDirectories.Any())
                {

                    foreach (DirectoryInfo d in subDirectories)
                    {
                        printer.Write(d.Name);
                        ShowFiles(d, printer);
                    }
                }
                
            }
        }
    }
}
