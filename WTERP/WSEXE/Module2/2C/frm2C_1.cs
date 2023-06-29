using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Linq;
using LibraryCalender;
using System.Drawing;

namespace WTERP
{
    public partial class frm2C_1 : Form
    {
        DataProvider con = new DataProvider();
        public frm2C_1()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        double HANG_SO = 31.6;
        BindingSource source1 = new BindingSource();
        DataTable dbTable;
        string a = "";
        string b = "";
        string c = ""; 

        #region Load Data
        public void check()
        {
            if (con.Check_MaskedText(txtNgayThiCong) == true)
            {
                a = txtNgayThiCong.Text;
            }
            if (con.Check_MaskedText(txtNgayGiao) == true)
            {
                b = txtNgayGiao.Text;
            }
            if (con.Check_MaskedText(txtCAL_YM) == true)
            {
                c = txtCAL_YM.Text;
            }
        }
        private void frm2C_1_Load(object sender, EventArgs e)
        {
            try
            {
                getInfo();
                LoadFirst();
                Load_Data();
                Load_DGV();
                ShowRecord();
                TrueLock_FalseUnLock_TextBox(true);
                cbTienTe.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = con.getUser(UID);// get UserName 
        }
        public void Load_Data()
        {
          string SQL0 = "SELECT TOP 1000 WS_NO, OR_NO,WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR,ROUND(TOT,2)  AS TOT,ROUND(TOTAL,2) TOTAL, TOT, TOTAL, OVER0, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO6, MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1 "+frm2CF5.DL.where+" ORDER BY WS_NO DESC";
          dbTable = con.readdata(SQL0);
          source1.DataSource = dbTable;
          GetMoneyt();
        
        }
        public DataRow currenRow
        {
            get
            {
                int position = this.BindingContext[source1].Position;
                if (position > -1)
                {
                    return ((DataRowView)source1.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        public void ShowRecord()
        {

            txtNgayThiCong.Text = con.formatstr2(currenRow["WS_DATE1"].ToString());
            txtNgayGiao.Text = con.formatstr2(currenRow["WS_DATE"].ToString());

            txtLoHang.Text = currenRow["WS_NO"].ToString();
            txtTaiLieu.Text = currenRow["OR_NO"].ToString();
            txtMaKH.Text = currenRow["C_NO"].ToString();
            txtTenKH.Text = currenRow["C_NAME"].ToString();
            cbTienTe.Text = con.Moneys(currenRow["M_TRAN"].ToString());

            txtDiaChi.Text = currenRow["ADDR"].ToString();
            TOT.Text = string.Format(currenRow["TOT"].ToString(), "#,##0.00");
            TOTAL.Text = string.Format(currenRow["TOTAL"].ToString(), "#,##0.00");
            OVER0.Text = currenRow["OVER0"].ToString();

            MEMO1.Text = currenRow["MEMO1"].ToString();
            MEMO2.Text = currenRow["MEMO2"].ToString();
            MEMO3.Text = currenRow["MEMO3"].ToString();
            MEMO4.Text = currenRow["MEMO4"].ToString();
            MEMO5.Text = currenRow["MEMO5"].ToString();
            MEMO6.Text = currenRow["MEMO6"].ToString();
            MEMO7.Text = currenRow["MEMO7"].ToString();
            MEMO8.Text = currenRow["MEMO8"].ToString();

            txtCAL_YM.Text = con.formatstr2(currenRow["CAL_YM"].ToString());

            txtUSR_NAME.Text = currenRow["USR_NAME"].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        public void Load_DGV()
        {
            string SQL2 = "SELECT NR,OR_NO,COLOR_C,COLOR,P_NAME,P_NAME3,BQTY as QTY,PRICE,AMOUNT,PCS,QTY as BQTY,MEMO,MK_NO1,QPCS,OR_NR,P_NAME2,P_NO,CAL_YM,C_OR_NO,GB_NO,GB_NR FROM CARB WHERE WS_NO = '" + txtLoHang.Text + "'";
            DataTable data = new DataTable();
            data = con.readdata(SQL2);
            DGV1.DataSource = data;
            con.DGV(DGV1);
          
            //load tab 2
            loadTab2(0);
        }
        string OR_NR1 = "";
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
               loadTab2(DGV1.CurrentRow.Index);
            }

        }
        public void loadTab2(int index1)
        {
           if (DGV1.Rows.Count > 0)
           {
               if (!string.IsNullOrEmpty(DGV1.Rows[index1].Cells["OR_NO"].Value.ToString()))
               {
                   OR_NR1 = DGV1.Rows[index1].Cells["OR_NR"].Value.ToString();
                   txtSoDH.Text = DGV1.Rows[index1].Cells["OR_NO"].Value.ToString();

                    DataTable dt3 = new DataTable();
                    if (txtSoDH.Text != string.Empty)
                    {
                        string SQL2 = "SELECT COLOR_E, COLOR_C, QTY FROM ORDB WHERE OR_NO = '" + txtSoDH.Text + "' AND NR = '" + OR_NR1 + "'";
                        DataTable dt2 = con.readdata(SQL2);
                        foreach (DataRow dr in dt2.Rows)
                        {
                            TxtMau_E.Text = dr["COLOR_E"].ToString();
                            TxtMau_C.Text = dr["COLOR_C"].ToString();
                            txtDinhLuong.Text = string.Format("{0:#,##0.00}", double.Parse(dr["QTY"].ToString()));
                        }
                        string SQL3 = "SELECT WS_NO,WS_DATE,BQTY FROM CARB WHERE OR_NO = '" + txtSoDH.Text + "' AND OR_NR = '" + OR_NR1 + "'";
                        dt3 = con.readdata(SQL3);
                        DGV2.DataSource = dt3;
                        float a = 0;
                        foreach (DataRow item in dt3.Rows)
                        {
                            a += float.Parse(item["BQTY"].ToString());
                        }
                        txtSoL.Text = a.ToString();

                        double i = double.Parse(txtDinhLuong.Text);
                        double j = double.Parse(txtSoL.Text);
                        double x = i - j;
                        txtSoLuongTon.Text = x.ToString("#,##0.00");
                    }
                    else
                    {
                        TxtMau_E.Text = "";
                        TxtMau_C.Text = "";
                        txtDinhLuong.Text = "";
                        txtSoLuongTon.Text = "";
                        txtSoL.Text = "";
                        DGV2.DataSource = dt3;
                    }
                    con.DGV(DGV2);
                }
           }
           else
           {
               txtSoDH.Text = "";
           }
        }
        public void LoadFirst()
        {
            con.CheckLoad(menuStrip1);

            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f8ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f11ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btnMoveFirst.Enabled = true;
            btnMoveLast.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMovePrevious.Enabled = true;

            btnAction.Hide();
            btnClose.Hide();
            //  f5ToolStripMenuItem.Checked = false;   
        }
        private void TrueLock_FalseUnLock_TextBox(bool check)
        {
            //tab 1
            txtNgayThiCong.ReadOnly = check;
            txtNgayGiao.ReadOnly = check;
            txtLoHang.ReadOnly = check;
            txtTaiLieu.ReadOnly = check;
            txtMaKH.ReadOnly = check;
            txtTenKH.ReadOnly = check;

            txtDiaChi.ReadOnly = check;
            DGV1.ReadOnly = check;
            TOT.ReadOnly = check;
            OVER0.ReadOnly = check;
            MEMO5.ReadOnly = check;
            txtCAL_YM.ReadOnly = check;
            TOTAL.ReadOnly = check;
            MEMO1.ReadOnly = check;
            MEMO2.ReadOnly = check;
            MEMO3.ReadOnly = check;
            MEMO4.ReadOnly = check;
            MEMO6.ReadOnly = check;
            MEMO7.ReadOnly = check;
            MEMO8.ReadOnly = check;
            MEMO1.ReadOnly = check;
            MEMO1.ReadOnly = check;

            //tab 2
            txtSoDH.ReadOnly = check;
            TxtMau_E.ReadOnly = check;
            TxtMau_C.ReadOnly = check;
            txtDinhLuong.ReadOnly = check;
            txtSoL.ReadOnly = check;
            txtSoLuongTon.ReadOnly = check;
            DGV2.ReadOnly = check;
        }
        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            source1.MoveFirst();
            ShowRecord();
            Load_DGV();

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            source1.MovePrevious();
            ShowRecord();
            Load_DGV();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            source1.MoveNext();
            ShowRecord();
            Load_DGV();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = true;
            btnMoveLast.Enabled = true;
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            source1.MoveLast();
            ShowRecord();
            Load_DGV();
            btnMoveFirst.Enabled = true;
            btnMovePrevious.Enabled = true;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;


        }
        #endregion
        #region Tool 3->12
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            //mở khóa chức năng
            btnAction.Show();
            btnClose.Show();

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;

            //mở lock
            TrueLock_FalseUnLock_TextBox(true);
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            f1ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            DateTime dr = DateTime.Now;
            txtNgayThiCong.Text = dr.ToString("yyyy/MM/dd");

            btnAction.Show();
            btnClose.Show();

            btnMoveFirst.Enabled = false;
            btnMovePrevious.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMoveLast.Enabled = false;

            //lấy cb tiền
            GetMoneyt();
            //mở lock
            TrueLock_FalseUnLock_TextBox(false);
            cbTienTe.Enabled = true;

        }
        void GetMoneyt()
        {
            string SQL = "SELECT DISTINCT M_NAME FROM MONEYT";
            DataTable dt = con.readdata(SQL);
            foreach (DataRow dr in dt.Rows)
            {
                cbTienTe.Items.Add(dr["M_NAME"].ToString());
            }
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frm2CF5 fm = new frm2CF5();
                fm.ShowDialog();
                Load_Data();
                source1.Position = frm2CF5.DL.Index;
                ShowRecord();
                Load_DGV();
                
               
        }
        public class F2c
        {
            public static string MaKH;
            public static string sodonhang;
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F2c.MaKH = txtMaKH.Text;
            f1ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = true;
            f7ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            frm2CF6 fm = new frm2CF6();
            fm.ShowDialog();
            ADD();
            TOTAL_A();
            loadTab2(0);
            //this.DGV1.Columns["REMARKS"].Visible = true;
        }

        public void ADD()
        {
            try
            {
                int NR = 1;
                foreach (var item in frm2CF6.LV)
                {
                    string AA = NR.ToString("D" + 3);

                    string SQL1 = "SELECT '" + AA + "' as NR,OR_NO,COLOR_C,COLOR_E AS COLOR,P_NAME_C AS P_NAME,THICK AS P_NAME3,QTY,'' MEMO,'' as OR_NO_C,0 AS PCS, 0 AS BQTY,0 AS QPCS, NR AS OR_NR,PRICE,TOTAL AS AMOUNT,PATT_C AS P_NAME2, P_NO,C_NO," +
                        "'' AS C_OR_NO,'' AS MK_NO1,'' AS GB_NO,'' AS GB_NR,REMARKS " +
                        " FROM dbo.ORDB WHERE OR_NO = '" + item.OR_NO + "' AND NR= '" + item.NR + "' AND K_NO = '" + item.K_NO + "' ";
                    DataTable dt2 = con.readdata(SQL1);
                    if (dt2 != null)
                    {
                        var RW = dt2.AsEnumerable().Where(myRow => myRow.Field<string>("REMARKS").Equals("不計價")).Select(x => x.Field<string>("REMARKS")).SingleOrDefault();
                        if (RW == "不計價")
                        {
                            txtTaiLieu.Text = "贈送";
                        }
                        if (dt2.Rows.Count > 0)
                        {
                            var dt = (DataTable)DGV1.DataSource;
                            int NR1 = 1;
                            foreach (DataRow dr in dt2.Rows)
                            {
                                NR1 = NR1 + DGV1.Rows.Count;
                                string AAA = NR1.ToString("D" + 3);
                                DataRow drToAdd = dt.NewRow();
                                drToAdd["NR"] = dr["NR"].ToString();
                                drToAdd["OR_NO"] = dr["OR_NO"].ToString();
                                drToAdd["COLOR_C"] = dr["COLOR_C"].ToString();
                                drToAdd["P_NAME"] = dr["P_NAME"].ToString();
                                drToAdd["COLOR"] = dr["COLOR"].ToString();
                                drToAdd["P_NAME3"] = dr["P_NAME3"].ToString();
                                drToAdd["BQTY"] = dr["BQTY"].ToString();
                                drToAdd["PRICE"] = dr["PRICE"].ToString();
                                drToAdd["AMOUNT"] = dr["AMOUNT"].ToString();
                                drToAdd["MEMO"] = dr["MEMO"].ToString();
                                drToAdd["PCS"] = dr["PCS"].ToString();
                                drToAdd["QTY"] = dr["QTY"].ToString();
                                drToAdd["QPCS"] = dr["QPCS"].ToString();
                                drToAdd["OR_NR"] = dr["OR_NR"].ToString();
                                drToAdd["P_NO"] = dr["P_NO"].ToString();
                                drToAdd["P_NAME2"] = dr["P_NAME2"].ToString();
                                drToAdd["CAL_YM"] = getDataCust(dr["C_NO"].ToString());
                                drToAdd["C_OR_NO"] = dr["C_OR_NO"].ToString();
                                drToAdd["MK_NO1"] = dr["MK_NO1"].ToString();
                                drToAdd["GB_NO"] = dr["GB_NO"].ToString();
                                drToAdd["GB_NR"] = dr["GB_NR"].ToString();
                                dt.Rows.Add(drToAdd);
                                dt.AcceptChanges();
                                NR1++;
                            }
                        }
                    }
                    NR++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private string getDataCust(string keyMaKH)
        {
            string key = "";
            if (!string.IsNullOrEmpty(txtNgayGiao.Text) && txtNgayGiao.MaskFull == true)
            {
                string ST = "SELECT TOP 1 CASE WHEN DAY('" + con.formatstr2(txtNgayGiao.Text) + "') > RCV_DATE AND ISNULL(RCV_DATE,'') <> '' THEN CAST(DATEADD(MONTH,1,'" + con.formatstr2(txtNgayGiao.Text) + "') AS DATE)" +
                    " ELSE '" + con.formatstr2(txtNgayGiao.Text) + "' END AS RCV_DATE, C_NO,C_NAME2 FROM dbo.CUST WHERE C_NO = '" + keyMaKH + "'";
                DataTable dt = con.readdata(ST);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime date = DateTime.Parse(dr["RCV_DATE"].ToString());
                    if (date.Month <= 9)
                    {
                        key = date.Year.ToString() + "0" + date.Month.ToString();
                    }
                    else
                    {
                        key = date.Year.ToString() + date.Month.ToString();
                    }
                }
            }
            return key;

        }
        public void TOTAL_A()
        {
            float A = 0;
            if (DGV1.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    A += float.Parse(item.Cells["AMOUNT"].Value.ToString());
                }
                TOT.Text = A.ToString("#,##0.00");
                TOTAL.Text = A.ToString("#,##0.00");
            }
            else
            {
                TOT.Text = "0";
                TOTAL.Text = "0";
            }
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                if (txtMaKH.Text != string.Empty)
                {
                    string ST2 = "select C_NO, C_NAME2, ADR3,(SELECT TOP 1 M_NAME FROM dbo.MONEYT WHERE M_NO = CUST.DEFA_MONEY) AS DEFA_MONEY from CUST where C_NO = '" + txtMaKH.Text + "'";
                    DataTable dt3 = con.readdata(ST2);
                    foreach (DataRow dr in dt3.Rows)
                    {
                        txtTenKH.Text = dr["C_NAME2"].ToString();
                        txtDiaChi.Text = dr["ADR3"].ToString();
                        cbTienTe.Text = dr["DEFA_MONEY"].ToString();
                    }
                }
                if (!string.IsNullOrEmpty(txtNgayGiao.Text) && txtNgayGiao.MaskFull == true)
                {
                   txtCAL_YM.Text = getDataCust(txtMaKH.Text);
                   if (DGV1.Rows.Count > 0)
                   {
                       for (int i = 0; i < DGV1.Rows.Count; i++)
                       {
                           DGV1.Rows[i].Cells["CAL_YM"].Value = getDataCust(txtMaKH.Text);
                       }
                   }
                }    
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LoadFirst();
            Load_Data();
            ShowRecord();
            Load_DGV();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAction.PerformClick();
        }

        #endregion
        string keySearch = "";
        string NgayThiCong = "";
        string NgayGiao = "";
        string ThangThanhToan = "";
        private void btnAction_Click(object sender, EventArgs e)
        {
            check();
            NgayThiCong = con.formatstr2(a);
            NgayGiao = con.formatstr2(b);
            ThangThanhToan = con.formatstr2(c);
            if (f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                Repairing();
                Load_Data();
                source1.Find("WS_NO", txtLoHang.Text);
                ShowRecord();
                Load_DGV();
                LoadFirst();
                f4ToolStripMenuItem.Checked = false;
                f6ToolStripMenuItem.Checked = false;
            }
            if (f11ToolStripMenuItem.Checked == true)
            {
                string sql = "UPDATE CARH SET OR_NO = '" + txtTaiLieu.Text + "',USR_NAME = N'" + lbUserName.Text + "' FROM CARH WHERE WS_NO = '" + txtLoHang.Text + "'";
                con.exedata(sql);

                //string sql = "UPDATE CARH SET OR_NO = '" + txtTaiLieu.Text + "',USR_NAME = N'" + lbUserName.Text + "' FROM CARH WHERE WS_NO = '" + txtLoHang.Text + "'";
                //con.exedata(sql);

                Load_Data();
                Load_DGV();
                ShowRecord();
                LoadFirst();
                f11ToolStripMenuItem.Checked = false;

            }
            if (f3ToolStripMenuItem.Checked == true)
            {
                string sql = "DELETE FROM CARH WHERE WS_NO = '" + txtLoHang.Text + "'";
                bool a = con.exedata(sql);
                if (a == true)
                {
                    DELETE_DGV();
                    LoadFirst();
                    Load_Data();
                    ShowRecord();
                    Load_DGV();
                    f3ToolStripMenuItem.Checked = false;
                }
            }
        }
        private string ReturnMoneyCombobox(string key)
        {

            string sql = "SELECT DISTINCT M_NO FROM MONEYT WHERE M_NAME = '" + keySearch + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            foreach (DataRow item in data.Rows)
            {
                key = item["M_NO"].ToString();
            }
            return key;
        }
        public void Repairing()
        {
            try
            {
                string money = "";
                string SQL = "UPDATE CARH SET WS_NO = '" + txtLoHang.Text + "',WS_DATE = '" + NgayGiao + "',C_NO = '" + txtMaKH.Text + "',C_NAME = '" + txtTenKH.Text + "',C_ANAME = SUBSTRING('" + txtTenKH.Text + "',1,8),ADDR = N'" + txtDiaChi.Text + "',OR_NO = '" + txtTaiLieu.Text + "',C_OR_NO = '',C_NO_O = '" + txtMaKH.Text + "',C_NAME_O = '" + txtTenKH.Text + "'," +
                    "C_ANAME_O = SUBSTRING('" + txtTenKH.Text + "',1,8),ADDR_O = '" + txtDiaChi.Text + "',TAX = 0,DISCOUNT = 0,RCV_MON = 0,INV_NO = '',AC_WS_NO = '',MEMO1 = '" + MEMO1.Text + "',MEMO2 = '" + MEMO2.Text + "',MEMO3 = '" + MEMO3.Text + "',MEMO4 = '" + MEMO4.Text + "'," +
                    "MEMO5 = '" + MEMO5.Text + "',MEMO6 = '" + MEMO6.Text + "',MEMO7 = '" + MEMO7.Text + "',MEMO8 = '" + MEMO8.Text + "',S_NO = '',S_NAME = '',TOT = ROUND('" + TOT.Text + "',2),TOTAL = ROUND('" + TOTAL.Text + "',2),NRCV_MON = ROUND('" + TOTAL.Text + "',2),DATESE = '',T_METH = '',CAR_COMPANY = ''," +
                    "COSTTOT = 0,PACK_NO = 0,CAL_YM = '" + ThangThanhToan + "',M_TRAN = '" + ReturnMoneyCombobox(money) + "',M_TRAN_R = " + HANG_SO + ",USR_NAME = '" + lbUserName.Text + "',OVER0 = '" + OVER0.Text + "',WS_DATE1 = '" + NgayThiCong + "' FROM CARH WHERE WS_NO = '" + txtLoHang.Text + "' ";
                bool Repair = con.exedata(SQL);
                if (Repair == true)
                {
                    DataTable data = new DataTable();
                    string sql = "SELECT TOP 1 WS_NO FROM CARB WHERE WS_NO = '" + txtLoHang.Text + "'";
                    data = con.readdata(sql);
                    if (data.Rows.Count > 0)
                    {
                        DELETE_DGV();
                        Insert_DGV();
                    }
                    else
                    {
                        Insert_DGV();
                    }
                    UPDATE_QTY_OUT_ORDB();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void DELETE_DGV()
        {
            try
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    string sql = "DELETE FROM CARB WHERE WS_NO='" + txtLoHang.Text + "' AND NR = '" + item.Cells["NR"].Value.ToString() + "'";
                    bool a = con.exedata(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Insert_DGV()
        {
            try
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    string st2 = "insert into dbo.CARB(WS_NO,NR,WS_DATE,C_NO,OR_NO,OR_NR,P_NO,P_NAME,P_NAME1,P_NAME2,P_NAME3,UNIT,BUNIT,QTY,TRANS,CUNIT,BQTY,PRICE,AMOUNT,COST,MEMO,SH_NO,FOB_DATE,C_OR_NO,COLOR,COLOR_C,CAL_YM,K_NO,ORD_DATE,WS_DATE1,WS_ORNO,MK_NO1,QPCS,PCS,GB_NO,GB_NR)" +
                                            " SELECT '" + txtLoHang.Text + "','" + item.Cells["NR"].Value.ToString() + "','" + NgayGiao + "','" + txtMaKH.Text + "','" + item.Cells["OR_NO"].Value.ToString() + "','" + item.Cells["OR_NR"].Value.ToString() + "','" + item.Cells["P_NO"].Value.ToString() + "'," +
                                            "N'" + item.Cells["P_NAME"].Value.ToString() + "',P_NAME_E,N'" + item.Cells["P_NAME2"].Value.ToString() + "',N'" + item.Cells["P_NAME3"].Value.ToString() + "',(SELECT UNIT FROM PROD WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "')," +
                                            "(SELECT BUNIT FROM PROD WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "')" +
                                            ",ROUND('" + item.Cells["BQTY"].Value.ToString() + "',2),(SELECT TRANS FROM PROD WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "'),(SELECT CUNIT FROM PROD WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "'),ROUND('" + item.Cells["QTY"].Value.ToString() + "',2)," +
                                            "'" + item.Cells["PRICE"].Value.ToString() + "',ROUND('" + item.Cells["AMOUNT"].Value.ToString() + "',2),(SELECT COST FROM PROD WHERE P_NO ='" + item.Cells["P_NO"].Value.ToString() + "'),'" + item.Cells["MEMO"].Value.ToString() + "','A',N'','" + item.Cells["C_OR_NO"].Value.ToString() + "'," +
                                            "'" + item.Cells["COLOR"].Value.ToString() + "','" + item.Cells["COLOR_C"].Value.ToString() + "','" + item.Cells["CAL_YM"].Value.ToString() + "',K_NO,ORDB.WS_DATE,'" + NgayThiCong + "',WS_RNO,'" + item.Cells["MK_NO1"].Value.ToString() + "'" +
                                            ",'" + item.Cells["QPCS"].Value.ToString() + "','" + item.Cells["PCS"].Value.ToString() + "','" + item.Cells["GB_NO"].Value.ToString() + "','" + item.Cells["GB_NR"].Value.ToString() + "' FROM ORDB WHERE OR_NO = '" + item.Cells["OR_NO"].Value.ToString() + "' " +
                                            "AND NR = '" + item.Cells["OR_NR"].Value.ToString() + "'";
                    bool a = con.exedata(st2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UPDATE_QTY_OUT_ORDB()
        {
            try
            {
                string OR_NO = "";
                string OR_NR = "";
                string K_NO = "";
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    OR_NO = item.Cells["OR_NO"].Value.ToString();
                    OR_NR = item.Cells["OR_NR"].Value.ToString();
                    string STT = "select WS_NO, OR_NO, OR_NR, K_NO,BQTY FROM CARB WHERE OR_NO = '" + OR_NO + "' AND OR_NR = '" + OR_NR + "'";
                    DataTable dt = con.readdata(STT);
                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check Y : Update khi Số lượng đặt - số lượng xuất <= 10 
                        K_NO = dr["K_NO"].ToString();
                        string STT2 = "update dbo.ORDB set dbo.ORDB.QTY_OUT = CASE WHEN QTY < (SELECT SUM(BQTY) FROM CARB WHERE CARB.OR_NO = '" + OR_NO + "' AND OR_NR= '" + OR_NR + "' AND CARB.K_NO = '" + K_NO + "') " +
                            "THEN ORDB.QTY ELSE (SELECT SUM(BQTY) FROM CARB WHERE CARB.OR_NO = '" + OR_NO + "' AND OR_NR= '" + OR_NR + "' AND CARB.K_NO = '" + K_NO + "') END, " +
                            " ORDB.OVER0 = CASE WHEN ORDB.QTY - (SELECT SUM(BQTY) FROM CARB WHERE CARB.OR_NO = '" + OR_NO + "' AND OR_NR = '" + OR_NR + "' AND CARB.K_NO = '" + K_NO + "') <= 10 THEN 'Y' ELSE 'N' END " +
                            " FROM dbo.ORDB WHERE OR_NO = '" + OR_NO + "' AND NR = '" + OR_NR + "' AND ORDB.K_NO = '" + K_NO + "'";
                        con.exedata(STT2);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNgayGiao.Text) && txtNgayGiao.MaskFull == true)
            {
                F2c.sodonhang = txtLoHang.Text;
                //frm2CF7_Old fm = new frm2CF7_Old();
                WSEXE.Module2._2C.Frm2CF7_Print fm = new WSEXE.Module2._2C.Frm2CF7_Print();
                fm.txtWS_NO_S.Text = txtLoHang.Text;
                fm.txtWS_NO_E.Text = txtLoHang.Text;
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ngày chưa được nhập !! Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void txtMaKH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
                {

                    frm2CustSearch fm = new frm2CustSearch();
                    fm.ShowDialog();

                    string DL = frm2CustSearch.ID.ID_CUST;
                    if (DL != string.Empty)
                    {
                        txtMaKH.Text = frm2CustSearch.ID.ID_CUST;
                    }
                    else
                        txtMaKH.Text = "";

                }
            }
            catch { }
        }

        private void txtNgayThiCong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtNgayThiCong.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }

        private void txtNgayGiao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtNgayGiao.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }

        private void MEMO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO1.Text = DL;
                }
                else
                    MEMO1.Text = "";
            }
        }
        private void MEMO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO2.Text = DL;
                }
                else
                    MEMO2.Text = "";
            }
        }

