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
    public partial class Form1R : Form
    {
        DataProvider conn = new DataProvider();
        public Form1R()
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        public void GetDL()
        {
            tb1.Text = Form1RF5.DL.t1;
            tb2.Text = Form1RF5.DL.t2;
            tb3.Text = Form1RF5.DL.t3;
            tb4.Text = Form1RF5.DL.t4;
            tb5.Text = Form1RF5.DL.t5;
            tb6.Text = Form1RF5.DL.t6;
            lblEditBy.Text = Form1RF5.DL.t7;
        }
        #region LOAD DATA
        private void Form1Rqldulieuketcau_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            LoadData();
            hienthi();


            btok.Hide();
            btdong.Hide();

            tb1.Enabled = false;
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;
            tb5.Enabled = false;
            tb6.Enabled = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            conn.DGV(dataGridViewFormR);

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

            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select PT_NO, PATT_NO, PATT_C, PATT_E, PT_BRAND, MEMO,USR_NAME from dbo.PATT";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewFormR.DataSource = bindingsource;

            this.dataGridViewFormR.Columns["USR_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = dataGridViewFormR.Rows[0].Cells["PT_NO"].Value.ToString();
            tb2.Text = dataGridViewFormR.Rows[0].Cells["PATT_NO"].Value.ToString();
            tb3.Text = dataGridViewFormR.Rows[0].Cells["PATT_C"].Value.ToString();
            tb4.Text = dataGridViewFormR.Rows[0].Cells["PATT_E"].Value.ToString();
            tb5.Text = dataGridViewFormR.Rows[0].Cells["PT_BRAND"].Value.ToString();
            tb6.Text = dataGridViewFormR.Rows[0].Cells["MEMO"].Value.ToString();
            lblEditBy.Text = dataGridViewFormR.Rows[0].Cells["USR_NAME"].Value.ToString();
        }
        public void hienthi2()
        {
            this.tb1.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[3].Value.ToString();
            this.tb5.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[4].Value.ToString();
            this.tb6.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[5].Value.ToString();
            this.lblEditBy.Text = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells[6].Value.ToString();
        }
        private void dataGridViewFormR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewFormR.ClearSelection();
            dataGridViewFormR.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewFormR.DataSource = bindingsource;
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
                int IndexNow = dataGridViewFormR.CurrentRow.Index;
                if (dataGridViewFormR.Rows.Count > IndexNow)
                {
                    dataGridViewFormR.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewFormR.DataSource = bindingsource;
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
                int IndexNow = dataGridViewFormR.CurrentRow.Index;
                if (dataGridViewFormR.Rows.Count > IndexNow)
                {
                    dataGridViewFormR.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewFormR.DataSource = bindingsource;
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
            dataGridViewFormR.ClearSelection();
            int so = dataGridViewFormR.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewFormR.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewFormR.DataSource = bindingsource;
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
        string txtLuuTC = "";
        string txtHoiXoa = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        string txtText6 = "";


        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {

                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Kết Cấu";
                txtText2 = "Mã Kết Cấu Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã kêt cấu";
                txtText4 = "Bạn chưa nhập số kêt cấu";
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
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Kết Cấu";
                txtText2 = "Mã Kết Cấu Đã Tồn Tại";
                txtText3 = "Bạn chưa nhập mã kêt cấu";
                txtText4 = "Bạn chưa nhập số kêt cấu";
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
                txtThongBao = "Nofication";
                txtText1 = "You Need to Change Texture Code";
                txtText2 = "Texture code already exists";
                txtText3 = "You have not entered texture code";
                txtText4 = "You have not entered texture number";
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
                txtThongBao = "通知";
                txtText1 = "您需要更改紋理代碼";
                txtText2 = "紋理代碼已存在";
                txtText3 = "您還沒有輸入紋理代碼";
                txtText4 = "您還沒有輸入紋理編號";
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
        #region Tool 1 -> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            tb6.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
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
            f5ToolStripMenuItem.Enabled = false;
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
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            tb6.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            DialogResult dr = MessageBox.Show("Bạn không thể sửa mã kết cấu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                tb1.Enabled = false;
                tb2.Enabled = true;
                tb3.Enabled = true;
                tb4.Enabled = true;
                tb5.Enabled = true;
                tb6.Enabled = true;
            }

        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1RF5 fr = new Form1RF5();
            fr.ShowDialog();
            GetDL();
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
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
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;
            tb6.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
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
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select PT_NO from PATT WHERE PT_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["PT_NO"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }
                con.Open();
                string st = "insert into dbo.PATT (PT_NO, PATT_NO, PATT_C, PATT_E, PT_BRAND, MEMO,USR_NAME) values(@PT_NO, @PATT_NO, @PATT_C, @PATT_E, @PT_BRAND, @MEMO,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st, con);

                cm.Parameters.AddWithValue("@PT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@PATT_NO", tb2.Text);
                cm.Parameters.AddWithValue("@PATT_C", tb3.Text);
                cm.Parameters.AddWithValue("@PATT_E", tb4.Text);
                cm.Parameters.AddWithValue("@PT_BRAND", tb5.Text);
                cm.Parameters.AddWithValue("@MEMO", tb6.Text);
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
                    tb3.Enabled = false;
                    tb4.Enabled = false;
                    tb5.Enabled = false;
                    tb6.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;


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
                string sodong = tb1.Text;
                if (sodong == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                DialogResult dr = MessageBox.Show(txtHoiXoa, txtThongBao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        cm = con.CreateCommand();
                        cm.CommandText = "delete from PATT where PT_NO ='" + sodong + "'";
                        cm.ExecuteNonQuery();
                        MessageBox.Show(txtText6);
                        con.Close();

                        LoadData();
                        hienthi();
                        hienthi2();

                        btok.Hide();
                        btdong.Hide();

                        tb1.Enabled = false;
                        tb2.Enabled = false;
                        tb3.Enabled = false;
                        tb4.Enabled = false;
                        tb5.Enabled = false;
                        tb6.Enabled = false;

                        f2ToolStripMenuItem.Enabled = true;
                        f3ToolStripMenuItem.Enabled = true;
                        f4ToolStripMenuItem.Enabled = true;
                        f5ToolStripMenuItem.Enabled = true;
                        f6ToolStripMenuItem.Enabled = true;
                        f7ToolStripMenuItem.Enabled = false;
                        f8ToolStripMenuItem.Enabled = false;
                        f10ToolStripMenuItem.Enabled = true;


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
                string st = "update dbo.PATT set PT_NO = @PT_NO, PATT_NO = @PATT_NO, PATT_C = @PATT_C, PATT_E = @PATT_E, PT_BRAND = @PT_BRAND, MEMO = @MEMO,USR_NAME = @USR_NAME where PT_NO = @PT_NO";
                con.Open();
                SqlCommand cm = new SqlCommand(st, con);

                cm.Parameters.AddWithValue("@PT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@PATT_NO", tb2.Text);
                cm.Parameters.AddWithValue("@PATT_C", tb3.Text);
                cm.Parameters.AddWithValue("@PATT_E", tb4.Text);
                cm.Parameters.AddWithValue("@PT_BRAND", tb5.Text);
                cm.Parameters.AddWithValue("@MEMO", tb6.Text);
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
                    tb3.Enabled = false;
                    tb4.Enabled = false;
                    tb5.Enabled = false;
                    tb6.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

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
                string SQL = "select PT_NO from PATT WHERE PT_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["PT_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("Mã Kết Cấu Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb1.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Open();
                string st = "insert into dbo.PATT (PT_NO, PATT_NO, PATT_C, PATT_E, PT_BRAND, MEMO,USR_NAME) values(@PT_NO, @PATT_NO, @PATT_C, @PATT_E, @PT_BRAND, @MEMO,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st, con);

                cm.Parameters.AddWithValue("@PT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@PATT_NO", tb2.Text);
                cm.Parameters.AddWithValue("@PATT_C", tb3.Text);
                cm.Parameters.AddWithValue("@PATT_E", tb4.Text);
                cm.Parameters.AddWithValue("@PT_BRAND", tb5.Text);
                cm.Parameters.AddWithValue("@MEMO", tb6.Text);
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
                    tb3.Enabled = false;
                    tb4.Enabled = false;
                    tb5.Enabled = false;
                    tb6.Enabled = false;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = false;
                    f8ToolStripMenuItem.Enabled = false;
                    f10ToolStripMenuItem.Enabled = true;

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

            tb1.Enabled = false;
            tb2.Enabled = false;
            tb3.Enabled = false;
            tb4.Enabled = false;
            tb5.Enabled = false;
            tb6.Enabled = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            dataGridViewFormR.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewFormR.RowHeadersWidth = 40;
            dataGridViewFormR.EnableHeadersVisualStyles = false;
            dataGridViewFormR.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            dataGridViewFormR.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11F, FontStyle.Bold);

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
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
            conn.tab(tb4, tb6, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb5, tb1, sender, e);
        }

    }
}
