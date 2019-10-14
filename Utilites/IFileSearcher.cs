using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public interface IFileSearcher
    {
        void Search(string name , IPrinter printer);
    }
}