        private void MEMO3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO3.Text = DL;
                }
                else
                    MEMO3.Text = "";
            }
        }

        private void MEMO4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO4.Text = DL;
                }
                else
                    MEMO4.Text = "";
            }
        }

        private void MEMO5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO5.Text = DL;
                }
                else
                    MEMO5.Text = "";
            }
        }

        private void MEMO7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO7.Text = DL;
                }
                else
                    MEMO7.Text = "";
            }
        }

        private void MEMO8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();

                string DL = FormSearchLeather2.ID.M_NAME;
                if (DL != string.Empty)
                {
                    MEMO8.Text = DL;
                }
                else
                    MEMO8.Text = "";
            }
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDown.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Right)
            {
                txtUp.Focus();
                txtUp.SelectAll();
            }
            if (e.KeyCode == Keys.Left)
            {
                txtDown.Focus();
                txtUp.SelectAll();
            }
        }

        private void txtNgayThiCong_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtCAL_YM, txtNgayGiao, sender, e);
        }

        private void txtNgayGiao_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtNgayThiCong, txtLoHang, sender, e);
        }

        private void txtLoHang_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtNgayGiao, txtTaiLieu, sender, e);
        }

        private void txtTaiLieu_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtLoHang, txtMaKH, sender, e);
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTaiLieu, txtTenKH, sender, e);
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMaKH, txtDiaChi, sender, e);
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTenKH, TOT, sender, e);
        }

        private void TOT_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtDiaChi, TOTAL, sender, e);
        }

        private void TOTAL_KeyDown(object sender, KeyEventArgs e)
        {
            tab(TOT, OVER0, sender, e);
        }

        private void OVER0_KeyDown(object sender, KeyEventArgs e)
        {
            tab(TOTAL, MEMO1, sender, e);
        }

        private void MEMO1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(OVER0, MEMO2, sender, e);
        }

        private void MEMO2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO1, MEMO3, sender, e);
        }

        private void MEMO3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO2, MEMO4, sender, e);
        }

        private void MEMO4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO3, MEMO5, sender, e);
        }

        private void MEMO5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO4, MEMO6, sender, e);
        }

        private void MEMO6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO5, MEMO7, sender, e);
        }

        private void MEMO7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(MEMO6, MEMO8, sender, e);
        }

        private void MEMO8_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(MEMO7, txtCAL_YM, sender, e);
        }

        private void CAL_YM_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(MEMO8, txtNgayThiCong, sender, e);
        }

        private void xóaXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
            {
                this.DGV1.Rows.RemoveAt(this.rowIndex);
            }
        }
        private int rowIndex = 0;
        private void DGV1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.DGV1.Rows[e.RowIndex].Selected = true;
                rowIndex = e.RowIndex;
                this.DGV1.CurrentCell = this.DGV1.Rows[e.RowIndex].Cells[1];
            }
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.DGV1.Rows[this.rowIndex].IsNewRow)
            {
                this.DGV1.Rows.Add("", "", "", "", "", "0", "0.00", "0.00", "", "", "", " ", "", "", "0");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbTienTe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTienTe.Text != null)
            {
                keySearch = cbTienTe.SelectedItem.ToString();
            }
        }
        private void f11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTaiLieu.Text = "作廢";
            TrueLock_FalseUnLock_TextBox(true);
            f11ToolStripMenuItem.Checked = true;
            btnAction.Show();
            btnClose.Show();
        }

        private void txtTaiLieu_DoubleClick(object sender, EventArgs e)
        {
            if (f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchLeather2 frmSearchMemo1 = new FormSearchLeather2();
                frmSearchMemo1.ShowDialog();
                txtTaiLieu.Text = FormSearchLeather2.ID.M_NAME;
            }

        }
        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenuStrip menu = new ContextMenuStrip();
                        int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                       
                        menu.Items.Add("Delete").Name = "Delete";

                        menu.Show(DGV1, new Point(e.X, e.Y));
                        menu.ItemClicked += Menu_ItemClicked;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Delete":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            if (DGV1.Rows.Count > 0)
                            {
                                DGV1.CurrentRow.Selected = true;
                                loadTab2(DGV1.CurrentRow.Index);
                            }   
                            else
                            {
                                loadTab2(0);
                            }
                            TOTAL_A();

                        }
                    }
                    break;
            }
        }
        private void txtNgayThiCong_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            con.tab_DOWN(txtDiaChi, txtNgayGiao, sender, e);
        }

        private void txtNgayGiao_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                con.tab_UP(txtNgayThiCong, txtLoHang, sender, e);
        }

        private void txtCAL_YM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                txtCAL_YM.Text = FromCalender.getDate.ToString("yyyy/MM");
            }
        }
        private void txtNgayGiao_TextChanged(object sender, EventArgs e)
        {
          if (!string.IsNullOrEmpty(txtNgayGiao.Text) && txtNgayGiao.MaskFull == true && !string.IsNullOrEmpty(txtMaKH.Text))
          {
              txtCAL_YM.Text = getDataCust(txtMaKH.Text);
              if (DGV1.Rows.Count > 0)
              {
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        DGV1.Rows[i].Cells["CAL_YM"].Value = getDataCust(txtMaKH.Text);
                    }
              }    
          }
        }
        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 13)
            {

                if ((f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
                {
                    float AMOUT = 0;
                    if (DGV1.Rows.Count > 0)
                    {
                        AMOUT = float.Parse(DGV1.CurrentRow.Cells["QTY"].Value.ToString()) * float.Parse(DGV1.CurrentRow.Cells["PRICE"].Value.ToString());
                        DGV1.CurrentRow.Cells["AMOUNT"].Value = Math.Round(AMOUT, 3).ToString();
                        TOTAL_A();
                    }
                }
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                f4ToolStripMenuItem.PerformClick();
            }    
            if (e.KeyCode == Keys.F6)
            {
                f6ToolStripMenuItem.PerformClick();
            }    
        }
    }

}

