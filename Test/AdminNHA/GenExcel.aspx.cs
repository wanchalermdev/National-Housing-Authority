using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Globalization;
using System.IO;

namespace Test.AdminNHA
{
    public partial class GenExcel : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["project_id"] = Request.QueryString["id"];
            int project_id = Int32.Parse(ViewState["project_id"].ToString());
            int user_id = Int32.Parse(Session["USER"].ToString());
            genformExcel();
            db.Update_Project_State( user_id, project_id, 9);
            Response.Redirect("");
        }
        private IWorkbook workbook;
        private IFont fontHeader, fontRow, fontRowBold, fontRowBoldUnderline, fontProjHead, fontProj;
        private ISheet sheet;
        private ICellStyle cellStyleHeader, cellStyleMediumRow, cellStyleLeftRow, cellStyleRightRow, cellStyleHeaderColor, cellStyleRowEnd, cellStyleLeftRowColor, cellStyleLeftRowBold, cellStyleLeftRowBoldColor, cellStyleProj, cellStyleProjHeader, cellStyleLeftRowUnderline, cellStyleMediumRowColorBorder, cellStyleMediumRowColor, cellStyleMediumRowBold, cellStyleMediumRowBoldColor;

        private void initialXSSFWorkbook()
        {
            workbook = new XSSFWorkbook();
            sheet = workbook.CreateSheet("Sheet1");

        }
        private void initialFontStyle()
        {
            fontHeader = workbook.CreateFont();
            fontHeader.FontName = "TH SarabunPSK";
            fontHeader.FontHeightInPoints = 16;

            fontRow = workbook.CreateFont();
            fontRow.FontName = "TH SarabunPSK";
            fontRow.FontHeightInPoints = 16;

            fontRowBold = workbook.CreateFont();
            fontRowBold.FontName = "TH SarabunPSK";
            fontRowBold.FontHeightInPoints = 16;
            fontRowBold.Boldweight = (short)FontBoldWeight.Bold;

            fontRowBoldUnderline = workbook.CreateFont();
            fontRowBoldUnderline.FontName = "TH SarabunPSK";
            fontRowBoldUnderline.FontHeightInPoints = 16;
            fontRowBoldUnderline.Boldweight = (short)FontBoldWeight.Bold;
            fontRowBoldUnderline.Underline = FontUnderlineType.Single;

            fontProj = workbook.CreateFont();
            fontProj.FontName = "TH SarabunPSK";
            fontProj.FontHeightInPoints = 16;
            fontProj.Boldweight = (short)FontBoldWeight.Bold;

            fontProjHead = workbook.CreateFont();
            fontProjHead.FontName = "TH SarabunPSK";
            fontProjHead.FontHeightInPoints = 20;
            fontProjHead.Boldweight = (short)FontBoldWeight.Bold;
        }
        private void initialsCellStyle()
        {
            // Proj Header
            cellStyleProjHeader = workbook.CreateCellStyle();
            cellStyleProjHeader.Alignment = HorizontalAlignment.Center;
            cellStyleProjHeader.VerticalAlignment = VerticalAlignment.Center;
            cellStyleProjHeader.SetFont(fontProjHead);
            //cellStyleProjHeader.WrapText = true;
            // Proj
            cellStyleProj = workbook.CreateCellStyle();
            cellStyleProj.Alignment = HorizontalAlignment.Left;
            cellStyleProj.VerticalAlignment = VerticalAlignment.Center;
            cellStyleProj.SetFont(fontProj);
            // Header Column
            cellStyleHeader = workbook.CreateCellStyle();
            cellStyleHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeader.Alignment = HorizontalAlignment.Center;
            cellStyleHeader.VerticalAlignment = VerticalAlignment.Center;
            cellStyleHeader.SetFont(fontHeader);
            cellStyleHeader.WrapText = true;
            // Header with grey color
            cellStyleHeaderColor = workbook.CreateCellStyle();
            cellStyleHeaderColor.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeaderColor.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeaderColor.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeaderColor.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleHeaderColor.Alignment = HorizontalAlignment.Center;
            cellStyleHeaderColor.VerticalAlignment = VerticalAlignment.Center;
            cellStyleHeaderColor.SetFont(fontHeader);
            cellStyleHeaderColor.WrapText = true;
            cellStyleHeaderColor.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleHeaderColor.FillPattern = FillPattern.SolidForeground;
            // Normal medium row with color and border
            cellStyleMediumRowColorBorder = workbook.CreateCellStyle();
            cellStyleMediumRowColorBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColorBorder.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColorBorder.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColorBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColorBorder.Alignment = HorizontalAlignment.Center;
            cellStyleMediumRowColorBorder.VerticalAlignment = VerticalAlignment.Center;
            cellStyleMediumRowColorBorder.SetFont(fontRow);
            //cellStyleMediumRowColorBorder.WrapText = true;
            cellStyleMediumRowColorBorder.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleMediumRowColorBorder.FillPattern = FillPattern.SolidForeground;

            // Normal medium row with color 
            cellStyleMediumRowColor = workbook.CreateCellStyle();
            cellStyleMediumRowColor.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColor.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowColor.Alignment = HorizontalAlignment.Center;
            cellStyleMediumRowColor.VerticalAlignment = VerticalAlignment.Center;
            cellStyleMediumRowColor.SetFont(fontRow);
            cellStyleMediumRowColor.WrapText = true;
            cellStyleMediumRowColor.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleMediumRowColor.FillPattern = FillPattern.SolidForeground;
            // Normal medium row
            cellStyleMediumRow = workbook.CreateCellStyle();
            cellStyleMediumRow.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRow.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRow.Alignment = HorizontalAlignment.Center;
            cellStyleMediumRow.VerticalAlignment = VerticalAlignment.Center;
            cellStyleMediumRow.SetFont(fontRow);
            cellStyleMediumRow.WrapText = true;
            // Normal medium row bold
            cellStyleMediumRowBold = workbook.CreateCellStyle();
            cellStyleMediumRowBold.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowBold.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowBold.Alignment = HorizontalAlignment.Center;
            cellStyleMediumRowBold.VerticalAlignment = VerticalAlignment.Center;
            cellStyleMediumRowBold.SetFont(fontRowBold);
            cellStyleMediumRowBold.WrapText = true;
            // Normal medium row bold with color
            cellStyleMediumRowBoldColor = workbook.CreateCellStyle();
            cellStyleMediumRowBoldColor.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowBoldColor.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleMediumRowBoldColor.Alignment = HorizontalAlignment.Center;
            cellStyleMediumRowBoldColor.VerticalAlignment = VerticalAlignment.Center;
            cellStyleMediumRowBoldColor.SetFont(fontRowBold);
            cellStyleMediumRowBoldColor.WrapText = true;
            cellStyleMediumRowBoldColor.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleMediumRowBoldColor.FillPattern = FillPattern.SolidForeground;
            // Normal left row
            cellStyleLeftRow = workbook.CreateCellStyle();
            cellStyleLeftRow.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRow.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRow.Alignment = HorizontalAlignment.Left;
            cellStyleLeftRow.VerticalAlignment = VerticalAlignment.Center;
            cellStyleLeftRow.SetFont(fontRow);
            cellStyleLeftRow.WrapText = true;
            // Normal right row
            cellStyleRightRow = workbook.CreateCellStyle();
            cellStyleRightRow.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleRightRow.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleRightRow.Alignment = HorizontalAlignment.Right;
            cellStyleRightRow.VerticalAlignment = VerticalAlignment.Center;
            cellStyleRightRow.SetFont(fontRow);
            cellStyleRightRow.WrapText = true;
            // Normal left row with color
            cellStyleLeftRowColor = workbook.CreateCellStyle();
            cellStyleLeftRowColor.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowColor.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowColor.Alignment = HorizontalAlignment.Left;
            cellStyleLeftRowColor.VerticalAlignment = VerticalAlignment.Center;
            cellStyleLeftRowColor.SetFont(fontRow);
            cellStyleLeftRowColor.WrapText = true;
            cellStyleLeftRowColor.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleLeftRowColor.FillPattern = FillPattern.SolidForeground;
            // Normal left row bold underline
            cellStyleLeftRowUnderline = workbook.CreateCellStyle();
            cellStyleLeftRowUnderline.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowUnderline.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowUnderline.Alignment = HorizontalAlignment.Left;
            cellStyleLeftRowUnderline.VerticalAlignment = VerticalAlignment.Center;
            cellStyleLeftRowUnderline.SetFont(fontRowBoldUnderline);
            cellStyleLeftRowUnderline.WrapText = true;
            // Normal left row bold
            cellStyleLeftRowBold = workbook.CreateCellStyle();
            cellStyleLeftRowBold.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowBold.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowBold.Alignment = HorizontalAlignment.Left;
            cellStyleLeftRowBold.VerticalAlignment = VerticalAlignment.Center;
            cellStyleLeftRowBold.SetFont(fontRowBold);
            cellStyleLeftRowBold.WrapText = true;
            // Normal left row bold with color
            cellStyleLeftRowBoldColor = workbook.CreateCellStyle();
            cellStyleLeftRowBoldColor.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowBoldColor.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cellStyleLeftRowBoldColor.Alignment = HorizontalAlignment.Left;
            cellStyleLeftRowBoldColor.VerticalAlignment = VerticalAlignment.Center;
            cellStyleLeftRowBoldColor.SetFont(fontRowBold);
            cellStyleLeftRowBoldColor.WrapText = true;
            cellStyleLeftRowBoldColor.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cellStyleLeftRowBoldColor.FillPattern = FillPattern.SolidForeground;
            // end of all row
            cellStyleRowEnd = workbook.CreateCellStyle();
            cellStyleRowEnd.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            //cellStyleRowEnd.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            //cellStyleRowEnd.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            //cellStyleRowEnd.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            //cellStyleRowEnd.Alignment = HorizontalAlignment.Center;
            //cellStyleRowEnd.VerticalAlignment = VerticalAlignment.Center;
            //cellStyleRowEnd.SetFont(fontRow);
            //cellStyleRowEnd.WrapText = true;
        }
        private string[] getMonth(int data)
        {
            string[] month = new string[2] { "", "" };
            switch (data)
            {
                case 1:
                    month = new string[2] { "มกราคม", "ม.ค." };
                    break;
                case 2:
                    month = new string[2] { "กุมพาพันธ์", "ก.พ." };
                    break;
                case 3:
                    month = new string[2] { "มีนาคม", "ม.ค." };
                    break;
                case 4:
                    month = new string[2] { "เมษายน", "เม.ย." };
                    break;
                case 5:
                    month = new string[2] { "พฤษภาคม", "พ.ค." };
                    break;
                case 6:
                    month = new string[2] { "มิถุนายน", "มิ.ย" };
                    break;
                case 7:
                    month = new string[2] { "กรกฎาคม", "ก.ค." };
                    break;
                case 8:
                    month = new string[2] { "สิงหาคม", "ส.ค." };
                    break;
                case 9:
                    month = new string[2] { "กันยายน", "ก.ย." };
                    break;
                case 10:
                    month = new string[2] { "ตุลาคม", "ต.ค." };
                    break;
                case 11:
                    month = new string[2] { "พฤศจิกายน", "พ.ย." };
                    break;
                case 12:
                    month = new string[2] { "ธันวาคม", "ธ.ค." };
                    break;

            }
            return month;
        }
        // Gen Function 
        string pname = "";
        string pbudget = "";
        string pyear = "";
        int pperiod;
        string[] mpname;
        string[] mfname;
        string[] mlname;
        string[] cpname;
        string[] cfname;
        string[] clname;
        int miter = 1;
        int citer = 1;
        string contract_num = "";
        string date_start = "";
        string date_end = "";
        DateTime date_start_dateFormat;
        DateTime date_end_dateFormat;
        DateTime date_start_dateFormat_plus1;
        string[] periodDay;
        string[] periodMoney;
        string[] periodDate;
        string[] periodDetail;
        int periodCount_ = 0;
        //string[,] DocDoc;
        //string[,] docType;
        //int[,] docNum;
        List<string>[] docDoc;
        List<string>[] docType;
        List<int>[] docNo;
        int DocIter = 0;
        int[] itemCount;
        private void genformExcel()
        {
            #region Initial
            initialXSSFWorkbook();
            initialFontStyle();
            initialsCellStyle();
            DataTable dt = new DataTable();
            dt.Columns.Add("ที่", typeof(string));
            dt.Columns.Add("คณะกรรมการตรวจสอบการจ้าง", typeof(string));
            dt.Columns.Add("เบอร์โทร ธก./สายตรง", typeof(string));
            dt.Columns.Add("มือถือ", typeof(string));
            dt.Columns.Add("ผู้รับจ้าง", typeof(string));
            dt.Columns.Add("จำนวนงวด และผลการดำเนินงาน", typeof(string));
            dt.Columns.Add("ระยะเวลา วัน", typeof(string));
            dt.Columns.Add("เงินงวด", typeof(string));
            dt.Columns.Add("วันส่งมอบงาน", typeof(string));
            dt.Columns.Add("ขยายเวลา", typeof(string));
            dt.Columns.Add("หมายเหตุ", typeof(string));

            sheet.SetColumnWidth(0, 914);
            sheet.SetColumnWidth(1, 11450);
            sheet.SetColumnWidth(2, 7135);
            sheet.SetColumnWidth(3, 3700);
            sheet.SetColumnWidth(4, 10425);
            sheet.SetColumnWidth(5, 21760);
            sheet.SetColumnWidth(6, 2193);
            sheet.SetColumnWidth(7, 5000);
            sheet.SetColumnWidth(8, 5000);
            sheet.SetColumnWidth(9, 3475);
            sheet.SetColumnWidth(10, 7135);
            #endregion
            #region <<<<<<Database Query>>>>>>>

            NHADATABASEEntities1 db = new NHADATABASEEntities1();
            //int id = Int32.Parse(ViewState["project_id"].ToString());
            int id = Int32.Parse(ViewState["project_id"].ToString());
            var query = db.Select_Project(id);
            if (query != null)
            {
                foreach (var item in query.ToList())
                {
                    pname = item.project_name;
                    pbudget = ((double)item.project_budget).ToString("n2");
                    pyear = item.year.ToString();
                    pperiod = (Int32)item.period;
                }
            }


            var query1 = db.Committee_Select_check(id);
            if (query1 != null)
            {
                foreach (var item in query1.ToList())
                {
                    miter++;
                }
                mpname = new string[miter];
                mfname = new string[miter];
                mlname = new string[miter];
            }
            query1 = db.Committee_Select_check(id);
            if (query1 != null)
            {
                int i = 0;
                foreach (var item in query1.ToList())
                {
                    mpname[i] = item.pname;
                    mfname[i] = item.first_name;
                    mlname[i] = item.last_name;
                    i++;
                }
            }

            var query2 = db.Committee_Select_employ(id);
            if (query2 != null)
            {
                foreach (var item in query2.ToList())
                {
                    citer++;
                }
                cpname = new string[citer];
                cfname = new string[citer];
                clname = new string[citer];
            }
            query2 = db.Committee_Select_employ(id);
            if (query2 != null)
            {
                int i = 0;
                foreach (var item in query2.ToList())
                {
                    cpname[i] = item.pname;
                    cfname[i] = item.first_name;
                    clname[i] = item.last_name;
                    i++;
                }
            }
            var queryContract = db.GenExcel_select_contract(id);
            {
                foreach (var item in queryContract.ToList())
                {
                    contract_num = item.contract_id;
                    date_start = item.day_contract.ToString();
                    date_end = item.day_end;
                }
            }
            date_start_dateFormat = DateTime.ParseExact(date_start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            date_end_dateFormat = DateTime.ParseExact(date_end, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            date_start_dateFormat_plus1 = DateTime.ParseExact(date_start, "yyyy-MM-dd", CultureInfo.InvariantCulture).AddDays(1);
            //date_start_dateFormat_plus1 = date_start_dateFormat.AddDays(1);
            string[] ds_arr = date_start.Split('-');
            string[] de_arr = date_end.Split('-');
            string[] ds_arr1 = date_start_dateFormat_plus1.Date.ToShortDateString().Split('/');
            var queryPeriod = db.GenExcel_select_period_detail(id);
            if (queryPeriod != null)
            {
                foreach (var item in queryPeriod.ToList())
                {
                    periodCount_++;
                }
                periodDay = new string[periodCount_];
                periodDate = new string[periodCount_];
                periodMoney = new string[periodCount_];
                periodDetail = new string[periodCount_];
            }
            queryPeriod = db.GenExcel_select_period_detail(id);
            if (queryPeriod != null)
            {
                int i = 0;
                foreach (var item in queryPeriod.ToList())
                {
                    periodDay[i] = item.day_period.ToString();
                    periodDate[i] = item.date_period.ToString();
                    periodMoney[i] = item.money.ToString();
                    periodDetail[i] = item.detail;
                    i++;
                    //periodCount_ = i;
                }
            }
            var queryDoc = db.GenExcel_select_document_period(id);
            if (queryDoc != null)
            {
                foreach (var item in queryDoc.ToList())
                {
                    DocIter++;
                }

                //DocDoc = new string[periodCount_, DocIter];
                //docType = new string[periodCount_, DocIter];
                //docNum = new int[periodCount_, DocIter];
            }
            docDoc = new List<string>[periodCount_];
            docType = new List<string>[periodCount_];
            docNo = new List<int>[periodCount_];
            for (int i = 0; i < periodCount_; i++)
            {
                docDoc[i] = new List<string>();
                docType[i] = new List<string>();
                docNo[i] = new List<int>();
            }
            queryDoc = db.GenExcel_select_document_period(id);
            if (queryDoc != null)
            {
                itemCount = new int[periodCount_];
                for (int i = 0; i < periodCount_; i++)
                {

                    queryDoc = db.GenExcel_select_document_period(id);
                    foreach (var item in queryDoc.ToList())
                    {
                        if (i == Int32.Parse(item.period))
                        {
                            docDoc[i].Add(item.doc);
                            docType[i].Add(item.type);
                            docNo[i].Add(Int32.Parse(item.number));
                            itemCount[i]++;
                        }
                    }
                }
            }


            #endregion
            if (ds_arr[2][0] == '0')
            {
                ds_arr[2] = ds_arr[2].Replace('0', ' ');
            }
            if (de_arr[2][0] == '0')
            {
                de_arr[2] = de_arr[2].Replace('0', ' ');
            }
            // Rows First (Column Header)
            dt.Rows.Add(null, null, null, null, null, pname, null, null, null, null, null);
            dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null);
            dt.Rows.Add("งบประมาณจัดจ้าง          " + pbudget + ".-", null, "บาท", "ใช้งบทำการปี " + pyear, null, null, null, null, null, null, null);
            dt.Rows.Add("สัญญาเลขที่ " + contract_num + " ลว. " + ds_arr[2] + " " + getMonth(Int32.Parse(ds_arr[1]))[1] + " " + ds_arr[0] + " (" + pperiod + " วัน)"
                , null, null, "เริ่มสัญญาวันที่  " + ds_arr1[1] + " " + getMonth(Int32.Parse(ds_arr1[0]))[0] + " " + ds_arr1[2] + " ถึงวันที่  " + de_arr[2] + " " + getMonth(Int32.Parse(de_arr[1]))[0] + " " + de_arr[0],
                null, null, null, null, null, "รหัสผู้ขาย:", "");

            for (int i = 0; i < 5; i++)
            {
                //dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null);
                IRow row1 = sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    // Row 0

                    if (i == 0)
                    {
                        if (j == 5)
                        {
                            String columnName = dt.Columns[j].ToString();
                            cell.CellStyle = cellStyleProjHeader;
                            cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        }
                    }
                    // Row 2/3
                    if (i == 2)
                    {
                        String columnName = dt.Columns[j].ToString();
                        cell.CellStyle = cellStyleProj;
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        if (j == 2)
                        {

                        }
                    }

                    if (i == 3)
                    {
                        String columnName = dt.Columns[j].ToString();
                        cell.CellStyle = cellStyleProj;
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    // Row 4
                    if (i == 4)
                    {
                        //ICell cell = row1.CreateCell(i);
                        String columnName = dt.Columns[j].ToString();
                        cell.SetCellValue(columnName);

                        if (j == 1)
                        {
                            // Set Background ??
                            cell.CellStyle = cellStyleHeaderColor;
                        }
                        else
                        {
                            cell.CellStyle = cellStyleHeader;
                        }
                    }
                }
            }

            // For test purpose
            tempData(dt);

            // Export 
            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "GenExcel.xlsx"));
                Response.BinaryWrite(exportData.ToArray());
                Response.End();
            }
        }
        #region <<<<<<<<<<<<New>>>>>>>>>>>>

        public List<string> returnStringToArray(string sometxt)
        {
            List<string> strList = new List<string>();
            int temp = 0;
            string tmpStr = "";
            int strlongcut = 90;
            while (sometxt.Length % strlongcut != 0)
            {
                sometxt += " ";
            }
            string w = sometxt;
            for (int i = 0; i < sometxt.Length; i++)
            {

                tmpStr += sometxt[i];
                if (tmpStr.Length % strlongcut == 0)
                {
                    strList.Add(tmpStr);
                    tmpStr = "";
                    temp++;
                }
            }
            return strList;
        }

        #endregion
        private void tempData(DataTable dt)
        {
            #region <<<<<<<<<My Test Region >>>>>>>>>>>>>
            List<string> perioddata = new List<string>();

            // จำนวนงวดงาน

            //int periodCount = periodCount_;
            int periodCount = periodCount_;
            // จำนวนคณะกรรมการตรวจการจ้าง
            int committeeNo = miter;
            // Column จำนวนงวดงาน only
            // จำนวนบรรทัดเนื้องาน
            int task = 0;
            int sumRow = 0;
            int fileRow = 0;
            int loopCount = 0;
            int finalRowCount = 0;
            #endregion
            int temp_miter = 0;
            int temp_citer = 0;
            int tempDocIter = 0;
            for (int p = 0; p < periodCount; p++)
            {
                //perioddata = returnStringToArray(testString(p));
                perioddata = returnStringToArray(periodDetail[p]);
                task = perioddata.Count;
                //fileRow = task + 12;
                fileRow = task + 6 + itemCount[p];
                loopCount = fileRow + 4 + sumRow;

                tempDocIter = 0;
                for (int i = 4 + sumRow; i <= loopCount; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 5; j < 6; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        // งวดงาน
                        if (i == 4 + sumRow)
                        {
                            int temp = p + 1;
                            cell.SetCellValue("งวดที่ " + temp);
                            cell.CellStyle = cellStyleLeftRowBoldColor;
                        }
                        // เนื้องาน and เอกสาร
                        else if (i == 5 + sumRow)
                        {
                            cell.SetCellValue("เนื้องาน");
                            cell.CellStyle = cellStyleLeftRowUnderline;
                        }
                        else if (5 + sumRow < i && i < 5 + task + 2 + sumRow)
                        {
                            if (i == 6 + sumRow)
                            {
                                string tmp = "";
                                foreach (var item in perioddata)
                                {
                                    tmp += item;
                                }
                                cell.SetCellValue(tmp);
                                int thisRow = i;
                                CellRangeAddress m = new CellRangeAddress(thisRow + 1, thisRow + task, 5, 5);
                                sheet.AddMergedRegion(m);
                            }
                            cell.CellStyle = cellStyleLeftRow;
                        }
                        else if (i == 5 + task + 2 + sumRow)
                        {
                            cell.SetCellValue("เอกสาร");
                            cell.CellStyle = cellStyleLeftRowUnderline;
                        }
                        // ส่งมอบ ณ ...
                        else if (i == 5 + task + 3 + sumRow)
                        {
                            cell.SetCellValue("ส่งมอบ ณ วันครบกำหนดตามสัญญา    /   หลังประชุมพิจารณาของคณะกรรมการ");
                            cell.CellStyle = cellStyleLeftRowBold;
                        }
                        else
                        {
                            if (tempDocIter >= DocIter)
                            {
                                cell.SetCellValue("");
                            }
                            else
                            {
                                if (tempDocIter >= itemCount[p])
                                {

                                }
                                else
                                {
                                    cell.SetCellValue(" - " + docDoc[p][tempDocIter] + " ประเภท " + docType[p][tempDocIter] + " จำนวน " + docNo[p][tempDocIter] + " ชุด");
                                    tempDocIter++;
                                }
                                //cell.SetCellValue(" - " + DocDoc[p, tempDocIter] + " ประเภท " + docType[p, tempDocIter] + " จำนวน " + docNum[p, tempDocIter] + " ชุด");
                                //loopCount++;
                            }
                            cell.CellStyle = cellStyleLeftRow;
                        }
                    }

                }
                // ระยะเวลาวัน - หมายเหตุ
                for (int i = 4 + sumRow; i <= loopCount; i++)
                {
                    IRow row = sheet.GetRow(i + 1);
                    for (int j = 6; j < 11; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        // ระยะเวลาวัน, วันส่งมอบงาน
                        if (j == 6)
                        {
                            if (i == 4 + sumRow)
                            {
                                cell.SetCellValue(periodDay[p]);
                                //cell.SetCellValue("<ระยะเวลา>");
                                cell.CellStyle = cellStyleMediumRow;
                            }
                            else if (i == 7 + sumRow)
                            {
                                cell.SetCellValue("ประมาณแผนการดำเนินงานตรวจรับงาน");
                                cell.CellStyle = cellStyleMediumRowColorBorder;
                            }
                            else
                            {
                                cell.CellStyle = cellStyleMediumRow;
                            }

                        }
                        else if (j == 7)
                        {
                            if (i == 4 + sumRow)
                            {
                                cell.SetCellValue(double.Parse(periodMoney[p]).ToString("N2"));
                                //cell.SetCellValue("<จำนวนเงินงวด>");
                                cell.CellStyle = cellStyleRightRow;
                            }
                            else if (i == 7 + sumRow)
                            {
                                cell.CellStyle = cellStyleMediumRowColorBorder;
                            }
                            else
                            {
                                cell.CellStyle = cellStyleMediumRow;
                            }
                        }
                        else if (j == 8)
                        {
                            if (i == 4 + sumRow)
                            {
                                string[] splitperiod = periodDate[p].Split(' ');
                                //DateTime thisDate = DateTime.ParseExact("10-20-2017", "MM-dd-yyyy", CultureInfo.InvariantCulture);
                                string[] split = splitperiod[0].Split('/');
                                cell.SetCellValue(split[1] + " " + getMonth(Int32.Parse(split[0]))[1] + " " + split[2]);
                                //Scell.SetCellValue("<วัน เดือน ปี>");
                                //cell.SetCellValue(periodDate[p]);
                                cell.CellStyle = cellStyleMediumRow;
                            }
                            if (i == 5 + sumRow)
                            {
                                //cell.SetCellValue("<วัน>");
                                cell.CellStyle = cellStyleMediumRow;
                            }
                            else if (i == 7 + sumRow)
                            {
                                cell.CellStyle = cellStyleMediumRowColorBorder;
                            }
                            else if (i == 8 + sumRow)
                            {
                                cell.SetCellValue("ระหว่างวันที่");
                                cell.CellStyle = cellStyleMediumRowColor;
                            }
                            else if (i == 9 + sumRow /*|| i == 9 + sumRow + 1*/)
                            {
                                string[] temp = periodDate[p].Split(' ');

                                //DateTime temp = new DateTime(Int32.Parse(tmpPeriod2[2]), Int32.Parse(tmpPeriod2[1]), Int32.Parse(tmpPeriod[0]));
                                //temp.AddDays(7);
                                DateTime datePlus0 = DateTime.ParseExact(temp[0], "M/d/yyyy", CultureInfo.InvariantCulture);
                                DateTime datePlus7 = DateTime.ParseExact(temp[0], "M/d/yyyy", CultureInfo.InvariantCulture).AddDays(7);
                                string[] split0 = datePlus0.ToString().Split('/');
                                string[] split7 = datePlus7.ToString().Split('/');
                                string[] split7year = split7[2].Split(' ');
                                if (split0[0] == split7[0])
                                {
                                    cell.SetCellValue(split0[1] + "-" + split7[1] + " " + getMonth(Int32.Parse(split7[0]))[1] + " " + split7year[0]/*split7[2]*/);

                                }
                                else
                                {
                                    cell.SetCellValue(split0[1] + " " + getMonth(Int32.Parse(split0[0]))[1] + "-" + split7[1] + " " + getMonth(Int32.Parse(split7[0]))[1] + split7year[0]);

                                }
                                //cell.SetCellValue(split[1] + " " + getMonth(Int32.Parse(split[0]))[1] + " " + split[2]);
                                //cell.SetCellValue(""); //<ระหว่างวัน>
                                cell.CellStyle = cellStyleMediumRowColor;
                            }
                            else
                            {
                                cell.CellStyle = cellStyleMediumRow;
                            }
                        }
                        else if (j == 10)
                        {
                            if (i == 4 + sumRow)
                            {
                                cell.SetCellValue("หนังสือนำส่ง");
                            }
                            if (i == 6 + sumRow)
                            {
                                cell.SetCellValue("วันตรวจรับ");
                            }
                            if (i == 8 + sumRow)
                            {
                                cell.SetCellValue("วันที่นักวิจัยรับเงิน");
                            }
                            if (i == 10 + sumRow)
                            {
                                cell.SetCellValue("วันออกเช็ค");
                            }
                            cell.CellStyle = cellStyleLeftRow;
                        }
                        else
                        {
                            cell.CellStyle = cellStyleMediumRow;
                        }
                    }
                }

                CellRangeAddress merge = new CellRangeAddress(8 + sumRow, 8 + sumRow, 6, 8);
                sheet.AddMergedRegion(merge);
                finalRowCount = loopCount + 1;
                //fileRow = fileRow + tempDocIter;
                sumRow = sumRow + fileRow;
            }

            // Column ที่ - ผู้รับจ้าง
            for (int i = 4; i <= loopCount; i++)
            {
                IRow row = sheet.GetRow(i + 1);
                for (int j = 0; j < 5; j++)
                {
                    ICell cell = row.CreateCell(j);

                    if (i > committeeNo + (3 /*+ 4*/))
                    {
                        if (j == 0)
                        {
                            if (i > committeeNo + (3 /*+ 4*/) + 1)
                            {
                                if (temp_citer + 1 >= citer)
                                {
                                    cell.SetCellValue("");
                                }
                                else
                                {
                                    cell.SetCellValue(temp_citer + 1);
                                    // temp_citer++;
                                }
                                cell.CellStyle = cellStyleMediumRow;
                            }
                        }
                        if (j == 1)
                        {
                            if (i == committeeNo + (3 /*+ 4*/) + 1)
                            {
                                cell.SetCellValue("คณะกรรมการจัดจ้าง");
                                cell.CellStyle = cellStyleHeaderColor;
                            }
                            else
                            {
                                if (temp_citer >= citer)
                                {
                                    cell.SetCellValue("");
                                }
                                else
                                {
                                    cell.SetCellValue(cpname[temp_citer] + cfname[temp_citer] + "  " + clname[temp_citer]);
                                    temp_citer++;

                                }
                                cell.CellStyle = cellStyleLeftRow;
                            }
                        }
                        if (j == 2)
                        {
                            cell.SetCellValue(""); // tel2
                            cell.CellStyle = cellStyleMediumRow;
                            if (i == committeeNo + (2 + 4) + 1)
                            {
                                cell.SetCellValue("");
                            }
                        }
                        if (j == 3)
                        {
                            cell.SetCellValue(""); // phone2
                            cell.CellStyle = cellStyleMediumRow;
                            if (i == committeeNo + (2 + 4) + 1)
                            {
                                cell.SetCellValue("");
                            }
                        }
                        if (j == 4)
                        {
                            cell.SetCellValue(""); //place2
                            cell.CellStyle = cellStyleLeftRow;
                            if (i == committeeNo + (2 + 4) + 1)
                            {
                                cell.SetCellValue("");
                            }
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            if (temp_miter + 1 >= miter)
                            {
                                cell.SetCellValue("");
                            }

                            else
                            {
                                cell.SetCellValue(temp_miter + 1);
                            }
                            cell.CellStyle = cellStyleMediumRow;
                        }
                        if (j == 1)
                        {


                            if (temp_miter >= miter)
                            {
                                cell.SetCellValue("");
                            }
                            else
                            {
                                cell.SetCellValue(mpname[temp_miter] + mfname[temp_miter] + "  " + mlname[temp_miter]); // <name>
                                temp_miter++;
                            }
                            cell.CellStyle = cellStyleLeftRow;
                        }
                        if (j == 2)
                        {
                            cell.SetCellValue("");// tel
                            cell.CellStyle = cellStyleMediumRow;
                        }
                        if (j == 3)
                        {
                            cell.SetCellValue("");// phone
                            cell.CellStyle = cellStyleMediumRow;
                        }
                        if (j == 4)
                        {
                            cell.SetCellValue("");// place
                            cell.CellStyle = cellStyleLeftRow;
                        }
                    }
                }
            }

            IRow finalrow = sheet.GetRow(loopCount + 1);
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                ICell cell = finalrow.CreateCell(j);
                cell.CellStyle = cellStyleRowEnd;
            }
        }
    }
}