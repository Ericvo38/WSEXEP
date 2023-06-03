﻿using System;
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
    public partial class Form1Q : Form
    {
        DataProvider conn = new DataProvider();
        public Form1Q()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        string check = "";
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        #region Load Data
        private void Form1QquanlydulieuHSBC_Load(object sender, EventArgs e)
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

            bt.Text = "NÚT DUYỆT";
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            conn.DGV(dataGridViewForm1Q);

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
            cm.CommandText = "select WS_DATE, M_NO, M_NAME, M_NAME_E, M_TRAN,USR_NAME from MONEYT";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1Q.DataSource = bindingsource;

            dataGridViewForm1Q.Columns["USR_NAME"].Visible = false;
        }
        public void hienthi()
        {
            tb1.Text = conn.formatstr2(dataGridViewForm1Q.Rows[0].Cells["WS_DATE"].Value.ToString());
            tb2.Text = dataGridViewForm1Q.Rows[0].Cells["M_NO"].Value.ToString();
            tb3.Text = dataGridViewForm1Q.Rows[0].Cells["M_NAME"].Value.ToString();
            tb4.Text = dataGridViewForm1Q.Rows[0].Cells["M_NAME_E"].Value.ToString();
            tb5.Text = dataGridViewForm1Q.Rows[0].Cells["M_TRAN"].Value.ToString();
            lblEditBy.Text = dataGridViewForm1Q.Rows[0].Cells["USR_NAME"].Value.ToString();


        }
        public void hienthi2()
        {
            this.tb1.Text = conn.formatstr2(dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[0].Value.ToString());
            this.tb2.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[3].Value.ToString();
            this.tb5.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[4].Value.ToString();
            this.lblEditBy.Text = dataGridViewForm1Q.Rows[dataGridViewForm1Q.CurrentRow.Index].Cells[5].Value.ToString();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            dataGridViewForm1Q.ClearSelection();
            dataGridViewForm1Q.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewForm1Q.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1Q.CurrentRow.Index;
                if (dataGridViewForm1Q.Rows.Count > IndexNow)
                {
                    dataGridViewForm1Q.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1Q.DataSource = bindingsource;
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
                int IndexNow = dataGridViewForm1Q.CurrentRow.Index;
                if (dataGridViewForm1Q.Rows.Count > IndexNow)
                {
                    dataGridViewForm1Q.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataGridViewForm1Q.DataSource = bindingsource;
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
            dataGridViewForm1Q.ClearSelection();
            int so = dataGridViewForm1Q.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            dataGridViewForm1Q.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewForm1Q.DataSource = bindingsource;
            bindingsource.MoveLast();

            hienthi2();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void dataGridViewForm1Q_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hienthi2();
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
        string txtText7 = "";

        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Bạn không thể sửa mã tiền tệ";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Tiền Tệ Với 10 Ký Tự";
                txtText2 = "Mã Tiền Tệ và ngày đăng kí đã tồn tại";
                txtText3 = "Bạn chưa nhập ngày tháng";
                txtText4 = "Bạn chưa nhập mã tiền tệ";
                txtText7 = "Bạn chưa nhập tỷ giá";
                txtText5 = "Mã Tiền Tệ Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
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
                txtText = "Bạn không thể sửa mã tiền tệ";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Tiền Tệ Với 10 Ký Tự";
                txtText2 = "Mã Tiền Tệ và ngày đăng kí đã tồn tại";
                txtText3 = "Bạn chưa nhập ngày tháng";
                txtText4 = "Bạn chưa nhập mã tiền tệ";
                txtText7 = "Bạn chưa nhập tỷ giá";
                txtText5 = "Mã Tiền Tệ Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
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
                txtText = "You cannot edit the currency code";
                txtThongBao = "Nofication";
                txtText1 = "You Need To Change Currency Code With 10 Characters";
                txtText2 = "Currency Code and registration date already exist";
                txtText3 = "You have not entered a date";
                txtText4 = "You have not entered a currency code";
                txtText7 = "You have not entered an exchange rate";
                txtText5 = "Currency Code Existing \n Please Click OK, [Close] and Re-Operate";
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
                txtText = "您無法編輯貨幣代碼";
                txtThongBao = "通知";
                txtText1 = "您需要更改 10 個字符的貨幣代碼";
                txtText2 = "貨幣代碼和註冊日期已經存在";
                txtText3 = "您還沒有輸入日期";
                txtText4 = "您還沒有輸入貨幣代碼";
                txtText7 = "您還沒有輸入匯率";
                txtText5 = "貨幣代碼已存在 \n 請單擊確定，[關閉] 並重新操作";
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
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "0";

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
            f10ToolStripMenuItem.Enabled = false;
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

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;

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
                tb1.Enabled = true;
                tb2.Enabled = false;
                tb3.Enabled = true;
                tb4.Enabled = true;
                tb5.Enabled = true;
            }

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
            Check();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string a = tb2.Text;
                string SQL = "select WS_DATE,M_NO from MONEYT where WS_DATE = '" + check + "' AND M_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                foreach (DataRow dr in dt.Rows)
                {
                    if (a.ToString() == dr["M_NO"].ToString() && check.ToString() == dr["WS_DATE"].ToString())
                    {
                        DialogResult er = MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (er == DialogResult.OK)
                            tb1.Focus();
                        return;
                    }
                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.MONEYT(WS_DATE, M_NO, M_NAME, M_NAME_E, M_TRAN,USR_NAME) values(@WS_DATE, @M_NO, @M_NAME, @M_NAME_E, @M_TRAN,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@WS_DATE", check);
                cm.Parameters.AddWithValue("@M_NO", tb2.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb3.Text);
                cm.Parameters.AddWithValue("@M_NAME_E", tb4.Text);
                cm.Parameters.AddWithValue("@M_TRAN", float.Parse(tb5.Text));
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
                else if (tb5.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText7 + "");
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
                string matien = tb2.Text;
                if (matien == "")
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
                        cm.CommandText = "delete from MONEYT where M_NO ='" + matien + "'";
                        cm.ExecuteNonQuery();
                        MessageBox.Show("" + txtText6 + "");
                        con.Close();

                        LoadData();
                        hienthi();
                        hienthi2();

                        tb1.Enabled = false;
                        tb2.Enabled = false;
                        tb3.Enabled = false;
                        tb4.Enabled = false;
                        tb5.Enabled = false;

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
                string st1 = "update dbo.MONEYT set USR_NAME = @USR_NAME,WS_DATE = @WS_DATE, M_NO = @M_NO, M_NAME = @M_NAME, M_NAME_E = @M_NAME_E, M_TRAN = @M_TRAN where M_NO = @M_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@WS_DATE", check);
                cm.Parameters.AddWithValue("@M_NO", tb2.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb3.Text);
                cm.Parameters.AddWithValue("@M_NAME_E", tb4.Text);
                cm.Parameters.AddWithValue("@M_TRAN", float.Parse(tb5.Text));
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
                else if (tb5.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText7 + "");
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
                    // Open Lock
                    tb2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                string a = tb2.Text;
                string SQL = "select WS_DATE,M_NO from MONEYT where WS_DATE = '" + check + "' AND M_NO = '" + a + "'";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["M_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText5 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb2.Focus();
                        }
                    }
                }
                catch
                {

                }
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.MONEYT(WS_DATE, M_NO, M_NAME, M_NAME_E, M_TRAN,USR_NAME) values(@WS_DATE, @M_NO, @M_NAME, @M_NAME_E,@M_TRAN,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@WS_DATE", check);
                cm.Parameters.AddWithValue("@M_NO", tb2.Text);
                cm.Parameters.AddWithValue("@M_NAME", tb3.Text);
                cm.Parameters.AddWithValue("@M_NAME_E", tb4.Text);
                cm.Parameters.AddWithValue("@M_TRAN", float.Parse(tb5.Text));
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
                else if (tb5.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText6 + "");
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
            tb3.Enabled = false;
            tb4.Enabled = false;
            tb5.Enabled = false;

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            bt.Text = "" + txtDuyet + "";
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        public void Check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                check = tb1.Text;
                check = conn.formatstr2(check.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb3, sender, e);
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
            conn.tab_DOWN(tb4, tb1, sender, e);
        }
    }
}
