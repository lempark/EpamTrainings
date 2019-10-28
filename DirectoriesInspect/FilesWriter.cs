﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UserInterface;

namespace DirectoriesInspect
{
    public static class FilesWriter
    {
        public static void Write(IEnumerable <FileInfo> files, IPrinter printer)
        {
            if (files.Count() == 0)
            {
                throw new ArgumentException("Files count is 0");
            }

            if (files == null || printer == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var file in files)
            {
                printer.Write(file.Name);
            }
        }
    }
}
