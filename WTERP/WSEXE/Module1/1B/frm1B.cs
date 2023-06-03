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
    public partial class Form1B : Form
    {
        DataProvider conn = new DataProvider();
        public Form1B()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataTable tb = new DataTable();
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        private void Form1BThongtindoanhnghiep_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);

            getInfo();
            LoadData();
            hienthidata();

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

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
            string sql = "select C_NO, C_NAME, C_ANAME, V_NAME, V_ANAME, NUMBER, BOSS, SPEAK, TEL1, TEL2, FAX, ACT, EMAIL, S_NO,  ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, MEMO1," +
                " MEMO2, MEMO3, ACCOUNT, PRE_RCV, EAR_MON, TAX_KIND, BA_NO, TAX_YN, PAY_CON, RCV_DATE, DEFA_MONEY,USR_NAME from VENDC";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
        }
        #region Change Language
        string txtThongBao = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtText9 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtText2 = "Bạn chưa nhập mã số Nhà cung cấp";
                txtText3 = "Bạn chưa nhập thanh toán trước";
                txtText4 = "Bạn chưa nhập mở tài khoản";
                txtText9 = "Mã Nhà Cung Cấp Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtText2 = "Bạn chưa nhập mã số Nhà cung cấp";
                txtText3 = "Bạn chưa nhập thanh toán trước";
                txtText4 = "Bạn chưa nhập mở tài khoản";
                txtText9 = "Mã Nhà Cung Cấp Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtText2 = "You have not entered the Supplier code";
                txtText3 = "You have not entered prepayment";
                txtText4 = "You have not entered to open an account";
                txtText9 = "Vendor Code Exists \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtText2 = "您尚未輸入供應商代碼";
                txtText3 = "您尚未輸入預付款";
                txtText4 = "您還沒有進入開戶";
                txtText9 = "供應商代碼已存在 \n 請單擊確定，[關閉] 並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }

        }
        #endregion

        #region check
        public DataRow currentRow
        {
            get
            {
                int position = this.BindingContext[bindingsource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bindingsource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        public void hienthidata()
        {
            this.tb1.Text = currentRow["C_NO"].ToString();
            this.tb2.Text = currentRow["C_NAME"].ToString();
            this.tb3.Text = currentRow["C_ANAME"].ToString();
            this.tb4.Text = currentRow["V_NAME"].ToString();
            this.tb5.Text = currentRow["V_ANAME"].ToString();

            this.tb6.Text = currentRow["NUMBER"].ToString();
            this.tb7.Text = currentRow["BOSS"].ToString();
            this.tb8.Text = currentRow["SPEAK"].ToString();
            this.tb9.Text = currentRow["TEL1"].ToString();
            this.tb10.Text = currentRow["TEL2"].ToString();

            this.tb11.Text = currentRow["FAX"].ToString();
            this.tb12.Text = currentRow["ACT"].ToString();
            this.tb13.Text = currentRow["EMAIL"].ToString();
            this.tb14.Text = currentRow["S_NO"].ToString();
            this.tb15.Text = "";

            this.tb16.Text = currentRow["ADR1ZIP"].ToString();
            this.tb17.Text = currentRow["ADR1"].ToString();
            this.tb18.Text = currentRow["ADR2ZIP"].ToString();
            this.tb19.Text = currentRow["ADR2"].ToString();
            this.tb20.Text = currentRow["ADR3ZIP"].ToString();
            this.tb21.Text = currentRow["ADR3"].ToString();

            this.tb22.Text = currentRow["ADR4ZIP"].ToString();
            this.tb23.Text = currentRow["ADR4"].ToString();
            this.tb24.Text = currentRow["MEMO1"].ToString();
            this.tb25.Text = currentRow["MEMO2"].ToString();
            this.tb26.Text = currentRow["MEMO3"].ToString();

            this.tb27.Text = currentRow["ACCOUNT"].ToString();
            this.tb28.Text = currentRow["PRE_RCV"].ToString();
            this.tb29.Text = currentRow["EAR_MON"].ToString();
            this.tb30.Text = currentRow["TAX_KIND"].ToString();
            this.tb31.Text = currentRow["BA_NO"].ToString();

            this.tb32.Text = "";
            this.tb33.Text = currentRow["TAX_YN"].ToString();
            this.tb34.Text = currentRow["PAY_CON"].ToString();
            this.tb35.Text = currentRow["RCV_DATE"].ToString();
            this.cb1.Text = currentRow["DEFA_MONEY"].ToString();

            this.lblEditBy.Text = currentRow["USR_NAME"].ToString();



        }
        public void LoadDL()
        {
            this.tb1.Text = Form1BF5.DL.T1;
            this.tb2.Text = Form1BF5.DL.T2;
            this.tb3.Text = Form1BF5.DL.T3;
            this.tb4.Text = Form1BF5.DL.T4;
            this.tb5.Text = Form1BF5.DL.T5;

            this.tb6.Text = Form1BF5.DL.T6;
            this.tb7.Text = Form1BF5.DL.T7;
            this.tb8.Text = Form1BF5.DL.T8;
            this.tb9.Text = Form1BF5.DL.T9;
            this.tb10.Text = Form1BF5.DL.T10;

            this.tb11.Text = Form1BF5.DL.T11;
            this.tb12.Text = Form1BF5.DL.T12;
            this.tb13.Text = Form1BF5.DL.T13;
            this.tb14.Text = Form1BF5.DL.T14;
            //this.tb15.Text = Form1BF5.DL.T15;

            this.tb16.Text = Form1BF5.DL.T16;
            this.tb17.Text = Form1BF5.DL.T17;
            this.tb18.Text = Form1BF5.DL.T18;
            this.tb19.Text = Form1BF5.DL.T19;
            this.tb20.Text = Form1BF5.DL.T20;
            this.tb21.Text = Form1BF5.DL.T21;

            this.tb22.Text = Form1BF5.DL.T22;
            this.tb23.Text = Form1BF5.DL.T23;
            this.tb24.Text = Form1BF5.DL.T24;
            this.tb25.Text = Form1BF5.DL.T25;
            this.tb26.Text = Form1BF5.DL.T26;
            this.tb27.Text = Form1BF5.DL.T27;
            this.tb28.Text = Form1BF5.DL.T28;
            this.tb29.Text = Form1BF5.DL.T29;

            this.tb30.Text = Form1BF5.DL.T30;
            this.tb31.Text = Form1BF5.DL.T31;

            //this.tb32.Text = Form1BF5.DL.T32;
            this.tb33.Text = Form1BF5.DL.T33;
            this.tb34.Text = Form1BF5.DL.T34;
            this.tb35.Text = Form1BF5.DL.T35;
            this.cb1.Text = Form1BF5.DL.T36;

            this.lblEditBy.Text = Form1BF5.DL.T37;
        }
        #endregion
        #region toolStrip
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";
            btok.Show();
            btdong.Show();

            this.tb1.Text = "";
            this.tb2.Text = "";
            this.tb3.Text = "";
            this.tb4.Text = "";
            this.tb5.Text = "";

            this.tb6.Text = "";
            this.tb7.Text = "";
            this.tb8.Text = "";
            this.tb9.Text = "";
            this.tb10.Text = "";

            this.tb11.Text = "";
            this.tb12.Text = "";
            this.tb13.Text = "";
            this.tb14.Text = "";
            this.tb15.Text = "";

            this.tb16.Text = "";
            this.tb17.Text = "";
            this.tb18.Text = "";
            this.tb19.Text = "";
            this.tb20.Text = "";

            this.tb21.Text = "";
            this.tb22.Text = "";
            this.tb23.Text = "";
            this.tb24.Text = "";
            this.tb25.Text = "";

            this.tb26.Text = "";
            this.tb27.Text = "";
            this.tb28.Text = "0";
            this.tb29.Text = "0";
            this.tb30.Text = "";


            this.tb31.Text = "";

            this.tb32.Text = "";
            this.tb33.Text = "";
            this.tb34.Text = "";
            this.tb35.Text = "";
            this.cb1.Text = "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();

            hienthidata();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingsource.MovePrevious();
            hienthidata();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e)
        {

            bindingsource.MoveNext();
            hienthidata();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();
            hienthidata();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
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

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
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

            //  this.tb1.Enabled = true;
            this.tb2.Enabled = true;
            this.tb3.Enabled = true;
            this.tb4.Enabled = true;
            this.tb5.Enabled = true;

            this.tb6.Enabled = true;
            this.tb7.Enabled = true;
            this.tb8.Enabled = true;
            this.tb9.Enabled = true;
            this.tb10.Enabled = true;

            this.tb11.Enabled = true;
            this.tb12.Enabled = true;
            this.tb13.Enabled = true;
            this.tb14.Enabled = true;
            this.tb15.Enabled = true;

            this.tb16.Enabled = true;
            this.tb17.Enabled = true;
            this.tb18.Enabled = true;
            this.tb19.Enabled = true;
            this.tb20.Enabled = true;

            this.tb21.Enabled = true;
            this.tb22.Enabled = true;
            this.tb23.Enabled = true;
            this.tb24.Enabled = true;
            this.tb25.Enabled = true;

            this.tb26.Enabled = true;
            this.tb27.Enabled = true;
            this.tb28.Enabled = true;
            this.tb29.Enabled = true;
            this.tb30.Enabled = true;

            this.tb31.Enabled = true;

            this.tb32.Enabled = true;
            this.tb33.Enabled = true;
            this.tb34.Enabled = true;
            this.tb35.Enabled = true;
            this.cb1.Enabled = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;


        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1BF5 frm = new Form1BF5();
            frm.ShowDialog();

            string dl1 = Form1BF5.DL.T1;
            if (dl1 != string.Empty)
                LoadDL();

            if (tb1.Text == "")
            {
                LoadData();
                hienthidata();
            }

        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            bt.Text = "COPY";
            btok.Show();
            btdong.Show();

            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1BF7 frm = new Form1BF7();
            this.Hide();
            frm.ShowDialog();
            this.Close();
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
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.VENDC( C_NO, C_NAME, C_ANAME, V_NAME, V_ANAME, NUMBER, BOSS, SPEAK, TEL1, TEL2, FAX, ACT, EMAIL, S_NO, ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, MEMO1, MEMO2, MEMO3, ACCOUNT, PRE_RCV, EAR_MON, TAX_KIND, BA_NO, TAX_YN, PAY_CON, RCV_DATE, DEFA_MONEY,USR_NAME) " +
                    " values(@C_NO, @C_NAME, @C_ANAME, @V_NAME, @V_ANAME, @NUMBER, @BOSS, @SPEAK, @TEL1, @TEL2, @FAX, @ACT, @EMAIL, @S_NO, @ADR1ZIP, @ADR1, @ADR2ZIP, @ADR2, @ADR3ZIP, @ADR3, @ADR4ZIP, @ADR4, @MEMO1, @MEMO2, @MEMO3, @ACCOUNT, @PRE_RCV, @EAR_MON, @TAX_KIND, @BA_NO, @TAX_YN, @PAY_CON, @RCV_DATE, @DEFA_MONEY,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@C_NO", tb1.Text);
                cm.Parameters.AddWithValue("@C_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@C_ANAME", tb3.Text);
                cm.Parameters.AddWithValue("@V_NAME", tb4.Text);
                cm.Parameters.AddWithValue("@V_ANAME", tb5.Text);

                cm.Parameters.AddWithValue("@NUMBER", tb6.Text);
                cm.Parameters.AddWithValue("@BOSS", tb7.Text);
                cm.Parameters.AddWithValue("@SPEAK", tb8.Text);
                cm.Parameters.AddWithValue("@TEL1", tb9.Text);
                cm.Parameters.AddWithValue("@TEL2", tb10.Text);

                cm.Parameters.AddWithValue("@FAX", tb11.Text);
                cm.Parameters.AddWithValue("@ACT", tb12.Text);
                cm.Parameters.AddWithValue("@EMAIL", tb13.Text);
                cm.Parameters.AddWithValue("@S_NO", tb14.Text);

                cm.Parameters.AddWithValue("@ADR1ZIP", tb16.Text);
                cm.Parameters.AddWithValue("@ADR1", tb17.Text);
                cm.Parameters.AddWithValue("@ADR2ZIP", tb18.Text);
                cm.Parameters.AddWithValue("@ADR2", tb19.Text);
                cm.Parameters.AddWithValue("@ADR3ZIP", tb20.Text);

                cm.Parameters.AddWithValue("@ADR3", tb21.Text);
                cm.Parameters.AddWithValue("@ADR4ZIP", tb22.Text);
                cm.Parameters.AddWithValue("@ADR4", tb23.Text);
                cm.Parameters.AddWithValue("@MEMO1", tb24.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb25.Text);

                cm.Parameters.AddWithValue("@MEMO3", tb26.Text);
                cm.Parameters.AddWithValue("@ACCOUNT", tb27.Text);
                cm.Parameters.AddWithValue("@PRE_RCV", float.Parse(tb28.Text));
                cm.Parameters.AddWithValue("@EAR_MON", float.Parse(tb29.Text));
                cm.Parameters.AddWithValue("@TAX_KIND", tb30.Text);

                cm.Parameters.AddWithValue("@BA_NO", tb31.Text);
                cm.Parameters.AddWithValue("@TAX_YN", tb33.Text);
                cm.Parameters.AddWithValue("@PAY_CON", tb34.Text);
                cm.Parameters.AddWithValue("@RCV_DATE", tb35.Text);
                cm.Parameters.AddWithValue("@DEFA_MONEY", cb1.Text);

                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb28.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb29.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                LoadData();
                hienthidata();

                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                btok.Hide();
                btdong.Hide();
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
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string manhacungcap = tb1.Text;
                if (manhacungcap == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from VENDC where C_NO ='" + manhacungcap + "'";
                    cm.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoadData();
                hienthidata();
                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                btok.Hide();
                btdong.Hide();
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
            else if (f4ToolStripMenuItem.Checked == true)
            {
                f4ToolStripMenuItem.Checked = true;
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.VENDC set C_NO = @C_NO, C_NAME = @C_NAME, C_ANAME = @C_ANAME, V_NAME = @V_NAME, V_ANAME = @V_ANAME, NUMBER = @NUMBER, BOSS = @BOSS, SPEAK = @SPEAK, TEL1 = @TEL1, TEL2 = @TEL2, FAX = @FAX, ACT = @ACT, EMAIL = @EMAIL, " +
                    "S_NO = @S_NO, ADR1ZIP = @ADR1ZIP, ADR1 = @ADR1, ADR2ZIP = @ADR2ZIP, ADR2 = @ADR2, ADR3ZIP = @ADR3ZIP, ADR3 = @ADR3, ADR4ZIP = @ADR4ZIP, ADR4 = @ADR4, MEMO1 = @MEMO1, MEMO2 = @MEMO2, MEMO3 = @MEMO3, ACCOUNT = @ACCOUNT, PRE_RCV = @PRE_RCV, " +
                    "EAR_MON = @EAR_MON, TAX_KIND = @TAX_KIND, BA_NO = @BA_NO, TAX_YN = @TAX_YN,  PAY_CON = @PAY_CON, RCV_DATE = @RCV_DATE, DEFA_MONEY = @DEFA_MONEY,USR_NAME = @USR_NAME where C_NO = @C_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@C_NO", tb1.Text);
                cm.Parameters.AddWithValue("@C_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@C_ANAME", tb3.Text);
                cm.Parameters.AddWithValue("@V_NAME", tb4.Text);
                cm.Parameters.AddWithValue("@V_ANAME", tb5.Text);

                cm.Parameters.AddWithValue("@NUMBER", tb6.Text);
                cm.Parameters.AddWithValue("@BOSS", tb7.Text);
                cm.Parameters.AddWithValue("@SPEAK", tb8.Text);
                cm.Parameters.AddWithValue("@TEL1", tb9.Text);
                cm.Parameters.AddWithValue("@TEL2", tb10.Text);

                cm.Parameters.AddWithValue("@FAX", tb11.Text);
                cm.Parameters.AddWithValue("@ACT", tb12.Text);
                cm.Parameters.AddWithValue("@EMAIL", tb13.Text);
                cm.Parameters.AddWithValue("@S_NO", tb14.Text);

                cm.Parameters.AddWithValue("@ADR1ZIP", tb16.Text);
                cm.Parameters.AddWithValue("@ADR1", tb17.Text);
                cm.Parameters.AddWithValue("@ADR2ZIP", tb18.Text);
                cm.Parameters.AddWithValue("@ADR2", tb19.Text);
                cm.Parameters.AddWithValue("@ADR3ZIP", tb20.Text);

                cm.Parameters.AddWithValue("@ADR3", tb21.Text);
                cm.Parameters.AddWithValue("@ADR4ZIP", tb22.Text);
                cm.Parameters.AddWithValue("@ADR4", tb23.Text);
                cm.Parameters.AddWithValue("@MEMO1", tb24.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb25.Text);

                cm.Parameters.AddWithValue("@MEMO3", tb26.Text);
                cm.Parameters.AddWithValue("@ACCOUNT", tb27.Text);
                cm.Parameters.AddWithValue("@PRE_RCV", float.Parse(tb28.Text));
                cm.Parameters.AddWithValue("@EAR_MON", float.Parse(tb29.Text));
                cm.Parameters.AddWithValue("@TAX_KIND", tb30.Text);

                cm.Parameters.AddWithValue("@BA_NO", tb31.Text);
                cm.Parameters.AddWithValue("@TAX_YN", tb33.Text);
                cm.Parameters.AddWithValue("@PAY_CON", tb34.Text);
                cm.Parameters.AddWithValue("@RCV_DATE", tb35.Text);
                cm.Parameters.AddWithValue("@DEFA_MONEY", cb1.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb28.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb29.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                LoadData();
                hienthidata();

                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                btok.Hide();
                btdong.Hide();
                bt.Text = "" + txtDuyet + "";


                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                f2ToolStripMenuItem.Checked = false;
                f3ToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f6ToolStripMenuItem.Checked = false;
                //mở khóa
                tb1.Enabled = true;

            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                f6ToolStripMenuItem.Checked = true;
                string a = tb1.Text;
                string SQL = "select C_NO from VENDC";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["C_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText9 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                string st1 = "insert into dbo.VENDC( C_NO, C_NAME, C_ANAME, V_NAME, V_ANAME, NUMBER, BOSS, SPEAK, TEL1, TEL2, FAX, ACT, EMAIL, S_NO, ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, MEMO1, MEMO2, MEMO3, ACCOUNT, PRE_RCV, EAR_MON, TAX_KIND, BA_NO, TAX_YN, PAY_CON, RCV_DATE, DEFA_MONEY,USR_NAME) " +
                    " values(@C_NO, @C_NAME, @C_ANAME, @V_NAME, @V_ANAME, @NUMBER, @BOSS, @SPEAK, @TEL1, @TEL2, @FAX, @ACT, @EMAIL, @S_NO, @ADR1ZIP, @ADR1, @ADR2ZIP, @ADR2, @ADR3ZIP, @ADR3, @ADR4ZIP, @ADR4, @MEMO1, @MEMO2, @MEMO3, @ACCOUNT, @PRE_RCV, @EAR_MON, @TAX_KIND, @BA_NO, @TAX_YN, @PAY_CON, @RCV_DATE, @DEFA_MONEY,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@C_NO", tb1.Text);
                cm.Parameters.AddWithValue("@C_NAME", tb2.Text);
                cm.Parameters.AddWithValue("@C_ANAME", tb3.Text);
                cm.Parameters.AddWithValue("@V_NAME", tb4.Text);
                cm.Parameters.AddWithValue("@V_ANAME", tb5.Text);

                cm.Parameters.AddWithValue("@NUMBER", tb6.Text);
                cm.Parameters.AddWithValue("@BOSS", tb7.Text);
                cm.Parameters.AddWithValue("@SPEAK", tb8.Text);
                cm.Parameters.AddWithValue("@TEL1", tb9.Text);
                cm.Parameters.AddWithValue("@TEL2", tb10.Text);

                cm.Parameters.AddWithValue("@FAX", tb11.Text);
                cm.Parameters.AddWithValue("@ACT", tb12.Text);
                cm.Parameters.AddWithValue("@EMAIL", tb13.Text);
                cm.Parameters.AddWithValue("@S_NO", tb14.Text);

                cm.Parameters.AddWithValue("@ADR1ZIP", tb16.Text);
                cm.Parameters.AddWithValue("@ADR1", tb17.Text);
                cm.Parameters.AddWithValue("@ADR2ZIP", tb18.Text);
                cm.Parameters.AddWithValue("@ADR2", tb19.Text);
                cm.Parameters.AddWithValue("@ADR3ZIP", tb20.Text);

                cm.Parameters.AddWithValue("@ADR3", tb21.Text);
                cm.Parameters.AddWithValue("@ADR4ZIP", tb22.Text);
                cm.Parameters.AddWithValue("@ADR4", tb23.Text);
                cm.Parameters.AddWithValue("@MEMO1", tb24.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb25.Text);

                cm.Parameters.AddWithValue("@MEMO3", tb26.Text);
                cm.Parameters.AddWithValue("@ACCOUNT", tb27.Text);
                cm.Parameters.AddWithValue("@PRE_RCV", float.Parse(tb28.Text));
                cm.Parameters.AddWithValue("@EAR_MON", float.Parse(tb29.Text));
                cm.Parameters.AddWithValue("@TAX_KIND", tb30.Text);

                cm.Parameters.AddWithValue("@BA_NO", tb31.Text);
                cm.Parameters.AddWithValue("@TAX_YN", tb33.Text);
                cm.Parameters.AddWithValue("@PAY_CON", tb34.Text);
                cm.Parameters.AddWithValue("@RCV_DATE", tb35.Text);
                cm.Parameters.AddWithValue("@DEFA_MONEY", cb1.Text);
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);


                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb28.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (tb29.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                LoadData();
                hienthidata();

                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f10ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                btok.Hide();
                btdong.Hide();
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
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            LoadData();
            hienthidata();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

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
            tab(cb1, tb2, sender, e);
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
            tab(tb25, tb1, sender, e);
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
            tab(tb34, cb1, sender, e);
        }

        private void cb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb35, tb27, sender, e);
        }


    }
}
