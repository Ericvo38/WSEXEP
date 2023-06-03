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
    public partial class frm2Q : Form
    {
        DataProvider con = new DataProvider();
        public frm2Q()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent(); 
            this.DGV1.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            con.Mousewheelscroll(DGV1, e);
            BindingData(con.RowIndexs);
        }
        public void BindingData(int index)
        {
            if (index == -1)
            {
                index = DGV1.CurrentRow.Index;
            }
            txtP_WT.Text = DGV1.Rows[index].Cells["P_WT"].Value.ToString();
            txtP_WTI.Text = DGV1.Rows[index].Cells["P_WTI"].Value.ToString();
            txtP_NAME1.Text = DGV1.Rows[index].Cells["P_NAME1"].Value.ToString();
            txtP_NAME2.Text = DGV1.Rows[index].Cells["P_NAME2"].Value.ToString();
        }
        BindingSource source = new BindingSource();
        public DataTable dt = new DataTable();
        #region LoadData
        private void frm2Q_Load(object sender, EventArgs e)
        {
            getInfo();
            Load_Data();
            ShowTextbox();
            loadfisrt();
        }
        public void loadfisrt()
        {
            btok.Hide();
            btdong.Hide();

            con.CheckLoad(menuStrip1);

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            txtP_WT.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
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
            lbUserName.Text = con.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
            btndateNow.Text = con.getDateNow(); // get DateNow
        }
        public void Load_Data()
        {
            string SQL = "select P_WT, P_WTI, P_NAME1, P_NAME2 from PROD_MATERIAL";
            dt = con.readdata(SQL);
            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }
        public void ShowTextbox()
        {
            txtP_WT.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            txtP_WTI.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WTI"].Value.ToString();
            txtP_NAME1.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NAME1"].Value.ToString();
            txtP_NAME2.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NAME2"].Value.ToString();
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtP_WT.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            txtP_WTI.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WTI"].Value.ToString();
            txtP_NAME1.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NAME1"].Value.ToString();
            txtP_NAME2.Text = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_NAME2"].Value.ToString();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            Load_Data();
            ShowTextbox();

            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            txtP_WT.Enabled = true;
        }
        private void btdau_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            DGV1.Rows[0].Selected = true;
            DGV1.DataSource = dt;
            DGV1.DataSource = source;
            source.MoveFirst();

            ShowTextbox();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = DGV1.CurrentRow.Index;
                if (DGV1.Rows.Count > IndexNow)
                {
                    DGV1.Rows[IndexNow - 1].Selected = true;
                }

                source.DataSource = dt;
                DGV1.DataSource = source;
                source.MovePrevious();
            }
            catch (Exception)
            {

            }
            ShowTextbox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = DGV1.CurrentRow.Index;
                if (DGV1.Rows.Count > IndexNow)
                {
                    DGV1.Rows[IndexNow + 1].Selected = true;
                }

                source.DataSource = dt;
                DGV1.DataSource = source;
                source.MoveNext();
            }
            catch (Exception)
            {

            }

            ShowTextbox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            int so = DGV1.Rows.Count - 1;
            DGV1.Rows[so - 1].Selected = true;
            source.DataSource = dt;
            DGV1.DataSource = source;
            source.MoveLast();

            ShowTextbox();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtSua = "SỬA";
                txtThem = "THÊM";
                txtXoa = "XÓA";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtSua = "EDIT";
                txtThem = "ADD";
                txtXoa = "DELETE";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtSua = "使固定";
                txtThem = "更多的";
                txtXoa = "刪除";
            }
        }
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                string st1 = "INSERT INTO PROD_MATERIAL(P_WT, P_WTI, P_NAME1, P_NAME2)  VALUES('"+txtP_WT.Text+"','"+txtP_WTI.Text+"','"+txtP_NAME1.Text+"','"+txtP_NAME2.Text+"')";
                con.exedata(st1);
                btdong.PerformClick();
            }
            else if(f3ToolStripMenuItem.Checked == true)
            {
                string st2 = "DELETE FROM PROD_MATERIAL WHERE P_WT = '" + txtP_WT.Text + "'";
                bool KQ = con.exedata(st2);
                con.exedata(st2);
                btdong.PerformClick();
            }
            else if(f4ToolStripMenuItem.Checked == true)
            {
                string st3 = "UPDATE PROD_MATERIAL SET P_WT = '" + txtP_WT.Text + "', P_WTI = '" + txtP_WTI.Text+ "', P_NAME1 = '" + txtP_NAME1.Text + "', P_NAME2 = '" + txtP_NAME2.Text + "' WHERE P_WT = '" + txtP_WT.Text + "'";
                bool KQ = con.exedata(st3);
                con.exedata(st3);
                btdong.PerformClick();
            }
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frm2QF5 fr = new frm2QF5();
            fr.ShowDialog();

            string DL = frm2QF5.Get_PWT;
            if (DL != string.Empty)
            {
                string SQL = "select P_WT, P_WTI, P_NAME1, P_NAME2 from PROD_MATERIAL WHERE P_WT='" + DL + "'";
                DataTable dt2 = con.readdata(SQL);
                foreach (DataRow dr in dt2.Rows)
                {
                    txtP_WT.Text = dr["P_WT"].ToString();
                    txtP_WTI.Text = dr["P_WTI"].ToString();
                    txtP_NAME1.Text = dr["P_NAME1"].ToString();
                    txtP_NAME2.Text = dr["P_NAME2"].ToString();
                }
            }
            else
            {
                Load_Data();
                ShowTextbox();
            }
             
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            bt.Text = ""+txtThem+"";
            f2ToolStripMenuItem.Checked = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            txtP_WT.Text = "";
            txtP_WTI.Text = "";
            txtP_NAME1.Text = "";
            txtP_NAME2.Text = "";
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            bt.Text = ""+txtXoa+"";
            f3ToolStripMenuItem.Checked = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
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
            bt.Text = ""+txtSua+"";
            f4ToolStripMenuItem.Checked = true;

            btok.Show();
            btdong.Show();

            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            txtP_WT.Enabled = false;
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

        private void txtP_WT_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME2, txtP_WTI, sender, e);
        }

        private void txtP_NAME1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NAME2, txtP_NAME2, sender, e);
        }

        private void txtP_NAME2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NAME1, txtP_WT, sender, e);
        }

        private void txtP_WTI_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_WT, txtP_NAME1, sender, e);
        }
    }
}
