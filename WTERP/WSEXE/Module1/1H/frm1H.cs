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
    public partial class Form1H : Form
    {
        DataProvider conn = new DataProvider();
        public Form1H()
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
        private void Form1Hquanlydulieukho_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            LoadData();
            hienthi();
            getInfo();
            tb1.Enabled = false;
            tb2.Enabled = false;

            btok.Hide();
            btdong.Hide();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";
            conn.DGV(dataGridViewForm1H);

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
            btndateNow.Text = conn.getDateNow(); // get DateNow


        }
        public void LoadData()
        {
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select SH_NO, SH_NAME,USR_NAME from SHOUSE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1H.DataSource = bindingsource;

            dataGridViewForm1H.Columns["USR_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1H.Rows[0].Cells["SH_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1H.Rows[0].Cells["SH_NAME"].Value.ToString();
            lblEditBy.Text = dataGridViewForm1H.Rows[0].Cells["USR_NAME"].Value.ToString();
        }

        private void dataGridViewForm1H_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }

        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells[1].Value.ToString();
            this.lblEditBy.Text = dataGridViewForm1H.Rows[dataGridViewForm1H.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1H.ClearSelection();
            dataGridViewForm1H.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1H.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1H.CurrentRow.Index;
                if (dataGridViewForm1H.Rows.Count > IndexNow)
                {
                    dataGridViewForm1H.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1H.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1H.CurrentRow.Index;
                if (dataGridViewForm1H.Rows.Count > IndexNow)
                {
                    dataGridViewForm1H.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1H.DataSource = bindingsource;
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
            dataGridViewForm1H.ClearSelection();
            int so = dataGridViewForm1H.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1H.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1H.DataSource = bindingsource;
            bindingsource.MoveLast();

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
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

            this.tb1.Text = "";
            this.tb2.Text = "";


            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();
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
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();
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
            tb1.Enabled = false;
            tb2.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
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
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btok.Show();
            btdong.Show();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        string txtText5 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtText3 = "Bạn chưa nhập mã kho";
                txtText4 = "Bạn chưa nhập tên kho";
                txtText5 = "Mã Kho Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtText3 = "Bạn chưa nhập mã kho";
                txtText4 = "Bạn chưa nhập tên kho";
                txtText5 = "Mã Kho Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtText3 = "You have not entered the code";
                txtText4 = "You have not entered the name of the store";
                txtText5 = "Stock Code Exists \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtText3 = "您還沒有輸入代碼";
                txtText4 = "您還沒有輸入店鋪名稱";
                txtText5 = "股票代碼存在\n請點擊確定，[關閉]並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select SH_NO from SHOUSE WHERE SH_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["M_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText5 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                            return;
                        }
                    }
                }
                catch
                {

                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.SHOUSE(SH_NO, SH_NAME,USR_NAME) values(@SH_NO, @SH_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@SH_NO", tb1.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
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

                    tb1.Enabled = false;
                    tb2.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btok.Hide();
                    btdong.Hide();
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
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string Makho = tb1.Text;
                if (Makho == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from SHOUSE where SH_NO ='" + Makho + "'";
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();
                    hienthi2();

                    tb1.Enabled = false;
                    tb2.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btok.Hide();
                    btdong.Hide();
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
                string st1 = "update dbo.SHOUSE set SH_NO = @SH_NO, SH_NAME = @SH_NAME,USR_NAME = @USR_NAME where SH_NO = @SH_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@SH_NO", tb1.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
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
                    f6ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btok.Hide();
                    btdong.Hide();
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
            else if (f6ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select SH_NO from SHOUSE WHERE SH_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["M_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText5 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                            return;
                        }
                    }
                }
                catch
                {

                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.SHOUSE(SH_NO, SH_NAME,USR_NAME) values(@SH_NO, @SH_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@SH_NO", tb1.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);
                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb2.Text == string.Empty)
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

                    tb1.Enabled = false;
                    tb2.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;
                    btok.Hide();
                    btdong.Hide();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            LoadData();
            hienthi();
            getInfo();
            tb1.Enabled = false;
            tb2.Enabled = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btok.Hide();
            btdong.Hide();

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
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }
        private void tb1_KeyDown_1(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
        private void tb2_KeyDown_1(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
    }
}
