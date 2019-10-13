using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilites
{
    namespace Printers
    {
        public interface IPrinter
        {
            void Write(string msg);
            string Read();
        }

        public class ConsolePrinter : IPrinter
        {
            public void Write(string msg)
            {
                Console.WriteLine(msg);
            }

            public string Read()
            {
                return Console.ReadLine();
            }
        }
    }
}
