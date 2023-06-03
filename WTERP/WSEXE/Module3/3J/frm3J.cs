using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3J : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        public frm3J()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtLuuTC = "";
        string txtLuuTB = "";
        string txtXoaTC = "";
        string txtXoaTB = "";
        string txtThem = "";
        string txtDuyet = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thành Công";
                txtXoaTB = "Xóa Thất Bại";
                txtThem = "THÊM";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thất Bại";
                txtThem = "THÊM";
                txtDuyet = "DUYỆT";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtLuuTC = "Save successfully";
                txtLuuTB = "Save Failed";
                txtXoaTC = "Delete Successfully";
                txtXoaTB = "Delete Failed";
                txtThem = "ADD";
                txtDuyet = "BROWSER";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtLuuTC = "保存成功";
                txtLuuTB = "保存失敗";
                txtXoaTC = "刪除成功";
                txtXoaTB = "刪除失敗";
                txtThem = "更多的";
                txtDuyet = "瀏覽器";
            }
        }
        #endregion
        private void frm3J_Load(object sender, EventArgs e)
        {
            LoadFirst();
            loadinfo();

        }
        void loadinfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = con.getDateNow();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }
        void LoadFirst()
        {
            checkNofication();
            con.CheckLoad(menuStrip1);
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;

            btnOk.Hide();
            btnDong.Hide();
            btnDuyet.Text = ""+txtDuyet+"";

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            LoadData();
        }
        #region Menu ToolStrip 
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btnOk.Show();
            btnDong.Show();
            btnDuyet.Text = ""+txtThem+"";

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btnOk.Show();
            btnDong.Show();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f5ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = true;

            btnOk.Show();
            btnDong.Show();

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3JF5 fm = new frm3JF5();
            fm.ShowDialog();
            textBox1.Text = frm3JF5.Share3JF5.MK_NO;
            textBox2.Text = frm3JF5.Share3JF5.SOURCE;
            textBox3.Text = frm3JF5.Share3JF5.UKG;
            textBox4.Text = frm3JF5.Share3JF5.WKG;
            textBox5.Text = frm3JF5.Share3JF5.BPCS;
            textBox6.Text = frm3JF5.Share3JF5.CARNO;
            txtUSR_NAME.Text = frm3JF5.Share3JF5.USR_NAME;

            frm3JF5.Share3JF5.MK_NO = "";
            frm3JF5.Share3JF5.SOURCE = "";
            frm3JF5.Share3JF5.UKG = "";
            frm3JF5.Share3JF5.WKG = "";
            frm3JF5.Share3JF5.BPCS = "";
            frm3JF5.Share3JF5.CARNO = "";
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        void LoadData()
        {
            string SQL1 = "select MK_NO, SOURCE, UKG, WKG, BPCS, CARNO, USR_NAME from ASOURCE ";
            DataTable dt = con.readdata(SQL1);
            source = new BindingSource();
            foreach (DataRow row in dt.Rows)
                source.Add(row);
            ShowRecord();
        }

        private void ShowRecord()
        {
            DataRow currenRow = (DataRow)source.Current;

            textBox1.Text = currenRow["MK_NO"].ToString();
            textBox2.Text = currenRow["SOURCE"].ToString();
            textBox3.Text = currenRow["UKG"].ToString();
            textBox4.Text = currenRow["WKG"].ToString();
            textBox5.Text = currenRow["BPCS"].ToString();
            textBox6.Text = currenRow["CARNO"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
        }
        private void btnMoveFirst_Click_1(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click_1(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click_1(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click_1(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true)
            {
                    AddData();
                    LoadFirst();
            }
            if(f3ToolStripMenuItem.Checked == true)
            {
                    Delete();
                    LoadFirst();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                    Repair();
                    LoadFirst();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            LoadFirst();
        }
        #region Method Add, Delete, Repair
        void AddData()
        {
            checkNofication();
            try
            {
                string SQL1 = "INSERT INTO ASOURCE (MK_NO, SOURCE, CARNO, WKG, USR_NAME, UKG, BPCS) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + txtUSR_NAME.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";
                bool Results = con.exedata(SQL1);
                if (Results == true)
                    MessageBox.Show(""+txtLuuTC+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show(""+txtLuuTB+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch (Exception err1)
            {

                MessageBox.Show(err1.Message);
            }
                
        }
        void Delete()
        {
            checkNofication();
            try
            {
                string SQL2 = "DELETE ASOURCE WHERE MK_NO = '" + textBox1.Text + "' AND SOURCE = '" + textBox2.Text + "' ";
                bool Results = con.exedata(SQL2);
                if (Results == true)
                    MessageBox.Show(""+txtXoaTC+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show(""+txtXoaTB+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err2)
            {
                MessageBox.Show(err2.Message);
            }
        }
        void Repair()
        {
            checkNofication();
            try
            {
                string SQL3 = "UPDATE ASOURCE SET CARNO = '" + textBox6.Text + "', WKG = '" + textBox4.Text + "', USR_NAME = '" + txtUSR_NAME.Text + "', UKG = '" + textBox3.Text + "', BPCS = '" + textBox5.Text + "' WHERE MK_NO = '" + textBox1.Text + "' AND SOURCE = '" + textBox2.Text + "' ";
                bool Results = con.exedata(SQL3);
                if (Results == true)
                    MessageBox.Show(""+txtLuuTC+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("" + txtLuuTB + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err3)
            {
                MessageBox.Show(err3.Message);
            }
        }
        #endregion
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
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox1, textBox2, sender, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox1, textBox3, sender, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox2, textBox4, sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox3, textBox2, sender, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox4, textBox6, sender, e);
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox5, textBox6, sender, e);
        }
    }
}
