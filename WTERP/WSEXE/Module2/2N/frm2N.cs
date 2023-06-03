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
    public partial class frm2N : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        public frm2N()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
            LoadFirst();
        }
        #region Load Data
        private void getID()
        {
            

            if (f5ToolStripMenuItem.Checked == true)
            {
                string getWS_NO = frm2NF5.getID.ID;
                string str2 = "SELECT TOP 1 WS_DATE, WS_NO, S_NO, S_NAME, C_NO_S, C_NO_E FROM STOHC WHERE WS_NO = '" + getWS_NO + "'";
                DataTable dt2 = con.readdata(str2);
                foreach (DataRow dr in dt2.Rows)
                {
                    txtngayTT.Text = con.formatstr2(dr["WS_DATE"].ToString());
                    txtST.Text = dr["WS_NO"].ToString();
                    txtNS1.Text = dr["S_NO"].ToString();
                    txtNS2.Text = dr["S_NAME"].ToString();
                    txtsoKHBD.Text = dr["C_NO_S"].ToString();
                    txtsoKHKT.Text = dr["C_NO_E"].ToString();
                }
            }
        }
        private void frm2N_Load(object sender, EventArgs e)
        {
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
            btndateNow.Text = con.getDateNow(); // get DateNow
        }
        public class getNR
        {
            public static int NR1;
            public static string WS_NO;
        }
        // Load first
        private void LoadFirst() // Loadfirst 
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f11ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnAction.Hide();
            btnClose.Hide();
            process();
            getNR.WS_NO = txtST.Text;
        }
        public void process() // Control Button MoveFirst, MovePrevious, MoveNext, MoveLast 
        {
         
                string str2 = "SELECT WS_DATE, WS_NO, S_NO, S_NAME, C_NO_S, C_NO_E FROM STOHC ORDER BY WS_NO DESC";
                DataTable dt2 = con.readdata(str2);
                if(dt2 != null && dt2.Rows.Count > 0)
                {
                    source = new BindingSource();
                    foreach (DataRow row in dt2.Rows)
                    source.Add(row);
                    ShowRecord();
                }
                else
                {
                    btnMoveFirst.Enabled = false;
                    btnMovePrevious.Enabled = false;
                    btnMoveNext.Enabled = false;
                    btnMoveLast.Enabled = false;
                }
        }
               
             


        private void ShowRecord() // Binding Data Source to Textbox 
        {
            DataRow currenRow = (DataRow)source.Current;

            txtngayTT.Text = con.formatstr2(currenRow["WS_DATE"].ToString());
            txtST.Text = currenRow["WS_NO"].ToString();
            txtNS1.Text = currenRow["S_NO"].ToString();
            txtNS2.Text = currenRow["S_NAME"].ToString();
            txtsoKHBD.Text = currenRow["C_NO_S"].ToString();
            txtsoKHKT.Text = currenRow["C_NO_E"].ToString();

        }
        private void LoadDGV() // Load DataGridview With Text chang WS_NO 
        {
            string Date = con.formatstr2(txtngayTT.Text);
            string S_SQL = "SELECT NR, C_NO, C_NAME, CAROUT, ORDOUT,CAROUT_C,ORDOUT_C,MEMO FROM STOBC WHERE WS_NO ='" + txtST.Text + "' ";
            DataTable dt = con.readdata(S_SQL);
            if (dt != null)
            {
                DGV1.DataSource = dt;

                con.DGV(DGV1);
            }
        }
        private void timer1_Tick(object sender, EventArgs e) // get Time Now 
        {
            btnTimeNow.Text = con.getTimeNow();
            getID();
        }
        public void getIP() //get IP local 
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void btnMoveFirst_Click(object sender, EventArgs e) //MoveFirst 
        {
            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMovePrevious_Click(object sender, EventArgs e) //MovePrevious 
        {
            source.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMoveNext_Click(object sender, EventArgs e) //MoveNext 
        {
            source.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMoveLast_Click(object sender, EventArgs e) //MoveLast 
        {
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }
        #endregion
        #region Tool 1->12
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e) // F1 Registration 
        {

        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Adding Data 
        {
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f11ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btnAction.Show();
            btnClose.Show();

            btnAction.Text = ""+txtThem+"";
            txtngayTT.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtNS1.Text = frmLogin.ID_USER;
            txtNS2.Text = con.getUser(txtNS1.Text);
            txtsoKHBD.Clear();
            txtsoKHKT.Clear();
            txtST.Clear();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) //F3 Delete Data 
        {
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f11ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btnAction.Show();
            btnClose.Show();
            btnAction.Text = ""+txtXoa+"";
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) //F5 Serch Data 
        {
            f5ToolStripMenuItem.Checked = true;
            frm2NF5 f5 = new frm2NF5();

            f5.Show();
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e) //F7 Print Data 
        {
            frm2NF7 fm = new frm2NF7();
            fm.ShowDialog();
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e) //F10 Save Data  
        {

        }

        private void f11ToolStripMenuItem_Click(object sender, EventArgs e) //F11 Format Data 
        {

        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) //F12 Close Application 
        {
                this.Hide();
        }
        #endregion
        #region Mouse Click
        private void txtsoKHBD_MouseDoubleClick(object sender, MouseEventArgs e) //Add Cust Start 
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fm = new frm2CustSearch();
                fm.ShowDialog();
                txtsoKHBD.Text = frm2CustSearch.ID.ID_CUST;
            }
        }

        private void txtsoKHKT_MouseDoubleClick(object sender, MouseEventArgs e) //Add Cust END 
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fm = new frm2CustSearch();
                fm.ShowDialog();
                txtsoKHKT.Text = frm2CustSearch.ID.ID_CUST;
            }
        }

        public void txtST_MouseClick(object sender, MouseEventArgs e) // Event Load WS_NO 
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                string Date = con.formatstr2(txtngayTT.Text);
                string SQL = "SELECT WS_NO, NR FROM STOBC WHERE WS_DATE = '" + Date + "' ";
                DataTable dt = con.readdata(SQL);
                if (dt.Rows.Count > 0)
                {
                    int max = 01;
                    int maxNR = 001;
                    foreach (DataRow dr in dt.Rows)
                    {
                        int getNR = int.Parse(dr["NR"].ToString());
                        if (maxNR < getNR)
                            maxNR = getNR;
                        maxNR++;
                        string k = dr["WS_NO"].ToString();
                        k = k.Substring(k.Length - 3, 3);
                        int L = int.Parse(k);
                        if (max < L)
                            max = L;
                        max++;
                    }
                    getNR.NR1 = maxNR;
                    string asString = max.ToString("D" + 3);
                    string re = Date + asString;
                    txtST.Text = re;
                }
                else
                {
                    txtST.Text = Date + "001";
                    getNR.NR1 = 1;
                }
            }
        }

        private void txtST_TextChanged(object sender, EventArgs e) // Event Load DGV 
        {
            LoadDGV();
        }

        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtLuuTC = "";
        string txtLuuTB = "";
        string txtXoaTC = "";
        string txtHoiXoa = "";
        string txtThem = "";
        string txtXoa = "";
        string txtText = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thành Công";
                txtHoiXoa = "Bạn có muốn xóa không?";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtText = "Chưa Nhập Mã Khách Hàng";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thành Công";
                txtHoiXoa = "Bạn có muốn xóa không?";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtText = "Chưa Nhập Mã Khách Hàng";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtLuuTC = "Save successfully";
                txtLuuTB = "Save Failure";
                txtXoaTC = "Delete Successfully";
               
                txtHoiXoa = "You may want to delete?";
              
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtText = "Customer Code Not Entered";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtLuuTC = "保存成功";
                txtLuuTB = "保存失敗";
                txtXoaTC = "刪除成功";
                txtHoiXoa = "你可能想刪除？";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtText = "未輸入客戶代碼";
            }
        }
        #endregion
        public void addData() //Adding Data  
        {
            checkNofication();
            bool add = false;
            string Insert = "";
            string SQL = "";
            string Date = con.formatstr2(txtngayTT.Text);
            string Time = DateTime.Now.ToString("HHmmss");
            if (txtsoKHBD.Text == string.Empty && txtsoKHKT.Text == string.Empty)
                MessageBox.Show(""+txtText+"");
            else if (txtsoKHBD.Text == string.Empty)
                SQL = "SELECT C_NO, C_NAME2 FROM CUST WHERE C_NO BETWEEN '*' AND '" + txtsoKHKT.Text + "'";
            else if (txtsoKHKT.Text == string.Empty)
                SQL = "SELECT C_NO, C_NAME2 FROM CUST WHERE C_NO BETWEEN '" + txtsoKHBD.Text + "' AND 'SELECT TOP 1 * FROM CUST ORDER BY C_NO DESC' ";
            else
                SQL = "SELECT C_NO, C_NAME2 FROM CUST WHERE C_NO BETWEEN '" + txtsoKHBD.Text + "' AND '" + txtsoKHKT.Text + "' ";
            DataTable dt = con.readdata(SQL);
            if(dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string STT = getNR.NR1.ToString("000000");
                    string C_NO = dr["C_NO"].ToString();
                    string C_NAME = dr["C_NAME2"].ToString();

                    Insert = "INSERT INTO STOBC (WS_NO, NR, WS_DATE, WS_TIME, C_NO, C_NAME) VALUES ('"+txtST.Text+ "','"+STT+"','"+Date+"','"+Time+"','"+C_NO+"','"+C_NAME+"') ";
                    add = con.exedata(Insert);
                    getNR.NR1++;
                }
            }
            string Insert1 = "INSERT INTO STOHC (WS_NO, WS_DATE, WS_TIME, S_NO, S_NAME, USR_NAME, OVER0, C_NO_S, C_NO_E) VALUES ('" + txtST.Text + "','" + Date + "','" + Time + "','" + txtNS1.Text + "','" + txtNS2.Text + "','" + txtNS2.Text + "','N', '" + txtsoKHBD.Text + "','" + txtsoKHKT.Text + "' ) ";
            bool add1 = con.exedata(Insert1);
            if (add1 == true)
                MessageBox.Show(""+txtLuuTC+"", ""+txtThongBao+"", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            else
                MessageBox.Show(""+txtLuuTB+"", ""+txtThongBao+"", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }
        private void DeleteData() // DeleteData  
        {
            checkNofication();
            string s1 = "DELETE FROM STOBC WHERE WS_NO = '" + txtST.Text + "' ";
            string s2 = "DELETE FROM STOHC WHERE WS_NO = '" + txtST.Text + "' ";
            DialogResult del = MessageBox.Show(""+txtHoiXoa+"", ""+txtThongBao+"", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(del == DialogResult.Yes)
            {
                bool del1 = con.exedata(s1);
                bool del2 = con.exedata(s2);
                if(del1 == true && del2 == true)
                    MessageBox.Show(""+txtXoaTC+"", ""+txtThongBao+"", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                LoadFirst();
            }
        }
        private void btnAction_Click(object sender, EventArgs e) // Process Button Action Add, Dele... 
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                addData();
                LoadFirst();
            }
            else if(f3ToolStripMenuItem.Checked == true)
            {
               DeleteData();
               LoadFirst();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) // Reset button Action 
        {
            LoadFirst();
        }

        private void txtngayTT_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtsoKHKT, txtST, sender, e);
        }

        private void txtST_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtngayTT, txtNS1, sender, e);
        }

        private void txtNS1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtST, txtNS2, sender, e);
        }

        private void txtNS2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtNS1, txtsoKHBD, sender, e);
        }

        private void txtsoKHBD_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtNS2, txtsoKHKT, sender, e);
        }

        private void txtsoKHKT_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtsoKHBD, txtngayTT, sender, e);
        }
    }
}
