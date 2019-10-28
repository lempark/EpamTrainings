using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoriesInspect
{
    class FilesEqualsComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(FileInfo obj)
        {
            return Path.GetFileName(obj.FullName).GetHashCode();
        }
    }
}
