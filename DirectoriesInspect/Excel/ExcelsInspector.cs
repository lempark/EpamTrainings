using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;


namespace InspectTasks.Excel
{
    public class ExcelsInspector : IInspector<string>
    {

        private List<(string path, string tableName, int collIndex, int startRowIndex)> collumnAdresses;

        public ExcelsInspector(List<(string path, string tableName, int collIndex, int startRowIndex)> collumnAdresses)
        {
            this.collumnAdresses = collumnAdresses;
        }

        public IEnumerable<string> GetDuplicates()
        {
            HashSet<string> result = this.GetValuesOfCollumn(this.collumnAdresses[0]);

            foreach ((string path, string tableName, int collIndex, int startRowIndex) collAdress in this.collumnAdresses.Skip(1))
            {
                result.IntersectWith(this.GetValuesOfCollumn(collAdress));
            }

            return result;
        }

        public IEnumerable<string> GetUniques()
        {
            HashSet<string> result = this.GetValuesOfCollumn(this.collumnAdresses[0]);

            foreach ((string path, string tableName, int collIndex, int startRowIndex) collAdress in this.collumnAdresses.Skip(1))
            {
                result.SymmetricExceptWith(this.GetValuesOfCollumn(collAdress));
            }

            return result;
        }

        private HashSet<string> GetValuesOfCollumn((string path, string tableName, int collIndex , int startRowIndex) collAdress)
        {
            if (collAdress.collIndex <= 0)
            {
                throw new ArgumentException("parametr shold be greater than 0", nameof(collAdress.collIndex));
            }

            if (collAdress.startRowIndex <= 0)
            {
                throw new ArgumentException("parametr shold be greater than 0", nameof(collAdress.startRowIndex));
            }

            HashSet<string> result = new HashSet<string>();

            using (ExcelPackage excelPackage = ExcelPackageFactory.CreateExcel(collAdress.path))
            {
                if (excelPackage == null)
                {
                    throw new FileNotFoundException();
                }

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[collAdress.tableName];
                if (worksheet == null)
                {
                    throw new ArgumentException("table name not found");
                }

                object cellValue;

                for (int i = collAdress.startRowIndex; ; i++)
                {
                    cellValue = worksheet.Cells[i, collAdress.collIndex].Value;
                    if (cellValue == null)
                    {
                        break;
                    }

                    result.Add(cellValue.ToString());
                }

                excelPackage.Save();

                return result;
            }
        }
    }
}
