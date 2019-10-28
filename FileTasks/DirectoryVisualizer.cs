using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UserInterface;


namespace FileTasks
{
    public static class DirectoryVisualizer
    {
        public static void VisualizeFilesAndDirectories(DirectoryInfo dir,  IPrinter printer, int tabulation)
        {
            if(printer == null || dir == null)
            {
                throw new ArgumentNullException();
            }
            if(!dir.Exists)
            {
                throw new ArgumentException("Directory not found");
            }

            
            printer.Write(new String('\t', tabulation) + dir.Name);
    
            DirectoryInfo[] subDirectories = dir.GetDirectories();
            foreach (DirectoryInfo d in subDirectories)
            {                   
                VisualizeFilesAndDirectories(d, printer, tabulation + 1);
            }
    
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                printer.Write(new String('\t' , tabulation+1) + file.Name);
            }
        }
    }  
}
