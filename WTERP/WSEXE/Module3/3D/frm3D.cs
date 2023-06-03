using LibraryCalender;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3D : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        public static string Share_Type = string.Empty;
        int FuncTions = 0;
        //public SqlConnection conn;
        string SQL = "";
        public frm3D()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        #region Global variable
        public static string Where = string.Empty, Share_WSNO = string.Empty;
        #endregion
        #region Load data
        string a = "";
        string b = "";
        public void check()
        {
            if(txtWS_DATE.MaskCompleted) a = con.formatstr2(txtWS_DATE.Text);
            if(txtFOB_DATE.MaskCompleted) b = con.formatstr2(txtFOB_DATE.Text);
        }
        public static string MaKH;
        private void frm3D_Load(object sender, EventArgs e)
        {
            LoadInfo();
            LoadFirst();
            Process();
            ShowRecord();
        }
        private void LoadFirst()
        {
            con.CheckLoad(menuStrip1);
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            btnDuyet.Text = "" + txtDuyet + "";

            //khóa function
            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            btnOk.Visible = false;
            btnDong.Visible = false;
        }
        private void LoadInfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = con.getDateNow();
            getIP();
        }
        public void getIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }

        public void Process()
        {
            SQL = "SELECT TOP 500 WS_DATE, WS_NO, OR_NO, C_NO, C_ANAME, P_NAME, FOB_DATE, BQTY, MEMO08, MEMO11, MEMO12, MEMO13, CLRCARD, MODEL_C, P_NAME2, " +
            "COLOR_C, MEMO14, MEMO15, MEMO16, PG_NO, M_TOT, USR_NAME, MEMO19 FROM PRDMK1 WHERE 1=1 " + Where + " ORDER BY WS_DATE DESC";
            DataTable dt = con.readdata(SQL);
            source = new BindingSource();
            source.DataSource = dt;
        }
        private void ShowRecord()
        {
            txtWS_DATE.Text = currenRow["WS_DATE"].ToString();
            txtWS_NO.Text = currenRow["WS_NO"].ToString();
            txtOR_NO.Text = currenRow["OR_NO"].ToString();
            txtC_NO.Text = currenRow["C_NO"].ToString();
            txtC_ANAME.Text = currenRow["C_ANAME"].ToString();
            txtP_NAME.Text = currenRow["P_NAME"].ToString();
            txtFOB_DATE.Text = con.formatstr2(currenRow["FOB_DATE"].ToString());
            txtBQTY.Text = string.Format("{0:#,##0.00}", double.Parse(currenRow["BQTY"].ToString()));
            txtMEMO08.Text = currenRow["MEMO08"].ToString();
            txtMEMO11.Text = currenRow["MEMO11"].ToString();
            txtMEMO12.Text = currenRow["MEMO12"].ToString();
            txtMEMO13.Text = currenRow["MEMO13"].ToString();
            txtCLRCARD.Text = currenRow["CLRCARD"].ToString();
            txtMODEL_C.Text = currenRow["MODEL_C"].ToString();
            txtP_NAME2.Text = currenRow["P_NAME2"].ToString();
            txtCOLOR_C.Text = currenRow["COLOR_C"].ToString();
            txtMEMO14.Text = currenRow["MEMO14"].ToString();
            txtMEMO15.Text = currenRow["MEMO15"].ToString();
            txtMEMO16.Text = currenRow["MEMO16"].ToString();
            txtPG_NO.Text = currenRow["PG_NO"].ToString();
            txtM_TOT.Text = currenRow["M_TOT"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
            txtMEMO19.Text = currenRow["MEMO19"].ToString();
            CheckPrint();
        }
        public DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[source].Position;
                if (position > -1)
                {
                    return ((DataRowView)source.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void CheckPrint()
        {
            string SQL = "SELECT OVER0 FROM PRDMK1 WHERE WS_NO = '" + txtWS_NO.Text + "' ";
            if(!string.IsNullOrEmpty(con.ExecuteScalar(SQL)))
            {
                if(con.ExecuteScalar(SQL) == "Y") f7ToolStripMenuItem.Enabled = false;
                else f7ToolStripMenuItem.Enabled = true;
            }
        }
        
        public class getWS_NO
        {
            public static string getSQL;
        }
        public class Get_ID
        {
            public static string Get_PWT;
        }
        #region Method Form Add, Delete, Update
        public void AddData() // Phương Thức Thêm
        {
            try
            {
                check();
                checkNofication();
                string str1 = "INSERT INTO PRDMK1(WS_NO,WS_DATE,C_NO,C_NAME,C_ANAME,ADDR,OR_NO,C_OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,FOB_DATE,CLRCARD,MODEL_C,MODEL_E,MEMO01,MEMO02,MEMO03,MEMO04,MEMO05,MEMO06,MEMO07,MEMO08,MEMO09,MEMO10,MEMO11," +
                    "MEMO12,MEMO13,MEMO14,MEMO15,MEMO16,MEMO17,MEMO18,MEMO19,MEMO20,USR_NAME,OVER0,M_TOT,PG_NO,COLOR_C,COLOR_E,PICS,QTY,UNIT,BQTY,BUNIT,K_NO,NR,WS_DATE1,WS_ORNO,B_NO)" +
                    " SELECT N'" + txtWS_NO.Text + "',N'" + a + "',N'" + txtC_NO.Text + "',(SELECT C_NAME2 FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'),N'" + txtC_ANAME.Text + "',(SELECT ADR3 FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'),N'" + txtOR_NO.Text + "',N'',(SELECT P_NO FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "'),'" + txtP_NAME.Text.Replace("'", "''") + "'," +
                    "(SELECT P_NAME_E +' '+ P_NAME_C FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "'),(SELECT T_NAME FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "'),N'',N'" + b + "',N'" + txtCLRCARD.Text + "'," +
                    "N'" + txtMODEL_C.Text + "',N'',N'',N'',N'',N'',N'',N'',N'',N'" + txtMEMO08.Text + "',N'',N'',N'" + txtMEMO11.Text + "',N'" + txtMEMO12.Text + "','" + txtMEMO13.Text + "',N'" + txtMEMO14.Text.Replace("'", "''") + "',N'" + txtMEMO15.Text.Replace("'", "''") + "',N'" + txtMEMO16.Text + "',N'',N'',N'',N'',N'" + lbUserName.Text.Replace("'", "''") + "',N'N',N'" + txtM_TOT.Text.Replace("'","''")+ "',N'" + txtPG_NO.Text + "'" +
                    ",'" + txtCOLOR_C.Text + "',(SELECT COLOR_E FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "'),0,0,N''," +
                    "ROUND('" + float.Parse(txtBQTY.Text) + "',0),N'',(SELECT K_NO FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "')," +
                    "(SELECT NR FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "')," +
                    "(SELECT WS_DATE FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "')," +
                    "(SELECT WS_RNO FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "'),(SELECT B_NO FROM ORDB WHERE WS_DATE = '" + getDate + "' AND NR = '" + Get_NR + "' AND C_NO = '" + getC_NO + "' AND K_NO = '" + getK_NO + "')" +
                    "";
                bool Result = con.exedata(str1);
                if (Result == true)
                {
                    ADD_DATA_PRDMKA();
                    UPDATE_ORDB_3D();
                    // MessageBox.Show("" + txtLuuTC + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnOk.Visible = true;
                    btnDong.Visible = true;
                }
                //con.CloseTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteData() // Phuong Thuc Xoa  
        {
            try
            {
                checkNofication();
                //xoa PRDMK1
                string str2 = "DELETE FROM PRDMK1 WHERE WS_NO = '" + txtWS_NO.Text + "'";
                bool Result = con.exedata(str2);
                if (Result == true)
                {
                    Delete_PKMAD();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateData() // Update Data  
        {
            try
            {
                check();
                checkNofication();
                string ID_USER = frmLogin.ID_USER;
                string USER_EDIT = con.getUser(ID_USER);
                string Date = a;
                string FOB_DATE = b;
                string str3 = "UPDATE PRDMK1 SET WS_NO='" + txtWS_NO.Text + "',WS_DATE='" + Date + "',C_NO='" + txtC_NO.Text + "',C_NAME = (SELECT C_NAME2 FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'),C_ANAME= '" + txtC_ANAME.Text + "'," +
                    "ADDR = (SELECT ADR3 FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'),OR_NO=N'" + txtOR_NO.Text + "',C_OR_NO=N''," +
                    "P_NO = P_NO,P_NAME = P_NAME,P_NAME1 = P_NAME1,P_NAME2 = P_NAME2,P_NAME3 = P_NAME3,FOB_DATE = '" + FOB_DATE + "',CLRCARD = N'" + txtCLRCARD.Text + "',MODEL_C = '" + txtMODEL_C.Text + "',MODEL_E = MODEL_E," +
                    "MEMO01 = '',MEMO02 = '',MEMO03 = '',MEMO04 = '',MEMO05 = '',MEMO06 = '',MEMO07 = '',MEMO08 = '" + txtMEMO08.Text + "',MEMO09 = '',MEMO10 = '',MEMO11 = '" + txtMEMO11.Text + "'," +
                    "MEMO12 = '" + txtMEMO12.Text + "',MEMO13 = '" + txtMEMO13.Text + "',MEMO14 = '" + txtMEMO14.Text + "',MEMO15 = '" + txtMEMO15.Text + "',MEMO16 = '" + txtMEMO16.Text + "',MEMO17 = '',MEMO18 = '',MEMO19 = '',MEMO20 = '',USR_NAME = '" + USER_EDIT + "'," +
                    "M_TOT = N'" + txtM_TOT.Text + "',PG_NO = '" + txtPG_NO.Text + "',COLOR_C = '" + txtCOLOR_C.Text + "',COLOR_E = COLOR_E,PICS = PICS,QTY = QTY,UNIT = '',BQTY = '" + float.Parse(txtBQTY.Text) + "',BUNIT = '',K_NO = K_NO,NR = NR," +
                    "WS_DATE1 = WS_DATE1,WS_ORNO = WS_ORNO,B_NO = B_NO FROM dbo.PRDMK1 WHERE WS_NO = '" + txtWS_NO.Text + "'";
                bool Result = con.exedata(str3);
                if (Result == true)
                {
                    UPDATE_FOB_DATE();
                    UPDATE_ORDB_3D();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowRecord();
            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowRecord();

            btdau.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            source.MovePrevious();

            ShowRecord();
            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowRecord();
            btdau.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        #endregion

        #region tool 1-> 12
        private void CheckFunction(int Func)
        {
            FuncTions = Func;
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Thêm    
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            CheckFunction(2);

            btnDuyet.ButtonViews(1);
            btnOk.Visible = true;
            btnDong.Visible = true;

            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            ReadOnlineTextBox();
            resetText();
            
            //chuc nang
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }
        private void resetText()
        {
            txtWS_NO.Clear();
            txtOR_NO.Clear();
            txtC_NO.Clear();
            txtC_ANAME.Clear();
            txtP_NAME.Clear();
            txtFOB_DATE.Clear();
            txtBQTY.Clear();
            txtMEMO08.Clear();
            txtMEMO11.Clear();
            txtMEMO12.Clear();
            txtMEMO13.Clear();
            txtCLRCARD.Clear();
            txtMODEL_C.Clear();
            txtP_NAME2.Clear();
            txtCOLOR_C.Clear();
            txtMEMO14.Clear();
            txtMEMO15.Clear();
            txtMEMO16.Clear();
            txtM_TOT.Clear();
            txtMEMO19.Clear();
        }
        private void ReadOnlineTextBox()
        {
            txtWS_DATE.ReadOnly = true;
            txtWS_NO.ReadOnly = true;
            txtOR_NO.ReadOnly = true;
            txtC_NO.ReadOnly = true;
            txtC_ANAME.ReadOnly = true;
            txtP_NAME.ReadOnly = true;
            txtFOB_DATE.ReadOnly = false;
            txtBQTY.ReadOnly = true;
            txtMEMO08.ReadOnly = true;
            txtMEMO19.ReadOnly = false;
            txtMEMO11.ReadOnly = false;
            txtMEMO12.ReadOnly = false;
            txtP_NAME2.ReadOnly = true;
            txtCOLOR_C.ReadOnly = true;
            txtMEMO14.ReadOnly = false;
            txtMEMO15.ReadOnly = false;
            txtMEMO16.ReadOnly = false;
            txtPG_NO.ReadOnly = false;
        }
        private void ReadOnly(bool check)
        {
            txtWS_NO.ReadOnly = check;
            txtOR_NO.ReadOnly = check;
            txtC_NO.ReadOnly = check;
            txtC_ANAME.ReadOnly = check;
            txtP_NAME.ReadOnly = check;
            txtBQTY.ReadOnly = check;
            txtMEMO08.ReadOnly = check;
            txtP_NAME2.ReadOnly = check;
            txtCOLOR_C.ReadOnly = check;
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)  // F3 Xóa   
        {
            checkNofication();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;

            CheckFunction(3);
            btnDuyet.ButtonViews(2);
            btnOk.Visible = true;
            btnDong.Visible = true;

            ReadOnly(true);
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)  // F4 Sửa   
        {
            checkNofication();
            CheckFunction(4);
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;

            txtWS_NO.ReadOnly = true;

            btnDuyet.ButtonViews(3);
            btnOk.Visible = true;
            btnDong.Visible = true;
            ReadOnly(true);
            txtMEMO16.ReadOnly = true;
            //chuc nang
            f2ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) //F5 Tìm Kiếm   
        {
            frm3DF5 fr = new frm3DF5();
            fr.ShowDialog();
            Process();
            source.Position = source.Find("WS_NO", Share_WSNO);
            ShowRecord();
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e) //F7 In
        {
            get_dt();
            frm3DF7 f7 = new frm3DF7();
            f7.ShowDialog();
        }
        public void get_dt()
        {
            send_dt.t1 = txtWS_NO.Text;
            Get_ID.Get_PWT = txtMEMO19.Text;
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e) // F10 Lưu  
        {

        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) // F12 Đóng  
        {
            this.Close();
        }
        #endregion

        #region Change language
        string txtThongBao = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtText = "";
        string txtDuyet = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtSua = "SỬA";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtText = "Đơn hàng này đã tạo, vui lòng chọn mã khác !";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtText = "Đơn hàng này đã tạo, vui lòng chọn mã khác !";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtSua = "EDIT";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtText = "This order has already been created, please choose another code !";
                txtDuyet = "BROWSER";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtSua = "使固定";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtText = "此訂單已創建，請選擇其他代碼！";
                txtDuyet = "瀏覽器";
            }
        }
        #endregion

        private void btnDong_Click(object sender, EventArgs e) // Button Đóng  
        {
            LoadFirst();
            Process();
            ShowRecord();
        }
        private void btnOk_Click(object sender, EventArgs e) // Button Ok  
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                AddData();
                LoadFirst();
                Process();
                source.Position = source.Find("WS_NO", txtWS_NO.Text);
                ShowRecord();
                f2ToolStripMenuItem.PerformClick();
                txtC_NO.Text = C_NO;
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                DeleteData();
                LoadFirst();
                Process();
                ShowRecord();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                UpdateData();
                LoadFirst();
                Process();
                source.Position = source.Find("WS_NO", txtWS_NO.Text);
                ShowRecord();
                txtWS_NO.Enabled = true;
                txtOR_NO.Enabled = true;
                txtP_NAME.Enabled = true;
                txtC_ANAME.Enabled = true;
                txtBQTY.Enabled = true;
                txtP_NAME2.Enabled = true;
                txtCOLOR_C.Enabled = true;
                txtMEMO16.Enabled = true;
            }
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e) //Add Ma Khach Hang, Ten Kh  
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                frm2CustSearch cust = new frm2CustSearch();
                cust.ShowDialog();
                txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
                txtC_ANAME.Text = frm2CustSearch.ID.C_ANAME2;
                MaKH = frm2CustSearch.ID.ID_CUST;
            }
        }
        private void txtMEMO08_MouseDoubleClick(object sender, MouseEventArgs e) //Add thick 
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                frmSearchMemo1.ShowDialog();
                txtMEMO08.Text = FormSearchLeather2.ID.M_NAME;
            }
        }
        private void txtWS_DATE_MouseClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                FromCalender frm = new FromCalender();
                frm.ShowDialog();
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        private void txtFOB_DATE_MouseClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                FromCalender frm = new FromCalender();
                frm.ShowDialog();
                txtFOB_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        private void frm3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Closeconnect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public static string G_CNO;
        public static string C_NO;
        string getDate;
        string Get_NR;
        string getC_NO;
        string getK_NO;
        private void txtOR_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                C_NO = txtC_NO.Text;
                WSEXE.Module3._3D.FrmChoiceType fm1 = new WSEXE.Module3._3D.FrmChoiceType(); 
                fm1.ShowDialog();
                if (!string.IsNullOrEmpty(Share_Type))
                {
                    frm3D_Products fm = new frm3D_Products();
                    fm.ShowDialog();
                    if (string.IsNullOrEmpty(fm.getDate))
                    {
                        getDate = "";
                    }
                    else
                    {
                        getDate = con.formatstr1(fm.getDate);
                    }
                    Get_NR = fm.Get_NR;
                    getC_NO = fm.getC_NO2;
                    getK_NO = fm.getK_NO;
                    string A3 = fm.getOR_NO;
                    txtWS_NO.Text = Share_Type + getDate + "-" + Get_NR;
                    if (con.checkExists("SELECT TOP 1 WS_NO FROM PRDMK1 WHERE WS_NO = '" + txtWS_NO.Text + "'"))
                    {
                        MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        txtOR_NO.Text = A3;
                        AddItem(A3, Get_NR);
                        //khóa function
                        btdau.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;

                    }
                }
            }
        }
        private void AddItem(string OR_NO, string NR)
        {
            try
            {
                string SQL = "SELECT C_NO, ISNULL(C_NAME_C,'')+ ISNULL(C_NAME_E,'') AS C_NAME, P_NAME_E +' '+P_NAME_C + ' '+PATT_E +' '+ PATT_C AS P_NAME, QTY, THICK, MODEL_E+MODEL_C AS MODEL, T_NAME, COLOR_E+COLOR_C AS COLOR, PURCHASER FROM dbo.ORDB WHERE OR_NO='" + OR_NO+"' AND NR ='"+NR+"' ";
                DataTable dt = con.readdata(SQL);
                foreach (DataRow dr in dt.Rows)
                {
                    if (string.IsNullOrEmpty(txtC_NO.Text))
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_ANAME.Text = dr["C_NAME"].ToString();
                    }
                    txtP_NAME.Text = dr["P_NAME"].ToString();
                    txtBQTY.Text = dr["QTY"].ToString();
                    txtMEMO08.Text = dr["THICK"].ToString();
                    txtMODEL_C.Text = dr["MODEL"].ToString();
                    txtP_NAME2.Text = dr["T_NAME"].ToString();
                    txtCOLOR_C.Text = dr["COLOR"].ToString();
                    txtMEMO16.Text = dr["PURCHASER"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class send_dt
        {
            public static string t1;
        }
        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (txtC_NO.Text != "")
                {
                    string SQL1 = "SELECT C_ANAME2 FROM CUST WHERE C_NO='" + txtC_NO.Text + "'";
                    txtC_ANAME.Text = con.ExecuteScalar(SQL1);
                }
            }
            
        }
        private void CheckOR_NO(string OR_NO)
        {
            try
            {
                string SQL = "SELECT OR_NO FROM PRDMK1 WHERE OR_NO ='"+OR_NO+"'";
                if (!string.IsNullOrEmpty(con.ExecuteScalar(SQL)))
                {
                   // MessageBox.Show("", con.MessageBox.Tile(), )
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPG_NO, txtWS_NO, sender, e);
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE, txtOR_NO, sender, e);
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWS_NO, txtC_NO, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtOR_NO, txtC_ANAME, sender, e);
        }

        private void txtC_ANAME_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NO, txtP_NAME, sender, e);
        }

        private void txtP_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_ANAME, txtFOB_DATE, sender, e);
        }

        private void txtFOB_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME, txtBQTY, sender, e);
        }

        private void txtBQTY_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtFOB_DATE, txtMEMO08, sender, e);
        }

        private void txtMEMO08_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtBQTY, txtMEMO11, sender, e);
        }

        private void txtMEMO11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO08, txtMEMO12, sender, e);
        }

        private void txtMEMO12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO11, txtMEMO13, sender, e);
        }

        private void txtMEMO13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO12, txtCLRCARD, sender, e);
        }

        private void txtCLRCARD_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO13, txtMODEL_C, sender, e);
        }

        private void txtMODEL_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCLRCARD, txtP_NAME2, sender, e);
        }

        private void txtP_NAME2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMODEL_C, txtCOLOR_C, sender, e);
        }

        private void txtCOLOR_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME2, txtMEMO14, sender, e);
        }

        private void txtMEMO14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCOLOR_C, txtMEMO15, sender, e);
        }

        private void txtMEMO15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO14, txtMEMO16, sender, e);
        }

        private void txtMEMO16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO15, txtPG_NO, sender, e);
        }

        private void txtPG_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtMEMO16, txtWS_DATE, sender, e);
        }

        private void txtMEMO11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                frmSearchMemo1.ShowDialog();
                string DL = FormSearchLeather2.ID.M_NAME;

                if (DL != string.Empty)
                {
                    txtMEMO11.Text = DL;
                }
                else
                    txtMEMO11.Text = "";
            }
        }
        public void ADD_DATA_PRDMKA()
        {
            string st2 = "INSERT INTO PRDMKA(MK_NOA,C_NO,C_NAME,C_ANAME,B_NAME,MODEL_C,THICK,CLRCARD,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,BQTY,OR_NO,OR_NR,OR_K_NO,DEPT,DEPT_NAME,MEMO,WS_DATE,WS_TIME,GW,NW,PACK_NO,QTY,OVER0,USR_NAME,POVER0,POVER1,SH_NO,FOB_DATE,B_NO,OLD_NO)" +
               " SELECT a.WS_NO,a.C_NO,a.C_NAME,a.C_ANAME,a.P_NAME2,a.MODEL_C,a.MEMO08,a.COLOR_C,a.P_NO,a.P_NAME,a.P_NAME1,a.P_NAME2,a.P_NAME3,a.BQTY,a.OR_NO,a.NR,a.K_NO,'G001','生管部門','G001'+a.WS_DATE+CAST(YEAR(GETDATE()) AS NVARCHAR(4)),a.WS_DATE,N'',0,0,N'',0,N'N',N'" + lbUserName.Text + "',N'N',N'N',N'',a.FOB_DATE,a.B_NO,a.WS_NO" +
               " FROM dbo.PRDMK1 AS a WHERE a.WS_NO = '" + txtWS_NO.Text + "' AND a.OR_NO = '" + txtOR_NO.Text + "' and a.NR = '" + Get_NR + "'";
            bool check = con.exedata(st2);
        }
        public void UPDATE_FOB_DATE()
        {
            string st1 = "UPDATE PRDMKA SET C_NO= b.C_NO,C_NAME = b.C_NAME,C_ANAME = b.C_ANAME,B_NAME = b.P_NAME2,MODEL_C = b.MODEL_C,THICK = b.MEMO08,CLRCARD = b.CLRCARD,P_NO = b.P_NO,P_NAME = b.P_NAME,P_NAME1 = b.P_NAME1,P_NAME2 = b.P_NAME2,P_NAME3 = b.P_NAME3,BQTY = b.BQTY," +
                " OR_NO = b.OR_NO,OR_NR = b.NR,OR_K_NO = b.K_NO,DEPT = 'G001',DEPT_NAME = '生管部門',MEMO = MEMO,WS_DATE = REPLACE(CAST(GETDATE() AS DATE), '-', ''),WS_TIME = N'',GW = 0,NW = 0,PACK_NO = N'',QTY = 0,OVER0 = N'N',USR_NAME = N''," +
                " POVER0 = N'N',POVER1 = N'N',SH_NO = N'',FOB_DATE = b.FOB_DATE,B_NO = b.B_NO,OLD_NO = b.WS_NO FROM PRDMKA AS a " +
                "INNER JOIN dbo.PRDMK1 AS b ON WS_NO = MK_NOA " +
                "WHERE MK_NOA = '" + txtWS_NO.Text + "'";
            bool check = con.exedata(st1);
        }
        private void txtMEMO19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                frm2QF5 fr = new frm2QF5();
                fr.ShowDialog();
                string DL = frm2QF5.Get_PWT_3D;
                if (DL != string.Empty)
                {
                    txtMEMO19.Text = DL;
                }
                else
                    txtMEMO19.Text = "";
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void UPDATE_ORDB_3D()
        {
            check();
            string text = "SELECT C_NO,OR_NO,K_NO,WS_DATE1,NR FROM PRDMK1 WHERE WS_NO = '" + txtWS_NO.Text + "'";
            DataTable data = new DataTable();
            data = con.readdata(text);
            string C_NO = "";
            string OR_NO = "";
            string K_NO = "";
            string WS_DATE1 = "";
            string NR = "";
            foreach (DataRow dt in data.Rows)
            {
                C_NO = dt["C_NO"].ToString();
                OR_NO = dt["OR_NO"].ToString();
                K_NO = dt["K_NO"].ToString();
                WS_DATE1 = dt["WS_DATE1"].ToString();
                NR = dt["NR"].ToString();
            }
            string sql = "UPDATE ORDB SET WS_DATE1= '" + b + "',CLRCARD='" + txtCLRCARD.Text + "' FROM ORDB WHERE C_NO = '" + C_NO + "' AND OR_NO = '" + OR_NO + "' AND K_NO = '" + K_NO + "' AND WS_DATE = '" + WS_DATE1 + "' AND NR = '" + NR + "'";
            bool check1 = con.exedata(sql);
        }
        private void Delete_PKMAD()
        {
            check();
            string sql = "DELETE PRDMKA WHERE MK_NOA='" + txtWS_NO.Text + "'";
            bool check1 = con.exedata(sql);
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
