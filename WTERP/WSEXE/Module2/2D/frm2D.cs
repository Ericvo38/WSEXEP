using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WTERP.WSEXE;
using System.Data.SqlClient;
using Microsoft.Office;
using Microsoft.Office.Interop.Excel;
using System.Net;
using System.Net.Sockets;
using WTERP.WSEXE.ReportView;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using static WTERP.WSEXE.Report;
using System.Globalization;
using LibraryCalender;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace WTERP
{
    public partial class Form2D : Form
    {
        DataProvider con = new DataProvider();
        public Form2D()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        public class Share2D
        {
            public static int Tab3_check = 0;
            public static string SQL3 = "";
            public static string SQL4 = "";
        }

        string a = "";
        string b = "";
        private void Form2Dqldieutralohang_Load(object sender, EventArgs e)
        {
            getInfo();
            FirstProcesTab3();
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
            toolStripStatusLabel4.Text = frmLogin.ID_NAME;
        }
        #region Process Load Data Main

        string where1 = "";
        string where2 = "";
        string where3 = "";
        string where4 = "";
        string where5 = "";
        string where6 = "";
        System.Data.DataTable dataTab6_1;

        public void GetValueWhere()
        {
            if (txt1t6.Text != "")
            {
                where1 = "AND H.WS_DATE >= '" + con.formatstr2(txt1t6.Text) + "'";
            }
            if (txt2t6.Text != "")
            {
                where2 = " AND H.WS_DATE <= '" + con.formatstr2(txt2t6.Text) + "'";
            }
            if (txt3t6.Text != "")
            {
                where3 = " AND H.C_NO>='" + txt3t6.Text + "'";
            }
            if (txt4t6.Text != "")
            {
                where4 = " AND H.C_NO<='" + txt4t6.Text + "'";
            }
            if (txt5t6.Text != "")
            {
                where5 = " O.T_NAME='" + txt5t6.Text + "'";
            }

            if (rdtatca6.Checked == true)
            {
                if (rdda.Checked == true)
                {
                    where6 = " AND(B.K_NO='1' OR B.K_NO='3')";
                }
                else if (rdbot.Checked == true)
                {
                    where6 = " AND(B.K_NO='2' OR B.K_NO='4')";
                }
                else if (rdtatca62.Checked == true)
                {
                    where6 = " AND(B.K_NO in (1,2,3,4))";
                }
            }
            else if (rdhangmau6.Checked == true)
            {
                if (rdda.Checked == true)
                {
                    where6 = " AND(B.K_NO='2')";
                }
                else if (rdbot.Checked == true)
                {
                    where6 = " AND(B.K_NO='1')";
                }
                else if (rdtatca62.Checked == true)
                {
                    where6 = " AND(B.K_NO='2' OR B.K_NO='1')";
                }
            }
            else if (rdhsx6.Checked == true)
            {
                if (rdda.Checked == true)
                {
                    where6 = " AND(B.K_NO='4')";
                }
                else if (rdbot.Checked == true)
                {
                    where6 = " AND(B.K_NO='3')";
                }
                else if (rdtatca62.Checked == true)
                {
                    where6 = " AND(B.K_NO='4' OR B.K_NO='3')";
                }
            }
        }

        public void dataTab6()
        {

            GetValueWhere();
            string report = "";
            if (cbBuTra.Checked == true)
            {
                report = "SELECT H.WS_DATE,H.WS_NO,H.C_NO,C.C_NAME2" +
                          ", B.OR_NO,B.P_NO,H.MEMO5,B.P_NAME,B.P_NAME3,O.QTY AS QTY_OR,B.BQTY,B.QTY,B.MEMO,B.COLOR,B.COLOR_C,O.T_NAME,B.P_NAME1,B.NR,B.K_NO,C.C_NAME2 as C_NAME" +
                          " FROM CARB B, CARH H,CUST C, ORDB O" +
                          " WHERE H.WS_NO = B.WS_NO AND H.C_NO = C.C_NO and H.OR_NO not like '%作廢%'" +
                          " AND O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString() +
                          " UNION" +
                          " SELECT H.WS_DATE,H.WS_NO,H.C_NO,C.C_NAME2,B.OR_NO,B.P_NO,H.MEMO5,B.P_NAME,B.P_NAME3," +
                          " O.QTY AS QTY_OR,(-1)*B.BQTY,(-1) * B.QTY, B.MEMO,B.COLOR,B.COLOR_C,O.T_NAME,B.P_NAME1,B.NR,B.K_NO,C.C_NAME2 as C_NAME" +
                          " FROM GIBB B, GIBH H,CUST C, ORDB O" +
                          " WHERE H.WS_NO = B.WS_NO AND H.C_NO = C.C_NO and H.OR_NO not like '%作廢%'" +
                          " AND O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString();
            }
            else if (cbKhongBuTra.Checked == true)
            {
                report = "SELECT H.WS_DATE,H.WS_NO,H.C_NO,C.C_NAME2" +
                         ", B.OR_NO,B.P_NO,H.MEMO5,B.P_NAME,B.P_NAME3,O.QTY AS QTY_OR,B.BQTY,B.QTY,B.MEMO,B.COLOR,B.COLOR_C,O.T_NAME,B.P_NAME1,B.NR,B.K_NO,C.C_NAME2 as C_NAME" +
                         " FROM CARB B, CARH H,CUST C, ORDB O" +
                         " WHERE H.WS_NO = B.WS_NO AND H.C_NO = C.C_NO and H.OR_NO not like '%作廢%'" +
                         " AND O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString();

            }
            report = report + " ORDER BY H.WS_DATE,H.C_NO,H.WS_NO,B.NR";

            System.Data.DataTable dt = con.readdata(report);

            dataTab6_1 = dt;
        }
        public void dataTab6_2()
        {
            GetValueWhere();
            string report = "SELECT H.WS_DATE,H.WS_NO,H.C_NO,C.C_NAME2" +
                          ", B.OR_NO,B.P_NO,H.MEMO5,B.P_NAME,B.P_NAME3,O.QTY AS QTY_OR,B.BQTY,B.QTY,B.MEMO,B.COLOR,B.COLOR_C,O.T_NAME,B.P_NAME1,B.NR,B.K_NO,C.C_NAME2 as C_NAME" +
                          " FROM CARB B, CARH H,CUST C, ORDB O" +
                          " WHERE H.WS_NO = B.WS_NO AND H.C_NO = C.C_NO and H.OR_NO not like '%作廢%'" +
                          " AND O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString() +
                          " UNION" +
                          " SELECT H.WS_DATE,H.WS_NO,H.C_NO,C.C_NAME2,B.OR_NO,B.P_NO,H.MEMO5,B.P_NAME,B.P_NAME3," +
                          " O.QTY AS QTY_OR,(-1)*B.BQTY,(-1) * B.QTY, B.MEMO,B.COLOR,B.COLOR_C,O.T_NAME,B.P_NAME1,B.NR,B.K_NO,C.C_NAME2 as C_NAME" +
                          " FROM GIBB B, GIBH H,CUST C, ORDB O" +
                          " WHERE H.WS_NO = B.WS_NO AND H.C_NO = C.C_NO and H.OR_NO not like '%作廢%'" +
                          " AND O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString();
            report = report + " ORDER BY H.WS_DATE,H.C_NO,H.WS_NO,B.NR";

            System.Data.DataTable dt = con.readdata(report);

            dataTab6_1 = dt;
        }
        public void ReportTap6()
        {
            foreach (DataRow item in dataTab6_1.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            ReportDocument cryRpt = new Cr_Form2D_Tab6();
            cryRpt.SetDataSource(dataTab6_1);
            cryRpt.DataDefinition.FormulaFields["FomDate"].Text = "'" + txt1t6.Text + "'";
            cryRpt.DataDefinition.FormulaFields["ToDate"].Text = "'" + txt2t6.Text + "'";
            cryRpt.DataDefinition.FormulaFields["NowDate"].Text = "'" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        public string where1Tab7 = "";
        public string WS_DATE_Proc = "";
        public string ToWS_DATE_Proc = "";
        public void ReportTap7()
        {
            string report = "SELECT * FROM CRB_BRD WHERE O_YEAR=''" + txt1_t7.Text.Substring(0, 4) + "''";

            if (radioButton4.Checked == true)
            {
                if (radioButton2.Checked == true)
                {
                    where1Tab7 = where1Tab7 + " AND K_NO=''2''";
                }
                else if (radioButton3.Checked == true)
                {
                    where1Tab7 = where1Tab7 + " AND K_NO=''4''";
                }
            }
            else if (radioButton5.Checked == true)
            {
                if (radioButton2.Checked == true)
                {
                    where1Tab7 = where1Tab7 + " AND K_NO=''1''";
                }
                else if (radioButton3.Checked == true)
                {
                    where1Tab7 = where1Tab7 + " AND K_NO=''3''";
                }
            }

            if (txt2_t7.Text != "")
            {
                where1Tab7 = where1Tab7 + " AND T_NAME>=''" + txt2_t7.Text + "''";
            }
            if (txt3_t7.Text != "")
            {
                where1Tab7 = where1Tab7 + " AND T_NAME<=''" + txt3_t7.Text + "''";
            }

            if (txt4_t7.Text != "" && txt5_t7.Text != "")
            {
                WS_DATE_Proc = txt4_t7.Text;
                ToWS_DATE_Proc = txt5_t7.Text;
            }
            else if (txt5_t7.Text != "")
            {
                WS_DATE_Proc = txt5_t7.Text;
                ToWS_DATE_Proc = txt5_t7.Text;
            }
            else if (txt4_t7.Text != "")
            {
                WS_DATE_Proc = txt4_t7.Text;
                ToWS_DATE_Proc = txt4_t7.Text;
            }

            report = report + where1Tab7 + " ORDER BY T_NAME,P_NAME_E,P_NAME3";

            string proc = "EXEC InserUpdateCRB_BRD '" + WS_DATE_Proc + "'," + "'" + ToWS_DATE_Proc + "'," + "'" + txt1_t7.Text + "'," + "'" + report + "'";
            System.Data.DataTable dt = con.readdata(proc);
            ReportDocument cryRpt = new Cr_Form2D_Tab7();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }

        public void ReportTap8()
        {
            string WS_DATE1 = "";
            string ToWS_DATE1 = "";
            string WS_DATE = "";
            string ToWS_DATE = "";
            string T_NAME = "";
            string ToT_NAME = "";
            string C_NO = "";
            string TOC_NO = "";
            string KNo = "";

            if (!string.IsNullOrEmpty(txt1_t8.Text))
            {
                WS_DATE1 = txt1_t8.Text.Replace("/", "");
            }
            if (!string.IsNullOrEmpty(txt2_t8.Text))
            {
                ToWS_DATE1 = txt2_t8.Text.Replace("/", "");
            }
            if (!string.IsNullOrEmpty(txt3_t8.Text))
            {
                WS_DATE = txt3_t8.Text.Replace("/", "");
            }
            if (!string.IsNullOrEmpty(txt4_t8.Text))
            {
                ToWS_DATE = txt4_t8.Text.Replace("/", "");
            }
            if (!string.IsNullOrEmpty(txt5_t8.Text))
            {
                T_NAME = txt5_t8.Text;
            }
            if (!string.IsNullOrEmpty(txt6_t8.Text))
            {
                ToT_NAME = txt6_t8.Text;
            }
            if (!string.IsNullOrEmpty(txt7_t8.Text))
            {
                C_NO = txt7_t8.Text;
            }
            if (!string.IsNullOrEmpty(txt8t8.Text))
            {
                TOC_NO = txt8t8.Text;
            }

            //if (radioButton6.Checked == true)
            //{
            if (radioButton6.Checked == true)
            {
                KNo = KNo + "3";
            }
            else if (radioButton7.Checked == true)
            {
                KNo = KNo + "1";
            }
            else if (radioButton1.Checked == true)
            {
                KNo = KNo + "3,1";
            }
            else if (radioButton13.Checked == true)
            {
                KNo = KNo + "4";
            }
            else if (radioButton14.Checked == true)
            {
                KNo = KNo + "2";
            }
            else if (radioButton12.Checked == true)
            {
                KNo = KNo + "4,2)";
            }
            //}

            string report = "EXEC dbo.Report_2Dtap8 N'" + WS_DATE1 + "', N'" + ToWS_DATE1 + "','" + WS_DATE + "','" + ToWS_DATE + "', N'" + T_NAME + "',N'" + ToT_NAME + "',N'" + C_NO + "',N'" + TOC_NO + "',N'" + KNo + "'";

            System.Data.DataTable dt = con.readdata(report);

            int CountStatus1 = 0;
            int CountStatus0 = 0;
            string fl;
            string f2;
            string fl1 = "";
            if (dt.Rows.Count > 0)
            {
                CountStatus1 = dt.AsEnumerable().Where(x => x.Field<string>("Statuss") == "Y").Count();
                CountStatus0 = dt.AsEnumerable().Where(x => x.Field<string>("Statuss") == "N").Count();
                fl = CountStatus1.ToString("F", CultureInfo.InvariantCulture);
                f2 = dt.Rows.Count.ToString("F", CultureInfo.InvariantCulture);
                fl1 = (Decimal.Parse(fl) / Decimal.Parse(f2) * 100).ToString();
            }

            ReportDocument cryRpt = new Cr_Form2D_Tab8();
            cryRpt.SetDataSource(dt);
            cryRpt.DataDefinition.FormulaFields["Status0"].Text = "'" + CountStatus0.ToString() + "'";
            cryRpt.DataDefinition.FormulaFields["Status1"].Text = "'" + CountStatus1.ToString() + "'";
            cryRpt.DataDefinition.FormulaFields["Ratio"].Text = "'" + Math.Round(Decimal.Parse(fl1), 2).ToString() + "%" + "'";
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        public void ReportTap9()
        {
            string where1 = "";
            string ordeyby = "";
            if (!string.IsNullOrEmpty(txt1_t9.Text))
            {
                where1 = where1 + " AND a.WS_DATE >= N'" + txt1_t9.Text.Replace("/", "") + "' ";
            }
            if (!string.IsNullOrEmpty(txt2_t9.Text))
            {
                where1 = where1 + " AND a.WS_DATE <= N'" + txt2_t9.Text.Replace("/", "") + "' ";
            }
            if (!string.IsNullOrEmpty(txt3_t9.Text))
            {
                where1 = where1 + " AND a.T_NAME >= N'" + txt3_t9.Text + "' ";
            }
            if (!string.IsNullOrEmpty(txt4_t9.Text))
            {
                where1 = where1 + " AND a.T_NAME <= N'" + txt4_t9.Text + "' ";
            }
            if (!string.IsNullOrEmpty(txt5_t9.Text))
            {
                where1 = where1 + " AND a.C_NO >= N'" + txt5_t9.Text + "' ";
            }
            if (!string.IsNullOrEmpty(txt6_t9.Text))
            {
                where1 = where1 + " AND a.C_NO <= N'" + txt6_t9.Text + "' ";
            }
            if (radioButton19.Checked == true)
            {
                where1 = where1 + " AND a.K_NO=N'3'";
            }
            else if (radioButton20.Checked == true)
            {
                where1 = where1 + " AND a.K_NO=N'1'";
            }
            else if (radioButton18.Checked == true)
            {
                where1 = where1 + " AND a.K_NO in(3,1)";
            }
            else if (radioButton16.Checked == true)
            {
                where1 = where1 + " AND a.K_NO in(4)";
            }
            else if (radioButton17.Checked == true)
            {
                where1 = where1 + " AND a.K_NO in(2)";
            }
            else if (radioButton15.Checked == true)
            {
                where1 = where1 + " AND a.K_NO in(4,2)";
            }
            if (radioButton24.Checked == true)
            {
                ordeyby = " ORDER BY a.T_NAME,WS_DATE";
            }
            else if (radioButton22.Checked == true)
            {
                ordeyby = " ORDER BY a.C_NO,WS_DATE";
            }
            else
            {
                ordeyby = " ORDER BY WS_DATE,a.C_NO";
            }

            string report = "SELECT a.BRAND,A.WS_NO,a.C_NAME_C,a.OR_NO,a.P_NAME_C,a.THICK,a.QTY,a.WS_DATE,'' AS b,'Y' Statuss FROM " +
                            " (SELECT a.BRAND, b.WS_NO, a.C_NAME_C, a.OR_NO, a.COLOR_C + a.COLOR_E + a.P_NAME_C + a.P_NAME_E AS P_NAME_C, a.THICK, a.QTY, a.WS_DATE, '' AS b, 'Y' Statuss, a.NR, a.T_NAME,a.C_NO " +
                            " FROM ORDB  a" +
                            " LEFT JOIN PRDMK2 b ON b.OR_NO = a.OR_NO AND a.K_NO = b.K_NO AND a.NR = b.NR" +
                            " WHERE 2 > 1" + where1 +
                            " )a" +
                            " WHERE NOT EXISTS(" +
                            " SELECT B.WS_NO FROM GIBB B WHERE B.WS_KIND= 'C' AND ISNULL(B.OR_NO,'')= a.OR_NO" +
                            " AND ISNULL(B.ORD_DATE,'') BETWEEN '" + txt1_t9.Text + "' AND '" + txt2_t9.Text + "' AND ISNULL(B.OR_NR,'')=a.NR)" + ordeyby;
            System.Data.DataTable dt = con.readdata(report);
            ReportDocument cryRpt = new Cr_Form2D_Tab9();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Get_DLTab1();
                Form2D_Tab1 fr = new Form2D_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Get_DLTab2();
                Form2D_Tab2 fr = new Form2D_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Get_DLTab3();
                frm2D_Tab3 fr = new frm2D_Tab3();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Get_DLTab4();
                Form2D_Tab4 fm = new Form2D_Tab4();
                fm.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                getDLTab5();
                frm2D_Tab5 frm = new frm2D_Tab5();
                frm.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5)
            {

                if (rdbaocao.Checked == true)
                {
                    dataTab6();
                    ReportTap6();
                }
                else
                {

                    if (checkBox2.Checked == true)
                    {
                        dataTab6_2();
                        string workbookPath = con.LinkTemplate + "Custom_Excel_CHAMPION1.xls";
                        string w_Path = con.LinkTemplate_SAVE + "Custom_Excel_CHAMPION1.xls";
                        Export_ExcelChitiet(workbookPath, w_Path);
                    }
                    else if (checkBox1.Checked == true)
                    {
                        dataTab6_2();
                        string workbookPath = con.LinkTemplate + "Custom_Excel_CHAMPION.xls";
                        string w_Path = con.LinkTemplate_SAVE + "Custom_Excel_CHAMPION.xls";
                        Export_ExcelRutGon(workbookPath, w_Path);
                    }
                    else
                    {
                        dataTab6();
                        Click_excel();
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                ReportTap7();
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                ReportTap8();
            }
            else if (tabControl1.SelectedIndex == 8)
            {
                ReportTap9();
            }
        }
        private string dataNumber()
        {
            string sql323 = "Select isnull(stt,0) stt from number_Table where ID_number = 1";
            System.Data.DataTable da3 = new System.Data.DataTable();
            da3 = con.readdata(sql323);
            return da3.Rows[0]["stt"].ToString();
        }
        private string dataNumber2()
        {
            string sql323 = "Select isnull(stt2,0) stt2 from number_Table where ID_number = 2";
            System.Data.DataTable da3 = new System.Data.DataTable();
            da3 = con.readdata(sql323);
            return da3.Rows[0]["stt2"].ToString();
        }
        private void Export_ExcelRutGon(string workbookPath, string filePath)
        {
            
            
            string sql = "SELECT B.OR_NO,O.MODEL_E,B.COLOR +' '+ B.P_NAME1 AS P_NAME, O.THICK,CASE WHEN B.MEMO = '' then O.QTY ELSE D.BQTY END AS QTY, B.BQTY as QTY_OUT,O.MODEL_E, CASE WHEN B.K_NO IN(1,2) THEN 'SAMPLE' ELSE CASE WHEN B.K_NO IN(3,4) " +
               "THEN 'PRODUCTION' ELSE '' END END AS NOTE, B.MEMO AS REMARKS,B.PCS,H.WS_DATE,H.C_NO,H.WS_NO,B.NR FROM CARB B INNER JOIN CARH H ON H.WS_NO = B.WS_NO " +
               "INNER JOIN CUST C  on H.C_NO = C.C_NO " +
               "INNER JOIN ORDB O  on O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO LEFT JOIN (SELECT SUM(BQTY) AS BQTY,OR_NO,OR_NR FROM dbo.GIBB GROUP BY OR_NO,OR_NR) D ON D.OR_NO = O.OR_NO AND O.NR = D.OR_NR WHERE H.OR_NO not like '%作廢%' " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString() +
               " ORDER BY H.WS_DATE,H.C_NO,H.WS_NO,B.NR";
            System.Data.DataTable da_New = new System.Data.DataTable();
            da_New = con.readdata(sql);

            string key = "";
            key = dataNumber();

            string sql2 = "UPDATE number_Table SET stt = " + (int.Parse(key) +1) + " from number_Table where ID_number = 1";
            con.exedata(sql2);

            key = dataNumber();

            filePath = con.LinkTemplate_SAVE + "_Excel_CHAMPION_" + key + ".xls";
            if (!string.IsNullOrEmpty(filePath))
            {
                File.Copy(workbookPath, filePath, true);
            }
            else
            {
                MessageBox.Show("Bạn chưa lưu file excel");
                return;
            }

            COMExcel.Application app = new COMExcel.Application();
            object valueMissing = System.Reflection.Missing.Value;

            COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
            false, valueMissing, valueMissing, valueMissing, valueMissing,
            COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
            valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);


            int ColumnsCount;
            if (da_New == null || (ColumnsCount = da_New.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

            COMExcel.Range DATES = IV.get_Range("E1", "G1");
            DATES.Value2 = "date: " + DateTime.Now.ToString("yyyy/MM/dd");

            COMExcel.Range CUST = IV.get_Range("A1", "D1");
            CUST.Value2 = getCustomer();

            app.Visible = true;
            int a = 3;

            for (int i = 0; i <= da_New.Rows.Count - 1; i++)
            {
                COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                OR_NO.Value2 = da_New.Rows[i]["OR_NO"].ToString();

                COMExcel.Range MODEL_E = IV.get_Range("B" + a, "B" + a);
                MODEL_E.Value2 = da_New.Rows[i]["MODEL_E"].ToString();

                COMExcel.Range P_NAME = IV.get_Range("C" + a, "C" + a);
                P_NAME.Value2 = da_New.Rows[i]["P_NAME"].ToString();

                COMExcel.Range THICK = IV.get_Range("D" + a, "D" + a);
                THICK.Value2 = da_New.Rows[i]["THICK"].ToString();

                COMExcel.Range QTY = IV.get_Range("E" + a, "E" + a);
                QTY.Value2 = da_New.Rows[i]["QTY"].ToString();

                COMExcel.Range QTY_OUT = IV.get_Range("F" + a, "F" + a);
                QTY_OUT.Value2 = da_New.Rows[i]["QTY_OUT"].ToString();

                COMExcel.Range NOTE = IV.get_Range("G" + a, "G" + a);
                NOTE.Value2 = da_New.Rows[i]["NOTE"].ToString();

                COMExcel.Range REMARKS = IV.get_Range("H" + a, "H" + a);
                REMARKS.Value2 = da_New.Rows[i]["REMARKS"].ToString();

                a++;
            }
            con.BorderAround(IV.get_Range("A3", "H" + (a - 1)));
            //thoát và thu hồi bộ nhớ cho COM
            //app.Quit();
            releaseObject(book);
            releaseObject(app);
        }
        private string getCustomer()
        {
            string key = "";
            string sql = "SELECT TOP 1 C_NAME2 FROM CUST WHERE C_NO = '" + txt3t6.Text + "'";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(sql);
            if (dt.Rows.Count > 0)
            {
                key = dt.Rows[0]["C_NAME2"].ToString();
            }
            return key;
        }
        private void Export_ExcelChitiet(string workbookPath, string filePath)
        {

            string sql = "SELECT B.OR_NO,O.MODEL_E,B.COLOR +' '+ B.P_NAME1 AS P_NAME, O.THICK,CASE WHEN B.MEMO = '' then O.QTY ELSE D.BQTY END AS QTY, B.BQTY as QTY_OUT,O.MODEL_E, CASE WHEN B.K_NO IN(1,2) THEN 'SAMPLE' ELSE CASE WHEN B.K_NO IN(3,4) " +
                "THEN 'PRODUCTION' ELSE '' END END AS NOTE, B.MEMO AS REMARKS,B.PCS,H.WS_DATE,H.C_NO,H.WS_NO,B.NR,H.MEMO1,H.MEMO2,H.MEMO3,H.MEMO4,H.MEMO5 FROM CARB B INNER JOIN CARH H ON H.WS_NO = B.WS_NO " +
                "INNER JOIN CUST C  on H.C_NO = C.C_NO " +
                "INNER JOIN ORDB O  on O.OR_NO = B.OR_NO AND O.NR = B.OR_NR AND O.K_NO = B.K_NO LEFT JOIN (SELECT SUM(BQTY) AS BQTY,OR_NO,OR_NR FROM dbo.GIBB GROUP BY OR_NO,OR_NR) D ON D.OR_NO = O.OR_NO AND O.NR = D.OR_NR WHERE H.OR_NO not like '%作廢%' " + where1.ToString() + where2.ToString() + where3.ToString() + where4.ToString() + where6.ToString() +
                " ORDER BY H.WS_DATE,H.C_NO,H.WS_NO,B.NR";
            System.Data.DataTable da_New = new System.Data.DataTable();
            da_New = con.readdata(sql);

            string key = "";
            key = dataNumber2();

            string sql2 = "UPDATE number_Table SET stt2 = " + (int.Parse(key) + 1) + " from number_Table where ID_number = 2";
            con.exedata(sql2);

            key = dataNumber2();

            filePath = con.LinkTemplate_SAVE + "_   Excel_CHAMPION_" + key + ".xls";

            if (!string.IsNullOrEmpty(filePath))
            {
                File.Copy(workbookPath, filePath, true);
            }
            else
            {
                MessageBox.Show("Bạn chưa lưu file excel");
                return;
            }
            COMExcel.Application app = new COMExcel.Application();
            object valueMissing = System.Reflection.Missing.Value;

            COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
            false, valueMissing, valueMissing, valueMissing, valueMissing,
            COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
            valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);


            int ColumnsCount;
            if (da_New == null || (ColumnsCount = da_New.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

            COMExcel.Range DATES = IV.get_Range("E1", "G1");
            DATES.Value2 = "date: " + DateTime.Now.ToString("yyyy/MM/dd");

            COMExcel.Range CUST = IV.get_Range("A1", "D1");
            CUST.Value2 = getCustomer();
            app.Visible = true;
            int a = 3;
            float sokien = 0;
            for (int i = 0; i <= da_New.Rows.Count - 1; i++)
            {
                COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                OR_NO.Value2 = da_New.Rows[i]["OR_NO"].ToString();

                COMExcel.Range MODEL_E = IV.get_Range("B" + a, "B" + a);
                MODEL_E.Value2 = da_New.Rows[i]["MODEL_E"].ToString();

                COMExcel.Range P_NAME = IV.get_Range("C" + a, "C" + a);
                P_NAME.Value2 = da_New.Rows[i]["P_NAME"].ToString();

                COMExcel.Range THICK = IV.get_Range("D" + a, "D" + a);
                THICK.Value2 = da_New.Rows[i]["THICK"].ToString();

                COMExcel.Range QTY = IV.get_Range("E" + a, "E" + a);
                QTY.Value2 = da_New.Rows[i]["QTY"].ToString();

                COMExcel.Range QTY_OUT = IV.get_Range("F" + a, "F" + a);
                QTY_OUT.Value2 = da_New.Rows[i]["QTY_OUT"].ToString();

                COMExcel.Range NOTE = IV.get_Range("G" + a, "G" + a);
                NOTE.Value2 = da_New.Rows[i]["NOTE"].ToString();

                COMExcel.Range REMARKS = IV.get_Range("H" + a, "H" + a);
                REMARKS.Value2 = da_New.Rows[i]["REMARKS"].ToString();

                COMExcel.Range PCS = IV.get_Range("I" + a, "I" + a);
                PCS.Value2 = da_New.Rows[i]["PCS"].ToString();

                COMExcel.Range Memo1 = IV.get_Range("K" + a, "L" + a);
                Memo1.Value2 = da_New.Rows[i]["MEMO1"].ToString();

                COMExcel.Range Memo2 = IV.get_Range("L" + a, "L" + a);
                Memo2.Value2 = da_New.Rows[i]["MEMO2"].ToString();

                COMExcel.Range Memo3 = IV.get_Range("M" + a, "M" + a);
                Memo3.Value2 = da_New.Rows[i]["MEMO3"].ToString();

                COMExcel.Range Memo4 = IV.get_Range("N" + a, "N" + a);
                Memo4.Value2 = da_New.Rows[i]["MEMO4"].ToString();

                COMExcel.Range Memo5 = IV.get_Range("O" + a, "O" + a);
                Memo5.Value2 = da_New.Rows[i]["MEMO5"].ToString();

                sokien += float.Parse(da_New.Rows[i]["PCS"].ToString());
                a++;
            }
            COMExcel.Range PCS_MEGER = IV.get_Range("J3", "J" + (a - 1));
            PCS_MEGER.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            PCS_MEGER.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            PCS_MEGER.Merge();
            PCS_MEGER.Value2 = "Tổng số " + sokien + "kiện";

            con.BorderAround(IV.get_Range("A3", "O" + (a - 1)));

            //thoát và thu hồi bộ nhớ cho COM
            //app.Quit();
            releaseObject(book);
            releaseObject(app);
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Process Tabcontrol 1 
        private void txt1_1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();
            txt1_1.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt1_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();
            txt1_2.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt1_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fm = new FormSearchMaterial2();
            fm.ShowDialog();
            txt1_3.Text = FormSearchMaterial2.ID.ID_P_NO;
        } 
        private void txt1_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fm = new FormSearchMaterial2();
            fm.ShowDialog();
            txt1_4.Text = FormSearchMaterial2.ID.ID_P_NO;
        }
        public class Tab1
        {
            public static string t1t1;
            public static string t2t1;
            public static string t3t1;
            public static string t4t1;

            public static bool r1t1;
            public static bool r2t1;
        }
        public void Get_DLTab1()
        {
            Tab1.t1t1 = txt1_1.Text;
            Tab1.t2t1 = txt1_2.Text;
            Tab1.t3t1 = txt1_3.Text;
            Tab1.t4t1 = txt1_4.Text;

            Tab1.r1t1 = rd11_1.Checked;
            Tab1.r2t1 = rd11_2.Checked;
        }
        #endregion

        #region Process Tabcontrol 2
        public class Tab2
        {
            public static string t1t2;
            public static string t2t2;
            public static string t3t2;
            public static string t4t2;
            public static string t5t2;

            public static bool r1t2;
            public static bool r2t2;
            public static bool r3t2;
        }
        public void Get_DLTab2()
        {
            string a = "";
            string b = "";
            string c = "";
            if (con.Check_MaskedText(tb3t2) == true)
            {
                a = tb3t2.Text;
            }
            if (con.Check_MaskedText(tb4t2) == true)
            {
                b = tb4t2.Text;
            }
            if (con.Check_MaskedText(tb5t2) == true)
            {
                c = tb5t2.Text;
            }
            Tab2.t1t2 = tb1t2.Text;
            Tab2.t2t2 = tb2t2.Text;
            Tab2.t3t2 = a;
            Tab2.t4t2 = b;
            Tab2.t5t2 = c;

            Tab2.r1t2 = rd1t2.Checked;
            Tab2.r2t2 = rd2t2.Checked;
            Tab2.r3t2 = rd3t2.Checked;
        }
        #endregion

        #region Process Tabcontrol 3 
        public class Tab3
        {
            public static string txt3_1;
            public static string txt3_2;
            public static string txt3_3;
            public static string txt3_4;
            public static string txt3_5;
            public static string txt3_6;
            public static string txt3_7;
            public static string txt3_8;
            public static string txt3_9;

            //1
            public static bool rdold;
            public static bool rdNew1;
            public static bool rdNew2;

            //2
            public static bool rd32_1;
            public static bool rd32_2;
            public static bool rd32_3;
            public static bool rd32_4;

            //3
            public static bool rd33_1;
            public static bool rd33_2;
            public static bool rd33_3;
        }
        public void Get_DLTab3()
        {
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            if (con.Check_MaskedText(txt3_3) == true)
            {
                a = txt3_3.Text;
            }
            if (con.Check_MaskedText(txt3_4) == true)
            {
                b = txt3_4.Text;
            }
            if (con.Check_MaskedText(txt3_7) == true)
            {
                c = txt3_7.Text;
            }
            if (con.Check_MaskedText(txt3_8) == true)
            {
                d = txt3_8.Text;
            }
            Tab3.txt3_1 = txt3_1.Text;
            Tab3.txt3_2 = txt3_2.Text;
            Tab3.txt3_3 = a;
            Tab3.txt3_4 = b;
            Tab3.txt3_5 = txt3_5.Text;
            Tab3.txt3_6 = txt3_6.Text;
            Tab3.txt3_7 = c;
            Tab3.txt3_8 = d;
            Tab3.txt3_9 = txt3_9.Text;

            //1
            Tab3.rdold = rdold.Checked;
            Tab3.rdNew1 = rdnew1.Checked;
            Tab3.rdNew2 = rdnew2.Checked;

            //2
            Tab3.rd32_1 = rd32_1.Checked;
            Tab3.rd32_2 = rd32_2.Checked;
            Tab3.rd32_3 = rd32_3.Checked;
            Tab3.rd32_4 = rd32_4.Checked;

            //3
            Tab3.rd33_1 = rd33_1.Checked;
            Tab3.rd33_2 = rd33_2.Checked;
            Tab3.rd33_3 = rd33_3.Checked;
        }
        void FirstProcesTab3()
        {
            if (rd32_1.Checked == true)
            {
                txt3_1.Show();
                txt3_2.Show();
                txt3_3.Hide();
                txt3_4.Hide();
                txt3_5.Hide();
                txt3_6.Hide();
                txt3_7.Show();
                txt3_8.Hide();
                txt3_9.Hide();

                lb31.Show();
                lb32.Show();
                lb33.Hide();
                lb34.Hide();
                lb35.Hide();
                lb36.Hide();
                lb37.Show();
                lb38.Hide();
                lb39.Hide();
                gb3_3.Hide();
            }
        }
        private void txt3_1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5 fm = new frm2CF5();
            fm.ShowDialog();
            txt3_1.Text = frm2CF5.DL.GetWS_NO;
        }
        private void txt3_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5 fm = new frm2CF5();
            fm.ShowDialog();
            txt3_2.Text = frm2CF5.DL.GetWS_NO;
        }
        private void txt3_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_3.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void txt3_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_4.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void txt3_5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txt3_5.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt3_6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txt3_6.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt3_7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_7.Text = FromCalender.getDate.ToString("yyyy/MM");
        }
        private void txt3_8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_8.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void txt3_9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fm = new FormSearchBrand();
            fm.ShowDialog();
            txt3_9.Text = FormSearchBrand.ID.TRADE;
        }

        private void rd32_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd32_1.Checked == true)
            {
                txt3_1.Show();
                txt3_2.Show();
                txt3_3.Hide();
                txt3_4.Hide();
                txt3_5.Hide();
                txt3_6.Hide();
                txt3_7.Show();
                txt3_8.Hide();
                txt3_9.Hide();

                lb31.Show();
                lb32.Show();
                lb33.Hide();
                lb34.Hide();
                lb35.Hide();
                lb36.Hide();
                lb37.Show();
                lb38.Hide();
                lb39.Hide();

                gb3_3.Hide();

                gb3_1.Show();
            }
        }
        private void rd32_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rd32_2.Checked == true)
            {
                txt3_1.Show();
                txt3_2.Show();
                txt3_3.Show();
                txt3_4.Show();
                txt3_5.Show();
                txt3_6.Show();
                txt3_7.Hide();
                txt3_8.Hide();
                txt3_9.Show();

                lb31.Show();
                lb32.Show();
                lb33.Show();
                lb34.Show();
                lb35.Show();
                lb36.Show();
                lb37.Hide();
                lb38.Hide();
                lb39.Show();

                gb3_1.Hide();
                gb3_3.Show();
            }

        }
        private void rd32_3_CheckedChanged(object sender, EventArgs e)
        {
            if (rd32_3.Checked == true)
            {
                txt3_1.Show();
                txt3_2.Show();
                txt3_3.Show();
                txt3_4.Show();
                txt3_5.Show();
                txt3_6.Show();
                txt3_7.Hide();
                txt3_8.Show();
                txt3_9.Show();

                lb31.Show();
                lb32.Show();
                lb33.Show();
                lb34.Show();
                lb35.Show();
                lb36.Show();
                lb37.Hide();
                lb38.Show();
                lb39.Show();

                gb3_1.Hide();
                gb3_3.Show();
            }
        }
        private void rd32_4_CheckedChanged(object sender, EventArgs e)
        {
            txt3_1.Show();
            txt3_2.Show();
            txt3_3.Hide();
            txt3_4.Hide();
            txt3_5.Hide();
            txt3_6.Hide();
            txt3_7.Hide();
            txt3_8.Hide();
            txt3_9.Hide();

            lb31.Show();
            lb32.Show();
            lb33.Hide();
            lb34.Hide();
            lb35.Hide();
            lb36.Hide();
            lb37.Hide();
            lb38.Hide();
            lb39.Hide();

            gb3_1.Hide();
            gb3_3.Hide();
        }
        #endregion

        #region  Process tabcontrol 4 
        public class Tab4
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;
            public static string t5;
            public static string t6;
            public static string t7;
            public static string t8;
            public static string t9;
            public static string t10;
            public static string t11;
            public static string t12;
            public static string t13;
            public static string t14;
            public static string t15;
            public static string t16;

            public static bool rd4_1;
            public static bool rd4_2;
            public static bool rd4_3;
        }
        public void Get_DLTab4()
        {
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string f = "";
            if (con.Check_MaskedText(txt4_3) == true)
            {
                a = txt4_3.Text;
            }
            if (con.Check_MaskedText(txt4_4) == true)
            {
                b = txt4_4.Text;
            }
            if (con.Check_MaskedText(txt4_10) == true)
            {
                c = txt4_10.Text;
            }
            if (con.Check_MaskedText(txt4_11) == true)
            {
                d = txt4_11.Text;
            }
            if (con.Check_MaskedText(txt4_14) == true)
            {
                a = txt4_14.Text;
            }

            Tab4.t1 = txt4_1.Text;
            Tab4.t2 = txt4_2.Text;
            Tab4.t3 = a;
            Tab4.t4 = b;
            Tab4.t5 = txt4_5.Text;
            Tab4.t6 = txt4_6.Text;
            Tab4.t7 = txt4_7.Text;
            Tab4.t8 = txt4_8.Text;
            Tab4.t9 = txt4_9.Text;
            Tab4.t10 = c;
            Tab4.t11 = d;
            Tab4.t12 = txt4_12.Text;
            Tab4.t13 = txt4_13.Text;
            Tab4.t14 = f;
            Tab4.t15 = txt4_15.Text;
            Tab4.t16 = txt4_16.Text;

            Tab4.rd4_1 = rd4_1.Checked;
            Tab4.rd4_2 = rd4_2.Checked;
            Tab4.rd4_3 = rd4_3.Checked;

        }
        private void txt4_1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txt4_1.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt4_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txt4_2.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt4_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void txt4_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_4.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void txt4_10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_10.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt4_11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_11.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt4_14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_14.Text = FromCalender.getDate.ToString("yy/MM");
        }

        void ProcesTab4() // Proces tab4 
        {

            string SQL = "SELECT ORDB.WS_DATE, ORDB.MODEL_E, ORDB.T_NAME,ORDB.OR_NO, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.P_NAME_E, ORDB.PRICE, ORDB.OVER0, ORDB.WS_DATE1, ORDB.CLRCARD, ORDB.QTY, ORDB.WS_DATE+'-'+ORDB.NR AS 'NR', ORDB.C_NAME_C, ORDB.QTY AS QTY2, CARB.WS_DATE, CARB.WS_NO, CARB.BQTY FROM ORDB LEFT JOIN CARB ON ORDB.OR_NO = CARB.OR_NO AND ORDB.NR = CARB.OR_NR WHERE 1 = 1 ";

            if (txt4_1.Text != "" && txt4_2.Text != "")
                SQL = SQL + " AND ORDB.C_NO BETWEEN '" + txt4_1.Text + "' AND '" + txt4_2.Text + "' ";
            if (txt4_3.Text != "__/__/__" && txt4_4.Text != "__/__/__")
                SQL = SQL + " AND ORDB.WS_DATE BETWEEN '" + con.formatstr1(txt4_3.Text) + "' AND '" + con.formatstr1(txt4_4.Text) + "' ";
            if (txt4_7.Text != "")
                SQL = SQL + " AND ORDB.COLOR_C = '" + txt4_7.Text + "' ";
            if (txt4_8.Text != "")
                SQL = SQL + " AND ORDB.COLOR_E = '" + txt4_8.Text + "' ";
            // viet tiep cau tim kiem
            //..........

            SQL = SQL + " ORDER BY ORDB.OR_NO ASC";
            Share2D.SQL4 = SQL;
            Form2D_Tab4 fm = new Form2D_Tab4();
            fm.ShowDialog();
        }
        #endregion

        #region Process Tabcontrol 5
        public class Tab5
        {
            public static string tb1t5;
            public static string tb2t5;
            public static string tb3t5;
            public static string tb4t5;
            public static string tb5t5;

            //radiobutton
            public static bool rdmau;
            public static bool rdsanxuat;
            public static bool rd1t5;
            public static bool rd2t5;
            public static bool rd3t5;
        }
        public void getDLTab5()
        {
            string a = "";
            string b = "";
            if (con.Check_MaskedText(tb1t5) == true)
            {
                a = tb1t5.Text;
            }
            if (con.Check_MaskedText(tb2t5) == true)
            {
                b = tb2t5.Text;
            }
            Tab5.tb1t5 = a;
            Tab5.tb2t5 = b;
            Tab5.tb3t5 = tb3t5.Text;
            Tab5.tb4t5 = tb4t5.Text;
            Tab5.tb5t5 = tb5t5.Text;
            //radiobutton
            Tab5.rdmau = rdmau.Checked;
            Tab5.rdsanxuat = rdsanxuat.Checked;
            Tab5.rd1t5 = rd1t5.Checked;
            Tab5.rd2t5 = rd2t5.Checked;
            Tab5.rd3t5 = rd3t5.Checked;
        }
        private void tb1t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1t5.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void tb2t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb2t5.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void tb3t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            tb3t5.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void tb4t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            tb4t5.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void tb5t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fm = new FormSearchBrand();
            fm.ShowDialog();
            tb5t5.Text = FormSearchBrand.ID.B_NO;
        }
        #endregion

        #region Process Tabcontrol 6
        private void txt1t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt1t6.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void tx2t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt2t6.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txt3t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            txt3t6.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void txt4t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            txt4t6.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txt5t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr = new FormSearchBrand();
            fr.ShowDialog();
            string DL1 = FormSearchBrand.ID.TRADE;
            if (DL1 != "")
                txt5t6.Text = DL1;
            else
                txt5t6.Text = "";
        }
        public void Export_Excel(System.Data.DataTable da)
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

            if (da.Rows.Count > 0)
            {
                DateTime Ti = DateTime.Now;
                string T1 = Ti.ToString("yyyy/MM/dd");
                String T2 = "印表日期:" + T1;
                worksheet.Cells[3, 1] = T2;
                // Header
                worksheet.Cells[4, 1] = "日期";
                worksheet.Cells[4, 2] = "單號";
                //worksheet.Cells[4, 3] = "客戶編號";
                worksheet.Cells[4, 4] = "客戶名稱";
                worksheet.Cells[4, 5] = "訂單號碼";
                worksheet.Cells[4, 6] = "產品編號";
                worksheet.Cells[4, 7] = "型體";
                worksheet.Cells[4, 8] = "產品名稱";
                worksheet.Cells[4, 9] = "規格";
                worksheet.Cells[4, 10] = "訂單數量";
                worksheet.Cells[4, 11] = "出貨數量";
                worksheet.Cells[4, 12] = "重量";
                worksheet.Cells[4, 13] = "備註";
                worksheet.Cells[4, 14] = "顏色(英)";
                worksheet.Cells[4, 15] = "顏色(中)";
                worksheet.Cells[4, 16] = "品牌";
                worksheet.Cells[4, 17] = "產品名稱(英)";

                object[] Header = new object[ColumnsCount];
                // column headings
                //for (int i = 0; i < ColumnsCount; i++)
                //    Header[i] = da.Columns[i].ColumnName;

                Microsoft.Office.Interop.Excel.Range HeaderRange = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[5, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[5, ColumnsCount]));
                HeaderRange.Value2 = Header;
                Range HeaderAll = worksheet.get_Range("A4", "Q5");
                HeaderAll.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Lavender);

                // Show DataTable 
                var hoang = da.AsEnumerable().GroupBy(r => new { Col1 = r["C_NO"], Col2 = r["WS_DATE"] }).Select(g=> g.OrderBy(r => r["WS_DATE"]).First()).OrderBy(x => x["WS_DATE"]).CopyToDataTable();
                int t = 0;
                //int h = 6;
                int RowsCount = da.Rows.Count + (5 + hoang.Rows.Count);
                object[,] Cells = new object[RowsCount, ColumnsCount];
                double SumQty_Or = 0;
                double SumBQTY = 0;
                double SumQTY = 0;

                for (int a = 0; a < hoang.Rows.Count; a++)
                {
                    var test = da.AsEnumerable().Where(x => x["C_NO"].ToString() == hoang.Rows[a]["C_NO"].ToString() && x["WS_DATE"].ToString() == hoang.Rows[a]["WS_DATE"].ToString()).CopyToDataTable();
                    var Qty_Or = test.AsEnumerable().Sum(x => x.Field<double>("QTY_OR"));
                    var BQTY = test.AsEnumerable().Sum(x => x.Field<double>("BQTY"));
                    var QTY = test.AsEnumerable().Sum(x => x.Field<double>("QTY"));
                    for (int j = 0; j < test.Rows.Count; j++)
                    {
                        for (int i = 0; i < test.Columns.Count - 3; i++)
                        {
                            Cells[t, i] = test.Rows[j][i];
                        }
                        t = t + 1;

                    }
                    Cells[t, 8] = "每日合計:";
                    Cells[t, 9] = Qty_Or;
                    Cells[t, 10] = BQTY;
                    Cells[t, 11] = QTY;
                    SumQty_Or += Qty_Or;
                    SumBQTY += BQTY;
                    SumQTY += QTY;
                    t = t + 1;
                }

                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;
                //Kẻ khung toàn bộ

                Range Total = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 9]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 9]));
                Total.Value2 = "總合計:";
                Total.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Range TotalResulft = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 10]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 10]));
                TotalResulft.Value2 = SumQty_Or;
                TotalResulft.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range TotalResulft2 = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 11]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 11]));
                TotalResulft2.Value2 = SumBQTY;
                TotalResulft2.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                Range TotalResulft3 = worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 12]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 1, 12]));
                TotalResulft3.Value2 = SumQTY;
                TotalResulft3.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                //Auto Size
                worksheet.Columns.AutoFit();
                //thoát và thu hồi bộ nhớ cho COM
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }
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
        public void check()
        {
            if (con.Check_MaskedText(txt1t6) == true)
            {
                a = con.formatstr2(txt1t6.Text);
            }
            if (con.Check_MaskedText(txt2t6) == true)
            {
                b = con.formatstr2(txt2t6.Text);
            }
        }
        public void Click_excel()
        {
            Export_Excel(dataTab6_1);
        }
        #endregion

        #region Process Tabcontrol 7

        #endregion

        #region Process Tabcontrol 8

        #endregion

        #region Process Tabcontrol 9

        #endregion

        #region Process KeyDown
        private void txt1_1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt6_t9, txt1_2, sender, e);
        }

        private void txt1_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt1_1, txt1_3, sender, e);
        }
        private void txt1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt1_2, txt1_4, sender, e);
        
        }

        private void txt1_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt1_3, tb1t2, sender, e);
            
        }

        private void tb1t2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt1_4, tb2t2, sender, e);
        }

        private void tb2t2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(tb1t2, tb3t2, sender, e);
          
        }

        private void tb3t2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(tb2t2, tb4t2,sender, e);
        }

        private void tb4t2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(tb3t2, tb5t2, sender, e);
        }
        private void tb5t2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(tb4t2, txt3_1, sender, e);
        }

        private void txt3_1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(tb5t2, txt3_2, sender, e);
        }

        private void txt3_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_1, txt3_3, sender, e);
        }
        private void txt3_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_2, txt3_4, sender, e);
        }
        private void txt3_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_3, txt3_5, sender, e);
        }

        private void txt3_5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_4, txt3_6, sender, e);
        }

        private void txt3_6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_5, txt3_7, sender, e);
        }

        private void txt3_7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_6, txt3_8, sender, e);
        }

        private void txt3_8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_7, txt3_9, sender, e);
        }

        private void txt3_9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_8, txt4_1, sender, e);
        }

        private void txt4_1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt3_9, txt4_2, sender, e);
        }

        private void txt4_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_1, txt4_3, sender, e);
        }

        private void txt4_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_2, txt4_4, sender, e);
        }

        private void txt4_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_3, txt4_5, sender, e);
        }

        private void txt4_5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_4, txt4_6, sender, e);
        }

        private void txt4_6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_5, txt4_7, sender, e);
        }

        private void txt4_7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_6, txt4_8, sender, e);
        }

        private void txt4_8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_7, txt4_9, sender, e);
        }

        private void txt4_9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_8, txt4_10, sender, e);
        }
        private void txt4_10_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_9, txt4_11, sender, e);
        }

        private void txt4_11_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_10, txt4_12, sender, e);
        }

        private void txt4_12_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_11, txt4_13, sender, e);
        }

        private void txt4_13_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_12, txt4_14, sender, e);
        }
        private void txt4_14_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_13, txt4_15, sender, e);
        }

        private void txt4_15_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_14, txt4_16, sender, e);
           
        }

        private void txt4_16_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_15, tb1t5, sender, e);
        }

        private void tb1t5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4_16, tb2t5, sender, e);
        }

        private void tb2t5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(tb1t5, tb3t5, sender, e);
        }

        private void tb3t5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(tb2t5, tb4t5, sender, e);
        }

        private void tb4t5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(tb3t5, tb5t5, sender, e);
        }

        private void tb5t5_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(tb4t5, txt1t6, sender, e);
        }

        private void txt1t6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(tb4t5, txt2t6, sender, e);
        }

        private void txt2t6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt1t6, txt3t6, sender, e);
        }

        private void txt3t6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt2t6, txt4t6, sender, e);
        }

        private void txt4t6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt3t6, txt5t6, sender, e);
        }

        private void txt5t6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt4t6, txt1_t7, sender, e);
        }

        private void txt1_t7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt5t6, txt2_t7, sender, e);
        }

        private void txt2_t7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt1_t7, txt3_t7, sender, e);
        }

        private void txt3_t7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt2_t7, txt4_t7, sender, e);
        }

        private void txt4_t7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_t7, txt5_t7, sender, e);
        }
        private void txt5_t7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt4_t7, txt1_t8, sender, e);

        }

        private void txt1_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt5_t7, txt2_t8, sender, e);
        }

        private void txt2_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt1_t8, txt3_t8, sender, e);
        }

        private void txt3_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt2_t8, txt4_t8, sender, e);
        }

        private void txt4_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_t8, txt5_t8, sender, e);
        }

        private void txt5_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_t8, txt6_t8, sender, e);
          
        }

        private void txt6_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt5_t8, txt7_t8, sender, e);
        }

        private void txt7_t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt6_t8, txt6_t8, sender, e);

        }

        private void txt8t8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt7_t8, txt1_t9, sender, e);
        }

        private void txt1_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt8t8, txt2_t9, sender, e);
        }

        private void txt2_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt1_t9, txt3_t9, sender, e);
        }
        private void txt3_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt2_t9, txt4_t9, sender, e);
        }

        private void txt4_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt3_t9, txt5_t9, sender, e);
        }

        private void txt5_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_t9, txt6_t9, sender, e);
        }

        private void txt6_t9_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt6_t9, txt1_1, sender, e);
        }

        #endregion

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();
                txt1_1.Text = frm2CustSearch.ID.ID_CUST;
            }
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btxemtruoc.PerformClick();
        }

        private void txt1_t7_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt5_t7, txt2_t7, sender, e);
        }

        private void txt4_t7_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt3_t7, txt5_t7, sender, e);
        }

        private void txt5_t7_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt1_t7, txt4_t7, sender, e);
        }

        private void txt1_t8_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt8t8, txt2_t8, sender, e);
        }

        private void txt2_t8_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt1_t8, txt3_t8, sender, e);
        }

        private void txt3_t8_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txt2_t8, txt4_t8, sender, e);
        }

        private void txt4_t8_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_t8, txt5_t8, sender, e);
        }

        private void txt1_t9_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt6_t9, txt2_t9, sender, e);
        }

        private void txt2_t9_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt1_t9, txt3_t9, sender, e);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tb3t2_DoubleClick(object sender, EventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb3t2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb4t2_DoubleClick(object sender, EventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb4t2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb5t2_DoubleClick(object sender, EventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb5t2.Text = FromCalender.getDate.ToString("yyyyMM");
        }

        private void txt1_t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt1_t7.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txt4_t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_t7.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txt5_t7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt5_t7.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txt1_t8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt1_t8.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txt2_t8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt2_t8.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txt3_t8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_t8.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txt4_t8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_t8.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txt1_t9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt1_t9.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txt2_t9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt2_t9.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void txt2_t7_DoubleClick(object sender, EventArgs e)
        {
            frm2BrandSearch frm2Brand = new frm2BrandSearch();
            frm2Brand.ShowDialog();
            txt2_t7.Text = frm2BrandSearch.getInfo.ID_BRAND;
        }

        private void txt3_t7_DoubleClick(object sender, EventArgs e)
        {
            frm2BrandSearch frm2Brand = new frm2BrandSearch();
            frm2Brand.ShowDialog();
            txt3_t7.Text = frm2BrandSearch.getInfo.ID_BRAND;
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btxemtruoc.PerformClick();
            }    
        }
    }
}
