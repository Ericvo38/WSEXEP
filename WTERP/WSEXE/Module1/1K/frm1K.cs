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

namespace WTERP
{
    public partial class Form1K : Form
    {
        DataProvider conn = new DataProvider();
        public Form1K()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        #region LOAD DATA
        private void Form1Kquanlithongtinthuonghieu_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            LoadData();
            hienthi();

            tb1.Enabled = false;
            tb2.Enabled = false;
            tb3.Enabled = false;

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
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
            lbUserName.Text = conn.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        public void LoadData()
        {
            getInfo();
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select B_NO, BRAND, TRADE,USR_NAME from BRAND";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1K.DataSource = bindingsource;
            conn.DGV(dataGridViewForm1K);

            this.dataGridViewForm1K.Columns["USR_NAME"].Visible = false;

        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1K.Rows[0].Cells["B_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1K.Rows[0].Cells["BRAND"].Value.ToString();
            tb3.Text = dataGridViewForm1K.Rows[0].Cells["TRADE"].Value.ToString();
            lblEditBy.Text = dataGridViewForm1K.Rows[0].Cells["USR_NAME"].Value.ToString();
        }

        private void dataGridViewForm1K_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }

        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1K.Rows[dataGridViewForm1K.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1K.Rows[dataGridViewForm1K.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1K.Rows[dataGridViewForm1K.CurrentRow.Index].Cells[2].Value.ToString();
            this.lblEditBy.Text = dataGridViewForm1K.Rows[dataGridViewForm1K.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1K.ClearSelection();
            dataGridViewForm1K.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1K.DataSource = bindingsource;
            bindingsource.MoveFirst();

            hienthi2();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1K.CurrentRow.Index;
                if (dataGridViewForm1K.Rows.Count > IndexNow)
                {
                    dataGridViewForm1K.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1K.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }

            hienthi2();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1K.CurrentRow.Index;
                if (dataGridViewForm1K.Rows.Count > IndexNow)
                {
                    dataGridViewForm1K.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1K.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            dataGridViewForm1K.ClearSelection();
            int so = dataGridViewForm1K.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1K.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1K.DataSource = bindingsource;
            bindingsource.MoveLast();

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtText1 = "Mã Nhãn Hiệu Đã Tồn Tại";
                txtText2 = "Bạn chưa nhập mã nhãn hiệu";
                txtText3 = " Bạn chưa nhập tên nhãn hiệu";
                txtText4 = "  Bạn chưa nhập tên buôn bán";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtText1 = "Mã Nhãn Hiệu Đã Tồn Tại";
                txtText2 = "Bạn chưa nhập mã nhãn hiệu";
                txtText3 = " Bạn chưa nhập tên nhãn hiệu";
                txtText4 = "  Bạn chưa nhập tên buôn bán";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtText1 = "Brand Code Exists";
                txtText2 = "You have not entered the brand code";
                txtText3 = "You have not entered a brand name";
                txtText4 = "You have not entered the merchant name";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtText1 = "存在品牌代碼";
                txtText2 = "您還沒有輸入品牌代碼";
                txtText3 = "您尚未輸入品牌名稱";
                txtText4 = "您還沒有輸入商家名稱";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region Tool 1 -> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtXoa + "";

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtSua + "";

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            tb1.Enabled = false;
            tb2.Enabled = true;
            tb3.Enabled = true;

        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;

            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }
        public void Get_DL()
        {
            tb1.Text = Form1KF5.DL.t1;
            tb2.Text = Form1KF5.DL.t2;
            tb3.Text = Form1KF5.DL.t3;
            lblEditBy.Text = Form1KF5.DL.t4;
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f10LưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        #endregion

        private void addData()
        {
            string a = tb1.Text;
            string SQL = "select TOP 1 B_NO from BRAND Where B_NO = '" + a + "'";
            if (conn.checkExists(SQL) == true)
            {
                MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.BRAND(B_NO, BRAND, TRADE,USR_NAME) values(@B_NO, @BRAND, @TRADE,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@B_NO", tb1.Text);
                cm.Parameters.AddWithValue("@BRAND", tb2.Text);
                cm.Parameters.AddWithValue("@TRADE", tb3.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb3.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();

                    hienthi2();

                    btok.Hide();
                    btdong.Hide();

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;

                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                addData();
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string st1 = tb1.Text;
                if (st1 == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from BRAND where B_NO ='" + st1 + "'";
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();
                    hienthi2();

                    btok.Hide();
                    btdong.Hide();

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.BRAND set B_NO = @B_NO, BRAND = @BRAND, TRADE = @TRADE,USR_NAME = @USR_NAME where B_NO = @B_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@B_NO", tb1.Text);
                cm.Parameters.AddWithValue("@BRAND", tb2.Text);
                cm.Parameters.AddWithValue("@TRADE", tb3.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb3.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();

                    hienthi2();

                    btok.Hide();
                    btdong.Hide();

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                    //mở khóa
                    tb1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                addData();
            }
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            LoadData();
            hienthi();
            hienthi2();

            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2, tb1, sender, e);
        }

        private void tb2_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb3, sender, e);
        }

        private void tb1_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb2, sender, e);
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1KF5 frm = new Form1KF5();
            frm.ShowDialog();

            string dl1 = Form1KF5.DL.t1;
            if (dl1 != string.Empty)
                Get_DL();

            if (tb1.Text == "")
            {
                LoadData();
                hienthi();
            }
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
    }
}
