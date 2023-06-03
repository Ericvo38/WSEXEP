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
    public partial class frm3K : Form
    {
        DataProvider con = new DataProvider();
        DataTable dt = new DataTable();
        BindingSource source;
        public frm3K()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }

        private void frm3K_Load(object sender, EventArgs e)
        {
            Loadfirst();
            loadinfo();
            LoadDGV();
        }
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtLuuTC = "";
        string txtLuuTB = "";
        string txtXoaTC = "";
        string txtDuyet = "";
        string txtText = "";
        string txtText1 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thành Công";
                txtDuyet = "DUYỆT";
                txtText = "Mã Vật Liệu không tồn tại";
                txtText1 = "Độ dày này không tồn tại";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtLuuTC = "Lưu Thành Công";
                txtLuuTB = "Lưu Thất Bại";
                txtXoaTC = "Xóa Thất Bại";
                txtDuyet = "DUYỆT";
                txtText = "Mã Vật Liệu không tồn tại";
                txtText1 = "Độ dày này không tồn tại";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtLuuTC = "Save successfully";
                txtLuuTB = "Save Failed";
                txtXoaTC = "Delete Successfully";
                txtDuyet = "BROWSER";
                txtText = "Material Code does not exist";
                txtText1 = "This thickness does not exist";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtLuuTC = "保存成功";
                txtLuuTB = "保存失敗";
                txtXoaTC = "刪除成功";
                txtDuyet = "瀏覽器";
                txtText = "材料代碼不存在";
                txtText1 = "這個厚度不存在";
            }
        }
        #endregion
        void Loadfirst()
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

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            LoadDGV();
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
        void LoadDGV()
        {
            string SQL = "SELECT * FROM BNOPNO ";
            dt = con.readdata(SQL);
            DGV1.DataSource = dt;
            DGV1.MyDGV();
            DGV1.Columns["BRAND"].Visible = false;
            DGV1.Columns["P_NAME"].Visible = false;
            DGV1.Columns["USR_NAME"].Visible = false;
            DGV1.Columns["UPDATEKIND"].Visible = false;
            DGV1.Columns["THICK"].Visible = false;
            process();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }

        #region Button Move (MoveFirst, MovePrevious, MoveNext, MoveLast) 
        public void process()
        {
            string s1 = "SELECT * FROM BNOPNO";
            DataTable dt1 = con.readdata(s1);
            source = new BindingSource();
            foreach (DataRow row in dt.Rows)
                source.Add(row);
            ShowRecord();
        }
        private void ShowRecord()
        {
            DataRow currenRow = (DataRow)source.Current;

            txtMaTH.Text = currenRow["B_NO"].ToString();
            txtTenTH_E.Text = currenRow["BRAND"].ToString();
            txtTenTH_C.Text = currenRow["TRADE"].ToString();
            txtMaLieu.Text = currenRow["P_NO"].ToString();
            txtTenLieu_E.Text = currenRow["P_NAME"].ToString();
            txtTenLieu_C.Text = currenRow["P_NAME1"].ToString();
            txtTHICK.Text = currenRow["THICK"].ToString();
            txtTyLe.Text = currenRow["FF01"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTH.Text = DGV1.CurrentRow.Cells["B_NO"].Value + "";
            txtTenTH_E.Text = DGV1.CurrentRow.Cells["BRAND"].Value + "";
            txtTenTH_C.Text = DGV1.CurrentRow.Cells["TRADE"].Value + "";
            txtMaLieu.Text = DGV1.CurrentRow.Cells["P_NO"].Value + "";
            txtTenLieu_E.Text = DGV1.CurrentRow.Cells["P_NAME"].Value + "";
            txtTenLieu_C.Text = DGV1.CurrentRow.Cells["P_NAME1"].Value + "";
            txtTHICK.Text = DGV1.CurrentRow.Cells["THICK"].Value + "";
            txtTyLe.Text = DGV1.CurrentRow.Cells["FF01"].Value + "";
            txtUSR_NAME.Text = DGV1.CurrentRow.Cells["USR_NAME"].Value + "";
        }
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }
        #endregion

        #region Process ToolStripMenu 
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Adding Data 
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnOk.Show();
            btnDong.Show();
            txtMaTH.Clear();
            txtMaTH.ReadOnly = false;
            txtTenTH_E.Clear();
            txtTenTH_C.Clear();

            txtMaLieu.Clear();
            txtMaLieu.ReadOnly = false;
            txtTenLieu_E.Clear();
            txtTenLieu_C.Clear();

            txtTHICK.Clear();
            txtTHICK.ReadOnly = false;
            txtTyLe.Text = "85";
            txtTyLe.ReadOnly = false;
            txtMaTH.Focus();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) // F3 Deleting Data 
        {
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnOk.Show();
            btnDong.Show();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Repairing Data 
        {
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f6ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnOk.Show();
            btnDong.Show();

            txtTyLe.ReadOnly = false;
            txtTyLe.Focus();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e) // F6 Coping Data 
        {
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = true;
            f12ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnOk.Show();
            btnDong.Show();

            txtMaTH.ReadOnly = false;
            txtMaTH.Focus();
            txtMaLieu.ReadOnly = false;
            txtTHICK.ReadOnly = false;
            txtTyLe.ReadOnly = false;
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) // f12 Exit App 
        {
            this.Close();
        }
        #endregion

        #region Method Add, Delete, repair 
        void AddingData()
        {
            checkNofication();
            try
            {
               string SQL1 = "INSERT INTO BNOPNO (B_NO, P_NO, BRAND, TRADE, P_NAME, P_NAME1, FF01, USR_NAME,THICK) VALUES ('" + txtMaTH.Text + "', '" + txtMaLieu.Text + "', '" + txtTenTH_E.Text + "', '" + txtTenTH_C.Text + "', '" + txtTenLieu_E.Text + "', '" + txtTenLieu_C.Text + "', '" + txtTyLe.Text + "','" + lbUserName.Text + "', '" + txtTHICK.Text + "') ";
               bool add = con.exedata(SQL1);
               if (add == true)
                    MessageBox.Show(""+txtLuuTC+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(""+txtLuuTB+"", ""+txtThongBao+"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception err1)
            {

                MessageBox.Show(err1.Message);
            }
            finally
            {
                con.Closeconnect();
            }
        }
        void DeleteData()
        {
            checkNofication();
            try
            {
                string SQL2 = "SELECT B_NO, P_NO FROM BNOPNO";
                DataTable dt = con.readdata(SQL2);
                bool Results = txtMaTH.CheckText(dt, "B_NO");
                bool Results2 = txtMaLieu.CheckText(dt, "P_NO");
                if (Results==true && Results2 == true)
                {
                    string SQL21 = "DELETE FROM BNOPNO WHERE B_NO = '" + txtMaTH.Text + "' AND P_NO = '" + txtMaLieu.Text+"' ";
                    bool dele = con.exedata(SQL21);
                    if (dele == true)
                        MessageBox.Show(""+txtXoaTC+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(""+txtLuuTB+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err2)
            {
                MessageBox.Show(err2.Message);
            }
        }
        void RepairData()
        {
            checkNofication();
            try
            {
                string SQL2 = "SELECT B_NO, P_NO FROM BNOPNO";
                DataTable dt = con.readdata(SQL2);
                bool contains = txtMaTH.CheckText(dt, "B_NO");
                bool contains2 = txtMaLieu.CheckText(dt, "P_NO");
                if (contains == true && contains2 == true)
                {
                    string SQL3 = "UPDATE BNOPNO SET FF01 = '" + txtTyLe.Text + "' WHERE B_NO = '"+txtMaTH.Text+"' AND P_NO = '"+txtMaLieu.Text+"' ";
                    bool Exe = con.exedata(SQL3);
                    if (Exe == true)
                        MessageBox.Show(""+txtLuuTC+"", ""+txtThongBao+"");
                    else
                        MessageBox.Show("" + txtLuuTB + "", "" + txtThongBao + "");
                }
            }
            catch (Exception err3)
            {
                MessageBox.Show(err3.Message);
            }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true) // Adding
            {
                    AddingData();
                    Loadfirst();
            }
            if(f3ToolStripMenuItem.Checked == true)
            {
              
                    DeleteData();
                    Loadfirst();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                    RepairData();
                    Loadfirst();
            }
            if(f6ToolStripMenuItem.Checked == true)
            {
                    AddingData();
                    Loadfirst();
            }
        }

        private void btnDong_Click(object sender, EventArgs e) // Button Đóng  
        {
            Loadfirst();
        }

        private void txtMaTH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchBrand fm = new FormSearchBrand();
                fm.ShowDialog();
                txtMaTH.Text = FormSearchBrand.ID.B_NO;
                txtTenTH_E.Text = FormSearchBrand.ID.TRADE;
                txtTenTH_C.Text = FormSearchBrand.ID.BRAND;
            }
        }

        private void txtMaLieu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchMaterial2 fm = new FormSearchMaterial2();
                fm.ShowDialog();
                txtMaLieu.Text = FormSearchMaterial2.ID.ID_P_NO;
                txtTenLieu_E.Text = FormSearchMaterial2.ID.P_NAME;
                txtTenLieu_C.Text = FormSearchMaterial2.ID.P_NAME1;
            }
        }
        private void txtMaTH_Leave(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (txtMaTH.Text != string.Empty)
                {
                    string SQL2 = "SELECT B_NO FROM BRAND";
                    DataTable dt = con.readdata(SQL2);
                    bool Results = txtMaTH.CheckText(dt, "B_NO");
                    if (Results == false)
                    {
                        checkNofication();
                        MessageBox.Show(""+txtText+"", ""+txtThongBao+"");
                        txtMaTH.Focus();
                    }
                }
            }
        }

        private void txtMaLieu_Leave(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (txtMaLieu.Text != string.Empty)
                {
                    checkNofication();
                    string SQL2 = "SELECT P_NO FROM PROD";
                    DataTable dt = con.readdata(SQL2);
                    bool Results = txtMaLieu.CheckText(dt, "P_NO");
                    if (Results == false)
                    {
                        MessageBox.Show(" "+txtText+"", ""+txtThongBao+"");
                        txtMaLieu.Focus();
                    }
                }
            }
        }

        private void txtTHICK_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchThick2 fm = new FormSearchThick2();
            fm.ShowDialog();
            txtTHICK.Text = FormSearchThick2.ID.ID_THICK;
        }

        private void txtTHICK_Leave(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (txtTHICK.Text != string.Empty)
                {
                    string SQL4 = "select T_NO, T_NAME from dbo.THICK";
                    DataTable dt = con.readdata(SQL4);
                    bool Results = txtTHICK.CheckText(dt, "T_NAME");
                    if (Results == false)
                    {
                        MessageBox.Show(""+txtText1+"", ""+txtThongBao+"");
                        txtTHICK.Clear();
                        txtTHICK.Focus();
                    }
                }
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

        private void txtMaTH_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMaTH, txtTenTH_E, sender, e);
        }

        private void txtTenTH_E_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMaTH, txtTenTH_C, sender, e);
        }

        private void txtTenTH_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTenTH_E, txtMaLieu, sender, e);
        }

        private void txtMaLieu_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTenTH_C, txtTenLieu_E, sender, e);
        }

        private void txtTenLieu_E_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMaLieu, txtTenLieu_C, sender, e);
        }

        private void txtTenLieu_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTenLieu_E, txtTHICK, sender, e);
        }

        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTenLieu_C, txtTyLe, sender, e);
        }

        private void txtTyLe_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTHICK, txtTyLe, sender, e);
        }
    }
}
