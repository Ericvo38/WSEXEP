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
    public partial class Form6D : Form
    {
        DataProvider DataProvider = new DataProvider();
        public Form6D()
        {
            this.ShowInTaskbar = false;
            DataProvider.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        //DataProvider conn = new DataProvider();
        BindingSource bindingsource;
        DataTable dt = new DataTable();
        
        void loadinfo()
        {
            lbUserName.Text = DataProvider.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void Form6D_Load(object sender, EventArgs e)
        {
            loadinfo();
            Load_data();
            Show_data();

            f1ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            f4ToolStripMenuItem.Checked = false;
            bt.Text = "NÚT LỆNH";
            btok.Hide();
            btdong.Hide();

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
            cm.CommandText = "select * from SYSPARA";
            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();

            foreach (DataRow row in dt.Rows)
                bindingsource.Add(row);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        public void Show_data()
        {
            DataRow currenRow = (DataRow)bindingsource.Current;

            tb1.Text = currenRow["SH_NO"].ToString();
            tb2.Text = currenRow["SING_SHOUS"].ToString();
            tb3.Text = currenRow["AC_ONLINE"].ToString();
            tb4.Text = currenRow["CHK_ONLINE"].ToString();
            tb5.Text = currenRow["MON_AUDIT"].ToString();

            tb6.Text = currenRow["RCV_P_HALF"].ToString();
            tb7.Text = currenRow["COPY_UP"].ToString();
            tb8.Text = currenRow["DATETIME"].ToString();
            tb9.Text = currenRow["RCV_PAGE"].ToString();
            tb10.Text = currenRow["FAXCOMPORT"].ToString();

            tb11.Text = currenRow["STAR_NO"].ToString();
            tb12.Text = currenRow["END_NO"].ToString();
            tb13.Text = currenRow["STAR_NO1"].ToString();
            tb14.Text = currenRow["END_NO1"].ToString();
            tb15.Text = currenRow["STAR_NO2"].ToString();

            tb16.Text = currenRow["END_NO2"].ToString();
            tb17.Text = currenRow["COSTKIND"].ToString();
            tb18.Text = currenRow["FAXBAUDRAT"].ToString();
            tb19.Text = currenRow["STAR_NO3"].ToString();
            tb20.Text = currenRow["END_NO3"].ToString();

            tb21.Text = currenRow["STAR_NO4"].ToString();
            tb22.Text = currenRow["END_NO4"].ToString();
            tb23.Text = currenRow["EXE_PATH"].ToString();
            c24.Text = currenRow["PROD_MONEY"].ToString();
            c25.Text = currenRow["ACT_MONEY"].ToString();

            c26.Text = currenRow["DEFA_MONEY"].ToString();
            tb27.Text = currenRow["PIC_PATH"].ToString();
            tb28.Text = currenRow["MEMO101"].ToString();
            tb29.Text = currenRow["MEMO102"].ToString();
            tb30.Text = currenRow["MEMO103"].ToString();

            tb31.Text = currenRow["MEMO104"].ToString();
            tb32.Text = currenRow["MEMO105"].ToString();
            tb33.Text = currenRow["MEMO106"].ToString();
            tb34.Text = currenRow["MEMO107"].ToString();
            tb35.Text = currenRow["MEMO108"].ToString();

            tb36.Text = currenRow["MEMO109"].ToString();
            tb37.Text = currenRow["MEMO110"].ToString();
            tb38.Text = currenRow["MEMO201"].ToString();
            tb39.Text = currenRow["MEMO202"].ToString();
            tb40.Text = currenRow["MEMO203"].ToString();

            tb41.Text = currenRow["MEMO204"].ToString();
            tb42.Text = currenRow["MEMO205"].ToString();
            tb43.Text = currenRow["MEMO206"].ToString();
            tb44.Text = currenRow["MEMO207"].ToString();
            tb45.Text = currenRow["MEMO208"].ToString();

            //tb46.Text = currenRow[""].ToString();
            tb47.Text = currenRow["MEMO209"].ToString();
            tb48.Text = currenRow["MEMO210"].ToString();
            tb49.Text = currenRow["MEMO301"].ToString();
            tb50.Text = currenRow["MEMO302"].ToString();

            tb51.Text = currenRow["MEMO303"].ToString();
            tb52.Text = currenRow["MEMO304"].ToString();
            tb53.Text = currenRow["MEMO305"].ToString();
            tb54.Text = currenRow["MEMO306"].ToString();
            tb55.Text = currenRow["MEMO307"].ToString();

            tb56.Text = currenRow["MEMO308"].ToString();
            tb57.Text = currenRow["MEMO309"].ToString();
            tb58.Text = currenRow["MEMO310"].ToString();
            tb59.Text = currenRow["P01"].ToString();
            tb60.Text = currenRow["P02"].ToString();

            tb61.Text = currenRow["P03"].ToString();
            tb62.Text = currenRow["P04"].ToString();
            tb63.Text = currenRow["P05"].ToString();
            tb64.Text = currenRow["PM_NO"].ToString();
            tb65.Text = currenRow["TN_NO"].ToString();

            tb66.Text = currenRow["DY_NO"].ToString();
            tb67.Text = currenRow["GD_NO"].ToString();
            tb68.Text = currenRow["PT_NO"].ToString();
            tb69.Text = currenRow["PK_NO"].ToString();
            tb70.Text = currenRow["ST_NO1"].ToString();

            tb71.Text = currenRow["ST_NO2"].ToString();
            tb72.Text = currenRow["PD_NO"].ToString();
            tb73.Text = currenRow["OPEN_QTY"].ToString();

        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
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

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No topic-based help system Installed. \n Không có chức năng hướng dẫn nào được cài đặt!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load_data();
            Show_data();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;

            bt.Text = "SỬA";
            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Load_data();
            Show_data();

            f1ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            f4ToolStripMenuItem.Checked = false;
            bt.Text = "NÚT LỆNH";
            btok.Hide();
            btdong.Hide();

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
            string st1 = "update dbo.SYSPARA set SH_NO=@SH_NO, SING_SHOUS=@SING_SHOUS, AC_ONLINE =@AC_ONLINE, CHK_ONLINE=@CHK_ONLINE, MON_AUDIT=@MON_AUDIT, RCV_P_HALF=@RCV_P_HALF, COPY_UP=@COPY_UP, DATETIME=@DATETIME, RCV_PAGE=@RCV_PAGE, FAXCOMPORT=@FAXCOMPORT," +
                "STAR_NO=@STAR_NO, END_NO=@END_NO, STAR_NO1=@STAR_NO1, END_NO1=@END_NO1, STAR_NO2=@STAR_NO2, COSTKIND=@COSTKIND, FAXBAUDRAT=@FAXBAUDRAT, STAR_NO3=@STAR_NO3, END_NO3=@END_NO3, STAR_NO4=@STAR_NO4, END_NO4=@END_NO4, EXE_PATH=@EXE_PATH, PROD_MONEY=@PROD_MONEY," +
                "ACT_MONEY=@ACT_MONEY, DEFA_MONEY=@DEFA_MONEY, PIC_PATH=@PIC_PATH, MEMO101=@MEMO101, MEMO102=@MEMO102, MEMO103=@MEMO103, MEMO104=@MEMO104, MEMO105=@MEMO105, MEMO106=@MEMO106, MEMO107=@MEMO107, MEMO108=@MEMO108, MEMO109=@MEMO109, MEMO110=@MEMO110," +
                "MEMO201=@MEMO201, MEMO202=@MEMO202, MEMO203=@MEMO203, MEMO204=@MEMO204, MEMO205=@MEMO205, MEMO206=@MEMO206, MEMO207=@MEMO207, MEMO208=@MEMO208, MEMO209=@MEMO209, MEMO210=@MEMO210, MEMO301=@MEMO301, MEMO302=@MEMO302, MEMO303=@MEMO303, MEMO304=@MEMO304," +
                "MEMO305=@MEMO305, MEMO306=@MEMO306, MEMO307=@MEMO307, MEMO308=@MEMO308, MEMO309=@MEMO309, MEMO310=@MEMO310, P01=@P01, P02=@P02, P03=@P03, P04=@P04, P05=@P05, PM_NO=@PM_NO, TN_NO=@TN_NO, DY_NO=@DY_NO, GD_NO=@GD_NO, PT_NO=@PT_NO, PK_NO=@PK_NO, ST_NO1=@ST_NO1," +
                "ST_NO2=@ST_NO2, PD_NO=@PD_NO, OPEN_QTY=@OPEN_QTY  where SH_NO=@SH_NO";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@SH_NO", tb1.Text);
            cm.Parameters.AddWithValue("@SING_SHOUS", tb2.Text);
            cm.Parameters.AddWithValue("@AC_ONLINE", tb3.Text);
            cm.Parameters.AddWithValue("@CHK_ONLINE", tb4.Text);
            cm.Parameters.AddWithValue("@MON_AUDIT", tb5.Text);

            cm.Parameters.AddWithValue("@RCV_P_HALF", tb6.Text);
            cm.Parameters.AddWithValue("@COPY_UP", tb7.Text);
            cm.Parameters.AddWithValue("@DATETIME", tb8.Text);
            cm.Parameters.AddWithValue("@RCV_PAGE", tb9.Text);
            cm.Parameters.AddWithValue("@FAXCOMPORT", tb10.Text);

            cm.Parameters.AddWithValue("@STAR_NO", tb11.Text);
            cm.Parameters.AddWithValue("@END_NO", tb12.Text);
            cm.Parameters.AddWithValue("@STAR_NO1", tb13.Text);
            cm.Parameters.AddWithValue("@END_NO1", tb14.Text);
            cm.Parameters.AddWithValue("@STAR_NO2", tb15.Text);

            cm.Parameters.AddWithValue("@END_NO2", tb16.Text);
            cm.Parameters.AddWithValue("@COSTKIND", tb17.Text);
            cm.Parameters.AddWithValue("@FAXBAUDRAT", tb18.Text);
            cm.Parameters.AddWithValue("@STAR_NO3", tb19.Text);
            cm.Parameters.AddWithValue("@END_NO3", tb20.Text);

            cm.Parameters.AddWithValue("@STAR_NO4", tb21.Text);
            cm.Parameters.AddWithValue("@END_NO4", tb22.Text);
            cm.Parameters.AddWithValue("@EXE_PATH", tb23.Text);
            cm.Parameters.AddWithValue("@PROD_MONEY", c24.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@ACT_MONEY", c25.SelectedItem.ToString());

            cm.Parameters.AddWithValue("@DEFA_MONEY", c26.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@PIC_PATH", tb27.Text);
            cm.Parameters.AddWithValue("@MEMO101", tb28.Text);
            cm.Parameters.AddWithValue("@MEMO102", tb29.Text);
            cm.Parameters.AddWithValue("@MEMO103", tb30.Text);

            cm.Parameters.AddWithValue("@MEMO104", tb31.Text);
            cm.Parameters.AddWithValue("@MEMO105", tb32.Text);
            cm.Parameters.AddWithValue("@MEMO106", tb33.Text);
            cm.Parameters.AddWithValue("@MEMO107", tb34.Text);
            cm.Parameters.AddWithValue("@MEMO108", tb35.Text);

            cm.Parameters.AddWithValue("@MEMO109", tb36.Text);
            cm.Parameters.AddWithValue("@MEMO110", tb37.Text);
            cm.Parameters.AddWithValue("@MEMO201", tb38.Text);
            cm.Parameters.AddWithValue("@MEMO202", tb39.Text);
            cm.Parameters.AddWithValue("@MEMO203", tb40.Text);

            cm.Parameters.AddWithValue("@MEMO204", tb41.Text);
            cm.Parameters.AddWithValue("@MEMO205", tb42.Text);
            cm.Parameters.AddWithValue("@MEMO206", tb43.Text);
            cm.Parameters.AddWithValue("@MEMO207", tb44.Text);
            cm.Parameters.AddWithValue("@MEMO208", tb45.Text);

            //cm.Parameters.AddWithValue("@", tb46.Text);
            cm.Parameters.AddWithValue("@MEMO209", tb47.Text);
            cm.Parameters.AddWithValue("@MEMO210", tb48.Text);
            cm.Parameters.AddWithValue("@MEMO301", tb49.Text);
            cm.Parameters.AddWithValue("@MEMO302", tb50.Text);

            cm.Parameters.AddWithValue("@MEMO303", tb51.Text);
            cm.Parameters.AddWithValue("@MEMO304", tb52.Text);
            cm.Parameters.AddWithValue("@MEMO305", tb53.Text);
            cm.Parameters.AddWithValue("@MEMO306", tb54.Text);
            cm.Parameters.AddWithValue("@MEMO307", tb55.Text);

            cm.Parameters.AddWithValue("@MEMO308", tb56.Text);
            cm.Parameters.AddWithValue("@MEMO309", tb57.Text);
            cm.Parameters.AddWithValue("@MEMO310", tb58.Text);
            cm.Parameters.AddWithValue("@P01", tb59.Text);
            cm.Parameters.AddWithValue("@P02", tb60.Text);

            cm.Parameters.AddWithValue("@P03", tb61.Text);
            cm.Parameters.AddWithValue("@P04", tb62.Text);
            cm.Parameters.AddWithValue("@P05", tb63.Text);
            cm.Parameters.AddWithValue("@PM_NO", tb64.Text);
            cm.Parameters.AddWithValue("@TN_NO", tb65.Text);

            cm.Parameters.AddWithValue("@DY_NO", tb66.Text);
            cm.Parameters.AddWithValue("@GD_NO", tb67.Text);
            cm.Parameters.AddWithValue("@PT_NO", tb68.Text);
            cm.Parameters.AddWithValue("@PK_NO", tb69.Text);
            cm.Parameters.AddWithValue("@ST_NO1", tb70.Text);

            cm.Parameters.AddWithValue("@ST_NO2", tb71.Text);
            cm.Parameters.AddWithValue("@PD_NO", tb72.Text);
            cm.Parameters.AddWithValue("@OPEN_QTY", tb73.Text);
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
                con.Close();
                Load_data();
                Show_data();

                f1ToolStripMenuItem.Enabled = false;
                f4ToolStripMenuItem.Enabled = true;
                f8ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                f4ToolStripMenuItem.Checked = false;
                bt.Text = "NÚT LỆNH";
                btok.Hide();
                btdong.Hide();

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            tab(tb73, tb2, sender, e);
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

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
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
            tab(tb22, tb27, sender, e);
        }

        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb23, tb28, sender, e);
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
            tab(tb44, tb47, sender, e);
        }

        private void tb47_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb45, tb48, sender, e);
        }

        private void tb48_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb47, tb49, sender, e);
        }

        private void tb49_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb48, tb50, sender, e);
        }
        private void tb50_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb49, tb51, sender, e);
        }
        private void tb51_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb50, tb52, sender, e);
        }
        private void tb52_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb51, tb53, sender, e);
        }
        private void tb53_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb52, tb54, sender, e);
        }
        private void tb54_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb53, tb55, sender, e);
        }
        private void tb55_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb54, tb56, sender, e);
        }

        private void tb56_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb55, tb57, sender, e);
        }
        private void tb57_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb56, tb58, sender, e);
        }

        private void tb58_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb57, tb59, sender, e);
        }

        private void tb60_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb59, tb61, sender, e);
        }
        private void tb59_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb58, tb60, sender, e);
        }
        private void tb61_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb60, tb62, sender, e);
        }

        private void tb62_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb61, tb63, sender, e);
        }
        private void tb63_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb62, tb64, sender, e);
        }

        private void tb64_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb63, tb65, sender, e);
        }

        private void tb65_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb64, tb66, sender, e);
        }

        private void tb66_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb65, tb67, sender, e);
        }

        private void tb67_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb66, tb68, sender, e);
        }

        private void tb68_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb67, tb69, sender, e);
        }

        private void tb69_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb68, tb70, sender, e);
        }

        private void tb70_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb69, tb71, sender, e);
        }

        private void tb71_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb70, tb72, sender, e);
        }

        private void tb72_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb71, tb73, sender, e);
        }
        private void tb73_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb71, tb1, sender, e);
        }
    }
    
}
