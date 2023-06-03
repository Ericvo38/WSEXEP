using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1N : Form
    {
        DataProvider conn = new DataProvider();
        public Form1N()
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
        private void Form1Nquanlymucthanhpham_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            LoadData();
            hienthi();

            btok.Hide();
            btdong.Hide();

            tb1.Enabled = false;
            tb2.Enabled = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            conn.DGV(dataGridViewForm1N);

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
            cm.CommandText = "select G_NO, G_NAME,USR_NAME from GRADE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1N.DataSource = bindingsource;

            dataGridViewForm1N.Columns["USR_NAME"].Visible = false;
        }

        public void hienthi()
        {
            tb1.Text = dataGridViewForm1N.Rows[0].Cells["G_NO"].Value.ToString();
            tb2.Text = dataGridViewForm1N.Rows[0].Cells["G_NAME"].Value.ToString();
            lblEditBy.Text = dataGridViewForm1N.Rows[0].Cells["USR_NAME"].Value.ToString();
        }

        public void hienthi2()
        {
            this.tb1.Text = dataGridViewForm1N.Rows[dataGridViewForm1N.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewForm1N.Rows[dataGridViewForm1N.CurrentRow.Index].Cells[1].Value.ToString();
            this.lblEditBy.Text = dataGridViewForm1N.Rows[dataGridViewForm1N.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void dataGridViewForm1N_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1N.ClearSelection();
            dataGridViewForm1N.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1N.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1N.CurrentRow.Index;
                if (dataGridViewForm1N.Rows.Count > IndexNow)
                {
                    dataGridViewForm1N.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1N.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1N.CurrentRow.Index;
                if (dataGridViewForm1N.Rows.Count > IndexNow)
                {
                    dataGridViewForm1N.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1N.DataSource = bindingsource;
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
            dataGridViewForm1N.ClearSelection();
            int so = dataGridViewForm1N.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1N.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1N.DataSource = bindingsource;
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
        string txtText4 = "";
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
                txtText = "Bạn không thể sửa mã mức thành phẩm";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Số Với 2 Ký Tự";
                txtText2 = "Mã Mức Thành Phẩm Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập Mã";
                txtText4 = "Bạn chưa nhập Tên";
                txtText5 = "Mã Thành Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
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
                txtText = "Bạn không thể sửa mã mức thành phẩm";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Số Với 2 Ký Tự";
                txtText2 = "Mã Mức Thành Phẩm Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập Mã";
                txtText4 = "Bạn chưa nhập Tên";
                txtText5 = "Mã Thành Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
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
                txtText = "You cannot edit the finished product level code";
                txtThongBao = "Nofication";
                txtText1 = "You Need To Change The Code With 2 Characters";
                txtText2 = "Finished Product Level Code Exists";
                txtText3 = "You have not entered the Code";
                txtText4 = "You have not entered Name";
                txtText5 = "Finished Product Code Existing \n Please Click OK, [Close] and Re-Operate";
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
                txtText = "您不能編輯成品級別代碼";
                txtThongBao = "通知";
                txtText1 = "您需要用 2 個字符更改代碼";
                txtText2 = "存在成品級別代碼";
                txtText3 = "您尚未輸入性能代碼";
                txtText4 = "您尚未輸入表演名稱";
                txtText5 = "已存在成品代碼\n請點擊確定，[關閉]並重新操作";
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
        #region Tool 1-> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
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
            tb1.Enabled = false;
            tb2.Enabled = true;
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
            DialogResult dr = MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                tb1.Enabled = false;
                tb2.Enabled = true;

            }

        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;
            MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;

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
                string SQL = "select G_NO from GRADE where G_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["G_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.GRADE(G_NO, G_NAME,USR_NAME) values(@G_NO, @G_NAME,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@G_NO", tb1.Text);
                cm.Parameters.AddWithValue("@G_NAME", tb2.Text);
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
                    MessageBox.Show("" + txtLuuTC + "");
                    con.Close();
                    LoadData();
                    hienthi();
                    hienthi2();

                    btok.Hide();
                    btdong.Hide();

                    tb1.Enabled = false;
                    tb2.Enabled = false;

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
                string Ma = tb1.Text;
                if (Ma == "")
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
                        cm.CommandText = "delete from GRADE where G_NO ='" + Ma + "'";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("" + txtText6 + "");
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
                        f10ToolStripMenuItem.Enabled = false;
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
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.GRADE set G_NO = @G_NO, G_NAME = @G_NAME,USR_NAME = @USR_NAME where G_NO = @G_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@G_NO", tb1.Text);
                cm.Parameters.AddWithValue("@G_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
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

                    tb1.Enabled = false;
                    tb2.Enabled = false;

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
                string SQL = "select G_NO from GRADE where G_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["G_NO"].ToString())
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
                string st1 = "insert into dbo.GRADE(G_NO, G_NAME) values(@G_NO, @G_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@G_NO", tb1.Text);
                cm.Parameters.AddWithValue("@G_NAME", tb2.Text);

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
                    MessageBox.Show("" + txtLuuTC + "");
                    con.Close();
                    LoadData();
                    hienthi();
                    hienthi2();

                    btok.Hide();
                    btdong.Hide();

                    tb1.Enabled = false;
                    tb2.Enabled = false;

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
            checkNofication();
            LoadData();
            hienthi();

            btok.Hide();
            btdong.Hide();

            tb1.Enabled = false;
            tb2.Enabled = false;

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
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2, tb1, sender, e);
        }
    }
}
