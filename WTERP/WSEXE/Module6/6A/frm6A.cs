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
using LibraryCalender;

namespace WTERP
{
    public partial class Form6A : Form
    {
        DataProvider conn = new DataProvider();
        public Form6A()
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
        #region Change language
        //txtThongBao
       // string txtText = "";
        string txtText1 = "";
       // string txtLuuTC = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtXoa = "";
        string txtSua = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                //txtText = "Trùng Mã Số Tài Khoản? Vui Lòng Nhập lại..";
                txtText1 = "Bạn Chưa Nhập Mã Số Tài Khoản";
                //txtLuuTC = "Lưu Thành Công";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                //txtText = "Trùng Mã Số Tài Khoản? Vui Lòng Nhập lại..";
                txtText1 = "You Have Not Entered Account Number";
                //txtLuuTC = "Lưu Thành Công";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
               // txtText = "Duplicate Account Number? Please Re-enter..";
                txtText1 = "You have not entered the order number?";
                //txtLuuTC = "Save successfully";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtSua = "EDIT";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                //txtText = "帳號重複？ 請重新輸入..";
                txtText1 = "您尚未輸入帳號";
                //txtLuuTC = "保存成功";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtSua = "使固定";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        private void Form6A_Load(object sender, EventArgs e)
        {
            checkFunction();
            rd1.Checked = false;
            Load_Data();
            Show_data();
            Load_Dataview();
        }
        private void LoadFisrt()
        {

            btok.Hide();
            btdong.Hide();
            checkNofication();
            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;


            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }

        private void checkFunction()
        {
            conn.CheckLoad(menuStrip1);
            LoadFisrt();
        }
        public void Load_Data()
        {
            loadinfo();
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select WSNO, WSDATE, USER_ID, NAME, SUPER from USRH";
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();

            foreach (DataRow row in datatable.Rows)
                bindingsource.Add(row);
        }


        public void Load_Dataview()
        {
            string SQL = "SELECT USRB_NEW.NR_Form,Name_From,Text_From,P_USE,F1,F2,F3,F4,F5,F6,f7,f8,F9,F10,f11,f12,P_PRICE FROM dbo.USRB_NEW " +
                "JOIN FORM_NAME ON FORM_NAME.NR_Form = USRB_NEW.NR_Form" +
                " WHERE USER_ID = '" + tb3.Text + "'";
            datatable = conn.readdata(SQL);
            conn.FormatDGV(DGV1, datatable);
            DGV1.Columns[0].Frozen = true;
            DGV1.Columns[1].Frozen = true;
            //Change_Cell_Value();
        }
        public void Show_data()
        {
            DataRow currenRow = (DataRow)bindingsource.Current;

            tb1.Text = conn.formatstr2(currenRow["WSDATE"].ToString());
            tb2.Text = currenRow["WSNO"].ToString();
            tb3.Text = currenRow["USER_ID"].ToString();
            tb4.Text = currenRow["NAME"].ToString();
            if (currenRow["SUPER"].ToString() == "1")
                rd1.Checked = true;
            else if (currenRow["SUPER"].ToString() == "0")
                rd1.Checked = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();

            Show_data();
            Load_Dataview();

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
                Load_Dataview();

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
                Load_Dataview();

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
            Load_Dataview();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            tb1.Text = d1.ToString("yyyy/MM/dd");
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            rd1.Checked = false;

            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            loadDataNull();

            f1ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }
        public void loadDataNull()
        {
            
            string sql = "SELECT NR_Form,Name_From,Text_From,0 AS P_USE,0 AS F1," +
                        "0 AS F2,0 AS F3,0 AS F4,0 AS F5,0 AS F6,0 AS f7," +
                        "0 AS f8,0 AS F9,0 AS F10,0 AS f11,0 AS f12,0 AS P_PRICE FROM FORM_NAME";
            DataTable dt = conn.readdata(sql);
            DGV1.DataSource = dt;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtXoa + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;


            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtSua + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;


            tb1.Enabled = true;
            tb2.Enabled = false;
            tb3.Enabled = true;
            tb4.Enabled = true;

            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6AF5 frm = new Form6AF5();
            frm.ShowDialog();

            string dl1 = Form6AF5.Get_data.t1;
            if (dl1 != string.Empty)
            {
                Set_Data();
                Load_Dataview();
            }

            if (tb2.Text == "")
            {
                Load_Data();
                Show_data();
                Load_Dataview();
            }
        }

