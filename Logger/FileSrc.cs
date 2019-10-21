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
            using (FileStream fs = new FileStream(Path, FileMode.Append)) 
            {
                fs.wr(msg + "\n");
            }
        }

        public string Read()
        {
            using (StreamReader fs = File.OpenText(Path))
            {
                return fs.ReadLine();
            }
        }
    }
}
