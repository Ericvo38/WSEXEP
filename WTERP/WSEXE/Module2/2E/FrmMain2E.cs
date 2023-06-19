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
            bdSource.Position = bdSource.Find("MK_NOA", s);
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
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 4;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 5;
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 6;
            frm2EF6 fm = new frm2EF6();
            fm.ShowDialog();
            if (frm2EF6.LV.Count >0) ADD_DGV();
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functions = 7;
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
                CheckMove();
                if (bdSource.Count > -1) ShowRecord();
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
        }
        private void LoadDGV()
        {
            try
            {
                string SQL = "SELECT * FROM GIBB WHERE WS_NO ='"+txtWS_NO.Text+"' ";
                TableGRV = connect.readdata(SQL);
                DGV1.DataSource = TableGRV;

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

                DGV1.DataGridViewFormat();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CreateWS_NO(string S)
        {
            int KQ = 0;
            string Result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(S))
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
                        string SQL = "SELECT MAX(WS_NO) AS  WS_NO FROM dbo.GIBH WHERE WS_KIND ='" + S + "' AND WS_DATE LIKE '" + DateTime.Now.ToString("yyyy") + "%' ";
                        string B = connect.ExecuteScalar(SQL);
                        B = B.Substring(B.LastIndexOf("-") + 1, ((B.Length - 1) - B.LastIndexOf("-")));
                        int.TryParse(B, out KQ);
                        KQ++;
                        if (S.Equals("T") || S.Equals("C")) S = S + "V";
                        Result = S + DateTime.Now.ToString("yyMM") + "-" + KQ.ToString("0000");
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
            foreach (var item in frm2EF6.LV)
            {
                //string SQL = "SELECT P_NO, P_NAME_C, COLOR_E, THICK, QTY, PRICE, (QTY * PRICE) TOTAL, OR_NO, NR, COLOR_C, P_NAME_E,WS_DATE,NR,C_NO,K_NO FROM ORDB WHERE WS_DATE = '" + item.WS_DATE + "' AND NR= '" + item.NR + "' AND C_NO= '" + item.C_NO + "' AND K_NO = '" + item.K_NO + "'";
                string SQL = "SELECT OR_NO, NR, P_NO, P_NAME_C, P_NAME_E AS P_NAME1, THICK AS P_NAME3,  QTY, PRICE, COLOR_E, COLOR_C, K_NO, WS_DATE, WS_RNO   FROM dbo.ORDB WHERE WS_DATE= '"+item.WS_DATE+"' AND NR ='" + item.NR+ "' AND C_NO ='"+item.C_NO+"' AND K_NO ='" + item.K_NO+"' ";
                DataTable dt2 = connect.readdata(SQL);
                if (dt2.Rows.Count > 0)
                {
                    NR = TableGRV.Rows.Count + 1;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        TableGRV.Rows.Add(txtWS_NO.Text, NR.ToString("000"), txtWS_DATE.Text, txtC_NO.Text, dr["OR_NO"].ToString(), dr["NR"].ToString(), dr["P_NO"].ToString(), dr["P_NAME_C"].ToString(), dr["P_NAME1"].ToString(),"", dr["P_NAME3"].ToString(), "", "", 1, 0, "", dr["QTY"].ToString(), dr["PRICE"].ToString(), GetAmount(dr["QTY"].ToString(), dr["PRICE"].ToString()),
                            0, "", "", "", dr["OR_NO"].ToString(), dr["COLOR_E"].ToString(), dr["COLOR_C"].ToString(), txtCAL_YM.Text.Replace("/",""), txtWS_KIND.Text, dr["K_NO"].ToString(), txtWS_DATE.Text.Replace("/",""), null, null,null, ss(dr["WS_RNO"].ToString()), "N");
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
        private int ss(string x)
        {
            int.TryParse(x, out int re);
            return re;
        }
        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {
            if (Functions == 0) LoadDGV();
        }
        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Functions == 2 || Functions == 4)
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

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if(Functions==2 || Functions == 4 || Functions == 6)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                    menu.Items.Add("Insert").Name = "Insert";
                    menu.Items.Add("Edit").Name = "Edit";
                    menu.Items.Add("Del").Name = "Del";

                    menu.Show(DGV1, new Point(e.X, e.Y));
                    menu.ItemClicked += Menu_ItemClicked;
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
                        if (!string.IsNullOrEmpty(txtWS_NO.Text))
                        {
                            frm2E_DGV fr1 = new frm2E_DGV();
                            fr1.ShowDialog();

                            int NR = 1;
                            DataTable dataTable = (DataTable)DGV1.DataSource;
                            for (int i = 0; i < frm2E_DGV.DT.LV.Count; i++)
                            {
                                NR = dataTable.Rows.Count + 1;
                                string AA = NR.ToString("D" + 3);

                                string BB = frm2E_DGV.DT.LV[i];
                                string BC = frm2E_DGV.DT.LV1[i];
                                string BD = frm2E_DGV.DT.LV2[i];

                                dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.00", "1.00", "", txtCAL_YM.Text, "", "", "", BD, "0");
                                //NR++;
                            }
                            DGV1.DataSource = dataTable;
                            txtTOT.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                            txtTOTAL.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                        }
                        else
                        {
                            txtWS_KIND.Focus();
                            if (frmLogin.Lang_ID == 1) throw new Exception("Loại đơn hàng không được để trống!");
                            else if (frmLogin.Lang_ID == 2) throw new Exception("Order type cannot be blank!");
                            else if (frmLogin.Lang_ID == 3) throw new Exception("訂單類型不能為空！");
                            else throw new Exception("Loại đơn hàng không được để trống!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "Del":
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
                if (date.Month <= 9)
                {
                    txtCAL_YM.Text = date.Year.ToString() + "0" + date.Month.ToString();
                }
                else
                {
                    txtCAL_YM.Text = date.Year.ToString() + date.Month.ToString();
                }
            }
        }

        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
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
    }
}