        public void Set_Data()
        {
            tb1.Text = Form6AF5.Get_data.t2;
            tb2.Text = Form6AF5.Get_data.t1;
            tb3.Text = Form6AF5.Get_data.t3;
            tb4.Text = Form6AF5.Get_data.t4;
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;


            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;

            btok.Show();
            btdong.Show();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;


            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL.tb3 = tb3.Text;
            Form6AF7 fr = new Form6AF7();
            fr.ShowDialog();

        }
        public class DL
        {
            public static string tb3;
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            checkNofication();
            Load_Data();
            Show_data();
            Load_Dataview();
            checkFunction();
            btok.Hide();
            btdong.Hide();
            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            tb2.Enabled = true;
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = conn.getDateNow();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                checkNofication();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if (checkExist() == true)
                    {
                        MessageBox.Show("Đã tồn tại tài khoản này!");
                    }
                    else
                    {
                        Add_Data();
                        checkFunction();
                    }
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    Delete_DGV();
                    checkFunction();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    Update_data();
                    checkFunction();
                }
                else if (f6ToolStripMenuItem.Checked == true)
                {
                    if (checkExist() == true)
                    {
                        MessageBox.Show("Đã tồn tại tài khoản này!");
                    }
                    else
                    {
                        Insert_Data();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updatadatagridview()
        {
            for (int i = 0; i < DGV1.Rows.Count - 1; i++)
            {
                string sql = "UPDATE dbo.USRB_NEW SET P_USE = " + ConvertStringToInt(DGV1.Rows[i].Cells["P_USE"].Value.ToString()) + "," +
                    "F1=" + ConvertStringToInt(DGV1.Rows[i].Cells["F1"].Value.ToString()) +
                    ",F2=" + ConvertStringToInt(DGV1.Rows[i].Cells["F2"].Value.ToString()) +
                    ",F3=" + ConvertStringToInt(DGV1.Rows[i].Cells["F3"].Value.ToString()) +
                    ",F4=" + ConvertStringToInt(DGV1.Rows[i].Cells["F4"].Value.ToString()) +
                    ",F5=" + ConvertStringToInt(DGV1.Rows[i].Cells["F5"].Value.ToString()) +
                    ",F6=" + ConvertStringToInt(DGV1.Rows[i].Cells["F6"].Value.ToString()) +
                    ",F7=" + ConvertStringToInt(DGV1.Rows[i].Cells["F7"].Value.ToString()) +
                    ",F8=" + ConvertStringToInt(DGV1.Rows[i].Cells["F8"].Value.ToString()) +
                    ",F9=" + ConvertStringToInt(DGV1.Rows[i].Cells["F9"].Value.ToString()) +
                    ",F10=" + ConvertStringToInt(DGV1.Rows[i].Cells["F10"].Value.ToString()) +
                    ",F11=" + ConvertStringToInt(DGV1.Rows[i].Cells["F11"].Value.ToString()) +
                    ",F12=" + ConvertStringToInt(DGV1.Rows[i].Cells["F12"].Value.ToString()) +
                    ",P_PRICE=" + ConvertStringToInt(DGV1.Rows[i].Cells["P_PRICE"].Value.ToString()) +
                    ",SUPER = "+ Covert_boot(rd1.Checked) + " WHERE USER_ID = '" + tb3.Text + "' AND NR_Form = " + DGV1.Rows[i].Cells["NR_Form"].Value.ToString() + "";
                conn.exedata(sql);
            }
        }
        public int ConvertStringToInt(string d)
        {
            if (d == "True")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string a = "";
        public void check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                a = conn.formatstr2(tb1.Text);
            }
        }
        public void Add_Data()
        {
            checkNofication();
            check();
            con = new SqlConnection(st);
            con.Open();
            string st1 = "insert into dbo.USRH(WSDATE, WSNO, USER_ID, NAME,PAS_WORD, SUPER)" +
                " values(@WSDATE, @WSNO, @USER_ID, @NAME,@PAS_WORD, @SUPER)";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@WSDATE", a);
            cm.Parameters.AddWithValue("@WSNO", tb2.Text);
            cm.Parameters.AddWithValue("@USER_ID", tb3.Text);
            cm.Parameters.AddWithValue("@NAME", tb4.Text);
            cm.Parameters.AddWithValue("@PAS_WORD", "123");
            cm.Parameters.AddWithValue("@SUPER", rd1.Checked);
          

            if (tb2.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }

            try
            {
                cm.ExecuteNonQuery();
                Add_DGV();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btdong.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

        }
        public void Add_DGV()
        {
            for (int i = 0; i < DGV1.RowCount - 1; i++)
            {
                string sql = "INSERT INTO dbo.USRB_NEW(USER_ID, SUPER, NR_Form, P_USE, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,P_PRICE) " +
                            "VALUES('" + tb3.Text + "','" + Covert_boot(rd1.Checked) + "'," + DGV1.Rows[i].Cells["NR_Form"].Value.ToString() +
                            "," + DGV1.Rows[i].Cells["P_USE"].Value.ToString() + "," + DGV1.Rows[i].Cells["F1"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F2"].Value.ToString() + "," + DGV1.Rows[i].Cells["F3"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F4"].Value.ToString() + "," + DGV1.Rows[i].Cells["F5"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F6"].Value.ToString() + "," + DGV1.Rows[i].Cells["F7"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F8"].Value.ToString() + "," + DGV1.Rows[i].Cells["F9"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F10"].Value.ToString() + "," + DGV1.Rows[i].Cells["F11"].Value.ToString() + "" +
                            "," + DGV1.Rows[i].Cells["F12"].Value.ToString() + "," + DGV1.Rows[i].Cells["P_PRICE"].Value.ToString() + ")";
                try
                {
                    conn.exedata(sql);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public void Delete_Data()
        {
            checkNofication();
            string Matk = tb2.Text;
            if (Matk == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            try
            {
                con = new SqlConnection(st);
                con.Open();
                cm = con.CreateCommand();
                cm.CommandText = "delete from USRH where USER_ID ='" + tb3.Text + "'";
                cm.ExecuteNonQuery();
                con.Close();

            }
            catch { }
        }

        public void Delete_DGV()
        {
            checkNofication();
            Delete_Data();
            conn.exedata("delete from USRB_NEW where USER_ID ='" + tb3.Text + "'");

            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btdong.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            tb2.Enabled = true;

        }
        public void Update_data()
        {
            checkNofication();
            check();
            con = new SqlConnection(st);
            con.Open();
            string st1 = "update dbo.USRH set WSDATE =@WSDATE, WSNO =@WSNO, USER_ID =@USER_ID, NAME =@NAME, SUPER =@SUPER where WSNO= @WSNO";
            SqlCommand cm = new SqlCommand(st1, con);

            cm.Parameters.AddWithValue("@WSDATE", a);
            cm.Parameters.AddWithValue("@WSNO", tb2.Text);
            cm.Parameters.AddWithValue("@USER_ID", tb3.Text);
            cm.Parameters.AddWithValue("@NAME", tb4.Text);
            cm.Parameters.AddWithValue("@SUPER", Covert_boot(rd1.Checked));

            if (tb2.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            try
            {
                cm.ExecuteNonQuery();
                updatadatagridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btdong.Hide();

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            tb2.Enabled = true;
        }
        public void Insert_Data()
        {
            checkNofication();
            check();
            con = new SqlConnection(st);
            con.Open();
            string st1 = "insert into dbo.USRH(WSDATE, WSNO, USER_ID, NAME, SUPER)" +
                " values('"+a+"', '"+ tb2.Text + "', '"+ tb3.Text + "', '"+ tb4.Text + "', '"+ rd1.Checked + "')";

            if (tb2.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            try
            {
                if (conn.exedata(st1) == true)
                {
                    Add_DGV();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;


            Load_Data();
            Show_data();
            Load_Dataview();

            btok.Hide();
            btdong.Hide();
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            //Load_Dataview();
        }
        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {

                FormSearchProgram fm = new FormSearchProgram();
                fm.ShowDialog();
                int NR = 1;
                for (int i = 0; i < FormSearchProgram.DT.LV.Count; i++)
                {
                    string AA = NR.ToString("D" + 3);
                    string BB = FormSearchProgram.DT.LV[i];
                    string BA = FormSearchProgram.DT.LV1[i];
                    DGV1.Rows.Add(AA, BB, BA, "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True", "True");
                    NR++;
                }
            }
        }

        private void tb2_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                int N = 1;
                string AA = N.ToString("D" + 3);
                string s = "Z" + conn.formatstr2(tb1.Text) + AA;

                string SQL = "select WSNO from USRH";
                DataTable dt = conn.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (s.ToString() == dr["WSNO"].ToString())
                        {
                            N++;
                            AA = N.ToString("D" + 3);
                            s = "Z" + conn.formatstr2(tb1.Text) + AA;

                        }
                    }
                }
                catch
                {

                }
                tb2.Text = s;
            }

        }

        public int Convert_bit(string a)
        {
            int n;
            if (a.ToString() == "True")
            {
                n = 1;
            }
            else if (a.ToString() == "False")
            {
                n = 0;
            }
            else n = 0;
            return n;

        }

        public int Covert_boot(bool b)
        {
            int c;
            if (b == true)
            {
                c = 1;
            }
            else c = 0;

            return c;
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
            conn.tab_DOWN(tb3, tb1, sender, e);
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {
            
            string sql = "SELECT * FROM USRH WHERE USER_ID = '" + tb3.Text + "'";
            DataTable dt = conn.readdata(sql);

            if (dt.Rows.Count > 0)
            {
                    tb1.Text = dt.Rows[0]["WSDATE"].ToString();
                    tb2.Text = dt.Rows[0]["WSNO"].ToString();
                    tb4.Text = dt.Rows[0]["NAME"].ToString();
                    if (dt.Rows[0]["SUPER"].ToString() == "True")
                        rd1.Checked = true;
                    else
                        rd1.Checked = false;
                    Load_Dataview();   
            }
            else
            {
                tb1.Text = DateTime.Now.ToString("yyyy/MM/dd");
                tb2.Text = "";
                tb4.Text = "";
                loadDataNull();
            }
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
        private bool checkExist()
        {
            string sql = "SELECT TOP 1 * FROM USRH WHERE USER_ID = '" + tb3.Text + "'";
            DataTable dt = conn.readdata(sql);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
