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
    public partial class Form6E : Form
    {
        DataProvider conn = new DataProvider();
        public Form6E()
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

        private void Form6E_Load(object sender, EventArgs e)
        {
                conn.CheckLoad(menuStrip1);
                Load_data();
                Show_data();

                bt.Text = "NÚT DUYỆT";
                btok.Hide();
                btdong.Hide();

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                f2ThêmToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f5TìmKiếmToolStripMenuItem.Checked = false;

                t1.Enabled = true;
                tb1.Enabled = true;

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
        public void Load_data()
        {
            loadinfo();
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select * from TAXRAT";
            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();

            foreach (DataRow row in dt.Rows)
                bindingsource.Add(row);
        }
        public void Show_data()
        {
          
                DataRow currenRow = (DataRow)bindingsource.Current;
        
                t1.Text = currenRow["WS_KD"].ToString();
                tb1.Text = currenRow["WS_KIND"].ToString();
                tb2.Text = currenRow["T_NAME"].ToString();
                tb3.Text = currenRow["T_RATE"].ToString();
                tb4.Text = currenRow["QTY_DEC"].ToString();
                tb5.Text = currenRow["BQTY_DEC"].ToString();
                tb6.Text = currenRow["COST_DEC"].ToString();

                tb7.Text = currenRow["PRICE_DEC"].ToString();
                tb8.Text = currenRow["AMOUNT_DEC"].ToString();
                tb9.Text = currenRow["TAX_DEC"].ToString();
                tb10.Text = currenRow["TOTAL_DEC"].ToString();
                tb11.Text = currenRow["AUTO_NO_NUM"].ToString();

                tb12.Text = currenRow["AUTO_NO"].ToString();
                tb13.Text = currenRow["LEAD_CHAR"].ToString();
                tb14.Text = currenRow["ADD_CONT"].ToString();
                tb15.Text = currenRow["M_PNAME"].ToString();
                tb16.Text = currenRow["DEC_45"].ToString();

                tb17.Text = currenRow["COST_LOCK"].ToString();
                tb18.Text = currenRow["NO_QTYSTOR"].ToString();
                tb19.Text = currenRow["COUNT_TAX"].ToString();
                tb20.Text = currenRow["M_COST"].ToString();
                tb21.Text = currenRow["QTY_DISP"].ToString();

                tb22.Text = currenRow["HIS_PRICE"].ToString();
                tb23.Text = currenRow["GC_NAME_CH"].ToString();
                tb24.Text = currenRow["MEMO01"].ToString();
                tb25.Text = currenRow["MEMO02"].ToString();
                tb26.Text = currenRow["MEMO03"].ToString();

                tb27.Text = currenRow["MEMO04"].ToString();
                tb28.Text = currenRow["MEMO05"].ToString();
                tb29.Text = currenRow["MEMO06"].ToString();
                tb30.Text = currenRow["MEMO07"].ToString();
                tb31.Text = currenRow["MEMO08"].ToString();

                tb32.Text = currenRow["MEMO09"].ToString();
                tb33.Text = currenRow["MEMO10"].ToString();
                tb34.Text = currenRow["Q_INDEX"].ToString();
                tb35.Text = currenRow["GRIDCOL01"].ToString();
                tb36.Text = currenRow["GRIDCOL02"].ToString();
                tb37.Text = currenRow["GRIDCOL03"].ToString();
                tb38.Text = currenRow["GRIDCOL04"].ToString();

                tb39.Text = currenRow["GRIDCOL05"].ToString();
                tb40.Text = currenRow["GRIDCOL06"].ToString();
                tb41.Text = currenRow["GRIDCOL07"].ToString();
                tb42.Text = currenRow["GRIDCOL08"].ToString();
                tb43.Text = currenRow["GRIDCOL09"].ToString();

                tb44.Text = currenRow["GRIDCOL10"].ToString();
                tb45.Text = currenRow["GC_NAME01"].ToString();
                tb46.Text = currenRow["GC_NAME02"].ToString();
                tb47.Text = currenRow["GC_NAME03"].ToString();
                tb48.Text = currenRow["GC_NAME04"].ToString();

                tb49.Text = currenRow["GC_NAME05"].ToString();
                tb50.Text = currenRow["GC_NAME06"].ToString();
                tb51.Text = currenRow["GC_NAME07"].ToString();
                tb52.Text = currenRow["GC_NAME08"].ToString();
                tb53.Text = currenRow["GC_NAME09"].ToString();

                tb54.Text = currenRow["GC_NAME10"].ToString();
                tb55.Text = currenRow["GRIDCOL11"].ToString();
                tb56.Text = currenRow["GRIDCOL12"].ToString();
                tb57.Text = currenRow["GRIDCOL13"].ToString();
                tb58.Text = currenRow["GRIDCOL14"].ToString();

                tb59.Text = currenRow["GRIDCOL15"].ToString();
                tb60.Text = currenRow["GRIDCOL16"].ToString();
                tb61.Text = currenRow["GRIDCOL17"].ToString();
                tb62.Text = currenRow["GRIDCOL18"].ToString();
                tb63.Text = currenRow["GRIDCOL19"].ToString();

                tb65.Text = currenRow["GRIDCOL20"].ToString();
                tb66.Text = currenRow["GC_NAME11"].ToString();
                tb67.Text = currenRow["GC_NAME12"].ToString();
                tb68.Text = currenRow["GC_NAME13"].ToString();

                tb69.Text = currenRow["GC_NAME14"].ToString();
                tb70.Text = currenRow["GC_NAME15"].ToString();
                tb71.Text = currenRow["GC_NAME16"].ToString();
                tb72.Text = currenRow["GC_NAME17"].ToString();
                tb73.Text = currenRow["GC_NAME18"].ToString();
                tb74.Text = currenRow["GC_NAME19"].ToString();
                tb75.Text = currenRow["GC_NAME20"].ToString();
   
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btdong.PerformClick();
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
            tb2.Focus();
            t1.Enabled = false;
            tb1.Enabled = false;

            btok.Show();
            btdong.Show();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ThêmToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5TìmKiếmToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void f2ThêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ThêmToolStripMenuItem.Checked = true;
            bt.Text = "THÊM";
            tb1.Focus();
            t1.Text = "";
            tb1.Text = "";
            tb2.Text = "";

            btok.Show();
            btdong.Show();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ThêmToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5TìmKiếmToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Load_data();
            Show_data();

            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ThêmToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ThêmToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5TìmKiếmToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            t1.Enabled = true;
            tb1.Enabled = true;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            if (f2ThêmToolStripMenuItem.Checked == true)
            {
                Insert_data();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                Update_data();
            }
        }
        public void Insert_data()
        {
            con = new SqlConnection(st);
            con.Open(); 
            string st1 = "insert into dbo.TAXRAT(WS_KD, WS_KIND, T_NAME, T_RATE, QTY_DEC, BQTY_DEC, COST_DEC, PRICE_DEC, AMOUNT_DEC, TAX_DEC, TOTAL_DEC, AUTO_NO_NUM, AUTO_NO, LEAD_CHAR, ADD_CONT, M_PNAME, DEC_45, COST_LOCK, NO_QTYSTOR, COUNT_TAX, M_COST, QTY_DISP, HIS_PRICE, GC_NAME_CH," +
                "MEMO01, MEMO02, MEMO03, MEMO04, MEMO05, MEMO06, MEMO07, MEMO08, MEMO09, MEMO10, Q_INDEX, GRIDCOL01, GRIDCOL02, GRIDCOL03, GRIDCOL04, GRIDCOL05, GRIDCOL06, GRIDCOL07, GRIDCOL08, GRIDCOL09, GRIDCOL10, GC_NAME01, GC_NAME02, GC_NAME03, GC_NAME04, GC_NAME05, GC_NAME06, GC_NAME07, GC_NAME08," +
                "GC_NAME09, GC_NAME10, GRIDCOL11, GRIDCOL12, GRIDCOL13, GRIDCOL14, GRIDCOL15, GRIDCOL16, GRIDCOL17, GRIDCOL18, GRIDCOL19, GRIDCOL20, GC_NAME11, GC_NAME12, GC_NAME13, GC_NAME14, GC_NAME15, GC_NAME16, GC_NAME17, GC_NAME18, GC_NAME19, GC_NAME20)" +
                " values(@WS_KD,@WS_KIND, @T_NAME, @T_RATE, @QTY_DEC, @BQTY_DEC, @COST_DEC, @PRICE_DEC, @AMOUNT_DEC, @TAX_DEC, @TOTAL_DEC, @AUTO_NO_NUM, @AUTO_NO, @LEAD_CHAR, @ADD_CONT, @M_PNAME, @DEC_45, @COST_LOCK, @NO_QTYSTOR, @COUNT_TAX, @M_COST, @QTY_DISP, @HIS_PRICE, @GC_NAME_CH," +
                "@MEMO01, @MEMO02, @MEMO03, @MEMO04, @MEMO05, @MEMO06, @MEMO07, @MEMO08, @MEMO09, @MEMO10, @Q_INDEX, @GRIDCOL01, @GRIDCOL02, @GRIDCOL03, @GRIDCOL04, @GRIDCOL05, @GRIDCOL06, @GRIDCOL07, @GRIDCOL08, @GRIDCOL09, @GRIDCOL10, @GC_NAME01, @GC_NAME02, @GC_NAME03, @GC_NAME04, @GC_NAME05, @GC_NAME06, @GC_NAME07, @GC_NAME08," +
                "@GC_NAME09, @GC_NAME10, @GRIDCOL11, @GRIDCOL12, @GRIDCOL13, @GRIDCOL14, @GRIDCOL15, @GRIDCOL16, @GRIDCOL17, @GRIDCOL18, @GRIDCOL19, @GRIDCOL20, @GC_NAME11, @GC_NAME12, @GC_NAME13, @GC_NAME14, @GC_NAME15, @GC_NAME16, @GC_NAME17, @GC_NAME18, @GC_NAME19, @GC_NAME20)";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@WS_KD", t1.Text);
            cm.Parameters.AddWithValue("@WS_KIND", tb1.Text);
            cm.Parameters.AddWithValue("@T_NAME", tb2.Text);
            cm.Parameters.AddWithValue("@T_RATE", tb3.Text);
            cm.Parameters.AddWithValue("@QTY_DEC", tb4.Text);
            cm.Parameters.AddWithValue("@BQTY_DEC", tb5.Text);

            cm.Parameters.AddWithValue("@COST_DEC", tb6.Text);
            cm.Parameters.AddWithValue("@PRICE_DEC", tb7.Text);
            cm.Parameters.AddWithValue("@AMOUNT_DEC", tb8.Text);
            cm.Parameters.AddWithValue("@TAX_DEC", tb9.Text);
            cm.Parameters.AddWithValue("@TOTAL_DEC", tb10.Text);

            cm.Parameters.AddWithValue("@AUTO_NO_NUM", tb11.Text);
            cm.Parameters.AddWithValue("@AUTO_NO", tb12.Text);
            cm.Parameters.AddWithValue("@LEAD_CHAR", tb13.Text);
            cm.Parameters.AddWithValue("@ADD_CONT", tb14.Text);
            cm.Parameters.AddWithValue("@M_PNAME", tb15.Text);

            cm.Parameters.AddWithValue("@DEC_45", tb16.Text);
            cm.Parameters.AddWithValue("@COST_LOCK", tb17.Text);
            cm.Parameters.AddWithValue("@NO_QTYSTOR", tb18.Text);
            cm.Parameters.AddWithValue("@COUNT_TAX", tb19.Text);
            cm.Parameters.AddWithValue("@M_COST", tb20.Text);

            cm.Parameters.AddWithValue("@QTY_DISP", tb21.Text);
            cm.Parameters.AddWithValue("@HIS_PRICE", tb22.Text);
            cm.Parameters.AddWithValue("@GC_NAME_CH", tb23.Text);
            cm.Parameters.AddWithValue("@MEMO01", tb24.Text);
            cm.Parameters.AddWithValue("@MEMO02", tb25.Text);

            cm.Parameters.AddWithValue("@MEMO03", tb26.Text);
            cm.Parameters.AddWithValue("@MEMO04", tb27.Text);
            cm.Parameters.AddWithValue("@MEMO05", tb28.Text);
            cm.Parameters.AddWithValue("@MEMO06", tb29.Text);
            cm.Parameters.AddWithValue("@MEMO07", tb30.Text);

            cm.Parameters.AddWithValue("@MEMO08", tb31.Text);
            cm.Parameters.AddWithValue("@MEMO09", tb32.Text);
            cm.Parameters.AddWithValue("@MEMO10", tb33.Text);

            cm.Parameters.AddWithValue("@Q_INDEX", tb34.Text);
            cm.Parameters.AddWithValue("@GRIDCOL01", tb35.Text);
            cm.Parameters.AddWithValue("@GRIDCOL02", tb36.Text);

            cm.Parameters.AddWithValue("@GRIDCOL03", tb37.Text);
            cm.Parameters.AddWithValue("@GRIDCOL04", tb38.Text);
            cm.Parameters.AddWithValue("@GRIDCOL05", tb39.Text);
            cm.Parameters.AddWithValue("@GRIDCOL06", tb40.Text);
            cm.Parameters.AddWithValue("@GRIDCOL07", tb41.Text);

            cm.Parameters.AddWithValue("@GRIDCOL08", tb42.Text);
            cm.Parameters.AddWithValue("@GRIDCOL09", tb43.Text);
            cm.Parameters.AddWithValue("@GRIDCOL10", tb44.Text);
            cm.Parameters.AddWithValue("@GC_NAME01", tb45.Text);
            cm.Parameters.AddWithValue("@GC_NAME02", tb46.Text);

            cm.Parameters.AddWithValue("@GC_NAME03", tb47.Text);
            cm.Parameters.AddWithValue("@GC_NAME04", tb48.Text);
            cm.Parameters.AddWithValue("@GC_NAME05", tb49.Text);
            cm.Parameters.AddWithValue("@GC_NAME06", tb50.Text);
            cm.Parameters.AddWithValue("@GC_NAME07", tb51.Text);

            cm.Parameters.AddWithValue("@GC_NAME08", tb52.Text);
            cm.Parameters.AddWithValue("@GC_NAME09", tb53.Text);
            cm.Parameters.AddWithValue("@GC_NAME10", tb54.Text);
            cm.Parameters.AddWithValue("@GRIDCOL11", tb55.Text);
            cm.Parameters.AddWithValue("@GRIDCOL12", tb56.Text);

            cm.Parameters.AddWithValue("@GRIDCOL13", tb57.Text);
            cm.Parameters.AddWithValue("@GRIDCOL14", tb58.Text);
            cm.Parameters.AddWithValue("@GRIDCOL15", tb59.Text);
            cm.Parameters.AddWithValue("@GRIDCOL16", tb60.Text);
            cm.Parameters.AddWithValue("@GRIDCOL17", tb61.Text);

            cm.Parameters.AddWithValue("@GRIDCOL18", tb62.Text);
            cm.Parameters.AddWithValue("@GRIDCOL19", tb63.Text);
            cm.Parameters.AddWithValue("@GRIDCOL20", tb65.Text);
            cm.Parameters.AddWithValue("@GC_NAME11", tb66.Text);
            cm.Parameters.AddWithValue("@GC_NAME12", tb67.Text);

            cm.Parameters.AddWithValue("@GC_NAME13", tb68.Text);
            cm.Parameters.AddWithValue("@GC_NAME14", tb69.Text);
            cm.Parameters.AddWithValue("@GC_NAME15", tb70.Text);
            cm.Parameters.AddWithValue("@GC_NAME16", tb71.Text);
            cm.Parameters.AddWithValue("@GC_NAME17", tb72.Text);
            
            cm.Parameters.AddWithValue("@GC_NAME18", tb73.Text);
            cm.Parameters.AddWithValue("@GC_NAME19", tb74.Text);
            cm.Parameters.AddWithValue("@GC_NAME20", tb75.Text);
        
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!");
                con.Close();

                Load_data();
                Show_data();

                bt.Text = "NÚT DUYỆT";
                btok.Hide();
                btdong.Hide();

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                f2ThêmToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f5TìmKiếmToolStripMenuItem.Checked = false;

                f1ToolStripMenuItem.Enabled = false;
                f2ThêmToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5TìmKiếmToolStripMenuItem.Enabled = true;
                f8ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi.  \n" + ex.Message);
            }
          
        }
        public void Update_data()
        {
            con = new SqlConnection(st);
            con.Open();
            string st1 = "update TAXRAT set WS_KD=@WS_KD, WS_KIND=@WS_KIND, T_NAME=@T_NAME, T_RATE=@T_RATE, QTY_DEC=@QTY_DEC, BQTY_DEC=@BQTY_DEC, COST_DEC=@COST_DEC, PRICE_DEC=@PRICE_DEC, AMOUNT_DEC=@AMOUNT_DEC, TAX_DEC=@TAX_DEC, TOTAL_DEC=@TOTAL_DEC, AUTO_NO_NUM=@AUTO_NO_NUM, AUTO_NO=@AUTO_NO, LEAD_CHAR=@LEAD_CHAR, ADD_CONT=@ADD_CONT, M_PNAME=@M_PNAME, DEC_45=@DEC_45, COST_LOCK=@COST_LOCK, NO_QTYSTOR=@NO_QTYSTOR, COUNT_TAX=@COUNT_TAX, M_COST=@M_COST, QTY_DISP=@QTY_DISP, HIS_PRICE=@HIS_PRICE, GC_NAME_CH=@GC_NAME_CH," +
                "MEMO01=@MEMO01, MEMO02=@MEMO02, MEMO03=@MEMO03, MEMO04=@MEMO04, MEMO05=@MEMO05, MEMO06=@MEMO06, MEMO07=@MEMO07, MEMO08=@MEMO08, MEMO09=@MEMO09, MEMO10=@MEMO10, Q_INDEX=@Q_INDEX, GRIDCOL01=@GRIDCOL01, GRIDCOL02=@GRIDCOL02, GRIDCOL03=@GRIDCOL03, GRIDCOL04=@GRIDCOL04, GRIDCOL05=@GRIDCOL05, GRIDCOL06=@GRIDCOL06, GRIDCOL07=@GRIDCOL07, GRIDCOL08=@GRIDCOL08, GRIDCOL09=@GRIDCOL09, GRIDCOL10=@GRIDCOL10, GC_NAME01=@GC_NAME01, GC_NAME02=@GC_NAME02, GC_NAME03=@GC_NAME03, GC_NAME04=@GC_NAME04, GC_NAME05=@GC_NAME05, GC_NAME06=@GC_NAME06, GC_NAME07=@GC_NAME07, GC_NAME08=GC_NAME08," +
                "GC_NAME09=@GC_NAME09, GC_NAME10=@GC_NAME10, GRIDCOL11=@GRIDCOL11, GRIDCOL12=@GRIDCOL12, GRIDCOL13=@GRIDCOL13, GRIDCOL14=@GRIDCOL14, GRIDCOL15=@GRIDCOL15, GRIDCOL16=@GRIDCOL16, GRIDCOL17=@GRIDCOL17, GRIDCOL18=@GRIDCOL18, GRIDCOL19=@GRIDCOL19, GRIDCOL20=@GRIDCOL20, GC_NAME11=@GC_NAME11, GC_NAME12=@GC_NAME12, GC_NAME13=@GC_NAME13, GC_NAME14=@GC_NAME14, GC_NAME15=@GC_NAME15, GC_NAME16=@GC_NAME16, GC_NAME17=@GC_NAME17, GC_NAME18=@GC_NAME18, GC_NAME19=@GC_NAME19, GC_NAME20=@GC_NAME20 WHERE WS_KD=@WS_KD AND WS_KIND=@WS_KIND";
                
            SqlCommand cm = new SqlCommand(st1, con);
            cm.Parameters.AddWithValue("@WS_KD", t1.Text);
            cm.Parameters.AddWithValue("@WS_KIND", tb1.Text);
            cm.Parameters.AddWithValue("@T_NAME", tb2.Text);
            cm.Parameters.AddWithValue("@T_RATE", tb3.Text);
            cm.Parameters.AddWithValue("@QTY_DEC", tb4.Text);
            cm.Parameters.AddWithValue("@BQTY_DEC", tb5.Text);

            cm.Parameters.AddWithValue("@COST_DEC", tb6.Text);
            cm.Parameters.AddWithValue("@PRICE_DEC", tb7.Text);
            cm.Parameters.AddWithValue("@AMOUNT_DEC", tb8.Text);
            cm.Parameters.AddWithValue("@TAX_DEC", tb9.Text);
            cm.Parameters.AddWithValue("@TOTAL_DEC", tb10.Text);

            cm.Parameters.AddWithValue("@AUTO_NO_NUM", tb11.Text);
            cm.Parameters.AddWithValue("@AUTO_NO", tb12.Text);
            cm.Parameters.AddWithValue("@LEAD_CHAR", tb13.Text);
            cm.Parameters.AddWithValue("@ADD_CONT", tb14.Text);
            cm.Parameters.AddWithValue("@M_PNAME", tb15.Text);

            cm.Parameters.AddWithValue("@DEC_45", tb16.Text);
            cm.Parameters.AddWithValue("@COST_LOCK", tb17.Text);
            cm.Parameters.AddWithValue("@NO_QTYSTOR", tb18.Text);
            cm.Parameters.AddWithValue("@COUNT_TAX", tb19.Text);
            cm.Parameters.AddWithValue("@M_COST", tb20.Text);

            cm.Parameters.AddWithValue("@QTY_DISP", tb21.Text);
            cm.Parameters.AddWithValue("@HIS_PRICE", tb22.Text);
            cm.Parameters.AddWithValue("@GC_NAME_CH", tb23.Text);
            cm.Parameters.AddWithValue("@MEMO01", tb24.Text);
            cm.Parameters.AddWithValue("@MEMO02", tb25.Text);

            cm.Parameters.AddWithValue("@MEMO03", tb26.Text);
            cm.Parameters.AddWithValue("@MEMO04", tb27.Text);
            cm.Parameters.AddWithValue("@MEMO05", tb28.Text);
            cm.Parameters.AddWithValue("@MEMO06", tb29.Text);
            cm.Parameters.AddWithValue("@MEMO07", tb30.Text);

            cm.Parameters.AddWithValue("@MEMO08", tb31.Text);
            cm.Parameters.AddWithValue("@MEMO09", tb32.Text);
            cm.Parameters.AddWithValue("@MEMO10", tb33.Text);

            cm.Parameters.AddWithValue("@Q_INDEX", tb34.Text);
            cm.Parameters.AddWithValue("@GRIDCOL01", tb35.Text);
            cm.Parameters.AddWithValue("@GRIDCOL02", tb36.Text);

            cm.Parameters.AddWithValue("@GRIDCOL03", tb37.Text);
            cm.Parameters.AddWithValue("@GRIDCOL04", tb38.Text);
            cm.Parameters.AddWithValue("@GRIDCOL05", tb39.Text);
            cm.Parameters.AddWithValue("@GRIDCOL06", tb40.Text);
            cm.Parameters.AddWithValue("@GRIDCOL07", tb41.Text);

            cm.Parameters.AddWithValue("@GRIDCOL08", tb42.Text);
            cm.Parameters.AddWithValue("@GRIDCOL09", tb43.Text);
            cm.Parameters.AddWithValue("@GRIDCOL10", tb44.Text);
            cm.Parameters.AddWithValue("@GC_NAME01", tb45.Text);
            cm.Parameters.AddWithValue("@GC_NAME02", tb46.Text);

            cm.Parameters.AddWithValue("@GC_NAME03", tb47.Text);
            cm.Parameters.AddWithValue("@GC_NAME04", tb48.Text);
            cm.Parameters.AddWithValue("@GC_NAME05", tb49.Text);
            cm.Parameters.AddWithValue("@GC_NAME06", tb50.Text);
            cm.Parameters.AddWithValue("@GC_NAME07", tb51.Text);

            cm.Parameters.AddWithValue("@GC_NAME08", tb52.Text);
            cm.Parameters.AddWithValue("@GC_NAME09", tb53.Text);
            cm.Parameters.AddWithValue("@GC_NAME10", tb54.Text);
            cm.Parameters.AddWithValue("@GRIDCOL11", tb55.Text);
            cm.Parameters.AddWithValue("@GRIDCOL12", tb56.Text);

            cm.Parameters.AddWithValue("@GRIDCOL13", tb57.Text);
            cm.Parameters.AddWithValue("@GRIDCOL14", tb58.Text);
            cm.Parameters.AddWithValue("@GRIDCOL15", tb59.Text);
            cm.Parameters.AddWithValue("@GRIDCOL16", tb60.Text);
            cm.Parameters.AddWithValue("@GRIDCOL17", tb61.Text);

            cm.Parameters.AddWithValue("@GRIDCOL18", tb62.Text);
            cm.Parameters.AddWithValue("@GRIDCOL19", tb63.Text);
            cm.Parameters.AddWithValue("@GRIDCOL20", tb65.Text);
            cm.Parameters.AddWithValue("@GC_NAME11", tb66.Text);
            cm.Parameters.AddWithValue("@GC_NAME12", tb67.Text);

            cm.Parameters.AddWithValue("@GC_NAME13", tb68.Text);
            cm.Parameters.AddWithValue("@GC_NAME14", tb69.Text);
            cm.Parameters.AddWithValue("@GC_NAME15", tb70.Text);
            cm.Parameters.AddWithValue("@GC_NAME16", tb71.Text);
            cm.Parameters.AddWithValue("@GC_NAME17", tb72.Text);

            cm.Parameters.AddWithValue("@GC_NAME18", tb73.Text);
            cm.Parameters.AddWithValue("@GC_NAME19", tb74.Text);
            cm.Parameters.AddWithValue("@GC_NAME20", tb75.Text);

            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!");
                con.Close();

                Load_data();
                Show_data();

                bt.Text = "NÚT DUYỆT";
                btok.Hide();
                btdong.Hide();

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                f2ThêmToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f5TìmKiếmToolStripMenuItem.Checked = false;

                f1ToolStripMenuItem.Enabled = false;
                f2ThêmToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5TìmKiếmToolStripMenuItem.Enabled = true;
                f8ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;
                t1.Enabled = true;
                tb1.Enabled = true;
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

        private void f5TìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5TìmKiếmToolStripMenuItem.Checked = true;
            
            Form6EF5 fr = new Form6EF5();
            fr.ShowDialog();

            string dl1 = Form6EF5.DT.s1;
            if (dl1 != string.Empty)
                Get_DT();
          

            if (tb1.Text == "")
            {
                Load_data();
                Show_data();
            }
        }
        public void Get_DT()
        {
            string s1 = Form6EF5.DT.s1;
            string s2 = Form6EF5.DT.s2;

            DataTable dt1 = new DataTable();
            string sql = "select * from TAXRAT WHERE WS_KD='" + s1.ToString() + "' AND WS_KIND='" + s2.ToString() + "'";
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = sql;
            dt1.Load(cm.ExecuteReader());
            con.Close();
            foreach (DataRow row in dt1.Rows)
            {
                t1.Text = row["WS_KD"].ToString();
                tb1.Text = row["WS_KIND"].ToString();
                tb2.Text = row["T_NAME"].ToString();
                tb3.Text = row["T_RATE"].ToString();
                tb4.Text = row["QTY_DEC"].ToString();
                tb5.Text = row["BQTY_DEC"].ToString();
                tb6.Text = row["COST_DEC"].ToString();

                tb7.Text = row["PRICE_DEC"].ToString();
                tb8.Text = row["AMOUNT_DEC"].ToString();
                tb9.Text = row["TAX_DEC"].ToString();
                tb10.Text = row["TOTAL_DEC"].ToString();
                tb11.Text = row["AUTO_NO_NUM"].ToString();

                tb12.Text = row["AUTO_NO"].ToString();
                tb13.Text = row["LEAD_CHAR"].ToString();
                tb14.Text = row["ADD_CONT"].ToString();
                tb15.Text = row["M_PNAME"].ToString();
                tb16.Text = row["DEC_45"].ToString();

                tb17.Text = row["COST_LOCK"].ToString();
                tb18.Text = row["NO_QTYSTOR"].ToString();
                tb19.Text = row["COUNT_TAX"].ToString();
                tb20.Text = row["M_COST"].ToString();
                tb21.Text = row["QTY_DISP"].ToString();

                tb22.Text = row["HIS_PRICE"].ToString();
                tb23.Text = row["GC_NAME_CH"].ToString();
                tb24.Text = row["MEMO01"].ToString();
                tb25.Text = row["MEMO02"].ToString();
                tb26.Text = row["MEMO03"].ToString();

                tb27.Text = row["MEMO04"].ToString();
                tb28.Text = row["MEMO05"].ToString();
                tb29.Text = row["MEMO06"].ToString();
                tb30.Text = row["MEMO07"].ToString();
                tb31.Text = row["MEMO08"].ToString();

                tb32.Text = row["MEMO09"].ToString();
                tb33.Text = row["MEMO10"].ToString();
                tb34.Text = row["Q_INDEX"].ToString();
                tb35.Text = row["GRIDCOL01"].ToString();
                tb36.Text = row["GRIDCOL02"].ToString();
                tb37.Text = row["GRIDCOL03"].ToString();
                tb38.Text = row["GRIDCOL04"].ToString();

                tb39.Text = row["GRIDCOL05"].ToString();
                tb40.Text = row["GRIDCOL06"].ToString();
                tb41.Text = row["GRIDCOL07"].ToString();
                tb42.Text = row["GRIDCOL08"].ToString();
                tb43.Text = row["GRIDCOL09"].ToString();

                tb44.Text = row["GRIDCOL10"].ToString();
                tb45.Text = row["GC_NAME01"].ToString();
                tb46.Text = row["GC_NAME02"].ToString();
                tb47.Text = row["GC_NAME03"].ToString();
                tb48.Text = row["GC_NAME04"].ToString();

                tb49.Text = row["GC_NAME05"].ToString();
                tb50.Text = row["GC_NAME06"].ToString();
                tb51.Text = row["GC_NAME07"].ToString();
                tb52.Text = row["GC_NAME08"].ToString();
                tb53.Text = row["GC_NAME09"].ToString();

                tb54.Text = row["GC_NAME10"].ToString();
                tb55.Text = row["GRIDCOL11"].ToString();
                tb56.Text = row["GRIDCOL12"].ToString();
                tb57.Text = row["GRIDCOL13"].ToString();
                tb58.Text = row["GRIDCOL14"].ToString();

                tb59.Text = row["GRIDCOL15"].ToString();
                tb60.Text = row["GRIDCOL16"].ToString();
                tb61.Text = row["GRIDCOL17"].ToString();
                tb62.Text = row["GRIDCOL18"].ToString();
                tb63.Text = row["GRIDCOL19"].ToString();

                tb65.Text = row["GRIDCOL20"].ToString();
                tb66.Text = row["GC_NAME11"].ToString();
                tb67.Text = row["GC_NAME12"].ToString();
                tb68.Text = row["GC_NAME13"].ToString();

                tb69.Text = row["GC_NAME14"].ToString();
                tb70.Text = row["GC_NAME15"].ToString();
                tb71.Text = row["GC_NAME16"].ToString();
                tb72.Text = row["GC_NAME17"].ToString();
                tb73.Text = row["GC_NAME18"].ToString();
                tb74.Text = row["GC_NAME19"].ToString();
                tb75.Text = row["GC_NAME20"].ToString();
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

        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb75, tb1, sender, e);
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(t1, tb2, sender, e);
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

        private void tb59_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb58, tb60, sender, e);
        }

        private void tb60_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb59, tb61, sender, e);
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
            tab(tb62, tb65, sender, e);
        }

        private void tb65_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb63, tb66, sender, e);
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
            tab(tb72, tb74, sender, e);
        }

        private void tb74_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb73, tb75, sender, e);
        }

        private void tb75_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb74, t1, sender, e);
        }
    }
}

