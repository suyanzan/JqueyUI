using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
namespace ClassLibrary1
{
    public class Class1
    {

        public static bool LockExcelInterop(string filepath, int sheet_index, string password,out String err)
        {
            err = "";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[sheet_index];
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced

                xlWorksheet.Protect(password);
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(filepath);
                xlApp.DisplayAlerts = true;
                //注意: Excel是Unmanaged程式，要妥善結束才能乾淨不留痕跡
                //否則，很容易留下一堆excel.exe在記憶體中
                //所有用過的COM+物件都要使用Marshal.FinalReleaseComObject清掉
                //COM+物件的Reference Counter，以利結束物件回收記憶體
                if (xlWorksheet != null)
                {
                    Marshal.FinalReleaseComObject(xlWorksheet);
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false); //忽略尚未存檔內容，避免跳出提示卡住
                    Marshal.FinalReleaseComObject(xlWorkbook);
                }
                if (xlApp != null)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                }
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return true;
            }
            catch(Exception ex)
            {

                //注意: Excel是Unmanaged程式，要妥善結束才能乾淨不留痕跡
                //否則，很容易留下一堆excel.exe在記憶體中
                //所有用過的COM+物件都要使用Marshal.FinalReleaseComObject清掉
                //COM+物件的Reference Counter，以利結束物件回收記憶體
                if (xlWorksheet != null)
                {
                    Marshal.FinalReleaseComObject(xlWorksheet);
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false); //忽略尚未存檔內容，避免跳出提示卡住
                    Marshal.FinalReleaseComObject(xlWorkbook);
                }
                if (xlApp != null)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return false;
            }
        }
        public static bool UnLockExcelInterop(string filepath, int sheet_index, string password, out String err)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[sheet_index];
            err = "";
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                xlWorksheet.Unprotect(password);
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(filepath);
                xlApp.DisplayAlerts = true;
                //注意: Excel是Unmanaged程式，要妥善結束才能乾淨不留痕跡
                //否則，很容易留下一堆excel.exe在記憶體中
                //所有用過的COM+物件都要使用Marshal.FinalReleaseComObject清掉
                //COM+物件的Reference Counter，以利結束物件回收記憶體
                if (xlWorksheet != null)
                {
                    Marshal.FinalReleaseComObject(xlWorksheet);
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false); //忽略尚未存檔內容，避免跳出提示卡住
                    Marshal.FinalReleaseComObject(xlWorkbook);
                }
                if (xlApp != null)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                }
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return true;
            }
            catch (Exception ex)
            {
                //注意: Excel是Unmanaged程式，要妥善結束才能乾淨不留痕跡
                //否則，很容易留下一堆excel.exe在記憶體中
                //所有用過的COM+物件都要使用Marshal.FinalReleaseComObject清掉
                //COM+物件的Reference Counter，以利結束物件回收記憶體
                if (xlWorksheet != null)
                {
                    Marshal.FinalReleaseComObject(xlWorksheet);
                }
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false); //忽略尚未存檔內容，避免跳出提示卡住
                    Marshal.FinalReleaseComObject(xlWorkbook);
                }
                if (xlApp != null)
                {
                    xlApp.Workbooks.Close();
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                }
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return false;
            }
        }
        public static void LockExcel(string filepath,int sheet_index,string password)
        {
            //Create workbook
            IWorkbook workBook;
            FileStream fsFile = new FileStream(filepath, FileMode.Open);
            workBook = new HSSFWorkbook(fsFile);
            string strFilePath = string.Format(filepath);
            using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                workBook = new HSSFWorkbook(fs);
            }
            //取得整份Excel之後，再去決定要去哪一個Sheet內資料。在NPOI每個Sheet都是一個陣列中的物件，故可以用Index去取
            //Protect the sheet
            HSSFSheet hst;
            hst = (HSSFSheet)workBook.GetSheetAt(sheet_index);
            //protect excel
            hst.ProtectSheet(password);
            //Save the file
            FileStream file = File.Create(filepath);
            workBook.Write(file);
            file.Close();

        }
        public static void UnLockExcelInterop(string filepath, int sheet_index, string password)
        {

        }
        /*
        public static void UnLockExcel(string filepath, int sheet_index, string password)
        {
            //Create workbook
            IWorkbook workBook;
            FileStream fsFile = new FileStream(filepath, FileMode.Open);
            workBook = new HSSFWorkbook(fsFile);
            string strFilePath = string.Format(filepath);
            using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                workBook = new HSSFWorkbook(fs);
            }
            //取得整份Excel之後，再去決定要去哪一個Sheet內資料。在NPOI每個Sheet都是一個陣列中的物件，故可以用Index去取
            //Protect the sheet
            HSSFSheet hst;
            hst = (HSSFSheet)workBook.GetSheetAt(sheet_index);
            HSSFRow row1 = (HSSFRow)hst.CreateRow(0);
            HSSFCell cel1 = (HSSFCell)row1.CreateCell(0);
            HSSFCell cel2 = (HSSFCell)row1.CreateCell(1);
            ICellStyle unlocked = workBook.CreateCellStyle();
            unlocked.IsLocked = false;//設定為非鎖定
            //cel1.SetCellValue("未被锁定");
            cel1.CellStyle = unlocked;
            //Save the file
            FileStream file = File.Create(filepath);
            workBook.Write(file);
            file.Close();
            //sheet1.ProtectSheet("password");

        }
        */
    }

}
