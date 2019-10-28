using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoriesInspect
{
    public class DirectoriesInspector : IInspector<FileInfo>
    {
        public List<DirectoryInfo> Directories { get; set; }

        public IEnumerable<FileInfo> GetDuplicates()
        {
            HashSet<FileInfo> result = new HashSet<FileInfo>(new FilesEqualsComparer());
            result = GetFilesSet(this.Directories[0]);
            HashSet<FileInfo> temp = new HashSet<FileInfo>();
            temp = GetFilesSet(Directories[1]);
            result.IntersectWith(temp);

            //foreach (DirectoryInfo dir in this.Directories.Skip(1))
            //{
            //    HashSet<FileInfo> tempp = new HashSet<FileInfo>();
            //    temp = GetFilesSet(dir);
            //    result.IntersectWith(tempp);
            //}

            return result;
        }

        public IEnumerable<FileInfo> GetUniques()
        {
            HashSet<FileInfo> result = GetFilesSet(this.Directories.First());

            foreach (DirectoryInfo dir in this.Directories.Skip(1))
            {
                result.SymmetricExceptWith(GetFilesSet(dir));
            }

            return result;
        }

        public static HashSet<FileInfo> GetFilesSet(DirectoryInfo dir)
        {
            if (dir == null)
            {
                throw new ArgumentNullException();
            }

            if (!dir.Exists)
            {
                throw new ArgumentException("Directory not found");
            }

            HashSet<FileInfo> foundFiles = new HashSet<FileInfo>(new FilesEqualsComparer());

            var files = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                foundFiles.Add(file);
            }

            return foundFiles;
        }
    }
}
