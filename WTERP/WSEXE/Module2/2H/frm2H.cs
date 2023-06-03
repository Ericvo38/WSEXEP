using LibraryCalender;
using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2H : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source;
        System.Data.DataTable dt = new System.Data.DataTable();
        int index = 0;
        public frm2H()
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
        #region Load Data
        private void frm2H_Load(object sender, EventArgs e)
        {
            getInfo();
            LoadFirst();
            loadDGV1();
            ShowRecord();

            btndateNow.Text = con.getDateNow();

            if (txtQTY_ORD.Text == "")
                txtQTY_ORD.Text = "0.00";
            if (txtQTY_OUT_T.Text == "")
                txtQTY_OUT_T.Text = "0.00";
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
        }
        private void LoadFirst()
        {
            con.CheckLoad(menuStrip1);
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;

            btnDong.Hide();
            btnOk.Hide();
            btnDuyet.Text = "" + txtDuyet + "";
            btnSelect.Show();



        }
        public void getIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void UpdateData()
        {
            string K_NO = txtK_NO.Text;
            string NR = txtNR.Text;
            string WS_DATE = txtWS_DATE.Text;
            string C_NO = txtC_NO.Text;

            checkNofication();
            string a = "";
            string b = "";
            if (con.Check_MaskedText(txtPAY_M) == true)
            {
                a = con.formatstr1(txtPAY_M.Text);
            }
            if (con.Check_MaskedText(txtACT_MONTH) == true)
            {
                b = con.formatstr1(txtACT_MONTH.Text);
            }
            string str1 = "UPDATE ORDB SET PAY_M = '" + a + "', QTY_ORD = '" + txtQTY_ORD.Text +
                "', QTY_OUT_T = '" + txtQTY_OUT_T.Text + "', QTY_OUT = '" + txtQTY_OUT.Text + "', ACT_MONTH = '" + b + "' ,COVER = '" + txt20.Text +
                "' WHERE K_NO = '" + txtK_NO.Text + "' AND NR = '" + txtNR.Text + "' and WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and C_NO = '" + txtC_NO.Text + "'";
            bool dt = con.exedata(str1);
            if (dt == true)
            {
                LoadFirst();
                Search();
                DGV1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in DGV1.Rows)
                    {
                        if (row.Cells["K_NO"].Value.ToString().Equals(K_NO) && row.Cells["NR"].Value.ToString().Equals(NR) && row.Cells["WS_DATE"].Value.ToString() == WS_DATE && row.Cells["C_NO"].Value.ToString() == C_NO)
                        {
                            index = row.Index;
                            DGV1.Rows[index].Selected = true;
                            DGV1.CurrentCell = DGV1.Rows[index].Cells[2];
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                ShowRecord();
            }
            else
            {
                LoadFirst();
            }
        }
        public string CheckNgonNgu()
        {
            string sql = "";
            if (DataProvider.LG.rdVietNam == true)
            {
                sql = "K_NAME";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                sql = "K_NAME_EN";
            }
            if (DataProvider.LG.rdChina == true)
            {
                sql = "K_NAME_CN";
            }
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                sql = "K_NAME";
            }
            return sql;
        }
        private void loadDGV1()
        {
            string str1 = "SELECT ORDB.K_NO," + CheckNgonNgu() + " as K_NAME, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, BRAND, MODEL_C, MODEL_E, P_NAME_C, COLOR_C, COLOR_E, THICK, QTY, PRICE, PER_S, GRADE, QTY_OUT_T, QTY_OUT, QTY_ORD, ACT_MONTH, ACHI, PAY_M,COVER,ORDB.USR_NAME FROM ORDB INNER JOIN tbl_Type_New ON ORDB.K_NO = tbl_Type_New.K_NO where 1=1" +
                " ORDER BY WS_DATE DESC";
            dt = new System.Data.DataTable();
            dt = con.readdata(str1);
            source = new BindingSource();
            source.DataSource = dt;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
                    dr["PAY_M"] = con.formatstr1(dr["PAY_M"].ToString());
                    dr["ACT_MONTH"] = con.formatstr1(dr["ACT_MONTH"].ToString());
                }
                DGV1.DataSource = dt;
                //DGV1.RowHeadersVisible = false;


                DGV1.Columns["K_NO"].Visible = false;
                DGV1.Columns["C_NO"].Visible = false;
                DGV1.Columns["MODEL_E"].Visible = false;
                DGV1.Columns["COLOR_E"].Visible = false;
                DGV1.Columns["PAY_M"].Visible = false;
                con.DGV(DGV1);
            }
        }
        private void ShowRecord()
        {
            if (index == -1)
            {
                index = DGV1.CurrentRow.Index;
            }
            this.txtK_NO.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            lblNhan.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["K_NAME"].Value.ToString();
            txtWS_DATE.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["WS_DATE"].Value.ToString();
            txtNR.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["NR"].Value.ToString();
            txtOR_NO.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["OR_NO"].Value.ToString();
            txtC_NO.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            txtC_NAME_C.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["C_NAME_C"].Value.ToString();
            txtT_NAME.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["BRAND"].Value.ToString();
            txtMODEL_E.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["MODEL_E"].Value.ToString();
            txtP_NAME_C.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["P_NAME_C"].Value.ToString();
            txtCOLOR_E.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["COLOR_E"].Value.ToString();
            txtTHICK.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["THICK"].Value.ToString();
            txtQTY.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["QTY"].Value.ToString();
            txtPRICE.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["PRICE"].Value.ToString();
            txtPER_S.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["PER_S"].Value.ToString();
            txtGRADE.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["GRADE"].Value.ToString();
            txtQTY_OUT_T.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["QTY_OUT_T"].Value.ToString();
            txtQTY_OUT.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["QTY_OUT"].Value.ToString();
            txtQTY_ORD.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["QTY_ORD"].Value.ToString();
            txtACT_MONTH.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["ACT_MONTH"].Value.ToString();
            txtACHI.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["ACHI"].Value.ToString();
            txtPAY_M.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["PAY_M"].Value.ToString();
            txt20.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["COVER"].Value.ToString();
            txtUSR_NAME.Text = DGV1.Rows[this.DGV1.CurrentRow.Index].Cells["USR_NAME"].Value.ToString();
        }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV1.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            DGV1.Enabled = false;
            checkNofication();
            f1ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btnOk.Show();
            btnDong.Show();
            btnDuyet.Text = "" + txtSua + "";

            if ((txtQTY.Text != "") && (txtQTY_OUT.Text == "0") || (txtQTY_OUT.Text == "0.00"))
            {
                txtQTY_ORD.Text = txtQTY.Text;
                txtQTY_OUT_T.Text = "0.00";
            }
            else if ((txtQTY.Text != "") && (txtQTY_OUT.Text != "0") || (txtQTY_OUT.Text != "0.00"))
            {
                txtQTY_ORD.Text = txtQTY.Text;
                txtQTY_OUT_T.Text = txtQTY.Text;
            }
            txtK_NO.ReadOnly = true;
            txtWS_DATE.ReadOnly = true;
            txtNR.ReadOnly = true;
            txtOR_NO.ReadOnly = true;
            txtC_NO.ReadOnly = true;
            txtC_NAME_C.ReadOnly = true;
            txtT_NAME.ReadOnly = true;
            txtMODEL_E.ReadOnly = true;
            txtCOLOR_E.ReadOnly = true;
            txtP_NAME_C.ReadOnly = true;
            txtTHICK.ReadOnly = true;
            txtGRADE.ReadOnly = true;
            txtQTY.ReadOnly = true;
            txtPRICE.ReadOnly = true;
            txtPER_S.ReadOnly = true;
            txtQTY_OUT_T.ReadOnly = true;
            txtQTY_OUT.ReadOnly = true;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2HF7 f7 = new frm2HF7();
            f7.ShowDialog();
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingData(e.RowIndex);
        }

        private void BindingData(int index)
        {
            if (index == -1)
            {
                index = DGV1.CurrentRow.Index;
            }

            //Lưu lại dòng dữ liệu vừa kích chọn
            DataGridViewRow row = this.DGV1.Rows[index];
            //Đưa dữ liệu vào textbox

            this.txtK_NO.Text = row.Cells["K_NO"].Value.ToString();
            lblNhan.Text = row.Cells["K_NAME"].Value.ToString();
            txtWS_DATE.Text = row.Cells["WS_DATE"].Value.ToString();
            txtNR.Text = row.Cells["NR"].Value.ToString();
            txtOR_NO.Text = row.Cells["OR_NO"].Value.ToString();
            txtC_NO.Text = row.Cells["C_NO"].Value.ToString();
            txtC_NAME_C.Text = row.Cells["C_NAME_C"].Value.ToString();
            txtT_NAME.Text = row.Cells["BRAND"].Value.ToString();
            txtMODEL_E.Text = row.Cells["MODEL_E"].Value.ToString();
            txtP_NAME_C.Text = row.Cells["P_NAME_C"].Value.ToString();
            txtCOLOR_E.Text = row.Cells["COLOR_E"].Value.ToString();
            txtTHICK.Text = row.Cells["THICK"].Value.ToString();
            txtQTY.Text = row.Cells["QTY"].Value.ToString();
            txtPRICE.Text = row.Cells["PRICE"].Value.ToString();
            txtPER_S.Text = row.Cells["PER_S"].Value.ToString();
            txtGRADE.Text = row.Cells["GRADE"].Value.ToString();
            if (row.Cells["QTY_OUT_T"].Value.ToString() != "")
                txtQTY_OUT_T.Text = row.Cells["QTY_OUT_T"].Value.ToString();
            else
                txtQTY_OUT_T.Text = "0.00";
            txtQTY_OUT.Text = row.Cells["QTY_OUT"].Value.ToString();
            if (row.Cells["QTY_ORD"].Value.ToString() != "")
                txtQTY_ORD.Text = row.Cells["QTY_ORD"].Value.ToString();
            else
                txtQTY_ORD.Text = "0.00";
            txtACT_MONTH.Text = con.formatstr1(row.Cells["ACT_MONTH"].Value.ToString());
            txtACHI.Text = row.Cells["ACHI"].Value.ToString();
            txtPAY_M.Text = con.formatstr1(row.Cells["PAY_M"].Value.ToString());
            txt20.Text = row.Cells["COVER"].Value.ToString();
            txtUSR_NAME.Text = row.Cells["USR_NAME"].Value.ToString();
        }
        private void btnMoveFirst_Click(object sender, EventArgs e) //MoveFirst 
        {
            DGV1.ClearSelection();
            DGV1.Rows[0].Selected = true;
            source.DataSource = dt;
            DGV1.DataSource = source;
            source.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click(object sender, EventArgs e) //MovePrevious 
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
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click(object sender, EventArgs e) //MoveNext 
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
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click(object sender, EventArgs e) //MoveLast 
        {
            checkNofication();
            DGV1.ClearSelection();
            int so = DGV1.Rows.Count - 1;
            DGV1.Rows[so - 1].Selected = true;
            source.DataSource = dt;
            DGV1.DataSource = source;
            source.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            btnDuyet.Text = "" + txtDuyet + "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            index = DGV1.CurrentCell.RowIndex;
            DGV1.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            DGV1.Enabled = true;
            LoadFirst();
            loadDGV1();
            ShowRecord();
            DGV1.ClearSelection();
            DGV1.FirstDisplayedScrollingRowIndex = DGV1.Rows[index].Index;
            DGV1.Rows[index].Selected = true;

            txtK_NO.ReadOnly = false;
            txtWS_DATE.ReadOnly = false;
            txtNR.ReadOnly = false;
            txtOR_NO.ReadOnly = false;
            txtC_NO.ReadOnly = false;
            txtC_NAME_C.ReadOnly = false;
            txtT_NAME.ReadOnly = false;
            txtMODEL_E.ReadOnly = false;
            txtCOLOR_E.ReadOnly = false;
            txtP_NAME_C.ReadOnly = false;
            txtTHICK.ReadOnly = false;
            txtGRADE.ReadOnly = false;
            txtQTY.ReadOnly = false;
            txtPRICE.ReadOnly = false;
            txtPER_S.ReadOnly = false;
            txtQTY_OUT_T.ReadOnly = false;
            txtQTY_OUT.ReadOnly = false;
        }

        private void timer1_Tick(object sender, EventArgs e) //get timeNow 
        {
            btnTimeNow.Text = con.getTimeNow();
            btndateNow.Text = con.getDateNow();
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtDuyet = "";
        string txtSua = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtDuyet = "NÚT DUYỆT";
                txtSua = "SỬA";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtDuyet = "NÚT DUYỆT";
                txtSua = "SỬA";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtDuyet = "Browsing Button";
                txtSua = "EDIT";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtDuyet = "瀏覽按鈕";
                txtSua = "使固定";
            }
        }
        #endregion
        private void btnOk_Click(object sender, EventArgs e)
        {
            DGV1.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            DGV1.Enabled = true;
            //index = DGV1.CurrentCell.RowIndex;
            if (f4ToolStripMenuItem.Checked == true)
                UpdateData();
            // DGV1.FirstDisplayedScrollingRowIndex = DGV1.Rows[index].Index;
            // DGV1.Rows[index].Selected = true;
            txtK_NO.ReadOnly = false;
            txtWS_DATE.ReadOnly = false;
            txtNR.ReadOnly = false;
            txtOR_NO.ReadOnly = false;
            txtC_NO.ReadOnly = false;
            txtC_NAME_C.ReadOnly = false;
            txtT_NAME.ReadOnly = false;
            txtMODEL_E.ReadOnly = false;
            txtCOLOR_E.ReadOnly = false;
            txtP_NAME_C.ReadOnly = false;
            txtTHICK.ReadOnly = false;
            txtGRADE.ReadOnly = false;
            txtQTY.ReadOnly = false;
            txtPRICE.ReadOnly = false;
            txtPER_S.ReadOnly = false;
            txtQTY_OUT_T.ReadOnly = false;
            txtQTY_OUT.ReadOnly = false;
        }

        private void txtACT_MONTH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtACT_MONTH.Text = FromCalender.getDate.ToString("yy/MM");
            }
        }

        private void txtPAY_M_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtPAY_M.Text = FromCalender.getDate.ToString("yy/MM");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {
            string sql = "SELECT ORDB.K_NO," + CheckNgonNgu() + " as K_NAME, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, BRAND, MODEL_C, MODEL_E, P_NAME_C, COLOR_C, COLOR_E, THICK, QTY, PRICE, PER_S, GRADE, QTY_OUT_T, QTY_OUT, QTY_ORD, ACT_MONTH, ACHI, PAY_M,COVER,ORDB.USR_NAME FROM ORDB INNER JOIN tbl_Type_New ON ORDB.K_NO = tbl_Type_New.K_NO where 1=1";

            if ((txC_NO.Text == "") && (tx_CNAME_C.Text == "") && (tx_CNAME_E.Text == "") && (tx_OR_NO.Text == "") && (tx_BRAND.Text == "") && (tx_COLOR_C.Text == "") && (tx_COLOR_E.Text == "") && (tx_PNAME_C.Text == "") && (tx_PNAME_E.Text == "") && (tx_THICK.Text == ""))
            {
                sql = sql + "";
            }
            if (tx_OR_NO.Text != "")
                sql = sql + " AND OR_NO LIKE N'%" + tx_OR_NO.Text + "%' ";
            if (txC_NO.Text != "")
                sql = sql + " AND C_NO LIKE N'%" + txC_NO.Text + "%'";
            if (tx_CNAME_C.Text != "")
                sql = sql + " AND C_NAME_C LIKE N'%" + tx_CNAME_C.Text + "%'";
            if (tx_CNAME_E.Text != "")
                sql = sql + " AND C_NAME_E LIKE N'%" + tx_CNAME_E.Text + "%'";
            if (tx_BRAND.Text != "")
                sql = sql + " AND BRAND LIKE N'%" + tx_BRAND.Text + "%'";
            if (tx_COLOR_C.Text != "")
                sql = sql + " AND COLOR_C LIKE N'%" + tx_COLOR_C.Text + "%'";
            if (tx_COLOR_E.Text != "")
                sql = sql + " AND COLOR_E LIKE N'%" + tx_COLOR_E.Text + "%'";
            if (tx_PNAME_C.Text != "")
                sql = sql + " AND P_NAME_C LIKE N'%" + tx_PNAME_C.Text + "%'";
            if (tx_PNAME_E.Text != "")
                sql = sql + " AND P_NAME_E LIKE N'%" + tx_PNAME_E.Text + "%'";
            if (tx_THICK.Text != "")
                sql = sql + " AND THICK LIKE N'%" + tx_THICK.Text + "%'";
            sql = sql + " ORDER BY WS_DATE DESC,NR DESC";
            DataTable dtSearch = con.readdata(sql);
            if (dtSearch.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSearch.Rows)
                    dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
                DGV1.DataSource = dtSearch;
                ShowRecord();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu, vui lòng kiểm tra lại!!");
            }


        }

        private void txC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(txNgaydat, tx_CNAME_C, sender, e);
        }

        private void tx_CNAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(txC_NO, tx_CNAME_E, sender, e);
        }

        private void tx_CNAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_CNAME_C, tx_OR_NO, sender, e);
        }

        private void tx_OR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_CNAME_E, tx_BRAND, sender, e);
        }

        private void tx_BRAND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_OR_NO, tx_COLOR_C, sender, e);
        }

        private void tx_COLOR_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_BRAND, tx_COLOR_E, sender, e);
        }

        private void tx_COLOR_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_COLOR_C, tx_PNAME_C, sender, e);
        }

        private void tx_PNAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_COLOR_E, tx_PNAME_E, sender, e);
        }

        private void tx_PNAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_PNAME_C, tx_THICK, sender, e);
        }

        private void tx_THICK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
            con.tab(tx_PNAME_E, txtK_NO, sender, e);
        }

        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();

        }

        private void txtK_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tx_THICK, txtWS_DATE, sender, e);
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtK_NO, txtNR, sender, e);
        }

        private void txtNR_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWS_DATE, txtOR_NO, sender, e);
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtNR, txtC_NO, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtOR_NO, txtC_NAME_C, sender, e);
        }

        private void txtC_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NO, txtT_NAME, sender, e);
        }

        private void txtT_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME_C, txtMODEL_E, sender, e);
        }

        private void txtMODEL_E_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtT_NAME, txtCOLOR_E, sender, e);
        }

        private void txtCOLOR_E_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMODEL_E, txtP_NAME_C, sender, e);
        }

        private void txtP_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCOLOR_E, txtGRADE, sender, e);
        }

        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME_C, txtGRADE, sender, e);
        }

        private void txtGRADE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTHICK, txt20, sender, e);
        }

        private void txt20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtGRADE, txtQTY, sender, e);
        }

        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txt20, txtPRICE, sender, e);
        }

        private void txtPRICE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtQTY, txtPER_S, sender, e);
        }

        private void txtPER_S_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPRICE, txtACHI, sender, e);
        }

        private void txtACHI_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtPER_S, txtPAY_M, sender, e);
        }

        private void txtPAY_M_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtACHI, txtACT_MONTH, sender, e);
        }

        private void txtQTY_ORD_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtPAY_M, txtQTY_OUT_T, sender, e);
        }

        private void txtQTY_OUT_T_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtQTY_ORD, txtQTY_OUT, sender, e);
        }

        private void txtQTY_OUT_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtQTY_OUT_T, txtACT_MONTH, sender, e);
        }

        private void txtACT_MONTH_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtQTY_OUT, tx1, sender, e);
        }

        private void tx1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(tx1, txnamthang, sender, e);
        }

        private void txnamthang_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(tx1, txNgaydat, sender, e);
        }

        private void txNgaydat_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txnamthang, txC_NO, sender, e);
        }

        private void txtK_NO_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                DGV1.ClearSelection();
                //DGV1.Rows[e.NewValue].Selected = true;
                DGV1.CurrentCell = DGV1.Rows[e.NewValue].Cells[1];
                BindingData(e.NewValue);
            }
        }

        private void txnamthang_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txnamthang.Text = FromCalender.getDate.ToString("yyMM");
        }
    }
}
