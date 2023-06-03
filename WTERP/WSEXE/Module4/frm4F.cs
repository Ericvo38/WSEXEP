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
    public partial class Form4F : Form
    {
        DataProvider conn = new DataProvider();
        public Form4F()
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
        string a = "";
        public void check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                a = conn.formatstr2(tb1.Text);
            }     
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
        private void Form4F_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            Load_data();
            Show_data();
            Load_dataview();

            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            btok.Hide();
            btdong.Hide();

            tb2.Enabled = true;
        }
        public void Load_data()
        {
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select WS_DATE, WS_NO, C_NO, C_ANAME, TOTAL from RRCVH";
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();

            foreach (DataRow row in datatable.Rows)
                bindingsource.Add(row);
        }
        public void Show_data()
        {

            DataRow currenRow = (DataRow)bindingsource.Current;

            tb1.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            tb2.Text = currenRow["WS_NO"].ToString();
            tb3.Text = currenRow["C_NO"].ToString();
            tb4.Text = currenRow["C_ANAME"].ToString();
            tb5.Text= currenRow["TOTAL"].ToString();
        }

        public void Load_dataview()
        {
            DataTable dt = new DataTable();
            BindingSource bds = new BindingSource();
            string SQL = "select NR, OR_NO, P_NAME, P_NAME3, CAL_YM, AMOUNT, OVER0, PRICE, BQTY, CA_NO, CA_NR, OR_NR, OR_KNO, OR_DATE from RRCVB where WS_NO='"+tb2.Text+"'";
            dt= conn.readdata(SQL);
            bds.DataSource = dt;
            DGV1.DataSource = bds;
            conn.DGV(DGV1);
            Convert_date_DGV1();
            Convert_Number();
        }
        public void Convert_date_DGV1()
        {
            for (int i = 0; i < DGV1.RowCount - 1; i++)
            {
                string s = DGV1.Rows[i].Cells["CAL_YM"].Value.ToString().Trim();
                string s1 = s.Substring(0, 4);
                string s2 = s.Substring(4,2);
                string s3 = s1 + "/" + s2;
                DGV1.Rows[i].Cells["CAL_YM"].Value = s3;
                string s4 = conn.formatstr1(DGV1.Rows[i].Cells["OR_DATE"].Value.ToString().Trim());
                DGV1.Rows[i].Cells["OR_DATE"].Value = s4;
            }
        }
        public void Convert_Number()
        {
            for (int i = 0; i < DGV1.RowCount - 1; i++)
            {
                string s1 = (Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2)).ToString();
                string s2 = (Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 3)).ToString();
                string s3 = (Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2)).ToString();
                DGV1.Rows[i].Cells["AMOUNT"].Value = s1;
                DGV1.Rows[i].Cells["PRICE"].Value = s2;
                DGV1.Rows[i].Cells["BQTY"].Value = s3;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Load_data();
            Show_data();
            Load_dataview();

            bt.Text = "NÚT DUYỆT";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();

            tb2.Enabled = true;
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();

            Show_data();
            Load_dataview();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MovePrevious();

                Show_data();
                Load_dataview();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MoveNext();

                Show_data();
                Load_dataview();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();

            Show_data();
            Load_dataview();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            Load_dataview();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "THÊM";
            btok.Show();
            btdong.Show();
            DateTime d1 = DateTime.Now;

            tb1.Text = d1.ToString("yyyy/MM/dd");
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "0";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

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

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

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

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            tb2.Enabled = false;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                Add_data();
            }
            else if(f3ToolStripMenuItem.Checked == true)
            {
                Detele_data();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                Upload_data();
            }
        }
        public void Add_data()
        {
            check();
            con = new SqlConnection(st);
            con.Open();
            string st1 = "insert into dbo.RRCVH(WS_DATE, WS_NO, C_NO, C_ANAME, TOTAL)" +
                " values(@WS_DATE, @WS_NO, @C_NO, @C_ANAME, @TOTAL)";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@WS_DATE", a);
            cm.Parameters.AddWithValue("@WS_NO", tb2.Text);
            cm.Parameters.AddWithValue("@C_NO", tb3.Text);
            cm.Parameters.AddWithValue("@C_ANAME", tb4.Text);
            cm.Parameters.AddWithValue("@TOTAL", tb5.Text);

            if (tb2.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Số Biên Nhận");
                return;
            }

            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.  \n" + ex.Message);
            }
            Load_data();
            Show_data();
            Load_dataview();
            btok.Hide();
            btdong.Hide();

            bt.Text = "NÚT DUYỆT";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
    
        }
        public void Detele_data()
        {
            string Mabn = tb2.Text;
            if (Mabn == "")
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            try
            {
                con = new SqlConnection(st);
                con.Open();
                cm = con.CreateCommand();
                cm.CommandText = "delete from RRCVH where WS_NO ='" + Mabn + "'";
                cm.ExecuteNonQuery();
                con.Close();

                Load_data();
                Show_data();
                Load_dataview();
                btok.Hide();
                btdong.Hide();

                bt.Text = "NÚT DUYỆT";
                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                f2ToolStripMenuItem.Checked = false;
                f3ToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
            }
            catch { }
        }
        public void Upload_data()
        {
            check();
            con = new SqlConnection(st);
            con.Open();
            string st1 = "update dbo.RRCVH set WS_DATE =@WS_DATE, WS_NO =@WS_NO,C_NO=@C_NO, C_ANAME =@C_ANAME, TOTAL=@TOTAL where WS_NO= @WS_NO";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@WS_DATE", a);
            cm.Parameters.AddWithValue("@WS_NO", tb2.Text);
            cm.Parameters.AddWithValue("@C_NO", tb3.Text);
            cm.Parameters.AddWithValue("@C_ANAME", tb4.Text);
            cm.Parameters.AddWithValue("@TOTAL", tb5.Text);

            if (tb2.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Má Số Tài Khoản");
                return;
            }

            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.  \n" + ex.Message);
            }

            Load_data();
            Show_data();
            Load_dataview();

            btok.Hide();
            btdong.Hide();

            bt.Text = "NÚT DUYỆT";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            tb2.Enabled = true;
        }

        private void tb2_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                int N = 1;
                string AA = N.ToString("D" + 3);
                string s = a + AA;

                string SQL = "select WS_NO from RRCVH";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (s.ToString() == dr["WSNO"].ToString())
                        {
                            N++;
                            AA = N.ToString("D" + 3);
                            s = a + AA;

                        }
                    }
                }
                catch
                {

                }
                tb2.Text = s;
            }
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();
                string DL = frm2CustSearch.ID.ID_CUST;
                if (DL.ToString() != "")
                {
                    tb3.Text = DL;
                }
                else tb3.Text = "";
            }
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2PF5 fr1 = new frm2PF5();
            fr1.ShowDialog();

            string dl = frm2PF5.SEND_FORM4F.T1;
            if (dl != "")
            {
                string SQL = "select * from RRCVH Where WS_NO ='" + dl + "' ";
                DataTable dt = conn.readdata(SQL);
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dl.ToString() == dr["WS_NO"].ToString())
                        {
                            tb1.Text = conn.formatstr2(dr["WS_DATE"].ToString());
                            tb2.Text = dr["WS_NO"].ToString();
                            tb3.Text = dr["C_NO"].ToString();
                            tb4.Text = dr["C_ANAME"].ToString();
                            tb5.Text = dr["TOTAL"].ToString();
                        
                        }

                    }
                }
                catch { }

            }
            else
            {
                btdong.PerformClick();
            }
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

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
           conn.tab_UP(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb4, tb1, sender, e);
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
