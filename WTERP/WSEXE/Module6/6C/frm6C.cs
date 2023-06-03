using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form6C : Form
    {
        DataProvider conn = new DataProvider();
        public Form6C()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
       
        BindingSource bindingsource;
        DataTable dt = new DataTable();


        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
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
        private void Form6C_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            Load_data();
            Show_data();

            btok.Hide();
            btdong.Hide();

            bt.Text = "NÚT DUYỆT";

            f4ToolStripMenuItem.Checked = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        public void Load_data()
        {
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select * from CONTROL";
            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();

            foreach (DataRow row in dt.Rows)
                bindingsource.Add(row);
        }
        public void Show_data()
        {
            DataRow currenRow = (DataRow)bindingsource.Current;

            tb1.Text = currenRow["COMPANY"].ToString();
            tb2.Text = currenRow["COMPANY1_E"].ToString();
            tb3.Text = currenRow["COMPADR"].ToString();
            tb4.Text = currenRow["COMPTEL"].ToString();
            tb5.Text = currenRow["COMPFAX"].ToString();

            tb6.Text = currenRow["COMPANY1"].ToString();
            tb7.Text = currenRow["COMPANY2_E"].ToString();
            tb8.Text = currenRow["COMPADR1"].ToString();
            tb9.Text = currenRow["COMPTEL1"].ToString();
            tb10.Text = currenRow["COMPFAX1"].ToString();

            tb11.Text = currenRow["COMPANY2"].ToString();
            tb12.Text = currenRow["COMPANY3_E"].ToString();
            tb13.Text = currenRow["COMPADR2"].ToString();
            tb14.Text = currenRow["COMPTEL2"].ToString();
            tb15.Text = currenRow["COMPFAX2"].ToString();

            tb16.Text = currenRow["QT01"].ToString();
            tb17.Text = currenRow["QT02"].ToString();
            tb18.Text = currenRow["RT01"].ToString();
            tb19.Text = currenRow["RT02"].ToString();
            tb20.Text = currenRow["E_HOST"].ToString();

            tb21.Text = currenRow["E_ADDR"].ToString();
            tb22.Text = currenRow["E_USER_ID"].ToString();
            tb23.Text = currenRow["E_PASSWORD"].ToString();
            tb24.Text = currenRow["PLACE1"].ToString();
            tb25.Text = currenRow["PLACE2"].ToString();

            tb26.Text = currenRow["PLACE3"].ToString();
            tb27.Text = currenRow["PLACE4"].ToString();
            tb28.Text = currenRow["PLACE5"].ToString();
            tb29.Text = currenRow["LC01"].ToString();
            tb30.Text = currenRow["LC02"].ToString();

            tb31.Text = currenRow["LC03"].ToString();
            tb32.Text = currenRow["LC04"].ToString();
            tb33.Text = currenRow["LC05"].ToString();
            tb34.Text = currenRow["RC01"].ToString();
            tb35.Text = currenRow["RC02"].ToString();

            tb36.Text = currenRow["RC03"].ToString();
            tb37.Text = currenRow["RC04"].ToString();
            tb38.Text = currenRow["RC05"].ToString();
            tb39.Text = currenRow["LE01"].ToString();
            tb40.Text = currenRow["LE02"].ToString();

            tb41.Text = currenRow["LE03"].ToString();
            tb42.Text = currenRow["LE04"].ToString();
            tb43.Text = currenRow["LE05"].ToString();
            tb44.Text = currenRow["RE01"].ToString();
            tb45.Text = currenRow["RE02"].ToString();

            tb46.Text = currenRow["RE03"].ToString();
            tb47.Text = currenRow["RE04"].ToString();
            tb48.Text = currenRow["RE05"].ToString();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "SỬA";

            f1ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Load_data();
            Show_data();

            btok.Hide();
            btdong.Hide();

            f1ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f4ToolStripMenuItem.Checked = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if(f4ToolStripMenuItem.Checked == true)
            {
                Update_data();
            }
          
        }

        public void Update_data()
        {
            con = new SqlConnection(st);
            con.Open();
            string st1 = "update dbo.CONTROL set COMPANY=@COMPANY, COMPANY1_E =@COMPANY1_E, COMPADR= @COMPADR, COMPTEL=@COMPTEL, COMPFAX =@COMPFAX, COMPANY1=@COMPANY1, COMPANY2_E=@COMPANY2_E, COMPADR1=@COMPADR1," +
                "COMPTEL1=@COMPTEL1, COMPFAX1=@COMPFAX1, COMPANY2=@COMPANY2, COMPANY3_E=@COMPANY3_E, COMPADR2=@COMPADR2, COMPTEL2=@COMPTEL2, COMPFAX2=@COMPFAX2, QT01=@QT01, QT02=@QT02, RT01=@RT01, RT02=@RT02, E_HOST=@E_HOST," +
                "E_ADDR=@E_ADDR, E_USER_ID=@E_USER_ID, E_PASSWORD=@E_PASSWORD, PLACE1=@PLACE1, PLACE2=@PLACE2, PLACE3=@PLACE3, PLACE4=@PLACE4, PLACE5=@PLACE5,  LC01=@LC01, LC02=@LC02, LC03=@LC03, LC04=@LC04, LC05=@LC05, RC01=@RC01," +
                "RC02=@RC02, RC03=@RC03, RC04=@RC04, RC05=@RC05, LE01=@LE01, LE02=@LE02, LE03=@LE03, LE04=@LE04, LE05=@LE05, RE01=@RE01, RE02=@RE02, RE03=@RE03, RE04=@RE04, RE05=@RE05 where COMPANY=@COMPANY";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@COMPANY", tb1.Text);
            cm.Parameters.AddWithValue("@COMPANY1_E", tb2.Text);
            cm.Parameters.AddWithValue("@COMPADR", tb3.Text);
            cm.Parameters.AddWithValue("@COMPTEL", tb4.Text);
            cm.Parameters.AddWithValue("@COMPFAX", tb5.Text);

            cm.Parameters.AddWithValue("@COMPANY1", tb6.Text);
            cm.Parameters.AddWithValue("@COMPANY2_E", tb7.Text);
            cm.Parameters.AddWithValue("@COMPADR1", tb8.Text);
            cm.Parameters.AddWithValue("@COMPTEL1", tb9.Text);
            cm.Parameters.AddWithValue("@COMPFAX1", tb10.Text);

            cm.Parameters.AddWithValue("@COMPANY2", tb11.Text);
            cm.Parameters.AddWithValue("@COMPANY3_E", tb12.Text);
            cm.Parameters.AddWithValue("@COMPADR2", tb13.Text);
            cm.Parameters.AddWithValue("@COMPTEL2", tb14.Text);
            cm.Parameters.AddWithValue("@COMPFAX2", tb15.Text);

            cm.Parameters.AddWithValue("@QT01", tb16.Text);
            cm.Parameters.AddWithValue("@QT02", tb17.Text);
            cm.Parameters.AddWithValue("@RT01", tb18.Text);
            cm.Parameters.AddWithValue("@RT02", tb19.Text);
            cm.Parameters.AddWithValue("@E_HOST", tb20.Text);

            cm.Parameters.AddWithValue("@E_ADDR", tb21.Text);
            cm.Parameters.AddWithValue("@E_USER_ID", tb22.Text);
            cm.Parameters.AddWithValue("@E_PASSWORD", tb23.Text);
            cm.Parameters.AddWithValue("@PLACE1", tb24.Text);
            cm.Parameters.AddWithValue("@PLACE2", tb25.Text);

            cm.Parameters.AddWithValue("@PLACE3", tb26.Text);
            cm.Parameters.AddWithValue("@PLACE4", tb27.Text);
            cm.Parameters.AddWithValue("@PLACE5", tb28.Text);
            cm.Parameters.AddWithValue("@LC01", tb29.Text);
            cm.Parameters.AddWithValue("@LC02", tb30.Text);

            cm.Parameters.AddWithValue("@LC03", tb31.Text);
            cm.Parameters.AddWithValue("@LC04", tb32.Text);
            cm.Parameters.AddWithValue("@LC05", tb33.Text);
            cm.Parameters.AddWithValue("@RC01", tb34.Text);
            cm.Parameters.AddWithValue("@RC02", tb35.Text);

            cm.Parameters.AddWithValue("@RC03", tb36.Text);
            cm.Parameters.AddWithValue("@RC04", tb37.Text);
            cm.Parameters.AddWithValue("@RC05", tb38.Text);
            cm.Parameters.AddWithValue("@LE01", tb39.Text);
            cm.Parameters.AddWithValue("@LE02", tb40.Text);

            cm.Parameters.AddWithValue("@LE03", tb41.Text);
            cm.Parameters.AddWithValue("@LE04", tb42.Text);
            cm.Parameters.AddWithValue("@LE05", tb43.Text);
            cm.Parameters.AddWithValue("@RE01", tb44.Text);
            cm.Parameters.AddWithValue("@RE02", tb45.Text);

            cm.Parameters.AddWithValue("@RE03", tb46.Text);
            cm.Parameters.AddWithValue("@RE04", tb47.Text);
            cm.Parameters.AddWithValue("@RE05", tb48.Text);

            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
                con.Close();

                Load_data();
                Show_data();

                btok.Hide();
                btdong.Hide();

                f1ToolStripMenuItem.Enabled = false;
                f4ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;
                bt.Text = "NÚT DUYỆT";

                f4ToolStripMenuItem.Checked = false;
                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.  \n" + ex.Message);
            }

        }

        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();

            Show_data();
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

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
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

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb48, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb3, sender, e);
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
            tab(tb4, tb6, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb5, tb7, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb8, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb7, tb9, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb8, tb10, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb9, tb11, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb10, tb12, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb11, tb13, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb12, tb14, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb14, tb16, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb16, tb18, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb17, tb19, sender, e);
        }

        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb18, tb20, sender, e);
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb19, tb21, sender, e);
        }

        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb20, tb22, sender, e);
        }

        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb21, tb23, sender, e);
        }

        private void tb23_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb22, tb24, sender, e);
        }

        private void tb24_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb23, tb25, sender, e);
        }

        private void tb25_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb24, tb26, sender, e);
        }

        private void tb26_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb25, tb27, sender, e);
        }

        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb26, tb28, sender, e);
        }

        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb27, tb29, sender, e);
        }

        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb28, tb30, sender, e);
        }

        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb29, tb31, sender, e);
        }

        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb30, tb32, sender, e);
        }
        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb31, tb33, sender, e);
        }

        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb32, tb34, sender, e);
        }

        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb33, tb35, sender, e);
        }

        private void tb35_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb34, tb36, sender, e);
        }

        private void tb36_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb35, tb37, sender, e);
        }

        private void tb37_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb36, tb38, sender, e);
        }

        private void tb38_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb37, tb39, sender, e);
        }

        private void tb39_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb38, tb40, sender, e);
        }

        private void tb40_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb39, tb41, sender, e);
        }

        private void tb41_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb40, tb42, sender, e);
        }

        private void tb42_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb41, tb43, sender, e);
        }

        private void tb43_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb42, tb44, sender, e);
        }

        private void tb44_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb43, tb45, sender, e);
        }

        private void tb45_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb44, tb46, sender, e);
        }

        private void tb46_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb45, tb47, sender, e);
        }

        private void tb47_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb46, tb48, sender, e);
        }

        private void tb48_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb47, tb1, sender, e);
        }
    }
}
