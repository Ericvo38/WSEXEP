using LibraryCalender;
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

namespace WTERP
{
    public partial class frm2M : Form
    {
        DataProvider con = new DataProvider(); // Ket noi SQL
        BindingSource source;
        public frm2M()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        #region Loaddata
        private void frm2M_Load(object sender, EventArgs e) //Method Form Loading  
        {
            frm2MF5.getID_C.Wheres = "";
            loadfirst();
            getInfo();
            MoveProcess();
        }
        public void MoveProcess() // Process Button Move 
        {
            string stsql = "SELECT TOP 100 WS_DATE, WS_NO, C_NO, C_ANAME, W1_CHECK, CAL_YM, USR_NAME FROM RCVH where 1=1 " + frm2MF5.getID_C.Wheres + " ORDER BY WS_NO DESC";
            DataTable dt = con.readdata(stsql);
            source = new BindingSource();
            foreach (DataRow row in dt.Rows)
            {
                source.Add(row);
            }
            if (!string.IsNullOrEmpty(frm2MF5.getID_C.Index))
            {
                source.Position = int.Parse(frm2MF5.getID_C.Index);
            }
            ShowRecord();
        }

        public void ShowRecord()
        {
            DataRow currenRow = (DataRow)source.Current;
            txtWS_DATE.Text = con.formatstr2(currenRow["WS_DATE"].ToString());
            txtWS_NO.Text = currenRow["WS_NO"].ToString();
            txtC_NO.Text = currenRow["C_NO"].ToString();
            txtC_ANAME.Text = currenRow["C_ANAME"].ToString();
            txtW1_CHECK.Text = currenRow["W1_CHECK"].ToString();
            txtCAL_YM.Text = con.formatstr2(currenRow["CAL_YM"].ToString());
            lbEditBy.Text = con.formatstr2(currenRow["USR_NAME"].ToString());
        }

