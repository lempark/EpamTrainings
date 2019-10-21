using System;
using System.IO;

namespace Logger
{
    public class FileSrc : ISource
    {
        public string Path { get; set; }

        public FileSrc(string path)
        {
            Path = path;
        }

        public void Write(string msg)
        {
            using (TextWriter fs = new StreamWriter(Path, true))
            {
                fs.WriteLine(msg + "\n");
            }
        }

        public string Read()
        {
            using (TextReader fs = File.OpenText(Path))
            {
                return fs.ReadLine();
            }
        }
    }
}
