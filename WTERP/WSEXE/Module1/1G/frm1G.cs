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
    public partial class Form1G : Form
    {
        DataProvider conn = new DataProvider();
        public Form1G()
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
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtText2 = "";
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
                txtText2 = "Mã Cụm Từ Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã";
                txtText4 = "Bạn chưa nhập nội dung";
                txtText5 = "Mã Cụm Từ Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtText2 = "Mã Cụm Từ Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã";
                txtText4 = "Bạn chưa nhập nội dung";
                txtText5 = "Mã Cụm Từ Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtText2 = "Phrase Code Already Exists";
                txtText3 = "You have not entered the code";
                txtText4 = "You did not enter content";
                txtText5 = "Phrase Code Already Exists \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtXoa = "Không có dữ liệu";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtText2 = "短語代碼已存在";
                txtText3 = "您還沒有輸入代碼";
                txtText4 = "您沒有輸入內容";
                txtText5 = "短語代碼存在 \n 請單擊確定，[關閉]並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region LOAD DATA
        private void Form1Gquanlydlcumtu_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            LoadData();
            hienthi();

            tb1.Enabled = false;
            tb2.Enabled = false;

            btok.Hide();
            btdong.Hide();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";
            getInfo();

            conn.DGV(dataGridViewForm1G);
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
            cm.CommandText = "select M_NO, M_NAME,USR_NAME from MEMO";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1G.DataSource = bindingsource;

            dataGridViewForm1G.Columns["USR_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1G.Rows[0].Cells["M_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1G.Rows[0].Cells["M_NAME"].Value.ToString();
            lblEditBy.Text = dataGridViewForm1G.Rows[0].Cells["USR_NAME"].Value.ToString();
        }

        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1G.Rows[dataGridViewForm1G.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1G.Rows[dataGridViewForm1G.CurrentRow.Index].Cells[1].Value.ToString();
            this.lblEditBy.Text = dataGridViewForm1G.Rows[dataGridViewForm1G.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1G.ClearSelection();
            dataGridViewForm1G.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1G.DataSource = bindingsource;
            bindingsource.MoveFirst();

            hienthi2();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1G.CurrentRow.Index;
                if (dataGridViewForm1G.Rows.Count > IndexNow)
                {
                    dataGridViewForm1G.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1G.DataSource = bindingsource;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataGridViewForm1G.CurrentRow.Index;
                if (dataGridViewForm1G.Rows.Count > IndexNow)
                {
                    dataGridViewForm1G.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1G.DataSource = bindingsource;
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridViewForm1G.ClearSelection();
            int so = dataGridViewForm1G.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1G.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1G.DataSource = bindingsource;
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
            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

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
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

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

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            // khóa
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridViewForm1G_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select M_NO from MEMO WHERE M_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["M_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.MEMO(M_NO, M_NAME,USR_NAME) values(@M_NO, @M_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@M_NO", tb1.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb2.Text);
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
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    tb1.Enabled = false;
                    tb2.Enabled = false;
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
                string tenma = tb1.Text;
                if (tenma == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from MEMO where M_NO ='" + tenma + "'";
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
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    tb1.Enabled = false;
                    tb2.Enabled = false;
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
                string st1 = "update dbo.MEMO set M_NO = @M_NO, M_NAME = @M_NAME,USR_NAME = @USR_NAME where M_NO = @M_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@M_NO", tb1.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb2.Text);
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
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    tb1.Enabled = false;
                    tb2.Enabled = false;
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
                string SQL = "select M_NO from MEMO WHERE M_NO = '" + a + "'";
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
                string st1 = "insert into dbo.MEMO(M_NO, M_NAME,USR_NAME) values(@M_NO, @M_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@M_NO", tb1.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb2.Text);
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
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    tb1.Enabled = false;
                    tb2.Enabled = false;
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

        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            LoadData();

            hienthi();
            hienthi2();

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            tb1.Enabled = false;
            tb2.Enabled = false;
            bt.Text = "" + txtDuyet + "";

            btok.Hide();
            btdong.Hide();


            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDown.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Right)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtDown.Focus();
                txtUp.SelectAll();
            }
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb1, sender, e);
        }
    }
}
