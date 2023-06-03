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
using System.Data.SqlClient;
using LibraryCalender;

namespace WTERP
{
    public partial class frm2F : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source = new BindingSource();
        string key = "";
        public frm2F()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        public class Share_2F
        {
            public static string C_NO;
        }
        string a = "";
        string b = "";
        public static string USES_NAME;
        #region Load Data 
        private void frm2F_Load(object sender, EventArgs e)
        {
            getInfo();
            loadsfirst();
            LoadData("WHERE 1=1");
            txtM_NAME.Enabled = false;
            ReadOnly(true);
        }
        private void LoadData(string key)
        {
            string sql = "SELECT WS_DATE,WS_NO,C_NO,C_NAME,CAL_YM,M_TRAN,USR_NAME,RCVTOT,TOT FROM CATH " + key + " ORDER BY WS_NO DESC";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            source.DataSource = data;
            LoadText();
        }
        private void LoadDGV(string key)
        {
            string s2 = "SELECT NR, P_NO, P_NAME, COLOR, P_NAME3, BQTY, PRICE, AMOUNT, C_OR_NO, CAL_YM, P_NAME1 FROM CATB WHERE WS_NO = '" + key + "' ";
            DataTable dt1 = con.readdata(s2);
            foreach (DataRow dr in dt1.Rows)
                dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
            DGV.DataSource = dt1;
            con.DGV(DGV);
        }
        private void ReadOnly(bool a)
        {
            txtWS_DATE.ReadOnly = a;
            txtWS_NO.ReadOnly = a;
            txtCAL_YM.ReadOnly = a;
            txtC_NO.ReadOnly = a;
            txtC_NAME.ReadOnly = a;
            txtRCVTOT.ReadOnly = a;
            txtTOT.ReadOnly = a;
        }
        public DataRow currentRow
        {
            get
            {
                int position = this.BindingContext[source].Position;
                if (position > -1)
                {
                    return ((DataRowView)source.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        private void LoadText()
        {
            txtWS_DATE.Text = con.formatstr2(currentRow["WS_DATE"].ToString());
            txtWS_NO.Text = currentRow["WS_NO"].ToString();
            txtC_NO.Text = currentRow["C_NO"].ToString();
            txtC_NAME.Text = currentRow["C_NAME"].ToString();
            txtCAL_YM.Text = currentRow["CAL_YM"].ToString();
            txtM_NAME.Text = getCombobox(currentRow["M_TRAN"].ToString());
            txtUSR_NAME.Text = currentRow["USR_NAME"].ToString();
            txtRCVTOT.Text = string.Format("{0:#,##0.00}", currentRow["RCVTOT"].ToString());
            txtTOT.Text = string.Format("{0:#,##0.00}", currentRow["TOT"].ToString());

            LoadDGV(txtWS_NO.Text);
        }
        private string getCombobox(string key)
        {
            string m_name = "";
            string sql = "SELECT TOP 1 M_NO,M_NAME FROM dbo.MONEYT WHERE M_NO = '"+ key + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                m_name = data.Rows[0]["M_NAME"].ToString();
            }
            return m_name;
            
        }
        private string ReturnComboboxID(string key)
        {
            string m_name = "";
            string sql = "SELECT TOP 1 M_NO FROM dbo.MONEYT WHERE M_NAME = '" + key + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                m_name = data.Rows[0]["M_NO"].ToString();
            }
            return m_name;

        }
        private void setCombobox()
        {
            txtM_NAME.Enabled = true;
            string sql = "SELECT DISTINCT M_NO,M_NAME FROM dbo.MONEYT WHERE 1=1";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            foreach (DataRow item in data.Rows)
            {
                txtM_NAME.Items.Add(item["M_NAME"].ToString());
            }
        }
        public static DataTable cbox;
        public void getInfo() //Method getIP,ID, User...  
        {
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = con.getUser(UID);// get UserName 
        }
        private void loadsfirst()
        {
            con.CheckLoad(menuStrip1);
          
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;

            btnDong.Visible = false;
            btnOk.Visible = false;
          

        }
        private void timer1_Tick(object sender, EventArgs e)  //get TimeNow  
        {
          btnTimeNow.Text = CN.getTimeNow();
          btndateNow.Text = CN.getDateNow();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
           
            source.MoveFirst();
            LoadText();
            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
            LoadText();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            source.MoveNext();
            LoadText();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            source.MoveLast();
            LoadText();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }
        #endregion
    
        #region Tool 1 -> 12
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = true;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnDong.Visible = true;
            btnOk.Visible = true;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
            //xử lý du liệu null
            ReadOnly(false);
            setCombobox();
            ResetTextBoxNull();
            LoadDGV(txtWS_NO.Text);
            txtRCVTOT.Text = "0.00";
            txtTOT.Text = "0.00";

            txtWS_DATE.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtCAL_YM.Text = DateTime.Now.ToString("yyyy/MM");
            getdataWWS_NO();

        } // F3 Adding Data
        private void ResetTextBoxNull()
        {
            txtWS_DATE.Text = "";
            txtWS_NO.Text = "";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtCAL_YM.Text = "";
            txtM_NAME.Text = "";
            txtUSR_NAME.Text = "";
            txtRCVTOT.Text = "";
            txtTOT.Text = "";
        }
        private void DGV_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    int position_xy_mouse_row = DGV.HitTest(e.X, e.Y).RowIndex;
                    menu.Items.Add("Insert").Name = "Insert";
                    menu.Items.Add("Edit").Name = "Edit";
                    menu.Items.Add("Del").Name = "Del";

                    menu.Show(DGV, new Point(e.X, e.Y));
                    menu.ItemClicked += Menu_ItemClicked;
                }
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
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
                            DataTable dataTable = (DataTable)DGV.DataSource;
                            for (int i = 0; i < frm2E_DGV.DT.LV.Count; i++)
                            {
                                NR = dataTable.Rows.Count + 1;
                                string AA = NR.ToString("D" + 3);
                                string BB = frm2E_DGV.DT.LV[i];
                                string BC = frm2E_DGV.DT.LV1[i];
                                string BD = frm2E_DGV.DT.LV2[i];

                                dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.000", "1.00", "", key, BD);
                                //NR++;
                            }
                            DGV.DataSource = dataTable;
                            txtTOT.Text = string.Format("{0:#,##0.00}", dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString());
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập mã hóa đơn chưa nhận");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Del":
                    foreach (DataGridViewCell oneCell in DGV.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV.Rows.Count - 1; i++)
                            {
                                DGV[0, i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }
        private void addData()
        {
            string txtKey = "";
            if (txtC_NAME.Text.Length < 8)
            {
                txtKey = txtC_NAME.Text;
            }
            else
            {
                txtKey = txtC_NAME.Text.Substring(0, 8);
            }
            string SQL2 = "INSERT INTO CATH (WS_NO, WS_DATE, C_NO, C_NAME, C_ANAME, C_NO_O, C_NAME_O, C_ANAME_O, TAX, DISCOUNT, RCV_MON, TOT, TOTAL, NRCV_MON, COSTTOT, PACK_NO, CAL_YM, M_TRAN, M_TRAN_R, RCVTOT, USR_NAME,ADDR,OR_NO,C_OR_NO,ADDR_O,INV_NO,AC_WS_NO,MEMO1,MEMO2,MEMO3,MEMO4,MEMO5,MEMO6,MEMO7,MEMO8,S_NO,S_NAME,DATESE,T_METH,CAR_COMPANY)  " +
            "SELECT '" + txtWS_NO.Text + "', '" + a + "', '" + txtC_NO.Text + "', '" + txtC_NAME.Text + "', '" + txtKey + "', '" + txtC_NO.Text + "', '" + txtC_NAME.Text + "', " +
            "'" + txtKey + "', 0, 0, 0,ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2),ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2),ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2), 0, 0, '" + b + "', " +
            "'" + ReturnComboboxID(txtM_NAME.Text) + "', 31.6,ROUND('" + double.Parse(string.IsNullOrEmpty(txtRCVTOT.Text) ? "0" : txtRCVTOT.Text) + "',2), '" + lbUserName.Text + "','','','','','','','','','','','','','','','','','','',''";
            bool dt2 = con.exedata(SQL2);
            if (dt2 == true)
            {
                ADD_DGV();
            }
        }
        public void ADD_DGV()
        {
          
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                string WS_DATE = a;
                string C_NO = txtC_NO.Text;
                string NR = DGV.Rows[i].Cells["NR"].Value.ToString();
                string P_NO = DGV.Rows[i].Cells["P_NO"].Value.ToString();
                string P_NAME = DGV.Rows[i].Cells["P_NAME"].Value.ToString();
                string COLOR = DGV.Rows[i].Cells["COLOR"].Value.ToString();
                string P_NAME3 = DGV.Rows[i].Cells["P_NAME3"].Value.ToString();
                string BQTY = DGV.Rows[i].Cells["BQTY"].Value.ToString();
                string PRICE = DGV.Rows[i].Cells["PRICE"].Value.ToString();
                string AMOUNT = DGV.Rows[i].Cells["AMOUNT"].Value.ToString();
                string C_OR_NO = DGV.Rows[i].Cells["C_OR_NO"].Value.ToString();
                string CAL_YM = DGV.Rows[i].Cells["CAL_YM"].Value.ToString();
                string P_NAME1 = DGV.Rows[i].Cells["P_NAME1"].Value.ToString();

                string SLQ3 = "INSERT INTO CATB (WS_NO, NR, WS_DATE, C_NO, P_NO, P_NAME, P_NAME1, UNIT, BUNIT, QTY, TRANS, CUNIT, BQTY, PRICE, AMOUNT,COST,MEMO, SH_NO,FOB_DATE,C_OR_NO,COLOR,COLOR_C, CAL_YM, K_NO, P_NAME3) VALUES " +
                    "('" + txtWS_NO.Text + "', '" + NR + "', '" + WS_DATE + "','" + C_NO + "', '" + P_NO + "', '" + P_NAME + "', '" + P_NAME1 + "', 'SF', 'SF', 0, 1, 2,ROUND( '" + BQTY + "',2)," +
                    "ROUND('" + PRICE + "',2),ROUND( '" + AMOUNT + "',2),0,'','A','', '" + C_OR_NO + "','" + COLOR + "','', '" + con.formatstr2(CAL_YM) + "', 1, '" + P_NAME3 + "')";
                con.exedata(SLQ3);

            }
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) // F3 Delete Data 
        {
         
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btnDong.Visible = true;
            btnOk.Visible = true;

            txtWS_NO.ReadOnly = true;
        
        }
        private void DeleteData()
        {
            string SQL = "DELETE CATH WHERE  WS_NO = '" + txtWS_NO.Text + "'";
            bool a = con.exedata(SQL);
            if (a == true)
            {
                Delete_DGV();
            }    
               
        }

