using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using WTERP.WSEXE;
using LibraryCalender;

namespace WTERP
{
    public partial class Form2ABF7 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable da;
        public Form2ABF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private static string title; // Title for Excel File tabpage 1 
        public static string SQL = ""; // for tabpage 1 report 
        public static string SQL2 = ""; // for tabpage 2 report 
        public static string SQL4 = ""; // for tabpage 4 report 
        public static string SQL3 = "";
        public static string SQL5 = "";
        public static string SQLSub = "";
        //check datetime
        string a = "";
        string b = "";
        string c = "";
        string d = "";
        string f = "";
        string g = "";
        string h = "";
        string i = "";
        string j = "";
        private void Form2ABF7_Load(object sender, EventArgs e) // Load Form Default 
        {
            loadDateTime();
        }
        void loadDateTime() // Load DateTime 
        {
            string strdate = DateTime.Now.ToString("yy/MM/dd");
            tb1.Text = strdate;
            tb2.Text = strdate;

            tb1t2.Text = strdate;

            tb2t3.Text = strdate;
            tb1t3.Text = strdate;

            txtWS_DATE_S4.Text = strdate;
            txtWS_DATE_E4.Text = strdate;
        }
        private void btnView_Click(object sender, EventArgs e) // Button View 
        {
            try
            {
                getTitle();
                if (tabControl1.SelectedIndex == 0)
                {
                    if (rdngaytatca.Checked == true)
                    {
                        procesTab0();
                    }
                    else if (rdtheongay.Checked == true)
                    {
                        procesTab1();

                    }

                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    // Procesing tabpage 2
                    procesTab2();
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    // Procesing tabpage 3
                    procesTab3();
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    // Procesing tabpage 4
                    procesTab4();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        void procesTab0() // Processing for tabpage 1 
        {

            check();
            string WS_DATE_S = conn.formatstr1(a);
            string WS_DATE_E = conn.formatstr1(b);

            if (rdbaocao.Checked == true)
            {
                // View Data Report
                SQL = "SELECT ORDB.WS_DATE,CUST.C_ANAME2 as C_NAME_E,ORDB.OR_NO,ORDB.T_NAME as BRAND,ORDB.MODEL_E,ORDB.P_NAME_E as 'MaterialName',ORDB.COLOR_E AS 'Color',ORDB.THICK,ORDB.QTY FROM ORDB as ORDB inner join CUST as CUST on ORDB.C_NO = CUST.C_NO WHERE ORDB.WS_DATE BETWEEN '" + WS_DATE_S + "' AND '" + WS_DATE_E + "'";
                typeProduct(); // Chọn Hàng báo cáo
                Form2ABF7_Report fr = new Form2ABF7_Report();
                fr.ShowDialog();
            }
            else if (rdexcel.Checked == true)
            {
                //SQL = "SELECT ORDB.WS_DATE+'-'+ORDB.NR AS 'Date',CUST.C_ANAME2 AS 'Cust.',ORDB.OR_NO AS 'PO#', ORDB.BRAND AS 'Brand', ORDB.MODEL_E AS 'Model#',ORDB.P_NAME_E + ORDB.P_NAME_C as 'MaterialName',ORDB.PATT_C AS 'Patt#', " +
                //    " ORDB.COLOR_E + ORDB.COLOR_C AS 'Color',ORDB.THICK AS 'Think',ORDB.QTY AS 'Qty',ORDB.CURRENCY AS 'Currency',ORDB.PRICE AS 'Price',ORDB.PER_S AS '%',ORDB.PURCHASER AS 'Purchaser',ORDB.GRADE AS 'Grade of Product',ORDB.ACCOUNT AS 'Accountant', " +
                //    " ORDB.SALES AS 'Businesman',ORDB.ACHI AS 'Achie Vement',ORDB.SEASON AS ' SeaSon',ORDB.DEVSTAGE AS 'Dev. Stage','' AS 'Total',ORDB.WS_DATE1 AS 'Schedule1', ORDB.SCHEDULE2 AS 'Schedule2',ORDB.WS_DATE3 AS 'Schedule3', ORDB.WS_DATE_F AS 'Finished', " +
                //    "ORDB.REMARKS AS 'Remarks',ORDB.RV_PLACE AS 'SFR#' ,ORDB.COMPOUNTS AS 'Compounts',ORDB.DESIGER AS 'Designer',CARB.BQTY AS 'OutQty',ORDB.WS_DATE FROM ORDB LEFT JOIN CARB ON ORDB.OR_NO = CARB.OR_NO AND ORDB.C_NO = CARB.C_NO LEFT JOIN CUST ON ORDB.C_NO = CUST.C_NO WHERE ORDB.WS_DATE BETWEEN '" + WS_DATE_S + "' AND '" + WS_DATE_E + "'";
                SQL = "SELECT CASE WHEN K_NO IN (3,4) THEN ORDB.WS_DATE+'-0'+ORDB.NR ELSE ORDB.WS_DATE+'-'+ORDB.NR END AS 'Date',dbo.CUST.C_NAME2 AS 'Cust.'," +
                        "ORDB.OR_NO AS 'PO#', ORDB.T_NAME AS 'Brand', ORDB.MODEL_E +' '+ ORDB.MODEL_C AS 'Model#'," +
                        "ORDB.P_NAME_E + ORDB.P_NAME_C AS 'MaterialName',ORDB.PATT_C AS 'Patt#'," +
                        "ORDB.COLOR_C + ORDB.COLOR_E AS 'Color',ORDB.THICK AS 'Think',ORDB.QTY AS 'Qty'," +
                        "ORDB.CURRENCY AS 'Currency',cast(ORDB.PRICE AS nvarchar(10)) AS 'Price',ORDB.PER_S AS '%'," +
                        "ORDB.PURCHASER AS 'Purchaser',ORDB.GRADE AS 'Grade of Product'," +
                        "ORDB.ACCOUNT AS 'Accountant',  ORDB.SALES AS 'Businesman',ORDB.ACHI AS 'Achie Vement'," +
                        "ORDB.SEASON AS ' SeaSon',ORDB.DEVSTAGE AS 'Dev. Stage','' AS 'Total',ORDB.WS_DATE1 AS 'Schedule1'," +
                        "ORDB.SCHEDULE2 AS 'Schedule2',ORDB.WS_DATE3 AS 'Schedule3', ORDB.WS_DATE_F AS 'Finished'," +
                        "ORDB.REMARKS AS 'Remarks',ORDB.RV_PLACE AS 'SFR#' ,ORDB.COMPOUNTS AS 'Compounts',ORDB.DESIGER AS 'Designer'," +
                        " 'OutQty' = (SELECT SUM(a.BQTY) AS BQTY FROM (" +
                        " SELECT CARB.WS_NO, CARB.WS_DATE, CARB.BQTY, CARH.OR_NO" +
                        " FROM CARB, CARH " +
                        " WHERE CARH.WS_NO = CARB.WS_NO AND CARB.ORD_DATE = ORDB.WS_DATE" +
                        " AND CARB.OR_NO = ORDB.OR_NO AND CARB.OR_NR = ORDB.NR" +
                        " AND CARB.K_NO = ORDB.K_NO" +
                        " UNION" +
                        " SELECT GIBB.WS_NO, GIBB.WS_DATE, GIBB.BQTY * (-1), GIBH.OR_NO" +
                        " FROM GIBB, GIBH" +
                        " WHERE GIBH.WS_NO = GIBB.WS_NO AND GIBB.WS_KIND <> 'B'" +
                        " AND GIBB.ORD_DATE = ORDB.WS_DATE AND GIBB.OR_NO = ORDB.OR_NO AND GIBB.OR_NR = ORDB.NR AND GIBB.K_NO = ORDB.K_NO)a),WS_DATE" +
                        " FROM ORDB" +
                        " LEFT JOIN CUST ON ORDB.C_NO = CUST.C_NO" +
                        " WHERE WS_DATE>= " + WS_DATE_S + " AND WS_DATE<= " + WS_DATE_E + " AND QTY> 0 ";

                if (!string.IsNullOrEmpty(tb5.Text))
                {
                    SQL = SQL + " AND BRAND like '%" + tb5.Text + "%' ";
                }
                if (!string.IsNullOrEmpty(tb6.Text))
                {
                    SQL = SQL + " AND T_NAME='" + tb6.Text + "' ";
                }
                // Extract Excel
                typeProduct2(); // Chọn Hàng báo cáo 
                da = new DataTable();
                da = conn.readdata(SQL);
                float D = 0;
                string CA = "";
                string BR = "";
                if (da.Rows.Count > 0)
                {
                    CA = da.Rows[0]["Cust."].ToString();
                    BR = da.Rows[0]["Brand"].ToString();
                    for (int i = 0; i <= da.Rows.Count - 1; i++)
                    {

                        string AA = da.Rows[i]["Cust."].ToString();
                        string Br1 = da.Rows[i]["Brand"].ToString();

                        if ((CA == AA) && (BR == Br1))
                        {
                            D = D + float.Parse(da.Rows[i]["Qty"].ToString());
                        }
                        else
                        {
                            da.Rows[i - 1]["Total"] = D.ToString();
                            CA = da.Rows[i]["Cust."].ToString();
                            BR = da.Rows[i]["Brand"].ToString();
                            //
                            D = float.Parse(da.Rows[i]["Qty"].ToString());
                        }
                        if (i == da.Rows.Count - 1)
                        {
                            da.Rows[da.Rows.Count - 1]["Total"] = D.ToString();
                        }

                    }
                    foreach (DataRow row in da.Rows)
                    {
                        if (row["OutQty"].ToString() == "")
                        {
                            row["OutQty"] = "0";
                        }

                    }
                }
                if (!string.IsNullOrEmpty(tb3.Text) || !string.IsNullOrEmpty(tb4.Text) || !string.IsNullOrEmpty(tb5.Text) || !string.IsNullOrEmpty(tb6.Text) || !string.IsNullOrEmpty(tb7.Text))
                {
                    ExportHoangTest1(da);
                }
                else
                {
                    ExportHoangTest(da);
                }
            }
        }

        private void ExportHoangTest1(DataTable da)
        {
            check();
            int ColumnsCount = 0;
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            if (da.Rows.Count > 0)
            {
                ColumnsCount = da.Columns.Count;
                int RowsCount = da.Rows.Count + 12;
                object[,] Cells = new object[RowsCount, ColumnsCount];

                int t = 0;
                //int sum = 0;
                int count1 = 0;
                int sum1 = 0;
                int colo = 0;

                Range row_header = worksheet.get_Range("A" + (t + 2), "AD" + (t + 2));
                row_header.Merge();
                row_header.Font.Name = "Times New Roman";
                row_header.Font.Size = 16;
                row_header.Font.Bold = true;
                row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row_header.VerticalAlignment = XlVAlign.xlVAlignCenter;
                row_header.ColumnWidth = 3;

                Cells[t + 1, 0] = title;
                Cells[t + 2, 0] = da.Rows[t][da.Columns.Count - 1];
                Cells[t + 3, 0] = "下單日期";
                Cells[t + 3, 1] = "客戶名稱";
                Cells[t + 3, 2] = "訂單號碼";
                Cells[t + 3, 3] = "貿易商.品牌";
                Cells[t + 3, 4] = "鞋型";
                Cells[t + 3, 5] = "材料名稱";
                Cells[t + 3, 6] = "紋路";
                Cells[t + 3, 7] = "顏色";
                Cells[t + 3, 8] = "厚度";
                Cells[t + 3, 9] = "數量";
                Cells[t + 3, 10] = "幣別";
                Cells[t + 3, 11] = "單價";
                Cells[t + 3, 12] = "";
                Cells[t + 3, 13] = "訂購人";
                Cells[t + 3, 14] = "成品級數";
                Cells[t + 3, 15] = "會計員";
                Cells[t + 3, 16] = "業務員";
                Cells[t + 3, 17] = "業績";
                Cells[t + 3, 18] = "季度";
                Cells[t + 3, 19] = "階段";
                Cells[t + 3, 20] = "合計";
                Cells[t + 3, 21] = "客戶交期";
                Cells[t + 3, 22] = "交期1";
                Cells[t + 3, 23] = "交期2";
                Cells[t + 3, 24] = "完成日期";
                Cells[t + 3, 25] = "備註";
                Cells[t + 3, 26] = "制另號";
                Cells[t + 3, 27] = "部位";
                Cells[t + 3, 28] = "設計師";
                Cells[t + 3, 29] = "已交量";

                for (int i = 0; i < ColumnsCount - 1; i++)
                    Cells[t + 4, i] = da.Columns[i].ColumnName;
                Microsoft.Office.Interop.Excel.Range HeaderRange = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[(t + 4), 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[(t + 6), ColumnsCount]));
                HeaderRange.Value2 = Cells;
                Range HeaderAll = worksheet.get_Range("A" + (t + 4), "AD" + (t + 5));
                HeaderAll.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Lavender);

                t = t + 5;

                for (int j = 0; j < da.Rows.Count; j++)
                {
                    for (int i = 0; i < da.Columns.Count - 1; i++)
                    {
                        Cells[t, i] = da.Rows[j][i];
                    }
                    t = t + 1;
                }
                BorderAround(worksheet.get_Range("A4", "AD" + (t)));
                colo = colo + da.Rows.Count + 5 + 7;
                //sum = sum + test.Rows.Count +3;
                count1 = count1 + da.Rows.Count;
                sum1 = sum1 + Int32.Parse(da.AsEnumerable().Sum(x => x.Field<double>("Qty")).ToString());
                //if (t == sum)
                //{
                Cells[t, 8] = "Total :";
                Cells[t, 9] = da.AsEnumerable().Sum(x => x.Field<double>("Qty")).ToString();

                Cells[t + 1, 8] = "項數:";
                Cells[t + 1, 9] = da.Rows.Count + "項";

                Cells[t + 2, 8] = "(" + tb1.Text + "號-" + tb2.Text + "號)累計筆數:";
                Cells[t + 2, 9] = count1;

                Cells[t + 3, 8] = "(" + tb1.Text + "號-" + tb2.Text + "號)AMOUNT:";
                Cells[t + 3, 9] = sum1;

                Cells[t + 4, 0] = "製表人:";
                Cells[t + 4, 11] = "製表人:";

                //Cells[t + 6, 3] = title;
                t = t + 5;

                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount, ColumnsCount])).Value2 = Cells;
                worksheet.Columns.AutoFit();
                //thoát và thu hồi bộ nhớ cho COM
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }
        }
        void ExportHoangTest(DataTable da)
        {
            DataTable hoang = new DataTable();
            check();
            string WS_DATE_S = i;
            string WS_DATE_E = j;
            int ColumnsCount = 0;
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            if (da.Rows.Count > 0)
            {
                ColumnsCount = da.Columns.Count;
                hoang = da.AsEnumerable().GroupBy(r => new { Col1 = r["WS_DATE"] }).Select(g => g.OrderBy(r => r["WS_DATE"]).First()).OrderBy(x => x["WS_DATE"]).CopyToDataTable();
                int RowsCount = da.Rows.Count + (7 * hoang.Rows.Count) + 3 + (3 * hoang.Rows.Count - 1);
                object[,] Cells = new object[RowsCount, ColumnsCount];

                int t = 0;
                //int sum = 0;
                int count1 = 0;
                double sum1 = 0;
                int colo = 0;
                for (int a = 0; a < hoang.Rows.Count; a++)
                {
                    Range row_header = worksheet.get_Range("A" + (t + 2), "AD" + (t + 2));
                    row_header.Merge();
                    row_header.Font.Name = "Times New Roman";
                    row_header.Font.Size = 16;
                    row_header.Font.Bold = true;
                    row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    row_header.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    row_header.ColumnWidth = 3;

                    Cells[t + 1, 0] = title;

                    Cells[t + 2, 0] = hoang.Rows[a][hoang.Columns.Count - 1];

                    Cells[t + 3, 0] = "下單日期";
                    Cells[t + 3, 1] = "客戶名稱";
                    Cells[t + 3, 2] = "訂單號碼";
                    Cells[t + 3, 3] = "貿易商.品牌";
                    Cells[t + 3, 4] = "鞋型";
                    Cells[t + 3, 5] = "材料名稱";
                    Cells[t + 3, 6] = "紋路";
                    Cells[t + 3, 7] = "顏色";
                    Cells[t + 3, 8] = "厚度";
                    Cells[t + 3, 9] = "數量";
                    Cells[t + 3, 10] = "幣別";
                    Cells[t + 3, 11] = "單價";
                    Cells[t + 3, 12] = "";
                    Cells[t + 3, 13] = "訂購人";
                    Cells[t + 3, 14] = "成品級數";
                    Cells[t + 3, 15] = "會計員";
                    Cells[t + 3, 16] = "業務員";
                    Cells[t + 3, 17] = "業績";
                    Cells[t + 3, 18] = "季度";
                    Cells[t + 3, 19] = "階段";
                    Cells[t + 3, 20] = "合計";
                    Cells[t + 3, 21] = "客戶交期";
                    Cells[t + 3, 22] = "交期1";
                    Cells[t + 3, 23] = "交期2";
                    Cells[t + 3, 24] = "完成日期";
                    Cells[t + 3, 25] = "備註";
                    Cells[t + 3, 26] = "制另號";
                    Cells[t + 3, 27] = "部位";
                    Cells[t + 3, 28] = "設計師";
                    Cells[t + 3, 29] = "已交量";
                    //worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount, ColumnsCount])).Value2 = Cells;
                    for (int i = 0; i < ColumnsCount - 1; i++)
                        Cells[t + 4, i] = da.Columns[i].ColumnName;
                    Microsoft.Office.Interop.Excel.Range HeaderRange = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[(t + 4), 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[(t + 6), ColumnsCount]));
                    HeaderRange.Value2 = Cells;
                    Range HeaderAll = worksheet.get_Range("A" + (t + 4), "AD" + (t + 5));
                    HeaderAll.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Lavender);

                    t = t + 5;
                    int bor = 0;
                    var test = da.AsEnumerable().Where(x => x["WS_DATE"].ToString() == hoang.Rows[a][hoang.Columns.Count - 1].ToString()).CopyToDataTable();
                    for (int j = 0; j < test.Rows.Count; j++)
                    {
                        if (j == 0)
                        {
                            bor = bor + t;
                        }

                        for (int i = 0; i < test.Columns.Count - 1; i++)
                        {
                            Cells[t, i] = test.Rows[j][i];
                        }
                        t = t + 1;
                        //worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount, ColumnsCount])).Value2 = Cells;
                    }
                    BorderAround(worksheet.get_Range("A" + (bor - 1), "AD" + (t)));
                    colo = colo + test.Rows.Count + 5 + 7;
                    //sum = sum + test.Rows.Count +3;
                    count1 = count1 + test.Rows.Count;
                    sum1 = sum1 + double.Parse(test.AsEnumerable().Sum(x => x.Field<double>("Qty")).ToString());
                    //if (t == sum)
                    //{
                    Cells[t, 8] = "Total :";
                    Cells[t, 9] = test.AsEnumerable().Sum(x => x.Field<double>("Qty")).ToString();

                    Cells[t + 1, 8] = "項數:";
                    Cells[t + 1, 9] = test.Rows.Count + "項";

                    Cells[t + 2, 8] = "(" + converttodate(hoang.Rows[0][hoang.Columns.Count - 1].ToString()) + "號-" + converttodate(hoang.Rows[a][hoang.Columns.Count - 1].ToString()) + "號)累計筆數:";
                    Cells[t + 2, 9] = count1;

                    Cells[t + 3, 8] = "(" + converttodate(hoang.Rows[0][hoang.Columns.Count - 1].ToString()) + "號-" + converttodate(hoang.Rows[a][hoang.Columns.Count - 1].ToString()) + "號)AMOUNT:";
                    Cells[t + 3, 9] = sum1;

                    Cells[t + 4, 0] = "製表人:";
                    Cells[t + 4, 11] = "製表人:";

                    //Cells[t + 6, 3] = title;
                    t = t + 5;

                    //}
                    //sum = sum + 7;
                }
                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[1, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount, ColumnsCount])).Value2 = Cells;
                worksheet.Columns.AutoFit();
                //thoát và thu hồi bộ nhớ cho COM
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }

        }
        public string converttodate(string da)
        {
            string de;
            string date1 = "20" + da.Substring(0, 2) + "/" + da.Substring(2, 2) + "/" + da.Substring(4, 2);
            de = DateTime.Parse(date1).ToString("yyyy/MM/dd");
            return de;
        }
        void procesTab1() // Processing for tabpage 1 
        {
            check();
            string WS_DATE_S = conn.formatstr1(a);
            string WS_DATE_E = conn.formatstr1(b);
            if (rdbaocao.Checked == true)
            {
                // View Data Report
                SQL = "SELECT WS_DATE,ORDB.C_NAME_E,OR_NO,T_NAME as BRAND,MODEL_E,ORDB.P_NAME_E + ORDB.P_NAME_C as 'MaterialName',ORDB.PATT_C,ORDB.COLOR_E + ORDB.COLOR_C AS 'Color',THICK,ORDB.QTY FROM ORDB WHERE ORDB.WS_DATE BETWEEN '" + WS_DATE_S + "' AND '" + WS_DATE_E + "'";
                typeProduct(); // Chọn Hàng báo cáo
                Form2ABF7_Report fr = new Form2ABF7_Report();
                fr.ShowDialog();
            }
            else if (rdexcel.Checked == true)
            {
                //SQL = "SELECT ORDB.WS_DATE+'-'+ORDB.NR AS 'Date',CUST.C_ANAME2 AS 'Cust.',ORDB.OR_NO AS 'PO#', ORDB.BRAND AS 'Brand', ORDB.MODEL_E AS 'Model#',ORDB.P_NAME_E + ORDB.P_NAME_C as 'MaterialName',ORDB.PATT_C AS 'Patt#',  " +
                //    " ORDB.COLOR_E + ORDB.COLOR_C AS 'Color',ORDB.THICK AS 'Think',ORDB.QTY AS 'Qty',ORDB.CURRENCY AS 'Currency',ORDB.PRICE AS 'Price',ORDB.PER_S AS '%',ORDB.PURCHASER AS 'Purchaser',ORDB.GRADE AS 'Grade of Product',ORDB.ACCOUNT AS 'Accountant', " +
                //    " ORDB.SALES AS 'Businesman',ORDB.ACHI AS 'Achie Vement',ORDB.SEASON AS ' SeaSon',ORDB.DEVSTAGE AS 'Dev. Stage','' AS 'Total',ORDB.WS_DATE1 AS 'Schedule1', ORDB.SCHEDULE2 AS 'Schedule2',ORDB.WS_DATE3 AS 'Schedule3', ORDB.WS_DATE_F AS 'Finished', " +
                //    " ORDB.REMARKS AS 'Remarks',ORDB.RV_PLACE AS 'SFR#' ,ORDB.COMPOUNTS AS 'Compounts',ORDB.DESIGER AS 'Designer',ORDB.QTY_OUT AS 'OutQty' FROM ORDB LEFT JOIN CUST ON ORDB.C_NO = CUST.C_NO WHERE ORDB.WS_DATE = '"+ WS_DATE_E+ "' ";
                SQL = " SELECT CASE WHEN K_NO IN (3,4) THEN ORDB.WS_DATE+'-0'+ORDB.NR ELSE ORDB.WS_DATE+'-'+ORDB.NR END AS 'Date',dbo.CUST.C_NAME2 AS 'Cust.'," +
                        "ORDB.OR_NO AS 'PO#', ORDB.T_NAME AS 'Brand', ORDB.MODEL_E +' '+ ORDB.MODEL_C AS 'Model#'," +
                        "ORDB.P_NAME_E + ORDB.P_NAME_C AS 'MaterialName',ORDB.PATT_C AS 'Patt#'," +
                        "ORDB.COLOR_C + ORDB.COLOR_E AS 'Color',ORDB.THICK AS 'Think',ORDB.QTY AS 'Qty'," +
                        "ORDB.CURRENCY AS 'Currency',cast(ORDB.PRICE AS nvarchar(10)) AS 'Price',ORDB.PER_S AS '%'," +
                        "ORDB.PURCHASER AS 'Purchaser',ORDB.GRADE AS 'Grade of Product'," +
                        "ORDB.ACCOUNT AS 'Accountant',  ORDB.SALES AS 'Businesman',ORDB.ACHI AS 'Achie Vement'," +
                        "ORDB.SEASON AS ' SeaSon',ORDB.DEVSTAGE AS 'Dev. Stage','' AS 'Total',ORDB.WS_DATE1 AS 'Schedule1'," +
                        "ORDB.SCHEDULE2 AS 'Schedule2',ORDB.WS_DATE3 AS 'Schedule3', ORDB.WS_DATE_F AS 'Finished'," +
                        "ORDB.REMARKS AS 'Remarks',ORDB.RV_PLACE AS 'SFR#' ,ORDB.COMPOUNTS AS 'Compounts',ORDB.DESIGER AS 'Designer'," +
                        " 'OutQty' = (SELECT SUM(a.BQTY) AS BQTY FROM(" +
                        " SELECT CARB.WS_NO, CARB.WS_DATE, CARB.BQTY, CARH.OR_NO" +
                        " FROM CARB, CARH " +
                        " WHERE CARH.WS_NO = CARB.WS_NO AND CARB.ORD_DATE = ORDB.WS_DATE" +
                        " AND CARB.OR_NO = ORDB.OR_NO AND CARB.OR_NR = ORDB.NR AND CARB.K_NO = ORDB.K_NO " +
                        " UNION" +
                        " SELECT GIBB.WS_NO, GIBB.WS_DATE, GIBB.BQTY * (-1), GIBH.OR_NO" +
                        " FROM GIBB, GIBH" +
                        " WHERE GIBH.WS_NO = GIBB.WS_NO AND GIBB.WS_KIND <> 'B'" +
                        " AND GIBB.ORD_DATE = ORDB.WS_DATE AND GIBB.OR_NO = ORDB.OR_NO AND GIBB.OR_NR = ORDB.NR AND GIBB.K_NO = ORDB.K_NO)a),WS_DATE" +
                        " FROM ORDB" +
                        " LEFT JOIN CUST ON ORDB.C_NO = CUST.C_NO" +
                        " WHERE WS_DATE = " + WS_DATE_E + " AND QTY> 0 ";
                // Extract Excel
                typeProduct2(); // Chọn Hàng báo cáo
                da = new System.Data.DataTable();
                da = conn.readdata(SQL);
                float D = 0;
                string CA = "";
                string BR = "";
                if (da.Rows.Count > 0)
                {
                    CA = da.Rows[0]["Cust."].ToString();
                    BR = da.Rows[0]["Brand"].ToString();
                    for (int i = 0; i <= da.Rows.Count - 1; i++)
                    {

                        string AA = da.Rows[i]["Cust."].ToString();
                        string Br1 = da.Rows[i]["Brand"].ToString();

                        if ((CA == AA) && (BR == Br1))
                        {
                            D = D + float.Parse(da.Rows[i]["Qty"].ToString());
                        }
                        else
                        {
                            da.Rows[i - 1]["Total"] = D.ToString();
                            CA = da.Rows[i]["Cust."].ToString();
                            BR = da.Rows[i]["Brand"].ToString();
                            D = float.Parse(da.Rows[i]["Qty"].ToString());
                        }
                        if (i == da.Rows.Count - 1)
                        {
                            da.Rows[da.Rows.Count - 1]["Total"] = D.ToString();
                        }
                    }
                    foreach (DataRow row in da.Rows)
                    {
                        if (row["OutQty"].ToString() == "")
                        {
                            row["OutQty"] = "0";
                        }
                    }
                }
                ExportToExcel(da);
            }
        }
        void procesTab2() // Processing for tabpage 2 
        {
            check();
            string Date2 = conn.formatstr1(f);
            SQL2 = "SELECT ORDB.WS_DATE, ORDB.C_NAME_C, ORDB.PURCHASER, ORDB.OR_NO, ORDB.COLOR_E + P_NAME_C as COLOR_E, ORDB.THICK, ORDB.QTY, ORDB.C_NO,SCHEDULE2,T_NAME,NR FROM ORDB WHERE 1=1 ";
            if (rdhangmau.Checked == true)
                SQL2 = SQL2 + " AND (ORDB.K_NO='1' OR ORDB.K_NO='2' OR K_NO='5') ";
            if (rdhangsanxuat.Checked == true)
                SQL2 = SQL2 + " AND (ORDB.K_NO='3' OR ORDB.K_NO='4') ";
            if (Date2 != "")
                SQL2 = SQL2 + " AND WS_DATE = '" + Date2 + "'";
            if (tb2t2.Text != "" && tb3t2.Text != "")
                SQL2 = SQL2 + " AND C_NO BETWEEN '" + tb2t2.Text + "' AND '" + tb3t2.Text + "'";

            SQL2 = SQL2 + " ORDER BY WS_DATE,C_NO,T_NAME,NR";
            Form2ABF7_TAB2 fm = new Form2ABF7_TAB2();
            fm.ShowDialog();
        }
        void procesTab3() // Processing for tabpage 3 
        {
            check();
            string DATE1 = conn.formatstr1(g);
            string DATE2 = conn.formatstr1(h);
            SQL3 = "SELECT WS_DATE,dbo.CUST.C_ANAME2 AS C_NAME_E,OR_NO,BRAND,P_NAME_E+P_NAME_C AS P_NAME_E,THICK,QTY,WS_DATE1,QTY_OUT,(QTY-QTY_OUT) AS QTY_OUT_T,'' as Accept,'" + g + "' as DATE1,'" + h + "' as DATE2 FROM ORDB INNER JOIN CUST ON CUST.C_NO = ORDB.C_NO " +
                    "WHERE OVER0<>'Y' and WS_DATE between '" + DATE1 + "' and '" + DATE2 + "' and ACHI != '' ";
            typeProduct3();
            Frm2ABF7_Tab3 fr = new Frm2ABF7_Tab3();
            fr.ShowDialog();
        }
        void procesTab4() // Processing for tabpage 4 
        {
            check();
            string WS_DATE_S = conn.formatstr1(i);
            string WS_DATE_E = conn.formatstr1(j);
            //SQL4 = "SELECT ORDB.WS_DATE, ORDB.C_NAME_C, ORDB.OR_NO, ORDB.BRAND, ORDB.P_NAME_E, ORDB.THICK, ORDB.QTY, ORDB.WS_DATE1,(ORDB.QTY - CARB.BQTY) AS TRU,(CARB.BQTY) AS SL, (CARB.WS_NO) AS CB, (CARB.WS_DATE) AS DATE1 from ORDB Left join CARB on ORDB.C_NO = CARB.C_NO and ORDB.OR_NO = CARB.OR_NO WHERE 1=1 ";
            SQL4 = "SELECT DISTINCT * FROM dbo.View_2ABF7Tap4" +
                    " WHERE 2 > 1";
            if (WS_DATE_S != "" && WS_DATE_E != "")
                SQL4 = SQL4 + " AND WS_DATE BETWEEN '" + WS_DATE_S + "' AND '" + WS_DATE_E + "' ";
            if (txtOR_NO_S4.Text != "" && txtOR_NO_E4.Text != "")
                SQL4 = SQL4 + " AND WS_DATE BETWEEN '" + txtOR_NO_S4.Text + "' AND '" + txtOR_NO_E4.Text + "' ";

            SQL4 = SQL4 + "ORDER BY WS_DATE,NR";

            SQLSub = "SELECT * from View2ABF7Tab4_1 Where ORD_DATE BETWEEN '" + WS_DATE_S + "' AND '" + WS_DATE_E + "'";
            Form2ABF7_Tab4 fm = new Form2ABF7_Tab4();
            fm.ShowDialog();
        }
        private string SUM()
        {
            string sum = "";
            check();
            string WS_DATE_S = conn.formatstr1(a);
            string WS_DATE_E = conn.formatstr1(b);
            if (rdexcel.Checked == true)
            {
                SQL5 = "SELECT SUM(QTY) as QTY FROM ORDB where 1=1 and WS_DATE between '" + WS_DATE_S + "' and '" + WS_DATE_E + "'";
                typeProduct4();
                DataTable data = new DataTable();
                data = conn.readdata(SQL5);
                foreach (DataRow row in data.Rows)
                {
                    sum = row["QTY"].ToString();
                }
            }
            return sum;
        }
        private string COUNT()
        {
            string count = "";
            check();
            string WS_DATE_S = conn.formatstr1(a);
            string WS_DATE_E = conn.formatstr1(b);
            if (rdexcel.Checked == true)
            {
                SQL5 = "SELECT COUNT(QTY) as QTY FROM ORDB where 1=1 and WS_DATE between '" + WS_DATE_S + "' and '" + WS_DATE_E + "'";
                typeProduct4();
                DataTable data = new DataTable();
                data = conn.readdata(SQL5);
                foreach (DataRow row in data.Rows)
                {
                    count = row["QTY"].ToString();
                }
            }
            return count;
        }
        void getTitle() // Get title for Excel for Tabpage 1 
        {
            if (rd1.Checked == true)
                title = "榔皮樣品合約登記    Sample of Split Agreement Report";
            else if (rd2.Checked == true)
                title = "內銷樣品合約登記    Sample of Leather Agreement Report";
            else if (rd3.Checked == true)
                title = "內銷量產合約登記    Split Mass Production Agreement Report";
            else if (rd4.Checked == true)
                title = "面皮量產合約登記    Leather Mass Production Agreement Report";
            else if (rd5.Checked == true)
                title = "台灣登記生產合同    Sample of Taiwan Agreement Report";
            else if (rd6.Checked == true)
                title = "越南製作中和皮胚  Another form of Agreement Report";
                //title = "簽訂另一份生產合同  Another form of Agreement Report";
            else if (rd7.Checked == true)
                title = "越南預生產合約登記   Sample of vietnam Agreement Report";
                //title = "越南製作合約登記    Sample of vietnam Agreement Report";
        }
        void typeProduct() // Select type Product for Tabpage 1 
        {
            if (rdnhanxet.Checked == true)
                SQL = SQL + " AND Remarks != '' "; //Chon Record co Nhan xet Them Remarks khac rong 
            if (rd1.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '1'"; // Hang mau da bo
            if (rd2.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '2'"; // Hang mau da Heo
            if (rd3.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '3'"; // Hang San xuat da bo
            if (rd4.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '4'"; // Hang San xuat da heo
            if (rd5.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '5'"; // Hang mau TaiWan
            if (rd6.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '6'"; // Hang Khac 
            if (rd7.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '7'"; // Hang San xuat VietNam
            if (tb3.Text != "")
                SQL = SQL + " AND ORDB.C_NO = '" + tb3.Text + "' "; // Tìm theo mã Khách hàng
            if (tb4.Text != "")
                SQL = SQL + " AND ORDB.P_NO = '" + tb4.Text + "' "; // Tìm theo mã Khách hàng
            SQL = SQL + " Order by BRAND,CUST.C_NO ASC,NR";

        }
        void typeProduct2() // Select type Product for Tabpage 1 
        {
            if (rdnhanxet.Checked == true)
                SQL = SQL + " AND Remarks != '' "; //Chon Record co Nhan xet Them Remarks khac rong 
            if (rd1.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '1'"; // Hang mau da bo
            if (rd2.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '2'"; // Hang mau da Heo
            if (rd3.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '3'"; // Hang San xuat da bo
            if (rd4.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '4'"; // Hang San xuat da heo
            if (rd5.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '5'"; // Hang mau TaiWan
            if (rd6.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '6'"; // Hang Khac 
            if (rd7.Checked == true)
                SQL = SQL + " AND ORDB.K_NO = '7'"; // Hang San xuat VietNam
            if (tb3.Text != "")
                SQL = SQL + " AND ORDB.C_NO = '" + tb3.Text + "' "; // Tìm theo mã Khách hàng
            if (tb4.Text != "")
                SQL = SQL + " AND ORDB.P_NO = '" + tb4.Text + "' "; // Tìm theo mã Khách hàng
            //SQL = SQL + " Order by CUST.C_NO ASC";
            if (!string.IsNullOrEmpty(tb3.Text) || !string.IsNullOrEmpty(tb4.Text) || !string.IsNullOrEmpty(tb5.Text) || !string.IsNullOrEmpty(tb6.Text) || !string.IsNullOrEmpty(tb7.Text))
            {
                SQL = SQL + " ORDER BY ORDB.WS_DATE,Brand,CUST.C_NO,NR";
            }
            else
            {
                SQL = SQL + " ORDER BY ORDB.WS_DATE,Brand,CUST.C_NO,NR";
            }
        }
        void typeProduct3() // Select type Product for Tabpage 1 
        {
            if (radioButton21.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '1'"; // Hang mau da bo
            if (radioButton22.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '2'"; // Hang mau da Heo
            if (radioButton20.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '3'"; // Hang San xuat da bo
            if (radioButton19.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '4'"; // Hang San xuat da heo
            if (radioButton18.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '5'"; // Hang mau TaiWan
            if (radioButton17.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '6'"; // Hang Khac 
            if (radioButton16.Checked == true)
                SQL3 = SQL3 + " AND ORDB.K_NO = '7'"; // Hang San xuat VietNam
            if (radioButton23.Checked)
                SQL3 = SQL3 + "";
            SQL3 = SQL3 + " ORDER BY WS_DATE,ORDB.C_NO,NR";
        }
        void typeProduct4() // Select type Product for Tabpage 1 
        {
            if (rdnhanxet.Checked == true)
                SQL5 = SQL5 + " AND Remarks != '' "; //Chon Record co Nhan xet Them Remarks khac rong 
            if (rd1.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '1'"; // Hang mau da bo
            if (rd2.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '2'"; // Hang mau da Heo
            if (rd3.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '3'"; // Hang San xuat da bo
            if (rd4.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '4'"; // Hang San xuat da heo
            if (rd5.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '5'"; // Hang mau TaiWan
            if (rd6.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '6'"; // Hang Khac 
            if (rd7.Checked == true)
                SQL5 = SQL5 + " AND ORDB.K_NO = '7'"; // Hang San xuat VietNam
            if (tb3.Text != "")
                SQL5 = SQL5 + " AND ORDB.C_NO = '" + tb3.Text + "' "; // Tìm theo mã Khách hàng
            if (tb4.Text != "")
                SQL5 = SQL5 + " AND ORDB.P_NO = '" + tb4.Text + "' "; // Tìm theo mã Khách hàng
        }
        void ExportToExcel(System.Data.DataTable da) // Method Export To Excel for tabPage 1 
        {
            check();
            string WS_DATE_S = i;
            string WS_DATE_E = j;
            int ColumnsCount = 0;
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;
            if (da.Rows.Count > 0)
            {
                ColumnsCount = da.Columns.Count;
                //Crea title 
                Range row_header = worksheet.get_Range("A2", "AD2");
                row_header.Merge();
                row_header.Font.Name = "Times New Roman";
                row_header.Font.Size = 16;
                row_header.Font.Bold = true;
                row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row_header.VerticalAlignment = XlVAlign.xlVAlignCenter;
                row_header.Value2 = title;
                row_header.ColumnWidth = 3;

                worksheet.Cells[3, 1] = conn.formatstr1(tb2.Text);
                // Header
                worksheet.Cells[4, 1] = "下單日期";
                worksheet.Cells[4, 2] = "客戶名稱";
                worksheet.Cells[4, 3] = "訂單號碼";
                worksheet.Cells[4, 4] = "貿易商.品牌";
                worksheet.Cells[4, 5] = "鞋型";
                worksheet.Cells[4, 6] = "材料名稱";
                worksheet.Cells[4, 7] = "紋路";
                worksheet.Cells[4, 8] = "顏色";
                worksheet.Cells[4, 9] = "厚度";
                worksheet.Cells[4, 10] = "數量";
                worksheet.Cells[4, 11] = "幣別";
                worksheet.Cells[4, 12] = "單價";
                worksheet.Cells[4, 13] = "";
                worksheet.Cells[4, 14] = "訂購人";
                worksheet.Cells[4, 15] = "成品級數";
                worksheet.Cells[4, 16] = "會計員";
                worksheet.Cells[4, 17] = "業務員";
                worksheet.Cells[4, 18] = "業績";
                worksheet.Cells[4, 19] = "季度";
                worksheet.Cells[4, 20] = "階段";
                worksheet.Cells[4, 21] = "合計";
                worksheet.Cells[4, 22] = "客戶交期";
                worksheet.Cells[4, 23] = "交期1";
                worksheet.Cells[4, 24] = "交期2";
                worksheet.Cells[4, 25] = "完成日期";
                worksheet.Cells[4, 26] = "備註";
                worksheet.Cells[4, 27] = "制另號";
                worksheet.Cells[4, 28] = "部位";
                worksheet.Cells[4, 29] = "設計師";
                worksheet.Cells[4, 30] = "已交量";

                object[] Header = new object[ColumnsCount];
                // column headings
                for (int i = 0; i < ColumnsCount - 1; i++)
                    Header[i] = da.Columns[i].ColumnName;
                Microsoft.Office.Interop.Excel.Range HeaderRange = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[5, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[5, ColumnsCount]));
                HeaderRange.Value2 = Header;
                Range HeaderAll = worksheet.get_Range("A4", "AD5");
                HeaderAll.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Lavender);

                //var hoang = da.AsEnumerable().GroupBy(r => new { Col1 = r["WS_DATE"] }).Select(g => g.OrderBy(r => r["WS_DATE"]).First()).CopyToDataTable();

                //int RowsCount = da.Rows.Count;
                //object[,] Cells = new object[RowsCount, ColumnsCount];

                //worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


                // Show DataTable 
                int RowsCount = da.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];
                for (int j = 0; j < RowsCount; j++)
                    for (int i = 0; i < ColumnsCount; i++)
                        Cells[j, i] = da.Rows[j][i];
                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;

                //Kẻ khung toàn bộ
                int hang = RowsCount + 5;
                BorderAround(worksheet.get_Range("A4", "AD" + hang));

                int s = RowsCount + 5;

                Range Total = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 6, 9]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 6, 9]));
                Total.Value2 = "Total :";
                Total.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Range TotalResulft = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 6, 10]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 6, 10]));
                TotalResulft.Value2 = "=SUM(J5:J" + s + ")";
                TotalResulft.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range CountItem = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 7, 9]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 7, 9]));
                CountItem.Value2 = "項數:";
                CountItem.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range CountItemResulft = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 7, 10]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 7, 10]));
                CountItemResulft.Value2 = "=COUNT(J5:J" + s + ")";
                CountItemResulft.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range ItemAll = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 8, 9]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 8, 9]));
                ItemAll.Value2 = "(" + tb1.Text + "號-" + tb2.Text + "號)累計筆數:";
                ItemAll.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Range V_ItemAll = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 8, 10]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 8, 10]));
                V_ItemAll.Value2 = "" + COUNT() + "";
                V_ItemAll.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range SumItem = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 9, 9]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 9, 9]));
                SumItem.Value2 = "" + tb1.Text + "號-" + tb2.Text + "號)AMOUNT: ";
                ItemAll.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Range V_SumItem = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 9, 10]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 9, 10]));
                V_SumItem.Value2 = "" + SUM() + "";
                V_SumItem.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range Total1 = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 10, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 10, 1]));
                Total1.Value2 = "製表人:";
                Total1.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Range TotalResulft1 = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 10, 11]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 10, 11]));
                TotalResulft1.Value2 = "製表人:";
                TotalResulft1.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;



                //Auto Size
                worksheet.Columns.AutoFit();
                //thoát và thu hồi bộ nhớ cho COMy
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }

        }
        private void BorderAround(Range range) // Create Boder style Excel File  
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        private static void releaseObject(object obj) // Clear COM Memory  
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
        private void btnClose_Click(object sender, EventArgs e) // Closing Form 
        {
            this.Close();
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e) // get ID PRODUCT START Tab 1  
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            tb3.Text = frm2CustSearch.ID.ID_CUST;
            frm2CustSearch.ID.ID_CUST = "";
        }

        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e) // get ID PRODUCT END Tab 1 
        {
            FormSearchMaterial2 fm = new FormSearchMaterial2();
            fm.ShowDialog();
            tb4.Text = FormSearchMaterial2.ID.ID_P_NO;
        }

        private void tb2t2_MouseDoubleClick(object sender, MouseEventArgs e) // get ID CUSTOMER START Tab 2 
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            tb2t2.Text = frm2CustSearch.ID.ID_CUST;
            frm2CustSearch.ID.ID_CUST = "";
        }

        private void tb3t2_MouseDoubleClick(object sender, MouseEventArgs e) // get ID CUSTOMER END Tab 2 
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            tb3t2.Text = frm2CustSearch.ID.ID_CUST;
            frm2CustSearch.ID.ID_CUST = "";
        }

        private void txtOR_NO_S4_MouseDoubleClick(object sender, MouseEventArgs e) // get OR_NO Start Tab 4 
        {

        }

        private void txtOR_NO_E4_MouseDoubleClick(object sender, MouseEventArgs e) // get OR_NO END Tab 4
        {

        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Closing form 
        {
            this.Close();
        }

        private void tb8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb8.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb9.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb2.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr1 = new FormSearchBrand();
            fr1.ShowDialog();

            string DL = FormSearchBrand.ID.BRAND;
            string DL1 = FormSearchBrand.ID.TRADE;
            if (DL != string.Empty)
            {
                tb5.Text = DL;
                tb6.Text = DL1;
            }
            else
            {
                tb5.Text = "";
                tb6.Text = "";
            }

        }

        private void tb6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr1 = new FormSearchBrand();
            fr1.ShowDialog();

            string DL = FormSearchBrand.ID.BRAND;
            string DL1 = FormSearchBrand.ID.TRADE;
            if (DL != string.Empty)
            {
                tb5.Text = DL;
                tb6.Text = DL1;
            }
            else
            {
                tb5.Text = "";
                tb6.Text = "";
            }

        }

        private void tb1t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1t2.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb1t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1t3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb2t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb2t3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE_S4_KeyDown(object sender, KeyEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtOR_NO_S4.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE_E4_KeyDown(object sender, KeyEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtOR_NO_E4.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb9.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb2.Focus();
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb1.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb3.Focus();
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb2.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb4.Focus();
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb3.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb5.Focus();
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb4.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb6.Focus();
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb5.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb7.Focus();
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb6.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb8.Focus();
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb7.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb9.Focus();
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                tb8.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb1.Focus();
        }
        void check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                a = tb1.Text;
            }
            if (conn.Check_MaskedText(tb2) == true)
            {
                b = tb2.Text;
            }
            if (conn.Check_MaskedText(tb8) == true)
            {
                c = tb8.Text;
            }
            if (conn.Check_MaskedText(tb9) == true)
            {
                d = tb9.Text;
            }
            if (conn.Check_MaskedText(tb1t2) == true)
            {
                f = tb1t2.Text;
            }
            if (conn.Check_MaskedText(tb1t3) == true)
            {
                g = tb1t3.Text;
            }
            if (conn.Check_MaskedText(tb2t3) == true)
            {
                h = tb2t3.Text;
            }
            if (conn.Check_MaskedText(txtWS_DATE_S4) == true)
            {
                i = txtWS_DATE_S4.Text;
            }
            if (conn.Check_MaskedText(txtWS_DATE_E4) == true)
            {
                j = txtWS_DATE_E4.Text;
            }
        }
        private void txtWS_DATE_S4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE_S4.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE_E4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE_E4.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void tb1t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t2, tb2t2, sender, e);
        }

        private void tb2t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1t2, tb3t2, sender, e);
        }

        private void tb3t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb2t2, tb1t2, sender, e);
        }

        private void tb1t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP_DOWN(tb2t3, tb2t3, sender, e);
        }

        private void tb2t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP_DOWN(tb1t3, tb1t3, sender, e);
        }

        private void txtWS_DATE_S4_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(txtOR_NO_E4, txtWS_DATE_E4, sender, e);
        }

        private void txtWS_DATE_E4_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtWS_DATE_S4, txtOR_NO_S4, sender, e);
        }

        private void txtOR_NO_S4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtWS_DATE_E4, txtOR_NO_E4, sender, e);
        }

        private void txtOR_NO_E4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(txtOR_NO_S4, txtWS_DATE_S4, sender, e);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        //private void tb1_IsOverwriteModeChanged(object sender, EventArgs e)
        //{

        //}
    }
}
