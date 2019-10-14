using System;
using System.Collections.Generic;
using System.IO;
using UserInterface;

namespace FileTasks
{
    public class TxtSearcher : IFileSearcher
    {
        #region Fields
        DirectoryInfo subDir;
        #endregion
    
        #region Properties
        public DirectoryInfo TargetDirectory { get; set; }
        public List<FileInfo> FoundFiles { get; }
        #endregion
    
        #region Constructors
        public TxtSearcher(DirectoryInfo targetDirectory)
        {
            TargetDirectory = targetDirectory;
            subDir = targetDirectory;
        }
        #endregion
    
        #region Methods
        public void Search(string name , IPrinter printer)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Name can not be empty");
    
            FileInfo[] files = subDir.GetFiles("*" + name + "*.txt");
            foreach (FileInfo file in files)
            {
                printer.Write(file.FullName);
            }
    
            DirectoryInfo[] subDirectories = subDir.GetDirectories();
            foreach (DirectoryInfo d in subDirectories)
            {
                subDir = d;
                Search(name , printer);
            }
        }
        #endregion
    } 
}
