using LibraryCalender;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WTERP.WSEXE;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm3L : Form
    {
        // DataGridViewGrouper grouper;
        DataProvider data = new DataProvider();
        public static double HANG_SO = 0.0929;
        public frm3L()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();

        private void frm3L_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            con.CheckLoad(menuStrip1);
            loadinfo();
            loadfirst();
            con.DGV(DGV1);
            con.DGV(DGV2);
        }
        private void loadfirst()
        {
            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,DONG NAI PROVINCE,VIET NAM.";
            txtFr.Text = lbUserName.Text;
            textBox3.Text = lbUserName.Text;

            this.DGV1.Columns["V_TheTich"].Visible = false;
            this.DGV1.Columns["CNO_STT"].Visible = false;
            this.DGV1.Columns["lstPackage"].Visible = false;
            this.DGV1.Columns["Number"].Visible = false;

           
        }

        void loadinfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO.Text = DL;
                txtC_NAME.Text = frm2CustSearch.ID.NAME_C;
                txtADR.Text = frm2CustSearch.ID.ADR3;
            }
            else
            {
                txtC_NO.Text = "";
                txtC_NAME.Text = "";
                txtADR.Text = "";
            }

        }
        public static string F_CNO;
        public static string F_CNAME;
        public static string F_ADDRESS;

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Cur = int.Parse(DGV2.CurrentCell.ColumnIndex.ToString());
            if (Cur == 11)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                this.DGV2.CurrentRow.Cells["EDT"].Value = "";
                this.DGV2.CurrentRow.Cells["EDT"].Value = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (con.checkExists("select * from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'") == true)
            {
                string sql = "select* from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'";
                DataTable dt1 = con.readdata(sql);
                foreach (DataRow dr in dt1.Rows)
                {
                    txtC_NO.Text = dr["C_NO"].ToString();
                    txtC_NAME.Text = dr["C_NAME"].ToString();
                    txtADR.Text = dr["ADDRESS"].ToString();
                    txtTEL.Text = dr["PHONE"].ToString();
                    txtFAX.Text = dr["FAX"].ToString();
                    txtATTN.Text = dr["ATTN"].ToString();
                    txtHSCODE.Text = dr["HSCODE"].ToString();
                    txtTAXID.Text = dr["TAXID"].ToString();
                    txtShipto.Text = dr["SHIPTO"].ToString();
                    txtShipment.Text = dr["SHIPMENT"].ToString();
                    txtDestination.Text = dr["DESTINATION"].ToString();
                }
            }
            else
            {
                string SQL1 = "select C_NO, C_NAME, ADR3 from CUST where C_NO = '" + txtC_NO.Text + "'";
                DataTable dt1 = con.readdata(SQL1);
                foreach (DataRow dr in dt1.Rows)
                {
                    txtC_NO.Text = dr["C_NO"].ToString();
                    txtC_NAME.Text = dr["C_NAME"].ToString();
                    txtADR.Text = dr["ADR3"].ToString();
                    txtTEL.Text = "";
                    txtFAX.Text = "";
                    txtATTN.Text = "";
                    txtHSCODE.Text = "";
                    txtTAXID.Text = "";
                    txtShipto.Text = "";
                    txtShipment.Text = "";
                    txtDestination.Text = "";
                }
            }
            string sql1 = "SELECT MAX(INVOICE) as MAX_INVOICE FROM tblHistoryInvoice where C_NO = '"+txtC_NO.Text+"'";
            DataTable dataTable = new DataTable();
            dataTable = con.readdata(sql1);
            lblInvoice.Text = dataTable.Rows[0]["MAX_INVOICE"].ToString();
        }

        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btdong.PerformClick();
        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            setDataExport();
        }
        private void setDataExport()
        {
            if (radioall.Checked == true)
            {
                if (rdHangMau.Checked == true)
                {
                    Export_Excel_Mau();
                }
                else if (rdHangSX.Checked == true)
                {
                    Export_Excel_SX();
                }
                Export_Excel_2();
            }
            else if (rdinvoice.Checked == true)
            {
                if (rdHangMau.Checked == true)
                {
                    Export_Excel_Mau();
                }
                else if (rdHangSX.Checked == true)
                {
                    Export_Excel_SX();
                }
            }
            else if (radioproforma.Checked == true)
            {
                Export_Excel_2();
            }
        }

        private void Export_Excel_2()
        {
            string workbookPath = con.LinkTemplate + "Sample_PROFORMAINVOICE.xls";
            string filePath = con.LinkTemplate_SAVE + "Sample_PROFORMAINVOICE.xls";

            if (con.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(con.LinkTemplate_SAVE);
                }
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

                COMExcel.Worksheet TAB6 = (COMExcel.Worksheet)book.Worksheets[1];
               

                COMExcel.Range C_NAME6 = TAB6.get_Range("B4", "B4");
                C_NAME6.Value2 = txtC_NAME.Text;
                // nhớ chia dòng
                COMExcel.Range ARD6 = TAB6.get_Range("A5", "A5");
                ARD6.Value2 = "ADDRESS: " + txtADR.Text;

                COMExcel.Range DATE6 = TAB6.get_Range("F9", "F9");
                DATE6.EntireColumn.NumberFormat = "dd-mmm-yy";
                DATE6.Value2 = txtDate.Text;

                COMExcel.Range PINO = TAB6.get_Range("F7", "F7");

                PINO.Value2 = textBox6.Text;

                COMExcel.Range ATTN6 = TAB6.get_Range("B7", "B7");
                ATTN6.Value2 = txtATTN.Text;

                COMExcel.Range TEL6 = TAB6.get_Range("B8", "B8");
                TEL6.Value2 = txtTEL.Text;

                COMExcel.Range FAX6 = TAB6.get_Range("B9", "B9");
                FAX6.Value2 = txtFAX.Text;

                COMExcel.Range Fr6 = TAB6.get_Range("F6", "F6");
                Fr6.Value2 = textBox3.Text;

                if (rdHangMau.Checked == true && tabControl1.SelectedIndex == 0)
                {
                    COMExcel.Range Brand6 = TAB6.get_Range("A12", "B12");
                    Brand6.Merge();
                    Brand6.Font.Bold = true;
                    Brand6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    if (DGV1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(this.DGV1.Rows[0].Cells["BRAND"].Value.ToString()))
                        {
                            Brand6.Value2 = "BRAND: " + this.DGV1.Rows[0].Cells["BRAND"].Value.ToString().ToUpper();
                        }
                        else
                        {
                            Brand6.Value2 = "";
                        }
                    }
                }
                else if (rdHangSX.Checked == true && tabControl1.SelectedIndex == 1)
                {
                    COMExcel.Range Brand6 = TAB6.get_Range("A12", "B12");
                    Brand6.Merge();
                    Brand6.Font.Bold = true;
                    Brand6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    if (DGV1.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(this.DGV2.Rows[0].Cells["BRAND"].Value.ToString()))
                        {
                            Brand6.Value2 = "BRAND: " + this.DGV2.Rows[0].Cells["BRAND1"].Value.ToString().ToUpper();
                        }
                        else
                        {
                            Brand6.Value2 = "";
                        }
                    }
                }
                COMExcel.Range FOB = TAB6.get_Range("E12", "E12");
                FOB.Font.Bold = true;
                FOB.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                FOB.Value2 = "FOB-HCM PRICE";

                int tab61 = 13;
                int tab62 = 14;
                int tab63 = 15;
                object S6 = "";

                for (int i = 0; i < DGV2.Rows.Count; i++)
                {
                    //row 13
                    COMExcel.Range OR_NO6 = TAB6.get_Range("A" + tab61, "B" + tab61);
                    OR_NO6.Font.Bold = true;
                    OR_NO6.Merge();
                    OR_NO6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    OR_NO6.Value2 = DGV2.Rows[i].Cells["OR_NO1"].Value.ToString();

                    S6 = DGV2.Rows[i].Cells["THICK1"].Value + " " + DGV2.Rows[i].Cells["P_NAME_E1"].Value.ToString();
                    COMExcel.Range P_NAME6 = TAB6.get_Range("A" + tab62, "B" + tab62);
                    P_NAME6.Merge();
                    P_NAME6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    P_NAME6.Font.Bold = true;
                    P_NAME6.EntireRow.AutoFit();
                    P_NAME6.Value2 = S6.ToString();

                    COMExcel.Range COLOR = TAB6.get_Range("A" + tab63, "B" + tab63);
                    COLOR.Font.Bold = true;
                    COLOR.Merge();
                    COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    COLOR.Value2 = DGV2.Rows[i].Cells["COLOR_E1"].Value.ToString();

                    //QTY
                    COMExcel.Range QTY6 = TAB6.get_Range("C" + tab63, "C" + tab63);
                    QTY6.Font.Bold = true;
                    QTY6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY6.Value2 = string.Format("{0:0.00}", DGV2.Rows[i].Cells["QTY1"].Value.ToString());

                    if (rdHangMau.Checked == true)
                    {
                        //EDT
                        COMExcel.Range EDT = TAB6.get_Range("D" + tab63, "D" + tab63);
                        EDT.Font.Bold = true;
                        EDT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        EDT.EntireColumn.NumberFormat = "dd-mmm";
                        EDT.Value2 = DGV2.Rows[i].Cells["EDT"].Value.ToString();
                    }
                    else if (rdHangSX.Checked == true)
                    {
                        //EDT
                        COMExcel.Range EDT = TAB6.get_Range("D" + tab63, "D" + tab63);
                        EDT.Font.Bold = true;
                        EDT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        EDT.EntireColumn.NumberFormat = "dd-mmm";
                        EDT.EntireColumn.Hidden = true;
                        EDT.Value2 = "";
                    }
                    //price
                    COMExcel.Range PRICE6 = TAB6.get_Range("E" + tab63, "E" + tab63);
                    PRICE6.Font.Bold = true;
                    PRICE6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    PRICE6.Value2 = "US$" + string.Format("{0:0.00}", DGV2.Rows[i].Cells["PRICE1"].Value.ToString());
                    //total
                    COMExcel.Range AMOUNT6 = TAB6.get_Range("F" + tab63, "F" + tab63);
                    AMOUNT6.Font.Bold = true;
                    AMOUNT6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AMOUNT6.Value2 = "US$" + string.Format("{0:0.00}", DGV2.Rows[i].Cells["TOTAL1"].Value.ToString());

                    tab61 = tab61 + 3; tab62 = tab62 + 3; tab63 = tab63 + 3;
                }

                COMExcel.Range T1 = TAB6.get_Range("A" + (tab61) + "", "B" + (tab61) + "");
                T1.Merge();
                T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T1.Font.Bold = true;
                T1.Value2 = "TOTAL";
                TAB6.get_Range("A" + (tab61) + "", "F" + (tab61) + "").Cells.BorderAround();

                int sc = DGV2.Rows.Count;
                float BQTY_SUM6 = 0;
                float AMOUNT_SUM6 = 0;
                for (int i = 0; i < sc; i++)
                {
                    BQTY_SUM6 += float.Parse(DGV2.Rows[i].Cells["QTY1"].Value.ToString());
                    AMOUNT_SUM6 += float.Parse(DGV2.Rows[i].Cells["TOTAL1"].Value.ToString());
                }
                COMExcel.Range T2 = TAB6.get_Range("C" + (tab61) + "", "C" + (tab61) + "");
                T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T2.Font.Bold = true;
                T2.Value2 = string.Format("{0:0.00}", BQTY_SUM6);

                COMExcel.Range T3 = TAB6.get_Range("F" + (tab61) + "", "F" + (tab61) + "");
                T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T3.Font.Bold = true;
                T3.EntireColumn.NumberFormat = "General";
                T3.Value2 = string.Format("{0:0.00}", AMOUNT_SUM6);
                //// row
                COMExcel.Range A6 = TAB6.get_Range("A" + (tab61 + 2), "A" + (tab61 + 2));
                A6.Font.Bold = true;
                A6.Value2 = "Payment Term: ";

                // row
                COMExcel.Range A62 = TAB6.get_Range("B" + (tab61 + 2), "B" + (tab61 + 2));
                A62.Font.Bold = true;
                A62.Value2 = txtTermOfpayment.Text;

                //row 24
                COMExcel.Range A100 = TAB6.get_Range("A" + (tab61 + 4), "A" + (tab61 + 4));
                A100.Font.Bold = true;
                A100.Value2 = "BENEFICIARY: ";

                //row 24
                COMExcel.Range A1002 = TAB6.get_Range("B" + (tab61 + 4), "B" + (tab61 + 4));
                A1002.Font.Bold = true;
                A1002.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                //row 24
                COMExcel.Range A1003 = TAB6.get_Range("B" + (tab61 + 5), "B" + (tab61 + 5));
                A1003.Font.Bold = true;
                A1003.Value2 = "NO. 102, ZHENFU RD, FAST DIST, TAICHUNG CITY 401, TAIWAN (R.O.C)";
                //row 24
                COMExcel.Range A1004 = TAB6.get_Range("B" + (tab61 + 6), "B" + (tab61 + 6));
                A1004.Font.Bold = true;
                A1004.Value2 = "TEL : 886-4-22116696       FAX: 886-4-22116683";

                COMExcel.Range A7 = TAB6.get_Range("A" + (tab61 + 7) + "", "A" + (tab61 + 7) + "");
                A7.Font.Bold = true;
                A7.Value2 = "ADIVISING BANK: ";

                COMExcel.Range A72 = TAB6.get_Range("B" + (tab61 + 7) + "", "B" + (tab61 + 7) + "");
                A72.Font.Bold = true;
                A72.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO., LTD";

                COMExcel.Range A73 = TAB6.get_Range("B" + (tab61 + 8) + "", "B" + (tab61 + 8) + "");
                A73.Font.Bold = true;
                A73.Value2 = "HONG KONG BRANCH";

                COMExcel.Range A74 = TAB6.get_Range("B" + (tab61 + 9) + "", "B" + (tab61 + 9) + "");
                A74.Font.Bold = true;
                A74.Value2 = "SWIFT CODE:ICBCHKHH";



                COMExcel.Range A8 = TAB6.get_Range("A" + (tab61 + 10) + "", "A" + (tab61 + 10) + "");
                A8.Font.Bold = true;
                A8.Value2 = "A/C NO: ";

                COMExcel.Range A82 = TAB6.get_Range("B" + (tab61 + 10) + "", "B" + (tab61 + 10) + "");
                A82.Font.Bold = true;
                A82.Font.Underline = true;
                A82.Value2 = "965-11-003037";

                COMExcel.Range A9 = TAB6.get_Range("A" + (tab61 + 11) + "", "A" + (tab61 + 11) + "");
                A9.Font.Bold = true;
                A9.Value2 = "BANK ADDRESS: ";

                COMExcel.Range A92 = TAB6.get_Range("B" + (tab61 + 11) + "", "B" + (tab61 + 11) + "");
                A92.Font.Bold = true;
                A92.Value2 = "SUIT 2201, 22/F, PRUDENTIAL TOWER, THE GATEWAY, HARBOUR CITY,";

                COMExcel.Range A93 = TAB6.get_Range("B" + (tab61 + 12) + "", "B" + (tab61 + 12) + "");
                A93.Font.Bold = true;
                A93.Value2 = "21 CANTON ROAD, TSIMSHATSUI, KOWLOON, HONG KONG";

                COMExcel.Range A10 = TAB6.get_Range("A" + (tab61 + 13) + "", "A" + (tab61 + 13) + "");
                A10.Font.Bold = true;
                A10.Value2 = "SHIPMENT: ";

                COMExcel.Range A102 = TAB6.get_Range("B" + (tab61 + 13) + "", "B" + (tab61 + 13) + "");
                A102.Font.Bold = true;
                A102.Value2 = txtShipment.Text;


                COMExcel.Range A11 = TAB6.get_Range("A" + (tab61 + 14) + "", "A" + (tab61 + 14) + "");
                A11.Font.Bold = true;
                A11.Value2 = "SHIP TO: ";

                COMExcel.Range A112 = TAB6.get_Range("B" + (tab61 + 14) + "", "B" + (tab61 + 14) + "");
                A112.Font.Bold = true;
                A112.Value2 = txtShipto.Text;

                COMExcel.Range REMARK1 = TAB6.get_Range("A" + (tab61 + 15) + "", "F" + (tab61 + 15) + "");
                REMARK1.Merge();
                REMARK1.Font.Bold = true;
                REMARK1.Value2 = "REMARK: 1) 3% MORE OR LESS IN BOTH QUANTITY AND AMOUNT ARE ACCEPTABLE.";

                COMExcel.Range REMARK2 = TAB6.get_Range("A" + (tab61 + 16) + "", "F" + (tab61 + 16) + "");
                REMARK2.Font.Bold = true;
                REMARK2.Merge();
                REMARK2.Value2 = "        2) THIRD PARTY SHIPPER AND DOCUMENTS ARE ACCEPTABLE.";

                COMExcel.Range REMARK3 = TAB6.get_Range("A" + (tab61 + 17) + "", "F" + (tab61 + 17) + "");
                REMARK3.Merge();
                REMARK3.Font.Bold = true;
                REMARK3.Value2 = "        3) FREIGHT OR AIR WILL BE COLLECTED BY BUYER.";

                COMExcel.Range SIGN = TAB6.get_Range("C" + (tab61 + 19) + "", "E" + (tab61 + 19) + "");
                SIGN.Merge();
                SIGN.Font.Bold = true;
                SIGN.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                app.Visible = true;
                app.Quit();
                con.releaseObject(book);
                con.releaseObject(app);
            }
        }
        public void Export_Excel_Mau()
        {
            string workbookPath = con.LinkTemplate + "Sample.xls";
            string filePath = con.LinkTemplate_SAVE + "Sample.xls";
            if (con.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(con.LinkTemplate_SAVE);
                }
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
                #region Worksheets1------------
                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range C_NAME = IV.get_Range("B4", "B4");
                C_NAME.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3 = IV.get_Range("B5", "B5");
                ARD3.Value2 = txtADR.Text;

                COMExcel.Range TAXID = IV.get_Range("B6", "B6");
                TAXID.Value2 = txtTAXID.Text;

                COMExcel.Range HSCODE = IV.get_Range("B7", "B7");
                HSCODE.Value2 = txtHSCODE.Text;

                COMExcel.Range DATE = IV.get_Range("E4", "E4");
                DATE.Value2 = txtDate.Text;

                COMExcel.Range INVOICE = IV.get_Range("E5", "E5");
                INVOICE.Value2 = txtInvoice.Text;

                COMExcel.Range ATTN = IV.get_Range("B8", "B8");
                ATTN.Value2 = txtATTN.Text;

                COMExcel.Range TEL = IV.get_Range("B9", "B9");
                TEL.Value2 = txtTEL.Text;

                COMExcel.Range FAX = IV.get_Range("B10", "B10");
                FAX.Value2 = txtFAX.Text;

                COMExcel.Range SHIP = IV.get_Range("B11", "B11");
                SHIP.Value2 = txtShip.Text;

                COMExcel.Range AD = IV.get_Range("B12", "B12");
                AD.Value2 = txtAd.Text;

                COMExcel.Range FROMTAB1 = IV.get_Range("B13", "B13");
                FROMTAB1.Value2 = txtFr.Text;

                COMExcel.Range FROMTAB1_1 = IV.get_Range("A16", "A16");
                FROMTAB1_1.Value2 = this.DGV1.Rows[0].Cells["K_NAME"].Value.ToString().ToUpper();

                COMExcel.Range FROMTAB1_2 = IV.get_Range("A17", "A17");
                FROMTAB1_2.Value2 = "BRAND: " + this.DGV1.Rows[0].Cells["BRAND"].Value.ToString();

                int a = 18;
                int b = 19;
                int c = 20;
                object S = "";
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    //stt
                    int stt = i + 1;
                    //row 18
                    COMExcel.Range stt_execl = IV.get_Range("A" + a, "A" + c);
                    stt_execl.Merge();
                    stt_execl.Font.Bold = true;
                    stt_execl.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_execl.Value2 = stt;

                    //row 18
                    COMExcel.Range OR_NO = IV.get_Range("B" + a, "B" + a);
                    OR_NO.Font.Bold = true;
                    OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                    //row 19
                    S = DGV1.Rows[i].Cells["P_NAME3"].Value + " " + DGV1.Rows[i].Cells["P_NAME1"].Value.ToString();
                    COMExcel.Range P_NAME = IV.get_Range("B" + b, "B" + b);
                    P_NAME.Font.Bold = true;
                    P_NAME.EntireRow.AutoFit();
                    P_NAME.WrapText = true;
                    P_NAME.Value2 = S.ToString();

                    //row 20
                    COMExcel.Range COLOR = IV.get_Range("B" + c, "B" + c);
                    COLOR.Font.Bold = true;
                    COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                    //Quantity
                    COMExcel.Range BQTY = IV.get_Range("C" + c, "C" + c);
                    BQTY.Font.Bold = true;
                    BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BQTY.Value2 = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    //price
                    COMExcel.Range PRICE = IV.get_Range("D" + c, "D" + c);
                    PRICE.Font.Bold = true;
                    PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    PRICE.NumberFormat = "[$USD] #,##0.00";
                    PRICE.Value2 = string.Format("{0:0.00}", DGV1.Rows[i].Cells["PRICE"].Value.ToString());

                    //total
                    COMExcel.Range AMOUNT = IV.get_Range("E" + c, "E" + c);
                    AMOUNT.Font.Bold = true;
                    AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AMOUNT.NumberFormat = "[$USD] #,##0.00";
                    AMOUNT.Value2 = string.Format("{0:0.00}", DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                    a = a + 3; b = b + 3; c = c + 3;
                }

                COMExcel.Range T1 = IV.get_Range("A" + (a) + "", "B" + (a) + "");
                T1.Merge();
                T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T1.Font.Bold = true;
                T1.Value2 = "TOTAL";
                IV.get_Range("A" + (a) + "", "E" + (a) + "").Cells.BorderAround();

                int sc = DGV1.Rows.Count;
                float BQTY_SUM = 0;
                float AMOUNT_SUM = 0;
                for (int i = 0; i < sc; i++)
                {
                    BQTY_SUM += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    AMOUNT_SUM += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                COMExcel.Range T2 = IV.get_Range("C" + (a) + "", "C" + (a) + "");
                T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T2.Font.Bold = true;
                T2.Value2 = string.Format("{0:0.00}", BQTY_SUM);
                COMExcel.Range T3 = IV.get_Range("E" + (a) + "", "E" + (a) + "");
                T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T3.Font.Bold = true;
                T3.Value2 = string.Format("{0:0.00}", AMOUNT_SUM);

                COMExcel.Range A6 = IV.get_Range("B" + (a + 2), "B" + (a + 2));
                A6.Font.Bold = true;
                A6.Value2 = "PAYMENT FOR GOODS ";
                //row 24
                COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                A100.Font.Bold = true;
                A100.Value2 = "DENEFICIAY: ";

                COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                A7.Font.Bold = true;
                A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                //row 25
                COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                A8.Font.Bold = true;
                A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 401,TAIWAN (R.O.C.) ";

                COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                A9.Font.Bold = true;
                A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                //row26

                COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                bank.Font.Bold = true;
                bank.Value2 = "BANK NAME: ";

                COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                A10.Font.Bold = true;
                A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                //row 27

                COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                Acount.Font.Bold = true;
                Acount.Value2 = "ACCOUNT NO: ";

                COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                A11.Font.Bold = true;
                A11.Value2 = "USA A/C : 965-11-003037 ";

                //row 28
                COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                Swift.Font.Bold = true;
                Swift.Value2 = "SWIFT CODE: ";

                COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                A12.Font.Bold = true;
                A12.Value2 = "ICBCHKHH";
                //row 29
                COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                bankAddress.Font.Bold = true;
                bankAddress.Value2 = "BANK ADDRESS: ";
                COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                A13.Font.Bold = true;
                A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                A14.Font.Bold = true;
                A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";
                #endregion
                #region Worksheets2----------
                //******* PK  ****** 
                COMExcel.Worksheet PK = (COMExcel.Worksheet)book.Worksheets[2];

                COMExcel.Range C_NAME2 = PK.get_Range("B4", "B4");
                C_NAME2.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD32 = PK.get_Range("B5", "B5");
                ARD32.Value2 = txtADR.Text;

                COMExcel.Range TAXID2 = PK.get_Range("B6", "B6");
                TAXID2.Value2 = txtTAXID.Text;

                COMExcel.Range HSCODE2 = PK.get_Range("B7", "B7");
                HSCODE2.Value2 = txtHSCODE.Text;

                COMExcel.Range DATE2 = PK.get_Range("E4", "E4");
                DATE2.Value2 = txtDate.Text;

                COMExcel.Range INVOICE2 = PK.get_Range("E5", "E5");
                INVOICE2.Value2 = txtInvoice.Text;

                COMExcel.Range ATTN2 = PK.get_Range("B8", "B8");
                ATTN2.Value2 = txtATTN.Text;

                COMExcel.Range TEL2 = PK.get_Range("B9", "B9");
                TEL2.Value2 = txtTEL.Text;

                COMExcel.Range FAX2 = PK.get_Range("B10", "B10");
                FAX2.Value2 = txtFAX.Text;

                COMExcel.Range SHIP2 = PK.get_Range("B11", "B11");
                SHIP2.Value2 = txtShip.Text;

                COMExcel.Range AD2 = PK.get_Range("B12", "B12");
                AD2.Value2 = txtAd.Text;

                COMExcel.Range FROM2 = PK.get_Range("B13", "B13");
                FROM2.Value2 = txtFr.Text;

                COMExcel.Range FROM2_1 = PK.get_Range("A16", "A16");
                FROM2_1.Value2 = this.DGV1.Rows[0].Cells["K_NAME"].Value.ToString().ToUpper();

                COMExcel.Range FROM2_2 = PK.get_Range("A17", "A17");
                FROM2_2.Value2 = "BRAND: " + this.DGV1.Rows[0].Cells["BRAND"].Value.ToString();

                int d = 18;
                int e = 19;
                int f = 20;
                object S1 = "";
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    //stt
                    int stt = i + 1;
                    //row 18
                    COMExcel.Range stt_execl2 = PK.get_Range("A" + d, "A" + f);
                    stt_execl2.Merge();
                    stt_execl2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_execl2.Font.Bold = true;
                    stt_execl2.Value2 = stt;

                    //row 18
                    COMExcel.Range OR_NO2 = PK.get_Range("B" + d, "B" + d);
                    OR_NO2.Font.Bold = true;
                    OR_NO2.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                    //row 19
                    S = DGV1.Rows[i].Cells["P_NAME3"].Value + " " + DGV1.Rows[i].Cells["P_NAME1"].Value.ToString();
                    COMExcel.Range P_NAME2 = PK.get_Range("B" + e, "B" + e);
                    P_NAME2.EntireRow.AutoFit();
                    P_NAME2.WrapText = true;
                    P_NAME2.Font.Bold = true;
                    P_NAME2.Value2 = S.ToString();

                    //row 20
                    COMExcel.Range COLOR2 = PK.get_Range("B" + f, "B" + f);
                    COLOR2.Font.Bold = true;
                    COLOR2.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                    //Quantity
                    COMExcel.Range BQTY2 = PK.get_Range("C" + f, "C" + f);
                    BQTY2.Font.Bold = true;
                    BQTY2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BQTY2.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();
                    //NW
                    COMExcel.Range NW2 = PK.get_Range("D" + f, "D" + f);
                    NW2.Font.Bold = true;
                    NW2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW2.Value2 = DGV1.Rows[i].Cells["PCS"].Value.ToString();
                    //GW
                    COMExcel.Range GW2 = PK.get_Range("E" + f, "E" + f);
                    GW2.Font.Bold = true;
                    GW2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW2.Value2 = DGV1.Rows[i].Cells["QPCS"].Value.ToString();

                    d = d + 3; e = e + 3; f = f + 3;
                }

                COMExcel.Range T1_2 = PK.get_Range("A" + (d) + "", "B" + (d) + "");
                T1_2.Merge();
                T1_2.Value2 = "TOTAL";
                T1_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T1_2.Font.Bold = true;
                PK.get_Range("A" + (d) + "", "E" + (d) + "").Cells.BorderAround();

                int sc2 = DGV1.Rows.Count;
                float BQTY_SUM2 = 0;
                float NW_SUM2 = 0;
                float GW_SUM2 = 0;
                for (int i = 0; i < sc2; i++)
                {
                    BQTY_SUM2 += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    NW_SUM2 += float.Parse(DGV1.Rows[i].Cells["PCS"].Value.ToString());
                    GW_SUM2 += float.Parse(DGV1.Rows[i].Cells["QPCS"].Value.ToString());
                }
                COMExcel.Range T22 = PK.get_Range("C" + (d) + "", "C" + (d) + "");
                T22.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T22.Font.Bold = true;
                T22.Value2 = string.Format("{0:0.0}", BQTY_SUM2);

                COMExcel.Range T32 = PK.get_Range("D" + (d) + "", "D" + (d) + "");
                T32.Font.Bold = true;
                T32.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T32.Value2 = string.Format("{0:0.0}", NW_SUM2);

                COMExcel.Range T42 = PK.get_Range("E" + (d) + "", "E" + (d) + "");
                T42.Font.Bold = true;
                T42.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T42.Value2 = string.Format("{0:0.0}", GW_SUM2);
                #endregion
                #region Worksheets3----------------
                //******* PKT  ****** 
                COMExcel.Worksheet PKT = (COMExcel.Worksheet)book.Worksheets[3];

                COMExcel.Range DATE_2 = PKT.get_Range("F6", "F6");
                DATE_2.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_2 = PKT.get_Range("B7", "B7");
                INVOICE_2.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_2 = PKT.get_Range("B8", "B8");
                SHIP_2.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_2 = PKT.get_Range("B11", "B11");
                C_NAME_2.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_2 = PKT.get_Range("A12", "A12");
                ARD3_2.Value2 = txtADR.Text;
                int row = 16;
                double sumQty_M2 = 0.0;
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    int stt = i + 1;
                    //stt
                    COMExcel.Range stt_execl23 = PKT.get_Range("A" + row, "A" + row);
                    stt_execl23.Font.Bold = true;
                    stt_execl23.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_execl23.Value2 = stt;
                    //row K_NAME
                    COMExcel.Range OR_NO23 = PKT.get_Range("B" + row, "B" + row);
                    OR_NO23.Font.Bold = true;
                    OR_NO23.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO23.Value2 = DGV1.Rows[i].Cells["K_NAME"].Value.ToString().ToUpper();
                    //Quantity
                    COMExcel.Range BQTY2 = PKT.get_Range("C" + row, "C" + row);
                    BQTY2.Font.Bold = true;
                    BQTY2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BQTY2.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();
                    //NW
                    COMExcel.Range QTY_M2 = PKT.get_Range("D" + row, "D" + row);
                    QTY_M2.Font.Bold = true;
                    QTY_M2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    double sonum = 0.0929;
                    double AB = double.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * sonum;
                    QTY_M2.Value2 = string.Format("{0:0.0}", AB);
                    //NW
                    COMExcel.Range NW2 = PKT.get_Range("E" + row, "E" + row);
                    NW2.Font.Bold = true;
                    NW2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW2.Value2 = DGV1.Rows[i].Cells["PCS"].Value.ToString();
                    //GW
                    COMExcel.Range GW2 = PKT.get_Range("F" + row, "F" + row);
                    GW2.Font.Bold = true;
                    GW2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW2.Value2 = DGV1.Rows[i].Cells["QPCS"].Value.ToString();
                    sumQty_M2 += AB;
                    row = row + 1;
                }
                con.BorderAround(PKT.get_Range("A16", "F" + row));

                COMExcel.Range T3_2 = PKT.get_Range("A" + (row) + "", "B" + (row) + "");
                T3_2.Merge();
                T3_2.Font.Bold = true;
                T3_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T3_2.Value2 = "TOTAL";
                PKT.get_Range("A" + (row) + "", "F" + (row) + "").Cells.BorderAround();

                int sc3 = DGV1.Rows.Count;
                float BQTY_SUM3 = 0;
                float NW_SUM3 = 0;
                float GW_SUM3 = 0;
                for (int i = 0; i < sc3; i++)
                {
                    BQTY_SUM3 += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    NW_SUM3 += float.Parse(DGV1.Rows[i].Cells["PCS"].Value.ToString());
                    GW_SUM3 += float.Parse(DGV1.Rows[i].Cells["QPCS"].Value.ToString());
                }
                COMExcel.Range T33 = PKT.get_Range("C" + (row) + "", "C" + (row) + "");
                T33.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T33.Font.Bold = true;
                T33.Value2 = string.Format("{0:0.0}", BQTY_SUM3);


                COMExcel.Range T35 = PKT.get_Range("D" + (row) + "", "D" + (row) + "");
                T35.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T35.Font.Bold = true;
                T35.Value2 = string.Format("{0:0.0}", sumQty_M2);

                COMExcel.Range T34 = PKT.get_Range("E" + (row) + "", "E" + (row) + "");
                T34.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T34.Font.Bold = true;
                T34.Value2 = string.Format("{0:0.0}", NW_SUM3);

                COMExcel.Range T31 = PKT.get_Range("F" + (row) + "", "F" + (row) + "");
                T31.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T31.Font.Bold = true;
                T31.Value2 = string.Format("{0:0.0}", GW_SUM3);

                COMExcel.Range Total_tab3 = PKT.get_Range("A" + (row + 2) + "", "A" + (row + 2) + "");
                Total_tab3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3.Font.Bold = true;
                Total_tab3.Value2 = "TOTAL: ";

                #endregion
                #region Worksheet4
                //******* BKBQ  ****** 
                COMExcel.Worksheet BKBQ = (COMExcel.Worksheet)book.Worksheets[4];

                COMExcel.Range DATE_3 = BKBQ.get_Range("B7", "B7");
                DATE_3.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_3 = BKBQ.get_Range("B8", "B8");
                INVOICE_3.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_3 = BKBQ.get_Range("B9", "B9");
                SHIP_3.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_3 = BKBQ.get_Range("B12", "B12");
                C_NAME_3.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_3 = BKBQ.get_Range("A13", "A13");
                ARD3_3.Value2 = txtADR.Text;
                int itab4 = 18;
                int stttab4 = 1;
                float Sum_BQTY = 0;
                float Sum_PCS = 0;
                float Sum_amount = 0;
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    COMExcel.Range stt = BKBQ.get_Range("A" + itab4, "A" + itab4);
                    stt.RowHeight = 22.8;
                    stt.Font.Bold = true;
                    stt.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    stt.Value2 = stttab4;

                    COMExcel.Range K_NAME = BKBQ.get_Range("B" + itab4, "B" + itab4);
                    K_NAME.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    K_NAME.Font.Bold = true;
                    K_NAME.Value2 = item.Cells["K_NAME"].Value.ToString().ToUpper();

                    COMExcel.Range BQTY = BKBQ.get_Range("C" + itab4, "C" + itab4);
                    BQTY.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    BQTY.Font.Bold = true;
                    BQTY.Value2 = item.Cells["BQTY"].Value.ToString();

                    COMExcel.Range PCS = BKBQ.get_Range("D" + itab4, "D" + itab4);
                    PCS.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PCS.Font.Bold = true;
                    PCS.Value2 = Math.Round(float.Parse(item.Cells["BQTY"].Value.ToString()) * (float)0.0929, 2).ToString();

                    COMExcel.Range PRICE = BKBQ.get_Range("E" + itab4, "E" + itab4);
                    PRICE.Font.Bold = true;
                    PRICE.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PRICE.NumberFormat = "[$USD] #,##0.00";
                    PRICE.Value2 = float.Parse(item.Cells["PRICE"].Value.ToString()).ToString();

                    COMExcel.Range amount = BKBQ.get_Range("F" + itab4, "F" + itab4);
                    amount.Font.Bold = true;
                    amount.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    amount.Value2 = Math.Round(float.Parse(item.Cells["BQTY"].Value.ToString()) * float.Parse(item.Cells["PRICE"].Value.ToString()), 2).ToString();

                    Sum_BQTY += float.Parse(item.Cells["BQTY"].Value.ToString());
                    Sum_PCS += (float.Parse(item.Cells["BQTY"].Value.ToString()) * (float)0.0929);
                    Sum_amount += float.Parse(item.Cells["BQTY"].Value.ToString()) * float.Parse(item.Cells["PRICE"].Value.ToString());

                    stttab4++;
                    itab4++;
                }
                con.BorderAround(BKBQ.get_Range("A18", "F" + itab4));

                COMExcel.Range total = BKBQ.get_Range("A" + itab4, "B" + itab4);
                total.Merge();
                total.Font.Bold = true;
                total.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                total.Value2 = "TOTAL";

                COMExcel.Range SUMBQTY = BKBQ.get_Range("C" + itab4, "C" + itab4);
                SUMBQTY.Merge();
                SUMBQTY.Font.Bold = true;
                SUMBQTY.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                SUMBQTY.Value2 = Math.Round(Sum_BQTY, 2).ToString();

                COMExcel.Range SUMPCS = BKBQ.get_Range("D" + itab4, "D" + itab4);
                SUMPCS.Merge();
                SUMPCS.Font.Bold = true;
                SUMPCS.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                SUMPCS.Value2 = Math.Round(Sum_PCS, 2).ToString();

                COMExcel.Range SUMaAMOUNT = BKBQ.get_Range("F" + itab4, "F" + itab4);
                SUMaAMOUNT.Merge();
                SUMaAMOUNT.Font.Bold = true;
                SUMaAMOUNT.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                SUMaAMOUNT.Value2 = Math.Round(Sum_amount, 2).ToString();

                COMExcel.Range SAYTOTAL = BKBQ.get_Range("A" + (itab4 + 2), "F" + (itab4 + 2));
                SAYTOTAL.Merge();
                SAYTOTAL.Font.Bold = true;
                SAYTOTAL.Value2 = "SAY TOTAL: ";

                COMExcel.Range food = BKBQ.get_Range("D" + (itab4 + 3), "F" + (itab4 + 3));
                food.Merge();
                food.Font.Bold = true;
                food.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                food.Value2 = "WEI TAI VIET NAM LEATHER  CO.,LTD ";

                COMExcel.Range food1 = BKBQ.get_Range("E" + (itab4 + 9), "E" + (itab4 + 9));
                food1.Merge();
                food1.Font.Bold = true;
                food1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                food1.Value2 = "LEE CHAO CHUN";
                #endregion
                #region Worksheets5
                //******* INBQ  ****** 
                COMExcel.Worksheet INBQ = (COMExcel.Worksheet)book.Worksheets[5];

                COMExcel.Range DATE_4 = INBQ.get_Range("F7", "F7");
                DATE_4.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_4 = INBQ.get_Range("B7", "B7");
                INVOICE_4.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_4 = INBQ.get_Range("B8", "B8");
                SHIP_4.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_4 = INBQ.get_Range("B11", "B11");
                C_NAME_4.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_4 = INBQ.get_Range("A12", "A12");
                ARD3_4.Value2 = txtADR.Text;

                int tab5 = 16;
                double sumQty_M5 = 0.0;
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    int stt = i + 1;
                    //stt
                    COMExcel.Range stt_exec5 = INBQ.get_Range("A" + tab5, "A" + tab5);
                    stt_exec5.Font.Bold = true;
                    stt_exec5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_exec5.Value2 = stt;
                    //row K_NAME
                    COMExcel.Range OR_NO5 = INBQ.get_Range("B" + tab5, "B" + tab5);
                    OR_NO5.Font.Bold = true;
                    OR_NO5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO5.Value2 = DGV1.Rows[i].Cells["K_NAME"].Value.ToString().ToUpper();
                    //Quantity
                    COMExcel.Range BQTY5 = INBQ.get_Range("C" + tab5, "C" + tab5);
                    BQTY5.Font.Bold = true;
                    BQTY5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BQTY5.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();
                    //NW
                    COMExcel.Range QTY_M5 = INBQ.get_Range("D" + tab5, "D" + tab5);
                    QTY_M5.Font.Bold = true;
                    QTY_M5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    double sonum = 0.0929;
                    double AB1 = double.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * sonum;
                    QTY_M5.Value2 = string.Format("{0:0.0}", AB1);
                    //NW
                    COMExcel.Range NW5 = INBQ.get_Range("E" + tab5, "E" + tab5);
                    NW5.Font.Bold = true;
                    NW5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                    NW5.NumberFormat = "[$USD] #,##0.00";
                    NW5.Value2 = DGV1.Rows[i].Cells["PRICE"].Value.ToString();
                    //GW
                    COMExcel.Range GW5 = INBQ.get_Range("F" + tab5, "F" + tab5);
                    GW5.Font.Bold = true;
                    GW5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW5.NumberFormat = "[$USD] #,##0.00";
                    GW5.Value2 = DGV1.Rows[i].Cells["AMOUNT"].Value.ToString();
                    sumQty_M5 += AB1;
                    tab5 = tab5 + 1;
                }
                con.BorderAround(INBQ.get_Range("A16", "F" + tab5));

                COMExcel.Range T5 = INBQ.get_Range("A" + (tab5) + "", "B" + (tab5) + "");
                T5.Merge();
                T5.Font.Bold = true;
                T5.Value2 = "TOTAL";
                T5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                INBQ.get_Range("A" + (tab5) + "", "F" + (tab5) + "").Cells.BorderAround();

                int sc5 = DGV1.Rows.Count;
                float BQTY_SUM5 = 0;
                float GW_SUM5 = 0;
                for (int i = 0; i < sc5; i++)
                {
                    BQTY_SUM5 += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    GW_SUM5 += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                COMExcel.Range T55 = INBQ.get_Range("C" + (tab5) + "", "C" + (tab5) + "");
                T55.Font.Bold = true;
                T55.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T55.Value2 = string.Format("{0:0.0}", BQTY_SUM5);

                COMExcel.Range T551 = INBQ.get_Range("D" + (tab5) + "", "D" + (tab5) + "");
                T551.Font.Bold = true;
                T551.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T551.Value2 = string.Format("{0:0.0}", sumQty_M5);

                COMExcel.Range T553 = INBQ.get_Range("F" + (tab5) + "", "F" + (tab5) + "");
                T553.Font.Bold = true;
                T553.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                T553.Value2 = string.Format("{0:0.0}", GW_SUM5);

                COMExcel.Range rowt51 = INBQ.get_Range("A" + (tab5 + 1) + "", "F" + (tab5 + 1) + "");
                rowt51.Font.Bold = true;
                rowt51.Merge();
                rowt51.Value2 = "SAY TOTAL: ";
                rowt51.Style.Font.Size = 12;
                rowt51.Font.Bold = true;

                COMExcel.Range rowt58 = INBQ.get_Range("D" + (tab5 + 3) + "", "E" + (tab5 + 3) + "");
                rowt58.Font.Bold = true;
                rowt58.Merge();
                rowt58.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                COMExcel.Range row5A = INBQ.get_Range("B" + (tab5 + 3) + "", "B" + (tab5 + 3) + "");
                row5A.Font.Bold = true;
                row5A.Value2 = "Destination: " + txtDestination.Text;

                COMExcel.Range row5A1 = INBQ.get_Range("B" + (tab5 + 4) + "", "B" + (tab5 + 4) + "");
                row5A1.Font.Bold = true;
                row5A1.Value2 = "Delivery :";

                COMExcel.Range row5A1B = INBQ.get_Range("C" + (tab5 + 4) + "", "C" + (tab5 + 4) + "");
                row5A1B.Font.Bold = true;
                row5A1B.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                row5A1B.Value2 = txtDeliveryTerm.Text;

                COMExcel.Range row5A2 = INBQ.get_Range("B" + (tab5 + 5) + "", "B" + (tab5 + 5) + "");
                row5A2.Font.Bold = true;
                row5A2.Value2 = "Term of payment :";

                COMExcel.Range row5A2B = INBQ.get_Range("C" + (tab5 + 5) + "", "C" + (tab5 + 5) + "");
                row5A2B.Font.Bold = true;
                row5A2B.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                row5A2B.Value2 = txtTermOfpayment.Text;

                COMExcel.Range row5A3 = INBQ.get_Range("B" + (tab5 + 6) + "", "B" + (tab5 + 6) + "");
                row5A3.Font.Bold = true;
                row5A3.Value2 = "Country of origin : Viet Nam";
                #endregion
                app.Visible = true;
                app.Quit();
                con.releaseObject(book);
                con.releaseObject(app);
            } 
        }
        public void Export_Excel_SX()
        {
            string workbookPath = con.LinkTemplate + "Sample_SX.xls";
            string filePath = con.LinkTemplate_SAVE + "Sample_SX.xls";
            if (con.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(con.LinkTemplate_SAVE);
                }
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
               
                #region Worksheets2----------
                //******* PK  ****** 
                COMExcel.Worksheet PK = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range C_NAME2 = PK.get_Range("B4", "B4");
                C_NAME2.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD32 = PK.get_Range("A5", "A5");
                ARD32.Value2 = "ADDRESS: " + txtADR.Text;

                COMExcel.Range TAXID2 = PK.get_Range("B7", "B7");
                TAXID2.Value2 = txtTAXID.Text;

                COMExcel.Range HSCODE2 = PK.get_Range("B8", "B8");
                HSCODE2.Value2 = txtHSCODE.Text;

                COMExcel.Range DATE2 = PK.get_Range("H4", "H4");

                DATE2.Value2 = txtDate.Text;

                COMExcel.Range INVOICE2 = PK.get_Range("H5", "H5");
                INVOICE2.Value2 = txtInvoice.Text;

                COMExcel.Range ATTN2 = PK.get_Range("B9", "B9");
                ATTN2.Value2 = txtATTN.Text;

                COMExcel.Range TEL2 = PK.get_Range("B10", "B10");
                TEL2.Value2 = txtTEL.Text;

                COMExcel.Range FAX2 = PK.get_Range("B11", "B11");
                FAX2.Value2 = txtFAX.Text;

                COMExcel.Range FROM2 = PK.get_Range("B12", "B12");
                FROM2.Value2 = txtFr.Text;


                int f = 15;
                object S1 = "";

                DataTable dataTable = new DataTable();
                foreach (DataGridViewColumn col in DGV1.Columns)
                {
                    dataTable.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row1 in DGV1.Rows)
                {
                    DataRow dRow = dataTable.NewRow();
                    foreach (DataGridViewCell cell in row1.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dataTable.Rows.Add(dRow);
                }

                float sumAll = 0;
                float SumAllPCS = 0;
                float SumAllQPCS = 0;
                float SumV_Thetich = 0;
                decimal Number = 0;
                float Sum_AMOUNT = 0;
                var group = dataTable.AsEnumerable().GroupBy(r => new { Col1 = r["CNO_STT"] }).Select(g => g.OrderBy(r => r["CNO_STT"]).First()).OrderBy(r => r["CNO_STT"]).CopyToDataTable();
                for (int i = 0; i < group.Rows.Count; i++)
                {
                    float SumBQty = 0;
                    float SumPCS = 0;
                    float SumQPCS = 0;
                    var group1 = dataTable.AsEnumerable().Where(x => x["CNO_STT"].ToString() == group.Rows[i]["CNO_STT"].ToString()).CopyToDataTable();

                    COMExcel.Range stt_execl2 = PK.get_Range("A" + f, "A" + (f + group1.Rows.Count - 1));
                    stt_execl2.Merge();
                    stt_execl2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_execl2.Font.Bold = true;
                    stt_execl2.Value2 = group.Rows[i]["CNO_STT"].ToString();

                    COMExcel.Range V_TheTich = PK.get_Range("I" + f, "I" + (f + group1.Rows.Count - 1));
                    V_TheTich.Merge();
                    V_TheTich.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    V_TheTich.Font.Bold = true;
                    V_TheTich.Value2 = group.Rows[i]["V_TheTich"].ToString();

                    for (int j = 0; j < group1.Rows.Count; j++)
                    {
                        COMExcel.Range da = PK.get_Range("B" + f, "B" + f);
                        da.Merge();
                        da.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        da.Font.Bold = true;
                        da.Value2 = "";

                        COMExcel.Range OR_NO = PK.get_Range("C" + f, "C" + f);
                        OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.Font.Bold = true;
                        OR_NO.Value2 = group1.Rows[j]["OR_NO"].ToString();

                        COMExcel.Range COLOR = PK.get_Range("D" + f, "D" + f);
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.Font.Bold = true;
                        COLOR.EntireColumn.WrapText = true;
                        COLOR.Value2 = group1.Rows[j]["COLOR"].ToString();

                        COMExcel.Range P_NAME3 = PK.get_Range("E" + f, "E" + f);
                        P_NAME3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.Font.Bold = true;
                        P_NAME3.Value2 = group1.Rows[j]["P_NAME3"].ToString();

                        COMExcel.Range BQTY = PK.get_Range("F" + f, "F" + f);
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Bold = true;
                        BQTY.Value2 = Math.Round(float.Parse(group1.Rows[j]["BQTY"].ToString()), 2);

                        COMExcel.Range PCS = PK.get_Range("G" + f, "G" + f);
                        PCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PCS.Font.Bold = true;
                        PCS.Value2 = Math.Round(float.Parse(group1.Rows[j]["PCS"].ToString()), 2);

                        COMExcel.Range QPCS = PK.get_Range("H" + f, "H" + f);
                        QPCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        QPCS.Font.Bold = true;
                        QPCS.Value2 = Math.Round(float.Parse(group1.Rows[j]["QPCS"].ToString()), 2);

                        f++;
                        SumBQty += float.Parse(group1.Rows[j]["BQTY"].ToString());
                        sumAll += float.Parse(group1.Rows[j]["BQTY"].ToString());
                        SumPCS += float.Parse(group1.Rows[j]["PCS"].ToString());
                        SumAllPCS += float.Parse(group1.Rows[j]["PCS"].ToString());
                        SumQPCS += float.Parse(group1.Rows[j]["QPCS"].ToString());
                        SumAllQPCS += float.Parse(group1.Rows[j]["QPCS"].ToString());
                        Sum_AMOUNT += float.Parse(group1.Rows[j]["AMOUNT"].ToString());
                    }
                    COMExcel.Range WEIGHT = PK.get_Range("A" + f, "E" + f);
                    WEIGHT.Merge();
                    WEIGHT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    WEIGHT.Font.Bold = true;
                    string key = "";
                    if (!string.IsNullOrEmpty(group.Rows[i]["lstPackage"].ToString()))
                    {
                        key = group.Rows[i]["lstPackage"].ToString();
                    }
                    WEIGHT.Value2 = "WEIGHT OF " + key.ToUpper();

                    COMExcel.Range WEIGHT_NUMBER = PK.get_Range("H" + f, "H" + f);
                    WEIGHT_NUMBER.Merge();
                    WEIGHT_NUMBER.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    WEIGHT_NUMBER.Font.Bold = true;
                    WEIGHT_NUMBER.Value2 = Math.Round(float.Parse(group.Rows[i]["Number"].ToString()), 2);

                    COMExcel.Range Border = PK.get_Range("A" + f, "I" + f);
                    Border.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //Border[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    COMExcel.Range lbBQTY = PK.get_Range("A" + (f + 1), "E" + (f + 1));
                    lbBQTY.Merge();
                    lbBQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    lbBQTY.Font.Bold = true;
                    lbBQTY.Value2 = "TOTAL: ";

                    COMExcel.Range Border1 = PK.get_Range("A" + (f + 1), "I" + (f + 1));
                    Border1.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                    COMExcel.Range txtBQTY = PK.get_Range("F" + (f + 1), "F" + (f + 1));
                    txtBQTY.Merge();
                    txtBQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtBQTY.Font.Bold = true;

                    txtBQTY.Value2 = Math.Round(float.Parse(SumBQty.ToString()), 2);

                    COMExcel.Range txtPCS = PK.get_Range("G" + (f + 1), "G" + (f + 1));
                    txtPCS.Merge();
                    txtPCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtPCS.Font.Bold = true;
                    txtPCS.Value2 = Math.Round(float.Parse(SumPCS.ToString()), 2);

                    COMExcel.Range txtQPCS = PK.get_Range("H" + (f + 1), "H" + (f + 1));
                    txtQPCS.Merge();
                    txtQPCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtQPCS.Font.Bold = true;
                    txtQPCS.Value2 = (SumQPCS + (string.IsNullOrEmpty(group.Rows[i]["Number"].ToString()) ? 0 : float.Parse(group.Rows[i]["Number"].ToString()))).ToString();
                    Number += (string.IsNullOrEmpty(group.Rows[i]["Number"].ToString()) ? 0 : decimal.Parse(group.Rows[i]["Number"].ToString()));

                    COMExcel.Range SumV = PK.get_Range("I" + (f + 1), "I" + (f + 1));
                    SumV.Merge();
                    SumV.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SumV.Font.Bold = true;
                    SumV.Value2 = Math.Round(float.Parse(group.Rows[i]["V_TheTich"].ToString()), 2);

                    SumV_Thetich += float.Parse(string.IsNullOrEmpty((string)group.Rows[i]["V_TheTich"].ToString()) ? "0" : Math.Round(double.Parse(group.Rows[i]["V_TheTich"].ToString()), 2).ToString());

                    f = f + 2;
                }

                COMExcel.Range lbSumAll = PK.get_Range("A" + (f), "E" + (f));
                lbSumAll.Merge();
                lbSumAll.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                lbSumAll.Font.Bold = true;
                lbSumAll.Value2 = "TOTAL: ";

                COMExcel.Range Border2 = PK.get_Range("A" + f, "I" + f);
                Border2.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;

                COMExcel.Range txtSumAll = PK.get_Range("F" + f, "F" + f);
                txtSumAll.Merge();
                txtSumAll.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtSumAll.Font.Bold = true;
                txtSumAll.Value2 = Math.Round(float.Parse(sumAll.ToString()), 2);


                COMExcel.Range txtSumAllPCS = PK.get_Range("G" + f, "G" + f);
                txtSumAllPCS.Merge();
                txtSumAllPCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtSumAllPCS.Font.Bold = true;
                txtSumAllPCS.Value2 = Math.Round(float.Parse(SumAllPCS.ToString()), 2);

                COMExcel.Range txtSumAllQPCS = PK.get_Range("H" + f, "H" + f);
                txtSumAllQPCS.Merge();
                txtSumAllQPCS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtSumAllQPCS.Font.Bold = true;
                txtSumAllQPCS.Value2 = Math.Round(SumAllQPCS + float.Parse(Number.ToString()), 2);

                COMExcel.Range txtTheTich = PK.get_Range("I" + f, "I" + f);
                txtTheTich.Merge();
                txtTheTich.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtTheTich.Font.Bold = true;
                txtTheTich.Value2 = Math.Round(SumV_Thetich, 2);
                #endregion
                #region Worksheets3----------------
                //******* PKT  ****** 
                COMExcel.Worksheet PKT = (COMExcel.Worksheet)book.Worksheets[2];

                COMExcel.Range DATE_2 = PKT.get_Range("G6", "G6");
                DATE_2.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_2 = PKT.get_Range("B7", "B7");
                INVOICE_2.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_2 = PKT.get_Range("B8", "B8");
                SHIP_2.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_2 = PKT.get_Range("B11", "B11");
                C_NAME_2.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_2 = PKT.get_Range("A12", "A12");
                ARD3_2.Value2 = txtADR.Text;

                int row = 16;
                string c_noo3 = "";
                double SumQTYM2 = 0.0;
                for (int i = 0; i < group.Rows.Count; i++)
                {
                    float SumBQty = 0;
                    float SumNW = 0;
                    float SumGW = 0;

                    var group1_tab4 = dataTable.AsEnumerable().Where(x => x["CNO_STT"].ToString() == group.Rows[i]["CNO_STT"].ToString()).CopyToDataTable();

                    //cột A
                    COMExcel.Range stt_execl24 = PKT.get_Range("A" + row, "A" + row);
                    stt_execl24.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    stt_execl24.Font.Bold = true;
                    c_noo3 = group.Rows[i]["CNO_STT"].ToString();
                    stt_execl24.Value2 = c_noo3;

                    COMExcel.Range V_TheTich = PKT.get_Range("H" + row, "H" + row);
                    V_TheTich.Merge();
                    V_TheTich.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    V_TheTich.Font.Bold = true;
                    V_TheTich.Value2 = group.Rows[i]["V_TheTich"].ToString();

                    for (int j = 0; j < group1_tab4.Rows.Count; j++)
                    {
                        SumBQty += float.Parse(group1_tab4.Rows[j]["BQTY"].ToString());
                        SumNW += float.Parse(group1_tab4.Rows[j]["PCS"].ToString());
                        SumGW += float.Parse(group1_tab4.Rows[j]["QPCS"].ToString());

                    }
                    COMExcel.Range txtDescription4 = PKT.get_Range("C" + (row), "C" + (row));
                    txtDescription4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtDescription4.Font.Bold = true;
                    txtDescription4.Value2 = group.Rows[i]["K_NAME"].ToString();

                    COMExcel.Range txtBQTY4 = PKT.get_Range("D" + (row), "D" + (row));
                    txtBQTY4.Merge();
                    txtBQTY4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtBQTY4.Font.Bold = true;
                    txtBQTY4.Value2 = Math.Round(SumBQty, 2);

                    COMExcel.Range txtPCS4 = PKT.get_Range("E" + (row), "E" + (row));
                    txtPCS4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtPCS4.Font.Bold = true;
                    double num = double.Parse(SumBQty.ToString()) * 0.0929;
                    SumQTYM2 += num;
                    txtPCS4.Value2 = Math.Round(num, 2).ToString();

                    COMExcel.Range txtNW = PKT.get_Range("F" + (row), "F" + (row));
                    txtNW.Merge();
                    txtNW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtNW.Font.Bold = true;
                    txtNW.Value2 = Math.Round(SumNW, 2).ToString();

                    COMExcel.Range txtGW = PKT.get_Range("G" + (row), "G" + (row));
                    txtGW.Merge();
                    txtGW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    txtGW.Font.Bold = true;
                    txtGW.Value = Math.Round(SumGW + float.Parse(group.Rows[i]["Number"].ToString()), 2).ToString();

                    row = row + 1;

                }
                COMExcel.Range Total_tab3 = PKT.get_Range("A" + (row) + "", "C" + (row) + "");
                Total_tab3.Merge();
                Total_tab3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3.Font.Bold = true;
                Total_tab3.Value2 = "TOTAL: ";

                COMExcel.Range Total_tab3_QTY = PKT.get_Range("D" + (row) + "", "D" + (row) + "");
                Total_tab3_QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3_QTY.Font.Bold = true;
                Total_tab3_QTY.Value2 = Math.Round(sumAll, 2).ToString();

                COMExcel.Range Total_tab3_QTYM2 = PKT.get_Range("E" + (row) + "", "E" + (row) + "");
                Total_tab3_QTYM2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3_QTYM2.Font.Bold = true;
                Total_tab3_QTYM2.Value2 = Math.Round(SumQTYM2, 2).ToString();

                COMExcel.Range Total_tab3_NW = PKT.get_Range("F" + (row) + "", "F" + (row) + "");
                Total_tab3_NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3_NW.Font.Bold = true;
                Total_tab3_NW.Value2 = Math.Round(SumAllPCS, 2).ToString();

                COMExcel.Range Total_tab3GW = PKT.get_Range("G" + (row) + "", "G" + (row) + "");
                Total_tab3GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3GW.Font.Bold = true;
                Total_tab3GW.Value2 = Math.Round(SumAllQPCS + float.Parse(Number.ToString()), 2).ToString();

                COMExcel.Range Total_tab3_V = PKT.get_Range("H" + (row) + "", "H" + (row) + "");
                Total_tab3_V.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_tab3_V.Font.Bold = true;
                Total_tab3_V.Value2 = Math.Round(SumV_Thetich, 2).ToString();

                con.BorderAround(PKT.get_Range("A" + (row), "H" + (row)));

                COMExcel.Range Total_Lable = PKT.get_Range("A" + (row + 2) + "", "A" + (row + 2) + "");
                Total_Lable.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                Total_Lable.Font.Bold = true;
                Total_Lable.Value2 = "TOTAL: ";
                #endregion
                #region Worksheet4
                //******* BKBQ  ****** 
                COMExcel.Worksheet BKBQ = (COMExcel.Worksheet)book.Worksheets[3];

                COMExcel.Range DATE_3 = BKBQ.get_Range("B7", "B7");
                DATE_3.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_3 = BKBQ.get_Range("B8", "B8");
                INVOICE_3.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_3 = BKBQ.get_Range("B9", "B9");
                SHIP_3.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_3 = BKBQ.get_Range("B12", "B12");
                C_NAME_3.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_3 = BKBQ.get_Range("A13", "A13");
                ARD3_3.Value2 = txtADR.Text;

                int itab4 = 18;
                string c_noo4 = "";
                double sumQuanlity4 = 0.0;

                //cột A
                COMExcel.Range stt_execl242 = BKBQ.get_Range("A" + itab4, "A" + itab4);
                stt_execl242.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                stt_execl242.Font.Bold = true;
                if (group.Rows.Count > 1)
                {
                    c_noo4 = "' " + group.Rows[0]["CNO_STT"].ToString() + "-" + group.Rows.Count.ToString() + "";
                }
                else
                {
                    c_noo4 = "' " + group.Rows[0]["CNO_STT"].ToString();
                }
                stt_execl242.Value2 = c_noo4;

                COMExcel.Range txtDesc = BKBQ.get_Range("B" + (itab4), "B" + (itab4));
                txtDesc.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtDesc.Font.Bold = true;
                txtDesc.Value2 = group.Rows[0]["K_NAME"].ToString();

                COMExcel.Range txtBQTY41 = BKBQ.get_Range("C" + (itab4), "C" + (itab4));
                txtBQTY41.Merge();
                txtBQTY41.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtBQTY41.Font.Bold = true;
                txtBQTY41.Value2 = Math.Round(sumAll, 2);

                COMExcel.Range txtPCS41 = BKBQ.get_Range("D" + (itab4), "D" + (itab4));
                txtPCS41.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtPCS41.Font.Bold = true;
                sumQuanlity4 = double.Parse(sumAll.ToString()) * HANG_SO;
                txtPCS41.Value2 = Math.Round(sumQuanlity4, 2).ToString();

                COMExcel.Range txtPrice41 = BKBQ.get_Range("E" + (itab4), "E" + (itab4));
                txtPrice41.Merge();
                txtPrice41.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtPrice41.Font.Bold = true;
                float price = 0;
                price = float.Parse(Sum_AMOUNT.ToString()) / float.Parse(sumAll.ToString());
                txtPrice41.Value2 = "US$" + Math.Round(price, 2).ToString();

                COMExcel.Range txtAmount4 = BKBQ.get_Range("F" + (itab4), "F" + (itab4));
                txtAmount4.Merge();
                txtAmount4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtAmount4.Font.Bold = true;
                txtAmount4.Value2 = "US$" + Math.Round(Sum_AMOUNT, 2).ToString();

                COMExcel.Range iNBQ_TOTAL4 = BKBQ.get_Range("A" + (itab4 + 1), "B" + (itab4 + 1));
                iNBQ_TOTAL4.Merge();
                iNBQ_TOTAL4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                iNBQ_TOTAL4.Font.Bold = true;
                iNBQ_TOTAL4.Value2 = "TOTAL: ";

                COMExcel.Range txtQTY4 = BKBQ.get_Range("C" + (itab4 + 1), "C" + (itab4 + 1));
                txtQTY4.Merge();
                txtQTY4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtQTY4.Font.Bold = true;
                txtQTY4.Value2 = Math.Round(sumAll, 2).ToString();

                COMExcel.Range txtQuantaty4 = BKBQ.get_Range("D" + (itab4 + 1), "D" + (itab4 + 1));
                txtQuantaty4.Merge();
                txtQuantaty4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtQuantaty4.Font.Bold = true;
                txtQuantaty4.Value2 = Math.Round(sumQuanlity4, 2).ToString();

                COMExcel.Range AMOUNT4 = BKBQ.get_Range("F" + (itab4 + 1), "F" + (itab4 + 1));
                AMOUNT4.Merge();
                AMOUNT4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                AMOUNT4.Font.Bold = true;
                AMOUNT4.Value2 = "US$" + Math.Round(Sum_AMOUNT, 2).ToString();

                con.BorderAround(BKBQ.get_Range("A18", "F" + (itab4 + 1)));

                COMExcel.Range SAYTOTAL4 = BKBQ.get_Range("A" + (itab4 + 2), "F" + (itab4 + 2));
                SAYTOTAL4.Merge();
                SAYTOTAL4.Font.Bold = true;
                SAYTOTAL4.Value2 = "SAY TOTAL: ";

                COMExcel.Range food = BKBQ.get_Range("D" + (itab4 + 3), "F" + (itab4 + 3));
                food.Merge();
                food.Font.Bold = true;
                food.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                food.Value2 = "WEI TAI VIET NAM LEATHER  CO.,LTD ";

                COMExcel.Range food1 = BKBQ.get_Range("E" + (itab4 + 9), "E" + (itab4 + 9));
                food1.Merge();
                food1.Font.Bold = true;
                food1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                food1.Value2 = "LEE CHAO CHUN";
                #endregion
                #region Worksheets5
                //******* INBQ  ****** 
                COMExcel.Worksheet INBQ = (COMExcel.Worksheet)book.Worksheets[4];

                COMExcel.Range DATE_4 = INBQ.get_Range("F7", "F7");
                DATE_4.Value2 = txtDate.Text;

                COMExcel.Range INVOICE_4 = INBQ.get_Range("B7", "B7");
                INVOICE_4.Value2 = txtInvoice.Text;

                COMExcel.Range SHIP_4 = INBQ.get_Range("B8", "B8");
                SHIP_4.Value2 = txtShip.Text;

                COMExcel.Range C_NAME_4 = INBQ.get_Range("B11", "B11");
                C_NAME_4.Value2 = txtC_NAME.Text;

                COMExcel.Range ARD3_4 = INBQ.get_Range("A12", "A12");
                ARD3_4.Value2 = txtADR.Text;

                int tab5 = 16;
                string c_noo5 = "";
                double sumQuanlity5 = 0.0;
                //cột A
                COMExcel.Range stt_execl2421 = INBQ.get_Range("A" + tab5, "A" + tab5);
                stt_execl2421.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                stt_execl2421.Font.Bold = true;
                if (group.Rows.Count > 1)
                {
                    c_noo5 = "' " + group.Rows[0]["CNO_STT"].ToString() + "-" + group.Rows.Count.ToString() + "";
                }
                else
                {
                    c_noo5 = "' " + group.Rows[0]["CNO_STT"].ToString();
                }
                stt_execl2421.Value2 = c_noo5;

                COMExcel.Range txtDesc5 = INBQ.get_Range("B" + (tab5), "B" + (tab5));
                txtDesc5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtDesc5.Font.Bold = true;
                txtDesc5.Value2 = group.Rows[0]["K_NAME"].ToString();

                COMExcel.Range txtBQTY416 = INBQ.get_Range("C" + (tab5), "C" + (tab5));
                txtBQTY416.Merge();
                txtBQTY416.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtBQTY416.Font.Bold = true;
                txtBQTY416.Value2 = Math.Round(sumAll, 2);

                COMExcel.Range txtPCS415 = INBQ.get_Range("D" + (tab5), "D" + (tab5));
                txtPCS415.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtPCS415.Font.Bold = true;
                sumQuanlity5 = double.Parse(sumAll.ToString()) * HANG_SO;
                txtPCS415.Value2 = Math.Round(sumQuanlity4, 2).ToString();

                COMExcel.Range txtPrice415 = INBQ.get_Range("E" + (tab5), "E" + (tab5));
                txtPrice415.Merge();
                txtPrice415.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtPrice415.Font.Bold = true;
                float price5 = 0;
                price5 = float.Parse(Sum_AMOUNT.ToString()) / float.Parse(sumAll.ToString());
                txtPrice415.Value2 = "US$" + Math.Round(price5, 2).ToString();

                COMExcel.Range txtAmount45 = INBQ.get_Range("F" + (tab5), "F" + (tab5));
                txtAmount45.Merge();
                txtAmount45.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtAmount45.Font.Bold = true;
                txtAmount45.Value2 = "US$" + Math.Round(Sum_AMOUNT, 2).ToString();

                COMExcel.Range iNBQ_TOTAL45 = INBQ.get_Range("A" + (tab5 + 1), "B" + (tab5 + 1));
                iNBQ_TOTAL45.Merge();
                iNBQ_TOTAL45.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                iNBQ_TOTAL45.Font.Bold = true;
                iNBQ_TOTAL45.Value2 = "TOTAL: ";

                COMExcel.Range txtQTY45 = INBQ.get_Range("C" + (tab5 + 1), "C" + (tab5 + 1));
                txtQTY45.Merge();
                txtQTY45.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtQTY45.Font.Bold = true;
                txtQTY45.Value2 = Math.Round(sumAll, 2).ToString();

                COMExcel.Range txtQuantaty45 = INBQ.get_Range("D" + (tab5 + 1), "D" + (tab5 + 1));
                txtQuantaty45.Merge();
                txtQuantaty45.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                txtQuantaty45.Font.Bold = true;
                txtQuantaty45.Value2 = Math.Round(sumQuanlity5, 2).ToString();

                COMExcel.Range AMOUNT45 = INBQ.get_Range("F" + (tab5 + 1), "F" + (tab5 + 1));
                AMOUNT45.Merge();
                AMOUNT45.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                AMOUNT45.Font.Bold = true;
                AMOUNT45.Value2 = "US$" + Math.Round(Sum_AMOUNT, 2).ToString();

                con.BorderAround(INBQ.get_Range("A16", "F" + (tab5 + 1)));

                COMExcel.Range rowt51 = INBQ.get_Range("A" + (tab5 + 2) + "", "F" + (tab5 + 2) + "");
                rowt51.Font.Bold = true;
                rowt51.Merge();
                rowt51.Value2 = "SAY TOTAL: ";
                rowt51.Style.Font.Size = 12;
                rowt51.Font.Bold = true;

                COMExcel.Range rowt58 = INBQ.get_Range("D" + (tab5 + 3) + "", "F" + (tab5 + 3) + "");
                rowt58.Font.Bold = true;
                rowt58.Merge();
                rowt58.EntireColumn.AutoFit();
                rowt58.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                COMExcel.Range row5A = INBQ.get_Range("B" + (tab5 + 3) + "", "B" + (tab5 + 3) + "");
                row5A.Font.Bold = true;
                row5A.Value2 = "Destination: " + txtDestination.Text;

                COMExcel.Range row5A1 = INBQ.get_Range("B" + (tab5 + 4) + "", "B" + (tab5 + 4) + "");
                row5A1.Font.Bold = true;
                row5A1.Value2 = "Delivery :";

                COMExcel.Range row5A1B = INBQ.get_Range("C" + (tab5 + 4) + "", "C" + (tab5 + 4) + "");
                row5A1B.Font.Bold = true;
                row5A1B.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                row5A1B.Value2 = txtDeliveryTerm.Text;

                COMExcel.Range row5A2 = INBQ.get_Range("B" + (tab5 + 5) + "", "B" + (tab5 + 5) + "");
                row5A2.Font.Bold = true;
                row5A2.Value2 = "Term of payment :";

                COMExcel.Range row5A2B = INBQ.get_Range("C" + (tab5 + 5) + "", "C" + (tab5 + 5) + "");
                row5A2B.Font.Bold = true;
                row5A2B.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                row5A2B.Value2 = txtTermOfpayment.Text;

                COMExcel.Range row5A3 = INBQ.get_Range("B" + (tab5 + 6) + "", "B" + (tab5 + 6) + "");
                row5A3.Font.Bold = true;
                row5A3.Value2 = "Country of origin : Viet Nam";

                COMExcel.Range row5A13 = INBQ.get_Range("D" + (tab5 + 7) + "", "F" + (tab5 + 7) + "");
                row5A13.Merge();
                row5A13.Font.Bold = true;
                row5A13.Value2 = "LEE CHAO CHUN";
                #endregion
                app.Visible = true;
                app.Quit();
                con.releaseObject(book);
                con.releaseObject(app);
            } 
            

            
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDataExport();
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                if (con.checkExists("SELECT TOP 1 C_NO FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'") == true)
                {
                    F_CNO = txtC_NO.Text;
                    F_CNAME = txtC_NAME.Text;
                    F_ADDRESS = txtADR.Text;
                    frmAddCust frmAddCust = new frmAddCust();
                    frmAddCust.ShowDialog();
                    txtC_NO.Text = "";
                    string DL = frmAddCust.getC_NO_Add_CUST.getC_NO;
                    if (DL != string.Empty)
                    {
                        txtC_NO.Text = DL;
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã khách hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,DONG NAI PROVINCE,VIET NAM.";
            DGV1.Rows.Clear();
            con.DGV(DGV1);

            DGV2.Rows.Clear();
            con.DGV(DGV2);
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                menu.Items.Add("Insert").Name = "Insert";
                menu.Items.Add("Edit").Name = "Edit";
                menu.Items.Add("Del").Name = "Del";

                menu.Show(DGV1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        private void DGV2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                menu.Items.Add("Insert").Name = "Insert";
                menu.Items.Add("Edit").Name = "Edit";
                menu.Items.Add("Del").Name = "Del";

                menu.Show(DGV1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked2;
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    try
                    {
                        if (!string.IsNullOrEmpty(txtC_NO.Text))
                        {
                            ClickInsertDataGridview();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập mã khách hàng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Del":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                        }
                    }
                    break;
            }
        }
        public class getDataRadio
        {
            public static bool rdHangMau;
            public static bool rdHangSX;
        }
        private void ClickInsertDataGridview()
        {
            getDataRadio.rdHangMau = rdHangMau.Checked;
            getDataRadio.rdHangSX = rdHangSX.Checked;
            F_CNO = txtC_NO.Text;
            frmSearchCARB fr = new frmSearchCARB();
            fr.ShowDialog();

            for (int i = 0; i < frmSearchCARB.DT.L_OR_NO.Count; i++)
            {
                string A1 = frmSearchCARB.DT.L_OR_NO[i];
                string A2 = frmSearchCARB.DT.L_COLOR[i];
                string A3 = frmSearchCARB.DT.L_P_NO[i];
                //string A4 = frmSearchCARB.DT.L_COLOR_C[i];
                string A5 = frmSearchCARB.DT.L_P_NAME[i];
                string A6 = frmSearchCARB.DT.L_PNAME3[i];
                string A7 = frmSearchCARB.DT.L_PNAME1[i];
                string A8 = frmSearchCARB.DT.L_BQTY[i];
                string A9 = frmSearchCARB.DT.L_PRICE[i];
                string A10 = frmSearchCARB.DT.L_AMOUNT[i];
                string A11 = frmSearchCARB.DT.L_PCS[i];
                string A12 = frmSearchCARB.DT.L_QPCS[i];
                string A13 = frmSearchCARB.DT.K_NAME[i].ToUpper();
                string A14 = frmSearchCARB.DT.BRAND[i];
                DGV1.Rows.Add(A1, A2, A3, A5, A6, A7, A13, A14, A8, A9, A10, A11, A12, "", "0", "", "0");
            }
        }
        private void Menu_ItemClicked2(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    try
                    {
                        if (!string.IsNullOrEmpty(txtC_NO.Text))
                        {
                            ClickInsertDataGridview2();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập mã khách hàng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Del":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV2.Rows.RemoveAt(oneCell.RowIndex);
                        }
                    }
                    break;
            }
        }
        private void ClickInsertDataGridview2()
        {
            F_CNO = txtC_NO.Text;
            FrmSearchORDB fr = new FrmSearchORDB();
            fr.ShowDialog();
            for (int i = 0; i < FrmSearchORDB.DT.OR_NO.Count; i++)
            {
                string A1 = FrmSearchORDB.DT.OR_NO[i];
                string A2 = FrmSearchORDB.DT.C_NO[i];
                string A3 = FrmSearchORDB.DT.P_NO[i];
                string A4 = FrmSearchORDB.DT.P_NAME_E[i];
                string A5 = FrmSearchORDB.DT.COLOR_E[i];
                string A6 = FrmSearchORDB.DT.THICK[i];
                string A7 = FrmSearchORDB.DT.K_NAME_EN[i].ToUpper();
                string A8 = FrmSearchORDB.DT.BRAND[i];
                string A9 = FrmSearchORDB.DT.QTY[i];
                string A10 = FrmSearchORDB.DT.PRICE[i];
                string A11 = FrmSearchORDB.DT.TOTAL[i];
                DGV2.Rows.Add(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, "");
            }
        }
        private void txtDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate, txtInvoice, sender, e);
        }
        private void txtDeliveryTerm_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtFAX, txtADR, sender, e);
        }
        private void txtDestination_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtADR, txtATTN, sender, e);
        }
        private void txtTAXID_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtTEL, txtHSCODE, sender, e);
        }
        private void txtHSCODE_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtTAXID, txtTermOfpayment, sender, e);
        }
        private void txtTermOfpayment_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtHSCODE, txtShip, sender, e);
        }
        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO, txtDate, sender, e);
        }
        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtInvoice, txtFAX, sender, e);
        }
        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate, txtC_NAME, sender, e);
        }
        private void txtADR_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtDeliveryTerm, txtDestination, sender, e);
        }
        private void txtATTN_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtDestination, txtTEL, sender, e);
        }
        private void txtTEL_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtATTN, txtTAXID, sender, e);
        }
        private void txtFAX_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NAME, txtDeliveryTerm, sender, e);
        }
        private void txtShip_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtTermOfpayment, txtFr, sender, e);
        }
        private void txtAd_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtFr, txtC_NO, sender, e);
        }
        private void txtFr_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtShip, txtAd, sender, e);
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private string getDate(MaskedTextBox maskedText)
        {
            string date = "";
            if (maskedText.MaskFull && !string.IsNullOrEmpty(maskedText.Text))
            {
                date = con.formatstr2(maskedText.Text);
            }
            return date;
        }
        private void rdHangMau_CheckedChanged(object sender, EventArgs e)
        {
            this.DGV1.Columns["V_TheTich"].Visible = false;
            this.DGV1.Columns["CNO_STT"].Visible = false;
            this.DGV1.Columns["Number"].Visible = false;
            this.DGV1.Columns["lstPackage"].Visible = false;
            this.DGV2.Columns["EDT"].Visible = true;
        }
        private void rdHangSX_CheckedChanged(object sender, EventArgs e)
        {
            this.DGV1.Columns["V_TheTich"].Visible = true;
            this.DGV1.Columns["CNO_STT"].Visible = true;
            this.DGV1.Columns["lstPackage"].Visible = true;
            this.DGV1.Columns["Number"].Visible = true;
            this.DGV2.Columns["EDT"].Visible = false;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                rdinvoice.Checked = true;
            }
            else
            {
                radioproforma.Checked = true;
            }
        }
        private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
                float AMOUNT = 0;
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());

                if (Cur == 9 || Cur == 8)
                {
                    AMOUNT = float.Parse(DGV1.CurrentRow.Cells["BQTY"].Value.ToString()) * float.Parse(DGV1.CurrentRow.Cells["PRICE"].Value.ToString());
                    DGV1.CurrentRow.Cells["AMOUNT"].Value = AMOUNT;
                }

                if (Cur == 15)
                {
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)DGV1.Rows[e.RowIndex].Cells["lstPackage"];
                    if (!string.IsNullOrEmpty(cb.Value.ToString()))
                    {
                        if (cb.Value.ToString() == "Pallet (L)")
                        {
                            DGV1.CurrentRow.Cells["Number"].Value = "1.2";
                        }
                        if (cb.Value.ToString() == "Pallet (N)")
                        {
                            DGV1.CurrentRow.Cells["Number"].Value = "0.8";
                        }
                        if (cb.Value.ToString() == "Bag")
                        {
                            DGV1.CurrentRow.Cells["Number"].Value = "0.2";
                        }
                        if (cb.Value.ToString() == "Carton" || cb.Value.ToString() == "Package")
                        {
                            DGV1.CurrentRow.Cells["Number"].Value = "0.1";
                        }
                    }
                    //MessageBox.Show((string)DGV1.CurrentRow.Cells["Number"].Value);
                }
            }
        }
        private void InsertHistoryInvoice2()
        {
            // hang mau 1 hang sx 2
            string sql = "INSERT INTO dbo.tblHistoryInvoice(DATECREATE,INVOICE,USER_NAME,C_NO) " +
                "SELECT '" + getDate(txtDate) + "','" + txtInvoice.Text + "','" + lbUserName.Text + "','" + txtC_NO.Text + "'";
            bool a = con.exedata(sql);
            if (a == true)
            {
                int stt = 1;
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    string sql1 = "INSERT INTO dbo.tblDescription_HistoryInvoice(NR,Invoice,CNO_STT,OR_NO,COLOR,P_NO,P_NAME,P_NAME3,P_NAME1,K_NAME,BRAND,BQTY,PRICE,AMOUNT,PCS,QPCS,V_TheTich,DongGoi,Number,K_TYPE) " +
                   "SELECT '" + stt + "','" + txtInvoice.Text + "','" + this.DGV1.Rows[i].Cells["CNO_STT"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "'," +
                   "'" + this.DGV1.Rows[i].Cells["COLOR"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["P_NO"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["P_NAME"].Value.ToString() + "'," +
                   "'" + this.DGV1.Rows[i].Cells["P_NAME3"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["P_NAME1"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["K_NAME"].Value.ToString() + "'," +
                   "'" + this.DGV1.Rows[i].Cells["BRAND"].Value.ToString() + "','" + float.Parse(this.DGV1.Rows[i].Cells["BQTY"].Value.ToString()) + "','" + float.Parse(this.DGV1.Rows[i].Cells["PRICE"].Value.ToString()) + "'," +
                   "'" + float.Parse(this.DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()) + "','" + float.Parse(this.DGV1.Rows[i].Cells["PCS"].Value.ToString()) + "','" + float.Parse(this.DGV1.Rows[i].Cells["QPCS"].Value.ToString()) + "'," +
                   "'" + this.DGV1.Rows[i].Cells["V_TheTich"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["lstPackage"].Value.ToString() + "','" + this.DGV1.Rows[i].Cells["Number"].Value.ToString() + "'";
                    bool b = con.exedata(sql1);
                    stt++;
                }
                MessageBox.Show("Lưu thành công!!");
            }
        }
        private void InsertHistoryProforma()
        {
            // hang mau 1 hang sx 2
            string sql = "INSERT INTO dbo.tblHistoryProforma(DATECREATE,PI_NO,USER_NAME,C_NO) " +
                "SELECT '" + getDate(txtDate) + "','" + textBox6.Text + "','" + lbUserName.Text + "','" + txtC_NO.Text + "'";
            bool a = con.exedata(sql);
            if (a == true)
            {
                int stt = 1;
                for (int i = 0; i < DGV2.Rows.Count; i++)
                {
                    string sql1 = "INSERT INTO dbo.tblDescription_HistoryProforma(PI_NO,NR,OR_NO,C_NO,P_NO,COLOR_E,P_NAME_E,THICK,K_NAME,BRAND,QTY,PRICE,TOTAL,EDT) " +
                        "SELECT '" + textBox6.Text + "','" + stt + "','" + this.DGV2.Rows[i].Cells["OR_NO1"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["C_NO"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["P_NO1"].Value.ToString() + "'," +
                        "'" + this.DGV2.Rows[i].Cells["COLOR_E1"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["P_NAME_E1"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["THICK1"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["K_NAME1"].Value.ToString() + "','" + this.DGV2.Rows[i].Cells["BRAND1"].Value.ToString() + "'," +
                        "'" + float.Parse(this.DGV2.Rows[i].Cells["QTY1"].Value.ToString()) + "','" + float.Parse(this.DGV2.Rows[i].Cells["PRICE1"].Value.ToString()) + "','" + float.Parse(this.DGV2.Rows[i].Cells["TOTAL1"].Value.ToString()) + "','" + con.formatstr2(this.DGV2.Rows[i].Cells["EDT"].Value.ToString()) + "'";
                    con.exedata(sql1);
                    stt++;
                }
                MessageBox.Show("Lưu thành công!!");
            }

        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (!string.IsNullOrEmpty(txtInvoice.Text))
                    {
                            if (con.checkExists("SELECT TOP 1 * FROM tblHistoryInvoice WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
                            {
                                MessageBox.Show("INVOICE " + txtInvoice.Text + " đã tồn tại, vui lòng kiểm tra lại!!!");
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Bạn có muốn lưu INVOICE, PACKING LIST mã " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dr == DialogResult.OK)
                                {
                                    InsertHistoryInvoice2();
                                }
                            }
                    }
                    else
                    {
                        MessageBox.Show("INVOICE không được để trống!!!");
                    }
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    if (!string.IsNullOrEmpty(textBox6.Text))
                    {
                            if (con.checkExists("SELECT TOP 1 * FROM tblHistoryProforma WHERE PI_NO = '" + textBox6.Text + "'") == true)
                            {
                                MessageBox.Show("Số PI NO " + textBox6.Text + " đã tồn tại, vui lòng kiểm tra lại!!!");
                            }
                            else
                            {
                                DialogResult dr = MessageBox.Show("Bạn có muốn lưu PROFORMA mã " + textBox6.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dr == DialogResult.OK)
                                {
                                    InsertHistoryProforma();
                                }
                            }
                    }
                    else
                    {
                        MessageBox.Show("Số PI_NO không được để trống!!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtInvoice.Text))
            //{
            //  getDataInvoiceChangedtab1();
            //}
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBox6.Text))
            //{
            //   getDataInvoiceChangedtab2();
            //}
        }
       
        private void getDataGribView(string invoice)
        {
            string sql = " SELECT CNO_STT,OR_NO,COLOR,P_NO,P_NAME,P_NAME3,P_NAME1,K_NAME,BRAND,BQTY,PRICE,AMOUNT,PCS,QPCS,V_TheTich,DongGoi AS lstPackage,Number FROM dbo.tblDescription_HistoryInvoice WHERE INVOICE = '" + invoice + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            DGV1.DataSource = data;

        }
        private void getCustomer(string c_no)
        {
            string sql = "SELECT * FROM dbo.tblInfoCustomer WHERE C_NO = '" + c_no + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    txtC_NO.Text = item["C_NO"].ToString();
                    txtC_NAME.Text = item["C_NAME"].ToString();
                    txtADR.Text = item["ADDRESS"].ToString();
                    txtATTN.Text = item["ATTN"].ToString();
                    txtTEL.Text = item["PHONE"].ToString();
                    txtFAX.Text = item["FAX"].ToString();
                    txtHSCODE.Text = item["HSCODE"].ToString();
                    txtTAXID.Text = item["TAXID"].ToString();
                    txtDestination.Text = item["DESTINATION"].ToString();
                    txtShipto.Text = item["SHIPTO"].ToString();
                    txtShipment.Text = item["SHIPMENT"].ToString();
                }
            }

        }

        private void getDataInvoiceChangedtab2()
        {
            // lấy thông tin invoice trước
            string sql1 = "SELECT * FROM dbo.tblHistoryProforma WHERE PI_NO = '" + textBox6.Text + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql1);
            if (data.Rows.Count > 0)
            {
                string keyCust = "";
                string keyproforma = "";
                foreach (DataRow item in data.Rows)
                {
                    keyCust = item["C_NO"].ToString();
                    keyproforma = item["PI_NO"].ToString();
                    txtDate.Text = con.formatstr2(item["DATECREATE"].ToString());
                }
                getCustomer(keyCust);
                getDataGribView2(keyproforma);
            }
        }
        private void getDataGribView2(string proforma)
        {
            string sql = "SELECT OR_NO,C_NO,P_NO,COLOR_E,P_NAME_E,THICK,K_NAME,BRAND,QTY,PRICE,TOTAL,EDT FROM dbo.tblDescription_HistoryProforma WHERE PI_NO = '" + proforma + "'";
            DataTable data = new DataTable();
            foreach (DataRow item in data.Rows)
            {
                item["EDT"] = con.formatstr2(item["EDT"].ToString());
            }
            data = con.readdata(sql);
            DGV2.DataSource = data;
        }

        private void f3ToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {

        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
               DeleteData("tblHistoryInvoice", "tblDescription_HistoryInvoice", "INVOICE", txtInvoice.Text);
               returnNull();
            }
            if (tabControl1.SelectedIndex == 1)
            {
                DeleteData("tblHistoryProforma", "tblDescription_HistoryProforma", "PI_NO", textBox6.Text);
                returnNull2();
            }
        }
        private void DeleteData(string table, string table2, string Column, string key)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                string sql = "DELETE FROM " + table + " WHERE " + Column + " = '" + key + "'";
                bool a = con.exedata(sql);
                if (a == true)
                {
                    string sql1 = "DELETE FROM " + table2 + " WHERE " + Column + " = '" + key + "'";
                    bool b = con.exedata(sql1);
                }

            }
        }
        private void returnNull()
        {
            txtInvoice.Text = "";
            txtTAXID.Text = "";
            txtHSCODE.Text = "";
            txtDestination.Text = "";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtDate.Text = "";
            lblInvoice.Text = "";
            txtADR.Text = "";
            txtATTN.Text = "";
            txtTEL.Text = "";
            txtFAX.Text = "";

            setNUllDataGribView(DGV1);
        }
        private void returnNull2()
        {
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtDate.Text = "";
            lblInvoice.Text = "";
            txtADR.Text = "";
            txtATTN.Text = "";
            txtTEL.Text = "";
            txtFAX.Text = "";

            textBox3.Text = "";
            textBox6.Text = "";
            txtDeliveryTerm.Text = "";
            txtTermOfpayment.Text = "";
            txtShip.Text = "";
            txtShipment.Text = "";
            txtDestination.Text = "";

            setNUllDataGribView(DGV2);
        }
        private void setNUllDataGribView(DataGridView dataGrid)
        {
            DataTable data = (DataTable)dataGrid.DataSource;
            data.Clear();
        }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    returnNull();
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    returnNull2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    frm3LF6_INVOICE frm3LF6_INVOICE = new frm3LF6_INVOICE();
                    frm3LF6_INVOICE.ShowDialog();
                    getCustomer(frm3LF6_INVOICE.getDatafrm3LF6_Invoice.C_NO);
                    getDataGribView(frm3LF6_INVOICE.getDatafrm3LF6_Invoice.Invoice);
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    frm3LF6_PROMAFOR frm = new frm3LF6_PROMAFOR();
                    frm.ShowDialog();
                    getCustomer(frm3LF6_PROMAFOR.getDatafrm3LF6_Proforma.C_NO);
                    getDataGribView(frm3LF6_PROMAFOR.getDatafrm3LF6_Proforma.Invoice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (!string.IsNullOrEmpty(txtInvoice.Text))
                    {
                        if (con.checkExists("SELECT TOP 1 * FROM tblHistoryInvoice WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
                        {
                            MessageBox.Show("INVOICE " + txtInvoice.Text + " không tìm thấy, vui lòng kiểm tra lại!!!");
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Bạn có muốn sửa INVOICE, PACKING LIST mã " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.OK)
                            {
                                UpdateInvoice();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVOICE không được để trống!!!");
                    }
                }
                else
                {
                    if (con.checkExists("SELECT TOP 1 * FROM tblHistoryProforma WHERE PI_NO = '" + textBox6.Text + "'") == true)
                    {
                        MessageBox.Show("Số PI NO " + textBox6.Text + " không tìm thấy, vui lòng kiểm tra lại!!!");
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Bạn có muốn lưu PROFORMA mã " + textBox6.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            UpdateProformar(); 
                        }
                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void UpdateProformar()
        {
            string sql = "UPDATE tblHistoryInvoice SET DATECREATE = '" + getDate(txtDate) + "',INVOICE = '" + txtInvoice.Text + "',C_NO = '" + txtC_NO.Text + "',USER_NAME = '" + lbUserName.Text + "'";
            bool a = con.exedata(sql);
            if (a == true)
            {
                UpdateDGV_Proforma();
            }
        }

        private void UpdateDGV_Proforma()
        {
            if (con.checkExists("SELECT TOP 1 * FROM tblHistoryProforma WHERE PI_NO = '" + textBox6.Text + "'") == true)
            {
                DeleteData("tblHistoryProforma", "tblDescription_HistoryProforma", "PI_NO", textBox6.Text);
                InsertHistoryProforma();
            }
            else
            {
                InsertHistoryProforma();
            }    
        }
        private void UpdateInvoice()
        {
            string sql = "UPDATE tblHistoryInvoice SET DATECREATE = '" + getDate(txtDate) + "',INVOICE = '" + txtInvoice.Text + "',C_NO = '"+txtC_NO.Text+"',USER_NAME = '"+lbUserName.Text+"'";
            bool a = con.exedata(sql);
            if (a == true)
            {
                UpdateDGV_Invoice();
            }    
        }
        private void UpdateDGV_Invoice()
        {
            if (con.checkExists("SELECT TOP 1 * FROM tblHistoryInvoice WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
            {
                DeleteData("tblHistoryInvoice", "tblDescription_HistoryInvoice", "INVOICE", txtInvoice.Text);
                InsertHistoryInvoice2();
            }
            else
            {
                InsertHistoryInvoice2();
            }    
        }
    }
}
