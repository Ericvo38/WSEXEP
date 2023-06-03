
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;
using LibraryCalender;
using CrystalDecisions.CrystalReports.Engine;
using static WTERP.WSEXE.Report;
using WTERP.WSEXE;
using WTERP.WSEXE.ReportView;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm2K : Form
    {
        DataProvider con = new DataProvider();
        public frm2K()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2K_Load(object sender, EventArgs e)
        {
            txtDate1.Focus();
            txtDate1.Text = DateTime.Now.ToString("yyyyMM");
            getInfo();
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = con.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        public static string Date1;
        public static string Date1_2;
        public static string Date2_2;
        public static string Date3_2;

        public static string Date1_3;
        public static string Date2_3;
        public static string Date3_3;

        public void Test_MaskedText()
        {

            if (con.Check_MaskedText(txtDate1) == true)
                Date1 = txtDate1.Text;
            if (con.Check_MaskedText(txtDate1_2) == true)
                Date1_2 = txtDate1_2.Text;
            if (con.Check_MaskedText(txtDate2_2) == true)
                Date2_2 = txtDate2_2.Text;
            if (con.Check_MaskedText(txtDate3_2) == true)
                Date3_2 = txtDate3_2.Text;
            if (con.Check_MaskedText(txtDate1_3) == true)
                Date1_3 = txtDate1_3.Text;
            if (con.Check_MaskedText(txtDate2_3) == true)
                Date2_3 = txtDate2_3.Text;
            if (con.Check_MaskedText(txtDate3_3) == true)
                Date3_3 = txtDate3_3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btXemtruwowc_Click(object sender, EventArgs e)
        {
            Test_MaskedText();
            DT_TAP1();
            DT_TAP2();
            DT_TAP3();
            if (tabControl1.SelectedIndex == 0)
            {
                radiocheck();
                radiocheck_2();
                view1();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                view2();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                view3();
            }
        }
        private void radiocheck()
        {
            if (rdCOLOR_C.Checked == true)
            {
                radio_color = 1;
            }
            else if (rdCOLOR_E.Checked == true)
            {
                radio_color = 2;
            }
            else
            {
                radio_color = 3;
            }
        }
        private void radiocheck_2()
        {
            if (rdP_NO_C.Checked == true)
            {
                radio_p_name = 1;
            }
            else if (rdP_NO_E.Checked == true)
            {
                radio_p_name = 2;
            }
            else
            {
                radio_p_name = 3;
            }
        }

        public static int radio_color;
        public static int radio_p_name;

        public static string txt_CNO;
        public static string txt_NP;
        public static string txt_CNO1_2;
        public static string txt_CNO2_2;
        public static string txt_WSNO_1_3;
        public static string txt_WSNO_2_3;

        public static string txt_CNO1_3;
        public static string txt_CNO2_3;
        public static string txt_CHK1;
        public static string txt_CHK2;
        public static string Month_Year;

        public static string Username;


        public static bool rd_Date;
        public static bool rd_ORNO;
        public static bool rd_KHN;
        public static bool rd_HN;

        public static bool rdNB;
        public static bool rdBN;

        public void DT_TAP1()
        {
            //Date1
            txt_CNO = txtCNO.Text;
            rd_Date = rdDate.Checked;
            rd_ORNO = rdOR_NO.Checked;
            rd_KHN = rdKHN.Checked;
            rd_HN = rdHN.Checked;
            //show theo yeu cầu
            rdNB = rdDDNB.Checked;
            rdBN = rdDDBN.Checked;
        }

        public void DT_TAP2()
        {
            txt_CNO1_2 = txtC_NO1.Text;
            txt_CNO2_2 = txtC_NO2.Text;

            txt_WSNO_1_3 = txtWS_NO_C1.Text;
            txt_WSNO_2_3 = txtWS_NO_C2.Text;
        }
        public void DT_TAP3()
        {
            txt_CNO1_3 = txtC_NO1_3.Text;
            txt_CNO2_3 = txtC_NO2_3.Text;
            txt_CHK1 = txtCHK1.Text;
            txt_CHK2 = txtCHK2.Text;
        }
        public void view1()
        {
            if (txtNP.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập GIÁ TRỊ NHỊ PHÂN! ");
                txtNP.Focus();
            }
            else
            {
                if (rdDDBN.Checked == true || rdDDNB.Checked == true)
                {
                    //Report1
                    if (rdTQ.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtDate1.Text) && txtDate1.MaskFull == true && !string.IsNullOrEmpty(txtCNO.Text))
                        {
                            frm2K_Tap1_1TQ f1 = new frm2K_Tap1_1TQ();
                            f1.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (rdVN.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtDate1.Text) && txtDate1.MaskFull == true && !string.IsNullOrEmpty(txtCNO.Text))
                        {
                            frm2K_Tap1_1 f1 = new frm2K_Tap1_1();
                            f1.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (rdPC.Checked == true)
                {
                    string bien = "AND B.OR_NO NOT LIKE'%作廢%' ";
                    string order_by = "";
                    if ((Date1 != string.Empty) && (txtCNO.Text != string.Empty))
                        bien = bien + " AND A.CAL_YM = '" + con.formatstr2(Date1) + "' AND A.C_NO = '" + txtCNO.Text + "'";
                    if ((Date1 != string.Empty) && (txtCNO.Text == string.Empty))
                        bien = bien + " AND A.CAL_YM = '" + con.formatstr2(Date1) + "'";
                    if ((Date1 == string.Empty) && (txtCNO.Text != string.Empty))
                        bien = bien + "AND A.C_NO = '" + txtCNO.Text + "'";
                    if (rdDate.Checked == true)
                    {
                        order_by = order_by + " ORDER BY A.WS_DATE,A.WS_NO,A.NR";
                    }
                    if (rdOR_NO.Checked == true)
                    {
                        order_by = order_by + " ORDER BY A.OR_NO,A.WS_DATE,A.WS_NO,A.NR";
                    }

                    string sql = "SELECT A.WS_DATE,A.WS_NO,'' AS A," + radiocheck_Phocap() + " +''+ " + radiocheck_Phocap_2() + " AS P_NAME,'' B,BQTY,'' C,PRICE,AMOUNT,P_NAME3,MEMO1,MEMO2,MEMO3,MEMO4,MEMO5,MEMO6,MEMO7,'' D,'' E FROM CARB AS A,CARH AS B WHERE B.WS_NO = A.WS_NO AND 1=1 " + bien + " " + order_by + "";
                    //string sql1 = "SELECT A.WS_DATE,A.WS_NO,'' AS A," + radiocheck_Phocap() + " +''+ " + radiocheck_Phocap_2() + " AS P_NAME,'' B,(BQTY*-1) BQTY,'' C,PRICE,(AMOUNT*-1) AMOUNT,P_NAME3,MEMO1,MEMO2,MEMO3,MEMO4,MEMO5,MEMO6,MEMO7,'' D,'' E FROM GIBB AS A,GIBH AS B WHERE A.WS_KIND<>'S' AND A.WS_NO=B.WS_NO AND 1=1 " + bien + " " + order_by + "";

                    System.Data.DataTable da = new System.Data.DataTable();
                   // System.Data.DataTable da2 = new System.Data.DataTable();

                    da = con.readdata(sql);
                    //da2 = con.readdata(sql1);
                   // da.Merge(da2);

                    foreach (DataRow dr in da.Rows)
                    {
                        dr["WS_DATE"] = dr["WS_DATE"].ToString().Substring(4, 4);
                    }
                    if (da != null)
                        ExportToExcel(da);
                }
            }
        }
        public void view2()
        {
            if (rdDS.Checked == true)
            {
                frm2K_Tab2 fr = new frm2K_Tab2();
                fr.ShowDialog();
            }
            else if (rdBTT.Checked == true)
            {
                string SQL1 = "SELECT CARB.C_NO,C_NAME,SUM(BQTY) AS BQTY,SUM(AMOUNT) AS AMOUNT FROM CARB INNER JOIN CARH ON CARH.WS_NO = CARB.WS_NO WHERE 1=1 ";
                if (!string.IsNullOrEmpty(txtC_NO1.Text))
                {
                    SQL1 = SQL1 + " AND CARB.C_NO>='" + txtC_NO1.Text + "'";
                }
                if (!string.IsNullOrEmpty(txtC_NO2.Text))
                {
                    SQL1 = SQL1 + " AND CARB.C_NO<='" + txtC_NO2.Text + "'";
                }
                if (!string.IsNullOrEmpty(txtWS_NO_C1.Text))
                {
                    SQL1 = SQL1 + " AND CARB.WS_NO>='" + txtWS_NO_C1.Text + "'";
                }
                if (!string.IsNullOrEmpty(txtWS_NO_C2.Text))
                {
                    SQL1 = SQL1 + " AND CARB.WS_NO<='" + txtWS_NO_C2.Text + "'";
                }
                if (!string.IsNullOrEmpty(Date1_2))
                {
                    SQL1 = SQL1 + " AND CARB.WS_DATE>='" + con.formatstr2(Date1_2) + "'";
                }
                if (!string.IsNullOrEmpty(Date2_2))
                {
                    SQL1 = SQL1 + " AND CARB.WS_DATE<='" + con.formatstr2(Date2_2) + "'";
                }
                if (!string.IsNullOrEmpty(Date2_3))
                {
                    SQL1 = SQL1 + " AND CARB.CAL_YM>'" + con.formatstr2(Date2_3) + "'";
                }
                SQL1 = SQL1 + " GROUP BY CARB.C_NO,C_NAME";
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = con.readdata(SQL1);
                ReportDocument cryRpt = new ReportDocument();
                cryRpt = new cr_From2K_Tap2();
                cryRpt.SetDataSource(dt);
                ShareReport.repo = cryRpt;
                Report frm = new Report();
                frm.ShowDialog();
            }

        }
        public void view3()
        {
            crytalReport_tab3();
        }
        private void crytalReport_tab3()
        {
            string C_NO1 = txtC_NO1_3.Text;
            string C_NO2 = txtC_NO2_3.Text;
            string Date1 = txtDate1_3.Text;
            string Date2 = txtDate2_3.Text;
            string Date3 = txtDate3_3.Text;
            string txtCHK1_3 = txtCHK1.Text;
            string txtCHK2_3 = txtCHK2.Text;

            string SQL1 = " select CUST.C_ANAME2, GIBB.WS_NO, GIBB.WS_DATE, (GIBB.COLOR_C + '' + GIBB.COLOR + '' + GIBB.P_NAME1) AS PNAME, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBB LEFT JOIN CUST ON GIBB.C_NO  = CUST.C_NO where 1=1";

            if (!string.IsNullOrEmpty(C_NO1))
            {
                SQL1 = SQL1 + " AND GIBB.C_NO>='" + C_NO1 + "'";
            }
            if (!string.IsNullOrEmpty(C_NO2))
            {
                SQL1 = SQL1 + " AND GIBB.C_NO<='" + C_NO2 + "'";
            }
            if (!string.IsNullOrEmpty(txtCHK1_3))
            {
                SQL1 = SQL1 + " AND GIBB.WS_NO>='" + txtCHK1_3 + "'";
            }
            if (!string.IsNullOrEmpty(txtCHK2_3))
            {
                SQL1 = SQL1 + " AND GIBB.WS_NO<='" + txtCHK2_3 + "'";
            }
            if (!string.IsNullOrEmpty(Date1) && txtDate1_3.MaskFull == true)
            {
                SQL1 = SQL1 + " AND GIBB.WS_DATE>='" + con.formatstr2(Date1) + "'";
            }
            if (!string.IsNullOrEmpty(Date2) && txtDate2_3.MaskFull == true)
            {
                SQL1 = SQL1 + " AND GIBB.WS_DATE<='" + con.formatstr2(Date2) + "'";
            }
            if (!string.IsNullOrEmpty(Date3) && txtDate3_3.MaskFull == true)
            {
                SQL1 = SQL1 + " AND GIBB.CAL_YM>='" + con.formatstr2(Date3) + "'";
            }
            SQL1 = SQL1 + " ORDER BY GIBB.C_NO,GIBB.WS_NO,GIBB.NR";

            System.Data.DataTable dt = con.readdata(SQL1);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new ReportDocument();
            cryRpt = new cr_From2K_Tab3();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        private void txtCNO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtCNO.Text = DL;
            }
            else
                txtCNO.Text = "";
        }
        private void txtC_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO1.Text = DL;
            }
            else
                txtC_NO1.Text = "";
        }
        private void txtC_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO2.Text = DL;
            }
            else
                txtC_NO2.Text = "";
        }

        private void txtC_NO1_3_DoubleClick(object sender, EventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO1_3.Text = DL;
            }
            else
                txtC_NO1_3.Text = "";
        }

        private void txtC_NO2_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO1_3.Text = DL;
            }
            else
                txtC_NO2_3.Text = "";
        }

        private void txtWS_NO_C1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5 fr = new frm2CF5();
            fr.ShowDialog();

            string DL = frm2CF5.DL.GetWS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO_C1.Text = DL;
            }
            else
                txtWS_NO_C1.Text = "";
        }

        private void txtWS_NO_C2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5 fr1 = new frm2CF5();
            fr1.ShowDialog();

            string DL = frm2CF5.DL.GetWS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO_C2.Text = DL;
            }
            else
                txtWS_NO_C2.Text = "";
        }

        private void txtDate1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender a = new LibraryCalender.FromCalender();
            a.ShowDialog();
            txtDate1.Text = FromCalender.getDate.ToString("yyyyMM");
        }

        private void txtDate1_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate1_2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate2_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2_2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate3_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate3_2.Text = FromCalender.getDate.ToString("yyyyMM");
        }

        private void txtDate1_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate1_3.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate2_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2_3.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate3_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate3_3.Text = FromCalender.getDate.ToString("yyyyMM");
        }

        public void ExportToExcel(System.Data.DataTable da)
        {
            int ColumnsCount;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            // Header
            worksheet.Cells[2, 1] = "出貨日期";
            worksheet.Cells[2, 2] = "出貨單號";
            worksheet.Cells[2, 3] = "訂單號碼";
            worksheet.Cells[2, 4] = "料號";
            worksheet.Cells[2, 5] = "材料名稱";
            worksheet.Cells[2, 6] = "單位";
            worksheet.Cells[2, 7] = "數量";
            worksheet.Cells[2, 8] = "幣別";
            worksheet.Cells[2, 9] = "單價";
            worksheet.Cells[2, 10] = "金額";
            worksheet.Cells[2, 11] = "厚度";
            worksheet.Cells[2, 12] = " ";
            worksheet.Cells[2, 13] = " ";
            worksheet.Cells[2, 14] = " ";
            worksheet.Cells[2, 15] = " ";
            worksheet.Cells[2, 16] = " ";
            worksheet.Cells[2, 17] = " ";
            worksheet.Cells[2, 18] = " ";
            worksheet.Cells[2, 19] = " ";
            worksheet.Cells[2, 20] = "單據性質";
            worksheet.Cells[2, 21] = "退貨/折扣單號";

            object[] Header = new object[ColumnsCount];
            // column headings
            //for (int i = 0; i < ColumnsCount; i++)
            //    Header[i] = da.Columns[i].ColumnName;

            Microsoft.Office.Interop.Excel.Range HeaderRange = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, ColumnsCount]));
            HeaderRange.Value2 = Header;
            Range HeaderAll = worksheet.get_Range("A2", "U2");
            HeaderAll.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Lavender);

            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 2, ColumnsCount])).Value2 = Cells;

            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 2, ColumnsCount])).HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 2, ColumnsCount])).VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[3, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 2, ColumnsCount])).Font.Size = 12;
            ////Auto Size
            worksheet.Columns.AutoFit();
            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void txtDate1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate1, txtCNO, sender, e);
        }
        private void txtCNO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate1, txtNP, sender, e);
        }

        private void txtNP_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtCNO, txtDate1, sender, e);
        }

        private void txtC_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate3_2, txtC_NO2, sender, e);
        }

        private void txtC_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO1, txtWS_NO_C1, sender, e);
        }

        private void txtWS_NO_C1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO2, txtWS_NO_C2, sender, e);
        }

        private void txtWS_NO_C2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtWS_NO_C1, txtDate1_2, sender, e);
        }

        private void txtDate1_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtWS_NO_C2, txtDate2_2, sender, e);
        }

        private void txtDate2_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDate1_2, txtDate3_2, sender, e);
        }

        private void txtDate3_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2_2, txtC_NO1, sender, e);
        }

        private void txtC_NO1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate3_3, txtC_NO2_3, sender, e);
        }

        private void txtC_NO2_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO1_3, txtDate1_3, sender, e);
        }

        private void txtDate1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO2_3, txtDate2_3, sender, e);
        }

        private void txtDate2_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate1_3, txtCHK1, sender, e);
        }

        private void txtCHK1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2_3, txtCHK2, sender, e);
        }

        private void txtCHK2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtCHK1, txtDate3_3, sender, e);
        }

        private void txtDate3_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtCHK2, txtC_NO1_3, sender, e);
        }
        private string radiocheck_Phocap()
        {
            string a = "";
            if (rdCOLOR_C.Checked == true)
            {
                a = "COLOR_C";
            }
            else if (rdCOLOR_E.Checked == true)
            {
                a = "COLOR";
            }
            else
            {
                a = "COLOR_C + '' + COLOR";
            }
            return a;
        }
        private string radiocheck_Phocap_2()
        {
            string b = "";
            if (rdP_NO_C.Checked == true)
            {
                b = "P_NAME1";
            }
            else if (rdP_NO_E.Checked == true)
            {
                b = "P_NAME";
            }
            else
            {
                b = "P_NAME1 + ''+ P_NAME";
            }
            return b;
        }

    }

}
