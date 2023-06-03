using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using LibraryCalender;

namespace WTERP
{
    public partial class Form3E : Form
    {
        DataProvider conn = new DataProvider();
        BindingSource source = new BindingSource();
        DataTable table = new DataTable();
        public static string Share_Type = string.Empty;
        int dem = 0;
        string SQL = "";
        string a = "";
        string b = "";
        string c = "";
        public Form3E()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        #region LoadData
        private void Form3E_Load(object sender, EventArgs e)
        {
            Form3EF5.getInfo.SQL = "";
            loadInfo();
            LoadFirst();
            LoaddData();
            ShowRecord();
        }
        void LoadFirst()
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btok.Hide();
            btdong.Hide();
            bt.Text = "" + txtDuyet + "";
            btdau.Enabled = true;
            btketthuc.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            ReadOnly(true);
        }

        private void ReadOnly(bool check)
        {
            tb1.ReadOnly = check;
            tb2.ReadOnly = check;
            tb3.ReadOnly = check;
            tb4.ReadOnly = check;
            tb5.ReadOnly = check;
            tb6.ReadOnly = check;
            tb7.ReadOnly = check;
            tb8.ReadOnly = check;
            tb9.ReadOnly = check;
            tb10.ReadOnly = check;
            tb11.ReadOnly = check;
            tb12.ReadOnly = check;
            tb13.ReadOnly = check;
            tb14.ReadOnly = check;
            tb15.ReadOnly = check;
            tb16.ReadOnly = check;
            tb17.ReadOnly = check;
            tb18.ReadOnly = check;
            tb19.ReadOnly = check;
            tb20.ReadOnly = check;
            tb21.ReadOnly = check;
            tb22.ReadOnly = check;
            tb23.ReadOnly = check;
            tb24.ReadOnly = check;
            FOB_DATE.ReadOnly = check;
        }
        void loadInfo()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER;
            lbUserName.Text = conn.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = conn.getDateNow();
        }
        public void LoaddData()
        {
            SQL = "select TOP 1000 * FROM PRDMK2 WHERE 1=1 "+ Form3EF5.getInfo.SQL + " ORDER BY WS_NO DESC";
            table = conn.readdata(SQL);
            source.DataSource = table;
            ShowRecord();
        }
        private void checkPrint()
        {
            string chk = "SELECT TOP 1 OVER0 FROM PRDMK2 WHERE WS_NO = '" + tb2.Text + "'";
            DataTable dtck = conn.readdata(chk);
            if (dtck.Rows.Count > 0)
            {
                foreach (DataRow dr in dtck.Rows)
                {
                    if (dr["OVER0"].ToString() == "Y")
                    {
                        f7ToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        f7ToolStripMenuItem.Enabled = true;
                    }
                }
            }
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
        public void ShowRecord()
        {
            tb1.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            tb2.Text = currenRow["WS_NO"].ToString();
            tb3.Text = currenRow["OR_NO"].ToString();
            tb4.Text = currenRow["OR_NO1"].ToString();
            tb5.Text = currenRow["C_NO"].ToString();

            tb6.Text = currenRow["C_NAME"].ToString();
            tb7.Text = currenRow["C_OR_NO"].ToString();
            tb8.Text = currenRow["P_NAME"].ToString();
            tb9.Text = currenRow["MEMO01"].ToString();
            tb10.Text = string.Format("{0:#,##0.00}", double.Parse(currenRow["BQTY"].ToString()));

            tb11.Text = currenRow["MEMO02"].ToString();
            tb12.Text = conn.formatstr2(currenRow["FOB_DATE"].ToString());
            tb13.Text = currenRow["MEMO07"].ToString();
            tb14.Text = currenRow["MEMO03"].ToString();
            tb15.Text = currenRow["MEMO05"].ToString();

            tb16.Text = currenRow["MEMO04"].ToString();
            tb17.Text = currenRow["MEMO06"].ToString();
            tb18.Text = currenRow["ORD_WEG"].ToString();
            tb19.Text = currenRow["OVER0"].ToString();
            tb20.Text = currenRow["USR_NAME"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();

            tb21.Text = currenRow["MEMO08"].ToString();
            tb22.Text = currenRow["PG_NO"].ToString();
            tb23.Text = currenRow["P_N"].ToString();
            tb24.Text = currenRow["P_C"].ToString();
            FOB_DATE.Text = conn.formatstr2(currenRow["FOB_DATEC"].ToString());

            GUI.g1 = currenRow["WS_NO"].ToString();
            GUI.g2 = currenRow["WS_NO"].ToString();
            GUI.g3 = string.Format("{0:#,##0}", double.Parse(currenRow["BQTY"].ToString()));

            checkPrint();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
        }

        private void btdau_Click(object sender, EventArgs e) // Button MoveFirst 
        {
            try
            {
                source.MoveFirst();
                ShowRecord();
                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bttruoc_Click(object sender, EventArgs e) // Button MovePrevious 
        {
            try
            {
                source.MovePrevious();
                ShowRecord();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btsau_Click(object sender, EventArgs e) // Button MoveNext 
        {
            try
            {
                source.MoveNext();
                ShowRecord();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btketthuc_Click(object sender, EventArgs e) // Button MoveLast 
        {
            try
            {
                source.MoveLast();
                ShowRecord();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = false;
                btketthuc.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e) // F1 Checking Data 
        {

        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Adding data 
        {
            checkNofication();
            //mo khoa readonly
            ReadOnly2(true, false);
            // khoa function

            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            bt.Text = "" + txtThem + "";
            string UID = frmLogin.ID_USER;
            tb20.Text = conn.getUser(UID); ;
            btok.Show();
            btdong.Show();

            getDataTextBox();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            // getNR();
        }
        private void getDataTextBox()
        {
                tb1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                tb2.Text = "";
                tb3.Text = "";
                tb4.Text = "";
                tb5.Text = "";

                tb6.Text = "";
                tb7.Text = "";
                tb8.Text = "";
                tb9.Text = "";
                tb10.Text = "0";

                tb11.Text = "";
                tb12.Text = "";
                tb13.Text = "";
                tb14.Text = "";
                tb15.Text = "";

                tb16.Text = "";
                tb17.Text = "";
                tb18.Text = "0";
                tb19.Text = "N";

                tb21.Text = "";
                tb22.Text = "NO: TD-QR-01";
                tb23.Text = "";
                tb24.Text = "";
                FOB_DATE.Text = "";
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) // F3 Deleting Data 
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;

            bt.Text = "" + txtXoa + "";
            btok.Show();
            btdong.Show();


            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Repairing Data 
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;

            bt.Text = "" + txtSua + "";
            btok.Show();
            btdong.Show();

            this.tb1.Enabled = true;
            this.tb2.Enabled = false;
            this.tb3.Enabled = true;
            this.tb4.Enabled = true;
            this.tb5.Enabled = true;

            this.tb6.Enabled = true;
            this.tb7.Enabled = true;
            this.tb8.Enabled = true;
            this.tb9.Enabled = true;
            this.tb10.Enabled = true;

            this.tb11.Enabled = true;
            this.tb12.Enabled = true;
            this.tb13.Enabled = true;
            this.tb14.Enabled = true;
            this.tb15.Enabled = true;

            this.tb16.Enabled = true;
            this.tb17.Enabled = true;
            this.tb18.Enabled = true;
            this.tb19.Enabled = true;
            this.tb20.Enabled = true;

            this.tb21.Enabled = true;
            this.tb22.Enabled = true;
            this.tb23.Enabled = true;
            this.tb24.Enabled = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            ReadOnly2(true, false);
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) // F5 Searching Data 
        {
            GUI.getSQL = Form3EF5.getInfo.SQL;
            Form3EF5 form = new Form3EF5();
            form.ShowDialog();
            LoaddData();
            source.Position = Form3EF5.getInfo.index;
            ShowRecord();
            btdau.Enabled = true;
            btketthuc.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e) // F7 Printing Data 
        {
            Form3EF7 fr = new Form3EF7();
            fr.tb1.Text = tb2.Text;
            fr.tb2.Text = tb2.Text;
            fr.ShowDialog();

        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e) // F10 Saving Data 
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = true;
            f12ToolStripMenuItem.Checked = false;

            btok.PerformClick();
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) // F12 Closing App 
        {
            this.Hide();
            this.Close();
        }

        public class GUI
        {
            public static string g1;
            public static string g2;
            public static string g3;
            public static string getSQL;
            public static string getC_NO;

        }
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            check();
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (!string.IsNullOrEmpty(tb3.Text))
                {
                    AddData();
                    LoadFirst();
                    dem++;
                    f2ToolStripMenuItem.PerformClick();
                    tb5.Text = GUI.getC_NO;
                }
                else
                {
                    MessageBox.Show("Vui lòng số đơn hàng trước khi thêm");
                }
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                Delete_PDRMK2();
                LoadFirst();
                LoaddData();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                UPDATE_PDRMK2();
                LoadFirst();
                LoaddData();
                source.Position = source.Find("WS_NO", tb2.Text);
                ShowRecord();
            }
        }
        private void UPDATE_PDRMK2()
        {
            try
            {
                float text = float.Parse(tb10.Text);
                string sql = "UPDATE PRDMK2 SET WS_NO=N'" + tb2.Text + "',WS_DATE=N'" + a + "',C_NO=N'" + tb5.Text + "',C_NAME=N'" + tb6.Text + "',C_ANAME=C_ANAME,ADDR=ADDR,OR_NO=N'" + tb3.Text + "',C_OR_NO=N'" + tb7.Text + "',P_NO=P_NO,P_NAME=N'" + tb8.Text + "',P_NAME1=P_NAME1,P_NAME2='',P_NAME3=''," +
                "FOB_DATE=N'" + b + "',FOB_DATEC=N'" + c + "',BQTY=N'" + text + "',MODEL_C='',MODEL_E='',MEMO01='" + tb9.Text + "',MEMO02=N'" + tb11.Text + "',MEMO03=N'" + tb14.Text + "',MEMO04='" + tb16.Text + "',MEMO05=N'" + tb15.Text + "',MEMO06=N'" + tb17.Text + "',MEMO07=N'" + tb13.Text + "',MEMO08=N'" + tb21.Text + "',USR_NAME=N'" + lbUserName.Text + "'," +
                "OVER0=N'N',PG_NO='" + tb22.Text + "',WS_DATE1=WS_DATE1,K_NO=K_NO,NR=NR,OR_NO1=N'" + tb4.Text + "',ORD_WEG=N'" + tb18.Text + "',WS_ORNO=WS_ORNO,P_N=N'" + tb23.Text + "',P_C=N'" + tb24.Text + "' FROM PRDMK2 WHERE WS_NO =N'" + tb2.Text + "'";
                bool a1 = conn.exedata(sql);
                if (a1 == true)
                {
                    UPDATE_PDRMKA();
                    UPDATE_ORDB();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void UPDATE_PDRMKA()
        {
            float text = float.Parse(tb10.Text);
            string sql = "UPDATE PRDMKA SET C_NO=N'" + tb5.Text + "',C_NAME=N'" + tb6.Text + "',C_ANAME=C_ANAME,B_NAME=N'" + tb15.Text + "',MODEL_C=N'" + tb17.Text + "',THICK=N'" + tb9.Text + "',CLRCARD=N'" + tb24.Text + "',P_NO=P_NO,P_NAME=N'" + tb23.Text + "',P_NAME1=P_NAME1,P_NAME2='',P_NAME3='',BQTY= '" + text + "',OR_NO='" + tb3.Text + "',OR_NR=OR_NR,OR_K_NO=OR_K_NO," +
                "DEPT=DEPT,DEPT_NAME=DEPT_NAME,MEMO=MEMO,WS_DATE=WS_DATE,WS_TIME=WS_TIME,GW=GW,NW=NW,PACK_NO=PACK_NO,QTY=QTY,OVER0=OVER0,USR_NAME=N'" + lbUserName.Text + "',POVER0=POVER0,POVER1=POVER1,SH_NO=SH_NO,FOB_DATE='" + b + "',OLD_NO = '" + tb2.Text + "' FROM PRDMKA WHERE MK_NOA= '" + tb2.Text + "'";
            conn.exedata(sql);
        }

        private void Delete_PDRMKA()
        {
            try
            {
                string sql = "DELETE FROM PRDMKA WHERE MK_NOA = '" + tb2.Text + "'";
                bool a = conn.exedata(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete_PDRMK2()
        {
            try
            {
                string sql = "DELETE FROM PRDMK2 WHERE WS_NO = '" + tb2.Text + "'";
                bool a = conn.exedata(sql);
                if (a == true)
                {
                    Delete_PDRMKA();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddData()
        {
            try
            {
                float test = float.Parse(tb10.Text);
                string sql = "INSERT INTO PRDMK2 (WS_NO,WS_DATE,C_NO,C_NAME,C_ANAME,ADDR,OR_NO,C_OR_NO,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,FOB_DATE,FOB_DATEC,BQTY,MODEL_C,MODEL_E,MEMO01,MEMO02,MEMO03,MEMO04,MEMO05,MEMO06,MEMO07,MEMO08,USR_NAME,OVER0,PG_NO,WS_DATE1,K_NO,NR,OR_NO1,ORD_WEG,WS_ORNO,P_N,P_C) " +
               "SELECT N'" + tb2.Text + "',N'" + a + "',N'" + tb5.Text + "',N'" + tb6.Text + "',(SELECT C_ANAME2 FROM CUST WHERE C_NO = '" + tb5.Text + "'),(SELECT ADR3 FROM CUST WHERE C_NO = '" + tb5.Text + "'),N'" + tb3.Text + "',N'" + tb7.Text + "',ORDB.P_NO,N'" + tb8.Text + "',ORDB.P_NAME_E,N'',N'',N'" + b + "',N'" + c + "',N'" + test + "',N'',N'',N'" + tb9.Text + "',N'" + tb11.Text + "',N'" + tb14.Text + "',N'" + tb16.Text + "'," +
               "N'" + tb15.Text + "',N'" + tb17.Text + "',N'" + tb13.Text + "',N'',N'" + tb20.Text + "',N'" + tb19.Text + "',N'" + tb22.Text + "',ORDB.WS_DATE,ORDB.K_NO,ORDB.NR,N'" + tb4.Text + "',N'" + tb18.Text + "',ORDB.WS_RNO,N'" + tb23.Text + "',N'" + tb24.Text + "' FROM ORDB WHERE C_NO = '" + frm3E_Products.getData3E.getC_NO + "' AND NR = '" + frm3E_Products.getData3E.Get_NR + "' AND WS_DATE = '" + frm3E_Products.getData3E.getDate + "' AND K_NO = '"+ frm3E_Products.getData3E.getK_NO + "'";
                bool a1 = conn.exedata(sql);
                if (a1 == true)
                {
                    ADD_DATA_PRDMKA();
                    UPDATE_ORDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void UPDATE_ORDB()
        {
            string text = "SELECT C_NO,OR_NO,K_NO,WS_DATE1,NR FROM PRDMK2 WHERE WS_NO = '" + tb2.Text + "'";
            DataTable data = new DataTable();
            data = conn.readdata(text);
            string C_NO = "";
            string K_NO = "";
            string WS_DATE1 = "";
            string NR = "";
            foreach (DataRow dt in data.Rows)
            {
                C_NO = dt["C_NO"].ToString();
                K_NO = dt["K_NO"].ToString();
                WS_DATE1 = dt["WS_DATE1"].ToString();
                NR = dt["NR"].ToString();
            }
            string sql = "UPDATE ORDB set WS_DATE1 = N'" + c + "',CLRCARD = N'" + tb14.Text + "' FROM ORDB where C_NO = N'" + C_NO + "' and K_NO = '" + K_NO + "' And WS_DATE = '" + WS_DATE1 + "' And NR = '" + NR + "'";
            conn.exedata(sql);
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            dem = 0;
            checkNofication();
            LoaddData();
            ShowRecord();
            LoadFirst();
        }

        private void tb5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            tb5.Text = frm2CustSearch.ID.ID_CUST;
            tb6.Text = frm2CustSearch.ID.C_ANAME2;
        }
        private void tb9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchLeather2 fr = new FormSearchLeather2();
            fr.ShowDialog();
            tb9.Text = FormSearchLeather2.ID.M_NAME;
        }
        private void tb14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchLeather2 fr = new FormSearchLeather2();
            fr.ShowDialog();
            tb14.Text = FormSearchLeather2.ID.M_NAME;
        }
        private void tb16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchLeather2 fr = new FormSearchLeather2();
            fr.ShowDialog();
            tb16.Text = FormSearchLeather2.ID.M_NAME;
        }
        private void tb13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true))
            {
                frm2QF5 fr = new frm2QF5();
                fr.ShowDialog();
                string DL = frm2QF5.Get_PWT_3E;
                if (DL != string.Empty)
                {
                    tb13.Text = DL;
                }
                else
                    tb3.Text = "";
            }
        }
        private void tb15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchLeather2 fr = new FormSearchLeather2();
            fr.ShowDialog();
            tb15.Text = FormSearchLeather2.ID.M_NAME;
        }
        private void tb17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchLeather2 fr = new FormSearchLeather2();
            fr.ShowDialog();
            tb17.Text = FormSearchLeather2.ID.M_NAME;
        }
        private void tb20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachUSRH fr = new FormSeachUSRH();
            fr.ShowDialog();
            tb20.Text = FormSeachUSRH.DL.USER_NAME;
        }
        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tb1.ReadOnly == false)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                tb1.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }
        }
        private void tb12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tb12.ReadOnly == false)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                tb12.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }
        }
        public static string Get_tb3;
        public static string MaKH;
        string A1 = "";
        string A2 = "";
        string A3 = "";
        string A4 = "";
        string A5 = "";
        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //checkNofication();
                if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                {
                    GUI.getC_NO = tb5.Text;
                    WSEXE.Module3._3E.FrmChoiceTypeE fm1 = new WSEXE.Module3._3E.FrmChoiceTypeE();
                    fm1.ShowDialog();
                    if (!string.IsNullOrEmpty(Share_Type))
                    {
                        frm3E_Products fm = new frm3E_Products();
                        fm.ShowDialog();

                        A1 = frm3E_Products.getData3E.getDate;
                        A2 = frm3E_Products.getData3E.Get_NR;
                        A3 = frm3E_Products.getData3E.getOR_NO;
                        A4 = frm3E_Products.getData3E.getC_NO;
                        A5 = frm3E_Products.getData3E.Get_NR;

                        if (!string.IsNullOrEmpty(A1) && !string.IsNullOrEmpty(A2))
                        {
                            tb2.Text = Share_Type + A1 + '-' + '0' + A2;
                        }
                        else
                        {
                            tb2.Text = "";
                        }
                        if (conn.checkExists("SELECT TOP 1 WS_NO FROM PRDMK2 WHERE WS_NO = '" + tb2.Text + "'") == true)
                        {
                            MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string SQL = "SELECT OR_NO, C_NO, C_NAME_C, COLOR_E,COLOR_C, P_NAME_E, P_NAME_C, THICK, QTY, T_NAME,MODEL_C, MODEL_E, P_NO, P_NAME_E, WS_DATE, K_NO, NR, WS_RNO,MEMO01,PATT_C,PATT_E,ORD_WEG,WS_DATE1 FROM ORDB WHERE OR_NO ='" + A3 + "' and NR = '" + A2 + "' ";
                            DataTable dt = conn.readdata(SQL);
                            foreach (DataRow dr1 in dt.Rows)
                            {
                                tb3.Text = dr1["OR_NO"].ToString();
                                tb5.Text = dr1["C_NO"].ToString();
                                tb6.Text = dr1["C_NAME_C"].ToString();
                                //tb6.Text = dr1["C_NAME_E"].ToString();
                                tb8.Text = dr1["COLOR_C"].ToString() + " " + dr1["COLOR_E"].ToString() + " " + dr1["P_NAME_E"].ToString() + " " + dr1["P_NAME_C"].ToString() + " " + dr1["PATT_E"].ToString() + " " + dr1["PATT_C"].ToString();
                                tb9.Text = dr1["THICK"].ToString();
                                tb10.Text = string.Format("{0:#,##0.00}", double.Parse(dr1["QTY"].ToString()));
                                tb15.Text = dr1["T_NAME"].ToString();
                                tb17.Text = dr1["MODEL_C"].ToString() + " " + dr1["MODEL_E"].ToString();
                                //tb13.Text = dr1["MEMO01"].ToString();
                                tb18.Text = dr1["ORD_WEG"].ToString();
                                FOB_DATE.Text = conn.formatstr2(dr1["WS_DATE1"].ToString());
                                //Tab2
                                tb23.Text = dr1["P_NAME_E"].ToString() + " " + dr1["P_NAME_C"].ToString() + " " + dr1["PATT_C"].ToString();
                                tb24.Text = dr1["COLOR_C"].ToString() + " " + dr1["COLOR_E"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void tb11_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (tb11.Text == "")
                {
                    tb11.Text = "圓";
                }
                else if (tb11.Text == "圓")
                {
                    tb11.Text = "半";
                }
                else if (tb11.Text == "半")
                {
                    tb11.Text = "圓";
                }
            }
        }
        #region tab_Up_Down
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb22, tb2, sender, e);

        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb3, sender, e);

        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb6, sender, e);

        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb5, tb7, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb8, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb7, tb9, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb8, tb10, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb9, tb11, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb10, tb12, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb11, tb13, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb12, tb14, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb14, tb16, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb16, tb18, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb17, FOB_DATE, sender, e);
        }

        private void FOB_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb18, tb19, sender, e);
        }

        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(FOB_DATE, tb20, sender, e);
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb19, tb21, sender, e);
        }

        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb20, tb22, sender, e);
        }

        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb21, tb1, sender, e);
        }
        #endregion
        private void FOB_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FOB_DATE.ReadOnly == false)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                FOB_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }
        }
        public void ADD_DATA_PRDMKA()
        {
            float test = float.Parse(tb10.Text);
            string sql = "INSERT INTO PRDMKA (MK_NOA,C_NO,C_NAME,C_ANAME,B_NAME,MODEL_C,THICK,CLRCARD,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,BQTY,OR_NO,OR_NR,OR_K_NO,DEPT,DEPT_NAME,MEMO,WS_DATE,WS_TIME,GW,NW,PACK_NO,QTY,OVER0,USR_NAME,POVER0,POVER1,SH_NO,FOB_DATE,OLD_NO)" +
                " SELECT '" + tb2.Text + "',N'" + tb5.Text + "',N'" + tb6.Text + "',(SELECT C_ANAME2 FROM CUST WHERE C_NO = N'" + tb5.Text + "'),N'" + tb15.Text + "',N'" + tb17.Text + "',N'" + tb9.Text + "',N'" + tb24.Text + "',ORDB.P_NO,N'" + tb23.Text + "',P_NAME_E,N'',N'',N'" + test + "',N'" + tb3.Text + "'," +
                "ORDB.NR,ORDB.K_NO,N'G001',N'生產部門','G001'+cast(N'" + a + "' AS VARCHAR)+ cast(YEAR('" + a + "') AS VARCHAR),'" + a + "',N'',N'',N'',N'',N'',N'N',N'',N'N',N'N',N'',N'" + b + "',N'" + tb2.Text + "' " +
                " FROM ORDB WHERE OR_NO = '" + frm3E_Products.getData3E.getOR_NO + "' AND NR = '" + frm3E_Products.getData3E.Get_NR + "' AND WS_DATE = '" + frm3E_Products.getData3E.getDate + "' AND K_NO = '"+ frm3E_Products.getData3E.getK_NO+ "'";
            conn.exedata(sql);
        }
        public void check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                a = conn.formatstr2(tb1.Text);
            }
            if (conn.Check_MaskedText(tb12) == true)
            {
                b = conn.formatstr2(tb12.Text);
            }
            if (conn.Check_MaskedText(FOB_DATE) == true)
            {
                c = conn.formatstr2(FOB_DATE.Text);
            }
        }
        private void ReadOnly2(bool check, bool check2)
        {
            tb1.ReadOnly = check2;
            tb2.ReadOnly = check;
            tb3.ReadOnly = check;
            tb4.ReadOnly = check2;
            tb5.ReadOnly = check2;
            tb6.ReadOnly = check;
            tb7.ReadOnly = check2;
            tb8.ReadOnly = check;
            tb9.ReadOnly = check;
            tb10.ReadOnly = check;
            tb11.ReadOnly = check2;
            tb12.ReadOnly = check2;
            tb13.ReadOnly = check2;
            tb14.ReadOnly = check2;
            tb15.ReadOnly = check;
            tb16.ReadOnly = check2;
            tb17.ReadOnly = check;
            tb18.ReadOnly = check2;
            tb19.ReadOnly = check;
            tb20.ReadOnly = check;
            tb21.ReadOnly = check;
            tb22.ReadOnly = check2;
            tb23.ReadOnly = check2;
            tb24.ReadOnly = check2;
            FOB_DATE.ReadOnly = check2;
        }
        private void tb5_TextChanged(object sender, EventArgs e)
        {
            if (tb5.Text != "")
            {
                string SQL1 = "SELECT C_NO, C_ANAME2 FROM CUST WHERE C_NO='" + tb5.Text + "'";
                DataTable dt3 = conn.readdata(SQL1);
                foreach (DataRow currenRow in dt3.Rows)
                {
                    tb6.Text = currenRow["C_ANAME2"].ToString();

                }
            }
        }
    }
}
