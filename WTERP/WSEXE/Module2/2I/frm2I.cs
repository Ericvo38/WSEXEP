using LibraryCalender;
using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frm2I : Form
    {
        DataProvider con = new DataProvider();
        public BindingSource bindingsource;
        public DataTable datatable = new DataTable();
       
        public frm2I()
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
        string WS_DATE1 = "";
        string WS_DATE2 = "";
        string stt = "";
        public void check()
        {
            if (con.Check_MaskedText(txtWS_DATE) == true)
            {
                WS_DATE1 = con.formatstr1(txtWS_DATE.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE_C) == true)
            {
                WS_DATE2 = con.formatstr1(txtWS_DATE_C.Text);
            }
        }
        #region Load data
        private void frm2I_Load(object sender, EventArgs e)
        {
            getIP();
            loadfirst();
            LoadData();
            BindingData(-1);
            con.DGV(DGV1);
            Color_Data();
            btndau.Enabled = false;
            btntruoc.Enabled = false;
        }
        //get time 
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = con.getTimeNow();
        }
        private void loadfirst()
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            con.CheckLoad(menuStrip1);

            btnAction.Visible = false;
            btnClose.Visible = false;

            btndau.Enabled = false;
            btntruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            DGV1.Enabled = true;
        }
        public void Color_Data() // Loading Color DataGridView 
        {
            DGV1.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in DGV1.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["K_NO"].Value.ToString()))
                {
                    if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("1"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("2"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkCyan;
                    }
                    else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("3"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("4"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("7"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Indigo;
                    }
                    else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("6"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        public void LoadData()
        {
                string SQL = "select TOP 500 "+ CheckNgonNgu() + " as K_NAME,ORDBC.K_NO, WS_DATE, NR, NR1, OR_NO, C_NO, C_NAME_C, BRAND, P_NO, P_NAME_C,P_NAME_E, PATT_C, COLOR_C, MODEL_C, THICK, QTY, PRICE, WS_DATE_C, P_NO_C, P_NAME_C_C,P_NAME_E_C, THICK_C, " +
                    "QTY_C, PRICE_C, DEV_PROD, CHANG_INFO, OR_NO_C, B_NO_C, BRAND_C, T_NAME_C, COLOR_C_C, COLOR_E_C, C_NO_C, C_NAME_C_C, C_NAME_E_C, PATT_C_C, PATT_E_C,USR_NAME from ORDBC INNER JOIN tbl_Type_New ON ORDBC.K_NO = tbl_Type_New.K_NO" + frm2IF5.getinfo.where;
                    SQL = SQL + " ORDER BY WS_DATE_C DESC";
                datatable = con.readdata(SQL);
                if (datatable.Rows.Count > 0)
                {
                    bindingsource = new BindingSource();
                    bindingsource.DataSource = datatable;
                    DGV1.DataSource = bindingsource;
                    foreach (DataRow dr in datatable.Rows)
                    {
                        dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
                        dr["WS_DATE_C"] = con.formatstr1(dr["WS_DATE_C"].ToString());
                    }
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
        public void BindingData(int index)
        {
            if (index == -1)
            {
                index = DGV1.CurrentRow.Index;
            }
            this.txtK_NO.Text = DGV1.Rows[index].Cells["K_NO"].Value.ToString();
            this.txtWS_DATE.Text = DGV1.Rows[index].Cells["WS_DATE"].Value.ToString();
            this.txtNR.Text = DGV1.Rows[index].Cells["NR"].Value.ToString();
            this.txtOR_NO.Text = DGV1.Rows[index].Cells["OR_NO"].Value.ToString();
            this.txtC_NO.Text = DGV1.Rows[index].Cells["C_NO"].Value.ToString();

            this.txtC_NAME_C.Text = DGV1.Rows[index].Cells["C_NAME_C"].Value.ToString();
            this.txtBRAND.Text = DGV1.Rows[index].Cells["BRAND"].Value.ToString();
            this.txtP_NO.Text = DGV1.Rows[index].Cells["P_NO"].Value.ToString();
            this.txtP_NAME_C.Text = DGV1.Rows[index].Cells["P_NAME_C"].Value.ToString();
            this.txtPATT_C.Text = DGV1.Rows[index].Cells["PATT_C"].Value.ToString();

            this.txtCOLOR_C.Text = DGV1.Rows[index].Cells["COLOR_C"].Value.ToString();
            this.txtMODEL_C.Text = DGV1.Rows[index].Cells["MODEL_C"].Value.ToString();
            this.txtTHICK.Text = DGV1.Rows[index].Cells["THICK"].Value.ToString();
            this.txtQTY.Text = string.Format("{0:0.00}", float.Parse(DGV1.Rows[index].Cells["QTY"].Value.ToString()));
            this.txtPRICE.Text = string.Format("{0:0.00}", float.Parse(DGV1.Rows[index].Cells["PRICE"].Value.ToString()));

            this.txtWS_DATE_C.Text = DGV1.Rows[index].Cells["WS_DATE_C"].Value.ToString();
            this.txtP_NO_C.Text = DGV1.Rows[index].Cells["P_NO_C"].Value.ToString();
            this.txtP_NAME_C_C.Text = DGV1.Rows[index].Cells["P_NAME_C_C"].Value.ToString();
            this.txtTHICK_C.Text = DGV1.Rows[index].Cells["THICK_C"].Value.ToString();
            this.txtQTY_C.Text = string.Format("{0:0.00}", float.Parse(DGV1.Rows[index].Cells["QTY_C"].Value.ToString()));

            this.txtPRICE_C.Text = string.Format("{0:0.00}", float.Parse(DGV1.Rows[index].Cells["PRICE_C"].Value.ToString()));
            this.txtDEV_PROD.Text = DGV1.Rows[index].Cells["DEV_PROD"].Value.ToString();
            this.txtCHANG_INFO.Text = DGV1.Rows[index].Cells["CHANG_INFO"].Value.ToString();
            this.txtOR_NO_C.Text = DGV1.Rows[index].Cells["OR_NO_C"].Value.ToString();
            this.txtB_NO_C.Text = DGV1.Rows[index].Cells["B_NO_C"].Value.ToString();

            this.txt_BRAND_C.Text = DGV1.Rows[index].Cells["BRAND_C"].Value.ToString();
            this.txtT_NAME_C.Text = DGV1.Rows[index].Cells["T_NAME_C"].Value.ToString();
            this.txtCOLOR_C_C.Text = DGV1.Rows[index].Cells["COLOR_C_C"].Value.ToString();
            this.txtCOLOR_E_C.Text = DGV1.Rows[index].Cells["COLOR_E_C"].Value.ToString();

            this.txtC_NO_C.Text = DGV1.Rows[index].Cells["C_NO_C"].Value.ToString();
            this.txtC_NAME_C_C.Text = DGV1.Rows[index].Cells["C_NAME_C_C"].Value.ToString();
            this.txtC_NAME_E_C.Text = DGV1.Rows[index].Cells["C_NAME_E_C"].Value.ToString();

            this.txtPATT_C_C.Text = DGV1.Rows[index].Cells["PATT_E_C"].Value.ToString();
            this.txtPATT_E_C.Text = DGV1.Rows[index].Cells["PATT_C_C"].Value.ToString();
            this.txtUSR_NAME.Text = DGV1.Rows[index].Cells["USR_NAME"].Value.ToString();

            //new
            this.txtP_NAME_E.Text = DGV1.Rows[index].Cells["P_NAME_E"].Value.ToString();
            this.txtP_NAME_E_C.Text = DGV1.Rows[index].Cells["P_NAME_E_C"].Value.ToString();
        }
        // Get IP :Local 
        public void getIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER;
            lbUserName.Text = con.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = con.getDateNow();
        }
        #endregion
        #region Tool 1-> 12
        // F2 Sửa
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btnDuyet.Text = "" + txtThem + "";
            btnAction.Visible = true;
            btnClose.Visible = true;

            btndau.Enabled = false;
            btntruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            DGV1.Enabled = false;

            SetNullTextBox();

        }
        public void SetNullTextBox()
        {
            this.txtK_NO.Text = "";
            this.txtWS_DATE.Text = "";
            this.txtNR.Text = "";
            this.txtOR_NO.Text = "";
            this.txtC_NO.Text = "";

            this.txtC_NAME_C.Text = "";
            this.txtBRAND.Text = "";
            this.txtP_NO.Text = "";
            this.txtP_NAME_C.Text = "";
            this.txtPATT_C.Text = "";

            this.txtCOLOR_C.Text = "";
            this.txtMODEL_C.Text = "";
            this.txtTHICK.Text = "";
            this.txtQTY.Text = "";
            this.txtPRICE.Text = "";

            this.txtWS_DATE_C.Text = "";
            this.txtP_NO_C.Text = "";
            this.txtP_NAME_C_C.Text = "";
            this.txtTHICK_C.Text = "";
            this.txtQTY_C.Text = "";

            this.txtPRICE_C.Text = "";
            this.txtDEV_PROD.Text = "";
            this.txtCHANG_INFO.Text = "";
            this.txtOR_NO_C.Text = "";
            this.txtB_NO_C.Text = "";

            this.txt_BRAND_C.Text = "";
            this.txtT_NAME_C.Text = "";
            this.txtCOLOR_C_C.Text = "";
            this.txtCOLOR_E_C.Text = "";

            this.txtC_NO_C.Text = "";
            this.txtC_NAME_C_C.Text = "";
            this.txtC_NAME_E_C.Text = "";

            this.txtPATT_C_C.Text = "";
            this.txtPATT_E_C.Text = "";

            txtP_NAME_E.Text = "";
            txtP_NAME_E_C.Text = "";

          
        }
        // F3 Xoa
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btnDuyet.Text = "" + txtXoa + "";
            btnAction.Visible = true;
            btnClose.Visible = true;

            btndau.Enabled = false;
            btntruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            DGV1.Enabled = false;
        }
        //F4 Sua 
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f4ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
            btnDuyet.Text = "" + txtSua + "";
            btnAction.Visible = true;
            btnClose.Visible = true;

            btndau.Enabled = false;
            btntruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            ReadOnlyTextBox(true);

            DGV1.Enabled = false;

        }
        // F5 Tim Kiem
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2IF5 fr2if5 = new frm2IF5();
            fr2if5.ShowDialog();
            LoadData();
            bindingsource.Position = frm2IF5.getinfo.index;
            BindingData(frm2IF5.getinfo.index);
            con.DGV(DGV1);
            Color_Data();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAction.PerformClick();
        }
        public static string G_WS_DATE;
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_WS_DATE = txtWS_DATE.Text;
            frm2IF7 fr1 = new frm2IF7();
            fr1.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            loadfirst();
            LoadData();
            BindingData(-1);
            ReadOnlyTextBox(false);
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtThem = "";
        string txtXoa = "";
        string txtSua = "";
        string txtText = "";
        string txtText1 = "";
        string txtText3 = "";
        string txtText4 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtThongBao = "Thông Báo";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtText = "Vui lòng kiểm tra lại Số đơn hàng & STT";
                txtText1 = "Vui lòng nhập ngày thay đổi";
                txtText3 = "Vui lòng nhập ngày thay đổi";
                txtText4 = "Chứng từ vận chuyển đã được tạo";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtText = "Vui lòng kiểm tra lại Số đơn hàng & STT";
                txtText1 = "Vui lòng nhập ngày thay đổi";
                txtText3 = "Vui lòng nhập ngày thay đổi";
                txtText4 = "Chứng từ vận chuyển đã được tạo!!";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtSua = "EDIT";
                txtText = "Please double check Order number & No";
                txtText1 = "Please enter change date";
                txtText3 = "Please enter change date";
                txtText4 = "The shipping document has been created, please notify the change!!";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtSua = "使固定";
                txtText = "請仔細檢查訂單號和否";
                txtText1 = "請輸入更改日期";
                txtText3 = "請輸入更改日期";
                txtText4 = "出貨單據已建立請通知異動!!";
            }
        }
        #endregion
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingData(-1);
        }
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            DGV1.Rows[0].Selected = true;
            // bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            DGV1.DataSource = bindingsource;
            bindingsource.MoveFirst();

            BindingData(-1);

            btndau.Enabled = false;
            btntruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btntruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = DGV1.CurrentRow.Index;
                if (DGV1.Rows.Count > IndexNow)
                {
                    DGV1.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                DGV1.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            BindingData(-1);

            btndau.Enabled = true;
            btntruoc.Enabled = true;
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

                bindingsource.DataSource = datatable;
                DGV1.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }

            BindingData(-1);

            btndau.Enabled = true;
            btntruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

        }
        private void btketthuc_Click(object sender, EventArgs e)
        {
            DGV1.ClearSelection();
            int so = DGV1.Rows.Count - 1;
            //MessageBox.Show(so.ToString());
            DGV1.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            DGV1.DataSource = bindingsource;
            bindingsource.MoveLast();
            BindingData(-1);

            btndau.Enabled = true;
            btntruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnAction.PerformClick();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            
            try
            {
                check();
                checkNofication();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    string sql = "SELECT WS_NO FROM CARB WHERE K_NO='" + txtK_NO.Text + "' AND ORD_DATE ='" + WS_DATE1 + "' AND OR_NR ='" + txtNR.Text + "' AND OR_NO ='" + txtOR_NO.Text + "'";
                    DataTable dt = con.readdata(sql);

                    if (dt.Rows.Count > 0)
                    {
                        string CheckWS_NO = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CheckWS_NO = CheckWS_NO + dt.Rows[i]["WS_NO"].ToString() + ",";
                        }
                        MessageBox.Show("" + txtText4 + "," + CheckWS_NO);
                    }
                    else
                    {
                        if (txtOR_NO.Text == "" || txtNR.Text == "")
                        {
                           
                            MessageBox.Show("" + txtText + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (WS_DATE2 == "" || txtWS_DATE.Text == "")
                            {
                                MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                ADD_DATA();
                                UPDATE_ORDB();
                                WS_DATE2 = "";
                                SetNullTextBox();
                                DGV1.Enabled = false;
                            }

                        }
                    }
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    DELETE_DATA();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    UP_DATA();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void getNR1()
        {
            string sql = "SELECT MAX(NR1) as NR1 FROM ORDBC WHERE C_NO = '"+txtC_NO.Text+ "' AND WS_DATE = '"+ WS_DATE1 + "' AND NR = '"+txtNR.Text+"'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    int Result;
                    if (dataRow["NR1"].ToString() != "")
                    {
                        Result = int.Parse(dataRow["NR1"].ToString());
                        Result++;
                        stt = Result.ToString("D" + 3);
                    }
                    else
                    {
                        stt = "001";
                    }
                }
            }
            else
            {
                stt = "001";
            }
        }
        public void ADD_DATA()
        {
            checkNofication();
            getNR1();
            string sql1 = "SELECT COLOR_E,MODEL_E,WS_RNO FROM ORDB WHERE K_NO='" + txtK_NO.Text + "' AND WS_DATE ='" + WS_DATE1 + "' AND NR ='" + txtNR.Text + "' AND C_NO ='" + txtC_NO.Text + "'";
            DataTable s = con.readdata(sql1);
            string COLOR_E = "";
            string MODEL_E = "";
            string WS_RNO = "";
            if (s.Rows.Count > 0)
            {
                COLOR_E = s.Rows[0][0].ToString();
                MODEL_E = s.Rows[0][1].ToString();
                WS_RNO = s.Rows[0][2].ToString();
            }
            string SQL2 = "INSERT INTO ORDBC(WS_DATE, NR, NR1, C_NO, OR_NO, K_NO, C_NAME_C, C_NAME_E, BRAND," +
            "P_NO, P_NAME_C, P_NAME_E, PATT_C, PATT_E, COLOR_C, COLOR_E, THICK, QTY, PRICE, MODEL_C, MODEL_E, WS_DATE_C," +
            "P_NO_C, P_NAME_C_C, P_NAME_E_C, THICK_C, QTY_C, PRICE_C, DEV_PROD, CHANG_INFO, COLOR_C_C, COLOR_E_C, B_NO_C," +
            "BRAND_c, T_NAME_C, OR_NO_c, USR_NAME, WS_ORNO, C_NO_C, C_NAME_C_C, C_NAME_E_C, PATT_E_C, PATT_C_C)" +
            "VALUES(N'" + WS_DATE1 + "', N'" + txtNR.Text + "', N'" + stt + "', N'" + txtC_NO.Text + "', N'" + txtOR_NO.Text +
            "', N'" + txtK_NO.Text + "', N'" + txtC_NAME_C.Text + "', N'" + txtC_NAME_C.Text + "', N'" + txtBRAND.Text + "', " +
            "N'" + txtP_NO.Text + "', N'" + txtP_NAME_C.Text + "', N'" + txtP_NAME_E.Text + "', N'" + txtPATT_C.Text + "', N'" + txtPATT_C.Text +
            "', N'" + txtCOLOR_C.Text + "', N'" + COLOR_E + "', N'" + txtTHICK.Text + "', " + float.Parse(txtQTY.Text) + ", " + float.Parse(txtPRICE.Text) +
            ", N'" + txtMODEL_C.Text + "', N'" + MODEL_E + "', N'" + WS_DATE2 + "', N'" + txtP_NO_C.Text + "', N'" + txtP_NAME_C_C.Text + "', N'"+ txtP_NAME_E_C.Text+"', N'" + txtTHICK_C.Text +
            "', " + float.Parse(txtQTY_C.Text) + ", " + float.Parse(txtPRICE_C.Text) + ", " +
            " N'" + txtDEV_PROD.Text + "', N'" + txtCHANG_INFO.Text + "', N'" + txtCOLOR_C_C.Text + "', N'" + txtCOLOR_E_C.Text + "', N'" + txtB_NO_C.Text +
            "', N'" + txt_BRAND_C.Text + "', N'" + txtT_NAME_C.Text + "', N'" + txtOR_NO_C.Text + "', N'" + lbUserName.Text + "', N'" + WS_RNO + "', N'" + txtC_NO_C.Text +
            "', N'" + txtC_NAME_C_C.Text + "', N'" + txtC_NAME_E_C.Text + "', N'" + txtPATT_E_C.Text + "', N'" + txtPATT_C_C.Text + "')";

            bool cheks = con.exedata(SQL2);
        }

        private void ReadOnlyTextBox(bool trues)
        {
            txtK_NO.ReadOnly = trues;
            txtWS_DATE.ReadOnly = trues;
            txtNR.ReadOnly = trues;
            txtOR_NO.ReadOnly = trues;
            txtBRAND.ReadOnly = trues;
            txtC_NAME_C.ReadOnly = trues;
            txtC_NO.ReadOnly = trues;
            txtP_NO.ReadOnly = trues;
            txtP_NAME_C.ReadOnly = trues;
            txtPATT_C.ReadOnly = trues;
            txtMODEL_C.ReadOnly = trues;
            txtCOLOR_C.ReadOnly = trues;
            txtTHICK.ReadOnly = trues;
            txtQTY.ReadOnly = trues;
            txtPRICE.ReadOnly = trues;
        }

        public void UP_DATA()
        {
            checkNofication();
            string sql = "SELECT WS_NO FROM CARB WHERE K_NO ='" + txtK_NO.Text+"' AND ORD_DATE ='"+WS_DATE1+"' AND OR_NR ='"+txtNR.Text+"' AND C_NO ='"+txtC_NO.Text+"'";
            DataTable dt = con.readdata(sql);
            if(dt.Rows.Count > 0)
            {
                string CheckWS_NO ="";
                for (int i =0;i< dt.Rows.Count;i++)
                {
                    CheckWS_NO = CheckWS_NO + dt.Rows[i]["WS_NO"].ToString() + ",";
                }
                MessageBox.Show(""+txtText4+ "," + CheckWS_NO);
            }
            else
            {
                string SQL4 = "Update ORDBC SET WS_DATE_C = '" +
                    WS_DATE2 + "', P_NO_C = '" + txtP_NO_C.Text + "', P_NAME_C_C = N'" + txtP_NAME_C_C.Text + "',P_NAME_E_C = N'"+ P_NAME_E_C + "', THICK_C = '" +
                    txtTHICK_C.Text + "', QTY_C = '" + double.Parse(txtQTY_C.Text) + "', PRICE_C = '" + double.Parse(txtPRICE_C.Text) +
                    "', DEV_PROD = '" + txtDEV_PROD.Text + "', CHANG_INFO = N'" + txtCHANG_INFO.Text + "', OR_NO_C = '" + txtOR_NO_C.Text +
                    "', B_NO_C = '" + txtB_NO_C.Text + "', BRAND_C = N'" + txt_BRAND_C.Text + "', T_NAME_C = N'" + txtT_NAME_C.Text +
                    "', COLOR_C_C = N'" + txtCOLOR_C_C.Text + "', COLOR_E_C = N'" + txtCOLOR_E_C.Text + "', C_NO_C = '" + txtC_NO_C.Text +
                    "', C_NAME_C_C = '" + txtC_NAME_C_C.Text + "', C_NAME_E_C = '" + txtC_NAME_E_C.Text + "', PATT_C_C = '" + txtPATT_C.Text +
                    "', PATT_E_C = '" + txtPATT_E_C.Text + "',USR_NAME = N'"+lbUserName.Text+ "' where K_NO = '" + txtK_NO.Text + "' AND WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' AND NR = '" + txtNR.Text + "' AND C_NO = '" + txtC_NO.Text + "' AND NR1 = '"+DGV1.CurrentRow.Cells["NR1"].Value.ToString()+"'";
                bool add4 = con.exedata(SQL4);
                if (add4 == true)
                {
                    UPDATE_ORDB();
                    ReadOnlyTextBox(false);
                    loadfirst();
                }
            }

        }
        public void UPDATE_ORDB()
        {
            checkNofication();
            if (txtWS_DATE_C.Text == "" || con.Check_MaskedText(txtWS_DATE_C) == false)
            {
                MessageBox.Show("" + txtText3 + "");
            }
            else
            {
                UPDATE();
                //string SQL4 = "";
                ////if (!string.IsNullOrEmpty(txtWS_DATE.Text))
                //if(txtWS_DATE_C.MaskCompleted)
                //{
                //    //SQL4 = "Update ORDB SET WS_DATE = '" + WS_DATE1 + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '"+txtC_NO.Text+"'";
                //    SQL4 = "Update ORDB SET WS_DATE = '" + txtWS_DATE_C.Text.Replace("/","") + "' from ORDB where ORDB.WS_DATE = '" +txtWS_DATE.Text.Replace("/", "")+ "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '"+txtC_NO.Text+"'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtP_NO_C.Text))
                //{
                //    SQL4 = "Update ORDB SET P_NO = N'" + txtP_NO_C.Text + "', P_NAME_E = N'" + txtP_NAME_E_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtP_NAME_C_C.Text))
                //{
                //    SQL4 = "Update ORDB SET P_NAME_C= N'" + txtP_NAME_C_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtTHICK_C.Text))
                //{
                //    SQL4 = "Update ORDB SET THICK = N'" + txtTHICK_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtQTY_C.Text))
                //{
                //    SQL4 = "Update ORDB SET QTY = ROUND('" + float.Parse(txtQTY_C.Text) + "',2),TOTAL = ROUND(" + float.Parse(txtQTY_C.Text) + " * PRICE,2) from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtPRICE_C.Text))
                //{
                //    SQL4 = "Update ORDB SET PRICE = ROUND('" + float.Parse(txtPRICE_C.Text) + "',2),TOTAL = ROUND(" + float.Parse(txtPRICE_C.Text) + " * QTY,2) from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtB_NO_C.Text))
                //{
                //    SQL4 = "Update ORDB SET B_NO = N'" + txtB_NO_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txt_BRAND_C.Text))
                //{
                //    SQL4 = "Update ORDB SET BRAND = N'" + txt_BRAND_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtT_NAME_C.Text))
                //{
                //    SQL4 = "Update ORDB SET T_NAME = N'" + txtT_NAME_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtCOLOR_C_C.Text))
                //{
                //    SQL4 = "Update ORDB SET COLOR_C = N'" + txtCOLOR_C_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtCOLOR_E_C.Text))
                //{
                //    SQL4 = "Update ORDB SET COLOR_E = N'" + txtCOLOR_E_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtC_NO_C.Text))
                //{
                //    SQL4 = "Update ORDB SET C_NO = N'" + txtC_NO_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);

                //    if (!string.IsNullOrEmpty(txtC_NAME_C_C.Text))
                //    {
                //        SQL4 = "Update ORDB SET C_NAME_C = N'" + txtC_NAME_C_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO_C.Text + "'";
                //        con.exedata(SQL4);
                //    }
                //    if (!string.IsNullOrEmpty(txtC_NAME_E_C.Text))
                //    {
                //        SQL4 = "Update ORDB SET C_NAME_E = N'" + txtC_NAME_E_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO_C.Text + "'";
                //        con.exedata(SQL4);
                //    }
                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(txtC_NAME_C_C.Text))
                //    {
                //        SQL4 = "Update ORDB SET C_NAME_C = N'" + txtC_NAME_C_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //        con.exedata(SQL4);
                //    }
                //    if (!string.IsNullOrEmpty(txtC_NAME_E_C.Text))
                //    {
                //        SQL4 = "Update ORDB SET C_NAME_E = N'" + txtC_NAME_E_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //        con.exedata(SQL4);
                //    }
                //}

                //if (!string.IsNullOrEmpty(txtPATT_C_C.Text))
                //{
                //    SQL4 = "Update ORDB SET PATT_C = N'" + txtPATT_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtPATT_E_C.Text))
                //{
                //    SQL4 = "Update ORDB SET PATT_E = N'" + txtPATT_E_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
                //if (!string.IsNullOrEmpty(txtOR_NO_C.Text))
                //{
                //    SQL4 = "Update ORDB SET OR_NO = N'" + txtOR_NO_C.Text + "' from ORDB where ORDB.WS_DATE = '" + con.formatstr1(txtWS_DATE.Text) + "' and ORDB.K_NO = '" + txtK_NO.Text + "' and ORDB.NR = '" + txtNR.Text + "' and C_NO = '" + txtC_NO.Text + "'";
                //    con.exedata(SQL4);
                //}
            }
        }
        public void DELETE_DATA()
        {
            checkNofication();
            string SQL3 = "DELETE FROM ORDBC WHERE WS_DATE='" + con.formatstr1(txtWS_DATE.Text) + "' AND NR='" + txtNR.Text + "' AND NR1='" + DGV1.Rows[DGV1.CurrentRow.Index].Cells["NR1"].Value.ToString() + "' AND C_NO='" + txtC_NO.Text + "' AND OR_NO='" + txtOR_NO.Text + "' AND WS_DATE_C ='" + con.formatstr1(txtWS_DATE_C.Text) + "'";
            bool add3 = con.exedata(SQL3);
            if (add3 == true)
            {
                loadfirst();
                LoadData();
                BindingData(-1);
            }
        }

        #region KeyDown
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }
        private void txtK_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtPATT_E_C, txtWS_DATE, sender, e);
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtK_NO, txtNR, sender, e);
        }

        private void txtNR_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE, txtOR_NO, sender, e);
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
            tab(txtC_NO, txtBRAND, sender, e);
        }

        private void txtBRAND_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME_C, txtP_NO, sender, e);
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtBRAND, txtP_NAME_C, sender, e);
        }

        private void txtP_NAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NO, txtPATT_C, sender, e);
        }

        private void txtPATT_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME_C, txtCOLOR_C, sender, e);
        }

        private void txtCOLOR_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPATT_C, txtMODEL_C, sender, e);
        }

        private void txtMODEL_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCOLOR_C, txtTHICK, sender, e);
        }

        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMODEL_C, txtQTY, sender, e);
        }

        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTHICK, txtPRICE, sender, e);
        }

        private void txtPRICE_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtQTY, txtWS_DATE_C, sender, e);
        }

        private void txtWS_DATE_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPRICE, txtP_NO_C, sender, e);
        }

        private void txtP_NO_C_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE_C, txtP_NAME_C_C, sender, e);
        }

        private void txtP_NAME_C_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NO_C, txtTHICK_C, sender, e);
        }

        private void txtTHICK_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME_C_C, txtQTY_C, sender, e);
        }

        private void txtQTY_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTHICK_C, txtPRICE_C, sender, e);
        }

        private void txtPRICE_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtQTY_C, txtDEV_PROD, sender, e);
        }

        private void txtDEV_PROD_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPRICE_C, txtCHANG_INFO, sender, e);
        }

        private void txtCHANG_INFO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtDEV_PROD, txtOR_NO_C, sender, e);
        }

        private void txtOR_NO_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCHANG_INFO, txtB_NO_C, sender, e);
        }

        private void txtB_NO_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtOR_NO_C, txt_BRAND_C, sender, e);
        }

        private void txt_BRAND_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtB_NO_C, txtT_NAME_C, sender, e);
        }

        private void txtT_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txt_BRAND_C, txtCOLOR_C_C, sender, e);
        }

        private void txtCOLOR_C_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtT_NAME_C, txtCOLOR_E_C, sender, e);
        }

        private void txtCOLOR_E_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCOLOR_C_C, txtC_NO_C, sender, e);
        }

        private void txtC_NO_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCOLOR_E_C, txtC_NAME_C_C, sender, e);
        }

        private void txtC_NAME_C_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NO_C, txtC_NAME_E_C, sender, e);
        }

        private void txtC_NAME_E_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME_C_C, txtPATT_C_C, sender, e);
        }

        private void txtPATT_C_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME_E_C, txtPATT_E_C, sender, e);
        }

        private void txtPATT_E_C_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPATT_C_C, txtK_NO, sender, e);
        }

        #endregion

        #region Mouse Click
        private void txtWS_DATE_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE_C.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void txtP_NO_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchMaterial2 fm = new FormSearchMaterial2();
                fm.ShowDialog();
                txtP_NO_C.Text = FormSearchMaterial2.ID.ID_P_NO;
                txtP_NAME_C_C.Text = FormSearchMaterial2.ID.P_NAME;
                txtP_NAME_E_C.Text = FormSearchMaterial2.ID.P_NAME1;
            }
        }

        private void txtTHICK_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchThick2 thick2 = new FormSearchThick2();
                thick2.ShowDialog();
                txtTHICK_C.Text = FormSearchThick2.ID.ID_THICK;

            }
        }

        private void txtB_NO_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                Form1KF5 band = new Form1KF5();
                band.ShowDialog();
                txtB_NO_C.Text = Form1KF5.DL.t1;
                txt_BRAND_C.Text = Form1KF5.DL.t2;
                txtT_NAME_C.Text = Form1KF5.DL.t3;
            }
        }

        private void txtC_NO_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch cust = new frm2CustSearch();
                cust.ShowDialog();
                txtC_NO_C.Text = frm2CustSearch.ID.ID_CUST;
                txtC_NAME_C_C.Text = frm2CustSearch.ID.NAME_C;
                txtC_NAME_E_C.Text = frm2CustSearch.ID.NAME_E;
            }
        }
        private void txtK_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtNR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtOR_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtC_NAME_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtBRAND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtP_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtPATT_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtCOLOR_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtMODEL_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }

        private void txtTHICK_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }
        private void txtP_NAME_C_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }
        public void Add_Info()
        {
            //SetNullTextBox();
            frm2IF1 fr1 = new frm2IF1();
            fr1.ShowDialog();

            string DL = frm2IF1.Get_Info.C_NO;
            string DL1 = frm2IF1.Get_Info.NR;
            string DL2 = frm2IF1.Get_Info.K_NO;
            string DL3 = frm2IF1.Get_Info.WS_DATE;
            if (DL != string.Empty)
            {
                string SQL1 = "select K_NO, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, BRAND, P_NO, P_NAME_C,P_NAME_E, PATT_C,COLOR_E, MODEL_C,THICK,QTY,PRICE from ORDB where C_NO = '" + DL + "' and NR ='" + DL1 + "' AND K_NO = '"+DL2+"' AND WS_DATE = '"+DL3+"'";
                DataTable dt = con.readdata(SQL1);
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtK_NO.Text = dr["K_NO"].ToString();
                    this.txtWS_DATE.Text = con.formatstr1(dr["WS_DATE"].ToString());
                    this.txtNR.Text = dr["NR"].ToString();
                    this.txtOR_NO.Text = dr["OR_NO"].ToString();
                    this.txtC_NO.Text = dr["C_NO"].ToString();

                    this.txtC_NAME_C.Text = dr["C_NAME_C"].ToString();
                    this.txtBRAND.Text = dr["BRAND"].ToString();
                    this.txtP_NO.Text = dr["P_NO"].ToString();
                    this.txtP_NAME_C.Text = dr["P_NAME_C"].ToString();
                    this.txtPATT_C.Text = dr["PATT_C"].ToString();
                   
                    this.txtCOLOR_C.Text = dr["COLOR_E"].ToString();
                    this.txtMODEL_C.Text = dr["MODEL_C"].ToString();

                    this.txtTHICK.Text = dr["THICK"].ToString();
                    this.txtQTY.Text = string.Format("{0:0.00}", float.Parse(dr["QTY"].ToString()));
                    this.txtPRICE.Text = string.Format("{0:0.00}", float.Parse(dr["PRICE"].ToString()));

                    this.txtQTY_C.Text = string.Format("{0:0.00}", float.Parse(dr["QTY"].ToString()));
                    this.txtPRICE_C.Text = string.Format("{0:0.00}", float.Parse(dr["PRICE"].ToString()));

                    //new
                    txtP_NAME_E.Text = dr["P_NAME_E"].ToString();
                    txtP_NAME_E_C.Text = "";
                }
            }
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
                Add_Info();
        }
        #endregion

        private void txtC_NO_C_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT C_NAME2,C_NAME2_E FROM dbo.CUST WHERE C_NO ='"+ txtC_NO_C.Text + "'";
            DataTable dt = con.readdata(sql);
            if(dt.Rows.Count > 0)
            {
                txtC_NAME_C_C.Text = dt.Rows[0]["C_NAME2"].ToString();
                txtC_NAME_E_C.Text = dt.Rows[0]["C_NAME2_E"].ToString();
            }
            else
            {
                txtC_NAME_C_C.Text = "";
                txtC_NAME_E_C.Text = "";
            }
        }

        private void txtB_NO_C_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT BRAND,TRADE FROM dbo.BRAND WHERE B_NO ='" + txtB_NO_C.Text + "'";
            DataTable dt = con.readdata(sql);
            if (dt.Rows.Count > 0)
            {
                txt_BRAND_C.Text = dt.Rows[0]["BRAND"].ToString();
                txtT_NAME_C.Text = dt.Rows[0]["TRADE"].ToString();
            }
            else
            {
                txt_BRAND_C.Text = "";
                txtT_NAME_C.Text = "";
            }
        }

        private void btnTimeNow_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE ORDB SET K_NO =K_NO ";
            if (!string.IsNullOrEmpty(txtP_NO_C.Text)) SQL = SQL + ", P_NO ='" + txtP_NO_C.Text + "' ";
            if (!string.IsNullOrEmpty(txtP_NAME_C_C.Text)) SQL = SQL + ", P_NAME_C ='" + txtP_NAME_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtP_NAME_E_C.Text)) SQL = SQL + ", P_NAME_E ='" + txtP_NAME_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtTHICK_C.Text)) SQL = SQL + ", THICK ='" + txtTHICK_C.Text + "'";
            if (!string.IsNullOrEmpty(txtQTY_C.Text) && !string.IsNullOrEmpty(txtPRICE_C.Text)) SQL = SQL + ", QTY ='" + ConvertFloat(txtQTY_C.Text) + "', PRICE ='" + ConvertFloat(txtPRICE_C.Text)+ "', TOTAL = ROUND("+ ConvertFloat(txtQTY_C.Text)+" * "+ConvertFloat(txtPRICE_C.Text)+",2)";
            if (!string.IsNullOrEmpty(txtOR_NO_C.Text)) SQL = SQL + ", OR_NO ='" + txtOR_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txtB_NO_C.Text)) SQL = SQL + ", B_NO ='" + txtB_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txt_BRAND_C.Text)) SQL = SQL + ", BRAND ='" + txt_BRAND_C.Text + "'";
            if (!string.IsNullOrEmpty(txtT_NAME_C.Text)) SQL = SQL + ", T_NAME ='" + txtT_NAME_C.Text + "'";
            if (!string.IsNullOrEmpty(txtCOLOR_C_C.Text)) SQL = SQL + ", COLOR_C ='" + txtCOLOR_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtCOLOR_E_C.Text)) SQL = SQL + ", COLOR_E ='" + txtCOLOR_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NO_C.Text)) SQL = SQL + ", C_NO ='" + txtC_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NAME_C_C.Text)) SQL = SQL + ", C_NAME_C ='" + txtC_NAME_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NAME_E_C.Text)) SQL = SQL + ", C_NAME_E ='" + txtC_NAME_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtPATT_C_C.Text)) SQL = SQL + ", PATT_C ='" + txtPATT_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtPATT_E_C.Text)) SQL = SQL + ", PATT_E ='" + txtPATT_E_C.Text + "'";

            SQL = SQL + " WHERE WS_DATE ='"+txtWS_DATE.Text.Replace("/","")+"' AND K_NO ='"+txtK_NO.Text+"' AND NR ='"+txtNR.Text+"'AND C_NO='"+txtC_NO.Text+"' ";
        }
        private void UPDATE()
        {
            string SQL = "UPDATE ORDB SET K_NO =K_NO ";
            if (!string.IsNullOrEmpty(txtP_NO_C.Text)) SQL = SQL + ", P_NO ='" + txtP_NO_C.Text + "' ";
            if (!string.IsNullOrEmpty(txtP_NAME_C_C.Text)) SQL = SQL + ", P_NAME_C ='" + txtP_NAME_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtP_NAME_E_C.Text)) SQL = SQL + ", P_NAME_E ='" + txtP_NAME_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtTHICK_C.Text)) SQL = SQL + ", THICK ='" + txtTHICK_C.Text + "'";
            if (!string.IsNullOrEmpty(txtQTY_C.Text) && !string.IsNullOrEmpty(txtPRICE_C.Text)) SQL = SQL + ", QTY ='" + ConvertFloat(txtQTY_C.Text) + "', PRICE ='" + ConvertFloat(txtPRICE_C.Text) + "', TOTAL = ROUND(" + ConvertFloat(txtQTY_C.Text) + " * " + ConvertFloat(txtPRICE_C.Text) + ",2)";
            if (!string.IsNullOrEmpty(txtOR_NO_C.Text)) SQL = SQL + ", OR_NO ='" + txtOR_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txtB_NO_C.Text)) SQL = SQL + ", B_NO ='" + txtB_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txt_BRAND_C.Text)) SQL = SQL + ", BRAND ='" + txt_BRAND_C.Text + "'";
            if (!string.IsNullOrEmpty(txtT_NAME_C.Text)) SQL = SQL + ", T_NAME ='" + txtT_NAME_C.Text + "'";
            if (!string.IsNullOrEmpty(txtCOLOR_C_C.Text)) SQL = SQL + ", COLOR_C ='" + txtCOLOR_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtCOLOR_E_C.Text)) SQL = SQL + ", COLOR_E ='" + txtCOLOR_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NO_C.Text)) SQL = SQL + ", C_NO ='" + txtC_NO_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NAME_C_C.Text)) SQL = SQL + ", C_NAME_C ='" + txtC_NAME_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtC_NAME_E_C.Text)) SQL = SQL + ", C_NAME_E ='" + txtC_NAME_E_C.Text + "'";
            if (!string.IsNullOrEmpty(txtPATT_C_C.Text)) SQL = SQL + ", PATT_C ='" + txtPATT_C_C.Text + "'";
            if (!string.IsNullOrEmpty(txtPATT_E_C.Text)) SQL = SQL + ", PATT_E ='" + txtPATT_E_C.Text + "'";

            SQL = SQL + " WHERE WS_DATE ='" + txtWS_DATE.Text.Replace("/", "") + "' AND K_NO ='" + txtK_NO.Text + "' AND NR ='" + txtNR.Text + "'AND C_NO='" + txtC_NO.Text + "' ";
            con.exedata(SQL);
        }
        private float ConvertFloat(string x)
        {
            float Result = 0;
            float.TryParse(x, out Result);
            return Result;
        }
    }
}
