using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace WTERP
{
    public partial class frm2K_Tap1_1 : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt0 = new DataTable();
        DataTable da = new DataTable();
        DataProvider con = new DataProvider();
        string user_name = "";
        string order_by = "";
        string CAL_YM = "";
        string C_NO = "";
        string DATE = "";
        string WS_NO_NEW = "";
        string P_NAME_NEW = "";
        string PRICE_NEW = "";
        string BQTY_NEW = "";
        string AMOUNT_NEW = "";
        string AMOUNT_CATH = "";
        DataTable da2 = new DataTable();

        public frm2K_Tap1_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            con.CreateButtonToolTipReport(crystalReportViewer1, btnExportExcel_Click);
        }
        private void frm2K_Tap1_1_Load(object sender, EventArgs e)
        {
            string UID = frmLogin.ID_USER; // get ID User 
            user_name = con.getUser(UID);// get UserName 

            order_by = "";
            CAL_YM = con.formatstr2(frm2K.Date1);
            C_NO = frm2K.txt_CNO;

            int radio_color = frm2K.radio_color;
            int radio_p_name = frm2K.radio_p_name;

            bool check1 = frm2K.rd_Date;
            bool check2 = frm2K.rd_ORNO;

            bool checkHN = frm2K.rd_HN;

            string where = "";
            bool checkDD1 = frm2K.rdNB;
            bool checkDD2 = frm2K.rdBN;

            int keyCheck = 0;

            if (checkHN == true)
            {
                keyCheck = 2;
            }
            else
            {
                keyCheck = 1;
            }

            if (check1 == true)
            {
                order_by = " ORDER BY A.WS_DATE,A.WS_NO,A.NR";
            }
            if (check2 == true)
            {
                order_by = "ORDER BY A.OR_NO,A.WS_DATE,A.WS_NO,A.NR";
            }
            // nội bộ lấy bù , bên ngoài thì không
            if (checkDD1 == true)
            {
                where = "'B.OR_NO NOT LIKE ''%作廢%'''";

                string st = "Exec Export_Report_And_Excel_2K_PERVIOUS '" + C_NO + "','" + CAL_YM + "'," + radio_color + "," + radio_p_name + ",'" + order_by + "'," + keyCheck + "," + where + "";
                dt = con.readdata(st);

                string st0 = "Exec Export_Report_And_Excel_2K '" + C_NO + "','" + CAL_YM + "'," + radio_color + "," + radio_p_name + ",'" + order_by + "'," + keyCheck + "," + where + "";
                dt0 = con.readdata(st0);

                string st2 = "Exec Export_Report_And_Excel_2K_Continues '" + C_NO + "','" + CAL_YM + "'," + radio_color + "," + radio_p_name + ",'" + order_by + "'," + keyCheck + "";
                dt2 = con.readdata(st2);

                dt.Merge(dt0);
                dt.Merge(dt2);
            }
            if (checkDD2 == true)
            {
                where = "'B.OR_NO NOT LIKE''%作廢%'' AND B.OR_NO NOT LIKE''%贈送%'' AND A.MEMO NOT LIKE''%補%'''";

                string st = "Exec Export_Report_And_Excel_2K '" + C_NO + "','" + CAL_YM + "'," + radio_color + "," + radio_p_name + ",'" + order_by + "'," + keyCheck + "," + where + "";
                dt = con.readdata(st);
            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["WS_DATE"] = dr["WS_DATE"].ToString().Substring(4, 4);
                    dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
                    //dr["AMOUNT"] = double.Parse(Math.Round(double.Parse(dr["AMOUNT"].ToString()), 3).ToString());
                }
            }
            WSEXE.ReportView.cr_From2K_Tap1_1 rpt = new WSEXE.ReportView.cr_From2K_Tap1_1();
            rpt.DataDefinition.FormulaFields["cal_ym"].Text = "'" + frm2K.Date1.Substring(0, 4) + "年" + frm2K.Date1.Substring(5, 2) + "月'";
            rpt.DataDefinition.FormulaFields["USR_NAME"].Text = "'" + user_name + "'";
            //new
           
            da = ReturnDataCATH(da);
            if (da.Rows.Count > 0)
            {
                da2 = ReturnDataCATB(da.Rows[0]["WS_DATE"].ToString(), da.Rows[0]["C_NO"].ToString(), da2);
                rpt.DataDefinition.FormulaFields["DATE"].Text = "'" + DATE + "'";
                rpt.DataDefinition.FormulaFields["WS_NO_NEW"].Text = "'" + WS_NO_NEW + "'";
                rpt.DataDefinition.FormulaFields["P_NAME_NEW"].Text = "'" + P_NAME_NEW + "'";
                rpt.DataDefinition.FormulaFields["PRICE_NEW"].Text = "'" + PRICE_NEW + "'";
                rpt.DataDefinition.FormulaFields["BQTY_NEW"].Text = "'" + BQTY_NEW + "'";
                rpt.DataDefinition.FormulaFields["AMOUNT_NEW"].Text = "'" + AMOUNT_NEW + "'";
                rpt.DataDefinition.FormulaFields["AMOUNT_CATH"].Text = "'" + AMOUNT_CATH + "'";
                if (checkHN == false)
                {
                    rpt.DataDefinition.FormulaFields["CHECK"].Text = "'" + "TRUE" + "'";
                }
                else
                {
                    rpt.DataDefinition.FormulaFields["CHECK"].Text = "'" + "FALSE" + "'";
                }
            }
            else
            {
                rpt.DataDefinition.FormulaFields["AMOUNT_CATH"].Text = "'" + "" + "'";
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        string key = "";
        string key2 = "";
        private DataTable ReturnDataCATH(DataTable data)
        {
            string sql = "SELECT * FROM CATH WHERE CAL_YM = '"+CAL_YM+"' AND C_NO ='" + C_NO + "'";
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                key = data.Rows[0]["WS_DATE"].ToString();
                key2 = data.Rows[0]["C_NO"].ToString();
                AMOUNT_CATH = string.Format("{0:#,##0.00}", double.Parse(data.Rows[0]["RCVTOT"].ToString()));
            }
            return data;
        }
        private DataTable ReturnDataCATB(string key22,string key23,DataTable data2)
        {
            string sql = "SELECT TOP 1 *,SUBSTRING(CAST(YEAR(WS_DATE) AS NVARCHAR(8)),3,8) +'/'+ CAST(MONTH(WS_DATE) AS NVARCHAR(8)) +' '+ P_NAME AS P_NAME_NEW FROM CATB WHERE WS_DATE = '" + key22 + "' AND C_NO ='" + key23 + "'";
            data2 = con.readdata(sql);
            foreach (DataRow dr in data2.Rows)
            {
                dr["WS_DATE"] = dr["WS_DATE"].ToString().Substring(4, 4);
                DATE = data2.Rows[0]["WS_DATE"].ToString();
                WS_NO_NEW = data2.Rows[0]["WS_NO"].ToString();
                P_NAME_NEW = data2.Rows[0]["P_NAME_NEW"].ToString();
                PRICE_NEW = string.Format("{0:#,##0.00}", double.Parse(data2.Rows[0]["PRICE"].ToString()));
                BQTY_NEW = string.Format("{0:#,##0.00}", double.Parse(data2.Rows[0]["BQTY"].ToString()));
                AMOUNT_NEW = string.Format("{0:#,##0.00}", double.Parse(data2.Rows[0]["AMOUNT"].ToString()));
               
            }
            return data2;
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            int page = 0;
            if ((dt.Rows.Count % 16) == 0)
            {
                page = dt.Rows.Count / 16;
            }
            else
            {
                page = (dt.Rows.Count / 16) + 1;
            }
            int pagenumber = 0;
            int rowex = 1;
            int rowList = 0;
            int BorderAround1 = 10;
            int indexrow = 0;
            int demm = 0;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel |*.xls";

            int ColumnsCount;
            if (dt == null || (ColumnsCount = dt.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;
            for (int i = 0; i < page; i++)
            {
                pagenumber = pagenumber + 16;
                // Header
                COMExcel.Worksheet IV = (COMExcel.Worksheet)workbook.Worksheets[1];
                COMExcel.Range Na1 = IV.get_Range("A" + rowex, "P" + rowex);
                Na1.Merge();
                Na1.Font.Bold = true;
                Na1.Font.Size = 26;
                Na1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na1.Value2 = "TOPPING INTERNATIONAL CO.,LTD.";

                COMExcel.Range Na2 = IV.get_Range("A" + (rowex + 1), "P" + (rowex + 1));
                Na2.Merge();
                Na2.Font.Bold = true;
                Na2.Font.Size = 18;
                Na2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na2.Value2 = "WEI TAI (VIETNAM) LEATHER CO., LTD.";

                COMExcel.Range Na3 = IV.get_Range("A" + (rowex + 2), "E" + (rowex + 2));
                Na3.Merge();
                Na3.Font.Bold = true;
                Na3.Font.Size = 8;
                Na3.Value2 = "TWN: CTY TNHH Da Thuộc WEITAI";

                COMExcel.Range Na4 = IV.get_Range("A" + (rowex + 3), "D" + (rowex + 3));
                Na4.Merge();
                Na4.Font.Size = 8;
                Na4.Value2 = "臺灣 :緯達皮革有限公司";

                COMExcel.Range Na6 = IV.get_Range("J" + (rowex + 2), "P" + (rowex + 2));
                Na6.Merge();
                Na6.Font.Size = 8;
                Na6.Value2 = "Việt Nam:công ty TNHH thuộc da wei tai";

                COMExcel.Range Na7 = IV.get_Range("J" + (rowex + 3), "P" + (rowex + 3));
                Na7.Merge();
                Na7.Font.Size = 8;
                Na7.Font.Bold = true;
                Na7.Value2 = "越南：越南緯達皮革有限公司";

                COMExcel.Range Na8 = IV.get_Range("J" + (rowex + 4), "O" + (rowex + 4));
                Na8.Merge();
                Na8.Font.Size = 8;
                Na8.Value2 = "同柰省仁澤縣協福社仁澤3工業區";

                COMExcel.Range Na9 = IV.get_Range("J" + (rowex + 5), "P" + (rowex + 5));
                Na9.Merge();
                Na9.Font.Size = 8;
                Na9.Font.Bold = true;
                Na9.RowHeight = 23;
                Na9.WrapText = true;
                Na9.VerticalAlignment = COMExcel.XlVAlign.xlVAlignTop;
                Na9.Value2 = "khu công nghiệp nhơn trạch, huyện nhơn trạch,tỉnh đồng nai";

                COMExcel.Range Na12 = IV.get_Range("K" + (rowex + 6), "O" + (rowex + 6));
                Na12.Merge();
                Na12.Font.Size = 8;
                Na12.Value2 = "TEL  :84-61-3560886";

                COMExcel.Range Na12_1 = IV.get_Range("K" + (rowex + 7), "P" + (rowex + 7));
                Na12_1.Merge();
                Na12_1.Font.Size = 8;
                Na12_1.Value2 = "FAX  :84-61-3560883";

                COMExcel.Range Na5 = IV.get_Range("E" + (rowex + 3), "I" + (rowex + 4));
                Na5.Merge();
                Na5.Font.Size = 20;
                Na5.Font.Bold = true;
                Na5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na5.Value2 = "請 款 對 帳 單";

                COMExcel.Range Na10 = IV.get_Range("A" + (rowex + 6), "C" + (rowex + 6));
                Na10.Merge();
                Na10.Font.Size = 8;
                Na10.Value2 = "TEL  :886-4-22116696";

                COMExcel.Range Na_10 = IV.get_Range("A" + (rowex + 7), "C" + (rowex + 7));
                Na_10.Merge();
                Na_10.Font.Size = 8;
                Na_10.Value2 = "FAX  :886-4-22116683";

                COMExcel.Range Na11 = IV.get_Range("A" + (rowex + 5), "E" + (rowex + 5));
                Na11.Merge();
                Na11.Font.Size = 8;
                Na11.WrapText = true;
                Na11.VerticalAlignment = COMExcel.XlVAlign.xlVAlignTop;
                Na11.Value2 = "SỐ 98 CẢNG 17 phố giáp tay ấp đông chợ đài trung";

                COMExcel.Range Na13 = IV.get_Range("E" + (rowex + 7), "I" + (rowex + 7));
                Na13.Merge();
                Na13.Font.Bold = true;
                Na13.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na13.Value2 = frm2K.Date1.Substring(0, 4) + "年" + frm2K.Date1.Substring(5, 2) + "月 請款對帳單";
                Na13.Font.Size = 12;

                COMExcel.Range Na14 = IV.get_Range("A" + (rowex + 8), "G" + (rowex + 8));
                Na14.Merge();
                Na14.Font.Bold = true;
                Na14.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Na14.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na14.RowHeight = 20;
                Na14.Value2 = dt.Rows[0]["C_NAME"].ToString();

                COMExcel.Range Na15 = IV.get_Range("H" + (rowex + 8), "K" + (rowex + 8));
                Na15.Merge();
                Na15.Font.Bold = true;
                Na15.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Na15.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na15.RowHeight = 20;
                Na15.Value2 = "幣別: " + dt.Rows[0]["M_TRAN"].ToString();

                COMExcel.Range Na15_1 = IV.get_Range("L" + (rowex + 8), "P" + (rowex + 8));
                Na15_1.Merge();
                Na15_1.Font.Bold = true;
                Na15_1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Na15_1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na15_1.RowHeight = 20;
                Na15_1.Font.Bold = true;
                Na15_1.Value2 = "PAGE: " + (i + 1) + " OF " + page;

                COMExcel.Range Na17 = IV.get_Range("A" + (rowex + 9), "A" + (rowex + 9));
                Na17.Merge();
                Na17.Font.Bold = true;
                Na17.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na17.Value2 = "日期";

                COMExcel.Range Na18 = IV.get_Range("B" + (rowex + 9), "D" + (rowex + 9));
                Na18.Merge();
                Na18.Font.Bold = true;
                Na18.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na18.Value2 = "號  數";

                COMExcel.Range Na19 = IV.get_Range("E" + (rowex + 9), "F" + (rowex + 9));
                Na19.Merge();
                Na19.Font.Bold = true;
                Na19.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na19.Value2 = "品名";

                COMExcel.Range Na20 = IV.get_Range("G" + (rowex + 9), "G" + (rowex + 9));
                Na20.Value2 = "規格";
                Na20.Font.Bold = true;
                Na20.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                COMExcel.Range Na21 = IV.get_Range("H" + (rowex + 9), "J" + (rowex + 9));
                Na21.Merge();
                Na21.Font.Bold = true;
                Na21.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na21.Value2 = "數量";

                COMExcel.Range Na22 = IV.get_Range("K" + (rowex + 9), "K" + (rowex + 9));
                Na22.Font.Bold = true;
                Na22.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na22.Value2 = "單 價";

                COMExcel.Range Na23 = IV.get_Range("L" + (rowex + 9), "N" + (rowex + 9));
                Na23.Merge();
                Na23.Font.Bold = true;
                Na23.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na23.Value2 = "金額";

                COMExcel.Range Na24 = IV.get_Range("O" + (rowex + 9), "P" + (rowex + 9));
                Na24.Merge();
                Na24.Value2 = "備註";
                Na24.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Na24.Font.Bold = true;

                for (int j = rowList; j < pagenumber; j++)
                {
                    if (indexrow < dt.Rows.Count)
                    {
                        COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                        Detail1.WrapText = true;
                        Detail1.Merge();
                        Detail1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail1.ColumnWidth = 5;
                        Detail1.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail1.NumberFormat = "Text";
                        Detail1.Font.Bold = true;
                        Detail1.Font.Size = 8;
                        Detail1.Value2 = "'" + dt.Rows[j]["WS_DATE"].ToString();

                        COMExcel.Range Detail2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 10));
                        Detail2.Merge();
                        Detail2.WrapText = true;
                        Detail2.ColumnWidth = 7;
                        Detail2.Value2 = dt.Rows[j]["WS_NO"].ToString();

                        COMExcel.Range DetailOR_NO = IV.get_Range("B" + (rowex + 11), "D" + (rowex + 11));
                        DetailOR_NO.Merge();
                        DetailOR_NO.WrapText = true;
                        DetailOR_NO.ColumnWidth = 7;
                        DetailOR_NO.Value2 = dt.Rows[j]["OR_NO"].ToString();

                        COMExcel.Range Detail3 = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                        Detail3.Merge();
                        Detail3.WrapText = true;
                        Detail3.Font.Size = 10;
                        Detail3.ColumnWidth = 17;
                        if (!string.IsNullOrEmpty(dt.Rows[j]["COLOR"].ToString()) || !string.IsNullOrEmpty(dt.Rows[j]["P_NAME"].ToString()))
                        {
                            if (string.IsNullOrEmpty(dt.Rows[j]["COLOR"].ToString()) && !string.IsNullOrEmpty(dt.Rows[j]["P_NAME"].ToString()))
                            {
                                Detail3.Value2 = dt.Rows[j]["P_NAME"].ToString();
                            }
                            else if (!string.IsNullOrEmpty(dt.Rows[j]["COLOR"].ToString()) && string.IsNullOrEmpty(dt.Rows[j]["P_NAME"].ToString()))
                            {
                                Detail3.Value2 = dt.Rows[j]["COLOR"].ToString();
                            }
                            else
                            {
                                Detail3.Value2 = dt.Rows[j]["COLOR"].ToString() + "\n" + dt.Rows[j]["P_NAME"].ToString();
                            }
                        }
                        else
                        {
                            Detail3.Value2 = "";
                        }
                        COMExcel.Range Detail4 = IV.get_Range("G" + (rowex + 10), "G" + (rowex + 11));
                        Detail4.Merge();
                        Detail4.WrapText = true;
                        Detail4.Font.Bold = true;
                        Detail4.Font.Size = 9;
                        Detail4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail4.ColumnWidth = 5;
                        Detail4.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail3.ColumnWidth = 7;
                        Detail4.Value2 = dt.Rows[j]["P_NAME3"].ToString();

                        COMExcel.Range Detail5 = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 11));
                        Detail5.Merge();
                        Detail5.WrapText = true;
                        Detail5.ColumnWidth = 7;
                        Detail5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail5.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail5.Font.Bold = true;
                        Detail5.Font.Size = 12;
                        Detail5.NumberFormat = "#,#0.00";
                        Detail5.Value2 = dt.Rows[j]["BQTY"].ToString();

                        COMExcel.Range Detail6 = IV.get_Range("K" + (rowex + 10), "K" + (rowex + 11));
                        Detail6.Merge();
                        Detail6.WrapText = true;
                        Detail6.Font.Bold = true;
                        Detail6.Font.Size = 12;
                        Detail6.ColumnWidth = 5;
                        Detail6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail6.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail6.NumberFormat = "#,#0.00";
                        Detail6.Value2 = dt.Rows[j]["PRICE"].ToString();

                        COMExcel.Range Detail7 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 11));
                        Detail7.Merge();
                        Detail7.WrapText = true;
                        Detail7.ColumnWidth = 3;
                        Detail7.Font.Bold = true;
                        Detail7.Font.Size = 12;
                        Detail7.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail7.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail7.NumberFormat = "#,#0.00";
                        Detail7.Value2 = dt.Rows[j]["AMOUNT"].ToString();

                        COMExcel.Range Detail8 = IV.get_Range("O" + (rowex + 10), "P" + (rowex + 11));
                        Detail8.Merge();
                        Detail8.WrapText = true;
                        Detail8.Font.Bold = true;
                        Detail8.Font.Size = 8;
                        Detail8.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail8.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail8.Value2 = dt.Rows[j]["P_NAME1"].ToString();

                        indexrow++;

                    }
                    else
                    {
                        demm++;
                        if (demm == 1)
                        {
                            if (i == page - 1)
                            {
                                COMExcel.Range title_1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                                title_1.Merge();
                                title_1.Value2 = "";

                                COMExcel.Range title_2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 11));
                                title_2.Merge();
                                title_2.Value2 = "";

                                COMExcel.Range sum_1 = IV.get_Range("K" + (rowex + 10), "K" + (rowex + 11));
                                sum_1.Merge();
                                
                                sum_1.Value2 = "";

                                COMExcel.Range sum_12 = IV.get_Range("O" + (rowex + 10), "P" + (rowex + 11));
                                sum_12.Merge();
                                sum_12.Value2 = "";

                                COMExcel.Range title2 = IV.get_Range("G" + (rowex + 10), "G" + (rowex + 11));
                                title2.Merge();
                                title2.Value2 = "";

                                COMExcel.Range title = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                                title.Merge();
                                title.Value2 = "";

                                COMExcel.Range sum = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 11));
                                sum.Merge();
                                sum.Value2 = "";

                                COMExcel.Range sum1 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 11));
                                sum1.Merge();
                                sum1.Value2 = "";
                            }
                        }
                        else
                        {
                            COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                            Detail1.WrapText = true;
                            Detail1.Merge();
                            Detail1.Value2 = "";
                            Detail1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            Detail1.ColumnWidth = 5;
                            Detail1.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                            COMExcel.Range Detail2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 11));
                            Detail2.Merge();
                            Detail2.Value2 = "";
                            Detail2.WrapText = true;
                            Detail2.ColumnWidth = 7;
                            COMExcel.Range Detail3 = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                            Detail3.Merge();
                            Detail3.Value2 = "";
                            Detail3.WrapText = true;
                            COMExcel.Range Detail4 = IV.get_Range("G" + (rowex + 10), "G" + (rowex + 11));
                            Detail4.Merge();
                            Detail4.Value2 = "";
                            Detail4.WrapText = true;
                            COMExcel.Range Detail5 = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 11));
                            Detail5.Merge();
                            Detail5.Value2 = "";
                            Detail5.WrapText = true;
                            Detail5.ColumnWidth = 2;
                            COMExcel.Range Detail6 = IV.get_Range("K" + (rowex + 10), "K" + (rowex + 11));
                            Detail6.Merge();
                            Detail6.Value2 = "";
                            Detail6.WrapText = true;
                            COMExcel.Range Detail7 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 11));
                            Detail7.Merge();
                            Detail7.Value2 = "";
                            Detail7.WrapText = true;
                            Detail7.ColumnWidth = 3;

                            COMExcel.Range Detail8 = IV.get_Range("O" + (rowex + 10), "P" + (rowex + 11));
                            Detail8.Merge();
                            Detail8.Value2 = "";
                            Detail8.ColumnWidth = 4;
                            Detail8.WrapText = true;

                        }
                        
                    }
                    rowex = rowex + 2;
                }
                if (i == page - 1)
                {
                    COMExcel.Range title = IV.get_Range("E" + (rowex + 11), "F" + (rowex + 11));
                    title.Merge();
                    title.Font.Bold = true;
                    title.Font.Size = 10;
                    title.Value2 = "合  計";

                    COMExcel.Range sum = IV.get_Range("H" + (rowex + 11), "J" + (rowex + 11));
                    sum.Merge();
                    sum.Font.Bold = true;
                    sum.NumberFormat = "#,##0.00";
                    sum.Font.Size = 12;
                    sum.Value2 = Math.Round(dt.AsEnumerable().Sum(x => x.Field<double>("BQTY")),2);

                    COMExcel.Range sum1 = IV.get_Range("L" + (rowex + 11), "N" + (rowex + 11));
                    sum1.Merge();
                    sum1.NumberFormat = "#,##0.00";
                    sum1.Font.Bold = true;
                    sum1.Font.Size = 12;
                    sum1.Value2 = Math.Round(dt.AsEnumerable().Sum(x => x.Field<double>("AMOUNT")),2);

                    if (da2.Rows.Count > 0)
                    {
                        COMExcel.Range title2 = IV.get_Range("E" + (rowex + 12), "F" + (rowex + 12));
                        title2.Merge();
                        title2.WrapText = true;
                        title2.Font.Bold = true;
                        title2.Font.Size = 10;
                        title2.Value2 = "本期實際請款";

                        COMExcel.Range sumCATH = IV.get_Range("L" + (rowex + 12), "N" + (rowex + 12));
                        sumCATH.Merge();
                        sumCATH.NumberFormat = "#,##0.00";
                        sumCATH.Font.Bold = true;
                        sumCATH.Font.Size = 12;
                        sumCATH.Value2 = AMOUNT_CATH;

                        COMExcel.Range WS = IV.get_Range("A" + (rowex + 13), "A" + (rowex + 13));
                        WS.Merge();
                        WS.WrapText = true;
                        WS.Font.Bold = true;
                        WS.NumberFormat = "@";
                        WS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        WS.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        WS.Font.Size = 8;
                        WS.Value2 = DATE;

                        COMExcel.Range WS_NO = IV.get_Range("B" + (rowex + 13), "D" + (rowex + 13));
                        WS_NO.Merge();
                        WS_NO.WrapText = true;
                        WS_NO.Font.Bold = true;
                        WS_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        WS_NO.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        WS_NO.Font.Size = 8;
                        WS_NO.Value2 = WS_NO_NEW;

                        COMExcel.Range P_NAME = IV.get_Range("E" + (rowex + 13), "F" + (rowex + 13));
                        P_NAME.Merge();
                        //P_NAME.WrapText = true;
                        P_NAME.Font.Bold = true;
                        P_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        P_NAME.Font.Size = 8;
                        P_NAME.Value2 = P_NAME_NEW;

                        COMExcel.Range P_NAME3 = IV.get_Range("G" + (rowex + 13), "G" + (rowex + 13));
                        P_NAME3.Merge();
                        P_NAME3.WrapText = true;
                        P_NAME3.Font.Bold = true;
                        P_NAME3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        P_NAME3.Font.Size = 8;
                        P_NAME3.Value2 = "";

                        COMExcel.Range BQTY = IV.get_Range("H" + (rowex + 13), "J" + (rowex + 13));
                        BQTY.Merge();
                        BQTY.WrapText = true;
                        BQTY.Font.Bold = true;
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        BQTY.NumberFormat = "#,##0.00";
                        BQTY.Font.Size = 8;
                        BQTY.Value2 = BQTY_NEW;

                        COMExcel.Range PRICE = IV.get_Range("K" + (rowex + 13), "K" + (rowex + 13));
                        PRICE.Merge();
                        PRICE.WrapText = true;
                        PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        PRICE.Font.Bold = true;
                        PRICE.NumberFormat = "#,##0.00";
                        PRICE.Font.Size = 8;
                        PRICE.Value2 = PRICE;

                        COMExcel.Range AMOUNT = IV.get_Range("L" + (rowex + 13), "N" + (rowex + 13));
                        AMOUNT.Merge();
                        AMOUNT.WrapText = true;
                        AMOUNT.Font.Bold = true;
                        AMOUNT.NumberFormat = "#,##0.00";
                        AMOUNT.Font.Size = 12;
                        AMOUNT.Value2 = AMOUNT_NEW;

                        COMExcel.Range MEMO = IV.get_Range("O" + (rowex + 13), "P" + (rowex + 13));
                        MEMO.Merge();
                        MEMO.WrapText = true;
                        MEMO.Font.Bold = true;
                        MEMO.Font.Size = 10;
                        MEMO.Value2 = ""; 

                        COMExcel.Range title32 = IV.get_Range("E" + (rowex + 14), "F" + (rowex + 14));
                        title32.Merge();
                        title32.Font.Bold = true;
                        title32.Font.Size = 10;
                        title32.Value2 = "湓收少收小計";

                        COMExcel.Range AMOUNT2 = IV.get_Range("L" + (rowex + 14), "N" + (rowex + 14));
                        AMOUNT2.Merge();
                        AMOUNT2.WrapText = true;
                        AMOUNT2.Font.Bold = true;
                        AMOUNT2.NumberFormat = "#,##0.00";
                        AMOUNT2.Font.Size = 12;
                        AMOUNT2.Value2 = AMOUNT_NEW;

                        COMExcel.Range title3 = IV.get_Range("E" + (rowex + 15), "F" + (rowex + 15));
                        title3.Merge();
                        title3.Font.Bold = true;
                        title3.Font.Size = 10;
                        title3.Value2 = "合  計";

                        COMExcel.Range AMOUNT3 = IV.get_Range("L" + (rowex + 15), "N" + (rowex + 15));
                        AMOUNT3.Merge();
                        AMOUNT3.WrapText = true;
                        AMOUNT3.Font.Bold = true;
                        AMOUNT3.NumberFormat = "#,##0.00";
                        AMOUNT3.Font.Size = 12;
                        AMOUNT3.Value2 = Math.Round(float.Parse(AMOUNT_CATH.ToString()) + float.Parse(AMOUNT_NEW.ToString()),2);

                        if (frm2K.rd_HN == false)
                        {
                            COMExcel.Range title4 = IV.get_Range("E" + (rowex + 16), "F" + (rowex + 16));
                            title4.Merge();
                            title4.Font.Bold = true;
                            title4.Font.Size = 10;
                            title4.Value2 = "差 異";

                            COMExcel.Range AMOUNT4 = IV.get_Range("L" + (rowex + 16), "N" + (rowex + 16));
                            AMOUNT4.Merge();
                            AMOUNT4.WrapText = true;
                            AMOUNT4.Font.Bold = true;
                            AMOUNT4.NumberFormat = "#,##0.00";
                            AMOUNT4.Font.Size = 12;
                            AMOUNT4.Value2 = float.Parse(AMOUNT_CATH.ToString()) + float.Parse(AMOUNT_NEW.ToString());

                            COMExcel.Range Na2523 = IV.get_Range("A" + (rowex + 17), "P" + (rowex + 17));
                            Na2523.Merge();
                            Na2523.Font.Bold = true;
                            Na2523.Font.Size = 10;
                            Na2523.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單: " + user_name + "";
                        }
                        else
                        {
                            
                            COMExcel.Range Na2523 = IV.get_Range("A" + (rowex + 16), "P" + (rowex + 16));
                            Na2523.Merge();
                            Na2523.Font.Bold = true;
                            Na2523.Font.Size = 10;
                            Na2523.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單: " + user_name + "";
                        }
                    }   
                    else
                    {
                        COMExcel.Range Na2523 = IV.get_Range("A" + (rowex + 12), "P" + (rowex + 12));
                        Na2523.Merge();
                        Na2523.Font.Bold = true;
                        Na2523.Font.Size = 10;
                        Na2523.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單: " + user_name + "";
                    }    
                    

                }    
                else
                {
                    COMExcel.Range Na25 = IV.get_Range("A" + (rowex + 11), "P" + (rowex + 11));
                    Na25.Merge();
                    Na25.Font.Bold = true;
                    Na25.Font.Size = 10;
                    Na25.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單: " + user_name + "";
                }    
                rowList = rowList + 16;
                rowex = rowex + 12;
                con.BorderAround(worksheet.get_Range("A" + (BorderAround1), "P" + (BorderAround1 + 32)));
                BorderAround1 = BorderAround1 + 44;
            }


        }
    }
}
