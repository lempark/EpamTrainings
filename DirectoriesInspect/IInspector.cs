using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoriesInspect
{
    public interface IInspector<T>
    {
        IEnumerable<T> GetDuplicates();

        IEnumerable<T> GetUniques();
    }
}