        private void loadfirst() //Load First 
        {
            con.CheckLoad(menuStrip1);
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnDuyet.Text = "" + txtDuyet + "";
            gB1.Hide();
            btnAction.Visible = false;
            btnDong.Visible = false;

            con.DGV(DGV1);

            txtWS_DATE.ReadOnly = true;
            txtWS_NO.ReadOnly = true;
            txtC_NO.ReadOnly = true;
            txtC_ANAME.ReadOnly = true;
            txtW1_CHECK.ReadOnly = true;
            txtCAL_YM.ReadOnly = true;
        }
        #endregion
        #region Function
        private void adding() //Add Data 
        {
            try
            {
                checkNofication();
                string WS_DATE = con.formatstr2(txtWS_DATE.Text);
                string WS_NO = txtWS_NO.Text;
                string C_NO = txtC_NO.Text;
                string C_ANAME = txtC_ANAME.Text;
                string W1_CHECK = txtW1_CHECK.Text;
                string CAL_YM = con.formatstr2(txtCAL_YM.Text);

                string str2 = "INSERT INTO RCVH (WS_NO,WS_DATE,C_NO,CAL_YM,C_ANAME,C_NAME,USR_NAME,CASH,W_CHECK,TOTAL,TELCASH,W1_CHECK) " +
                    "VALUES ('" + WS_NO + "', '" + WS_DATE + "', '" + C_NO + "', '" + CAL_YM + "', '" + C_ANAME + "',N'',N'" + lbUserName.Text + "',0,0,0,0,'" + W1_CHECK + "' )";
                bool a = con.exedata(str2);
                if (a == false)
                {
                    MessageBox.Show("Mã phiếu thu đã tồn tại!!");
                }    
                else
                {
                    insertDGV();
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertDGV()
        {
            //int checkinsert = 0;
            //if(f2ToolStripMenuItem.Checked == true)
            //{
            //    checkinsert = 1;
            //}
            string WS_NO = txtWS_NO.Text;
            string C_NO = txtC_NO.Text;
            int NR = 1;
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                string CAL_YM = con.formatstr2(DGV1.Rows[i].Cells["CAL_YM"].Value.ToString());
                // insert RCVB và update CARB,GIBB,ORDB
                string str1 = "dbo.proc_2M_Insert_Update @WS_NO = N'" + WS_NO + "',@NR = N'0" + NR.ToString("D" + 3) + "',@WS_DATE = '" + con.formatstr2(DGV1.Rows[i].Cells["WS_DATE"].Value.ToString()) +
                    "',@C_NO = N'" + C_NO + "',@OR_NO = N'" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "',@OR_NR = N'" + DGV1.Rows[i].Cells["OR_NR"].Value.ToString() + "',@P_NO = N''," +
                    "@P_NAME = N'" + DGV1.Rows[i].Cells["P_NAME"].Value.ToString() + "',@P_NAME1 = N'',@P_NAME2 = N'',@P_NAME3 = N'" + DGV1.Rows[i].Cells["P_NAME3"].Value.ToString() + "',@UNIT = N'',@BUNIT = N''," +
                    "@QTY = 0.0,@TRANS = 0.0,@CUNIT = N'',@BQTY = " + DGV1.Rows[i].Cells["BQTY"].Value.ToString() + ",@PRICE = " + DGV1.Rows[i].Cells["PRICE"].Value.ToString() + ", @AMOUNT = " + DGV1.Rows[i].Cells["AMOUNT"].Value.ToString() + "," +
                    "@COST = 0.0,@MEMO = N'',@SH_NO = N'',@FOB_DATE = '',@C_OR_NO = N'" + DGV1.Rows[i].Cells["WS_NO"].Value.ToString() + "',@COLOR = N''," +
                    "@COLOR_C = N'',@CAL_YM = N'" + CAL_YM + "',@K_NO = N'" + DGV1.Rows[i].Cells["K_NO"].Value.ToString() + "',@OVER0 = N'" + DGV1.Rows[i].Cells["OVER0"].Value.ToString() + "',@ORD_DATE = ''," +
                    "@POVER = N'" + DGV1.Rows[i].Cells["POVER"].Value.ToString() + "',@GB_NO = N'',@GB_NR = N''";
                con.exedata(str1);
                NR++;
            }
        }
        private void deleteData() //Delete Data 
        {
            checkNofication();
            string WS_NO = txtWS_NO.Text;
            try
            {
                bool xoa = con.exedata("DELETE FROM RCVH WHERE WS_NO = '" + WS_NO + "' ");
                if (xoa == true)
                {
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (con.exedata("DELETE FROM RCVB WHERE WS_NO = '" + WS_NO + "' and NR = '" + DGV1.Rows[i].Cells["NR"].Value.ToString() + "'") == true)
                        {
                            string xoa1 = "";
                            if (int.Parse(DGV1.Rows[i].Cells["K_NO"].Value.ToString()) == 1)
                            {
                                xoa1 = "UPDATE CARB SET CAL_YM=N'" + con.formatstr2(txtCAL_YM.Text) + "',OVER0=N'N' WHERE WS_NO=N'" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "' AND NR=N'" + DGV1.Rows[i].Cells["OR_NR"].Value.ToString() + "'";
                            }
                            else
                            {
                                xoa1 = "UPDATE GIBB SET CAL_YM=N'" + con.formatstr2(txtCAL_YM.Text) + "',OVER0=N'N' WHERE WS_NO=N'" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "' AND NR=N'" + DGV1.Rows[i].Cells["OR_NR"].Value.ToString() + "'";
                            }
                            con.exedata(xoa1);
                        }
                    }

                    loadfirst();
                    MoveProcess();
                    con.Closeconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateData() //Update Data 
        {
            checkNofication();
            string WS_NO = txtWS_NO.Text;
            string WS_DATE = con.formatstr2(txtWS_DATE.Text);
            string C_NO = txtC_NO.Text;
            string W1_CHECK = txtW1_CHECK.Text;
            string CAL_YM = con.formatstr2(txtCAL_YM.Text);
            string C_ANAME = txtC_ANAME.Text;
            string str2 = "UPDATE RCVH SET WS_NO='" + WS_NO + "', WS_DATE ='" + WS_DATE + "',C_NO='" + C_NO + "',CAL_YM='" + CAL_YM + "',C_ANAME='" + C_ANAME +
                "',C_NAME=N'',USR_NAME='" + lbUserName.Text + "',CASH =0,W_CHECK=0,TOTAL=0,TELCASH=0,W1_CHECK='" + W1_CHECK + "' WHERE WS_NO = '" + WS_NO + "'";

            if (con.exedata(str2) == true)
            {
                if (con.exedata("DELETE FROM RCVB WHERE WS_NO = '" + WS_NO + "' ") == true)
                {
                    insertDGV();
                }
            }
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        //string txtLuuTC = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtXoa = "";
        string txtSua = "";
        string txtText = "";
        string txtCheck = "";
        string txtText12 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                //txtLuuTC = "Lưu Thành Công";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtText = "Bạn có Muốn Thoát chương Trình Không ?";
                txtText12 = "Mã Phiếu đã tồn tại";
                txtCheck = "Tháng khách hàng đã tồn tại, vui lòng nhập lại!";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                // txtLuuTC = "Lưu Thành Công";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtText = "Bạn có Muốn Thoát chương Trình Không ?";
                txtCheck = "Tháng khách hàng đã tồn tại, vui lòng nhập lại!";
                txtText12 = "Mã Phiếu đã tồn tại";

            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                // txtLuuTC = "Save successfully";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtSua = "EDIT";
                txtText = "Do You Want To Exit The Program?";
                txtCheck = "Customer month already exists, please re-enter!";
                txtText12 = "Coupon Code already exists";

            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                //  txtLuuTC = "保存成功";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtSua = "使固定";
                txtText = "您想退出程序嗎？";
                txtCheck = "客戶月份已存在,請重新輸入!";
                txtText12 = "优惠券代码已存在";
            }
        }
        #endregion
        private void Datenow_Tick(object sender, EventArgs e) // Show TimeNow 
        {
            btnTimeNow.Text = con.getTimeNow();
            //loadID();
        }
        #region Tool 1-> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) //F2 Adding Data 
        {
            checkNofication();
            txtWS_DATE.Text = "";
            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //txtWS_NO.Text = con.formatstr2(DateTime.Now.ToString("yyyy/MM/dd")) + "001";
            gB1.Show();
            btnAction.Visible = true;
            btnDong.Visible = true;
            rdngay.Checked = true;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            txtC_NO.Clear();
            txtC_ANAME.Clear();
            txtW1_CHECK.Clear();
            txtCAL_YM.Clear();
            txtW1_CHECK.Text = "N";
            txtW1_CHECK.ReadOnly = true;
            btnDuyet.Text = "" + txtThem + "";
            txtWS_DATE.ReadOnly = false;
            txtWS_NO.ReadOnly = false;
            txtC_NO.ReadOnly = false;
            txtC_ANAME.ReadOnly = false;
            txtCAL_YM.ReadOnly = false;

            //khoa check
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) //F3 Delete Data 
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;

            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnAction.Visible = true;
            btnDong.Visible = true;
            btnDuyet.Text = "" + txtXoa + "";

            //khoa check
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) //F4 Repair Data 
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;

            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            btnAction.Visible = true;
            btnDong.Visible = true;
            btnDuyet.Text = "" + txtSua + "";

            txtWS_DATE.ReadOnly = true;
            txtWS_NO.ReadOnly = true;
            txtC_NO.ReadOnly = true;
            txtC_ANAME.ReadOnly = true;
            txtW1_CHECK.ReadOnly = true;
            txtCAL_YM.ReadOnly = true;

            //khoa check
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) //F5 Searching Data 
        {
            f5ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            frm2MF5 fr5f = new frm2MF5();
            fr5f.ShowDialog();
            MoveProcess();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e) //F6 Maintenancing System 
        {
            f6ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;

            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e) //F9 Checking Data 
        {
            f9ToolStripMenuItem.Checked = true;
            if (f2ToolStripMenuItem.Checked == true && f9ToolStripMenuItem.Checked == true)
            {
                f2ToolStripMenuItem.Checked = true;
                f9ToolStripMenuItem.Checked = false;
            }
            else if (f4ToolStripMenuItem.Checked == true && f9ToolStripMenuItem.Checked == true)
            {
                f4ToolStripMenuItem.Checked = true;
                f9ToolStripMenuItem.Checked = false;
            }
            else
            {
                f9ToolStripMenuItem.Checked = true;
                f2ToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f3ToolStripMenuItem.Checked = false;
                f5ToolStripMenuItem.Checked = false;
            }
            f12ToolStripMenuItem.Checked = false;
            btnAction.Show();
            btnDong.Show();
            btnDuyet.Text = "CHECK";
            txtW1_CHECK.Text = "Y";

            //khoa check
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e) //F10 Saving Data 
        {
            f10ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) //F12 Close Aplication 
        {
            checkNofication();
            DialogResult result = MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                this.Close();
        }

        #endregion
        private void btnAction_Click(object sender, EventArgs e)//Button Action 
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                adding();
                LoadDGV();
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                deleteData();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                updateData();
            }
            else if (f9ToolStripMenuItem.Checked == true)
            {
                string sql = "UPDATE RCVH SET USR_NAME= N'" + lbUserName.Text + "',W1_CHECK=N'Y' WHERE WS_NO=N'" + txtWS_NO.Text + "'";
                con.exedata(sql);
            }
            loadfirst();

        }
        private void btnDong_Click(object sender, EventArgs e) // Button Close 
        {
            loadfirst();
            LoadDGV();
            ShowRecord();
        }
        public void loadID() // Method ID Loading 
        {
            if (f5ToolStripMenuItem.Checked == true)
            {
                if (string.IsNullOrEmpty(frm2MF5.getID_C.ID))
                {
                    txtWS_NO.Text = frm2MF5.getID_C.ID;
                }
            }
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

        private void loadtxtmaKH()
        {
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void txtmaKH_DoubleClick(object sender, EventArgs e) // Loading Method get ID Customer 
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fs = new frm2CustSearch();
                fs.ShowDialog();
                if (f4ToolStripMenuItem.Checked == true)
                {
                    string sqlcheck = "SELECT WS_NO FROM RCVH WHERE C_NO ='" + frm2CustSearch.ID.ID_CUST + "' AND WS_NO='" + txtWS_NO.Text + "'";
                    DataTable dtCheck = con.readdata(sqlcheck);
                    if (dtCheck.Rows.Count > 0)
                    {
                        MessageBox.Show("" + txtCheck + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        loadtxtmaKH();
                    }
                }
                else
                {
                    loadtxtmaKH();
                }
            }
        }
        private void btnMoveFirst_Click(object sender, EventArgs e) // Button MoveFirst 
        {
            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)// Button MovePrevious 
        {
            source.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click(object sender, EventArgs e) // Button MoveNext 
        {
            source.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click(object sender, EventArgs e) // button MoveLast 
        {
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e) // Load DataGridview 
        {
            LoadDGV();
        }
        public void LoadDGV()
        {
            string sqldtgv = "SELECT K_NO,WS_DATE,OR_NO,P_NAME,CAL_YM,P_NAME3,BQTY,PRICE,OVER0,AMOUNT,GB_NO,POVER,C_NO,NR,C_OR_NO as WS_NO,OR_NR FROM RCVB WHERE WS_NO = '" + txtWS_NO.Text + "'";
            DataTable dtgv = con.readdata(sqldtgv);
            if (dtgv != null)
            {
                foreach (DataRow dr in dtgv.Rows)
                {
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                    dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
                }
                DGV1.DataSource = dtgv;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void txtCAL_YM_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string sqlcheck = "SELECT WS_NO FROM RCVH WHERE C_NO ='" + txtC_NO.Text + "' AND CAL_YM='" + con.formatstr2(txtCAL_YM.Text) + "'";
                DataTable dtCheck = con.readdata(sqlcheck);
                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("" + txtCheck + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    string sql = "SELECT * FROM (" +
                                "SELECT 1 as K_NO,CARB.WS_DATE,CARB.OR_NO AS WS_NO,COLOR_C  +' '+ COLOR + P_NAME1 AS P_NAME, LEFT(CARB.CAL_YM, 4)+'/' + RIGHT(CARB.CAL_YM, 2) AS CAL_YM," +
                                " P_NAME3, BQTY, PRICE, CARH.OVER0,AMOUNT,GB_NO,'N' AS POVER, CARB.C_NO,'' as NR,CARB.WS_NO as OR_NO,NR AS OR_NR " +
                                " FROM CARB,CARH" +
                                " WHERE CARB.WS_NO = CARH.WS_NO  AND CARB.CAL_YM = '" + con.formatstr2(txtCAL_YM.Text) + "' AND CARH.OR_NO NOT LIKE '%作廢%' AND CARB.C_NO = '" + txtC_NO.Text + "'" +
                                " UNION ALL" +
                                " SELECT 2 as K_NO,GIBB.WS_DATE,GIBB.OR_NO AS WS_NO,ISNULL(COLOR,'') + P_NAME1 AS P_NAME, LEFT(GIBB.CAL_YM, 4)+'/' + RIGHT(GIBB.CAL_YM, 2) AS CAL_YM," +
                                " P_NAME3, (-1*BQTY) AS BQTY, PRICE,'Y' AS OVER0,(-1 * AMOUNT) AS AMOUNT,'' AS GB_NO,'N' AS POVER, GIBB.C_NO,'' as NR,GIBB.WS_NO as OR_NO,NR AS OR_NR  FROM GIBB,GIBH" +
                                " WHERE GIBB.WS_NO = GIBH.WS_NO  AND GIBH.OR_NO NOT LIKE '%作廢%' AND GIBB.C_NO = '" + txtC_NO.Text + "' AND GIBB.CAL_YM = '" + con.formatstr2(txtCAL_YM.Text) + "')a ORDER BY a.K_NO ASC,a.WS_DATE ASC";
                    DataTable dt = con.readdata(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                    }
                    DGV1.DataSource = dt;
                }
            }
        }

        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FromCalender frm = new FromCalender();
                frm.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f3ToolStripMenuItem.Checked == true)
                {
                    btnDong.PerformClick();
                }
            }
            else if (keyData == Keys.F2)
            {
                f2ToolStripMenuItem.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1)
                {
                    FromCalender fm = new FromCalender();
                    fm.ShowDialog();
                   this.DGV1[1,DGV1.CurrentRow.Index].Value = FromCalender.getDate.ToString("yyyy/MM/dd");
                    //frmDateTime frm = new frmDateTime();
                    //frm.ShowDialog();
                    //this.DGV1[1, DGV1.CurrentRow.Index].Value = frmDateTime.Date.ToString("yyyy/MM/dd"); ;
                }
                if (Cur == 4)
                {
                    // nếu tháng thanh toán = tháng thanh toán trong dgv = Y : N
                    FromCalender fm = new FromCalender();
                    fm.ShowDialog();
                    this.DGV1[4, DGV1.CurrentRow.Index].Value = FromCalender.getDate.ToString("yyyy/MM"); ;
                    if (FromCalender.getDate.ToString("yyyy/MM") == txtCAL_YM.Text)
                    {
                        this.DGV1[8, DGV1.CurrentRow.Index].Value = "Y";
                    }
                    else
                    {
                        this.DGV1[8, DGV1.CurrentRow.Index].Value = "N";
                    }
                }
                if (Cur == 8)
                {
                    if (this.DGV1[8, DGV1.CurrentRow.Index].Value.ToString() == "N")
                    {
                        this.DGV1[8, DGV1.CurrentRow.Index].Value = "Y";
                    }
                    else
                    {
                        this.DGV1[8, DGV1.CurrentRow.Index].Value = "N";
                    }

                }
                if (Cur == 11)
                {
                    if (this.DGV1[11, DGV1.CurrentRow.Index].Value.ToString() == "N")
                    {
                        this.DGV1[11, DGV1.CurrentRow.Index].Value = "Y";
                    }
                    else
                    {
                        this.DGV1[11, DGV1.CurrentRow.Index].Value = "N";
                    }

                }
            }
        }



        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true)
            {
                con.CreateMenuStrip(e, DGV1, false);
            }
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                con.MouseButtonsRightSelectDGV(e, DGV1);
            }
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtCAL_YM, txtWS_NO, sender, e);
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE, txtC_NO, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtWS_NO, txtC_ANAME, sender, e);
        }

        private void txtC_ANAME_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO, txtCAL_YM, sender, e);
        }

        private void txtCAL_YM_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_ANAME, txtWS_DATE, sender, e);
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                if (txtC_NO.Text != "")
                {
                    DataTable dt = null;
                    dt = con.readdata("SELECT TOP 1 C_NO, C_NAME2,C_NAME2_E,CASE WHEN LEN(C_ANAME2) >= 8 THEN SUBSTRING(C_ANAME2,1,8) ELSE  C_ANAME2 END C_ANAME2 FROM CUST WHERE C_NO = '" + txtC_NO.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            txtC_ANAME.Text = item["C_ANAME2"].ToString();
                        }
                    }
                    else
                    {
                        txtC_ANAME.Clear();
                        txtC_NO.Focus();
                    }
                }
            }

        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fr = new FromCalender();
                fr.ShowDialog();
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
                if (txtWS_DATE.MaskFull == true)
                {
                    Int64 d = 0;
                    string sql = "SELECT CASE WHEN MAX(WS_NO) IS NULL THEN '0' ELSE MAX(WS_NO) end as WS_NO FROM RCVH WHERE WS_NO LIKE '" + con.formatstr2(txtWS_DATE.Text) + "%'";
                    DataTable dt = new DataTable();
                    dt = con.readdata(sql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["WS_NO"].ToString() == "0")
                            {
                                txtWS_NO.Text = con.formatstr2(txtWS_DATE.Text) + "001";
                            }
                            else
                            {
                                d = Int64.Parse(item["WS_NO"].ToString());
                                d++;
                                txtWS_NO.Text = d.ToString();
                            }
                        }
                    }
                    else
                    {
                        txtWS_NO.Text = con.formatstr2(txtWS_DATE.Text) + "001";
                    }
                }
        }

        private void txtCAL_YM_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtWS_NO_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string str = "SELECT * FROM RCVH Where WS_NO ='" + txtWS_NO.Text + "'";
                DataTable dt = con.readdata(str);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("" + txtText12 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
    }
}
