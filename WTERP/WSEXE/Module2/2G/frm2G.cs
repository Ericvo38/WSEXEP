using LibraryCalender;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm2G : Form
    {
        DataProvider con = new DataProvider();
        public frm2G()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void Form2G_Load(object sender, EventArgs e)
        {
            getInfo();
            groupBox11.Hide();
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
        public static string sql = "";
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e) //F1 Cheking Data 
        {

        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 View Data 
        {

        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Closing Form 
        {
            this.Hide();
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e) // Button Closing Form 
        {
            this.Hide();
            this.Close();
        }

        public static string M7;

        public void Check_M7()
        {
            if (con.Check_MaskedText(txtMonth_7) == true)
            {
                if (txtMonth_7.Text != string.Empty)
                {
                    M7 = txtMonth_7.Text;
                }
            }
        }
        int danhmuctab1 = 0;
        System.Data.DataTable dataTab1 = new System.Data.DataTable();
        private void btnView_Click(object sender, EventArgs e) // Button View Data 
        {
            Check_M7();
            if (tabControl1.SelectedIndex == 0)
            {

                if (rdDaheo.Checked == true)
                {
                    danhmuctab1 = 2;
                }
                else
                {
                    danhmuctab1 = 1;
                }
                //if (con.Check_MaskedText(txtMonth1) == true)
                if(txtMonth1.MaskFull)
                {
                    if (radioButton16.Checked == true)
                    {
                        string Y1 = "";
                        string M1 = "";
                        if (con.Check_MaskedText(txtMonth1) == true)
                        {
                            Y1 = txtMonth1.Text.Substring(0, 2);
                            M1 = txtMonth1.Text.Substring(3, 2);
                        }
                        string SQL = "proc_2dTab1 '" + Y1 + "','" + danhmuctab1 + "','%" + txtKD.Text + "%','"+ M1 + "','"+txtDATE2.Text.Replace("/","")+"'";
                        dataTab1 = con.readdata(SQL);
                        View_CNO1();
                    }
                    if (radioButton17.Checked == true)
                    {
                        report1();
                    }
                    if (radioButton18.Checked == true)
                    {
                        report2();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (con.Check_MaskedText(txtMonth_2) == true)
                {
                    if (rddaheo2.Checked == true)
                    {
                        View_PNO1();
                    }
                    if (rddabo2.Checked == true)
                    {
                        View_PNO2();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (con.Check_MaskedText(txtMonth_3) == true)
                {
                    if (rddaheo3.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtKD3.Text) || !string.IsNullOrEmpty(txtBRAND1.Text) || !string.IsNullOrEmpty(txtBRAND2.Text))
                        {
                            string SQLUpdate = "proc_2DTab3_WHERE '2',  N'" + txtMonth_3.Text.Substring(0, 2) + "', '" + txtBRAND1.Text + "', '" + txtBRAND2.Text + "', N'%" + txtKD3.Text + "%','" + txtMonth_3.Text.Substring(3, 2) + "','"+txtDATE2_3.Text.Replace("/","")+"'";
                            View_BRAND1(con.readdata(SQLUpdate));
                        }
                        else
                        {
                            string SQLUpdate = "proc_2DTab3 '2',N'" + txtMonth_3.Text.Substring(0, 2) + "','" + txtMonth_3.Text.Substring(3, 2) + "','" + txtDATE2_3.Text.Replace("/", "") + "'";
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt = con.readdata(SQLUpdate);
                            View_BRAND1(dt);
                        }
                    }
                    if (rddabo3.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtKD3.Text) || !string.IsNullOrEmpty(txtBRAND1.Text) || !string.IsNullOrEmpty(txtBRAND2.Text))
                        {
                            string SQLUpdate = "proc_2DTab3_WHERE '1',  N'" + txtMonth_3.Text.Substring(0, 2) + "', '" + txtBRAND1.Text + "', '" + txtBRAND2.Text + "', N'%" + txtKD3.Text + "%','"+ txtMonth_3.Text.Substring(3, 2) + "','" + txtDATE2_3.Text.Replace("/", "") + "'";
                            View_BRAND2(con.readdata(SQLUpdate));
                        }
                        else
                        {
                            string SQLUpdate = "proc_2DTab3 '1',N'" + txtMonth_3.Text.Substring(0, 2) + "','" + txtMonth_3.Text.Substring(3, 2) + "','" + txtDATE2_3.Text.Replace("/", "") + "'";
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dt = con.readdata(SQLUpdate);
                            View_BRAND2(dt);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (con.Check_MaskedText(txtMonth_4) == true)
                {
                    Export_Excel_Tab4();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedIndex == 4)          
            {
                if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2) == true))
                {
                    if (rdKH.Checked == true)
                    {
                        ViewAGV_KH();
                    }
                    if ((rdLieu.Checked == true) && (rddaheo5.Checked == true))
                    {
                        View_AVG_PNO1();
                    }
                    if ((rdLieu.Checked == true) && (rddabo5.Checked == true))
                    {
                        View_AVG_PNO2();
                    }
                    if ((rdNH.Checked == true) && (rddaheo5.Checked == true))
                    {
                        View_AVG_BRAND1();
                    }
                    if ((rdNH.Checked == true) && (rddabo5.Checked == true))
                    {
                        View_AVG_BRAND2();
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                if (con.Check_MaskedText(txtMonth_6) == true)
                {
                    if (rddaheo6.Checked == true)
                    {
                        View_TNAME1();
                    }
                    if (rddabo6.Checked == true)
                    {
                        View_TNAME2();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                if (con.Check_MaskedText(txtMonth_7) == true)
                {
                    if (txtKHUVUC.Text != "")
                    {
                        txtKHUVUC1 = FrmSearchMEMO1.ID.M_ID;
                    }
                    int danhmuc = 0;
                    if (rdDH.Checked == true)
                    {//Danh muc da heo
                        danhmuc = 2;
                    }
                    else if (rdDB.Checked == true)
                    {
                        danhmuc = 1;
                    }
                    else
                    {
                        danhmuc = 0;
                    }
                    YEAR = int.Parse(txtMonth_7.Text.Substring(0, 2));
                    Months = txtMonth_7.Text.Substring(3, 2);
                    K_NO = danhmuc;
                    txtKHUVUC1 = txtKHUVUC.Text;
                    Parameter.KHUVUC = txtKHUVUC1;
                    Parameter.K_NO = K_NO;
                    Parameter.YEAR = YEAR;
                    Parameter.Months = Months;
                    if (rdSLBC.Checked == true)
                    {
                      frm2G_Tab6_1 fr = new frm2G_Tab6_1();
                      fr.ShowDialog();
                    }
                    else if (rdHBT.Checked == true)
                    {
                       frm2G_Tap7_2 fr = new frm2G_Tap7_2();
                       fr.ShowDialog();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public class Parameter
        {
            public static int K_NO;
            public static int YEAR;
            public static string KHUVUC;
            public static string Months;
        }
        public static string txtKHUVUC1 = "";
        public static int K_NO = 0;
        public static int YEAR = 0;
        public static string Months = "";
        public void report2()
        {
            sql = "select '" + con.formatstr1(txtMonth1.Text) + "' as Date, WS_DATE,C_NO+C_NAME_C as C_NO,OR_NO,T_NAME,BRAND,MODEL_E,P_NAME_E + P_NAME_C as P_NAME_E,COLOR_E,THICK,QTY from ORDB where 1=1";
            if (rdTatCa.Checked == true)
            {
                sql = sql + " AND K_NO in (3,4)";
            }
            else if (rdDaheo.Checked == true)
            {
                sql = sql + " AND K_NO in (4)";
            }
            else if (rddabo.Checked == true)
            {
                sql = sql + " AND K_NO in (3)";
            }

            if (!string.IsNullOrEmpty(txtDATE1.Text))
            {
                sql = sql + " AND WS_DATE>='" + con.formatstr1(txtDATE1.Text) + "'";
            }
            if (!string.IsNullOrEmpty(txtDATE2.Text))
            {
                sql = sql + " AND WS_DATE<='" + con.formatstr1(txtDATE2.Text) + "'";
            }
            if (!string.IsNullOrEmpty(txtKD.Text))
            {
                sql = sql + " AND SALES LIKE '%" + txtKD.Text + "%'";
            }
            sql = sql + " order by C_NO,WS_DATE,NR";
            WSEXE.frm2GTab1 frm2GTab = new WSEXE.frm2GTab1();
            frm2GTab.ShowDialog();
        }
        public void report1()
        {
            sql = "select '" + con.formatstr1(txtMonth1.Text) + "' as Date,WS_DATE,C_NO+C_NAME_C as C_NO,OR_NO,T_NAME,BRAND,MODEL_E,P_NAME_E + P_NAME_C as P_NAME_E,COLOR_E,THICK,QTY from ORDB where 1=1";
            if (rdTatCa.Checked == true)
            {
                sql = sql + " AND K_NO in (1,2,5)";
            }
            else if (rdDaheo.Checked == true)
            {
                sql = sql + " AND K_NO in (1,2,5)";
            }
            else if (rddabo.Checked == true)
            {
                sql = sql + " AND K_NO in (1,2,5)";
            }
            if (!string.IsNullOrEmpty(txtDATE1.Text))
            {
                sql = sql + " AND WS_DATE>='" + con.formatstr1(txtDATE1.Text) + "'";
            }
            if (!string.IsNullOrEmpty(txtDATE2.Text))
            {
                sql = sql + " AND WS_DATE<='" + con.formatstr1(txtDATE2.Text) + "'";
            }
            if (!string.IsNullOrEmpty(txtKD.Text))
            {
                sql = sql + " AND SALES LIKE '%" + txtKD.Text + "%'";
            }
            sql = sql + " order by C_NO,WS_DATE,NR";
            WSEXE.frm2GTab1 frm2GTab = new WSEXE.frm2GTab1();
            frm2GTab.ShowDialog();
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


        // xuất Excel ra tab4
        public void Export_Excel_Tab4()
        {
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            // Khoi tao cell Customer 
            Range Cell_Customer = worksheet.get_Range("A4", "B5");
            Cell_Customer.Merge();
            Cell_Customer.Font.Name = "Times New Roman";
            Cell_Customer.Font.Size = 10;
            Cell_Customer.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Cell_Customer.Value2 = "類別(Style)   日期(Date)";

            // Nam AH
            Range CAH = worksheet.get_Range("AH4", "AH5");
            CAH.Merge();
            CAH.Font.Name = "Times New Roman";
            CAH.Font.Size = 10;
            CAH.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            CAH.Value2 = "總合計";

            //Nam AI
            Range CAI = worksheet.get_Range("AI4", "AI5");
            CAI.Merge();
            CAI.Font.Name = "Times New Roman";
            CAI.Font.Size = 10;
            CAI.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            CAI.Value2 = "平均單價";

            //ROW A1
            Range RA1 = worksheet.get_Range("A6", "A7");
            RA1.Merge();
            RA1.Font.Name = "Times New Roman";
            RA1.Font.Size = 10;
            RA1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RA1.Value2 = "A1:";

            //ROW A2
            Range RA2 = worksheet.get_Range("A8", "A9");
            RA2.Merge();
            RA2.Font.Name = "Times New Roman";
            RA2.Font.Size = 10;
            RA2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RA2.Value2 = "A2:";

            //ROW B1
            Range RB1 = worksheet.get_Range("A10", "A11");
            RB1.Merge();
            RB1.Font.Name = "Times New Roman";
            RB1.Font.Size = 10;
            RB1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB1.Value2 = "B1:";

            //ROW  B2
            Range RB2 = worksheet.get_Range("A12", "A13");
            RB2.Merge();
            RB2.Font.Name = "Times New Roman";
            RB2.Font.Size = 10;
            RB2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB2.Value2 = "B2:";

            //ROW C
            Range RC = worksheet.get_Range("A14", "A15");
            RC.Merge();
            RC.Font.Name = "Times New Roman";
            RC.Font.Size = 10;
            RC.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RC.Value2 = "C:";

            //ROW D
            Range RD = worksheet.get_Range("A16", "A17");
            RD.Merge();
            RD.Font.Name = "Times New Roman";
            RD.Font.Size = 10;
            RD.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RD.Value2 = "D:";

            //ROW B6
            Range RB6 = worksheet.get_Range("B6", "B6");
            RB6.Merge();
            RB6.Font.Name = "Times New Roman";
            RB6.Font.Size = 10;
            RB6.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB6.Value2 = "數量";

            //ROW B7
            Range RB7 = worksheet.get_Range("B7", "B7");
            RB7.Merge();
            RB7.Font.Name = "Times New Roman";
            RB7.Font.Size = 10;
            RB7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB7.Value2 = "金額";

            //ROW B8
            Range RB8 = worksheet.get_Range("B8", "B8");
            RB8.Merge();
            RB8.Font.Name = "Times New Roman";
            RB8.Font.Size = 10;
            RB8.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB8.Value2 = "數量";

            //ROW B9
            Range RB9 = worksheet.get_Range("B9", "B9");
            RB9.Merge();
            RB9.Font.Name = "Times New Roman";
            RB9.Font.Size = 10;
            RB9.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB9.Value2 = "金額";

            //ROW B10
            Range RB10 = worksheet.get_Range("B10", "B10");
            RB10.Merge();
            RB10.Font.Name = "Times New Roman";
            RB10.Font.Size = 10;
            RB10.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB10.Value2 = "數量";

            //ROW B11
            Range RB11 = worksheet.get_Range("B11", "B11");
            RB11.Merge();
            RB11.Font.Name = "Times New Roman";
            RB11.Font.Size = 10;
            RB11.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB11.Value2 = "金額";

            //ROW B12
            Range RB12 = worksheet.get_Range("B12", "B12");
            RB12.Merge();
            RB12.Font.Name = "Times New Roman";
            RB12.Font.Size = 10;
            RB12.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB12.Value2 = "數量";

            //ROW B13
            Range RB13 = worksheet.get_Range("B13", "B13");
            RB13.Merge();
            RB13.Font.Name = "Times New Roman";
            RB13.Font.Size = 10;
            RB13.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB13.Value2 = "金額";

            //ROW B14
            Range RB14 = worksheet.get_Range("B14", "B14");
            RB14.Merge();
            RB14.Font.Name = "Times New Roman";
            RB14.Font.Size = 10;
            RB14.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB14.Value2 = "數量";

            //ROW B15
            Range RB15 = worksheet.get_Range("B15", "B15");
            RB15.Merge();
            RB15.Font.Name = "Times New Roman";
            RB15.Font.Size = 10;
            RB15.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB15.Value2 = "金額";

            //ROW B16
            Range RB16 = worksheet.get_Range("B16", "B16");
            RB16.Merge();
            RB16.Font.Name = "Times New Roman";
            RB16.Font.Size = 10;
            RB16.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB16.Value2 = "數量";


            //ROW B17
            Range RB17 = worksheet.get_Range("B17", "B17");
            RB17.Merge();
            RB17.Font.Name = "Times New Roman";
            RB17.Font.Size = 10;
            RB17.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            RB17.Value2 = "金額";

            //Range Cell_MONTH = worksheet.get_Range(worksheet.Cells[7, 4], worksheet.Cells[9, 4]);
            //Cell_MONTH.Merge(true);

            worksheet.Cells[2, 13] = " 越南-12月訂單平均單價登記表  -  Average Price Report for Month ";
            worksheet.Cells[2, 13].Font.Name = "Times New Roman";

        }
        //sp_BaoCao_TNAME_Y 
        private void txtKinhDoanh1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 fm = new FormSearchStaff4();
            fm.ShowDialog();
            txtKD.Text = FormSearchStaff4.ID.S_NAME2;
        }
        private void txtMonth1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth1.Text = FromCalender.getDate.ToString("yyMM");
        }
        private void txtDATE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtDATE2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtMonth_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth_2.Text = FromCalender.getDate.ToString("yyMM");
        }
        private void txtDATE1_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1_2.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtDATE2_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2_2.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtMonth_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth_3.Text = FromCalender.getDate.ToString("yyMM");
        }
        private void txtDATE1_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1_3.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtDATE2_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2_3.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtMonth_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth_4.Text = FromCalender.getDate.ToString("yyMM");
        }

        private void txtDATE1_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1_4.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE2_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2_4.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtYear1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtYear1.Text = FromCalender.getDate.ToString("yy");
        }
        private void txtYear2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtYear2.Text = FromCalender.getDate.ToString("yy");
        }

        private void txtMonth_6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth_6.Text = FromCalender.getDate.ToString("yyMM");
        }

        private void txtDATE1_6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1_6.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE2_6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2_6.Text = FromCalender.getDate.ToString("yyMMdd");
        }
        private void txtMonth_7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtMonth_7.Text = FromCalender.getDate.ToString("yyMM");
        }
        private void txtDATE1_7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1_7.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE2_7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2_7.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtP_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr = new FormSearchMaterial2();
            fr.ShowDialog();

            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
            {
                txtP_NO1.Text = DL;
            }
            else
                txtP_NO1.Text = "";
        }
        private void txtP_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr = new FormSearchMaterial2();
            fr.ShowDialog();

            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
            {
                txtP_NO2.Text = DL;
            }
            else
                txtP_NO2.Text = "";
        }
        private void txtKD3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 fr1 = new FormSearchStaff4();
            fr1.ShowDialog();
            string DL = FormSearchStaff4.ID.S_NAME2;

            if (DL != string.Empty)
            {
                txtKD3.Text = DL;
            }
            else
                txtKD3.Text = "";
        }

        private void txtBRAND1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr2 = new FormSearchBrand();
            fr2.ShowDialog();

            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
            {
                txtBRAND1.Text = DL;
            }
            else
                txtBRAND1.Text = "";
        }
        private void txtBRAND2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr2 = new FormSearchBrand();
            fr2.ShowDialog();

            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
            {
                txtBRAND2.Text = DL;
            }
            else
                txtBRAND2.Text = "";
        }

        private void txtC_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();

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
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO2.Text = DL;
            }
            else
                txtC_NO2.Text = "";
        }

        private void txtP_NO1_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr2 = new FormSearchMaterial2();
            fr2.ShowDialog();
            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
            {
                txtP_NO1_4.Text = DL;
            }
            else
                txtP_NO1_4.Text = "";
        }

        private void txtP_NO2_4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr3 = new FormSearchMaterial2();
            fr3.ShowDialog();
            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
            {
                txtP_NO2_4.Text = DL;
            }
            else
                txtP_NO2_4.Text = "";
        }

        private void txtBRAND1_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr4 = new FormSearchBrand();
            fr4.ShowDialog();
            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
            {
                txtBRAND1_2.Text = DL;
            }
            else
                txtBRAND1_2.Text = "";
        }

        private void txtBRAND2_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr4 = new FormSearchBrand();
            fr4.ShowDialog();
            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
            {
                txtBRAND2_2.Text = DL;
            }
            else
                txtBRAND2_2.Text = "";
        }

        private void txtKD6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 fr5 = new FormSearchStaff4();
            fr5.ShowDialog();
            string DL = FormSearchStaff4.ID.S_NAME2;
            if (DL != string.Empty)
            {
                txtKD6.Text = DL;
            }
            else
                txtKD6.Text = "";
        }

        private void txtKHUVUC_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmSearchMEMO1 fr = new FrmSearchMEMO1();
            fr.ShowDialog();
            string DL = FrmSearchMEMO1.ID.M_NAME;
            if (DL != string.Empty)
            {
                txtKHUVUC.Text = DL;
            }
            else
                txtKHUVUC.Text = "";

        }

        public void Export_Excel(System.Data.DataTable da)
        {
            string workbookPath = con.LinkTemplate + "Custemer_sp.xls";
            string filePath = con.LinkTemplate_SAVE + "Custemer_sp.xls";
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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                app.Visible = true;

                string Y1 = "";
                if (con.Check_MaskedText(txtMonth1) == true)
                    Y1 = txtMonth1.Text.Substring(0, 2);
                int N1 = int.Parse(Y1) - 1;
                int N2 = int.Parse(Y1) - 2;

                COMExcel.Range Na1 = IV.get_Range("C4", "E5");
                Na1.Value2 = "20" + N2.ToString() + " " + "年";

                COMExcel.Range Na2 = IV.get_Range("F4", "H5");
                Na2.Value2 = "20" + N1.ToString() + " " + "年";

                int a = 7;

                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {

                    COMExcel.Range C_NAME = IV.get_Range("A" + a, "A" + (a + 2));
                    C_NAME.Merge();
                    C_NAME.Value2 = da.Rows[i]["C_NAME"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range K2 = IV.get_Range("B" + (a + 2), "B" + (a + 2));
                    K2.Value2 = "L";

                    COMExcel.Range YO1D = IV.get_Range("C" + a, "C" + a);
                    YO1D.Value2 = da.Rows[i]["Y01D"].ToString();

                    COMExcel.Range YO1P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    YO1P.Value2 = da.Rows[i]["Y01P"].ToString();

                    COMExcel.Range YO1L = IV.get_Range("C" + (a + 2), "C" + (a + 2));
                    YO1L.Value2 = da.Rows[i]["Y01M"].ToString();

                    COMExcel.Range YO1P_S = IV.get_Range("D" + a, "D" + (a + 2));
                    YO1P_S.Merge();
                    YO1P_S.Value2 = da.Rows[i]["Y01P_S"].ToString();

                    COMExcel.Range Y01NUM = IV.get_Range("E" + a, "E" + (a + 2));
                    Y01NUM.Merge();
                    Y01NUM.Value2 = da.Rows[i]["Y01NUM"].ToString();

                    COMExcel.Range Y02D = IV.get_Range("F" + a, "F" + a);
                    Y02D.Value2 = da.Rows[i]["Y02D"].ToString();

                    COMExcel.Range Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    Y02P.Value2 = da.Rows[i]["Y02P"].ToString();

                    COMExcel.Range Y02M = IV.get_Range("F" + (a + 2), "F" + (a + 2));
                    Y02M.Value2 = da.Rows[i]["Y02M"].ToString();

                    COMExcel.Range Y02P_S = IV.get_Range("G" + a, "G" + (a + 2));
                    Y02P_S.Merge();
                    Y02P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    COMExcel.Range Y02NUM = IV.get_Range("H" + a, "H" + (a + 2));
                    Y02NUM.Merge();
                    Y02NUM.Value2 = da.Rows[i]["Y02NUM"].ToString();

                    COMExcel.Range M12D = IV.get_Range("I" + a, "I" + a);
                    M12D.Value2 = da.Rows[i]["M12D"].ToString();

                    COMExcel.Range M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                    M12P.Value2 = da.Rows[i]["M12P"].ToString();

                    COMExcel.Range M12M = IV.get_Range("I" + (a + 2), "I" + (a + 2));
                    M12M.Value2 = da.Rows[i]["M12M"].ToString();

                    COMExcel.Range M12P_S = IV.get_Range("J" + a, "J" + (a + 2));
                    M12P_S.Merge();
                    M12P_S.Value2 = da.Rows[i]["M12P_S"].ToString();

                    COMExcel.Range M01D = IV.get_Range("K" + a, "K" + a);
                    M01D.Value2 = da.Rows[i]["M01D"].ToString();

                    COMExcel.Range M01P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                    M01P.Value2 = da.Rows[i]["M01P"].ToString();

                    COMExcel.Range M01M = IV.get_Range("K" + (a + 2), "K" + (a + 2));
                    M01M.Value2 = da.Rows[i]["M01M"].ToString();

                    COMExcel.Range M01PS = IV.get_Range("L" + a, "L" + (a + 2));
                    M01PS.Merge();
                    M01PS.Value2 = da.Rows[i]["M01P_S"].ToString();

                    COMExcel.Range M02D = IV.get_Range("M" + a, "M" + a);
                    M02D.Value2 = da.Rows[i]["M02D"].ToString();

                    COMExcel.Range M02P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                    M02P.Value2 = da.Rows[i]["M02P"].ToString();

                    COMExcel.Range M02M = IV.get_Range("M" + (a + 2), "M" + (a + 2));
                    M02M.Value2 = da.Rows[i]["M02M"].ToString();

                    COMExcel.Range M02P_S = IV.get_Range("N" + a, "N" + (a + 2));
                    M02P_S.Merge();
                    M02P_S.Value2 = da.Rows[i]["M02P_S"].ToString();

                    COMExcel.Range M03D = IV.get_Range("O" + a, "O" + a);
                    M03D.Value2 = da.Rows[i]["M03D"].ToString();

                    COMExcel.Range M03P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                    M03P.Value2 = da.Rows[i]["M03P"].ToString();

                    COMExcel.Range M03M = IV.get_Range("O" + (a + 2), "O" + (a + 2));
                    M03M.Value2 = da.Rows[i]["M03M"].ToString();

                    COMExcel.Range M03P_S = IV.get_Range("P" + a, "P" + (a + 2));
                    M03P_S.Merge();
                    M03P_S.Value2 = da.Rows[i]["M03P_S"].ToString();

                    COMExcel.Range M04D = IV.get_Range("Q" + a, "Q" + a);
                    M04D.Value2 = da.Rows[i]["M04D"].ToString();

                    COMExcel.Range M04P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                    M04P.Value2 = da.Rows[i]["M04P"].ToString();

                    COMExcel.Range M04M = IV.get_Range("Q" + (a + 2), "Q" + (a + 2));
                    M04M.Value2 = da.Rows[i]["M04M"].ToString();

                    COMExcel.Range M04P_S = IV.get_Range("R" + a, "R" + (a + 2));
                    M04P_S.Merge();
                    M04P_S.Value2 = da.Rows[i]["M04P_S"].ToString();

                    COMExcel.Range M05D = IV.get_Range("S" + a, "S" + a);
                    M05D.Value2 = da.Rows[i]["M05D"].ToString();

                    COMExcel.Range M05P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                    M05P.Value2 = da.Rows[i]["M05P"].ToString();

                    COMExcel.Range M05M = IV.get_Range("S" + (a + 2), "S" + (a + 2));
                    M05M.Value2 = da.Rows[i]["M05M"].ToString();

                    COMExcel.Range M05P_S = IV.get_Range("T" + a, "T" + (a + 2));
                    M05P_S.Merge();
                    M05P_S.Value2 = da.Rows[i]["M05P_S"].ToString();

                    COMExcel.Range M06D = IV.get_Range("U" + a, "U" + a);
                    M06D.Value2 = da.Rows[i]["M06D"].ToString();

                    COMExcel.Range M06P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                    M06P.Value2 = da.Rows[i]["M06P"].ToString();

                    COMExcel.Range M06M = IV.get_Range("U" + (a + 2), "U" + (a + 2));
                    M06M.Value2 = da.Rows[i]["M06M"].ToString();

                    COMExcel.Range M06P_S = IV.get_Range("V" + a, "V" + (a + 2));
                    M06P_S.Merge();
                    M06P_S.Value2 = da.Rows[i]["M06P_S"].ToString();

                    COMExcel.Range M07D = IV.get_Range("W" + a, "W" + a);
                    M07D.Value2 = da.Rows[i]["M07D"].ToString();

                    COMExcel.Range M07P = IV.get_Range("W" + (a + 1), "W" + (a + 1));
                    M07P.Value2 = da.Rows[i]["M07P"].ToString();

                    COMExcel.Range M07M = IV.get_Range("W" + (a + 2), "W" + (a + 2));
                    M07M.Value2 = da.Rows[i]["M07M"].ToString();

                    COMExcel.Range M07P_S = IV.get_Range("X" + a, "X" + (a + 2));
                    M07P_S.Merge();
                    M07P_S.Value2 = da.Rows[i]["M07P_S"].ToString();

                    COMExcel.Range M08D = IV.get_Range("Y" + a, "Y" + a);
                    M08D.Value2 = da.Rows[i]["M08D"].ToString();

                    COMExcel.Range M08P = IV.get_Range("Y" + (a + 1), "Y" + (a + 1));
                    M08P.Value2 = da.Rows[i]["M08P"].ToString();

                    COMExcel.Range M08M = IV.get_Range("Y" + (a + 2), "Y" + (a + 2));
                    M08M.Value2 = da.Rows[i]["M08M"].ToString();

                    COMExcel.Range M08P_S = IV.get_Range("Z" + a, "Z" + (a + 2));
                    M08P_S.Merge();
                    M08P_S.Value2 = da.Rows[i]["M08P_S"].ToString();

                    COMExcel.Range M09D = IV.get_Range("AA" + a, "AA" + a);
                    M09D.Value2 = da.Rows[i]["M09D"].ToString();

                    COMExcel.Range M09P = IV.get_Range("AA" + (a + 1), "AA" + (a + 1));
                    M09P.Value2 = da.Rows[i]["M09P"].ToString();

                    COMExcel.Range M09M = IV.get_Range("AA" + (a + 2), "AA" + (a + 2));
                    M09M.Value2 = da.Rows[i]["M09M"].ToString();

                    COMExcel.Range M09P_S = IV.get_Range("AB" + a, "AB" + (a + 2));
                    M09P_S.Merge();
                    M09P_S.Value2 = da.Rows[i]["M09P_S"].ToString();

                    COMExcel.Range M10D = IV.get_Range("AC" + a, "AC" + a);
                    M10D.Value2 = da.Rows[i]["M10D"].ToString();

                    COMExcel.Range M10P = IV.get_Range("AC" + (a + 1), "AC" + (a + 1));
                    M10P.Value2 = da.Rows[i]["M10P"].ToString();

                    COMExcel.Range M10M = IV.get_Range("AC" + (a + 2), "AC" + (a + 2));
                    M10M.Value2 = da.Rows[i]["M10M"].ToString();

                    COMExcel.Range M10P_S = IV.get_Range("AD" + a, "AD" + (a + 2));
                    M10P_S.Merge();
                    M10P_S.Value2 = da.Rows[i]["M10P_S"].ToString();

                    COMExcel.Range M11D = IV.get_Range("AE" + a, "AE" + a);
                    M11D.Value2 = da.Rows[i]["M11D"].ToString();

                    COMExcel.Range M11P = IV.get_Range("AE" + (a + 1), "AE" + (a + 1));
                    M11P.Value2 = da.Rows[i]["M11P"].ToString();

                    COMExcel.Range M11M = IV.get_Range("AE" + (a + 2), "AE" + (a + 2));
                    M11M.Value2 = da.Rows[i]["M11M"].ToString();

                    COMExcel.Range M11P_S = IV.get_Range("AF" + a, "AF" + (a + 2));
                    M11P_S.Merge();
                    M11P_S.Value2 = da.Rows[i]["M11P_S"].ToString();

                    COMExcel.Range M13D = IV.get_Range("AG" + a, "AG" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("AG" + (a + 1), "AG" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13M = IV.get_Range("AG" + (a + 2), "AG" + (a + 2));
                    M13M.Value2 = da.Rows[i]["M13M"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("AH" + a, "AH" + (a + 2));
                    M13P_S.Merge();
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    COMExcel.Range MNUM = IV.get_Range("AI" + a, "AI" + (a + 2));
                    MNUM.Merge();
                    MNUM.Value2 = da.Rows[i]["MNUM"].ToString();

                    COMExcel.Range MP_S = IV.get_Range("AJ" + a, "AJ" + (a + 2));
                    MP_S.Merge();
                    MP_S.Value2 = da.Rows[i]["MP_S"].ToString();

                    a = a + 3;
                }

                string d1 = "\"D\"";
                string p1 = "\"P\"";
                string l1 = "\"L\"";
                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 2));
                T1.Merge();
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B2 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B2.Value2 = "P";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 2), "B" + (a + 2));
                B3.Value2 = "L";

                COMExcel.Range T_Y01D = IV.get_Range("C" + a, "C" + a);
                T_Y01D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_Y01P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_Y01L = IV.get_Range("C" + (a + 2), "C" + (a + 2));
                T_Y01L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", C7:C" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_Y02D = IV.get_Range("F" + a, "F" + a);
                T_Y02D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_Y02P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_Y02L = IV.get_Range("F" + (a + 2), "F" + (a + 2));
                T_Y02L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", F7:F" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M12D = IV.get_Range("I" + a, "I" + a);
                T_M12D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", I7:I" + (a - 1) + ")";

                COMExcel.Range T_M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                T_M12P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", I7:I" + (a - 1) + ")";

                COMExcel.Range T_M12L = IV.get_Range("I" + (a + 2), "I" + (a + 2));
                T_M12L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", I7:I" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M01D = IV.get_Range("K" + a, "K" + a);
                T_M01D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", K7:K" + (a - 1) + ")";

                COMExcel.Range T_M01P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                T_M01P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", K7:K" + (a - 1) + ")";

                COMExcel.Range T_M01L = IV.get_Range("K" + (a + 2), "K" + (a + 2));
                T_M01L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", K7:K" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M02D = IV.get_Range("M" + a, "M" + a);
                T_M02D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", M7:M" + (a - 1) + ")";

                COMExcel.Range T_M02P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                T_M02P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", M7:M" + (a - 1) + ")";

                COMExcel.Range T_M02L = IV.get_Range("M" + (a + 2), "M" + (a + 2));
                T_M02L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", M7:M" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M03D = IV.get_Range("O" + a, "O" + a);
                T_M03D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", O7:O" + (a - 1) + ")";

                COMExcel.Range T_M03P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                T_M03P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", O7:O" + (a - 1) + ")";

                COMExcel.Range T_M03L = IV.get_Range("O" + (a + 2), "O" + (a + 2));
                T_M03L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", O7:O" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M04D = IV.get_Range("Q" + a, "Q" + a);
                T_M04D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", Q7:Q" + (a - 1) + ")";

                COMExcel.Range T_M04P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                T_M04P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", Q7:Q" + (a - 1) + ")";

                COMExcel.Range T_M04L = IV.get_Range("Q" + (a + 2), "Q" + (a + 2));
                T_M04L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", Q7:Q" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M05D = IV.get_Range("S" + a, "S" + a);
                T_M05D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", S7:S" + (a - 1) + ")";

                COMExcel.Range T_M05P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                T_M05P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", S7:S" + (a - 1) + ")";

                COMExcel.Range T_M05L = IV.get_Range("S" + (a + 2), "S" + (a + 2));
                T_M05L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", S7:S" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M06D = IV.get_Range("U" + a, "U" + a);
                T_M06D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", U7:U" + (a - 1) + ")";

                COMExcel.Range T_M06P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                T_M06P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", U7:U" + (a - 1) + ")";

                COMExcel.Range T_M06L = IV.get_Range("U" + (a + 2), "U" + (a + 2));
                T_M06L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", U7:U" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M07D = IV.get_Range("W" + a, "W" + a);
                T_M07D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", W7:W" + (a - 1) + ")";

                COMExcel.Range T_M07P = IV.get_Range("W" + (a + 1), "W" + (a + 1));
                T_M07P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", W7:W" + (a - 1) + ")";

                COMExcel.Range T_M07L = IV.get_Range("W" + (a + 2), "W" + (a + 2));
                T_M07L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", W7:W" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M08D = IV.get_Range("Y" + a, "Y" + a);
                T_M08D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", Y7:Y" + (a - 1) + ")";

                COMExcel.Range T_M08P = IV.get_Range("Y" + (a + 1), "Y" + (a + 1));
                T_M08P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", Y7:Y" + (a - 1) + ")";

                COMExcel.Range T_M08L = IV.get_Range("Y" + (a + 2), "Y" + (a + 2));
                T_M08L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", Y7:Y" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M09D = IV.get_Range("AA" + a, "AA" + a);
                T_M09D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", AA7:AA" + (a - 1) + ")";

                COMExcel.Range T_M09P = IV.get_Range("AA" + (a + 1), "AA" + (a + 1));
                T_M09P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", AA7:AA" + (a - 1) + ")";

                COMExcel.Range T_M09L = IV.get_Range("AA" + (a + 2), "AA" + (a + 2));
                T_M09L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", AA7:AA" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M10D = IV.get_Range("AC" + a, "AC" + a);
                T_M10D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", AC7:AC" + (a - 1) + ")";

                COMExcel.Range T_M10P = IV.get_Range("AC" + (a + 1), "AC" + (a + 1));
                T_M10P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", AC7:AC" + (a - 1) + ")";

                COMExcel.Range T_M10L = IV.get_Range("AC" + (a + 2), "AC" + (a + 2));
                T_M10L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", AC7:AC" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M11D = IV.get_Range("AE" + a, "AE" + a);
                T_M11D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", AE7:AE" + (a - 1) + ")";

                COMExcel.Range T_M11P = IV.get_Range("AE" + (a + 1), "AE" + (a + 1));
                T_M11P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", AE7:AE" + (a - 1) + ")";

                COMExcel.Range T_M11L = IV.get_Range("AE" + (a + 2), "AE" + (a + 2));
                T_M11L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", AE7:AE" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M13D = IV.get_Range("AG" + a, "AG" + a);
                T_M13D.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", AG7:AG" + (a - 1) + ")";

                COMExcel.Range T_M13P = IV.get_Range("AG" + (a + 1), "AG" + (a + 1));
                T_M13P.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", AG7:AG" + (a - 1) + ")";

                COMExcel.Range T_M13L = IV.get_Range("AG" + (a + 2), "AG" + (a + 2));
                T_M13L.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", AG7:AG" + (a - 1) + ")";

              
                app.Quit();
                releaseObject(book);
                releaseObject(book);
                releaseObject(app);
            }
            
        }
        public void View_CNO1()
        {
            if (dataTab1 != null)
            {
                foreach (DataRow dr in dataTab1.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0.00";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0.00";

                    if (dr["Y01M"].ToString() == string.Empty)
                        dr["Y01M"] = "0.00";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0.00";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0.00";

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0.00";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0.00";

                    if (dr["Y02M"].ToString() == string.Empty)
                        dr["Y02M"] = "0.00";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0.00";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0.00";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0.00";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0.00";

                    if (dr["M12M"].ToString() == string.Empty)
                        dr["M12M"] = "0.00";

                    if (dr["M12P_S"].ToString() == string.Empty)
                        dr["M12P_S"] = "0.00";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0.00";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0.00";

                    if (dr["M01M"].ToString() == string.Empty)
                        dr["M01M"] = "0.00";

                    if (dr["M01P_S"].ToString() == string.Empty)
                        dr["M01P_S"] = "0.00";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0.00";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0.00";

                    if (dr["M02M"].ToString() == string.Empty)
                        dr["M02M"] = "0.00";

                    if (dr["M02P_S"].ToString() == string.Empty)
                        dr["M02P_S"] = "0.00";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0.00";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0.00";

                    if (dr["M03M"].ToString() == string.Empty)
                        dr["M03M"] = "0.00";

                    if (dr["M03P_S"].ToString() == string.Empty)
                        dr["M03P_S"] = "0.00";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0.00";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0.00";

                    if (dr["M04M"].ToString() == string.Empty)
                        dr["M04M"] = "0.00";

                    if (dr["M04P_S"].ToString() == string.Empty)
                        dr["M04P_S"] = "0.00";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0.00";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0.00";

                    if (dr["M05M"].ToString() == string.Empty)
                        dr["M05M"] = "0.00";

                    if (dr["M05P_S"].ToString() == string.Empty)
                        dr["M05P_S"] = "0.00";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0.00";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0.00";

                    if (dr["M06M"].ToString() == string.Empty)
                        dr["M06M"] = "0.00";

                    if (dr["M06P_S"].ToString() == string.Empty)
                        dr["M06P_S"] = "0.00";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0.00";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0.00";

                    if (dr["M07M"].ToString() == string.Empty)
                        dr["M07M"] = "0.00";

                    if (dr["M07P_S"].ToString() == string.Empty)
                        dr["M07P_S"] = "0.00";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0.00";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0.00";

                    if (dr["M08M"].ToString() == string.Empty)
                        dr["M08M"] = "0.00";

                    if (dr["M08P_S"].ToString() == string.Empty)
                        dr["M08P_S"] = "0.00";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0.00";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0.00";

                    if (dr["M09M"].ToString() == string.Empty)
                        dr["M09M"] = "0.00";

                    if (dr["M09P_S"].ToString() == string.Empty)
                        dr["M09P_S"] = "0.00";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0.00";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0.00";

                    if (dr["M10M"].ToString() == string.Empty)
                        dr["M10M"] = "0.00";

                    if (dr["M10P_S"].ToString() == string.Empty)
                        dr["M10P_S"] = "0.00";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0.00";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0.00";

                    if (dr["M11M"].ToString() == string.Empty)
                        dr["M11M"] = "0.00";

                    if (dr["M11P_S"].ToString() == string.Empty)
                        dr["M11P_S"] = "0.00";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13M"].ToString() == string.Empty)
                        dr["M13M"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                    if (dr["MNUM"].ToString() == string.Empty)
                        dr["MNUM"] = "0.00";

                    if (dr["MP_S"].ToString() == string.Empty)
                        dr["MP_S"] = "0.00";

                }

            }
            Export_Excel(dataTab1);
        }

        //TAP2
        public void Export_Excel_PNO(System.Data.DataTable da)
        {
            string workbookPath = con.LinkTemplate + "PNO_sample.xls";
            string filePath = con.LinkTemplate_SAVE + "PNO_sample.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                
                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");


                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];
                app.Visible = true;

                string Y1 = "";
                if (con.Check_MaskedText(txtMonth_2) == true)
                    Y1 = txtMonth_2.Text.Substring(0, 2);
                int N1 = int.Parse(Y1) - 2;
                int N2 = int.Parse(Y1) - 1;

                COMExcel.Range Na1 = IV.get_Range("C4", "E4");
                Na1.Value2 = "Y20" + N1.ToString();

                COMExcel.Range Na2 = IV.get_Range("F4", "H4");
                Na2.Value2 = "Y20" + N2.ToString();
                int a = 8;

                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {
                    // lấy thông tin
                    COMExcel.Range P_NAME1 = IV.get_Range("A" + a, "A" + a);
                    P_NAME1.WrapText = true;
                    P_NAME1.Value2 = da.Rows[i]["P_NAME1"].ToString();

                    COMExcel.Range P_NAME = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                    P_NAME.WrapText = true;
                    P_NAME.Value2 = da.Rows[i]["P_NAME"].ToString();

                  

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    //2 năm trước
                    COMExcel.Range YO1D = IV.get_Range("C" + a, "C" + a);
                    YO1D.Value2 = da.Rows[i]["Y01D"].ToString();

                    COMExcel.Range YO1P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    YO1P.Value2 = da.Rows[i]["Y01P"].ToString();


                    COMExcel.Range Y01NUM = IV.get_Range("D" + a, "D" + (a + 1));
                    Y01NUM.Merge();
                    Y01NUM.Value2 = da.Rows[i]["Y01NUM"].ToString();

                    COMExcel.Range Y01P_S = IV.get_Range("E" + a, "E" + (a + 1));
                    Y01P_S.Merge();
                    Y01P_S.Value2 = da.Rows[i]["Y01P_S"].ToString();

                    //1 năm trước
                    COMExcel.Range Y02D = IV.get_Range("F" + a, "F" + a);
                    Y02D.Value2 = da.Rows[i]["Y02D"].ToString();

                    COMExcel.Range Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    Y02P.Value2 = da.Rows[i]["Y02P"].ToString();

                    COMExcel.Range Y02NUM = IV.get_Range("G" + a, "G" + (a + 1));
                    Y02NUM.Merge();
                    Y02NUM.Value2 = da.Rows[i]["Y02NUM"].ToString();

                    COMExcel.Range Y02P_S = IV.get_Range("H" + a, "H" + (a + 1));
                    Y02P_S.Merge();
                    Y02P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    // bắt đầu 
                    COMExcel.Range M12D = IV.get_Range("I" + a, "I" + a);
                    M12D.Value2 = da.Rows[i]["M12D"].ToString();

                    COMExcel.Range M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                    M12P.Value2 = da.Rows[i]["M12P"].ToString();

                    COMExcel.Range M01D = IV.get_Range("J" + a, "J" + a);
                    M01D.Value2 = da.Rows[i]["M01D"].ToString();

                    COMExcel.Range M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                    M01P.Value2 = da.Rows[i]["M01P"].ToString();

                    COMExcel.Range M02D = IV.get_Range("K" + a, "K" + a);
                    M02D.Value2 = da.Rows[i]["M02D"].ToString();

                    COMExcel.Range M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                    M02P.Value2 = da.Rows[i]["M02P"].ToString();

                    COMExcel.Range M03D = IV.get_Range("L" + a, "L" + a);
                    M03D.Value2 = da.Rows[i]["M03D"].ToString();

                    COMExcel.Range M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                    M03P.Value2 = da.Rows[i]["M03P"].ToString();

                    COMExcel.Range M04D = IV.get_Range("M" + a, "M" + a);
                    M04D.Value2 = da.Rows[i]["M04D"].ToString();

                    COMExcel.Range M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                    M04P.Value2 = da.Rows[i]["M04P"].ToString();

                    COMExcel.Range M05D = IV.get_Range("N" + a, "N" + a);
                    M05D.Value2 = da.Rows[i]["M05D"].ToString();

                    COMExcel.Range M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                    M05P.Value2 = da.Rows[i]["M05P"].ToString();

                    COMExcel.Range M06D = IV.get_Range("O" + a, "O" + a);
                    M06D.Value2 = da.Rows[i]["M06D"].ToString();

                    COMExcel.Range M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                    M06P.Value2 = da.Rows[i]["M06P"].ToString();

                    COMExcel.Range M07D = IV.get_Range("P" + a, "P" + a);
                    M07D.Value2 = da.Rows[i]["M07D"].ToString();

                    COMExcel.Range M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                    M07P.Value2 = da.Rows[i]["M07P"].ToString();

                    COMExcel.Range M08D = IV.get_Range("Q" + a, "Q" + a);
                    M08D.Value2 = da.Rows[i]["M08D"].ToString();

                    COMExcel.Range M08P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                    M08P.Value2 = da.Rows[i]["M08P"].ToString();

                    COMExcel.Range M09D = IV.get_Range("R" + a, "R" + a);
                    M09D.Value2 = da.Rows[i]["M09D"].ToString();

                    COMExcel.Range M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                    M09P.Value2 = da.Rows[i]["M09P"].ToString();

                    COMExcel.Range M10D = IV.get_Range("S" + a, "S" + a);
                    M10D.Value2 = da.Rows[i]["M10D"].ToString();

                    COMExcel.Range M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                    M10P.Value2 = da.Rows[i]["M10P"].ToString();

                    COMExcel.Range M11D = IV.get_Range("T" + a, "T" + a);
                    M11D.Value2 = da.Rows[i]["M11D"].ToString();

                    COMExcel.Range M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                    M11P.Value2 = da.Rows[i]["M11P"].ToString();

                    //tổng kết
                    //hiện tại
                    COMExcel.Range M13D = IV.get_Range("U" + a, "U" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13NUM = IV.get_Range("V" + a, "V" + (a + 1));
                    M13NUM.Merge();
                    M13NUM.Value2 = da.Rows[i]["M13NUM"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("W" + a, "W" + (a + 1));
                    M13P_S.Merge();
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    COMExcel.Range P_NO = IV.get_Range("X" + a, "X" + a);
                    P_NO.Value2 = da.Rows[i]["P_NO"].ToString();

                    a = a + 2;
                }

                string d1 = "\"D\"";
                string p1 = "\"P\"";
                //merge
                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 1));
                T1.Merge();
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                //2 nam trc
                COMExcel.Range T_Y01D = IV.get_Range("C" + a, "C" + a);
                T_Y01D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", C8:C" + (a - 1) + ")";

                COMExcel.Range T_Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_Y01P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", C8:C" + (a - 1) + ")";
                //1 nam trc
                COMExcel.Range T_Y02D = IV.get_Range("F" + a, "F" + a);
                T_Y02D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", F8:F" + (a - 1) + ")";

                COMExcel.Range T_Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_Y02P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", F8:F" + (a - 1) + ")";

                //*********************12
                COMExcel.Range T_M12D = IV.get_Range("I" + a, "I" + a);
                T_M12D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", I8:I" + (a - 1) + ")";

                COMExcel.Range T_M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                T_M12P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", I8:I" + (a - 1) + ")";

                //*********************1

                COMExcel.Range T_M01D = IV.get_Range("J" + a, "J" + a);
                T_M01D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", J8:J" + (a - 1) + ")";

                COMExcel.Range T_M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                T_M01P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", J8:J" + (a - 1) + ")";

                //*********************2

                COMExcel.Range T_M02D = IV.get_Range("K" + a, "K" + a);
                T_M02D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", K8:K" + (a - 1) + ")";

                COMExcel.Range T_M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                T_M02P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", K8:K" + (a - 1) + ")";

                //*********************3

                COMExcel.Range T_M03D = IV.get_Range("L" + a, "L" + a);
                T_M03D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", L8:L" + (a - 1) + ")";

                COMExcel.Range T_M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                T_M03P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", L8:L" + (a - 1) + ")";

                //*********************4

                COMExcel.Range T_M04D = IV.get_Range("M" + a, "M" + a);
                T_M04D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", M8:M" + (a - 1) + ")";

                COMExcel.Range T_M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                T_M04P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", M8:M" + (a - 1) + ")";

                //*********************5

                COMExcel.Range T_M05D = IV.get_Range("N" + a, "N" + a);
                T_M05D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", N8:N" + (a - 1) + ")";

                COMExcel.Range T_M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                T_M05P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", N8:N" + (a - 1) + ")";

                //*********************6

                COMExcel.Range T_M06D = IV.get_Range("O" + a, "O" + a);
                T_M06D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", O8:O" + (a - 1) + ")";

                COMExcel.Range T_M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                T_M06P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", O8:O" + (a - 1) + ")";

                //*********************7

                COMExcel.Range T_M07D = IV.get_Range("P" + a, "P" + a);
                T_M07D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", P8:P" + (a - 1) + ")";

                COMExcel.Range T_M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                T_M07P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", P8:P" + (a - 1) + ")";

                //*********************8

                COMExcel.Range T_M08D = IV.get_Range("Q" + a, "Q" + a);
                T_M08D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", Q8:Q" + (a - 1) + ")";

                COMExcel.Range T_M08P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                T_M08P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", Q8:Q" + (a - 1) + ")";

                //*********************9

                COMExcel.Range T_M09D = IV.get_Range("R" + a, "R" + a);
                T_M09D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", R8:R" + (a - 1) + ")";

                COMExcel.Range T_M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                T_M09P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", R8:R" + (a - 1) + ")";

                //*********************10

                COMExcel.Range T_M10D = IV.get_Range("S" + a, "S" + a);
                T_M10D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", S8:S" + (a - 1) + ")";

                COMExcel.Range T_M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                T_M10P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", S8:S" + (a - 1) + ")";

                //*********************11

                COMExcel.Range T_M11D = IV.get_Range("T" + a, "T" + a);
                T_M11D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", T8:T" + (a - 1) + ")";

                COMExcel.Range T_M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                T_M11P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", T8:T" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M13D = IV.get_Range("U" + a, "U" + a);
                T_M13D.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + d1 + ", U8:U" + (a - 1) + ")";

                COMExcel.Range T_M13P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                T_M13P.Value2 = "=SUMIF(B8:B" + (a - 1) + "," + p1 + ", U8:U" + (a - 1) + ")";

                app.Quit();
                releaseObject(book);
                releaseObject(app);
            }

            
        }

        public void View_PNO1() //Pig Skins
        {
            string Y1 = "";
            string M1 = "";
            if(txtMonth_2.MaskFull)
            {
                Y1 = txtMonth_2.Text.Substring(0, 2);
                M1 = txtMonth_2.Text.Substring(3, 2);
            }    
                
            string sql = "Exec Export_Test_2G_Tab2_DaHeo '" + Y1 + "','"+ M1 + "'";
            if (!string.IsNullOrEmpty(txtP_NO1.Text) && !string.IsNullOrEmpty(txtP_NO2.Text))
            {
                sql = sql + ",'" + txtP_NO1.Text + "','" + txtP_NO2.Text + "'";
            }
            else
            {
                sql = sql + ",'',''";
            }
            sql = sql + ",'" + txtDATE2_2.Text.Replace("/", "") + "'";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0";

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0";
                }
            }
            Export_Excel_PNO(dt);
        }
        public void View_PNO2() //Cow Skins
        {
            string Y1 = "";
            string M1 = "";
            if (con.Check_MaskedText(txtMonth_2) == true)
            {
                Y1 = txtMonth_2.Text.Substring(0, 2);
                M1 = txtMonth_2.Text.Substring(3, 2);
            }    
            string sql = "Exec Export_Test_2G_Tab2_DaBo '" + Y1 + "','"+ M1 + "'";
            if (!string.IsNullOrEmpty(txtP_NO1.Text) && !string.IsNullOrEmpty(txtP_NO2.Text))
            {
                sql = sql + ",'" + txtP_NO1.Text + "','" + txtP_NO2.Text + "'";
            }
            else
            {
                sql = sql + ",'',''";
            }
            sql = sql + ",'" + txtDATE2_2.Text.Replace("/", "") + "'";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0";

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0";
                }
            }
            Export_Excel_PNO(dt);
        }

        // tap3
        public void Export_Excel_BRAND(System.Data.DataTable da)
        {
            string workbookPath = con.LinkTemplate + "BRAND_sample.xls";
            string filePath = con.LinkTemplate_SAVE + "BRAND_sample.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);



                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                app.Visible = true;
                string Y1 = "";
                if (con.Check_MaskedText(txtMonth_3) == true)
                    Y1 = txtMonth_3.Text.Substring(0, 2);
                int N1 = int.Parse(Y1) - 1;
                int N2 = int.Parse(Y1) - 2;

                COMExcel.Range Na1 = IV.get_Range("C4", "E4");
                Na1.Value2 = "20" + N2.ToString() + " " + "年";

                COMExcel.Range Na2 = IV.get_Range("F4", "H4");
                Na2.Value2 = "20" + N1.ToString() + " " + "年";

                int a = 6;
                app.Visible = true;
                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {

                    COMExcel.Range BRAND = IV.get_Range("A" + a, "A" + (a + 1));
                    BRAND.Merge();
                    BRAND.Value2 = da.Rows[i]["BRAND"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range Y01D = IV.get_Range("C" + a, "C" + a);
                    Y01D.Value2 = da.Rows[i]["Y01D"].ToString();

                    COMExcel.Range Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    Y01P.Value2 = da.Rows[i]["Y01P"].ToString();

                    COMExcel.Range Y01NUM = IV.get_Range("D" + a, "D" + (a + 1));
                    Y01NUM.Merge();
                    Y01NUM.Value2 = da.Rows[i]["Y01NUM"].ToString();

                    COMExcel.Range Y01P_S = IV.get_Range("E" + a, "E" + (a + 1));
                    Y01P_S.Merge();
                    Y01P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    //*************************

                    COMExcel.Range Y02D = IV.get_Range("F" + a, "F" + a);
                    Y02D.Value2 = da.Rows[i]["Y02D"].ToString();

                    COMExcel.Range Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    Y02P.Value2 = da.Rows[i]["Y02P"].ToString();

                    COMExcel.Range Y02NUM = IV.get_Range("G" + a, "G" + (a + 1));
                    Y02NUM.Merge();
                    Y02NUM.Value2 = da.Rows[i]["Y02NUM"].ToString();

                    COMExcel.Range Y02P_S = IV.get_Range("H" + a, "H" + (a + 1));
                    Y02P_S.Merge();
                    Y02P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    COMExcel.Range M12D = IV.get_Range("I" + a, "I" + a);
                    M12D.Value2 = da.Rows[i]["M12D"].ToString();

                    COMExcel.Range M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                    M12P.Value2 = da.Rows[i]["M12P"].ToString();

                    COMExcel.Range M01D = IV.get_Range("J" + a, "J" + a);
                    M01D.Value2 = da.Rows[i]["M01D"].ToString();

                    COMExcel.Range M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                    M01P.Value2 = da.Rows[i]["M01P"].ToString();

                    COMExcel.Range M02D = IV.get_Range("K" + a, "K" + a);
                    M02D.Value2 = da.Rows[i]["M02D"].ToString();

                    COMExcel.Range M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                    M02P.Value2 = da.Rows[i]["M02P"].ToString();

                    COMExcel.Range M03D = IV.get_Range("L" + a, "L" + a);
                    M03D.Value2 = da.Rows[i]["M03D"].ToString();

                    COMExcel.Range M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                    M03P.Value2 = da.Rows[i]["M03P"].ToString();

                    COMExcel.Range M04D = IV.get_Range("M" + a, "M" + a);
                    M04D.Value2 = da.Rows[i]["M04D"].ToString();

                    COMExcel.Range M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                    M04P.Value2 = da.Rows[i]["M04P"].ToString();

                    COMExcel.Range M05D = IV.get_Range("N" + a, "N" + a);
                    M05D.Value2 = da.Rows[i]["M05D"].ToString();

                    COMExcel.Range M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                    M05P.Value2 = da.Rows[i]["M05P"].ToString();

                    COMExcel.Range M06D = IV.get_Range("O" + a, "O" + a);
                    M06D.Value2 = da.Rows[i]["M06D"].ToString();

                    COMExcel.Range M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                    M06P.Value2 = da.Rows[i]["M06P"].ToString();

                    COMExcel.Range M07D = IV.get_Range("P" + a, "P" + a);
                    M07D.Value2 = da.Rows[i]["M07D"].ToString();

                    COMExcel.Range M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                    M07P.Value2 = da.Rows[i]["M07P"].ToString();

                    COMExcel.Range M08D = IV.get_Range("Q" + a, "Q" + a);
                    M08D.Value2 = da.Rows[i]["M08D"].ToString();

                    COMExcel.Range M08P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                    M08P.Value2 = da.Rows[i]["M08P"].ToString();

                    COMExcel.Range M09D = IV.get_Range("R" + a, "R" + a);
                    M09D.Value2 = da.Rows[i]["M09D"].ToString();

                    COMExcel.Range M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                    M09P.Value2 = da.Rows[i]["M09P"].ToString();

                    COMExcel.Range M10D = IV.get_Range("S" + a, "S" + a);
                    M10D.Value2 = da.Rows[i]["M10D"].ToString();

                    COMExcel.Range M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                    M10P.Value2 = da.Rows[i]["M10P"].ToString();

                    COMExcel.Range M11D = IV.get_Range("T" + a, "T" + a);
                    M11D.Value2 = da.Rows[i]["M11D"].ToString();

                    COMExcel.Range M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                    M11P.Value2 = da.Rows[i]["M11P"].ToString();

                    COMExcel.Range M13D = IV.get_Range("U" + a, "U" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13NUM = IV.get_Range("V" + a, "V" + (a + 1));
                    M13NUM.Merge();
                    M13NUM.Value2 = da.Rows[i]["M13NUM"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("W" + a, "W" + (a + 1));
                    M13P_S.Merge();
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    a = a + 2;
                }

                string d1 = "\"D\"";
                string p1 = "\"P\"";

                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 1));
                T1.Merge();
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                COMExcel.Range T_Y01D = IV.get_Range("C" + a, "C" + a);
                T_Y01D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $C6:$C" + (a - 1) + ")";

                COMExcel.Range T_Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_Y01P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $C6:$C" + (a - 1) + ")";

                COMExcel.Range TotalD = IV.get_Range("D" + (a), "D" + (a + 1));
                TotalD.Merge();
                TotalD.Value2 = "";

                COMExcel.Range TotalD1 = IV.get_Range("E" + (a), "E" + (a + 1));
                TotalD1.Merge();
                TotalD1.Value2 = "";

                COMExcel.Range TotalG1 = IV.get_Range("G" + (a), "G" + (a + 1));
                TotalG1.Merge();
                TotalG1.Value2 = "";

                COMExcel.Range TotalH1 = IV.get_Range("H" + (a), "H" + (a + 1));
                TotalH1.Merge();
                TotalH1.Value2 = "";
                //*********************

                COMExcel.Range T_Y02D = IV.get_Range("F" + a, "F" + a);
                T_Y02D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $F6:$F" + (a - 1) + ")";

                COMExcel.Range T_Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_Y02P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $F6:$F" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M12D = IV.get_Range("I" + a, "I" + a);
                T_M12D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $I6:$I" + (a - 1) + ")";

                COMExcel.Range T_M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                T_M12P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $I6:$I" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M01D = IV.get_Range("J" + a, "J" + a);
                T_M01D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $J6:$J" + (a - 1) + ")";

                COMExcel.Range T_M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                T_M01P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $J6:$J" + (a - 1) + ")";

                //*********************
                COMExcel.Range T_M02D = IV.get_Range("K" + a, "K" + a);
                T_M02D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $K6:$K" + (a - 1) + ")";

                COMExcel.Range T_M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                T_M02P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", $K6:$K" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M03D = IV.get_Range("L" + a, "L" + a);
                T_M03D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $L6:$L" + (a - 1) + ")";

                COMExcel.Range T_M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                T_M03P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $L6:$L" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M04D = IV.get_Range("M" + a, "M" + a);
                T_M04D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $M6:$M" + (a - 1) + ")";

                COMExcel.Range T_M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                T_M04P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $M6:$M" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M05D = IV.get_Range("N" + a, "N" + a);
                T_M05D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $N6:$N" + (a - 1) + ")";

                COMExcel.Range T_M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                T_M05P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $N6:$N" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M06D = IV.get_Range("O" + a, "O" + a);
                T_M06D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", $O6:$O" + (a - 1) + ")";

                COMExcel.Range T_M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                T_M06P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $O6:$O" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M07D = IV.get_Range("P" + a, "P" + a);
                T_M07D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $P6:$P" + (a - 1) + ")";

                COMExcel.Range T_M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                T_M07P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $P6:$P" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M08D = IV.get_Range("Q" + a, "Q" + a);
                T_M08D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $Q6:$Q" + (a - 1) + ")";

                COMExcel.Range T_M08P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                T_M08P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $Q6:$Q" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M09D = IV.get_Range("R" + a, "R" + a);
                T_M09D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $R6:$R" + (a - 1) + ")";

                COMExcel.Range T_M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                T_M09P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $R6:$R" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M10D = IV.get_Range("S" + a, "S" + a);
                T_M10D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $S6:$S" + (a - 1) + ")";

                COMExcel.Range T_M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                T_M10P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $S6:$S" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M11D = IV.get_Range("T" + a, "T" + a);
                T_M11D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $T6:$T" + (a - 1) + ")";

                COMExcel.Range T_M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                T_M11P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $T6:$T" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M13D = IV.get_Range("U" + a, "U" + a);
                T_M13D.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + d1 + ", $U6:$U" + (a - 1) + ")";

                COMExcel.Range T_M13P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                T_M13P.Value2 = "=SUMIF($B6:$B" + (a - 1) + "," + p1 + ", $U6:$U" + (a - 1) + ")";

                COMExcel.Range v = IV.get_Range("V" + (a), "V" + (a + 1));
                v.Merge();
                v.Value2 = "";

                COMExcel.Range W = IV.get_Range("W" + (a), "W" + (a + 1));
                W.Merge();
                W.Value2 = "";

                app.Quit();
                releaseObject(book);
                releaseObject(book);
                releaseObject(app);
            }
        }
        public void View_BRAND1(System.Data.DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0.00";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0.00";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0.00";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0.00";

                    //******************

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0.00";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0.00";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0.00";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0.00";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0.00";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0.00";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0.00";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0.00";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0.00";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0.00";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0.00";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0.00";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0.00";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0.00";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0.00";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0.00";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0.00";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0.00";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0.00";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0.00";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0.00";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0.00";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0.00";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0.00";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0.00";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0.00";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0.00";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0.00";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                }
            }
            Export_Excel_BRAND(dt);
        }
        public void View_BRAND2(System.Data.DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0.00";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0.00";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0.00";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0.00";

                    //******************

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0.00";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0.00";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0.00";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0.00";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0.00";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0.00";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0.00";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0.00";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0.00";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0.00";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0.00";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0.00";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0.00";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0.00";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0.00";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0.00";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0.00";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0.00";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0.00";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0.00";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0.00";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0.00";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0.00";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0.00";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0.00";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0.00";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0.00";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0.00";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                }
            }
            Export_Excel_BRAND(dt);
        }
        private void rdLieu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLieu.Checked == true)
                groupBox11.Show();
            if (rdLieu.Checked == false)
                groupBox11.Hide();
        }

        private void rdNH_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNH.Checked == true)
                groupBox11.Show();
            if (rdNH.Checked == false)
                groupBox11.Hide();
        }

        // Tap 5
        public void Export_Excel_AVG(System.Data.DataTable da)
        {
            string workbookPath = con.LinkTemplate + "FormAVG_KH.xls";
            string filePath = con.LinkTemplate_SAVE + "FormAVG_KH.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);


                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                app.Visible = true;

                int a = 7;
                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {

                    COMExcel.Range C_NAME = IV.get_Range("A" + a, "A" + (a + 2));
                    C_NAME.Merge();
                    C_NAME.Value2 = da.Rows[i]["C_NAME"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range K2 = IV.get_Range("B" + (a + 2), "B" + (a + 2));
                    K2.Value2 = "L";

                    COMExcel.Range D01 = IV.get_Range("C" + a, "C" + a);
                    D01.Value2 = da.Rows[i]["D01"].ToString();

                    COMExcel.Range P01 = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    P01.Value2 = da.Rows[i]["P01"].ToString();

                    COMExcel.Range C01 = IV.get_Range("C" + (a + 2), "C" + (a + 2));
                    C01.Value2 = da.Rows[i]["C01"].ToString();

                    COMExcel.Range P01P = IV.get_Range("D" + (a + 1), "D" + (a + 1));
                    P01P.Value2 = da.Rows[i]["P01P"].ToString();

                    COMExcel.Range C01P = IV.get_Range("D" + (a + 2), "D" + (a + 2));
                    C01P.Value2 = da.Rows[i]["C01P"].ToString();

                    COMExcel.Range N01 = IV.get_Range("E" + (a + 2), "E" + (a + 2));
                    N01.Value2 = da.Rows[i]["N01"].ToString();

                    //*************************

                    COMExcel.Range D02 = IV.get_Range("F" + a, "F" + a);
                    D02.Value2 = da.Rows[i]["D02"].ToString();

                    COMExcel.Range P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    P02.Value2 = da.Rows[i]["P02"].ToString();

                    COMExcel.Range C02 = IV.get_Range("F" + (a + 2), "F" + (a + 2));
                    C02.Value2 = da.Rows[i]["C02"].ToString();

                    COMExcel.Range P02P = IV.get_Range("G" + (a + 1), "G" + (a + 1));
                    P02P.Value2 = da.Rows[i]["P02P"].ToString();

                    COMExcel.Range C02P = IV.get_Range("G" + (a + 2), "G" + (a + 2));
                    C02P.Value2 = da.Rows[i]["C02P"].ToString();

                    COMExcel.Range N02 = IV.get_Range("H" + (a + 2), "H" + (a + 2));
                    N02.Value2 = da.Rows[i]["N02"].ToString();

                    //***************************

                    COMExcel.Range D03 = IV.get_Range("I" + a, "I" + a);
                    D03.Value2 = da.Rows[i]["D03"].ToString();

                    COMExcel.Range P03 = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                    P03.Value2 = da.Rows[i]["P03"].ToString();

                    COMExcel.Range C03 = IV.get_Range("I" + (a + 2), "I" + (a + 2));
                    C03.Value2 = da.Rows[i]["C03"].ToString();

                    COMExcel.Range P03P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                    P03P.Value2 = da.Rows[i]["P03P"].ToString();

                    COMExcel.Range C03P = IV.get_Range("J" + (a + 2), "J" + (a + 2));
                    C03P.Value2 = da.Rows[i]["C03P"].ToString();

                    COMExcel.Range N03 = IV.get_Range("K" + (a + 2), "K" + (a + 2));
                    N03.Value2 = da.Rows[i]["N03"].ToString();

                    //***************************

                    COMExcel.Range D04 = IV.get_Range("L" + a, "L" + a);
                    D04.Value2 = da.Rows[i]["D04"].ToString();

                    COMExcel.Range P04 = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                    P04.Value2 = da.Rows[i]["P04"].ToString();

                    COMExcel.Range C04 = IV.get_Range("L" + (a + 2), "L" + (a + 2));
                    C04.Value2 = da.Rows[i]["C04"].ToString();

                    COMExcel.Range P04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                    P04P.Value2 = da.Rows[i]["P04P"].ToString();

                    COMExcel.Range C04P = IV.get_Range("M" + (a + 2), "M" + (a + 2));
                    C04P.Value2 = da.Rows[i]["C04P"].ToString();

                    COMExcel.Range N04 = IV.get_Range("N" + (a + 2), "N" + (a + 2));
                    N04.Value2 = da.Rows[i]["N04"].ToString();

                    //***************************

                    COMExcel.Range D05 = IV.get_Range("O" + a, "O" + a);
                    D05.Value2 = da.Rows[i]["D05"].ToString();

                    COMExcel.Range P05 = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                    P05.Value2 = da.Rows[i]["P04"].ToString();

                    COMExcel.Range C05 = IV.get_Range("O" + (a + 2), "O" + (a + 2));
                    C05.Value2 = da.Rows[i]["C05"].ToString();

                    COMExcel.Range P05P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                    P05P.Value2 = da.Rows[i]["P05P"].ToString();

                    COMExcel.Range C05P = IV.get_Range("M" + (a + 2), "M" + (a + 2));
                    C05P.Value2 = da.Rows[i]["C05P"].ToString();

                    COMExcel.Range N05 = IV.get_Range("N" + (a + 2), "N" + (a + 2));
                    N05.Value2 = da.Rows[i]["N05"].ToString();

                    //***************************

                    COMExcel.Range D06 = IV.get_Range("R" + a, "R" + a);
                    D06.Value2 = da.Rows[i]["D06"].ToString();

                    COMExcel.Range P06 = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                    P06.Value2 = da.Rows[i]["P06"].ToString();

                    COMExcel.Range C06 = IV.get_Range("R" + (a + 2), "R" + (a + 2));
                    C06.Value2 = da.Rows[i]["C06"].ToString();

                    COMExcel.Range P06P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                    P06P.Value2 = da.Rows[i]["P06P"].ToString();

                    COMExcel.Range C06P = IV.get_Range("S" + (a + 2), "S" + (a + 2));
                    C06P.Value2 = da.Rows[i]["C06P"].ToString();

                    COMExcel.Range N06 = IV.get_Range("T" + (a + 2), "T" + (a + 2));
                    N06.Value2 = da.Rows[i]["N06"].ToString();

                    //***************************

                    COMExcel.Range D07 = IV.get_Range("U" + a, "U" + a);
                    D07.Value2 = da.Rows[i]["D07"].ToString();

                    COMExcel.Range P07 = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                    P07.Value2 = da.Rows[i]["P07"].ToString();

                    COMExcel.Range C07 = IV.get_Range("U" + (a + 2), "U" + (a + 2));
                    C07.Value2 = da.Rows[i]["C07"].ToString();

                    COMExcel.Range P07P = IV.get_Range("V" + (a + 1), "V" + (a + 1));
                    P07P.Value2 = da.Rows[i]["P07P"].ToString();

                    COMExcel.Range C07P = IV.get_Range("V" + (a + 2), "V" + (a + 2));
                    C07P.Value2 = da.Rows[i]["C07P"].ToString();

                    COMExcel.Range N07 = IV.get_Range("W" + (a + 2), "W" + (a + 2));
                    N07.Value2 = da.Rows[i]["N07"].ToString();

                    //***************************

                    COMExcel.Range D08 = IV.get_Range("X" + a, "X" + a);
                    D08.Value2 = da.Rows[i]["D08"].ToString();

                    COMExcel.Range P08 = IV.get_Range("X" + (a + 1), "X" + (a + 1));
                    P08.Value2 = da.Rows[i]["P08"].ToString();

                    COMExcel.Range C08 = IV.get_Range("X" + (a + 2), "X" + (a + 2));
                    C08.Value2 = da.Rows[i]["C08"].ToString();

                    COMExcel.Range P08P = IV.get_Range("Y" + (a + 1), "Y" + (a + 1));
                    P08P.Value2 = da.Rows[i]["P08P"].ToString();

                    COMExcel.Range C08P = IV.get_Range("Y" + (a + 2), "Y" + (a + 2));
                    C08P.Value2 = da.Rows[i]["C08P"].ToString();

                    COMExcel.Range N08 = IV.get_Range("Z" + (a + 2), "Z" + (a + 2));
                    N08.Value2 = da.Rows[i]["N08"].ToString();

                    //***************************

                    COMExcel.Range D09 = IV.get_Range("AA" + a, "AA" + a);
                    D09.Value2 = da.Rows[i]["D09"].ToString();

                    COMExcel.Range P09 = IV.get_Range("AA" + (a + 1), "AA" + (a + 1));
                    P09.Value2 = da.Rows[i]["P09"].ToString();

                    COMExcel.Range C09 = IV.get_Range("AA" + (a + 2), "AA" + (a + 2));
                    C09.Value2 = da.Rows[i]["C09"].ToString();

                    COMExcel.Range P09P = IV.get_Range("AB" + (a + 1), "AB" + (a + 1));
                    P09P.Value2 = da.Rows[i]["P09P"].ToString();

                    COMExcel.Range C09P = IV.get_Range("AB" + (a + 2), "AB" + (a + 2));
                    C09P.Value2 = da.Rows[i]["C09P"].ToString();

                    COMExcel.Range N09 = IV.get_Range("AC" + (a + 2), "AC" + (a + 2));
                    N09.Value2 = da.Rows[i]["N09"].ToString();

                    //***************************

                    COMExcel.Range D10 = IV.get_Range("AE" + a, "AE" + a);
                    D10.Value2 = da.Rows[i]["D10"].ToString();

                    COMExcel.Range P10 = IV.get_Range("AE" + (a + 1), "AE" + (a + 1));
                    P10.Value2 = da.Rows[i]["P10"].ToString();

                    COMExcel.Range C10 = IV.get_Range("AE" + (a + 2), "AE" + (a + 2));
                    C10.Value2 = da.Rows[i]["C10"].ToString();

                    COMExcel.Range P10P = IV.get_Range("AF" + (a + 1), "AF" + (a + 1));
                    P10P.Value2 = da.Rows[i]["P10P"].ToString();

                    COMExcel.Range C10P = IV.get_Range("AF" + (a + 2), "AF" + (a + 2));
                    C10P.Value2 = da.Rows[i]["C10P"].ToString();

                    COMExcel.Range N10 = IV.get_Range("AG" + (a + 2), "AG" + (a + 2));
                    N10.Value2 = da.Rows[i]["N10"].ToString();

                    a = a + 3;
                }

                string d1 = "\"D\"";
                string p1 = "\"P\"";
                string l1 = "\"L\"";


                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 2));
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                COMExcel.Range B4 = IV.get_Range("B" + (a + 2), "B" + (a + 2));
                B4.Value2 = "L";

                COMExcel.Range T_D01 = IV.get_Range("C" + a, "C" + a);
                T_D01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_P01 = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_P01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_C01 = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_C01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", C7:C" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_D02 = IV.get_Range("F" + a, "F" + a);
                T_D02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_P02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_C02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_C02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + l1 + ", F7:F" + (a - 1) + ")";

                app.Quit();
                releaseObject(book);
                releaseObject(book);
                releaseObject(app);

            }

        }

        public void ViewAGV_KH()
        {
            string Y1 = "";
            if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2)))
                Y1 = txtYear1.Text;

            string SQL = " select C_NAME, D01, P01, C01, P01P, C01P, N01, D02, P02, C02, P02P, C02P, N02, D03, P03, C03, P03P, C03P, N03, D04, P04, C04, P04P, C04P, N04, D05, P05, C05, P05P, C05P, N05, D06, P06, C06, P06P, C06P, N06, D07, P07, C07, P07P, C07P, N07,  D08, P08, C08, P08P, C08P, N08, D09, P09, C09, P09P, C09P, N09," +
                " D10, P10, C10, P10P, C10P, N10 FROM ORD_CNOT ORDER BY N01 ASC";

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(SQL);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["D01"].ToString() == string.Empty)
                        dr["D01"] = "0.00";

                    if (dr["P01"].ToString() == string.Empty)
                        dr["P01"] = "0.00";

                    if (dr["C01"].ToString() == string.Empty)
                        dr["C01"] = "0.00";

                    if (dr["P01P"].ToString() == string.Empty)
                        dr["P01P"] = "0.00";

                    if (dr["C01P"].ToString() == string.Empty)
                        dr["C01P"] = "0.00";

                    if (dr["N01"].ToString() == string.Empty)
                        dr["N01"] = "0.00";

                    //******************

                    if (dr["D02"].ToString() == string.Empty)
                        dr["D02"] = "0.00";

                    if (dr["P02"].ToString() == string.Empty)
                        dr["P02"] = "0.00";

                    if (dr["C02"].ToString() == string.Empty)
                        dr["C02"] = "0.00";

                    if (dr["P02P"].ToString() == string.Empty)
                        dr["P02P"] = "0.00";

                    if (dr["C02P"].ToString() == string.Empty)
                        dr["C02P"] = "0.00";

                    if (dr["N02"].ToString() == string.Empty)
                        dr["N02"] = "0.00";
                }
            }
            Export_Excel_AVG(dt);
        }

        public void Export_Excel_AVGPNO(System.Data.DataTable da)
        {
           
            string workbookPath = con.LinkTemplate + "FormAVG_PNO.xls";
            string filePath = con.LinkTemplate_SAVE + "FormAVG_PNO.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                int a = 7;
                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {

                    COMExcel.Range P_NAME1 = IV.get_Range("A" + a, "A" + a);
                    P_NAME1.Value2 = da.Rows[i]["P_NAME1"].ToString();

                    COMExcel.Range P_NAME = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                    P_NAME.Value2 = da.Rows[i]["P_NAME"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range M13D = IV.get_Range("C" + a, "C" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("D" + a, "D" + (a + 1));
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    COMExcel.Range M13NUM = IV.get_Range("E" + a, "E" + (a + 1));
                    M13NUM.Value2 = da.Rows[i]["M13NUM"].ToString();

                    //*************************

                    COMExcel.Range D02 = IV.get_Range("F" + a, "F" + a);
                    D02.Value2 = da.Rows[i]["D02"].ToString();

                    COMExcel.Range P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    P02.Value2 = da.Rows[i]["P02"].ToString();

                    COMExcel.Range P02P = IV.get_Range("G" + a, "G" + (a + 1));
                    P02P.Value2 = da.Rows[i]["P02P"].ToString();

                    COMExcel.Range N02 = IV.get_Range("H" + a, "H" + (a + 1));
                    N02.Value2 = da.Rows[i]["N02"].ToString();

                    a = a + 2;
                }
                string d1 = "\"D\"";
                string p1 = "\"P\"";

                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 1));
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                COMExcel.Range T_D01 = IV.get_Range("C" + a, "C" + a);
                T_D01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_P01 = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_P01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", C7:C" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_D02 = IV.get_Range("F" + a, "F" + a);
                T_D02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_P02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", F7:F" + (a - 1) + ")";

                app.Visible = true;

                app.Quit();
                releaseObject(book);
                releaseObject(book);
                releaseObject(app);
            }
        }
        public void View_AVG_PNO1()
        {
            string Y1 = "";
            if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2)))
                Y1 = txtYear1.Text;

            string SQL = " select PROD.P_NAME1, ORD_PNO.P_NAME, ORD_PNO.M13D, ORD_PNO.M13P, ORD_PNO.M13P_S, ORD_PNO.M13NUM, '' as D02, '' as P02, '' as P02P, '' as N02  from ORD_PNO LEFT JOIN PROD ON ORD_PNO.P_NO = PROD.P_NO Where ORD_PNO.O_YEAR = '" + Y1 + "'  AND ORD_PNO.B_NO = '2'  ";
            // MessageBox.Show(SQL);

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(SQL);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    //******************

                    if (dr["D02"].ToString() == string.Empty)
                        dr["D02"] = "0.00";

                    if (dr["P02"].ToString() == string.Empty)
                        dr["P02"] = "0.00";

                    if (dr["P02P"].ToString() == string.Empty)
                        dr["P02P"] = "0.00";

                    if (dr["N02"].ToString() == string.Empty)
                        dr["N02"] = "0.00";
                }
            }
            Export_Excel_AVGPNO(dt);
        }

        public void View_AVG_PNO2()
        {
            string Y1 = "";
            if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2)))
                Y1 = txtYear1.Text;

            string SQL1 = " select PROD.P_NAME1, ORD_PNO.P_NAME, ORD_PNO.M13D, ORD_PNO.M13P, ORD_PNO.M13P_S, ORD_PNO.M13NUM, '' as D02, '' as P02, '' as P02P, '' as N02  from ORD_PNO LEFT JOIN PROD ON ORD_PNO.P_NO = PROD.P_NO Where ORD_PNO.O_YEAR = '" + Y1 + "'  AND ORD_PNO.B_NO = '1' ";

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = con.readdata(SQL1);
            if (dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    //******************

                    if (dr["D02"].ToString() == string.Empty)
                        dr["D02"] = "0.00";

                    if (dr["P02"].ToString() == string.Empty)
                        dr["P02"] = "0.00";

                    if (dr["P02P"].ToString() == string.Empty)
                        dr["P02P"] = "0.00";

                    if (dr["N02"].ToString() == string.Empty)
                        dr["N02"] = "0.00";
                }
            }
            Export_Excel_AVGPNO(dt1);
        }

        public void Export_Excel_AVGBRAND(System.Data.DataTable da)
        {
           
            string workbookPath = con.LinkTemplate + "FormAVG_BRAND.xls";
            string filePath = con.LinkTemplate_SAVE + "FormAVG_BRAND.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                int a = 7;
                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {

                    COMExcel.Range BRAND = IV.get_Range("A" + a, "A" + (a + 1));
                    BRAND.Value2 = da.Rows[i]["BRAND"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range M13D = IV.get_Range("C" + a, "C" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("D" + a, "D" + (a + 1));
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    COMExcel.Range M13NUM = IV.get_Range("E" + a, "E" + (a + 1));
                    M13NUM.Value2 = da.Rows[i]["M13NUM"].ToString();

                    //*************************

                    COMExcel.Range D02 = IV.get_Range("F" + a, "F" + a);
                    D02.Value2 = da.Rows[i]["D02"].ToString();

                    COMExcel.Range P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    P02.Value2 = da.Rows[i]["P02"].ToString();

                    COMExcel.Range P02P = IV.get_Range("G" + a, "G" + (a + 1));
                    P02P.Value2 = da.Rows[i]["P02P"].ToString();

                    COMExcel.Range N02 = IV.get_Range("H" + a, "H" + (a + 1));
                    N02.Value2 = da.Rows[i]["N02"].ToString();

                    a = a + 2;
                }
                string d1 = "\"D\"";
                string p1 = "\"P\"";

                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 1));
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                COMExcel.Range T_D01 = IV.get_Range("C" + a, "C" + a);
                T_D01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", C7:C" + (a - 1) + ")";

                COMExcel.Range T_P01 = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_P01.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", C7:C" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_D02 = IV.get_Range("F" + a, "F" + a);
                T_D02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + d1 + ", F7:F" + (a - 1) + ")";

                COMExcel.Range T_P02 = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                T_P02.Value2 = "=SUMIF(B7:B" + (a - 1) + "," + p1 + ", F7:F" + (a - 1) + ")";

                app.Visible = true;
                //book;

                app.Quit();
                releaseObject(book);
                releaseObject(book);
                releaseObject(app);

            }
               
        }
        public void View_AVG_BRAND1()
        {
            string Y1 = "";
            if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2)))
                Y1 = txtYear1.Text;

            string SQL1 = " select BRAND, M13D, M13P, M13P_S, M13NUM, '' as D02, '' as P02, '' as P02P, '' as N02  from ORD_BRD Where O_YEAR = '" + Y1 + "'  AND B_NO = '2' ";

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = con.readdata(SQL1);
            if (dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    //******************

                    if (dr["D02"].ToString() == string.Empty)
                        dr["D02"] = "0.00";

                    if (dr["P02"].ToString() == string.Empty)
                        dr["P02"] = "0.00";

                    if (dr["P02P"].ToString() == string.Empty)
                        dr["P02P"] = "0.00";

                    if (dr["N02"].ToString() == string.Empty)
                        dr["N02"] = "0.00";
                }
            }
            Export_Excel_AVGBRAND(dt1);
        }
        public void View_AVG_BRAND2()
        {
            string Y1 = "";
            if ((con.Check_MaskedText(txtYear1) == true) && (con.Check_MaskedText(txtYear2)))
                Y1 = txtYear1.Text;

            string SQL1 = " select BRAND, M13D, M13P, M13P_S, M13NUM, '' as D02, '' as P02, '' as P02P, '' as N02  from ORD_BRD Where O_YEAR = '" + Y1 + "'  AND B_NO = '1' ";

            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = con.readdata(SQL1);
            if (dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    //******************

                    if (dr["D02"].ToString() == string.Empty)
                        dr["D02"] = "0.00";

                    if (dr["P02"].ToString() == string.Empty)
                        dr["P02"] = "0.00";

                    if (dr["P02P"].ToString() == string.Empty)
                        dr["P02P"] = "0.00";

                    if (dr["N02"].ToString() == string.Empty)
                        dr["N02"] = "0.00";
                }
            }
            Export_Excel_AVGBRAND(dt1);
        }
        // tap 6 - - - - - - 
        public void Export_Excel_TNAME(System.Data.DataTable da)
        {
            string workbookPath = con.LinkTemplate + "TNAME_sample.xls";
            string filePath = con.LinkTemplate_SAVE + "TNAME_sample1.xls";

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
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                int ColumnsCount;
                if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                string Y1 = "";
                if (con.Check_MaskedText(txtMonth_6) == true)
                    Y1 = txtMonth_6.Text.Substring(0, 2);
                int N1 = int.Parse(Y1) - 1;
                int N2 = int.Parse(Y1) - 2;

                COMExcel.Range Na1 = IV.get_Range("C4", "E4");
                Na1.Value2 = "20" + N2.ToString() + " " + "年";

                COMExcel.Range Na2 = IV.get_Range("F4", "H4");
                Na2.Value2 = "20" + N1.ToString() + " " + "年";

                int a = 6;

                for (int i = 0; i <= da.Rows.Count - 1; i++)
                {
                    COMExcel.Range TNAME = IV.get_Range("A" + a, "A" + (a + 1));
                    TNAME.Value2 = da.Rows[i]["T_NAME"].ToString();

                    COMExcel.Range K = IV.get_Range("B" + a, "B" + a);
                    K.Value2 = "D";

                    COMExcel.Range K1 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                    K1.Value2 = "P";

                    COMExcel.Range Y01D = IV.get_Range("C" + a, "C" + a);
                    Y01D.Value2 = da.Rows[i]["Y01D"].ToString();

                    COMExcel.Range Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                    Y01P.Value2 = da.Rows[i]["Y01P"].ToString();

                    COMExcel.Range Y01NUM = IV.get_Range("D" + a, "D" + (a + 2));
                    Y01NUM.Value2 = da.Rows[i]["Y01NUM"].ToString();

                    COMExcel.Range Y01P_S = IV.get_Range("E" + a, "E" + (a + 2));
                    Y01P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    //*************************

                    COMExcel.Range Y02D = IV.get_Range("F" + a, "F" + a);
                    Y02D.Value2 = da.Rows[i]["Y02D"].ToString();

                    COMExcel.Range Y02P = IV.get_Range("F" + (a + 1), "F" + (a + 1));
                    Y02P.Value2 = da.Rows[i]["Y02P"].ToString();

                    COMExcel.Range Y02NUM = IV.get_Range("G" + a, "G" + (a + 2));
                    Y02NUM.Value2 = da.Rows[i]["Y02NUM"].ToString();

                    COMExcel.Range Y02P_S = IV.get_Range("H" + a, "H" + (a + 2));
                    Y02P_S.Value2 = da.Rows[i]["Y02P_S"].ToString();

                    COMExcel.Range M12D = IV.get_Range("I" + a, "I" + a);
                    M12D.Value2 = da.Rows[i]["M12D"].ToString();

                    COMExcel.Range M12P = IV.get_Range("I" + a, "I" + (a + 1));
                    M12P.Value2 = da.Rows[i]["M12P"].ToString();

                    COMExcel.Range M01D = IV.get_Range("J" + a, "J" + a);
                    M01D.Value2 = da.Rows[i]["M01D"].ToString();

                    COMExcel.Range M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                    M01P.Value2 = da.Rows[i]["M01P"].ToString();

                    COMExcel.Range M02D = IV.get_Range("K" + a, "K" + a);
                    M02D.Value2 = da.Rows[i]["M02D"].ToString();

                    COMExcel.Range M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                    M02P.Value2 = da.Rows[i]["M02P"].ToString();

                    COMExcel.Range M03D = IV.get_Range("L" + a, "L" + a);
                    M03D.Value2 = da.Rows[i]["M03D"].ToString();

                    COMExcel.Range M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                    M03P.Value2 = da.Rows[i]["M03P"].ToString();

                    COMExcel.Range M04D = IV.get_Range("M" + a, "M" + a);
                    M04D.Value2 = da.Rows[i]["M04D"].ToString();

                    COMExcel.Range M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                    M04P.Value2 = da.Rows[i]["M04P"].ToString();

                    COMExcel.Range M05D = IV.get_Range("N" + a, "N" + a);
                    M05D.Value2 = da.Rows[i]["M05D"].ToString();

                    COMExcel.Range M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                    M05P.Value2 = da.Rows[i]["M05P"].ToString();

                    COMExcel.Range M06D = IV.get_Range("O" + a, "O" + a);
                    M06D.Value2 = da.Rows[i]["M06D"].ToString();

                    COMExcel.Range M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                    M06P.Value2 = da.Rows[i]["M06P"].ToString();

                    COMExcel.Range M07D = IV.get_Range("P" + a, "P" + a);
                    M07D.Value2 = da.Rows[i]["M07D"].ToString();

                    COMExcel.Range M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                    M07P.Value2 = da.Rows[i]["M07P"].ToString();

                    COMExcel.Range M08D = IV.get_Range("Q" + a, "Q" + a);
                    M08D.Value2 = da.Rows[i]["M08D"].ToString();

                    COMExcel.Range M08P = IV.get_Range("Q" + (a + 1), "Q" + (a + 1));
                    M08P.Value2 = da.Rows[i]["M08P"].ToString();

                    COMExcel.Range M09D = IV.get_Range("R" + a, "R" + a);
                    M09D.Value2 = da.Rows[i]["M09D"].ToString();

                    COMExcel.Range M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                    M09P.Value2 = da.Rows[i]["M09P"].ToString();

                    COMExcel.Range M10D = IV.get_Range("S" + a, "S" + a);
                    M10D.Value2 = da.Rows[i]["M10D"].ToString();

                    COMExcel.Range M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                    M10P.Value2 = da.Rows[i]["M10P"].ToString();

                    COMExcel.Range M11D = IV.get_Range("T" + a, "T" + a);
                    M11D.Value2 = da.Rows[i]["M11D"].ToString();

                    COMExcel.Range M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                    M11P.Value2 = da.Rows[i]["M11P"].ToString();

                    COMExcel.Range M13D = IV.get_Range("U" + a, "U" + a);
                    M13D.Value2 = da.Rows[i]["M13D"].ToString();

                    COMExcel.Range M13P = IV.get_Range("U" + (a + 1), "U" + (a + 1));
                    M13P.Value2 = da.Rows[i]["M13P"].ToString();

                    COMExcel.Range M13NUM = IV.get_Range("V" + a, "V" + (a + 2));
                    M13NUM.Value2 = da.Rows[i]["M13NUM"].ToString();

                    COMExcel.Range M13P_S = IV.get_Range("W" + a, "W" + (a + 2));
                    M13P_S.Value2 = da.Rows[i]["M13P_S"].ToString();

                    a = a + 2;
                }

                string d1 = "\"D\"";
                string p1 = "\"P\"";

                COMExcel.Range T1 = IV.get_Range("A" + a, "A" + (a + 1));
                T1.Value2 = "TOTAL";

                COMExcel.Range B1 = IV.get_Range("B" + a, "B" + a);
                B1.Value2 = "D";

                COMExcel.Range B3 = IV.get_Range("B" + (a + 1), "B" + (a + 1));
                B3.Value2 = "P";

                COMExcel.Range T_Y01D = IV.get_Range("C" + a, "C" + a);
                T_Y01D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", C6:C" + (a - 1) + ")";

                COMExcel.Range T_Y01P = IV.get_Range("C" + (a + 1), "C" + (a + 1));
                T_Y01P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", C6:C" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_Y02D = IV.get_Range("F" + a, "F" + a);
                T_Y02D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", F6:F" + (a - 1) + ")";

                COMExcel.Range T_Y02P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                T_Y02P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", F6:F" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M12D = IV.get_Range("I" + a, "I" + a);
                T_M12D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", I6:I" + (a - 1) + ")";

                COMExcel.Range T_M12P = IV.get_Range("I" + (a + 1), "I" + (a + 1));
                T_M12P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", I6:I" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M01D = IV.get_Range("J" + a, "J" + a);
                T_M01D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", J6:J" + (a - 1) + ")";

                COMExcel.Range T_M01P = IV.get_Range("J" + (a + 1), "J" + (a + 1));
                T_M01P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", J6:J" + (a - 1) + ")";

                //*********************
                COMExcel.Range T_M02D = IV.get_Range("K" + a, "K" + a);
                T_M02D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", K6:K" + (a - 1) + ")";

                COMExcel.Range T_M02P = IV.get_Range("K" + (a + 1), "K" + (a + 1));
                T_M02P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", K6:K" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M03D = IV.get_Range("L" + a, "L" + a);
                T_M03D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", L6:L" + (a - 1) + ")";

                COMExcel.Range T_M03P = IV.get_Range("L" + (a + 1), "L" + (a + 1));
                T_M03P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", L6:L" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M04D = IV.get_Range("M" + a, "M" + a);
                T_M04D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", M6:M" + (a - 1) + ")";

                COMExcel.Range T_M04P = IV.get_Range("M" + (a + 1), "M" + (a + 1));
                T_M04P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", M6:M" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M05D = IV.get_Range("N" + a, "N" + a);
                T_M05D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", N6:N" + (a - 1) + ")";

                COMExcel.Range T_M05P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                T_M05P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", N6:N" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M06D = IV.get_Range("O" + a, "O" + a);
                T_M06D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", O6:O" + (a - 1) + ")";

                COMExcel.Range T_M06P = IV.get_Range("O" + (a + 1), "O" + (a + 1));
                T_M06P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", O6:O" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M07D = IV.get_Range("P" + a, "P" + a);
                T_M07D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", P6:P" + (a - 1) + ")";

                COMExcel.Range T_M07P = IV.get_Range("P" + (a + 1), "P" + (a + 1));
                T_M07P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", P6:P" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M08D = IV.get_Range("Q" + a, "Q" + a);
                T_M08D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", Q8:Q" + (a - 1) + ")";

                COMExcel.Range T_M08P = IV.get_Range("N" + (a + 1), "N" + (a + 1));
                T_M08P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", Q8:Q" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M09D = IV.get_Range("R" + a, "R" + a);
                T_M09D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", R6:R" + (a - 1) + ")";

                COMExcel.Range T_M09P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                T_M09P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", R6:R" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M10D = IV.get_Range("S" + a, "S" + a);
                T_M10D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", S6:S" + (a - 1) + ")";

                COMExcel.Range T_M10P = IV.get_Range("S" + (a + 1), "S" + (a + 1));
                T_M10P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", S6:S" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M11D = IV.get_Range("T" + a, "T" + a);
                T_M11D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", T6:T" + (a - 1) + ")";

                COMExcel.Range T_M11P = IV.get_Range("T" + (a + 1), "T" + (a + 1));
                T_M11P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", T6:T" + (a - 1) + ")";

                //*********************

                COMExcel.Range T_M13D = IV.get_Range("U" + a, "U" + a);
                T_M13D.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + d1 + ", U6:U" + (a - 1) + ")";

                COMExcel.Range T_M13P = IV.get_Range("R" + (a + 1), "R" + (a + 1));
                T_M13P.Value2 = "=SUMIF(B6:B" + (a - 1) + "," + p1 + ", U6:U" + (a - 1) + ")";

                app.Visible = true;

                app.Quit();

                releaseObject(book);
                releaseObject(book);
                releaseObject(app);
            } 
        }
        public void View_TNAME1()
        {
            string Y1 = "";
            if (con.Check_MaskedText(txtMonth_6) == true)
                Y1 = txtMonth_6.Text.Substring(0, 2);

            string SQL = " select T_NAME, Y01D, Y01P, Y01NUM, Y01P_S, Y02D, Y02P, Y02NUM, Y02P_S, M12D, M12P, M01D, M01P, M02D, M02P, M03D, M03P, M04D, M04P, M05D, M05P, M06D, M06P, M07D, M07P, M08D, M08P, M09D, M09P, M10D, M10P, M11D, M11P, M13D, M13P, M13NUM, M13P_S from ORD_BRDN" +
                " WHERE O_YEAR = '" + Y1 + "' and B_NO = '2' ORDER BY M13NUM ASC";

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(SQL);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0.00";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0.00";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0.00";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0.00";

                    //******************

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0.00";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0.00";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0.00";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0.00";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0.00";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0.00";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0.00";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0.00";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0.00";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0.00";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0.00";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0.00";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0.00";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0.00";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0.00";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0.00";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0.00";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0.00";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0.00";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0.00";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0.00";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0.00";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0.00";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0.00";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0.00";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0.00";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0.00";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0.00";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                }
            }
            Export_Excel_TNAME(dt);
        }
        public void View_TNAME2()
        {
            string Y1 = "";
            if (con.Check_MaskedText(txtMonth_6) == true)
                Y1 = txtMonth_6.Text.Substring(0, 2);

            string SQL = " select T_NAME, Y01D, Y01P, Y01NUM, Y01P_S, Y02D, Y02P, Y02NUM, Y02P_S, M12D, M12P, M01D, M01P, M02D, M02P, M03D, M03P, M04D, M04P, M05D, M05P, M06D, M06P, M07D, M07P, M08D, M08P, M09D, M09P, M10D, M10P, M11D, M11P, M13D, M13P, M13NUM, M13P_S from ORD_BRDN" +
                " WHERE O_YEAR = '" + Y1 + "' and B_NO = '1' ORDER BY M13NUM ASC";

            System.Data.DataTable dt = new System.Data.DataTable();
            dt = con.readdata(SQL);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Y01D"].ToString() == string.Empty)
                        dr["Y01D"] = "0.00";

                    if (dr["Y01P"].ToString() == string.Empty)
                        dr["Y01P"] = "0.00";

                    if (dr["Y01NUM"].ToString() == string.Empty)
                        dr["Y01NUM"] = "0.00";

                    if (dr["Y01P_S"].ToString() == string.Empty)
                        dr["Y01P_S"] = "0.00";

                    //******************

                    if (dr["Y02D"].ToString() == string.Empty)
                        dr["Y02D"] = "0.00";

                    if (dr["Y02P"].ToString() == string.Empty)
                        dr["Y02P"] = "0.00";

                    if (dr["Y02P_S"].ToString() == string.Empty)
                        dr["Y02P_S"] = "0.00";

                    if (dr["Y02NUM"].ToString() == string.Empty)
                        dr["Y02NUM"] = "0.00";

                    if (dr["M12D"].ToString() == string.Empty)
                        dr["M12D"] = "0.00";

                    if (dr["M12P"].ToString() == string.Empty)
                        dr["M12P"] = "0.00";

                    if (dr["M01D"].ToString() == string.Empty)
                        dr["M01D"] = "0.00";

                    if (dr["M01P"].ToString() == string.Empty)
                        dr["M01P"] = "0.00";

                    if (dr["M02D"].ToString() == string.Empty)
                        dr["M02D"] = "0.00";

                    if (dr["M02P"].ToString() == string.Empty)
                        dr["M02P"] = "0.00";

                    if (dr["M03D"].ToString() == string.Empty)
                        dr["M03D"] = "0.00";

                    if (dr["M03P"].ToString() == string.Empty)
                        dr["M03P"] = "0.00";

                    if (dr["M04D"].ToString() == string.Empty)
                        dr["M04D"] = "0.00";

                    if (dr["M04P"].ToString() == string.Empty)
                        dr["M04P"] = "0.00";

                    if (dr["M05D"].ToString() == string.Empty)
                        dr["M05D"] = "0.00";

                    if (dr["M05P"].ToString() == string.Empty)
                        dr["M05P"] = "0.00";

                    if (dr["M06D"].ToString() == string.Empty)
                        dr["M06D"] = "0.00";

                    if (dr["M06P"].ToString() == string.Empty)
                        dr["M06P"] = "0.00";

                    if (dr["M07D"].ToString() == string.Empty)
                        dr["M07D"] = "0.00";

                    if (dr["M07P"].ToString() == string.Empty)
                        dr["M07P"] = "0.00";

                    if (dr["M08D"].ToString() == string.Empty)
                        dr["M08D"] = "0.00";

                    if (dr["M08P"].ToString() == string.Empty)
                        dr["M08P"] = "0.00";

                    if (dr["M09D"].ToString() == string.Empty)
                        dr["M09D"] = "0.00";

                    if (dr["M09P"].ToString() == string.Empty)
                        dr["M09P"] = "0.00";

                    if (dr["M10D"].ToString() == string.Empty)
                        dr["M10D"] = "0.00";

                    if (dr["M10P"].ToString() == string.Empty)
                        dr["M10P"] = "0.00";

                    if (dr["M11D"].ToString() == string.Empty)
                        dr["M11D"] = "0.00";

                    if (dr["M11P"].ToString() == string.Empty)
                        dr["M11P"] = "0.00";

                    if (dr["M13D"].ToString() == string.Empty)
                        dr["M13D"] = "0.00";

                    if (dr["M13P"].ToString() == string.Empty)
                        dr["M13P"] = "0.00";

                    if (dr["M13NUM"].ToString() == string.Empty)
                        dr["M13NUM"] = "0.00";

                    if (dr["M13P_S"].ToString() == string.Empty)
                        dr["M13P_S"] = "0.00";

                }
            }
            Export_Excel_TNAME(dt);
        }
        private void txtMonth1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2, txtKD, sender, e);
        }

        private void txtKD_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtMonth1, txtDATE1, sender, e);
        }

        private void txtDATE1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtKD, txtDATE2, sender, e);
        }

        private void txtDATE2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE1, txtMonth1, sender, e);
        }

        private void txtMonth_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2_2, txtP_NO1, sender, e);
        }

        private void txtP_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtMonth_2, txtP_NO2, sender, e);
        }

        private void txtP_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtP_NO1, txtDATE1_2, sender, e);
        }

        private void txtDATE1_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtP_NO2, txtDATE2_2, sender, e);
        }

        private void txtDATE2_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE1_2, txtMonth_2, sender, e);
        }

        private void txtDATE2_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtMonth_3, txtDATE1_3, sender, e);
        }

        private void txtMonth_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2_3, txtKD3, sender, e);
        }

        private void txtKD3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtMonth_3, txtBRAND1, sender, e);
        }

        private void txtBRAND1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtKD3, txtBRAND2, sender, e);
        }

        private void txtBRAND2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND1, txtDATE1_3, sender, e);
        }

        private void txtDATE1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND2, txtDATE2_3, sender, e);
        }

        private void txtMonth_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2_4, txtC_NO1, sender, e);
        }

        private void txtC_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtMonth_4, txtC_NO2, sender, e);
        }

        private void txtC_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO1, txtP_NO1_4, sender, e);
        }

        private void txtP_NO1_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NO2_4, txtP_NO1_4, sender, e);
        }

        private void txtP_NO2_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NO1_4, txtBRAND1_2, sender, e);
        }

        private void txtBRAND1_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NO2_4, txtBRAND2_2, sender, e);
        }

        private void txtBRAND2_2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND1_2, txtDATE1_4, sender, e);
        }

        private void txtDATE1_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND2_2, txtDATE2_4, sender, e);
        }

        private void txtDATE2_4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE1_4, txtMonth_4, sender, e);
        }

        private void txtYear1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtYear2, txtYear2, sender, e);
        }

        private void txtYear2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtYear1, txtYear1, sender, e);
        }

        private void txtMonth_6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2_6, txtKD6, sender, e);
        }

        private void txtKD6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtMonth_6, txtDATE1_6, sender, e);
        }

        private void txtDATE1_6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtKD6, txtDATE2_6, sender, e);
        }

        private void txtDATE2_6_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE1_6, txtMonth_6, sender, e);
        }

        private void txtMonth_7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2_7, txtKHUVUC, sender, e);
        }

        private void txtKHUVUC_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtMonth_7, txtDATE1_7, sender, e);
        }

        private void txtDATE1_7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtKHUVUC, txtDATE2_7, sender, e);
        }

        private void txtDATE2_7_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE1_7, txtMonth_7, sender, e);
        }
    }
}
