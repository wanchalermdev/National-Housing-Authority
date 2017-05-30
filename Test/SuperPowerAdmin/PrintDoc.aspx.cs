using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.SuperPowerAdmin
{
    public partial class PrintDoc : System.Web.UI.Page
    {
        private string[] projectname;
        private string[] total;
        private string yearSelect;
        private string[] oct;
        private string[] nov;
        private string[] dec;
        private string[] jan;
        private string[] feb;
        private string[] mar;
        private string[] apr;
        private string[] may;
        private string[] jun;
        private string[] jul;
        private string[] aug;
        private string[] sep;
        private double[] oct2;
        private double[] nov2;
        private double[] dec2;
        private double[] jan2;
        private double[] feb2;
        private double[] mar2;
        private double[] apr2;
        private double[] may2;
        private double[] jun2;
        private double[] jul2;
        private double[] aug2;
        private double[] sep2;


        private string checkNullValue(string value)
        {
            if (value == "0.00")
            {
                return "";
            }
            return value;
        }
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBudgetYear();
                ViewState["year"] = DateTime.Now.Year + 543;
                GvBinding(Int32.Parse(ViewState["year"].ToString()));               
            }
            int year = Int32.Parse(DdYear.SelectedItem.Text);
            GvBinding(year);

        }

        private void LoadBudgetYear()
        {
            var bgYear = from d in db.SP_SuperPowerAdmin_Budget_Select()
                         select new
                         {
                             Name = d.year,
                             Id = d.budget
                         };
            DdYear.DataTextField = "Name";
            DdYear.DataValueField = "Id";
            DdYear.DataSource = bgYear;
            DdYear.DataBind();
        }

        protected void DdYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Int32.Parse(DdYear.SelectedItem.Text);
            GvBinding(year);
        }

        private void GvBinding(int year)
        {
            gvDoc.DataSource = db.SP_BudgetPlan_Create_Report(year);
            gvDoc.DataBind();
        }

        string handleNULL(string input, int offset)
        {
            if (input == null)
            {
                if (offset == 0)
                {
                    return input = "  ";
                }
                return input = " ";
            }
            int result = Int32.Parse(input) + offset;
            return result.ToString();
        }

        protected void ButtonDownload1_Click(object sender, EventArgs e)
        {


            int year = Int32.Parse(DdYear.SelectedItem.Text);
            var getCount = db.SP_BudgetPlan_Create_Report(year);
            int i = 0;
            if (getCount != null)
            {
                foreach (var item2 in getCount.ToList())
                {
                    i++;
                }
            }

            projectname = new string[i];
            oct = new string[i];
            nov = new string[i];
            dec = new string[i];
            jan = new string[i];
            feb = new string[i];
            mar = new string[i];
            apr = new string[i];
            may = new string[i];
            jun = new string[i];
            jul = new string[i];
            aug = new string[i];
            sep = new string[i];
            oct2 = new double[i];
            nov2 = new double[i];
            dec2 = new double[i];
            jan2 = new double[i];
            feb2 = new double[i];
            mar2 = new double[i];
            apr2 = new double[i];
            may2 = new double[i];
            jun2 = new double[i];
            jul2 = new double[i];
            aug2 = new double[i];
            sep2 = new double[i];
            total = new string[i];
            var query = db.SP_BudgetPlan_Create_Report(year);

            if (query != null)
            {
                int j = 0;
                foreach (var item2 in query.ToList())
                {
                    oct[j] = checkNullValue(((double)item2.october).ToString("n2"));
                    oct2[j] = (double)item2.october;
                    nov[j] = checkNullValue(((double)item2.november).ToString("n2"));
                    nov2[j] = (double)item2.november;
                    dec[j] = checkNullValue(((double)item2.december).ToString("n2"));
                    dec2[j] = (double)item2.december;
                    jan[j] = checkNullValue(((double)item2.january).ToString("n2"));
                    jan2[j] = (double)item2.january;
                    feb[j] = checkNullValue(((double)item2.february).ToString("n2"));
                    feb2[j] = (double)item2.february;
                    mar[j] = checkNullValue(((double)item2.march).ToString("n2"));
                    mar2[j] = (double)item2.march;
                    apr[j] = checkNullValue(((double)item2.april).ToString("n2"));
                    apr2[j] = (double)item2.april;
                    may[j] = checkNullValue(((double)item2.may).ToString("n2"));
                    may2[j] = (double)item2.may;
                    jun[j] = checkNullValue(((double)item2.june).ToString("n2"));
                    jun2[j] = (double)item2.june;
                    jul[j] = checkNullValue(((double)item2.july).ToString("n2"));
                    jul2[j] = (double)item2.july;
                    aug[j] = checkNullValue(((double)item2.august).ToString("n2"));
                    aug2[j] = (double)item2.august;
                    sep[j] = checkNullValue(((double)item2.september).ToString("n2"));
                    sep2[j] = (double)item2.september;
                    double monneyBath = Convert.ToDouble(item2.total);
                    projectname[j] = item2.project_name;
                    total[j] = monneyBath.ToString("N2");
                    yearSelect = item2.year.ToString();
                    j++;
                }

            }
            #region initial
            initialXSSFWorkbook();
            initial_FontStyle();
            initial_CellStyle();
            DataTable dt = new DataTable();
            dt.Columns.Add("ลำดับที่", typeof(string));
            dt.Columns.Add("ชื่อโครงการวิจัย", typeof(string));
            dt.Columns.Add("งบ " + 1 + " ได้รับจัดสรร", typeof(string));
            dt.Columns.Add("งบ " + 2 + " ได้รับจัดสรร", typeof(string));
            dt.Columns.Add("งบ " + 3 + " ได้รับจัดสรร", typeof(string));
            dt.Columns.Add("งบ " + 4 + " ได้รับจัดสรร", typeof(string));
            dt.Columns.Add("วันทำสัญญา", typeof(string));
            dt.Columns.Add("ผู้ประสานงาน", typeof(string));
            dt.Columns.Add("จำนวนเงินทำสัญญา", typeof(string));
            dt.Columns.Add("เงินที่ตั้งกรอบ ขออนุมัติจัดจ้าง", typeof(string));
            dt.Columns.Add("ปี " + handleNULL(yearSelect, 0), typeof(string));
            dt.Columns.Add("ตค.", typeof(string));
            dt.Columns.Add("พย.", typeof(string));
            dt.Columns.Add("ธค.", typeof(string));
            dt.Columns.Add("มค.", typeof(string));
            dt.Columns.Add("กพ.", typeof(string));
            dt.Columns.Add("มีค.", typeof(string));
            dt.Columns.Add("เมย.", typeof(string));
            dt.Columns.Add("พค.", typeof(string));
            dt.Columns.Add("มิย.", typeof(string));
            dt.Columns.Add("กค.", typeof(string));
            dt.Columns.Add("สค.", typeof(string));
            dt.Columns.Add("กย.", typeof(string));
            dt.Columns.Add("ปี " + handleNULL(yearSelect, 1), typeof(string));
            dt.Columns.Add("รวมทั้งโครงการ", typeof(string));
            //ตารางควบคุมงานวิจัย / งบประมาณตาม / งบประมาณตามสัญญา / งบประมาณเบิกจริง"
            sheet.SetColumnWidth(0, 1800);
            sheet.SetColumnWidth(1, 12000);
            sheet.SetColumnWidth(2, 7135);
            sheet.SetColumnWidth(3, 7135);
            sheet.SetColumnWidth(4, 7135);
            sheet.SetColumnWidth(5, 7135);
            sheet.SetColumnWidth(6, 3700);
            sheet.SetColumnWidth(7, 3700);
            sheet.SetColumnWidth(8, 4500);
            sheet.SetColumnWidth(9, 4500);
            sheet.SetColumnWidth(10, 4500);
            sheet.SetColumnWidth(11, 4500);
            sheet.SetColumnWidth(12, 4500);
            sheet.SetColumnWidth(13, 4500);
            sheet.SetColumnWidth(14, 4500);
            sheet.SetColumnWidth(15, 4500);
            sheet.SetColumnWidth(16, 4500);
            sheet.SetColumnWidth(17, 4500);
            sheet.SetColumnWidth(18, 4500);
            sheet.SetColumnWidth(19, 4500);
            sheet.SetColumnWidth(20, 4500);
            sheet.SetColumnWidth(21, 4500);
            sheet.SetColumnWidth(22, 4500);
            sheet.SetColumnWidth(23, 4500);
            sheet.SetColumnWidth(24, 4500);
            #endregion

            // Rows First (Column Header)
            dt.Rows.Add("หมายเหตุ: ข้อมูลการจ่ายเงินงวดต่างๆของโครงการให้น้องๆเทสีเขียว/เหลือง/แดงที่ cell นั้น (แดงคือล่าช้ากว่าแผน/เหลืองคือตัดงบแล้ว/เขียวคือกรรมการลงนามครบและส่งไป พด.แล้ว) และเพิ่ม comment วันที่พด. ตัดใบ PO + เลขที่ PO +วันที่นัดตรวจรับงาน", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            dt.Rows.Add(null, "งบประมาณปี " + yearSelect, "กรณีโครงการภาคอีสานและภาคใต้ที่เราต้องทำกระบวนการตรวจรับเอง เหลืองคือตัดงบแล้วและส่งไป บช.แล้ว / เขียวคือลลินีสรุปยอดประจำเดือนให้แล้ว และเพิ่ม comment วันที่ตรวจรับงาน+วันที่FI.Doc+วันที่วช.ส่งเอกสารให้ บช.", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            dt.Rows.Add(null, "งบประมาณอนุมัติ", "", null, null, null, null, null, null, "คงเหลือรายเดือน", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            for (i = 0; i < 5; i++)
            {
                IRow row1 = sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    // Row 0

                    if (i == 0)
                    {
                        String columnName = dt.Columns[j].ToString();
                        cell.CellStyle = cs_bold_no_l;
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    // Row 1
                    if (i == 1)
                    {
                        String columnName = dt.Columns[j].ToString();
                        if (j == 1)
                        {
                            cell.CellStyle = cs_bold_no_m;
                        }
                        if (j == 2)
                        {
                            cell.CellStyle = cs_bold_no_l;
                        }
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    // Row 2
                    if (i == 2)
                    {
                        String columnName = dt.Columns[j].ToString();
                        if (j == 1)
                        {
                            cell.CellStyle = cs_bold_no_m;
                        }
                        else if (j == 6)
                        {
                            cell.CellStyle = cs_bold_no_l;
                        }
                        else
                        {
                            cell.CellStyle = cs_bold_no_r;
                        }
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    // Row 3
                    if (i == 3)
                    {
                        //ICell cell = row1.CreateCell(i);
                        String columnName = dt.Columns[j].ToString();
                        if (j >= 0 && j <= 10 || j == 23)
                        {
                            cell.SetCellValue(columnName);
                        }
                        if (j == 11)
                        {
                            cell.SetCellValue("ตารางควบคุมงานวิจัย / งบประมาณตามงาน / งบประมาณตามสัญญา / งบประมาณเบิกจริง");
                        }
                        cell.CellStyle = cs_normal_m;
                        if (j == 24)
                        {
                            cell.CellStyle = cs_normal_no_m;
                        }
                    }
                    // Row 4
                    if (i == 4)
                    {
                        String columnName = dt.Columns[j].ToString();
                        if (j >= 11 && j <= 22)
                        {
                            cell.SetCellValue(columnName);
                        }

                        cell.CellStyle = cs_normal_m;
                        if (j == 24)
                        {
                            cell.SetCellValue(columnName);
                            cell.CellStyle = cs_normal_no_m;
                        }
                    }
                }
            }
            for (i = 0; i < 11; i++)
            {
                CellRangeAddress merge = new CellRangeAddress(3, 4, i, i);
                sheet.AddMergedRegion(merge);
            }
            CellRangeAddress merge2 = new CellRangeAddress(3, 3, 11, 22);
            sheet.AddMergedRegion(merge2);
            CellRangeAddress merge3 = new CellRangeAddress(3, 4, 23, 23);
            sheet.AddMergedRegion(merge3);
            // For test purpose
            tempData2(dt);

            // Export 
            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "เอกสารรายงาน.xlsx"));
                Response.BinaryWrite(exportData.ToArray());
                Response.End();
            }
        }
        private IWorkbook workbook;
        private ISheet sheet;
        private void initialXSSFWorkbook()
        {
            workbook = new XSSFWorkbook();
            sheet = workbook.CreateSheet("Sheet1");

        }

        private IFont font_row, font_bold;
        private ICellStyle cs_normal_m, cs_normal_l, cs_normal_r
            , cs_normal_lr_m, cs_normal_lr_l, cs_normal_lr_r
            , cs_normal_g_m, cs_normal_g_l, cs_normal_g_r
            , cs_normal_no_m, cs_normal_no_l, cs_normal_no_r
            , cs_normal_no_g_m, cs_normal_no_g_l, cs_normal_no_g_r
            , cs_bold_m, cs_bold_l, cs_bold_r
            , cs_bold_no_m, cs_bold_no_l, cs_bold_no_r;
        private void initial_FontStyle()
        {
            font_row = workbook.CreateFont();
            font_row.FontName = "TH SarabunPSK";
            font_row.FontHeightInPoints = 16;

            font_bold = workbook.CreateFont();
            font_bold.FontName = "TH SarabunPSK";
            font_bold.FontHeightInPoints = 16;
            font_bold.Boldweight = (short)FontBoldWeight.Bold;

        }
        private void initial_CellStyle()
        {
            #region normal border
            cs_normal_m = workbook.CreateCellStyle();
            cs_normal_m.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_m.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_m.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_m.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_m.Alignment = HorizontalAlignment.Center;
            cs_normal_m.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_m.SetFont(font_row);
            cs_normal_m.WrapText = true;

            cs_normal_l = workbook.CreateCellStyle();
            cs_normal_l.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_l.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_l.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_l.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_l.Alignment = HorizontalAlignment.Left;
            cs_normal_l.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_l.SetFont(font_row);
            cs_normal_l.WrapText = true;

            cs_normal_r = workbook.CreateCellStyle();
            cs_normal_r.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_r.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_r.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_r.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_r.Alignment = HorizontalAlignment.Right;
            cs_normal_r.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_r.SetFont(font_row);
            cs_normal_r.WrapText = true;
            #endregion
            #region normal l-r border
            cs_normal_lr_m = workbook.CreateCellStyle();
            cs_normal_lr_m.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_m.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_m.Alignment = HorizontalAlignment.Center;
            cs_normal_lr_m.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_lr_m.SetFont(font_row);
            cs_normal_lr_m.WrapText = true;

            cs_normal_lr_l = workbook.CreateCellStyle();
            cs_normal_lr_l.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_l.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_l.Alignment = HorizontalAlignment.Left;
            cs_normal_lr_l.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_lr_l.SetFont(font_row);
            cs_normal_lr_l.WrapText = true;

            cs_normal_lr_r = workbook.CreateCellStyle();
            cs_normal_lr_r.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_r.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_lr_r.Alignment = HorizontalAlignment.Right;
            cs_normal_lr_r.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_lr_r.SetFont(font_row);
            cs_normal_lr_r.WrapText = true;
            #endregion
            #region normal border gray
            cs_normal_g_m = workbook.CreateCellStyle();
            cs_normal_g_m.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_m.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_m.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_m.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_m.Alignment = HorizontalAlignment.Center;
            cs_normal_g_m.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_g_m.SetFont(font_row);
            cs_normal_g_m.WrapText = true;
            cs_normal_g_m.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_normal_g_m.FillPattern = FillPattern.SolidForeground;

            cs_normal_g_l = workbook.CreateCellStyle();
            cs_normal_g_l.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_l.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_l.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_l.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_l.Alignment = HorizontalAlignment.Left;
            cs_normal_g_l.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_g_l.SetFont(font_row);
            cs_normal_g_l.WrapText = true;
            cs_normal_g_l.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_normal_g_l.FillPattern = FillPattern.SolidForeground;

            cs_normal_g_r = workbook.CreateCellStyle();
            cs_normal_g_r.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_r.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_r.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_r.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_normal_g_r.Alignment = HorizontalAlignment.Right;
            cs_normal_g_r.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_g_r.SetFont(font_row);
            cs_normal_g_r.WrapText = true;
            cs_normal_g_r.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_normal_g_r.FillPattern = FillPattern.SolidForeground;
            #endregion
            #region normal no border
            cs_normal_no_m = workbook.CreateCellStyle();
            cs_normal_no_m.Alignment = HorizontalAlignment.Center;
            cs_normal_no_m.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_m.SetFont(font_row);
            cs_normal_no_m.WrapText = true;

            cs_normal_no_l = workbook.CreateCellStyle();
            cs_normal_no_l.Alignment = HorizontalAlignment.Left;
            cs_normal_no_l.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_l.SetFont(font_row);
            cs_normal_no_l.WrapText = true;

            cs_normal_no_r = workbook.CreateCellStyle();
            cs_normal_no_r.Alignment = HorizontalAlignment.Right;
            cs_normal_no_r.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_r.SetFont(font_row);
            cs_normal_no_r.WrapText = true;
            #endregion
            #region normal no border with gray
            cs_normal_no_g_m = workbook.CreateCellStyle();
            cs_normal_no_g_m.Alignment = HorizontalAlignment.Center;
            cs_normal_no_g_m.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_g_m.SetFont(font_row);
            cs_normal_no_g_m.WrapText = true;
            cs_normal_no_g_m.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_normal_no_g_m.FillPattern = FillPattern.SolidForeground;

            cs_normal_no_g_l = workbook.CreateCellStyle();
            cs_normal_no_g_l.Alignment = HorizontalAlignment.Left;
            cs_normal_no_g_l.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_g_l.SetFont(font_row);
            cs_normal_no_g_l.WrapText = true;
            cs_normal_no_g_l.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_normal_no_g_l.FillPattern = FillPattern.SolidForeground;

            cs_normal_no_g_r = workbook.CreateCellStyle();
            cs_normal_no_g_r.Alignment = HorizontalAlignment.Right;
            cs_normal_no_g_r.VerticalAlignment = VerticalAlignment.Center;
            cs_normal_no_g_r.SetFont(font_row);
            cs_normal_no_g_r.WrapText = true;
            cs_normal_no_g_r.FillForegroundColor = IndexedColors.Grey50Percent.Index;
            cs_normal_no_g_r.FillPattern = FillPattern.SolidForeground;
            #endregion
            #region bold border
            cs_bold_m = workbook.CreateCellStyle();
            cs_bold_m.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_m.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_m.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_m.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_m.Alignment = HorizontalAlignment.Center;
            cs_bold_m.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_m.SetFont(font_bold);
            cs_bold_m.WrapText = true;

            cs_bold_l = workbook.CreateCellStyle();
            cs_bold_l.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_l.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_l.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_l.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_l.Alignment = HorizontalAlignment.Left;
            cs_bold_l.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_l.SetFont(font_bold);
            cs_bold_l.WrapText = true;

            cs_bold_r = workbook.CreateCellStyle();
            cs_bold_r.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_r.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_r.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_r.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_bold_r.Alignment = HorizontalAlignment.Right;
            cs_bold_r.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_r.SetFont(font_bold);
            cs_bold_r.WrapText = true;
            #endregion
            #region bold no border
            cs_bold_no_m = workbook.CreateCellStyle();
            cs_bold_no_m.Alignment = HorizontalAlignment.Center;
            cs_bold_no_m.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_no_m.SetFont(font_bold);
            //cs_bold_no_m.WrapText = true;

            cs_bold_no_l = workbook.CreateCellStyle();
            cs_bold_no_l.Alignment = HorizontalAlignment.Left;
            cs_bold_no_l.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_no_l.SetFont(font_bold);
            //cs_bold_no_l.WrapText = true;

            cs_bold_no_r = workbook.CreateCellStyle();
            cs_bold_no_r.Alignment = HorizontalAlignment.Right;
            cs_bold_no_r.VerticalAlignment = VerticalAlignment.Center;
            cs_bold_no_r.SetFont(font_bold);
            //cs_bold_no_r.WrapText = true;
            #endregion
        }
        private void tempData2(DataTable dt)
        {
            int projectNum = projectname.Length;
            double sumTotal = 0;
            double sumOct = 0;
            double sumNov = 0;
            double sumDec = 0;
            double sumJan = 0;
            double sumFeb = 0;
            double sumMar = 0;
            double sumApr = 0;
            double sumMay = 0;
            double sumJun = 0;
            double sumJul = 0;
            double sumAug = 0;
            double sumSep = 0;
            for (int i = 4; i < projectNum + 4; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                dt.Rows.Add(i - 3, projectname[i - 4], "", "", "", "", "", "", total[i - 4], "", "", oct[i - 4], nov[i - 4], dec[i - 4], jan[i - 4], feb[i - 4], mar[i - 4], apr[i - 4], may[i - 4], jun[i - 4], jul[i - 4], oct[i - 4], sep[i - 4], "", total[i - 4]);
                sumTotal = sumTotal + double.Parse(total[i - 4]);
                sumOct = sumOct + oct2[i - 4];
                sumNov = sumNov + nov2[i - 4];
                sumDec = sumDec + dec2[i - 4];
                sumJan = sumJan + jan2[i - 4];
                sumFeb = sumFeb + feb2[i - 4];
                sumMar = sumMar + mar2[i - 4];
                sumApr = sumApr + apr2[i - 4];
                sumMay = sumMay + may2[i - 4];
                sumJun = sumJun + jun2[i - 4];
                sumJul = sumJul + jul2[i - 4];
                sumAug = sumAug + aug2[i - 4];
                sumSep = sumSep + sep2[i - 4];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);

                    String columnName = dt.Columns[j].ToString();
                    if (j == 0 || j == 3 || j == 4)
                    {
                        cell.CellStyle = cs_normal_m;
                    }
                    else if (j == 1)
                    {
                        cell.CellStyle = cs_normal_l;
                    }
                    else if (j == 24)
                    {
                        cell.CellStyle = cs_normal_no_g_r;
                    }
                    else
                    {
                        cell.CellStyle = cs_normal_r;
                    }
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }
            for (int i = projectNum + 4; i < projectNum + 7; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                //dt.Rows.Add(null, null, "123", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0");
                dt.Rows.Add(null, null, "", "", "", "", "", "", sumTotal.ToString("n2"), null, null, sumOct.ToString("n2"), sumNov.ToString("n2"), sumDec.ToString("n2"), sumJan.ToString("n2"), sumFeb.ToString("n2"), sumMar.ToString("n2"), sumApr.ToString("n2"), sumMay.ToString("n2"), sumJun.ToString("n2"), sumJul.ToString("n2"), sumAug.ToString("n2"), sumSep.ToString("n2"), "", sumTotal.ToString("n2"));
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);

                    String columnName = dt.Columns[j].ToString();
                    if (i == projectNum + 4 || i == projectNum + 5)
                    {
                        cell.CellStyle = cs_normal_r;
                    }
                    if (i == projectNum + 6)
                    {
                        if (j == 0 || j == 1)
                        {
                            // Do nothing
                        }
                        else
                        {
                            //cell.SetCellValue(dt.Rows[i][columnName].ToString());
                            cell.CellStyle = cs_normal_r;
                        }
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    if (j == 24)
                    {
                        cell.CellStyle = cs_normal_no_g_r;
                    }
                    //cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }
            for (int i = projectNum + 7; i < projectNum + 17; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                //dt.Rows.Add("temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0", "temp0");
                for (int j = 10; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);

                    String columnName = dt.Columns[j].ToString();
                    if (i == projectNum + 7)
                    {
                        continue;
                    }
                    else if (i == projectNum + 8)
                    {
                        if (j == 10)
                        {
                            cell.SetCellValue("ค่าบริหารโครงการ");
                            cell.CellStyle = cs_bold_no_m;
                        }
                        if (j >= 11 && j <= 22)
                        {
                            cell.SetCellValue(columnName);
                            cell.CellStyle = cs_normal_m;
                        }
                        continue;
                    }
                    else if (i >= projectNum + 9 && i <= projectNum + 14)
                    {
                        if (j == 10)
                        {
                            if (i == projectNum + 9) cell.SetCellValue("ค่าดำเนินการ");
                            if (i == projectNum + 10) cell.SetCellValue("ศวพ.");
                            if (i == projectNum + 11) cell.SetCellValue("ฟม.");
                            if (i == projectNum + 12) cell.SetCellValue("วพ. (1)ค่าดำเนินการ");
                            if (i == projectNum + 13) cell.SetCellValue("    (2)ค่าวัสดุสำนักงาน");
                            if (i == projectNum + 14) cell.SetCellValue("    (3)ค่าล่วงเวลาลูกจ้าง");
                            cell.CellStyle = cs_normal_lr_l;
                        }
                        else if (j >= 11 && j <= 23)
                        {
                            cell.CellStyle = cs_normal_lr_r;
                            cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        }
                        else
                        {
                            cell.CellStyle = cs_normal_no_g_r;
                            cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        }
                    }
                    else
                    {
                        if (j == 10)
                        {
                            continue;
                        }
                        else if (j == 24)
                        {
                            cell.CellStyle = cs_normal_no_g_r;
                        }
                        else
                        {
                            cell.CellStyle = cs_normal_g_r;
                        }
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    }
                    //cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }
            for (int i = projectNum + 17; i < projectNum + 23; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                //dt.Rows.Add(null, "temp0", null, null, null, null, null, "temp0", "temp0", "temp0", "temp0", "temp0", null, "temp0", "temp0", "temp0", null, null, null, null, null, null);
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);

                    String columnName = dt.Columns[j].ToString();
                    if (i == projectNum + 17)
                    {
                        if (j == 1) cell.SetCellValue("ค่าใช้จ่ายดำเนินการ");
                        cell.CellStyle = cs_bold_no_l;

                    }
                    if (i == projectNum + 18)
                    {
                        if (j == 13) cell.SetCellValue("FI.DOC");
                        if (j == 14) cell.SetCellValue("รหัสพนักงาน");
                        if (j == 16) cell.SetCellValue("ค.7 / เงินสดย่อย");
                        if (j == 17) cell.SetCellValue("เลขหนังสือฝ่ายอื่น");
                        if (j == 18) cell.SetCellValue("เลขของกอง วพ.");
                        cell.CellStyle = cs_bold_no_m;
                    }
                    if (i >= projectNum + 19 && i <= projectNum + 22)
                    {
                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        if (j == 1 || j == 13 || j == 14 || j == 16 || j == 17 || j == 18)
                        {
                            cell.CellStyle = cs_normal_no_l;
                        }
                        if (j == 10)
                        {
                            cell.CellStyle = cs_normal_no_r;
                        }
                        if (j == 11 || j == 12)
                        {
                            cell.CellStyle = cs_normal_no_m;
                        }
                    }
                }
            }

            //dt.Rows.Add(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }
    

    }
}