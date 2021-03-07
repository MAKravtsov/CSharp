using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace StudentBillsv2
{
    public class ExcelFile
    {
        public Application Application;
        public Workbooks WorkBooks;
        public Workbook WorkBook;
        public Worksheet WorkSheet;

        public Range Rows => WorkSheet.UsedRange.Rows;

        public ExcelFile()
        {
        }

        public void Connect(string path, string nameWorkSheet)
        {
            Application = new Application();
            WorkBooks = Application.Workbooks;
            WorkBook = WorkBooks.Open(path);
            WorkSheet = WorkBook.Worksheets[nameWorkSheet];
        }

        public void Save()
        {
            try {
                Application.DisplayAlerts = false;
                WorkBook.Save();
            }
            catch (Exception ex) {
                MessageBox.Show($"{ex.Message} {ex.InnerException?.Message} {ex.StackTrace}");
            }
        }

        public void ExportToPDF(string name)
        {
            WorkSheet.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, name);
        }

        public void RunMacros(string name)
        {
            Application.Run(name);
        }

        public void Print()
        {
            WorkSheet.PrintOutEx();
        }

        public void DisConnect()
        {
            WorkBook.Close(true);
            WorkBooks.Close();
            Application.Quit();

            Marshal.ReleaseComObject(WorkSheet);
            Marshal.ReleaseComObject(WorkBook);
            Marshal.ReleaseComObject(WorkBooks);
            Marshal.ReleaseComObject(Application);

            WorkSheet = null;
            WorkBook = null;
            WorkBooks = null;
            Application = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //Thread.Sleep(1000);
        }

        public void FillCell(int row, string column, dynamic value)
        {
            WorkSheet.Cells[row, column] = value;
        }

    }
}
