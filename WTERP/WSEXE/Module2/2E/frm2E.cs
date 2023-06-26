using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using LibraryCalender;

namespace WTERP
{
    public partial class Form2E : Form
    {
        DataProvider conn = new DataProvider();
        
        public Form2E()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bindingsource = new BindingSource();
        string a = "";
        #region Load data
        private void Form2E_Load(object sender, EventArgs e)
        {
            loadfirts();
            Load_Data();
            Show_data();
            Load_DGV();
        }
        private void loadfirts()
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            getInfo();
            bt.Text = "" + txtDuyet + "";
            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            txtWS_NO.Enabled = true;
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = conn.getUser(UID);// get UserName 
        }
        public void Load_Data()
        {
            string sql = "SELECT WS_DATE, WS_KIND, WS_NO, C_NO, C_NAME, TOT, TOTAL, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO6, MEMO7, MEMO8, CAL_YM, USR_NAME FROM GIBH ORDER BY WS_DATE DESC,WS_NO DESC";
            dt = new DataTable();
            dt = conn.readdata(sql);
            bindingsource.DataSource = dt;
        }
        public void Load_DGV()
        {
            //string SQL = "select TOP 100 NR, P_NO, P_NAME, COLOR, P_NAME3, BQTY, PRICE,ROUND(AMOUNT,2) as AMOUNT, OR_NO, CAL_YM, OR_NR, MEMO, COLOR_c, P_NAME1, QTY,N'' as WS_DATE,N'' as C_NO,N'' as K_NO  from GIBB where WS_NO = '" + tb3.Text + "' ";
            string SQL = "select TOP 100 *  from GIBB where WS_NO = '" + txtWS_NO.Text + "' ";
            dt = conn.readdata(SQL);
            DGV1.DataSource = dt;
            conn.DGV(DGV1);
        }
        public DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[bindingsource].Position;
                if (position > -1)
                {
                    return ((DataRowView)bindingsource.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        public void Show_data()
        {
            txtWS_DATE.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            txtWS_KIND.Text = currenRow["WS_KIND"].ToString();
            txtWS_NO.Text = currenRow["WS_NO"].ToString();
            txtC_NO.Text = currenRow["C_NO"].ToString();
            txtC_NAME.Text = currenRow["C_NAME"].ToString();
            txtTOT.Text = string.Format("{0:#,##0.00}", double.Parse(currenRow["TOT"].ToString()));
            txtTOTAL.Text = string.Format("{0:#,##0.00}", double.Parse(currenRow["TOTAL"].ToString()));
            txtMEMO1.Text = currenRow["MEMO1"].ToString();
            txtMEMO2.Text = currenRow["MEMO2"].ToString();
            txtMEMO3.Text = currenRow["MEMO3"].ToString();
            txtMEMO4.Text = currenRow["MEMO4"].ToString();
            txtMEMO5.Text = currenRow["MEMO5"].ToString();
            txtMEMO6.Text = currenRow["MEMO6"].ToString();
            txtMEMO7.Text = currenRow["MEMO7"].ToString();
            txtMEMO8.Text = currenRow["MEMO8"].ToString();
            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
            txtCAL_YM.Text = conn.formatstr2(currenRow["CAL_YM"].ToString());
        }
        public bool Checktb3()
        {
            bool chk = false;
            string SQL = "select NR, P_NO, P_NAME, COLOR, P_NAME3, BQTY, PRICE, ROUND(AMOUNT,2) AMOUNT, OR_NO, CAL_YM, OR_NR, MEMO, COLOR_c, P_NAME1, QTY from GIBB where WS_NO = '" + txtWS_NO.Text + "' ";
            dt = conn.readdata(SQL);
            if (dt.Rows.Count > 0)
            {
                chk = true;
            }
            return chk;
        }
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();
            Show_data();
            Load_DGV();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MovePrevious();

                Show_data();
                Load_DGV();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            try
            {
                bindingsource.MoveNext();

                Show_data();
                Load_DGV();
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();
            Show_data();
            Load_DGV();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtText = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtXoa = "";
        string txtSua = "";
        string txtNodata = "";
        string txtQTY = "";
        string txt3 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Bạn Chưa Nhập Mã Số";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
                txtQTY = "Trọng lượng chưa được nhập";
                txt3 = "Danh sách giảm giá đã tòn tại, vui lòng nhập lại!";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Bạn Chưa Nhập Mã Số";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtSua = "SỬA";
                txtNodata = "Không có dữ liệu";
                txtQTY = "Trọng lượng chưa được nhập";
                txt3 = "Danh sách giảm giá đã tòn tại, vui lòng nhập lại!";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "You Have Not Entered Your Code";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtSua = "EDIT";
                txtNodata = "No data";
                txtQTY = "Weight not entered!";
                txt3 = "Track number already exists, please re-enter!";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "您尚未輸入代碼";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtSua = "使固定";
                txtNodata = "沒有數據";
                txtQTY = "重量未輸入!";
                txt3 = "單號已存在,請重新輸入!";
            }
        }
        #endregion
        #region Tool 1-> 12
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void f2ThêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            btok.Show();
            btdong.Show();
            bt.Text = "" + txtThem + "";

            DateTime date = DateTime.Now;
            txtWS_DATE.Text = date.ToString("yyyy/MM/dd");

            txtWS_KIND.Text = "";
            txtWS_NO.Text = "";
            txtC_NO.Text = "";
            txtC_NAME.Text = "";
            txtTOT.Text = "0.00";
            txtTOTAL.Text = "0.00";
            txtMEMO1.Text = "";
            txtMEMO2.Text = "";
            txtMEMO3.Text = "";
            txtMEMO4.Text = "";
            txtMEMO5.Text = "";
            txtMEMO6.Text = "";
            txtMEMO7.Text = "";
            txtMEMO8.Text = "";
            txtCAL_YM.Text = "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            Load_DGV();
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f3ToolStripMenuItem.Checked = true;
            btok.Show();
            btdong.Show();
            bt.Text = "" + txtXoa + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
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
            f4ToolStripMenuItem.Checked = true;
            btok.Show();
            btdong.Show();
            bt.Text = "" + txtSua + "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            txtWS_NO.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5ToolStripMenuItem.Checked = true;
            frm2EF5 fr = new frm2EF5();
            fr.ShowDialog();

            //string DL = frm2EF5.DT.G1;
            //if (DL != string.Empty)
            //{
            //    string SQL = "SELECT WS_DATE, WS_KIND, WS_NO, C_NO, C_NAME, TOT, TOTAL, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO6, MEMO7, MEMO8, CAL_YM,USR_NAME FROM GIBH where WS_NO = '" + DL + "' ";
            //    dt = conn.readdata(SQL);
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        txtWS_DATE.Text = conn.formatstr2(row["WS_DATE"].ToString());
            //        txtWS_KIND.Text = row["WS_KIND"].ToString();
            //        txtWS_NO.Text = row["WS_NO"].ToString();
            //        txtC_NO.Text = row["C_NO"].ToString();
            //        txtC_NAME.Text = row["C_NAME"].ToString();
            //        txtTOT.Text = string.Format("{0:#,##0.00}", double.Parse(row["TOT"].ToString()));
            //        txtTOTAL.Text = string.Format("{0:#,##0.00}", double.Parse(row["TOTAL"].ToString()));
            //        txtMEMO1.Text = row["MEMO1"].ToString();
            //        txtMEMO2.Text = row["MEMO2"].ToString();
            //        txtMEMO3.Text = row["MEMO3"].ToString();
            //        txtMEMO4.Text = row["MEMO4"].ToString();
            //        txtMEMO5.Text = row["MEMO5"].ToString();
            //        txtMEMO6.Text = row["MEMO6"].ToString();
            //        txtMEMO7.Text = row["MEMO7"].ToString();
            //        txtMEMO8.Text = row["MEMO8"].ToString();
            //        txtCAL_YM.Text = conn.formatstr2(row["CAL_YM"].ToString());
            //    }
            //    Load_DGV();
            //}
            //else
            //{
            //    Load_Data();
            //    Show_data();
            //}
            //f5ToolStripMenuItem.Checked = false;
        }
        public class F2E
        {
            public static string MaKH;
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                F2E.MaKH = txtC_NO.Text;
                f1ToolStripMenuItem.Checked = false;
                //f4ToolStripMenuItem.Checked = true;
                f5ToolStripMenuItem.Checked = false;
                f6ToolStripMenuItem.Checked = true;
                f7ToolStripMenuItem.Checked = false;
                f10ToolStripMenuItem.Checked = false;
                f12ToolStripMenuItem.Checked = false;

