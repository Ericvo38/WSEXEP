using LibraryCalender;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3I : Form
    {
        DataProvider con = new DataProvider();
        BindingSource Bdsource = new BindingSource();
        DataTable table_DGV;

        public static string Where = string.Empty;
        int rowIndex = -1, Function = 0;      
        string TextP_NO, TextC_ANAME, TextC_NO;
        
        public frm3I()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm3I_Load(object sender, EventArgs e)
        {
            Loadinfo();
            LoadFirst();
        }
        #region Change language             
        double TBQTY = 0.0;
        double TAMT = 0.0;        
        #endregion

        #region Load info Form, LoadFirst
        private void LoadFirst()
        {
            con.CheckLoad(menuStrip1);
            Function = 0;
            EnableFunction();

            btnOk.Hide();
            btnDong.Hide();
            btnDuyet.ButtonViews(0);

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;

            DGV1.ReadOnly = true;

            LoadData();
        }
        private void EnableFunction()
        {
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;
        }
        private void DisableFunction()
        {
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;
        }
        private void Loadinfo()
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
        #endregion

        #region ToolStripMenuItem F1 --> F12 
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 1;
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 2;
            DisableFunction();

            btnOk.Show();
            btnDong.Show();
            btnDuyet.ButtonViews(1);

            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");

            txtWS_NO.Clear();
            txtMK_NOA.Clear();
            txtW_KIND.Clear();
            txtC_NAME.Clear();
            txtP_NAME.Clear();
            txtSOURCE.Clear();
            txtTHICK.Clear();
            txtK_NO.Clear();
            txtWKG.Clear();
            txtPSF.Clear();
            txtMK_NOA1.Clear();
            txtCLRCARD.Clear();
            txtCARNO.Clear();

            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;

            DGV1.ReadOnly = false;

            string sql = "SELECT NR,P_NO,P_NAME, QTY, BQTY, UNIT, BUNIT, PRICE, AMOUNT, M_TRAN, BMEMO, W_CHK FROM COSTB WHERE WS_NO=N''";
            table_DGV = con.readdata(sql);
            DGV1.DataSource = table_DGV;
            DGV1.DataGridViewFormat();
            InsertItem();
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 3;
            DisableFunction();

            btnOk.Show();
            btnDong.Show();
            btnDuyet.ButtonViews(2);

            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 4;
            DisableFunction();
            DGV1.ReadOnly = false;

            btnOk.Show();
            btnDong.Show();
            btnDuyet.ButtonViews(3);
            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            DGV1.ReadOnly = false;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 5;
            frm3IF5 fm = new frm3IF5();
            fm.ShowDialog();
            if (!string.IsNullOrEmpty(frm3IF5.GetWS_NO))
            {
                LoadData();
                Bdsource.Position = Bdsource.Find("WS_NO", frm3IF5.GetWS_NO);
                ShowRecord();
            }

        }     
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 6;
            DisableFunction();

            btnOk.Show();
            btnDong.Show();
            btnDuyet.ButtonViews(6);

            txtWS_DATE.Text = DateTime.Now.ToString("yyyyMMdd");
            txtWS_NO.Text = "";
            txtMK_NOA.Text = "";
            txtW_KIND.Text = "";
            txtC_NAME.Text = "";
            txtP_NAME.Text = "";
            txtSOURCE.Text = "";
            txtTHICK.Text = "";
            txtK_NO.Text = "";
            txtWKG.Text = "";
            txtPSF.Text = "";
            txtMK_NOA1.Text = "";
            txtCLRCARD.Text = "";
            txtCARNO.Text = "";

            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;

            DGV1.ReadOnly = false;
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 7;
            frm3IF7 fr = new frm3IF7();
            fr.txtWS_DATE1.Text = txtWS_NO.Text;
            fr.tb1.Text = txtWS_NO.Text;
            fr.tb4.Text = txtWS_NO.Text;
            fr.ShowDialog();

        }     
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 9;
            try
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    string sql = "SELECT P_NO,P_NAME,W_CHECK FROM J2BKPVC.dbo.PROD1C WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "'";
                    if (string.IsNullOrEmpty(con.ExecuteScalar(sql)))
                    {
                        if (con.GetLangdefaul() == 0) throw new Exception(item.Cells["P_NO"].Value.ToString()+ " Sản phẩm không chính xác, vui lòng nhập lại!");
                        else if (con.GetLangdefaul() == 1) throw new Exception(item.Cells["P_NO"].Value.ToString()+ " The product is incorrect, please re-enter!");
                        else if (con.GetLangdefaul() == 2) throw new Exception(item.Cells["P_NO"].Value.ToString() + " 產品不正確,請重新輸入!");
                        else throw new Exception(item.Cells["P_NO"].Value.ToString() + " Sản phẩm không chính xác, vui lòng nhập lại!");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, con.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 12;
            this.Close();
        }

        #endregion
        
        public class Share3I
        {
            public static string W_KIND;
            public static string SOURCE;
        }
        #region Method Form Defaul 
        private void LoadData()
        {
            string SQL1 = "SELECT top 1000 WS_DATE, WS_NO, MK_NO, W_KIND, C_NAME, P_NAME, SOURCE, THICK, K_NO, WKG, PSF ,MK_NOA, CLRCARD, CARNO,USR_NAME FROM COSTH WHERE 1=1 " + Where + " ORDER BY WS_DATE DESC";
            DataTable dt = con.readdata(SQL1);
            Bdsource.DataSource = dt;
            if(Bdsource.Position >-1)
                ShowRecord();
            LoadDGV(txtWS_NO.Text);
        }
        private void LoadDGV(string WS_NO)
        {
            string SQL2 = "SELECT NR,P_NO,P_NAME, QTY, BQTY, UNIT, BUNIT, PRICE, AMOUNT, M_TRAN, BMEMO, W_CHK FROM COSTB WHERE WS_NO = '" + WS_NO + "' ";
            table_DGV = con.readdata(SQL2);
            DGV1.DataSource = table_DGV;
            DataGridViewFormat(DGV1);
        }
        private void ShowRecord()
        {
            txtWS_DATE.Text = con.formatstr2(currenRow["WS_DATE"].ToString());
            txtWS_NO.Text = currenRow["WS_NO"].ToString();
            txtMK_NOA.Text = currenRow["MK_NO"].ToString();
            txtW_KIND.Text = currenRow["W_KIND"].ToString();
            txtC_NAME.Text = currenRow["C_NAME"].ToString();
            txtP_NAME.Text = currenRow["P_NAME"].ToString();
            txtSOURCE.Text = currenRow["SOURCE"].ToString();
            txtTHICK.Text = currenRow["THICK"].ToString();
            txtK_NO.Text = currenRow["K_NO"].ToString();
            txtWKG.Text = String.Format("{0:#,###}", currenRow["WKG"]);
            txtPSF.Text = currenRow["PSF"].ToString();
            txtMK_NOA1.Text = currenRow["MK_NOA"].ToString();
            txtCLRCARD.Text = currenRow["CLRCARD"].ToString();
            txtCARNO.Text = currenRow["CARNO"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
        }
        private DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[Bdsource].Position;
                if (position > -1)
                {
                    return ((DataRowView)Bdsource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void SetPosition(string s)
        {
            Bdsource.Position = Bdsource.Find("WS_NO", s);
        }
        private float ConvertFloat(string s)
        {
            float x = 0;
            float.TryParse(s, out x);
            return x;
        }
        public void DataGridViewFormat(DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersWidth = 15;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV.BackgroundColor = Color.White;
            DGV.ForeColor = Color.MidnightBlue;
            DGV.BorderStyle = BorderStyle.FixedSingle;
            DGV.DefaultCellStyle.Format = "#,##0.000";
        }
        #endregion

        #region Button MoveFirst, MovePrevious, MoveNext, MoveLast
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            if (Bdsource.Position == -1) return;
            Bdsource.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            if (Bdsource.Position == -1) return;
            Bdsource.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
            if (Bdsource.Position == 0) btnMoveFirst.PerformClick();
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (Bdsource.Position == -1) return;
            Bdsource.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
            if (Bdsource.Position == (Bdsource.Count - 1)) btnMoveLast.PerformClick();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            if (Bdsource.Position == -1) return;
            Bdsource.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        #endregion

        #region Button Action Form
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Function == 2|| Function == 6) AddData(); //Add, Copy               
                else if (Function == 3) DeleteData(); //Delete Data               
                else if (Function == 4) ModifyData(); //Modify Data
                LoadFirst();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            LoadFirst();
        }
        #endregion

        #region Method Form

        private Boolean Delete_DGV(string WS_NO)
        {
            bool Result = false;
            try
            {
                if (string.IsNullOrEmpty(WS_NO)) return false;
                string SQL = "DELETE FROM dbo.COSTB WHERE WS_NO ='" + WS_NO + "' ";
                Result = con.exedata(SQL);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            return Result;
        }
        public Boolean Add_DGV()
        {
            Boolean Result = false;
            try
            {
                if (DGV1.Rows.Count <= 0) return false;
                for (int i = 0; i < DGV1.RowCount; i++)
                {
                    string key = "";
                    if (!string.IsNullOrEmpty(DGV1.Rows[i].Cells["BUNIT"].Value.ToString()))
                    {
                        key = DGV1.Rows[i].Cells["BUNIT"].Value.ToString() + "'";
                    }
                    string st2 = "INSERT INTO dbo.COSTB(WS_NO, NR, P_NO, P_NAME, QTY, BQTY, UNIT, BUNIT, PRICE, AMOUNT, M_TRAN, BMEMO, W_CHK)" +
                    " SELECT N'" + txtWS_NO.Text + "',N'" + DGV1.Rows[i].Cells["NR"].Value.ToString() + "',N'" + DGV1.Rows[i].Cells["P_NO"].Value.ToString() + "',N'" + DGV1.Rows[i].Cells["P_NAME"].Value.ToString() + "','" + ConvertFloat(DGV1.Rows[i].Cells["QTY"].Value.ToString()) + "'," +
                    "'" + ConvertFloat(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) + "','" + DGV1.Rows[i].Cells["UNIT"].Value.ToString() + "','" + key + "','" + ConvertFloat(DGV1.Rows[i].Cells["PRICE"].Value.ToString()) + "','" + ConvertFloat(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()) + "'," +
                    "N'" + DGV1.Rows[i].Cells["M_TRAN"].Value.ToString() + "',N'" + DGV1.Rows[i].Cells["BMEMO"].Value.ToString() + "',N'" + DGV1.Rows[i].Cells["W_CHK"].Value.ToString() + "'";
                    Result = con.exedata(st2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        
        private string CreateWS_NO()
        {
            string Result = txtWS_DATE.Text.Replace("/", "");
            try
            {
                if (txtWS_DATE.MaskCompleted)
                {
                    string SQL3 = "SELECT MAX(WS_NO) AS WS_NO FROM COSTH WHERE WS_DATE = '" + txtWS_DATE.Text.Replace("/", "") + "'";
                    string S1 = con.ExecuteScalar(SQL3);
                    if (!string.IsNullOrEmpty(S1))
                    {
                        int NR = 0;
                        S1 = S1.Substring(S1.Length - 3, 3);
                        int.TryParse(S1, out NR);
                        NR++;
                        Result = txtWS_DATE.Text.Replace("/", "") + NR.ToString("D" + 3);
                    }
                    else
                    {
                        Result = Result + "001";
                    }
                }
                else
                {
                    txtWS_DATE.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Result;
        }
        private void AddData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    txtWS_NO.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Số đơn sản xuất không được để trống!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Production order number cannot be blank!");
                    else if(con.GetLangdefaul() == 2) throw new Exception("生產訂單號不能為空！");
                    else throw new Exception("Số đơn sản xuất không được để trống!");
              
                }
                else if (ConvertFloat(txtPSF.Text)<=0)
                {
                    txtPSF.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Số Feet không được bằng 0, vui lòng nhập lại !");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Feet cannot be 0, please re-enter !");
                    else if (con.GetLangdefaul() == 2) throw new Exception("英尺不能為0，請重新輸入！");
                    else throw new Exception("Số Feet không được bằng 0, vui lòng nhập lại !");
                }
                else if (string.IsNullOrEmpty(txtMK_NOA.Text))
                {
                    txtMK_NOA.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Số lệnh sản xuất chưa được nhập, vui lòng nhập lại!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Work order number is not entered, please re-enter!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("工令編號未輸入,請重新輸入!");
                    else throw new Exception("Số lệnh sản xuất chưa được nhập, vui lòng nhập lại!");
                }
                else if (string.IsNullOrEmpty(txtWKG.Text))
                {
                    txtWKG.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Vui nhập trọng lượng!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Please enter the weight!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("請輸入重量！");
                    else throw new Exception("Vui nhập trọng lượng!");
                }
                else if (string.IsNullOrEmpty(txtSOURCE.Text))
                {
                    txtSOURCE.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Vui lòng thêm nguồn skin Chưa nhập, vui lòng nhập lại!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Please add skin source Not entered, please re-enter!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("請加皮源 未輸入,請重新輸入!");
                    else throw new Exception("Vui lòng thêm nguồn skin Chưa nhập, vui lòng nhập lại!");
                }
                else if (string.IsNullOrEmpty(txtCARNO.Text))
                {
                    txtCARNO.Focus();
                    if (con.GetLangdefaul() == 0) throw new Exception("Vui lòng thêm số sêri Chưa nhập, vui lòng nhập lại!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Please add serial number Not entered, please re-enter!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("請添加序列號 未輸入，請重新輸入！");
                    else throw new Exception("Vui lòng thêm số sêri Chưa nhập, vui lòng nhập lại!");
                }
                else
                {
                    string st1 = "insert into dbo.COSTH(WS_DATE, WS_NO, MK_NO, W_KIND, C_NAME, P_NAME, SOURCE, THICK, K_NO, WKG, PSF, MK_NOA, CLRCARD, CARNO,USR_NAME,C_NO,C_ANAME,P_NO,TBQTY,TAMT)" +
                                " SELECT N'" + txtWS_DATE.Text.Replace("/", "") + "','" + txtWS_NO.Text + "',N'" + txtMK_NOA.Text + "',N'" + txtW_KIND.Text.Replace("'", "''") + "',N'" + txtC_NAME.Text.Replace("'", "''") + "',N'" + txtP_NAME.Text.Replace("'", "''") + "',N'" + txtSOURCE.Text.Replace("'", "''") + "',N'" + txtTHICK.Text + "',N'" + txtK_NO.Text + "'," +
                                "'" + float.Parse(txtWKG.Text) + "','" + float.Parse(txtPSF.Text) + "',N'" + txtMK_NOA1.Text + "',N'" + txtCLRCARD.Text + "',N'" + txtCARNO.Text + "',N'" + lbUserName.Text + "',N'" + TextC_NO + "',N'" + TextC_ANAME + "',N'" + TextP_NO + "','" + TBQTY + "','" + TAMT + "'";
                    if (con.exedata(st1))
                    {
                        Add_DGV();
                        LoadData();
                        SetPosition(txtWS_NO.Text);
                    }
                    else
                    {
                        if (con.GetLangdefaul() == 0) throw new Exception("Lỗi không thể thêm dữ liệu, vui lòng kiểm tra lại!");
                        else if (con.GetLangdefaul() == 1) throw new Exception("Error could not add data, please check again!");
                        else if (con.GetLangdefaul() == 2) throw new Exception("錯誤無法添加數據，請重新檢查!");
                        else throw new Exception("Lỗi không thể thêm dữ liệu, vui lòng kiểm tra lại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, con.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public bool DeleteData()
        {
            bool Result = false;
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    if (con.GetLangdefaul() == 0) throw new Exception("Vui lòng chọn dữ liệu, trước khi xóa!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Please select data, before deleting!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("請先選擇數據，再刪除！");
                    else throw new Exception("Vui lòng chọn dữ liệu, trước khi xóa!");
                }
                else
                {
                    string SQL1 = "DELETE FROM COSTH WHERE WS_NO ='" + txtWS_NO.Text + "'";
                    string SQL2 = "DELETE FROM COSTB WHERE WS_NO ='" + txtWS_NO.Text + "'"; 
                    Result = con.Transaction(SQL1, SQL2);
                    Where = string.Empty;
                    if (Result == false)
                    {
                        if (con.GetLangdefaul() == 0) throw new Exception("Xẩy ra lỗi, không thể xóa dữ liệu!");
                        else if (con.GetLangdefaul() == 1) throw new Exception("An error occurred, data cannot be deleted!");
                        else if (con.GetLangdefaul() == 2) throw new Exception("發生錯誤，無法刪除數據！");
                        else throw new Exception("Xẩy ra lỗi, không thể xóa dữ liệu!");
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Result = false;
            }
            return Result;
        }
        public void ModifyData()
        {
            bool Result = false;
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    if (con.GetLangdefaul() == 0) throw new Exception("Vui lòng chọn dữ liệu trước khi sửa!");
                    else if (con.GetLangdefaul() == 1) throw new Exception("Please select data before editing!");
                    else if (con.GetLangdefaul() == 2) throw new Exception("編輯前請選擇數據！");
                    else throw new Exception("Vui lòng chọn dữ liệu trước khi sửa!");
                }
                else
                {
                    SetPosition(txtWS_NO.Text);
                    string SQL1 = "UPDATE dbo.COSTH SET WS_DATE= '" + txtWS_DATE.Text.Replace("/", "") + "', WS_NO= N'" + txtWS_NO.Text + "', MK_NO= N'" + txtMK_NOA.Text + "', W_KIND= N'" + txtW_KIND.Text + "', C_NAME= N'" + txtC_NAME.Text + "', " +
                                 "P_NAME= N'" + txtC_NAME.Text.Replace("'","''") + "', SOURCE= N'" + txtSOURCE.Text.Replace("'", " '' ") + "', THICK= N'" + txtTHICK.Text + "', K_NO= N'" + txtK_NO.Text + "', WKG= '" + float.Parse(txtWKG.Text) + "', PSF= '" + float.Parse(txtPSF.Text) + "', " +
                                 "MK_NOA= N'" + txtMK_NOA1.Text + "', CLRCARD = N'" + txtCLRCARD.Text + "', CARNO= N'" + txtCARNO.Text + "', USR_NAME=N'"+ lbUserName.Text+ "' where WS_NO= N'" + txtWS_NO.Text + "'";
                    Result = con.exedata(SQL1);
                    if (Result)
                    {
                        Result = Delete_DGV(txtWS_NO.Text);
                        if (Result)
                        {
                            Add_DGV();
                            SetPosition(txtWS_NO.Text);
                        }
                        else
                        {
                            if (con.GetLangdefaul() == 0) throw new Exception("Xẩy ra lỗi, khi sửa dữ liệu!");
                            else if (con.GetLangdefaul() == 1) throw new Exception("An error occurred, while editing data!");
                            else if (con.GetLangdefaul() == 2) throw new Exception("編輯數據時發生錯誤！");
                            else throw new Exception("Xẩy ra lỗi, khi sửa dữ liệu!");
                        }
                            
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Result = false;
            }
        }
        #endregion

        #region Event DataGridView
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                if (DGV1.Rows.Count == 0) return;
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (this.DGV1.CurrentCell.OwningColumn.Name == "NR")
                {
                    DeleteItem();
                    return;
                }

                if (this.DGV1.CurrentCell.OwningColumn.Name == "P_NO")
                {
                    Insert_DGV();
                }
                if (this.DGV1.CurrentCell.OwningColumn.Name == "UNIT")
                {
                    FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                    frmSearchMemo1.ShowDialog();
                    string MM = FormSearchLeather2.ID.M_NAME;
                    this.DGV1["UNIT", DGV1.CurrentRow.Index].Value = MM;
                }
                if (Cur == 10)
                {
                    FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                    frmSearchMemo1.ShowDialog();
                    string MM = FormSearchLeather2.ID.M_NAME;
                    this.DGV1[10, DGV1.CurrentRow.Index].Value = MM;
                }
            }
        }
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(this.DGV1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Function ==2 || Function == 4 || Function == 6)
            {
                if (this.DGV1.CurrentCell.OwningColumn.Name == "QTY")
                {
                    float WKG, QTY, BQTY, PRICE;
                    float.TryParse(txtWKG.Text, out WKG);
                    float.TryParse(this.DGV1.CurrentRow.Cells["QTY"].Value.ToString(), out QTY);
                    float.TryParse(this.DGV1.CurrentRow.Cells["BQTY"].Value.ToString(), out BQTY);
                    float.TryParse(this.DGV1.CurrentRow.Cells["PRICE"].Value.ToString(), out PRICE);

                    this.DGV1.CurrentRow.Cells["BQTY"].Value = (QTY * WKG) / 100;
                    this.DGV1.CurrentRow.Cells["AMOUNT"].Value = BQTY * PRICE;

                    //double converttxtWKG = (!string.IsNullOrEmpty(txtWKG.Text.ToString()) ? double.Parse(txtWKG.Text.ToString()) : 0);
                    //this.DGV1["BQTY", DGV1.CurrentRow.Index].Value = double.Parse(this.DGV1[DGV1.CurrentCell.ColumnIndex, DGV1.CurrentRow.Index].Value.ToString()) * converttxtWKG / 100;
                    //this.DGV1["AMOUNT", DGV1.CurrentRow.Index].Value = double.Parse(DGV1["BQTY", DGV1.CurrentRow.Index].Value.ToString()) * double.Parse(this.DGV1["PRICE", DGV1.CurrentRow.Index].Value.ToString());

                }
            }
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
                rowIndex = e.RowIndex;

        }
        #endregion

        #region Event Form
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
        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE, txtWS_NO, sender, e);
        }
        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE, txtMK_NOA, sender, e);
        }

        private void txtMK_NOA_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWS_NO, txtW_KIND, sender, e);
        }
        private void txtW_KIND_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMK_NOA, txtC_NAME, sender, e);
        }
        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtW_KIND, txtP_NAME, sender, e);
        }
        private void txtP_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME, txtSOURCE, sender, e);
        }
        private void txtSOURCE_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtP_NAME, txtTHICK, sender, e);
        }
        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtSOURCE, txtK_NO, sender, e);
        }
        private void txtK_NO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTHICK, txtWKG, sender, e);
        }
        private void txtWKG_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtK_NO, txtPSF, sender, e);
        }
        private void txtPSF_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWKG, txtMK_NOA1, sender, e);
        }
        private void txtMK_NOA1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPSF, txtCLRCARD, sender, e);
        }
        private void txtCLRCARD_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMK_NOA1, txtCARNO, sender, e);
        }
        private void txtCARNO_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCLRCARD, txtCARNO, sender, e);
        }
        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            if (FromCalender.Flags)
            {
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }

        }
        private void txtCARNO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function==2 || Function == 4 || Function == 6)
                {
                frmSearchBWARB frmSearch = new frmSearchBWARB();
                frmSearch.ShowDialog();
                txtSOURCE.Text = frmSearchBWARB.DTfrmSearchBWARB.DL;
                txtCARNO.Text = frmSearchBWARB.DTfrmSearchBWARB.S_NO;
            }
        }
        private void txtMK_NOA_MouseClick(object sender, MouseEventArgs e)
        {
            if(Function == 2 || Function == 6)
                txtWS_NO.Text = CreateWS_NO();
        }
        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            if (Function == 2 || Function == 6)
                txtWS_NO.Text = CreateWS_NO();
        }
       
        private void txtW_KIND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function==2 || Function ==4 || Function ==6)
            {
                if (txtW_KIND.Text == "")
                    txtW_KIND.Text = "1";

                else if (txtW_KIND.Text == "1")
                    txtW_KIND.Text = "2";

                else if (txtW_KIND.Text == "2")
                    txtW_KIND.Text = "1";
            }
        }
        private void txtMK_NOA_DoubleClick(object sender, EventArgs e)
        {

        }
        private void txtSOURCE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                frmSearchMemo1.tb1.Text = "C";
                frmSearchMemo1.ShowDialog();
                txtSOURCE.Text = FormSearchLeather2.ID.M_NAME;
            }
        }

        private void txtPSF_Leave(object sender, EventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6) txtWKG.isNumber();
        }
        private void txtWKG_Leave(object sender, EventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6) txtWKG.isNumber();
        }

        private void txtWKG_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWKG.Text))
            {
                if (DGV1.Rows.Count > 0)
                {
                    float WKG= 0, QTY= 0, BQTY= 0, PRICE= 0;
                    if (!string.IsNullOrEmpty(txtWKG.Text)) float.TryParse(txtWKG.Text, out WKG);
                    foreach (DataGridViewRow item in DGV1.Rows)
                    {
                        if(!string.IsNullOrEmpty(item.Cells["QTY"].Value.ToString())) float.TryParse(item.Cells["QTY"].Value.ToString(), out QTY);
                        if (!string.IsNullOrEmpty(item.Cells["BQTY"].Value.ToString())) float.TryParse(item.Cells["BQTY"].Value.ToString(), out BQTY);
                        if (!string.IsNullOrEmpty(item.Cells["PRICE"].Value.ToString())) float.TryParse(item.Cells["PRICE"].Value.ToString(), out PRICE);

                        item.Cells["BQTY"].Value = (QTY * WKG) / 100;
                        item.Cells["AMOUNT"].Value = BQTY * PRICE;
                        //if (!string.IsNullOrEmpty(item.Cells["QTY"].Value.ToString()) || !string.IsNullOrEmpty(item.Cells["BQTY"].Value.ToString()))
                        //    item.Cells["BQTY"].Value = ConvertFloat(item.Cells["QTY"].Value.ToString()) * ConvertFloat(txtWKG.Text) / 100;

                        //if (!string.IsNullOrEmpty(item.Cells["AMOUNT"].Value.ToString()) || !string.IsNullOrEmpty(item.Cells["BQTY"].Value.ToString()) || !string.IsNullOrEmpty(item.Cells["PRICE"].Value.ToString()))
                        //    item.Cells["AMOUNT"].Value = ConvertFloat(item.Cells["BQTY"].Value.ToString()) * ConvertFloat(item.Cells["PRICE"].Value.ToString());
                    }
                }
            }
        }
        private void txtMK_NOA_TextChanged(object sender, EventArgs e)
        {
            if (Function == 2 || Function == 6 || Function == 4) AddItem(txtMK_NOA.Text);
        }
        #endregion

        #region Item Menu
        public static string Share_P_NO;
        private void DeleteItem()
        {
            if(table_DGV.Rows.Count > 0)
            {
                DataRow row = table_DGV.Rows[rowIndex];
                row.Delete();
            }
            table_DGV.AcceptChanges();
            foreach (DataRow dr in table_DGV.Rows)
            {
                string i = dr["NR"].ToString();
                int x; int.TryParse(i, out x);
                if (x > rowIndex)
                {
                    x--;
                    string NR = x.ToString("D" + 3);
                    dr["NR"] = NR;
                }
            }
            table_DGV.AcceptChanges();
            DGV1.DataSource = table_DGV;
        }
        private void InsertItem()
        {
            //if (rowIndex == -1) return;
            if (rowIndex > -1)
            {
                foreach (DataRow dr in table_DGV.Rows)
                {
                    int.TryParse(dr["NR"].ToString(), out int NR);
                    if (NR > rowIndex + 1)
                    {
                        dr["NR"] = (NR + 1).ToString("D" + 3);
                        table_DGV.AcceptChanges();
                    }
                }
            }
                
            string NRNEW = (rowIndex + 2).ToString("D" + 3);
            table_DGV.Rows.Add(NRNEW, "", "", 0, 0,"","",0,0,"", "","");
            table_DGV.AcceptChanges();
            DGV1.DataSource = table_DGV;
            this.DGV1.Sort(this.DGV1.Columns["NR"], ListSortDirection.Ascending);
        }
        private void Insert_DGV()
        {
            if (rowIndex == -1) return;
            frm3IF2 fm = new frm3IF2();
            fm.ShowDialog();
            string sql = "SELECT P_NO, P_NAME, P_NAME1, PRICE, P_NAME2, P_NAME3, C_NO, M_TRAN FROM J2BKPVC.dbo.PROD1C WHERE P_NO ='" + Share_P_NO + "' ";
            DataTable dt = con.readdata(sql);
            //DataRow row = table_DGV.Rows[rowIndex];
            foreach (DataRow dr in dt.Rows)
            {
                DGV1.Rows[rowIndex].Cells["NR"].Value = (rowIndex + 1).ToString("D" + 3);
                DGV1.Rows[rowIndex].Cells["P_NO"].Value = dr["P_NO"];
                DGV1.Rows[rowIndex].Cells["P_NAME"].Value = dr["P_NAME1"];
                DGV1.Rows[rowIndex].Cells["QTY"].Value = 0;
                DGV1.Rows[rowIndex].Cells["BQTY"].Value = 0;
                DGV1.Rows[rowIndex].Cells["UNIT"].Value = "";
                DGV1.Rows[rowIndex].Cells["BUNIT"].Value = "";
                DGV1.Rows[rowIndex].Cells["PRICE"].Value = ConvertFloat(dr["PRICE"].ToString());
                DGV1.Rows[rowIndex].Cells["AMOUNT"].Value = 0;
                DGV1.Rows[rowIndex].Cells["M_TRAN"].Value = dr["M_TRAN"];
                DGV1.Rows[rowIndex].Cells["BMEMO"].Value = "";
                DGV1.Rows[rowIndex].Cells["W_CHK"].Value = "";

            }
            DGV1.DataGridViewFormat();
            this.DGV1.Sort(this.DGV1.Columns["NR"], ListSortDirection.Ascending);
            DGV1.DataSource = table_DGV;
        }      
        #endregion
        
        private void AddItem(string MK_NOA)
        {
            try
            {
                if (string.IsNullOrEmpty(MK_NOA)) return;

                string SQL = "SELECT DISTINCT MK_NOA, A.OR_NO, A.OR_K_NO, A.C_NAME, ISNULL(A.CLRCARD,'') + ' '+ ISNULL(A.P_NAME,'') AS P_NAME, A.THICK, B.OR_NO, A.BQTY, B.CLRCARD, ISNULL(A.SOURCE,'') + '      ' + ISNULL(S_PN3,'') AS SOURCE, A.WKG, A.CARNO  FROM PRDMKA A RIGHT JOIN ORDB B ON A.OR_NO = B.OR_NO WHERE MK_NOA ='" + MK_NOA + "' ";
                DataTable dt = con.readdata(SQL);
                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtW_KIND.Text = dr["OR_K_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME"].ToString();
                        txtP_NAME.Text = dr["P_NAME"].ToString();
                        txtTHICK.Text = dr["THICK"].ToString();
                        txtPSF.Text = String.Format("{0:#,###}", dr["BQTY"]);
                        txtCLRCARD.Text = dr["CLRCARD"].ToString();

                        txtSOURCE.Text = dr["SOURCE"].ToString();
                        txtWKG.Text = String.Format("{0:#,###}", dr["WKG"]);
                        txtMK_NOA1.Text = dr["MK_NOA"].ToString();
                        txtCARNO.Text = dr["CARNO"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Menu ContentStrip
        private void 新增明細UToolStripMenuItem_Click(object sender, EventArgs e)
        {//add
            DGV1.AllowUserToAddRows = true;
            DGV1.CurrentCell = DGV1.Rows[DGV1.Rows.Count - 1].Cells[1];
            DGV1.Rows[DGV1.Rows.Count - 1].Cells[0].Value = (DGV1.Rows.Count).ToString("D" + 3);

        }

        #region Insert Items
        private void 插入明細VToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 1; i++)
            {
                InsertItem();
            }
        } //1 Rows

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                InsertItem();
            }
        } //2 Rows

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                InsertItem();
            }
        } // 3 Rows

        private void rowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                InsertItem();
            }
        } // 4 Rows

        private void rowsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                InsertItem();
            }
        } //5 Rows
        #endregion

        private void 删除明細WToolStripMenuItem_Click(object sender, EventArgs e)
        {//W
            DeleteItem();
        }

        private void DGV1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                InsertItem();
            }
        }

        private void 产品挑选XToolStripMenuItem_Click(object sender, EventArgs e)
        {// Choice Item
            Insert_DGV();
        }
        private void 储存YToolStripMenuItem_Click(object sender, EventArgs e)
        {//Save Item
            btnOk.PerformClick();
        }
        private void 放弃ZToolStripMenuItem_Click(object sender, EventArgs e)
        {//Close Item
            btnDong.PerformClick();
        }
        #endregion



    }
}
