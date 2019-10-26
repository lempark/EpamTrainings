using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StyleCopTasks
{
    public interface IRectangle
    {
        Point LeftTop { get; set; }

        Point RightBottom { get; set; }

    }
}