                btdau.Enabled = false;
                bttruoc.Enabled = false;
                btsau.Enabled = false;
                btketthuc.Enabled = false;

                frm2EF6 fm = new frm2EF6();
                fm.ShowDialog();
                ADD_DGV();
        }
        public void ADD_DGV()
        {
            getDataCust();
            int NR = 1;
            foreach (var item in frm2EF6.LV)
            {
                string SQL1 = "SELECT P_NO, P_NAME_C, COLOR_E, THICK, QTY, PRICE, (QTY * PRICE) TOTAL, OR_NO, NR, COLOR_C, P_NAME_E,WS_DATE,NR,C_NO,K_NO FROM ORDB WHERE WS_DATE = '" + item.WS_DATE + "' AND NR= '" + item.NR + "' AND C_NO= '" + item.C_NO + "' AND K_NO = '" + item.K_NO + "'";
                DataTable dt2 = conn.readdata(SQL1);
                if (dt2.Rows.Count > 0)
                {
                    DataTable dataTable = (DataTable)DGV1.DataSource;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        NR = dataTable.Rows.Count + 1;
                        string AA = NR.ToString("D" + 3);
                        dataTable.Rows.Add(AA, dr["P_NO"].ToString(), dr["P_NAME_C"].ToString(), dr["COLOR_E"].ToString(), dr["THICK"].ToString(), dr["QTY"].ToString(), dr["PRICE"].ToString(), dr["TOTAL"].ToString(),
                                           dr["OR_NO"].ToString(), key, dr["NR"].ToString(), " ", dr["COLOR_C"].ToString(), dr["P_NAME_E"].ToString(), "0", dr["WS_DATE"].ToString(), dr["C_NO"].ToString(), dr["K_NO"].ToString());
                    }
                    txtTOT.Text = string.Format(dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString(), "#,##0.00");
                    txtTOTAL.Text = string.Format(dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString(), "#,##0.00"); 
                }
                NR++;
            }
        }
        //public static string WS_NO;
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WS_NO = txtWS_NO.Text;
            frm2EF7 fr = new frm2EF7();
            fr.ShowDialog();
        }
        #endregion
        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            check();
            if (f2ToolStripMenuItem.Checked == true)
            {
                bool chk = false;
                chk = Checktb3();
                if (chk)
                {
                    MessageBox.Show(txt3);
                }
                else
                {
                    string sql = "SELECT 1 FROM GIBH WHERE WS_NO = '" + txtWS_NO.Text + "'";
                    DataTable data = new DataTable();
                    data = conn.readdata(sql);
                    if (data.Rows.Count > 0)
                    {
                        MessageBox.Show("Đã tồn tại mã '" + txtWS_NO.Text + "'");
                    }
                    else
                    {
                        ADD_DATA();
                    }
                }
            }
            if (f3ToolStripMenuItem.Checked == true)
            {
                DELETE_DATA();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                UPDATE_DATA();
            }
        }
        public void ADD_DATA()
        {
            string D1 = "";
            string D2 = "";
            string D3 = "";
            string D1_1 = "";
            bool checkTransaction = false;
            string ST = " select C_NO, C_ANAME2, ADR3,DEFA_MONEY from CUST where C_NO = '" + txtC_NO.Text + "'";
            DataTable dt4 = conn.readdata(ST);
            if (dt4.Rows.Count > 0)
            {
                foreach (DataRow dr in dt4.Rows)
                {
                    D1 = dr["C_ANAME2"].ToString();
                    D2 = dr["ADR3"].ToString();
                    D3 = dr["DEFA_MONEY"].ToString();
                    if (D1.Length >= 8)
                        D1_1 = D1.Substring(0, 7);

                }
            }    
            for (int i = 0; i < DGV1.RowCount; i++)
            {
                if (int.Parse(DGV1.Rows[i].Cells["QTY"].Value.ToString()) <= 0)
                {
                    MessageBox.Show(txtQTY);
                    return;
                }
            }
            conn.OpentTransaction();
            string st1 = "insert into dbo.GIBH(WS_DATE, WS_KIND, WS_NO, C_NO, C_NAME, C_ANAME, ADDR," +
                " C_NO_O, C_NAME_O, C_ANAME_O, ADDR_O, TAX, DISCOUNT, RCV_MON,  TOT, TOTAL, NRCV_MON," +
                " MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO6, MEMO7, MEMO8, COSTTOT, PACK_NO ,CAL_YM, M_TRAN, M_TRAN_R,OR_NO,USR_NAME) " +
                "SELECT '" + a + "', '" + txtWS_KIND.Text + "', '" + txtWS_NO.Text + "', '" + txtC_NO.Text + "', N'" + txtC_NAME.Text + "', N'" + D1_1 +
                "', N'" + D2 + "', '" + txtC_NO.Text + "', '" + txtC_NAME.Text + "', '" + D1_1 + "', '" + D2 + "', 0, 0, 0, ROUND('" + txtTOT.Text +
                "',2), '" + txtTOTAL.Text + "', '" + txtTOT.Text + "', N'" + txtMEMO1.Text + "', N'" + txtMEMO2.Text + "', N'" + txtMEMO3.Text +
                "', N'" + txtMEMO4.Text + "', N'" + txtMEMO5.Text + "', N'" + txtMEMO6.Text + "', N'" + txtMEMO7.Text + "', N'" + txtMEMO8.Text + "', 0, 0, '" + conn.formatstr2(txtCAL_YM.Text) + "', '" + D3 + "', 31.6,'',N'" + lbUserName.Text + "'";

            checkTransaction = conn.ExecuteTransaction(st1);
            if (txtWS_KIND.Text == string.Empty)
            {
                MessageBox.Show("" + txtText + "");
                return;
            }
            try
            {
                if (checkTransaction == true)
                {
                    Insert_DGV();
                }
                else
                {
                    conn.CloseTransaction(false);
                    return;
                }
            }
            catch (Exception ex)
            {
                conn.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
            loadfirts();
            Load_Data();
            bindingsource.Find("WS_NO", txtWS_NO.Text);
            Load_DGV();
            //btdong.PerformClick();
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
                        string D4 = DGV1.Rows[i].Cells["OR_NR"].Value.ToString();

                        string st2 = "insert into dbo.GIBB(WS_NO, NR, WS_DATE, C_NO, OR_NO, OR_NR, P_NO, P_NAME, P_NAME1, P_NAME3," +
                                     " QTY, TRANS, BQTY, PRICE, AMOUNT, COST, C_OR_NO, COLOR, COLOR_c," +
                                     " CAL_YM, WS_KIND, K_NO, ORD_DATE, WS_ORNO, HOVER1,MEMO)" +
                                     " SELECT N'" + txtWS_NO.Text + "', N'" + DGV1.Rows[i].Cells["NR"].Value + "', '" + a + "', N'" + txtC_NO.Text + "', N'" + DGV1.Rows[i].Cells["OR_NO"].Value +
                                     "', '" + D4 + "', '" + DGV1.Rows[i].Cells["P_NO"].Value + "', N'" + DGV1.Rows[i].Cells["P_NAME"].Value +"'," +
                                     " N'" + DGV1.Rows[i].Cells["P_NAME1"].Value + "', '" + DGV1.Rows[i].Cells["P_NAME3"].Value + "',ROUND( '" + DGV1.Rows[i].Cells["QTY"].Value + "',2), 0, ROUND('" + DGV1.Rows[i].Cells["BQTY"].Value +
                                     "',2), ROUND('" + DGV1.Rows[i].Cells["PRICE"].Value + "',2),ROUND('" + DGV1.Rows[i].Cells["AMOUNT"].Value + "',2), 0, '" + DGV1.Rows[i].Cells["OR_NO"].Value +
                                     "', N'" + DGV1.Rows[i].Cells["COLOR"].Value + "', N'" + DGV1.Rows[i].Cells["COLOR_C"].Value + "', '" + DGV1.Rows[i].Cells["CAL_YM"].Value +
                                     "', '" + txtWS_KIND.Text + "', '" + D3 + "',(SELECT WS_DATE FROM ORDB WHERE WS_DATE = '" + D1 + "' AND C_NO = '" + D2 + "' AND K_NO = '" + D3 + "' AND NR= '" + D4 + "'),(SELECT WS_RNO FROM ORDB WHERE WS_DATE = '" + D1 + "' AND C_NO = '" + D2 + "' AND K_NO = '" + D3 + "' AND NR= '" + D4 + "'),'N','" + DGV1.Rows[i].Cells["MEMO"].Value+ "' ";
                        checktransaction = conn.ExecuteTransaction(st2);
                        if (checktransaction == false)
                        {
                            conn.CloseTransaction(false);
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
                            " SELECT '" + txtWS_NO.Text + "', '" + DGV1.Rows[i].Cells["NR"].Value + "', '" + a + "', '" + txtC_NO.Text + "', '" + DGV1.Rows[i].Cells["P_NO"].Value +
                            "', N'" + DGV1.Rows[i].Cells["P_NAME"].Value + "', N'" + DGV1.Rows[i].Cells["P_NAME1"].Value + "', 'SF', 'SF' " +
                            ",ROUND( '" + DGV1.Rows[i].Cells["QTY"].Value + "',2), 1, 2, ROUND('" + DGV1.Rows[i].Cells["BQTY"].Value + "',2), ROUND('" + DGV1.Rows[i].Cells["PRICE"].Value + "',2), ROUND('" + DGV1.Rows[i].Cells["AMOUNT"].Value +
                            "',2), 0, 'A', '" + DGV1.Rows[i].Cells["CAL_YM"].Value + "', '" + txtWS_KIND.Text + "','Y', 0, 'N',''";
                        checktransaction = conn.ExecuteTransaction(st2);
                        if (checktransaction == false)
                        {
                            conn.CloseTransaction(false);
                            return;
                        }
                    }
                }
                conn.CloseTransaction(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void DELETE_DATA()
        {
            bool check1 = false;
            conn.OpentTransaction();
            DELETE_DGV();
            string MaTL = txtWS_NO.Text;
            if (MaTL == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            try
            {
                check1 = conn.ExecuteTransaction("delete from GIBH where WS_NO ='" + MaTL + "'");
                if (check1 == false)
                {
                    conn.CloseTransaction(false);
                }
                else
                {
                    conn.CloseTransaction(true);
                }
            }
            catch
            {
                conn.CloseTransaction(false);
            }
            btdong.PerformClick();
        }

        public void DELETE_DGV()
        {
            bool check1;
            check();
            for (int i = 0; i < DGV1.RowCount; i++)
            {
                string A1 = DGV1.Rows[i].Cells["NR"].Value.ToString();
                check1 = conn.ExecuteTransaction("delete from GIBB where WS_NO = '" + txtWS_NO.Text + "' AND NR = '" + A1 + "'");
                if (check1 == false)
                {
                    conn.CloseTransaction(false);
                    return;
                }
            }
        }

        public void UPDATE_DATA()
        {
            conn.OpentTransaction();
            string st1 = "update dbo.GIBH set WS_DATE='" + a + "', WS_KIND='" + txtWS_KIND.Text + "', WS_NO='" + txtWS_NO.Text + "'," +
                " C_NO='" + txtC_NO.Text + "', C_NAME=N'" + txtC_NAME.Text + "', TOT='" + txtTOT.Text + "', TOTAL='" + txtTOTAL.Text + "', MEMO1=N'" + txtMEMO1.Text + "', MEMO2=N'" + txtMEMO2.Text + "'," +
                " MEMO3=N'" + txtMEMO3.Text + "', MEMO4=N'" + txtMEMO4.Text + "', MEMO5=N'" + txtMEMO5.Text + "', MEMO6=N'" + txtMEMO6.Text + "', MEMO7=N'" + txtMEMO7.Text + "', MEMO8=N'" + txtMEMO8.Text + "', " +
                "CAL_YM='" + conn.formatstr2(txtCAL_YM.Text) + "', USR_NAME = N'" + lbUserName.Text + "' where WS_NO= '" + txtWS_NO.Text + "'";
            if (txtWS_KIND.Text == string.Empty)
            {
                MessageBox.Show("" + txtText + "");
                return;
            }
            try
            {
                bool check1 = conn.ExecuteTransaction(st1);
                if (check1 == true)
                {
                    Update_DGV();
                }
                else
                {
                    conn.CloseTransaction(false);
                }
            }
            catch (Exception ex)
            {
                conn.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
            loadfirts();
        }
        public void Update_DGV()
        { 
            try
            {
                bool check = conn.ExecuteTransaction("delete from GIBB where WS_NO = '" + txtWS_NO.Text + "'");
                if (check == true)
                {
                    Insert_DGV();
                }
                else
                {
                    conn.CloseTransaction(false);
                }
            }
            catch (Exception ex)
            {
                conn.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
            //}
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            bt.Text = "" + txtDuyet + "";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;
            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            txtWS_NO.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            checkNofication();
            Load_Data();
            Show_data();
            Load_DGV();
        }

        private void tb2_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (txtWS_KIND.Text == "")
                    txtWS_KIND.Text = "B";
                else if (txtWS_KIND.Text == "B")
                    txtWS_KIND.Text = "T";
                else if (txtWS_KIND.Text == "T")
                    txtWS_KIND.Text = "C";
                else if (txtWS_KIND.Text == "C")
                    txtWS_KIND.Text = "B";

                bool chk = false;
                chk = Checktb3();
                if (chk)
                {
                    MessageBox.Show(txt3);
                    txtWS_NO.Focus();
                }
            }
        }

        private void tb3_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                string sql = "EXEC dbo.CreateWS_NO_2E @WS_KIND = N'" + txtWS_KIND.Text + "',@WS_DATE = N'" + conn.formatstr2(txtWS_DATE.Text) + "'";
                DataTable dt23 = new DataTable();
                dt23 = conn.readdata(sql);
                if (dt23.Rows.Count > 0)
                {
                    txtWS_NO.Text = dt23.Rows[0]["WS_NO_NEW"].ToString();
                }
                Load_DGV();
            }
        }
        public void check()
        {
            if (conn.Check_MaskedText(txtWS_DATE) == true)
            {
                a = conn.formatstr2(txtWS_DATE.Text);
            }
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }
        private void tb1_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtCAL_YM, txtWS_KIND, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtWS_DATE, txtWS_NO, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWS_KIND, txtC_NO, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtWS_NO, txtC_NAME, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NO, txtTOT, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME, txtTOTAL, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTOT, txtMEMO1, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTOTAL, txtMEMO2, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO1, txtMEMO3, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO2, txtMEMO4, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO3, txtMEMO5, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO4, txtMEMO6, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO5, txtMEMO7, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO6, txtMEMO8, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {

            conn.tab_DOWN(txtMEMO7, txtCAL_YM, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO8, txtMEMO4, sender, e);
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                getDataCust();
            }

        }
        string key = "";
        private void getDataCust()
        {
            string ST = "Exec getRCV_DATE_2E '" + conn.formatstr2(txtWS_DATE.Text) + "', '" + txtC_NO.Text + "'";
            dt = conn.readdata(ST);
            foreach (DataRow dr in dt.Rows)
            {
                txtC_NO.Text = dr["C_NO"].ToString();
                txtC_NAME.Text = dr["C_NAME2"].ToString();
                DateTime date = DateTime.Parse(dr["RCV_DATE"].ToString());
                if (date.Month <= 9)
                {
                    key = date.Year.ToString() + "0" + date.Month.ToString();
                }
                else
                {
                    key = date.Year.ToString() + date.Month.ToString();
                }
                txtCAL_YM.Text = key;
            }
        }
        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();

                string DL = frm2CustSearch.ID.ID_CUST;
                if (DL != string.Empty)
                {
                    string ST = "select C_NO, C_NAME2 from CUST where C_NO = '" + DL + "'";
                    dt = conn.readdata(ST);
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

        private int rowIndex = 0;

        private void xóaXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
            {
                this.DGV1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
            {
                this.DGV1.Rows.Add("", "", "", "", "", "0", "0.00", "0.00", "", "", "", " ", "", "", "0");
            }
        }

        private void tb8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO1.Text = DL;
                }
                else
                    txtMEMO1.Text = "";
            }
        }

        private void tb9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO2.Text = DL;
                }
                else
                    txtMEMO2.Text = "";
            }
        }

        private void tb10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO3.Text = DL;
                }
                else
                    txtMEMO3.Text = "";
            }
        }

        private void tb11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO4.Text = DL;
                }
                else
                    txtMEMO4.Text = "";
            }
        }

        private void tb12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO5.Text = DL;
                }
                else
                    txtMEMO5.Text = "";
            }
        }

        private void tb13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO6.Text = DL;
                }
                else
                    txtMEMO6.Text = "";
            }
        }

        private void tb14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO7.Text = DL;
                }
                else
                    txtMEMO7.Text = "";
            }
        }

        private void tb15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    txtMEMO8.Text = DL;
                }
                else
                    txtMEMO8.Text = "";
            }
        }

        private void tb16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM");
                //frmDateTime fm = new frmDateTime();
                //fm.ShowDialog();
                //tb16.Text = frmDateTime.Date.ToString("yyyy/MM");
            }
        }
        private void DGV1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.DGV1.Rows[e.RowIndex].Selected = true;
                    rowIndex = e.RowIndex;
                    this.DGV1.CurrentCell = this.DGV1.Rows[e.RowIndex].Cells[1];
                    this.contextMenuStrip1.Show(this.DGV1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true)
            {
                if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
                {
                    this.DGV1.Rows.RemoveAt(this.rowIndex);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true)
            {
                //if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
                //{
                //    this.DGV1.Rows.Add("", "", "", "", "", "0", "0.00", "0.00", "", "", "", " ", "", "", "0");
                //}
            }

        }
        private void tb2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (f2ToolStripMenuItem.Checked == true)
                {
                    if (!string.IsNullOrEmpty(txtWS_KIND.Text))
                    {
                        string sql = "EXEC dbo.CreateWS_NO_2E @WS_KIND = N'" + txtWS_KIND.Text + "',@WS_DATE = N'" + conn.formatstr2(txtWS_DATE.Text) + "'";
                        DataTable dt23 = new DataTable();
                        dt23 = conn.readdata(sql);
                        if (dt23.Rows.Count > 0)
                        {
                            txtWS_NO.Text = dt23.Rows[0]["WS_NO_NEW"].ToString();
                        }
                        Load_DGV();
                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1)
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
                        dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.00", "1.00", "", key, "", "", "", BD, "0");
                        //NR++;
                    }
                    DGV1.DataSource = dataTable;
                }
                if (Cur == 11)
                {
                    FormSearchLeather2 fr1 = new FormSearchLeather2();
                    fr1.ShowDialog();
                    string MM = FormSearchLeather2.ID.M_NAME;
                    this.DGV1[11, DGV1.CurrentRow.Index].Value = MM;
                }
            }
        }

        private void Form2E_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
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
                                
                                dataTable.Rows.Add(AA, BB, BC, "", "", "1", "1.00", "1.00", "", key, "", "", "", BD, "0");
                                //NR++;
                            }
                            DGV1.DataSource = dataTable;
                            txtTOT.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                            txtTOTAL.Text = dataTable.AsEnumerable().Sum(s => s.Field<double>("AMOUNT")).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập mã báo giá");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

        private void tb4_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                bool chk = false;
                chk = Checktb3();
                if (chk)
                {
                    MessageBox.Show(txt3);
                    txtWS_NO.Focus();
                }
            }
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                bool chk = false;
                chk = Checktb3();
                if (chk)
                {
                    MessageBox.Show(txt3);
                    txtWS_NO.Focus();
                }
            }
        }

        private void tb5_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                bool chk = false;
                chk = Checktb3();
                if (chk)
                {
                    MessageBox.Show(txt3);
                    txtWS_NO.Focus();
                }
            }
        }

        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                float Va = float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells[5].Value.ToString());
                float Va1 = float.Parse(DGV1.Rows[DGV1.CurrentRow.Index].Cells[6].Value.ToString());
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
