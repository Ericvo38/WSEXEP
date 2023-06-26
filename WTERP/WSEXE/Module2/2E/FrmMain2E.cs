using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2E
{
    public partial class FrmMain2E : Form
    {
        DataProvider connect = new DataProvider();
        BindingSource bdSource;
        DataTable TableGRV;
        int Functions = 0;
        public static string Share_WS_NO = string.Empty;
        public FrmMain2E()
        {
            InitializeComponent();
        }
        private void FrmMain2E_Load(object sender, EventArgs e)
        {
            Loadinfo();
            LoadFirst();
        }

        #region Load Base 
        private void LoadFirst()
        {
            Functions = 0;
            EnableFunction();
            LoadData();
        }
        private void Loadinfo()
        {
            lbUserName.Text = frmLogin.ID_NAME;
            lblNamePC.Text = System.Environment.MachineName;
            btndateNow.Text = connect.getDateNow();
            //btnDayofWeek.Text = connect.ButtonDayofWeek();
            lbIPAddrees.Text = connect.GetIPAddrees();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = connect.getTimeNow();
        }
        private void EnableFunction()
        {
            
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            txtWS_DATE.ReadOnly = true;
            txtWS_KIND.ReadOnly = true;
            txtWS_NO.ReadOnly = true;
            txtC_NO.ReadOnly = true;
            txtC_NAME.ReadOnly = true;

            txtTOT.ReadOnly = true;
            txtTOTAL.ReadOnly = true;
            txtMEMO1.ReadOnly = true;
            txtMEMO2.ReadOnly = true;
            txtMEMO3.ReadOnly = true;
            txtMEMO4.ReadOnly = true;
            txtMEMO5.ReadOnly = true;
            txtMEMO6.ReadOnly = true;
            txtMEMO7.ReadOnly = true;
            txtMEMO8.ReadOnly = true;

            txtCAL_YM.ReadOnly = true;

            btnOK.Visible = false;
            btnCancel.Visible = false;

            DGV1.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void DisableFunction()
        {
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            txtWS_DATE.ReadOnly = false;
            txtWS_KIND.ReadOnly = false;
            txtWS_NO.ReadOnly = false;
            txtC_NO.ReadOnly = false;
            txtC_NAME.ReadOnly = false;

            txtTOT.ReadOnly = false;
            txtTOTAL.ReadOnly = false;
            txtMEMO1.ReadOnly = false;
            txtMEMO2.ReadOnly = false;
            txtMEMO3.ReadOnly = false;
            txtMEMO4.ReadOnly = false;
            txtMEMO5.ReadOnly = false;
            txtMEMO6.ReadOnly = false;
            txtMEMO7.ReadOnly = false;
            txtMEMO8.ReadOnly = false;

            txtCAL_YM.ReadOnly = false;

            btnOK.Visible = true;
            btnCancel.Visible = true;

            DGV1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }
        private void CheckMove()
        {
            if(bdSource.Count < 0)
            {
                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
            }
            else if(bdSource.Position == 0)
            {
                btnMoveFirst.Enabled = false;
                btnMovePrevious.Enabled = false;
                btnMoveNext.Enabled = true;
                btnMoveLast.Enabled = true;
            }
            else if (bdSource.Position == bdSource.Count-1)
            {
                btnMoveFirst.Enabled = true;
                btnMovePrevious.Enabled = true;
                btnMoveNext.Enabled = false;
                btnMoveLast.Enabled = false;
            }
            else
            {
                btnMoveFirst.Enabled = true;
                btnMovePrevious.Enabled = true;
                btnMoveNext.Enabled = true;
                btnMoveLast.Enabled = true;
            }
        }
        private DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[bdSource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bdSource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void SetPosition(string s)
        {
            bdSource.Position = bdSource.Find("WS_NO", s);
        }
        #endregion

        #region Button Acction Form
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryCalender.FromCalender fm = new LibraryCalender.FromCalender();
            fm.ShowDialog();
            if (LibraryCalender.FromCalender.Flags)
            {
                txtWS_DATE.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
            }
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 2;

            txtWS_DATE.Text = DateTime.Now.ToString("yyyyMMdd");
            txtWS_KIND.Clear();
            txtWS_NO.Clear();
            txtC_NO.Clear();
            txtC_NAME.Clear();

            txtTOT.Clear();
            txtTOTAL.Clear();
            txtMEMO1.Clear();
            txtMEMO2.Clear();
            txtMEMO3.Clear();
            txtMEMO4.Clear();
            txtMEMO5.Clear();
            txtMEMO6.Clear();
            txtMEMO7.Clear();
            txtMEMO8.Clear();
            txtCAL_YM.Clear();
            txtWS_KIND.Focus();

            DisableFunction();
            LoadDGV();
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 3;
            DisableFunction();
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 4;
            DisableFunction();
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2EF5 fr = new frm2EF5();
            fr.ShowDialog();
            if (!string.IsNullOrEmpty(frm2EF5.Share_WS_NO))
            {
                LoadData();
                SetPosition(frm2EF5.Share_WS_NO);
                ShowRecord();
            }
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtC_NO.Text))
                {
                    if (frmLogin.Lang_ID == 0) throw new Exception("Vui lòng nhập mã khách hàng!");
                    else if(frmLogin.Lang_ID == 1) throw new Exception("Please enter customer code!");
                    else if(frmLogin.Lang_ID == 2) throw new Exception("请输入客户代码！");
                    else throw new Exception("Vui lòng nhập mã khách hàng!");
                    
                }
                else
                {
                    Frm2EF6New fm = new Frm2EF6New();
                    fm.txtC_NO.Text = txtC_NO.Text;
                    fm.ShowDialog();
                    if (Frm2EF6New.Products.Count > 0) ADD_DGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2EF7 fr = new frm2EF7();
            fr.txtWS_NO.Text = txtWS_NO.Text;
            fr.txtWS_NO1.Text = txtWS_NO.Text;
            fr.ShowDialog();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            if (bdSource.Position == -1) return;
            bdSource.MoveFirst();
            ShowRecord();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            if (bdSource.Position == -1) return;
            bdSource.MovePrevious();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
            if (bdSource.Position == 0) btnMoveFirst.PerformClick();
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (bdSource.Position == -1) return;
            bdSource.MoveNext();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
            if (bdSource.Position == (bdSource.Count - 1)) btnMoveLast.PerformClick();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            if (bdSource.Position == -1) return;
            bdSource.MoveLast();
            ShowRecord();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(Functions == 2)
            {
                AddData();
            }
            else if(Functions == 3)
            {
                DeleteData();
            }
            else if (Functions == 4)
            {
                ModifyData();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            LoadFirst();
        }
        #endregion
        private void LoadData()
        {
            try
            {
                string SQL = "SELECT * FROM GIBH ORDER BY WS_DATE DESC,WS_NO DESC";
                bdSource = new BindingSource();
                bdSource.DataSource = connect.readdata(SQL);
                if (bdSource.Count > -1) ShowRecord();
                LoadDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowRecord()
        {
            txtWS_DATE.Text = currenRow["WS_DATE"].ToString();
            txtWS_KIND.Text = currenRow["WS_KIND"].ToString();
            txtWS_NO.Text = currenRow["WS_NO"].ToString();
            txtC_NO.Text = currenRow["C_NO"].ToString();
            txtC_NAME.Text = currenRow["C_NAME"].ToString();

            txtTOT.Text = currenRow["TOT"].ToString();
            txtTOTAL.Text = currenRow["TOTAL"].ToString();
            txtMEMO1.Text = currenRow["MEMO1"].ToString();
            txtMEMO2.Text = currenRow["MEMO2"].ToString();
            txtMEMO3.Text = currenRow["MEMO3"].ToString();
            txtMEMO4.Text = currenRow["MEMO4"].ToString();
            txtMEMO5.Text = currenRow["MEMO5"].ToString();
            txtMEMO6.Text = currenRow["MEMO6"].ToString();
            txtMEMO7.Text = currenRow["MEMO7"].ToString();
            txtMEMO8.Text = currenRow["MEMO8"].ToString();
            txtCAL_YM.Text = currenRow["CAL_YM"].ToString();

            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();

            CheckMove();
        }
        private void LoadDGV()
        {
            try
            {
                string SQL = "SELECT * FROM GIBB WHERE WS_NO ='"+txtWS_NO.Text+"' ";
                TableGRV = connect.readdata(SQL);
                DGV1.DataSource = TableGRV;
                DGVNew();
                DataGridViewFormat(DGV1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DataGridViewFormat(DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            DGV.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            DGV.RowHeadersWidth = 15;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV.BackgroundColor = Color.White;
            DGV.ForeColor = Color.MidnightBlue;
            DGV.BorderStyle = BorderStyle.FixedSingle;
            DGV.ColumnHeadersHeight = 52;
            DGV.RowTemplate.Height = 30;
        }
        private void DGVNew()
        {
            DGV1.Columns["NR"].DisplayIndex = 0;
            DGV1.Columns["P_NO"].DisplayIndex = 1;
            DGV1.Columns["P_NAME"].DisplayIndex = 2;
            DGV1.Columns["COLOR"].DisplayIndex = 3;
            DGV1.Columns["P_NAME3"].DisplayIndex = 4;
            DGV1.Columns["BQTY"].DisplayIndex = 5;
            DGV1.Columns["PRICE"].DisplayIndex = 6;
            DGV1.Columns["AMOUNT"].DisplayIndex = 7;
            DGV1.Columns["OR_NO"].DisplayIndex = 8;
            DGV1.Columns["CAL_YM"].DisplayIndex = 9;
            DGV1.Columns["MEMO"].DisplayIndex = 10;
            DGV1.Columns["COLOR_C"].DisplayIndex = 11;
            DGV1.Columns["COLOR_E"].DisplayIndex = 12;
            DGV1.Columns["QTY"].DisplayIndex = 13;

            DGV1.Columns["BQTY"].DefaultCellStyle.Format = "#,##0.00";
            DGV1.Columns["PRICE"].DefaultCellStyle.Format = "#,##0.000";
            DGV1.Columns["AMOUNT"].DefaultCellStyle.Format = "#,##0.00";
            DGV1.Columns["QTY"].DefaultCellStyle.Format = "#,##0";

            DGV1.Columns["WS_NO"].Visible = false;
            DGV1.Columns["WS_DATE"].Visible = false;
            DGV1.Columns["OR_NR"].Visible = false;
            DGV1.Columns["C_NO"].Visible = false;
            DGV1.Columns["P_NAME1"].Visible = false;
            DGV1.Columns["UNIT"].Visible = false;
            DGV1.Columns["BUNIT"].Visible = false;
            DGV1.Columns["CUNIT"].Visible = false;
            DGV1.Columns["SH_NO"].Visible = false;
            DGV1.Columns["FOB_DATE"].Visible = false;
            DGV1.Columns["WS_KIND"].Visible = false;
            DGV1.Columns["ORD_DATE"].Visible = false;
            DGV1.Columns["P_NAME2"].Visible = false;
            DGV1.Columns["K_NO"].Visible = false;
            DGV1.Columns["TRANS"].Visible = false;
            DGV1.Columns["COST"].Visible = false;
            DGV1.Columns["C_OR_NO"].Visible = false;
            DGV1.Columns["UPDATEKIND"].Visible = false;
            DGV1.Columns["OVER0"].Visible = false;
            DGV1.Columns["WS_ORNO"].Visible = false;
            DGV1.Columns["WS_RECNO"].Visible = false;
            DGV1.Columns["HOVER1"].Visible = false;
        }
        private string CreateWS_NO(string Type)
        {
            string Result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(Type))
                {
                    txtWS_KIND.Focus();

                    if (frmLogin.Lang_ID == 1) throw new Exception("Loại đơn hàng không được để trống!");
                    else if (frmLogin.Lang_ID == 2) throw new Exception("Order type cannot be blank!");
                    else if (frmLogin.Lang_ID == 3) throw new Exception("訂單類型不能為空！");
                    else throw new Exception("Loại đơn hàng không được để trống!");
                }
                else 
                {
                    if (txtWS_KIND.Text.Equals("C") || txtWS_KIND.Text.Equals("T") || txtWS_KIND.Text.Equals("B"))
                    {
                        string Like = string.Empty;
                        if (Type.Equals("T"))
                        {
                            Like = Type + "V" + txtWS_DATE.Text.Replace("/", "").Substring(2, 4);
                        }
                        else if (Type.Equals("C"))
                        {
                            Like = Type + "V" + txtWS_DATE.Text.Replace("/", "").Substring(2, 2);
                        }
                        else if (Type.Equals("B"))
                        {
                            Like = Type + txtWS_DATE.Text.Replace("/", "").Substring(2, 2);
                        }

                        if (!string.IsNullOrEmpty(Like))
                        {
                            string SQL = "SELECT * FROM GIBH WHERE WS_NO LIKE '" + Like + "%' ";
                            DataTable dt = connect.readdata(SQL);
                            int Cur = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                string S = dr["WS_NO"].ToString();
                                S = S.Substring(S.LastIndexOf("-") + 1, ((S.Length - 1) - S.LastIndexOf("-")));
                                int.TryParse(S, out int x);
                                if (x > Cur) Cur = x;
                            }
                            Cur++;
                            Result = Like + "-" + Cur.ToString("0000");
                        }
                    }
                    else
                    {
                        txtWS_KIND.Focus();

                        if (frmLogin.Lang_ID == 1) throw new Exception("Nhập sai, vui lòng nhập lại C Hoặc T Hoặc B!");
                        else if (frmLogin.Lang_ID == 2) throw new Exception("Enter incorrectly, please re-enter C Or T Or B!");
                        else if (frmLogin.Lang_ID == 3) throw new Exception("輸入不正確,請重新輸入CORT OR B!");
                        else throw new Exception("Nhập sai, vui lòng nhập lại C Hoặc T Hoặc B!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Result = string.Empty;
            }
            return Result;
        }
        
        public void ADD_DGV()
        {
            getDataCust();
            int NR = 0;
            foreach (var item in Frm2EF6New.Products)
            {
                string SQL = "SELECT OR_NO, NR, P_NO, P_NAME_C, P_NAME_E AS P_NAME1, THICK AS P_NAME3,  QTY, PRICE, COLOR_E, COLOR_C, K_NO, WS_DATE, WS_RNO   FROM dbo.ORDB WHERE WS_DATE= '"+item.WS_DATE.Replace("/","")+"' AND NR ='" + item.NR+ "' AND C_NO ='"+item.C_NO+"' AND K_NO ='" + item.K_NO+"' ";
                DataTable dt2 = connect.readdata(SQL);
                if (dt2.Rows.Count > 0)
                {
                    NR = TableGRV.Rows.Count + 1;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        TableGRV.Rows.Add(txtWS_NO.Text, NR.ToString("000"), txtWS_DATE.Text, txtC_NO.Text, dr["OR_NO"].ToString(), dr["NR"].ToString(), dr["P_NO"].ToString(), dr["P_NAME_C"].ToString(), dr["P_NAME1"].ToString(),"", dr["P_NAME3"].ToString(), "", "", 1, 0, "", dr["QTY"].ToString(), dr["PRICE"].ToString(), GetAmount(dr["QTY"].ToString(), dr["PRICE"].ToString()),
                            0, "", "", "", dr["OR_NO"].ToString(), dr["COLOR_E"].ToString(), dr["COLOR_C"].ToString(), txtCAL_YM.Text, txtWS_KIND.Text, dr["K_NO"].ToString(), dr["WS_DATE"].ToString(), null, null,null, dr["WS_RNO"].ToString(), "N");
                        TableGRV.AcceptChanges();
                    }
                    txtTOT.Text = string.Format(TableGRV.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString(), "#,##0.00");
                    txtTOTAL.Text = string.Format(TableGRV.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString(), "#,##0.00");
                }
                NR++;
            }
            DGV1.Refresh();
        }
        private double GetAmount(string N1, string N2)
        {
            double.TryParse(N1, out double Num1);
            double.TryParse(N2, out double Num2);
            return Num1 * Num2;
        }
       
        #region Add Data
        private void AddData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    txtWS_NO.Focus();
                    if (frmLogin.Lang_ID == 1) throw new Exception("Mã đơn hàng không được để trống !");
                    else if (frmLogin.Lang_ID == 2) throw new Exception("Order number cannot be blank !");
                    else if (frmLogin.Lang_ID == 3) throw new Exception("订单号不能为空！");
                    else throw new Exception("Mã đơn hàng không được để trống !");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtC_NO.Text))
                    {
                        txtC_NO.Focus();
                        if (frmLogin.Lang_ID == 1) throw new Exception("Mã khách hàng không được để trống !");
                        else if (frmLogin.Lang_ID == 2) throw new Exception("Customer code cannot be blank !");
                        else if (frmLogin.Lang_ID == 3) throw new Exception("客户代码不能为空！");
                        else throw new Exception("Mã khách hàng không được để trống !");
                    }
                    else
                    {
                        string SQL1 = "SELECT C_NO, C_ANAME2, ADR3,DEFA_MONEY FROM CUST WHERE C_NO = '"+ txtC_NO.Text + "'";
                        DataTable dt1 = connect.readdata(SQL1);
                        string D1 = string.Empty, D2 = string.Empty, D3 = string.Empty;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            D1 = dr["C_ANAME2"].ToString();
                            D2 = dr["ADR3"].ToString();
                            D3 = dr["DEFA_MONEY"].ToString();
                            if (D1.Length >= 8)
                                D1 = D1.Substring(0, 7);
                        }
                        for (int i = 0; i < DGV1.RowCount; i++)
                        {
                            if (int.Parse(DGV1.Rows[i].Cells["QTY"].Value.ToString()) <= 0)
                            {
                                if (frmLogin.Lang_ID == 1) throw new Exception("Vui lòng nhập trọng lượng !");
                                else if (frmLogin.Lang_ID == 2) throw new Exception("Please enter weight !");
                                else if (frmLogin.Lang_ID == 3) throw new Exception("请输入重量！");
                                else throw new Exception("Vui lòng nhập trọng lượng !");
                            }
                        }
                        connect.OpentTransaction();
                        Share_WS_NO = txtWS_NO.Text;

                        string st1 = "INSERT INTO dbo.GIBH(WS_DATE, WS_KIND, WS_NO, C_NO, C_NAME, C_ANAME, ADDR," +
                                     " C_NO_O, C_NAME_O, C_ANAME_O, ADDR_O, TAX, DISCOUNT, RCV_MON,  TOT, TOTAL, NRCV_MON," +
                                     " MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO6, MEMO7, MEMO8, COSTTOT, PACK_NO ,CAL_YM, M_TRAN, M_TRAN_R,OR_NO,USR_NAME) " +
                                     "SELECT '" + txtWS_DATE.Text.Replace("/","")+ "', '" + txtWS_KIND.Text + "', '" + txtWS_NO.Text + "', '" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + D1 +
                                     "', N'" + D2 + "', '" + txtC_NO.Text + "', '" + txtC_NAME.Text + "', '" + D1 + "', '" + D2 + "', 0, 0, 0, ROUND('" + txtTOT.Text +
                                     "',2), '" + txtTOTAL.Text + "', '" + txtTOT.Text + "', N'" + txtMEMO1.Text + "', N'" + txtMEMO2.Text + "', N'" + txtMEMO3.Text +
                                     "', N'" + txtMEMO4.Text + "', N'" + txtMEMO5.Text + "', N'" + txtMEMO6.Text + "', N'" + txtMEMO7.Text + "', N'" + txtMEMO8.Text + "', 0, 0, '" +txtCAL_YM.Text.Replace("/","") + "', '" + D3 + "', 31.6,'',N'" + lbUserName.Text + "'";
                        bool checkTransaction = connect.ExecuteTransaction(st1);
                        if (checkTransaction == true)
                        {
                            Insert_DGV();
                        }
                        else
                        {
                            connect.CloseTransaction(false);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadFirst();
            SetPosition(Share_WS_NO);
            ShowRecord();
        }
        public void Insert_DGV()
        {
            bool checktransaction = false;
            try
            {
                if (txtWS_KIND.Text == "T" || txtWS_KIND.Text == "C") // HANG BU, TRA
                {
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        string D1 = DGV1.Rows[i].Cells["WS_DATE"].Value.ToString();
                        string D2 = DGV1.Rows[i].Cells["C_NO"].Value.ToString();
                        string D3 = DGV1.Rows[i].Cells["K_NO"].Value.ToString();
                        //string D4 = DGV1.Rows[i].Cells["OR_NR"].Value.ToString();

                        string st2 = "insert into dbo.GIBB(WS_NO, NR, WS_DATE, C_NO, OR_NO, OR_NR, P_NO, P_NAME, P_NAME1, P_NAME3," +
                                     " QTY, TRANS, BQTY, PRICE, AMOUNT, COST, C_OR_NO, COLOR, COLOR_c," +
                                     " CAL_YM, WS_KIND, K_NO, ORD_DATE, WS_ORNO, HOVER1,MEMO)" +
                                     " SELECT N'" + DGV1.Rows[i].Cells["WS_NO"].Value + "', N'" + DGV1.Rows[i].Cells["NR"].Value + "', '" + DGV1.Rows[i].Cells["WS_DATE"].Value.ToString().Replace("/","") + "', N'" + DGV1.Rows[i].Cells["C_NO"].Value + "', N'" + DGV1.Rows[i].Cells["OR_NO"].Value +
                                     "', '" + DGV1.Rows[i].Cells["OR_NR"].Value + "', '" + DGV1.Rows[i].Cells["P_NO"].Value + "', N'" + DGV1.Rows[i].Cells["P_NAME"].Value + "'," +
                                     " N'" + DGV1.Rows[i].Cells["P_NAME1"].Value + "', '" + DGV1.Rows[i].Cells["P_NAME3"].Value + "',ROUND( '" + DGV1.Rows[i].Cells["QTY"].Value + "',2), 0, ROUND('" + DGV1.Rows[i].Cells["BQTY"].Value +
                                     "',2), ROUND('" + DGV1.Rows[i].Cells["PRICE"].Value + "',2),ROUND('" + DGV1.Rows[i].Cells["AMOUNT"].Value + "',2), 0, '" + DGV1.Rows[i].Cells["OR_NO"].Value +
                                     "', N'" + DGV1.Rows[i].Cells["COLOR"].Value + "', N'" + DGV1.Rows[i].Cells["COLOR_C"].Value + "', '" + DGV1.Rows[i].Cells["CAL_YM"].Value.ToString().Replace("/", "") +
                                     "', '" + DGV1.Rows[i].Cells["WS_KIND"].Value + "', '" + D3 + "','"+DGV1.Rows[i].Cells["ORD_DATE"].Value.ToString().Replace("/", "") + "','"+ DGV1.Rows[i].Cells["WS_ORNO"].Value+ "','N','" + DGV1.Rows[i].Cells["MEMO"].Value + "' ";
                        checktransaction = connect.ExecuteTransaction(st2);
                        if (checktransaction == false)
                        {
                            connect.CloseTransaction(false);
                            return;
                        }
                    }
                }
                else if (txtWS_KIND.Text == "B") // CONG NO
                {
                    for (int i = 0; i < DGV1.RowCount; i++)
                    {
                        string st2 = "insert into dbo.GIBB(WS_NO, NR, WS_DATE, C_NO, P_NO, P_NAME, P_NAME1, UNIT, BUNIT," +
                            " QTY, TRANS, CUNIT, BQTY, PRICE, AMOUNT, COST, SH_NO, CAL_YM, WS_KIND, OVER0, WS_ORNO, HOVER1, OR_NO)" +
                            " SELECT '" + DGV1.Rows[i].Cells["WS_NO"].Value + "', '" + DGV1.Rows[i].Cells["NR"].Value + "', '" + txtWS_DATE.Text.Replace("/", "") + "', '" + DGV1.Rows[i].Cells["C_NO"].Value + "', '" + DGV1.Rows[i].Cells["P_NO"].Value +
                            "', N'" + DGV1.Rows[i].Cells["P_NAME"].Value + "', N'" + DGV1.Rows[i].Cells["P_NAME1"].Value + "', 'SF', 'SF' " +
                            ",ROUND( '" + DGV1.Rows[i].Cells["QTY"].Value + "',2), 1, 2, ROUND('" + DGV1.Rows[i].Cells["BQTY"].Value + "',2), ROUND('" + DGV1.Rows[i].Cells["PRICE"].Value + "',2), ROUND('" + DGV1.Rows[i].Cells["AMOUNT"].Value +
                            "',2), 0, 'A', '" + DGV1.Rows[i].Cells["CAL_YM"].Value.ToString().Replace("/","") + "', '" + DGV1.Rows[i].Cells["WS_KIND"].Value + "','Y', 0, 'N',''";
                        checktransaction = connect.ExecuteTransaction(st2);
                        if (checktransaction == false)
                        {
                            connect.CloseTransaction(false);
                            return;
                        }
                    }
                }
                connect.CloseTransaction(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        #region Delete Data
        private void DeleteData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    return;
                }
                else
                {
                    string SQL1 = "DELETE GIBH WHERE WS_NO='"+txtWS_NO.Text+"' ";
                    string SQL2 = "DELETE GIBB WHERE WS_NO='"+txtWS_NO.Text+"' ";
                    bool Result = connect.Transaction(SQL1, SQL2);
                    if (Result == false)
                    {
                        if (frmLogin.Lang_ID == 1) throw new Exception("Lỗi, Không xóa được dữ liệu");
                        else if (frmLogin.Lang_ID == 2) throw new Exception("Error, Cannot delete data");
                        else if(frmLogin.Lang_ID == 3) throw new Exception("错误，无法删除数据");
                        else throw new Exception("Lỗi, Không xóa được dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadFirst();
        }
        #endregion

        #region Modify Data
        public void ModifyData()
        {
            connect.OpentTransaction();
            Share_WS_NO = txtWS_NO.Text;
            string st1 = "update dbo.GIBH set WS_DATE='" + txtWS_DATE.Text.Replace("/","") + "', WS_KIND='" + txtWS_KIND.Text + "', WS_NO='" + txtWS_NO.Text + "'," +
                " C_NO='" + txtC_NO.Text + "', C_NAME=N'" + txtC_NAME.Text + "', TOT='" + txtTOT.Text + "', TOTAL='" + txtTOTAL.Text + "', MEMO1=N'" + txtMEMO1.Text + "', MEMO2=N'" + txtMEMO2.Text + "'," +
                " MEMO3=N'" + txtMEMO3.Text + "', MEMO4=N'" + txtMEMO4.Text + "', MEMO5=N'" + txtMEMO5.Text + "', MEMO6=N'" + txtMEMO6.Text + "', MEMO7=N'" + txtMEMO7.Text + "', MEMO8=N'" + txtMEMO8.Text + "', " +
                "CAL_YM='" +txtCAL_YM.Text.Replace("/","") + "', USR_NAME = N'" + lbUserName.Text + "' where WS_NO= '" + txtWS_NO.Text + "'";
            
            try
            {
                if (string.IsNullOrEmpty(txtWS_NO.Text))
                {
                    txtWS_NO.Focus();
                    if (frmLogin.Lang_ID == 1) throw new Exception("Mã đơn hàng không được để trống !");
                    else if (frmLogin.Lang_ID == 2) throw new Exception("Order number cannot be blank !");
                    else if (frmLogin.Lang_ID == 3) throw new Exception("订单号不能为空！");
                    else throw new Exception("Mã đơn hàng không được để trống !");
                }
                bool check1 = connect.ExecuteTransaction(st1);
                if (check1 == true)
                {
                    Update_DGV();
                }
                else
                {
                    connect.CloseTransaction(false);
                }
            }
            catch (Exception ex)
            {
                connect.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
            LoadFirst();
            SetPosition(Share_WS_NO);
            ShowRecord();
        }
        public void Update_DGV()
        {
            try
            {
                bool check = connect.ExecuteTransaction("DELETE FROM GIBB WHERE WS_NO = '"+txtWS_NO.Text + "'");
                if (check == true)
                {
                    Insert_DGV();
                }
                else
                {
                    connect.CloseTransaction(false);
                }
            }
            catch (Exception ex)
            {
                connect.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            if (Functions == 0) LoadDGV();
        }
        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Functions == 2 || Functions == 4 || Functions == 6)
            {
                LibraryCalender.FromCalender fm = new LibraryCalender.FromCalender();
                fm.ShowDialog();
                if (LibraryCalender.FromCalender.Flags) txtWS_DATE.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");
            }
        }
        private void txtWS_KIND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Functions == 2 || Functions == 4)
            {
                if (txtWS_KIND.Text.Equals("C")) txtWS_KIND.Text = "T";
                else if(txtWS_KIND.Text.Equals("T")) txtWS_KIND.Text = "B";
                else txtWS_KIND.Text = "C";
                txtWS_NO.Text = CreateWS_NO(txtWS_KIND.Text);
            }
        }
        private void txtWS_NO_MouseClick(object sender, MouseEventArgs e)
        {
            if (Functions == 2 || Functions == 4) txtWS_NO.Text = CreateWS_NO(txtWS_KIND.Text);
        }
        private void txtWS_KIND_TextChanged(object sender, EventArgs e)
        {
            if (Functions == 2 || Functions == 4) txtWS_KIND.Text = txtWS_KIND.Text.ToUpper();

        }

        int rowIndex = -1;
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
           
            if(Functions==2 || Functions == 4 || Functions == 6)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(this.DGV1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);

                    //ContextMenuStrip menu = new ContextMenuStrip();
                    //int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                    //menu.Items.Add("Insert").Name = "Insert";
                    //menu.Items.Add("Edit").Name = "Edit";
                    //menu.Items.Add("Delete").Name = "Del";

                    //menu.Show(DGV1, new Point(e.X, e.Y));
                    //menu.ItemClicked += Menu_ItemClicked;
                }
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            getDataCust();
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    try
                    {
                        Insert_Item();
                        //if (!string.IsNullOrEmpty(txtWS_NO.Text))
                        //{
                        //    frm2E_DGV fr1 = new frm2E_DGV();
                        //    fr1.ShowDialog();

                        //    int NR = 1;
                        //    DataTable dataTable = (DataTable)DGV1.DataSource;
                        //    for (int i = 0; i < frm2E_DGV.DT.LV.Count; i++)
                        //    {
                        //        NR = dataTable.Rows.Count + 1;
                        //        string AA = NR.ToString("D" + 3);

                        //        string BB = frm2E_DGV.DT.LV[i];
                        //        string BC = frm2E_DGV.DT.LV1[i];
                        //        string BD = frm2E_DGV.DT.LV2[i];

                        //        dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.00", "1.00", "", txtCAL_YM.Text, "", "", "", BD, "0");
                        //        dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.00", "1.00", "", txtCAL_YM.Text, "", "", "", BD, "0");
                        //    }
                        //    DGV1.DataSource = dataTable;
                        //    txtTOT.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                        //    txtTOTAL.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                        //}
                        //else
                        //{
                        //    txtWS_KIND.Focus();
                        //    if (frmLogin.Lang_ID == 1) throw new Exception("Loại đơn hàng không được để trống!");
                        //    else if (frmLogin.Lang_ID == 2) throw new Exception("Order type cannot be blank!");
                        //    else if (frmLogin.Lang_ID == 3) throw new Exception("訂單類型不能為空！");
                        //    else throw new Exception("Loại đơn hàng không được để trống!");
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Delete":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV1.Rows.Count - 1; i++)
                            {
                                DGV1[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }
        
        private void getDataCust()
        {
            string ST = "Exec getRCV_DATE_2E '" + txtWS_DATE.Text.Replace("/","") + "', '" + txtC_NO.Text + "'";
            DataTable dt = connect.readdata(ST);
            foreach (DataRow dr in dt.Rows)
            {
                txtC_NO.Text = dr["C_NO"].ToString();
                txtC_NAME.Text = dr["C_NAME2"].ToString();
                DateTime date = DateTime.Parse(dr["RCV_DATE"].ToString());
                txtCAL_YM.Text = date.ToString("yyyyMM");
            }
        }

        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Functions == 2 || Functions == 4 || Functions == 6)
            {
                float Va = float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells["BQTY"].Value.ToString());
                float Va1 = float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells["PRICE"].Value.ToString());
                float sub = Va * Va1;
                DGV1.Rows[DGV1.CurrentRow.Index].Cells[7].Value = sub.ToString();

                float A = 0;
                if (DGV1.Rows.Count >= 1)
                {
                    for (int i = 0; i < DGV1.RowCount; i++)
                    {
                        A = A + float.Parse(DGV1.Rows[i].Cells[7].Value.ToString());
                    }
                    txtTOT.Text = Math.Round(A, 2).ToString();
                    txtTOTAL.Text = Math.Round(A, 2).ToString();
                }
                else
                {
                    txtTOT.Text = "0";
                    txtTOTAL.Text = "0";
                }


            }
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Functions == 2 || Functions == 4 || Functions == 6)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();

                string DL = frm2CustSearch.ID.ID_CUST;
                if (DL != string.Empty)
                {
                    string ST = "select C_NO, C_NAME2 from CUST where C_NO = '" + DL + "'";
                    DataTable dt = connect.readdata(ST);
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME2"].ToString();
                    }
                }
                else
                {
                    txtC_NO.Text = "";
                    txtC_NAME.Text = "";
                }
            }
        }
        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender fm = new LibraryCalender.FromCalender();
            fm.ShowDialog();
            if (LibraryCalender.FromCalender.Flags) txtCAL_YM.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMM");
        }
        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (Functions == 2 || Functions == 4 || Functions == 6) getDataCust();
        }
        private void DGV1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            if(Functions==2 || Functions == 4 || Functions == 6)
            {
                DGV1.CurrentRow.Cells["AMOUNT"].Value = SubData(DGV1.CurrentRow.Cells["BQTY"].Value.ToString(), DGV1.CurrentRow.Cells["PRICE"].Value.ToString()).ToString();
                float Sum = 0;
                if (DGV1.Rows.Count > 0)
                {
                    for (int i = 0; i < DGV1.RowCount; i++)
                    {
                        Sum = Sum + SubData(DGV1.Rows[i].Cells["BQTY"].Value.ToString(), DGV1.Rows[i].Cells["PRICE"].Value.ToString());
                    }
                }
                txtTOT.Text = Math.Round(Sum, 2).ToString();
                txtTOTAL.Text = Math.Round(Sum, 2).ToString();
            }
        }
        private float SubData(string s1, string s2)
        {
            float Num1=0, Num2 = 0;
            float.TryParse(s1, out Num1);
            float.TryParse(s2, out Num2);
            return Num1 * Num2;
        }

        private void txtWS_DATE_TextChanged(object sender, EventArgs e)
        {
            if (Functions == 2) txtWS_NO.Text = CreateWS_NO(txtWS_KIND.Text);
        }

        private void DGV1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Functions == 2 || Functions == 4)
            {
                if (this.DGV1.CurrentCell.OwningColumn.Name == "P_NO")
                {
                    if (string.IsNullOrEmpty(DGV1.CurrentRow.Cells["P_NO"].Value.ToString()))
                    {
                        if (rowIndex < -1) return;
                        frm2E_DGV fr1 = new frm2E_DGV();
                        fr1.ShowDialog();

                        string NR = (rowIndex + 1).ToString("000");
                        UpdateTableDGV(NR);
                    }
                    
                }
            }
        }

        private void 新增明細TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Item();
        }

        private void 插入明細UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert_Item();
        }

        private void 刪除明細VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Item();
        }

        private void 訂單明細WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6ToolStripMenuItem.PerformClick();
        }

        private void 產品挑選XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void 儲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }
        private void 放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFirst();
        }
        private void Add_Item()
        {
            if (rowIndex < -1) return;
            string NRNEW = (TableGRV.Rows.Count+1).ToString("D" + 3);
            TableGRV.Rows.Add(txtWS_NO.Text, NRNEW, txtWS_DATE.Text.Replace("/", ""), "", "", "", "", "", "", "", "", "", "", 1, 0, "", 0, 0, 0, 0, "", "", "", "", "", "", txtCAL_YM.Text.Replace("/", ""), txtWS_KIND.Text, "", "", null, null, null, 0, "N");
            TableGRV.AcceptChanges();
            DGV1.DataSource = TableGRV;
            this.DGV1.Sort(this.DGV1.Columns["NR"], ListSortDirection.Ascending);
        }
        private void Insert_Item()
        {
            if (rowIndex < -1) return;
            foreach (DataRow dr in TableGRV.Rows)
            {
                int.TryParse(dr["NR"].ToString(), out int NR);
                if (NR > rowIndex + 1)
                {
                    dr["NR"] = (NR + 1).ToString("D" + 3);
                    TableGRV.AcceptChanges();
                }
            }
            string NRNEW = (rowIndex + 2).ToString("D" + 3);
            TableGRV.Rows.Add(txtWS_NO.Text, NRNEW, txtWS_DATE.Text.Replace("/", ""), "", "", "", "", "", "", "", "", "", "", 1, 0, "", 0, 0, 0, 0, "", "", "", "", "", "", txtCAL_YM.Text.Replace("/", ""), txtWS_KIND.Text, "", "", null, null, null, 0, "N");
            TableGRV.AcceptChanges();
            DGV1.DataSource = TableGRV;
            this.DGV1.Sort(this.DGV1.Columns["NR"], ListSortDirection.Ascending);
        }
        private void Delete_Item()
        {
            if (TableGRV.Rows.Count > 0)
            {
                DataRow row = TableGRV.Rows[rowIndex];
                row.Delete();
            }
            TableGRV.AcceptChanges();
            foreach (DataRow dr in TableGRV.Rows)
            {
                string i = dr["NR"].ToString();
                int x; int.TryParse(i, out x);
                if (x > rowIndex)
                {
                    x--;
                    string NR = x.ToString("000");
                    dr["NR"] = NR;
                }
            }
            TableGRV.AcceptChanges();
            DGV1.DataSource = TableGRV;
        }
        private void SelectProduct()
        {
            try
            {
                if (rowIndex < -1) return;
                frm2E_DGV fr1 = new frm2E_DGV();
                fr1.ShowDialog();
                if(frm2E_DGV.DT.LV.Count > 0)
                {
                    string NRNEW = (TableGRV.Rows.Count + 1).ToString("D" + 3);
                    for (int i = 0; i < frm2E_DGV.DT.LV.Count; i++)
                    {
                        string BB = frm2E_DGV.DT.LV[i];
                        string BC = frm2E_DGV.DT.LV1[i];
                        string BD = frm2E_DGV.DT.LV2[i];
                        TableGRV.Rows.Add(txtWS_NO.Text, NRNEW, txtWS_DATE.Text.Replace("/", ""), "", "", "", BB, BC, BD, "", "", "SF", "SF", 1, 1, "2", 1, 1, 1, 0, "", "A", "", "", "", "", txtCAL_YM.Text.Replace("/", ""), txtWS_KIND.Text, "", "", null, null, null, 0, "N");
                    }
                    DGV1.DataSource = TableGRV;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTableDGV(string NR)
        {
            foreach(DataRow dr in TableGRV.Rows)
            {
                if (dr["NR"].ToString().Equals(NR))
                {
                    for (int i = 0; i < frm2E_DGV.DT.LV.Count; i++)
                    {
                        dr["P_NO"] = frm2E_DGV.DT.LV[i];
                        dr["P_NAME"] = frm2E_DGV.DT.LV1[i];
                        dr["P_NAME1"] = frm2E_DGV.DT.LV2[i];
                    }
                }
            }
            DGV1.DataSource = TableGRV;
        }
    }
}
