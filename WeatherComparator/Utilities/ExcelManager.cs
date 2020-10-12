using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace WeatherComparator.Utilities
{
    class ExcelHelper
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        string application = "";

        public ExcelHelper(string application)
        {
            this.application = application;
        }

        public void WriteToExcelLog(string CityName ,float temp)
        {
            string fName = application + "_TemperatureData_" + DateTime.Today.ToString("ddMMyyyy") + ".xlsx";

            string mainPath = @"C:\" + application + "Logs";
            string folderPath = System.IO.Path.Combine(mainPath, DateTime.Today.ToString("MMMM"));
            string excelPath = System.IO.Path.Combine(folderPath, fName);

            try
            {
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(mainPath);
                    System.IO.Directory.CreateDirectory(folderPath);
                }


                string fNameOnly = Path.GetFileNameWithoutExtension(excelPath);
                string extension = Path.GetExtension(excelPath);
                string path = Path.GetDirectoryName(excelPath);

                if (!File.Exists(excelPath))
                {
                    xlApp = new Excel.Application();
                    xlApp.Visible = false;

                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet.Name = "Sheet1";
                    xlWorkSheet.Cells[1, 1] = "City Name";
                    xlWorkSheet.Cells[1, 2] = "Temperature (in degrees celcius)";
                    Excel.Range headers = xlWorkSheet.UsedRange;
                    headers.EntireRow.Font.Bold = true;
        }
                else
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlApp.Visible = false;
                    xlWorkBook = xlApp.Workbooks.Open(excelPath);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                }


                Excel.Range xlRange = (Excel.Range)xlWorkSheet.Cells[xlWorkSheet.Rows.Count, 1];
                long lastRow = (long)xlRange.get_End(Excel.XlDirection.xlUp).Row;
                long newRow = lastRow + 1;


                xlWorkSheet.Cells[lastRow + 1, 1] = CityName;
                xlWorkSheet.Cells[lastRow + 1, 2] = temp;
      

                Excel.Range range = xlWorkSheet.Range["A1", "J" + newRow];
          
                xlWorkSheet.Columns.AutoFit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();

            }
            finally
            {
                xlApp.DisplayAlerts = false;
                xlWorkBook.SaveAs(excelPath, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Marshal.ReleaseComObject(xlWorkSheet);
                xlWorkBook.Close();
                Marshal.ReleaseComObject(xlWorkBook);
                xlApp.Quit();
                KillSpecificExcelFileProcess(fName);
                Marshal.ReleaseComObject(xlApp);
            }

        }

        private void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.MainWindowTitle == "Microsoft Excel - " + excelFileName)
                    process.Kill();
            }
        }
    }
}
