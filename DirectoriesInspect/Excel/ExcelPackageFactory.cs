using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using OneDriveOperations;

namespace InspectTasks.Excel
{
    class ExcelPackageFactory
    {
        public static ExcelPackage CreateExcel(string path)
        {
            if (path == "OneDrive")
            {
                return new ExcelPackage(OneDriveFilesOperator.GetFile());
            }
            else
            {
                var file = new FileInfo(path);

                if (file.Exists)
                {
                    return new ExcelPackage(file);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
