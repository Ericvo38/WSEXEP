using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2L : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        static bool chk = false;
        public frm2L()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2L_Load(object sender, EventArgs e)
        {
            loadfirst();
            getInfo();
            LoadDGV();
            con.DGV(DGV1);
        }
       
    
        private void LoadDGV()
        {
            string str1 = "SELECT C_NAME, M01M, M02M, M03M, M04M, M05M, M06M, M07M, M08M, M09M, M10M, M11M, M12M FROM ORD_CNO";
            DataTable dt1 = con.readdata(str1);
            if (dt1 != null)
                DGV1.DataSource = dt1;
        }
        private void loadfirst()
        {
            con.CheckLoad(menuStrip1);
            f1ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnSua.Hide();
            btnDong.Hide();
            

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;

            txt1.ReadOnly = true;
            txt2.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            txt5.ReadOnly = true;
            txt6.ReadOnly = true;
            txt7.ReadOnly = true;
            txt8.ReadOnly = true;
            txt9.ReadOnly = true;
            txt10.ReadOnly = true;
            txt11.ReadOnly = true;
            txt12.ReadOnly = true;
        }
        public void getInfo()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            btndateNow.Text = con.getDateNow();
            string UID = frmLogin.ID_USER;
            lbUserName.Text = con.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
        }
        
        // Tim Theo Năm
        private void getYears()
        {
            string year = txtYears.Text;
            if (con.IsNumber(year) == true)
            {
                if (year.Length > 2)
                {
                    year = year.Substring(year.Length - 2, 2);
                }
                string str1 = "SELECT C_NAME, M01M, M02M, M03M, M04M, M05M, M06M, M07M, M08M, M09M, M10M, M11M, M12M FROM ORD_CNO WHERE O_YEAR LIKE '%" + year + "%'";
                DataTable dt = con.readdata(str1);
                source = new BindingSource();
                source.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    chk = true;
                    DGV1.DataSource = dt;
                    con.DGV(DGV1);
                    bindingdata();
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Năm '" + txtYears.Text + "' Không có Tồn tại \n Vui lòng chọn lại năm! ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Năm nhập không hợp lệ", "Thông Báo");
           
        }
        // luu
        private void luu()
        {
            var cultureInfo = new CultureInfo("vi-VI");
            string year = txtYears.Text;
            string result = DateTime.ParseExact(year, "yyyy",
                            CultureInfo.InvariantCulture).ToString("yy");
            string str2 = "UPDATE ORD_CNO SET M01M = '"+txt1.Text+"', M02M = '"+txt2.Text+"', M03M = '"+txt3.Text+"', M04M = '"+txt4.Text+"', M05M = '"+txt5.Text+"', M06M = '"+txt6.Text+"', M07M = '"+txt7.Text+"', M08M = '"+txt8.Text+"', M09M = '"+txt9.Text+"', M10M = '"+txt10.Text+"', M11M = '"+txt11.Text+"', M12M = '"+txt12.Text+"' WHERE O_YEAR = '" + result+"'";
            bool a = con.exedata(str2);
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2LF7 fr = new frm2LF7();
            fr.ShowDialog();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }
        //binding Textbox<-> DataGridView
        private void bindingdata()
        {
            txt1.DataBindings.Clear();
            txt1.DataBindings.Add("Text", DGV1.DataSource, "M01M");

            txt2.DataBindings.Clear();
            txt2.DataBindings.Add("Text", DGV1.DataSource, "M02M");

            txt3.DataBindings.Clear();
            txt3.DataBindings.Add("Text", DGV1.DataSource, "M03M");

            txt4.DataBindings.Clear();
            txt4.DataBindings.Add("Text", DGV1.DataSource, "M04M");

            txt5.DataBindings.Clear();
            txt5.DataBindings.Add("Text", DGV1.DataSource, "M05M");

            txt6.DataBindings.Clear();
            txt6.DataBindings.Add("Text", DGV1.DataSource, "M06M");

            txt7.DataBindings.Clear();
            txt7.DataBindings.Add("Text", DGV1.DataSource, "M07M");

            txt8.DataBindings.Clear();
            txt8.DataBindings.Add("Text", DGV1.DataSource, "M08M");

            txt9.DataBindings.Clear();
            txt9.DataBindings.Add("Text", DGV1.DataSource, "M09M");

            txt10.DataBindings.Clear();
            txt10.DataBindings.Add("Text", DGV1.DataSource, "M10M");

            txt11.DataBindings.Clear();
            txt11.DataBindings.Add("Text", DGV1.DataSource, "M11M");

            txt12.DataBindings.Clear();
            txt12.DataBindings.Add("Text", DGV1.DataSource, "M12M");
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
           getYears();
            btnChon.Hide();
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bindingdata();
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f10ToolStripMenuItem.Enabled = true;
            btnDong.Show();
            btnSua.Show();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;

            txt1.ReadOnly = false;
            txt2.ReadOnly = false;
            txt3.ReadOnly = false;
            txt4.ReadOnly = false;
            txt5.ReadOnly = false;
            txt6.ReadOnly = false;
            txt7.ReadOnly = false;
            txt8.ReadOnly = false;
            txt9.ReadOnly = false;
            txt10.ReadOnly = false;
            txt11.ReadOnly = false;
            txt12.ReadOnly = false;
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            luu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            loadfirst();
            chk = false;
            btnChon.Show();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            DGV1.Rows[0].Selected = true;
            DGV1.DataSource = source;
            source.MoveFirst();
            bindingdata();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = DGV1.CurrentRow.Index;
                if (DGV1.Rows.Count > IndexNow)
                {
                    DGV1.Rows[IndexNow - 1].Selected = true;
                }
                DGV1.DataSource = source;
                source.MovePrevious();
            }
            catch (Exception)
            {

            }
            bindingdata();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = DGV1.CurrentRow.Index;
                if (DGV1.Rows.Count > IndexNow)
                {
                    DGV1.Rows[IndexNow + 1].Selected = true;
                }
                DGV1.DataSource = source;
                source.MoveNext();
            }
            catch (Exception)
            {

            }
            bindingdata();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            int so = DGV1.Rows.Count - 1;
            DGV1.Rows[so - 1].Selected = true;;
            DGV1.DataSource = source;
            source.MoveLast();
            bindingdata();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            luu();
        }

        private void txtYears_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYears_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                getYears();
            }    
        }

        private void txtYears_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtYears.Text = FromCalender.getDate.ToString("yyyy");
            //frmDateTime dateTime = new frmDateTime();
            //dateTime.ShowDialog();
            //txtYears.Text = frmDateTime.Date.ToString("yyyy");
        }
    }
}
