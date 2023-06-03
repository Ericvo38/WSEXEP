using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2P : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        DataTable dt1;
        public frm2P()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();

        }
        #region LoadData
        private void loadfirt()
        {
            con.CheckLoad(menuStrip1);

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            txtmaSoPhieu.Enabled = true;
            btndateNow.Text = con.getDateNow();
            btnAction.Visible = false;
            btnClose.Visible = false;
            LoadDataText();
        }
        private void LoadDataText()
        {
            string strload = "SELECT * FROM RRCVH";
            DataTable dt = con.readdata(strload);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtDate.Text = con.formatstr2(dr["WS_DATE"].ToString());
                    txtmaSoPhieu.Text = dr["WS_NO"].ToString();
                    txtmaKH.Text = dr["C_NO"].ToString();
                    txttenKH.Text = dr["C_ANAME"].ToString();
                    txtsoTien.Text = dr["TOTAL"].ToString();
                    lbEditBy.Text = dr["USR_NAME"].ToString();
                }
            }
            LoadDGV();
        }
        //Button Duyet
        private void StaticDuyet()
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                btnAction.Text = "" + txtThem + "";
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                btnAction.Text = "" + txtXoa + "";
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                btnAction.Text = "" + txtSua + "";
            }
        }
        //Button Close
        private void btnCloseLoad()
        {
            checkNofication();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;
            btnAction.Visible = false;
            btnClose.Visible = false;
            btnDuyet.Text = "" + txtDuyet + "";
        }
        // Load DataGridview
        private void LoadDGV()
        {
            string S_SQL = "SELECT NR, OR_NO, P_NAME, P_NAME3, CAL_YM,AMOUNT,OVER0,PRICE , BQTY, CA_NO, CA_NR,OR_NR, OR_KNO, OR_DATE FROM RRCVB WHERE WS_NO = '" + txtmaSoPhieu.Text + "'";
            DataTable dt = con.readdata(S_SQL);
            foreach (DataRow dr in dt.Rows)
            {
                dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
                dr["OR_DATE"] = con.formatstr1(dr["OR_DATE"].ToString());
                dr["AMOUNT"] = String.Format("{0:0.#}", dr["AMOUNT"].ToString());
            }
            DGV1.DataSource = dt;
            DGV1.RowHeadersVisible = false;
            con.DGV(DGV1);
        }
        private void processRecord()
        {
            string str1 = "SELECT WS_DATE, WS_NO, C_NO, C_ANAME, TOTAL,USR_NAME FROM RRCVH";
            dt1 = new DataTable();
            dt1 = con.readdata(str1);
            source = new BindingSource();
            foreach (DataRow row in dt1.Rows)
                source.Add(row);
            ShowRecord();
        }
        //Load Record
        private void ShowRecord()
        {
            DataRow currenRow = (DataRow)source.Current;

            txtDate.Text = currenRow["WS_DATE"].ToString();
            txtmaSoPhieu.Text = currenRow["WS_NO"].ToString();
            txtmaKH.Text = currenRow["C_NO"].ToString();
            txttenKH.Text = currenRow["C_ANAME"].ToString();
            txtsoTien.Text = currenRow["TOTAL"].ToString();
            lbEditBy.Text = currenRow["USR_NAME"].ToString();
        }
        #endregion
        string a = "";
        // Phuong thuc them
        private void addData()
        {
            try
            {
                checkNofication();
                if (con.Check_MaskedText(txtDate) == true)
                {
                    a = txtDate.Text;
                }
                string ngay = con.formatstr2(a);
                string str1 = "INSERT INTO RRCVH VALUES('" + txtmaSoPhieu.Text + "','" + ngay + "','" + txtmaKH.Text + "','','" + txttenKH.Text + "','','" + lbUserName.Text + "',' 0', '0','" + txtsoTien.Text + "','0', 'N', '')";
                if (con.exedata(str1) == true)
                {
                    //string StrQuery;
                    //try
                    //{
                    //   using (SqlCommand comm = new SqlCommand())
                    //   {
                    //   //con.Openconnect();
                    //   //for (int i = 0; i < DGV1.Rows.Count; i++)
                    //   //    {
                    //   //         StrQuery = @"INSERT INTO dbo.RRCVB(WS_NO,NR,WS_DATE,C_NO,RCV_NO,RCV_NR,CA_NO,CA_NR,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,
                    //   //                    BUNIT,BQTY,PRICE,AMOUNT,MEMO,COLOR,COLOR_C,CAL_YM,K_NO,OVER0,OR_NO,OR_NR,OR_DATE,
                    //   //                    OR_KNO,UPDATEKIND,WS_RECNO,GB_NO,GB_NR) VALUES ("
                    //   //                      + txtmaSoPhieu.Text + ", "
                    //   //                      + DGV1.Rows[i].Cells["NR"].Value.ToString() + ", "
                    //   //                      + ngay + ", "
                    //   //                      + txtmaKH.Text + ", "
                    //   //                      + DGV1.Rows[i].Cells["RCV_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["RCV_NR"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["CA_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["CA_NR"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["P_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["P_NAME"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["P_NAME1"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["P_NAME2"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["P_NAME3"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["BUNIT"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["BQTY"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["PRICE"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["AMOUNT"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["MEMO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["COLOR"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["COLOR_C"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["CAL_YM"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["K_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["OVER0"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["OR_NR"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["K_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["OR_DATE"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["OR_KNO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["UPDATEKIND"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["WS_RECNO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["GB_NO"].Value.ToString() + ", "
                    //   //                      + DGV1.Rows[i].Cells["GB_NR"].Value.ToString() + ", ";
                    //   //        comm.CommandText = StrQuery;
                    //   //        comm.ExecuteNonQuery();
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Phuong Thuc Xoa
        private void DeleData()
        {
            try
            {
                checkNofication();
                string str2 = "DELETE  FROM RRCVH WHERE WS_NO = '" + txtmaSoPhieu.Text + "'";
                con.exedata(str2);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        //Phuong thuc Sua
        private void updateData()
        {
            try
            {
                checkNofication();
                if (con.Check_MaskedText(txtDate) == true)
                {
                    a = txtDate.Text;
                }
                string ngay = con.formatstr2(a);
                string str3 = "UPDATE RRCVH SET WS_DATE = '" + ngay + "', C_NO = '" + txtmaKH.Text + "', C_ANAME = '" + txttenKH.Text + "', TOTAL = '" + txtsoTien.Text + "', USR_NAME = N'" + lbUserName.Text + "' WHERE WS_NO = '" + txtmaSoPhieu.Text + "'";
                con.exedata(str3);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        #region Tool 1-> 12
        // F1 Kiem tra
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = true;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            StaticDuyet();
        }
        //F2 Them 
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            StaticDuyet();
            f2ToolStripMenuItem.Enabled = false;
            f1ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btnAction.Visible = true;
            btnClose.Visible = true;
            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            string datenow = con.formatstr2(txtDate.Text);
            txtmaSoPhieu.Text = datenow + "001";
            txtsoTien.Text = "0";
            txtmaKH.Clear();
            txttenKH.Clear();
        }
        // F3 Xoa
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            StaticDuyet();
            btnAction.Visible = true;
            btnClose.Visible = true;
        }
        // F4 Sua
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f5ToolStripMenuItem.Checked = false;
            txtmaSoPhieu.Enabled = false;
            StaticDuyet();
            btnAction.Visible = true;
            btnClose.Visible = true;
        }
        // F5 tim Kiem
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = true;
            StaticDuyet();
            frm2PF5 f5v = new frm2PF5();
            f5v.ShowDialog();
        }
        //F10 Luu
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtText = "";
        string txtDuyet = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtSua = "SỬA";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtText = "Chưa Nhập Mã Khách Hàng";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtText = "Chưa Nhập Mã Khách Hàng";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtSua = "EDIT";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtText = "Customer Code Not Entered";
                txtDuyet = "BROWSER";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtSua = "使固定";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtText = "未輸入客戶代碼";
                txtDuyet = "瀏覽器";
            }
        }
        #endregion
        // get timeNow
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }
        //button close
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCloseLoad();
            loadfirt();
        }

        // Kiem Tra Rang buoc Ma Khach Hang
        private void txttenKH_Click(object sender, EventArgs e)
        {

            if (txtmaKH.Text != "")
            {
                DataTable dt = con.readdata("SELECT C_NO, C_NAME2,C_NAME2_E, C_ANAME2 FROM CUST WHERE C_NO = '" + txtmaKH.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txttenKH.Text = dr["C_ANAME2"].ToString();
                    }
                }
                else
                {
                    checkNofication();
                    MessageBox.Show("" + txtText + "");
                    txtmaKH.Clear();
                    txtmaKH.Focus();
                }
            }
        }

        private void txtmaKH_DoubleClick(object sender, EventArgs e)
        {
            frm2CustSearch fs = new frm2CustSearch();
            fs.ShowDialog();
            loadtxtmaKH();
        }
        private void loadtxtmaKH()
        {
            txtmaKH.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void frm2P_Load(object sender, EventArgs e)
        {
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            getInfo();
            loadfirt();
            StaticDuyet();
            processRecord();
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
            btndateNow.Text = con.getDateNow(); // get DateNow
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                addData();
                loadfirt();
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                DeleData();
                loadfirt();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                updateData();
                loadfirt();

            }

        }
        // Button MoveFirst
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {

            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        // Button MovePrevious 
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        // Button MoveNext 
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        // Button MoveLast
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frmDate = new FromCalender();
            frmDate.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtsoTien, txtmaSoPhieu, sender, e);
        }

        private void txtmaSoPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate, txtmaKH, sender, e);
        }

        private void txtmaKH_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtmaSoPhieu, txttenKH, sender, e);
        }

        private void txttenKH_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtmaKH, txtsoTien, sender, e);
        }

        private void txtsoTien_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txttenKH, txtDate, sender, e);
        }
    }
}