using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndEnumTasks
{
    public interface ISize
    {
        int Width { get; set; }
        int Height { get; set; }

        int Perimeter();
    }
}