        public void Delete_DGV()
        {
            string SQL = "DELETE CATB WHERE WS_NO = '" + txtWS_NO.Text + "'";
            con.exedata(SQL);
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Repair Data 
        {
           
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btnDong.Visible = true;
            btnOk.Visible = true;

            ReadOnly(false);
            txtWS_NO.ReadOnly = true;

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;
        }
        private void UpdateData()
        {
            string SQL2 = "UPDATE  CATH SET  WS_DATE ='" + a + "', CAL_YM= '" + b + "', C_NO= '" + txtC_NO.Text + "', C_NAME = '" + txtC_NAME.Text + "', M_TRAN = '" + ReturnComboboxID(txtM_NAME.Text) + "', " +
                "RCVTOT = ROUND('" + double.Parse(string.IsNullOrEmpty(txtRCVTOT.Text) ? "0" : txtRCVTOT.Text) + "',2), TOT = ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2), TOTAL = ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2)," +
                " NRCV_MON = ROUND('" + double.Parse(string.IsNullOrEmpty(txtTOT.Text) ? "0" : txtTOT.Text) + "',2), USR_NAME = N'" + lbUserName.Text+"' WHERE WS_NO = '" + txtWS_NO.Text + "' ";
            bool dt2 = con.exedata(SQL2);
            if (dt2 == true)
            {
                Update_DGV();
            }    
        }
        public void Update_DGV()
        {
            Delete_DGV();
            ADD_DGV();
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) //F5 Searching Data 
        {
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = true;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            frm2FF5 frm = new frm2FF5();
            frm.ShowDialog();
            source.DataSource = frm2FF5.getWS_NO.bind;
            source.Position = frm2FF5.getWS_NO.index;
            LoadText();
            LoadDGV(txtWS_NO.Text);
           
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Share_2F.C_NO = txtC_NO.Text;
            frm2FF7_Print fm = new frm2FF7_Print();
            fm.ShowDialog();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtWS_NO_MouseClick(object sender, MouseEventArgs e)
        {
            getdataWWS_NO();
        }
        private void getdataWWS_NO()
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                string date = con.formatstr2(txtWS_DATE.Text).Trim();
                string date2 = con.formatstr2(txtWS_DATE.Text).Substring(0, 4);
                string s = "SELECT TOP 1 WS_NO FROM CATH WHERE YEAR(WS_DATE) = '" + date2 + "' ORDER BY WS_NO DESC";
                //string s = "SELECT WS_NO FROM CATH";
                string Da = date.Substring(2, 2);
                DataTable dt = con.readdata(s);
                if (dt.Rows.Count > 0)
                {
                    int max = 01;
                    foreach (DataRow dr in dt.Rows)
                    {

                        string k = dr["WS_NO"].ToString();
                        k = k.Substring(k.Length - 6, 6);
                        int L = int.Parse(k);

                        if (max < L)
                            max = L;
                        max = max + 1;
                    }
                    string asString = max.ToString("D" + 6);
                    string re = "N" + Da + "-" + asString;
                    txtWS_NO.Text = re;
                }
                else
                {
                    txtWS_NO.Text = "N" + Da + "-000001";
                }
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            loadsfirst();
            LoadData("WHERE 1=1");
           
        }
        #endregion


        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                check();
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if (con.checkExists("SELECT TOP 1 WS_NO FROM CATH WHERE WS_NO = '" + txtWS_NO.Text + "'") == true)
                    {
                        MessageBox.Show("Mã " + txtWS_NO.Text + " đã tồn tại!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       
                        addData();
                        loadsfirst();
                        LoadData("WHERE 1=1");
                    }
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    DeleteData();
                    loadsfirst();
                    LoadData("WHERE 1=1");
                    txtWS_NO.ReadOnly = false;
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    UpdateData();
                    loadsfirst();
                    LoadData("WHERE 1=1");
                    txtWS_NO.ReadOnly = false;
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked || f4ToolStripMenuItem.Checked || f6ToolStripMenuItem.Checked)
            {
                frm2CustSearch fm = new frm2CustSearch();
                fm.ShowDialog();
                txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
                txtC_NAME.Text = frm2CustSearch.ID.NAME_C;
            }
        }
        
