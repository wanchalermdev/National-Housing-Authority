using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Test.SuperPowerAdmin
{
    public partial class CreateBudget : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBudgets();
            //TxtYear.Text = DateTime.Now.Year.ToString();
        }

        private void LoadBudgets()
        {
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                gvBudget.DataSource = db.SP_SuperPowerAdmin_Budget_Select();
                gvBudget.DataBind();
            }
        }

        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
                {
                    int year = Int32.Parse(TxtYear.Text.ToString());
                    decimal budget = decimal.Parse(TxtBudget.Text.ToString());
                    System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                    db.SP_SuperPowerAdmin_Budget_Create(year, budget, result);
                    //Label3.Text = result.Value.ToString();
                    LoadBudgets();
                    TxtYear.Text = "";
                    TxtBudget.Text = "";
                }

            }
        }

        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("HomeCreateProject.aspx");
        }



        protected void gvBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string check = e.CommandName.ToString();
            int index = (Convert.ToInt32(e.CommandArgument));
            GridViewRow row = gvBudget.Rows[index];
            string year = row.Cells[0].Text;

            if (check == "edit")
            {
                Response.Redirect("EditBudget.aspx?year=" + year);
            }
            else if (check == "delete")
            {
                db.SP_SuperPowerAdmin_Budget_Delete(Int32.Parse(year));
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
        // Variables สำหรับ Excel
        private IWorkbook workbook;
        private IFont font_Header, font_Row;
        private ISheet sheet;
        private ICellStyle cs_header_bold, cs_row_left, cs_row_right, cs_row_center;
        // กำหนด Sheet
        private void initial_XSSFWorkbook()
        {
            workbook = new XSSFWorkbook();
            sheet = workbook.CreateSheet("Sheet1");

        }
        // กำหนด Font ที่จะใช้
        void initial_Font()
        {
            font_Header = workbook.CreateFont();
            font_Header.FontName = "TH SarabunPSK";
            font_Header.FontHeightInPoints = 16;
            font_Header.Boldweight = (short)FontBoldWeight.Bold;

            font_Row = workbook.CreateFont();
            font_Row.FontName = "TH SarabunPSK";
            font_Row.FontHeightInPoints = 16;
        }
        // กำหนด Style ที่จะใช้ในแต่ละ Cells
        void initial_Style()
        {
            #region header
            cs_header_bold = workbook.CreateCellStyle();
            cs_header_bold.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_header_bold.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_header_bold.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_header_bold.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_header_bold.Alignment = HorizontalAlignment.Center;
            cs_header_bold.VerticalAlignment = VerticalAlignment.Center;
            cs_header_bold.SetFont(font_Header);
            cs_header_bold.WrapText = true;
            cs_header_bold.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            cs_header_bold.FillPattern = FillPattern.SolidForeground;
            #endregion
            #region row
            cs_row_left = workbook.CreateCellStyle();
            cs_row_left.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_left.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_left.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_left.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_left.Alignment = HorizontalAlignment.Left;
            cs_row_left.VerticalAlignment = VerticalAlignment.Center;
            cs_row_left.SetFont(font_Row);
            cs_row_left.WrapText = true;

            cs_row_right = workbook.CreateCellStyle();
            cs_row_right.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_right.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_right.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_right.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_right.Alignment = HorizontalAlignment.Right;
            cs_row_right.VerticalAlignment = VerticalAlignment.Center;
            cs_row_right.SetFont(font_Row);
            cs_row_right.WrapText = true;

            cs_row_center = workbook.CreateCellStyle();
            cs_row_center.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_center.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_center.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_center.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
            cs_row_center.Alignment = HorizontalAlignment.Center;
            cs_row_center.VerticalAlignment = VerticalAlignment.Center;
            cs_row_center.SetFont(font_Row);
            cs_row_center.WrapText = true;
            #endregion
        }

        void GenExcel()
        {
            initial_XSSFWorkbook();
            initial_Font();
            initial_Style();

            DataTable dt = new DataTable();
            // กำหนด Column
            dt.Columns.Add("ปีงบประมาณ", typeof(string));
            dt.Columns.Add("เงินงบประมาณประจำปี", typeof(string));
            dt.Columns.Add("งบประมาณจัดสรร", typeof(string));
            dt.Columns.Add("งบประมาณคงเหลือ", typeof(string));
            // กำหนดความกว้าง Column
            sheet.SetColumnWidth(0, 5000);
            sheet.SetColumnWidth(1, 8000);
            sheet.SetColumnWidth(2, 8000);
            sheet.SetColumnWidth(3, 8000);

            int countYear = 0;
            var query = db.SP_SuperPowerAdmin_Budget_Select();
            if (query != null)
            {
                foreach (var item in query.ToList())
                {
                    countYear++;
                }
            }
            string[] yearBudget = new string[countYear];
            string[] budgetYear = new string[countYear];
            string[] budgetAllocate = new string[countYear];
            string[] budgetRemain = new string[countYear];
            query = db.SP_SuperPowerAdmin_Budget_Select();
            if (query != null)
            {
                int i = 0;
                foreach (var item in query.ToList())
                {
                    yearBudget[i] = item.year.ToString();
                    budgetYear[i] = ((double)item.budget).ToString("n2");
                    budgetAllocate[i] = ((double)item.projectBudget).ToString("n2");
                    budgetRemain[i] = ((double)item.projectBalance).ToString("n2");
                    i++;
                }
            }

            // จำนวนปีที่แสดงบนตารางหน้า Createbudget (สูงสุด 4 ปี)
            int yearCount = countYear;
            // หัว Column
            IRow rowHead = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                String columnName = dt.Columns[i].ToString();
                ICell cell = rowHead.CreateCell(i);
                cell.CellStyle = cs_header_bold;
                cell.SetCellValue(columnName);
            }
            // Row ต่อๆมา
            // i = row
            // j = column
            for (int i = 0; i < yearCount; i++)
            {
                dt.Rows.Add(yearBudget[i], budgetYear[i], budgetAllocate[i], budgetRemain[i]);
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.CellStyle = cs_row_left;
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    //if (j == 0)
                    //{
                    //    cell.CellStyle = cs_row_center;
                    //    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    //}
                    //else
                    //{
                    //    cell.CellStyle = cs_row_right;
                    //    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                    //}
                }
            }

            // นำ Data ทั้งหมด gen เข้า Excel
            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "รายงานสรุปภาพรวมงบประมาณ.xlsx"));
                Response.BinaryWrite(exportData.ToArray());
                Response.End();
            }
        }

        protected void BtnPrintOut_Click(object sender, EventArgs e)
        {
            GenExcel();
        }
    }
}