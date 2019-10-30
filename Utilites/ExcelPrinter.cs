using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;

namespace UserInterface
{
    public class ExcelPrinter : IPrinter
    {
        private int collIndex;
        private int rowIndex;
        private string path;
        private string tableName;
        private bool inRowFormatting;

        public ExcelPrinter(
           int collIndex,
           int rowIndex,
           string path,
           string tableName,
           bool inRowFormatting)
        {
            this.collIndex = collIndex;
            this.rowIndex = rowIndex;
            this.path = path;
            this.tableName = tableName;
            this.inRowFormatting = inRowFormatting;
        }


        public void Write(string message)
        {
            if (collIndex < 0 || rowIndex < 0)
                throw new ArgumentException("index should be greater than 0");
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("path is empty");
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("tableName is empty");

            FileInfo file = new FileInfo(path);

            if (!file.Exists)
                throw new ArgumentException("file not found");

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[tableName];

                if (worksheet == null)
                    worksheet = excelPackage.Workbook.Worksheets.Add(tableName);

                worksheet.Cells[rowIndex, collIndex].Value = message;

                if (inRowFormatting)
                    collIndex++;
                else
                    rowIndex++;

                excelPackage.Save();
            }
        }

        public string Read()
        {
            throw new NotImplementedException();  
        }
    }
}