        private void maskedTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked || f4ToolStripMenuItem.Checked || f6ToolStripMenuItem.Checked)
            {
                FromCalender frmDateTime1 = new FromCalender();
                frmDateTime1.ShowDialog();
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }    
           
        }

        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked || f4ToolStripMenuItem.Checked || f6ToolStripMenuItem.Checked)
            {
                FromCalender frmDateTime1 = new FromCalender();
                frmDateTime1.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM");
            }
        }
        public void check()
        {
            if (con.Check_MaskedText(txtWS_DATE) == true)
            {
                a = con.formatstr2(txtWS_DATE.Text);
            }
            if (con.Check_MaskedText(txtCAL_YM) == true)
            {
                b = con.formatstr2(txtCAL_YM.Text);
            }
        }
        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NAME, txtWS_NO, sender, e);
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE, txtCAL_YM, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtCAL_YM, txtC_NAME, sender, e);
        }

        private void txtCAL_YM_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtWS_NO, txtC_NO, sender, e);
        }

        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO, txtWS_DATE, sender, e);
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
           if (f2ToolStripMenuItem.Checked || f4ToolStripMenuItem.Checked || f6ToolStripMenuItem.Checked)
            {
                getDataCust();
            }    
        }
        private void getDataCust()
        {
            string ST = "Exec getRCV_DATE_2E '" + con.formatstr2(txtWS_DATE.Text) + "', '" + txtC_NO.Text + "'";
            DataTable dt = con.readdata(ST);
            foreach (DataRow dr in dt.Rows)
            {
                txtC_NO.Text = dr["C_NO"].ToString();
                txtC_NAME.Text = dr["C_NAME2"].ToString();
                txtM_NAME.Text = getCombobox(dr["DEFA_MONEY"].ToString());
                DateTime date = DateTime.Parse(dr["DATE_ADD"].ToString());
                DateTime date2 = DateTime.Parse(dr["RCV_DATE"].ToString());
                if (date.Month <= 9)
                {
                    txtCAL_YM.Text = date2.Year.ToString() + "/0" + date2.Month.ToString();
                    key = date.Year.ToString() + "/0" + date.Month.ToString();
                }
                else
                {
                    txtCAL_YM.Text = date2.Year.ToString() + "/" + date2.Month.ToString();
                    key = date.Year.ToString() +"/"+ date.Month.ToString();
                }
                //txtCAL_YM.Text = dr["RCV_DATE"].ToString("yyyyMM");
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float Va = float.Parse(DGV.Rows[DGV.CurrentRow.Index].Cells["BQTY"].Value.ToString());
            float Va1 = float.Parse(DGV.Rows[DGV.CurrentRow.Index].Cells["PRICE"].Value.ToString());
            float sub = Va * Va1;
            DGV.Rows[DGV.CurrentRow.Index].Cells["AMOUNT"].Value = sub.ToString();

            float A = 0;
            if (DGV.Rows.Count >= 1)
            {
                for (int i = 0; i < DGV.RowCount; i++)
                {
                    A = A + float.Parse(DGV.Rows[i].Cells["AMOUNT"].Value.ToString());
                }
                txtTOT.Text = string.Format("{0:#,##0.00}", A.ToString());
            }
            else
            {
                txtTOT.Text = "0.00";
            }
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
