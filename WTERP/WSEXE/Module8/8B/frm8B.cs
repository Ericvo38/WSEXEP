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
    public partial class Form8B : Form
    {
        DataProvider conn = new DataProvider();
        public Form8B()
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

        private void Form8B_Load(object sender, EventArgs e)
        {
            //phan quyền
            conn.CheckLoad(menuStrip1);
            loadinfo();
            Load_Data();
            Show_Data();


            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;


            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            conn.DGV(dataF8B);
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        public void Load_Data()
        {
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "SELECT DEPT_NO, DEPT_NAME, SH_NO, SH_NAME FROM DEPT";
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataF8B.DataSource = bindingsource;
        }
        public void Show_Data()
        {
            tb1.Text = dataF8B.Rows[0].Cells["DEPT_NO"].Value.ToString();
            tb2.Text = dataF8B.Rows[0].Cells["DEPT_NAME"].Value.ToString();
            tb3.Text = dataF8B.Rows[0].Cells["SH_NO"].Value.ToString();
            tb4.Text = dataF8B.Rows[0].Cells["SH_NAME"].Value.ToString();   
        }

        public void Show_click_Data()
        {
            this.tb1.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[3].Value.ToString();
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "THÊM";
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "XÓA";
            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "SỬA";
            btok.Show();
            btdong.Show();

            tb1.Enabled = false;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;
            MessageBox.Show("Bạn Cần Thay Đổi Mã Bộ Phận Với 4 Ký Tự", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //tb1.Focus();
            bt.Text = "COPY";
            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataF8B.ClearSelection();
            dataF8B.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dataF8B.DataSource = bindingsource;
            bindingsource.MoveFirst();

            Show_click_Data();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataF8B.CurrentRow.Index;
                if (dataF8B.Rows.Count > IndexNow)
                {
                    dataF8B.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataF8B.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }

            Show_click_Data();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataF8B.CurrentRow.Index;
                if (dataF8B.Rows.Count > IndexNow)
                {
                    dataF8B.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataF8B.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }

            Show_click_Data();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            dataF8B.ClearSelection();
            int so = dataF8B.Rows.Count - 1;
            dataF8B.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataF8B.DataSource = bindingsource;
            bindingsource.MoveLast();

            Show_click_Data();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void dataF8B_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb1.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[1].Value.ToString();
            this.tb3.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[2].Value.ToString();
            this.tb4.Text = dataF8B.Rows[dataF8B.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.DEPT (DEPT_NO, DEPT_NAME, SH_NO, SH_NAME) values (@DEPT_NO, @DEPT_NAME, @SH_NO, @SH_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@DEPT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@SH_NO", tb3.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb4.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("Bạn Chưa Nhập Mã Bộ Phận");
                    return;
                }
                try
                {
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!");
                    con.Close();
                    btok.Hide();
                    btdong.Hide();

                    Load_Data();
                    Show_click_Data();

                    tb1.Enabled = true;
                    tb2.Enabled = true;
                    tb3.Enabled = true;
                    tb4.Enabled = true;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = false;
                    bttruoc.Enabled = false;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "NÚT DUYỆT";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi.  \n" + ex.Message);
                }
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string t = tb1.Text;
                if (t == "")
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from DEPT where DEPT_NO ='" + t + "'";
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Bạn Đã Xóa Thành công");
                    con.Close();

                    Load_Data();
                    Show_click_Data();

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = false;
                    bttruoc.Enabled = false;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "NÚT DUYỆT";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                    btok.Hide();
                    btdong.Hide();
                }

                catch
                {
                    MessageBox.Show("Xảy ra lỗi \n Vui Lòng Kiểm Tra Lại");
                }

            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.DEPT set DEPT_NO = @DEPT_NO, DEPT_NAME = @DEPT_NAME, SH_NO = @SH_NO, SH_NAME= @SH_NAME where DEPT_NO = @DEPT_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@DEPT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@SH_NO", tb3.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb4.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("Bạn Chưa Nhập Mã Bộ Phận");
                    return;
                }
                try
                {
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    con.Close();

                    btok.Hide();
                    btdong.Hide();

                    Load_Data();
                    Show_click_Data();

                    tb1.Enabled = true;
                    tb2.Enabled = true;
                    tb3.Enabled = true;
                    tb4.Enabled = true;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = false;
                    bttruoc.Enabled = false;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "NÚT DUYỆT";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi \n Vui Lòng Kiểm Tra Lại");
                }
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                string a = tb1.Text;
                string SQL = "select DEPT_NO from DEPT";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["DEPT_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("Mã Bộ Phận Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                string st1 = "insert into dbo.DEPT (DEPT_NO, DEPT_NAME, SH_NO, SH_NAME) values (@DEPT_NO, @DEPT_NAME, @SH_NO, @SH_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@DEPT_NO", tb1.Text);
                cm.Parameters.AddWithValue("@DEPT_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@SH_NO", tb3.Text);
                cm.Parameters.AddWithValue("@SH_NAME", tb4.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("Bạn Chưa Nhập Mã Bộ Phận");
                    return;
                }
                try
                {
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!");
                    con.Close();

                    btok.Hide();
                    btdong.Hide();

                    Load_Data();
                    Show_click_Data();

                    tb1.Enabled = true;
                    tb2.Enabled = true;
                    tb3.Enabled = true;
                    tb4.Enabled = true;

                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f8ToolStripMenuItem.Enabled = true;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = false;
                    bttruoc.Enabled = false;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "NÚT DUYỆT";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi.  \n" + ex.Message);
                }

            }

        }




    }
}
