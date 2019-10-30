using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace UserInterface
{
    public interface IRunner
    {
        IPrinter Printer { get; set; }
        
        ILogger Logger { get; set; }

        void Run();
    }
}
