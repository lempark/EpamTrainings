using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace InspectTasks.Directories
{
    public class DirectoriesInspector : IInspector<FileInfo>
    {
        private List<DirectoryInfo> directories;

        public DirectoriesInspector(List<DirectoryInfo> directories)
        {
            this.directories = directories;
        }

        public IEnumerable<FileInfo> GetDuplicates()
        {
            HashSet<FileInfo> result = new HashSet<FileInfo>(new FilesEqualsComparer());
            result = GetFilesSet(this.directories.First());

            foreach (DirectoryInfo dir in this.directories.Skip(1))
            {
                result.IntersectWith(GetFilesSet(dir));
            }

            return result;
        }

        public IEnumerable<FileInfo> GetUniques()
        {
            HashSet<FileInfo> result = new HashSet<FileInfo>(new FilesEqualsComparer());
            result = GetFilesSet(this.directories.First());

            foreach (DirectoryInfo dir in this.directories.Skip(1))
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
                throw new DirectoryNotFoundException();
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
