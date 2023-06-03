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
    public partial class Form1L : Form
    {
        DataProvider conn = new DataProvider();
        public Form1L()
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
        #region Load Data
        private void Form1Lquanlithongtinnhanvien_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            LoadData();
            hienthi();

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            conn.DGV(dataGridViewForm1L);

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
            cm.CommandText = "select S_NO, S_NAME, S_KIND, DEPT_NO, DEPT_NAME,USR_NAME from SALE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1L.DataSource = bindingsource;
            this.dataGridViewForm1L.Columns["USR_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewForm1L.Rows[0].Cells["S_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1L.Rows[0].Cells["S_NAME"].Value.ToString();
            tb3.Text = dataGridViewForm1L.Rows[0].Cells["S_KIND"].Value.ToString();
            tb4.Text = dataGridViewForm1L.Rows[0].Cells["DEPT_NO"].Value.ToString();
            tb5.Text = dataGridViewForm1L.Rows[0].Cells["DEPT_NAME"].Value.ToString();

            lblEditBy.Text = dataGridViewForm1L.Rows[0].Cells["USR_NAME"].Value.ToString();
        }
        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[3].Value.ToString();
            this.tb5.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[4].Value.ToString();

            this.tb5.Text = dataGridViewForm1L.Rows[dataGridViewForm1L.CurrentRow.Index].Cells[5].Value.ToString();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1L.ClearSelection();
            dataGridViewForm1L.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1L.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1L.CurrentRow.Index;
                if (dataGridViewForm1L.Rows.Count > IndexNow)
                {
                    dataGridViewForm1L.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1L.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1L.CurrentRow.Index;
                if (dataGridViewForm1L.Rows.Count > IndexNow)
                {
                    dataGridViewForm1L.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1L.DataSource = bindingsource;
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
            dataGridViewForm1L.ClearSelection();
            int so = dataGridViewForm1L.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1L.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1L.DataSource = bindingsource;
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
        string txtText = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtLuuTC = "";
        string txtHoiXoa = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        string txtText5 = "";
        string txtText6 = "";

        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Bạn Cần Thay Đổi Mã Nhân Viên Với 20 Ký Tự";
                txtThongBao = "Thông Báo";
                txtText1 = "Mã Nhân Viên Đã Tồn Tại";
                txtText2 = "Bạn chưa nhập mã nhân viên";
                txtText3 = "Bạn chưa nhập tên nhân viên";
                txtText5 = "Mã Nhân Viên Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtText6 = "Xóa Thành Công";
                txtLuuTC = "Lưu Thành Công";
                txtHoiXoa = "Bạn có muốn xóa không?";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Bạn Cần Thay Đổi Mã Nhân Viên Với 20 Ký Tự";
                txtThongBao = "Thông Báo";
                txtText1 = "Mã Nhân Viên Đã Tồn Tại";
                txtText2 = "Bạn chưa nhập mã nhân viên";
                txtText3 = "Bạn chưa nhập tên nhân viên";
                txtText5 = "Mã Nhân Viên Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtText6 = "Xóa Thành Công";
                txtLuuTC = "Lưu Thành Công";
                txtHoiXoa = "Bạn có muốn xóa không?";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "You Need To Change Employee Code With 20 Characters";
                txtThongBao = "Nofication";
                txtText1 = "Employee Code Exists";
                txtText2 = "You have not entered employee code";
                txtText3 = "You have not entered employee name";
                txtText5 = "Employee Code Exists \n Please Click OK, [Close] and Re-Operate";
                txtText6 = "Delete Successfully";
                txtLuuTC = "Save successfully";
                txtHoiXoa = "You may want to delete?";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "您需要更改 20 個字符的員工代碼";
                txtThongBao = "通知";
                txtText1 = "員工代碼存在";
                txtText2 = "您還沒有輸入員工代碼";
                txtText3 = "您還沒有輸入員工姓名";
                txtText5 = "員工代碼存在\n請點擊確定，[關閉]並重新操作";
                txtText6 = "刪除成功";
                txtLuuTC = "保存成功";
                txtHoiXoa = "你可能想刪除？";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region Tool 1->12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
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
            f6ToolStripMenuItem.Enabled = false;
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
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            DialogResult dr = MessageBox.Show("Bạn không thể sửa mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                tb1.Enabled = false;
                tb2.Enabled = true;
                tb3.Enabled = true;
                tb4.Enabled = true;
                tb5.Enabled = true;
            }
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }

            btok.Show();
            btdong.Show();


            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

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
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select S_NO from SALE WHERE S_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["S_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.SALE(S_NO, S_NAME, S_KIND, DEPT_NO, DEPT_NAME,USR_NAME) values(@S_NO, @S_NAME, @S_KIND, @DEPT_NO, @DEPT_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@S_NO", tb1.Text);
                cm.Parameters.AddWithValue("@S_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@S_KIND", tb3.Text);
                cm.Parameters.AddWithValue("@DEPT_NO", tb4.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb5.Text);
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

                try
                {

                    cm.ExecuteNonQuery();
                    MessageBox.Show("" + txtLuuTC + "");
                    con.Close();
                    LoadData();

                    hienthi();
                    hienthi2();

                    btok.Hide();
                    btdong.Hide();


                    tb1.Enabled = true;
                    tb2.Enabled = true;
                    tb3.Enabled = true;
                    tb4.Enabled = true;
                    tb5.Enabled = true;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
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
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string Manhanvien = tb1.Text;
                if (Manhanvien == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                DialogResult dr = MessageBox.Show("" + txtHoiXoa + "", "" + txtThongBao + "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        con = new SqlConnection(st);
                        con.Open();
                        cm = con.CreateCommand();
                        cm.CommandText = "delete from SALE where S_NO ='" + Manhanvien + "'";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("" + txtText6 + "");
                        con.Close();

                        LoadData();
                        hienthi();
                        hienthi2();


                        btok.Hide();
                        btdong.Hide();
                        tb1.Enabled = true;
                        tb2.Enabled = true;
                        tb3.Enabled = true;
                        tb4.Enabled = true;
                        tb5.Enabled = true;

                        f2ToolStripMenuItem.Enabled = true;
                        f3ToolStripMenuItem.Enabled = true;
                        f4ToolStripMenuItem.Enabled = true;
                        f6ToolStripMenuItem.Enabled = true;
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
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.SALE set S_NO = @S_NO, S_NAME = @S_NAME, S_KIND = @S_KIND, DEPT_NO = @DEPT_NO, DEPT_NAME = @DEPT_NAME,USR_NAME = @USR_NAME where S_NO = @S_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@S_NO", tb1.Text);
                cm.Parameters.AddWithValue("@S_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@S_KIND", tb2.Text);
                cm.Parameters.AddWithValue("@DEPT_NO", tb2.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb2.Text);
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

                try
                {

                    cm.ExecuteNonQuery();
                    MessageBox.Show("" + txtLuuTC + "");
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
                    // mở khóa 
                    tb1.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select S_NO from SALE WHERE S_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["S_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText5 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                        }
                    }
                }
                catch
                {

                }

                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.SALE(S_NO, S_NAME, S_KIND, DEPT_NO, DEPT_NAME,USR_NAME) values(@S_NO, @S_NAME, @S_KIND, @DEPT_NO, @DEPT_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@S_NO", tb1.Text);
                cm.Parameters.AddWithValue("@S_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@S_KIND", tb3.Text);
                cm.Parameters.AddWithValue("@DEPT_NO", tb4.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb5.Text);
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

                try
                {

                    cm.ExecuteNonQuery();
                    MessageBox.Show("" + txtLuuTC + "");
                    con.Close();
                    LoadData();

                    hienthi();
                    hienthi2();

                    btok.Hide();
                    btdong.Hide();


                    tb1.Enabled = true;
                    tb2.Enabled = true;
                    tb3.Enabled = true;
                    tb4.Enabled = true;
                    tb5.Enabled = true;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
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
        private void btdong_Click(object sender, EventArgs e)
        {
            LoadData();
            hienthi();

            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = true;
            f6ToolStripMenuItem.Checked = true;
        }
        private void dataGridViewForm1L_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4, tb1, sender, e);
        }
    }
}
