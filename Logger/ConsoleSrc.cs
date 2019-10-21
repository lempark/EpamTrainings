using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleSrc : ISource
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Read()
        {
            throw new NotImplementedException("Not supported read exception message from console");
        }
    }
}
