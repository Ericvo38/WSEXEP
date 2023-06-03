using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using LibraryCalender;

namespace WTERP
{
    public partial class Form2AB : Form
    {
        int pageIndex = 0;
        int PageSize = 300;
        DataProvider conn = new DataProvider();
        public Form2AB()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
            this.dataGridViewdonhang.MouseWheel += new MouseEventHandler(mousewheel);
        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            conn.Mousewheelscroll(dataGridViewdonhang, e);
            BindingData(conn.RowIndexs);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                f5ToolStripMenuItem.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public DataTable tbc = new DataTable();
        SqlConnection con;
        string st = CN.str;
        public BindingSource bindingsource;
        public DataTable datatable = new DataTable();
        string a = "";
        string c = "";
        string d = "";

        #region Loaddata
        void check()
        {
            if (conn.Check_MaskedText(tb2) == true)
            {
                a = tb2.Text;
            }
            if (conn.Check_MaskedText(tb30) == true)
            {
                c = tb30.Text;
            }
            if (conn.Check_MaskedText(tb33) == true)
            {
                d = tb33.Text;
            }
        }
        private void Formdonhang_Load(object sender, EventArgs e)
        {
            getInfo();
            if (frmWSEXE.ID_FORM.STR == "F1")
            {
                Loadfirst2A();
            }
            else if (frmWSEXE.ID_FORM.STR == "F2")
            {
                //con = new SqlConnection(st);

                conn.CheckPriceLock("Form2AB", tb24);
                Loadfirst2B();
            }
            LoadDataGriView();
            BindingData(-1);
            Color_Data();
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            //IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            //foreach (IPAddress address in localIP)  // get IP Local  
            //{
            //    if (address.AddressFamily == AddressFamily.InterNetwork)
            //        //lbIP.Text = address.ToString();
            //}
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = conn.getUser(UID);// get UserName 
            //lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        public void LoadDataGriView() // Load datagridview 
        {
            if (f5ToolStripMenuItem.Checked == true)
            {
                //LoadSearch();
                pageIndex = 0;
                load();
                if (checknew == 0)
                {
                    pageIndex = 1;
                }
                Color_Data();
            }
            else
            {
                load();
                pageIndex = 1;
                Color_Data();
            }
        }
        int checknew = 0;
        public void load()
        {
            DataTable ds = new DataTable();

            string SQL = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC) AS ROWID, tbl_Type_New.K_NO," + CheckNgonNgu() + " as K_NAME, ORDB.WS_DATE, ORDB.NR, ORDB.OR_NO, ORDB.C_NO, ORDB.C_NAME_C," +
                    " ORDB.C_NAME_E, ORDB.B_NO,ORDB.BRAND, ORDB.T_NAME, ORDB.MODEL_C, ORDB.MODEL_E, ORDB.P_NO, ORDB.P_NAME_C, ORDB.P_NAME_E, ORDB.COLOR_C, " +
                    "ORDB.COLOR_E,ORDB.PATT_E, ORDB.PATT_C, ORDB.THICK, ORDB.QTY, ORDB.CURRENCY, ORDB.CLRCARD, ORDB.PRICE, ORDB.PER_S, ORDB.GRADE, ORDB.ACCOUNT, " +
                    "ORDB.ACHI,SUBSTRING(ORDB.WS_DATE1,3,6) as WS_DATE1,SUBSTRING(ORDB.SCHEDULE2,3,6) as SCHEDULE2,ORDB.WS_DATE3, ORDB.TOTAL, ORDB.WS_DATE_F, ORDB.PURCHASER, ORDB.ORD_WEG, ORDB.DEVSTAGE,ORDB.MK_PLACE, ORDB.SER_NO, " +
                    "ORDB.COMPOUNTS, ORDB.DESIGER, ORDB.RV_PLACE, ORDB.SEASON, ORDB.SALES, ORDB.REMARKS, ORDB.QTY_OUT, ORDB.OVER0, ORDB.ONOS,ORDB.USR_NAME " +
                    "FROM ORDB INNER JOIN tbl_Type_New ON ORDB.K_NO = tbl_Type_New.K_NO where 1=1 " + Form2ABF5.where + ") ORDB where 1=1 AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);
            ds = conn.readdata(SQL);

            foreach (DataRow dr in ds.Rows)
            {
                dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
                dr["WS_DATE_F"] = conn.formatstr1(dr["WS_DATE_F"].ToString());
                dr["WS_DATE1"] = conn.formatstr1(dr["WS_DATE1"].ToString());
                dr["SCHEDULE2"] = conn.formatstr1(dr["SCHEDULE2"].ToString());
            }
            if (checknew == 0)
            {
                bindingsource = new BindingSource();
                datatable = ds;
                pageIndex++;
            }
            else
            {
                datatable.Merge(ds);
                pageIndex++;
            }
            bindingsource.DataSource = datatable;
            conn.FormatDGVbindingsource(dataGridViewdonhang, bindingsource);

            if ((Form2ABF5.index >= bindingsource.Count || Form2ABF5.index == (bindingsource.Count - 2) || Form2ABF5.index == (bindingsource.Count - 1)) && ds.Rows.Count > 0)
            {
                checknew = 1;
                load();
            }
            else
            {
                checknew = 0;
            }

            dataGridViewdonhang.CurrentCell = dataGridViewdonhang[dataGridViewdonhang.CurrentCell.ColumnIndex, Form2ABF5.index];
            BindingData(Form2ABF5.index);
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
        //void LoadSearch()
        //{
        //    //datatable = Form2ABF5.getInfo.da;
        //    bindingsource = Form2ABF5.getInfo.da1;
        //    if (datatable != null)
        //    {
        //        conn.FormatDGVbindingsource(dataGridViewdonhang, bindingsource);
        //        string searchValue = tb4.Text;
        //        string searchNR = tb3.Text;
        //        int rowIndex = 0;

        //        dataGridViewdonhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //        try
        //        {
        //            foreach (DataGridViewRow row in dataGridViewdonhang.Rows)
        //            {
        //                if (row.Cells["OR_NO"].Value.ToString().Equals(searchValue) && row.Cells["NR"].Value.ToString().Equals(searchNR))
        //                {
        //                    rowIndex = row.Index;
        //                    //MessageBox.Show(rowIndex.ToString());
        //                    dataGridViewdonhang.Rows[rowIndex].Selected = true;
        //                    dataGridViewdonhang.CurrentCell = dataGridViewdonhang.Rows[rowIndex].Cells["K_NAME"];
        //                    break;
        //                }
        //            }
        //        }
        //        catch (Exception exc)
        //        {
        //            MessageBox.Show(exc.Message);
        //        }
        //        BindingData(-1);
        //        Color_Data();
        //    }
        //}
        void LoadSearch3(DataTable datatable)
        {
            if (datatable != null)
            {
                bindingsource.DataSource = datatable;
                conn.FormatDGVbindingsource(dataGridViewdonhang, bindingsource);
                string searchValue = tb4.Text;
                string searchNR = tb3.Text;
                int rowIndex = 0;

                dataGridViewdonhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dataGridViewdonhang.Rows)
                    {
                        if (row.Cells["OR_NO"].Value.ToString().Equals(searchValue) && row.Cells["NR"].Value.ToString().Equals(searchNR))
                        {
                            rowIndex = row.Index;
                            //MessageBox.Show(rowIndex.ToString());
                            dataGridViewdonhang.Rows[rowIndex].Selected = true;
                            dataGridViewdonhang.CurrentCell = dataGridViewdonhang.Rows[rowIndex].Cells["K_NAME"];
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                //f5ToolStripMenuItem.Checked = false;
                //conn.FormatDGV(dataGridViewdonhang, dt1);
                BindingData(-1);
                Color_Data();
            }
        }
        public void Color_Data() // Loading Color DataGridView 
        {
            foreach (DataGridViewRow row in dataGridViewdonhang.Rows)
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
        void Loadfirst2A() // The First Loading  Form 2A 
        {
            checkNofication();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btok.Hide();
            btdong.Hide();
            bt.Text = "" + txtDuyet + "";
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        void Loadfirst2B()  // The First Loading  Form 2B 
        {
            conn.CheckLoad(menuStrip1);
            checkNofication();
            Hover_Combobox();
            btok.Hide();
            btdong.Hide();
            bt.Text = "" + txtDuyet + "";
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        public void BindingData(int index)
        {
            if (index == -1)
            {
                index = dataGridViewdonhang.CurrentRow.Index;
            }
            this.tb1.Text = dataGridViewdonhang.Rows[index].Cells["K_NO"].Value.ToString();
            this.tb2.Text = dataGridViewdonhang.Rows[index].Cells["WS_DATE"].Value.ToString();
            this.tb3.Text = dataGridViewdonhang.Rows[index].Cells["NR"].Value.ToString();
            this.tb4.Text = dataGridViewdonhang.Rows[index].Cells["OR_NO"].Value.ToString();
            this.tb5.Text = dataGridViewdonhang.Rows[index].Cells["C_NO"].Value.ToString();

            this.tb6.Text = dataGridViewdonhang.Rows[index].Cells["C_NAME_C"].Value.ToString();
            this.tb7.Text = dataGridViewdonhang.Rows[index].Cells["C_NAME_E"].Value.ToString();
            this.tb8.Text = dataGridViewdonhang.Rows[index].Cells["B_NO"].Value.ToString();
            this.tb9.Text = dataGridViewdonhang.Rows[index].Cells["BRAND"].Value.ToString();
            this.tb10.Text = dataGridViewdonhang.Rows[index].Cells["T_NAME"].Value.ToString();

            this.tb11.Text = dataGridViewdonhang.Rows[index].Cells["MODEL_C"].Value.ToString();
            this.tb12.Text = dataGridViewdonhang.Rows[index].Cells["MODEL_E"].Value.ToString();
            this.tb13.Text = dataGridViewdonhang.Rows[index].Cells["P_NO"].Value.ToString();
            this.tb14.Text = dataGridViewdonhang.Rows[index].Cells["P_NAME_C"].Value.ToString();
            this.tb15.Text = dataGridViewdonhang.Rows[index].Cells["P_NAME_E"].Value.ToString();

            this.tb16.Text = dataGridViewdonhang.Rows[index].Cells["COLOR_C"].Value.ToString();
            this.tb17.Text = dataGridViewdonhang.Rows[index].Cells["COLOR_E"].Value.ToString();
            this.tb18.Text = dataGridViewdonhang.Rows[index].Cells["PATT_E"].Value.ToString();
            this.tb19.Text = dataGridViewdonhang.Rows[index].Cells["PATT_C"].Value.ToString();
            this.tb20.Text = dataGridViewdonhang.Rows[index].Cells["THICK"].Value.ToString();

            this.tb21.Text = string.Format("{0:0.00}", double.Parse(dataGridViewdonhang.Rows[index].Cells["QTY"].Value.ToString()));

            this.tb22.Text = dataGridViewdonhang.Rows[index].Cells["CURRENCY"].Value.ToString();
            this.tb23.Text = dataGridViewdonhang.Rows[index].Cells["CLRCARD"].Value.ToString();

            this.tb24.Text = string.Format("{0:0.00}", double.Parse(dataGridViewdonhang.Rows[index].Cells["PRICE"].Value.ToString()));

            this.tb25.Text = dataGridViewdonhang.Rows[index].Cells["PER_S"].Value.ToString();
            this.tb26.Text = dataGridViewdonhang.Rows[index].Cells["GRADE"].Value.ToString();
            this.tb27.Text = dataGridViewdonhang.Rows[index].Cells["ACCOUNT"].Value.ToString();
            this.tb28.Text = dataGridViewdonhang.Rows[index].Cells["ACHI"].Value.ToString();
            this.tb29.Text = dataGridViewdonhang.Rows[index].Cells["WS_DATE1"].Value.ToString();
            this.tb30.Text = dataGridViewdonhang.Rows[index].Cells["SCHEDULE2"].Value.ToString();
            this.tb31.Text = dataGridViewdonhang.Rows[index].Cells["WS_DATE3"].Value.ToString();

            this.tb32.Text = tb32.Text = string.Format("{0:0.00}", double.Parse(dataGridViewdonhang.Rows[dataGridViewdonhang.CurrentRow.Index].Cells["TOTAL"].Value.ToString()));

            this.tb33.Text = conn.formatstr1(dataGridViewdonhang.Rows[index].Cells["WS_DATE_F"].Value.ToString());
            this.tb34.Text = dataGridViewdonhang.Rows[index].Cells["PURCHASER"].Value.ToString();
            this.tb35.Text = dataGridViewdonhang.Rows[index].Cells["ORD_WEG"].Value.ToString();

            this.tb36.Text = dataGridViewdonhang.Rows[index].Cells["DEVSTAGE"].Value.ToString();
            this.tb37.Text = dataGridViewdonhang.Rows[index].Cells["MK_PLACE"].Value.ToString();
            this.tb38.Text = dataGridViewdonhang.Rows[index].Cells["SER_NO"].Value.ToString();
            this.tb39.Text = dataGridViewdonhang.Rows[index].Cells["COMPOUNTS"].Value.ToString();
            this.tb40.Text = dataGridViewdonhang.Rows[index].Cells["DESIGER"].Value.ToString();

            this.tb41.Text = dataGridViewdonhang.Rows[index].Cells["RV_PLACE"].Value.ToString();
            this.tb42.Text = dataGridViewdonhang.Rows[index].Cells["SEASON"].Value.ToString();
            this.tb43.Text = dataGridViewdonhang.Rows[index].Cells["SALES"].Value.ToString();
            this.tb44.Text = dataGridViewdonhang.Rows[index].Cells["REMARKS"].Value.ToString();

            this.tb45.Text = string.Format("{0:0.00}", double.Parse(dataGridViewdonhang.Rows[index].Cells["QTY_OUT"].Value.ToString()));

            this.tb46.Text = dataGridViewdonhang.Rows[index].Cells["OVER0"].Value.ToString();
            this.tb47.Text = dataGridViewdonhang.Rows[index].Cells["ONOS"].Value.ToString();
            this.txtUser_Name.Text = dataGridViewdonhang.Rows[index].Cells["USR_NAME"].Value.ToString();


            // this.txtPWT.Text = dataGridViewdonhang.Rows[dataGridViewdonhang.CurrentRow.Index].Cells["ONOS"].Value.ToString();
        }
        private void dataGridViewdonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingData(-1);
        }
        private void btdau_Click(object sender, EventArgs e) // Button MoveFirst 
        {
            dataGridViewdonhang.ClearSelection();
            dataGridViewdonhang.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewdonhang.DataSource = bindingsource;
            bindingsource.MoveFirst();

            BindingData(-1);

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e) //Button MovePrevious
        {
            try
            {
                int IndexNow = dataGridViewdonhang.CurrentRow.Index;
                if (dataGridViewdonhang.Rows.Count > IndexNow)
                {
                    dataGridViewdonhang.Rows[IndexNow - 1].Selected = true;
                }
                bindingsource.DataSource = datatable;
                dataGridViewdonhang.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }
            BindingData(-1);
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btsau_Click(object sender, EventArgs e) //Button MoveNext 
        {
            try
            {
                int IndexNow = dataGridViewdonhang.CurrentRow.Index;
                if (dataGridViewdonhang.Rows.Count > IndexNow)
                {
                    dataGridViewdonhang.Rows[IndexNow + 1].Selected = true;
                }
                bindingsource.DataSource = datatable;
                dataGridViewdonhang.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }
            BindingData(-1);
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void btketthuc_Click(object sender, EventArgs e) //Button MoveLast 
        {
            string str = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC) AS ROWID, tbl_Type_New.K_NO," + CheckNgonNgu() + " as K_NAME, ORDB.WS_DATE, ORDB.NR, ORDB.OR_NO, ORDB.C_NO, ORDB.C_NAME_C," +
                                               " ORDB.C_NAME_E, ORDB.B_NO,ORDB.BRAND, ORDB.T_NAME, ORDB.MODEL_C, ORDB.MODEL_E, ORDB.P_NO, ORDB.P_NAME_C, ORDB.P_NAME_E, ORDB.COLOR_C, " +
                                               "ORDB.COLOR_E,ORDB.PATT_E, ORDB.PATT_C, ORDB.THICK, ORDB.QTY, ORDB.CURRENCY, ORDB.CLRCARD, ORDB.PRICE, ORDB.PER_S, ORDB.GRADE, ORDB.ACCOUNT, " +
                                               "ORDB.ACHI,SUBSTRING(ORDB.WS_DATE1,3,6) as WS_DATE1,SUBSTRING(ORDB.SCHEDULE2,3,6) as SCHEDULE2,ORDB.WS_DATE3, ORDB.TOTAL, ORDB.WS_DATE_F, ORDB.PURCHASER, ORDB.ORD_WEG, ORDB.DEVSTAGE,ORDB.MK_PLACE, ORDB.SER_NO, " +
                                               "ORDB.COMPOUNTS, ORDB.DESIGER, ORDB.RV_PLACE, ORDB.SEASON, ORDB.SALES, ORDB.REMARKS, ORDB.QTY_OUT, ORDB.OVER0, ORDB.ONOS,ORDB.USR_NAME " +
                                               "FROM ORDB INNER JOIN tbl_Type_New ON ORDB.K_NO = tbl_Type_New.K_NO where 1=1 " + Form2ABF5.where + ") ORDB where 1=1 ";
            datatable = conn.readdata(str);

            foreach (DataRow dr in datatable.Rows)
            {
                dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
                dr["WS_DATE_F"] = conn.formatstr1(dr["WS_DATE_F"].ToString());
                dr["WS_DATE1"] = conn.formatstr1(dr["WS_DATE1"].ToString());
                dr["SCHEDULE2"] = conn.formatstr1(dr["SCHEDULE2"].ToString());
            }

            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            conn.FormatDGVbindingsource(dataGridViewdonhang, bindingsource);

            dataGridViewdonhang.ClearSelection();
            int so = dataGridViewdonhang.Rows.Count - 1;
            dataGridViewdonhang.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataGridViewdonhang.DataSource = bindingsource;
            bindingsource.MoveLast();
            BindingData(-1);
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtText = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        //string txtText4 = "";
        //string txtLuuTC = "";
        //string txtHoiXoa = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtXoa = "";
        string txtNodata = "";
        string txtText5 = "";
        //string txtText6 = "";
        string txtText7 = "";
        string txtText8 = "";
        string txtText9 = "";
        string txtText10 = "";
        string txtText11 = "";
        string txtText13 = "";
        //string txtText14 = "";
        string txtText16 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Bạn chưa chọn phân loại hàng";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn chưa nhập số thứ tự?";
                txtText2 = "Bạn chưa nhập Mã đơn hàng ?";
                txtText3 = "Bạn chưa chọn mã Khách Hàng ?";
                //txtText4 = "Đơn hàng :" + tb4.Text + "\n Đã lưu thành công";
                txtText5 = "Đơn hàng :" + tb4.Text + "\nĐã xóa Thành công!";
                //txtText6 = "Không thể xóa đơn hàng này";
                txtText7 = "Bạn chưa nhập số lượng";
                txtText8 = "Bạn chưa nhập đơn giá";
                txtText9 = "Bạn chưa nhập tổng";
                txtText10 = "Bạn chưa nhập trọng lượng";
                txtText11 = "Bạn chưa nhập số lượng giao";
                txtText13 = "Mục Phân loại hoặc Ngày Sai, Vui lòng kiểm tra lại";
                //txtText14 = "Bạn có muốn sửa đơn hàng này không ? ";
                txtText16 = " Mã nhãn hiệu không tổn tại, vui lòng kiểm tra lại";
                //txtLuuTC = "Lưu Thành Công";
                // txtHoiXoa = "Bạn có muốn xóa không?";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Bạn chưa chọn phân loại hàng";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn chưa nhập số thứ tự?";
                txtText2 = "Bạn chưa nhập Mã đơn hàng ?";
                txtText3 = "Bạn chưa chọn mã Khách Hàng ?";
                //txtText4 = "Đơn hàng :" + tb4.Text + "\n Đã lưu thành công";
                txtText5 = "Đơn hàng :" + tb4.Text + "\nĐã xóa Thành công!";
                //txtText6 = "Không thể xóa đơn hàng này";
                txtText7 = "Bạn chưa nhập số lượng";
                txtText8 = "Bạn chưa nhập đơn giá";
                txtText9 = "Bạn chưa nhập tổng";
                txtText10 = "Bạn chưa nhập trọng lượng";
                txtText11 = "Bạn chưa nhập số lượng giao";
                txtText13 = "Mục Phân loại hoặc Ngày Sai, Vui lòng kiểm tra lại";
                //txtText14 = "Bạn có muốn sửa đơn hàng này không ? ";
                txtText16 = " Mã nhãn hiệu không tổn tại, vui lòng kiểm tra lại";
                //txtLuuTC = "Lưu Thành Công";
                // txtHoiXoa = "Bạn có muốn xóa không?";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "You have not selected a product category";
                txtThongBao = "Nofication";
                txtText1 = "You have not entered the order number?";
                txtText2 = "You have not entered your order number?";
                txtText3 = "You have not selected the Customer code?";
                //txtText4 = "Order :" + tb4.Text + "\n Saved successfully";
                txtText5 = "Order :" + tb4.Text + "\n Deleted Successfully!";
                //txtText6 = "This order cannot be deleted";
                txtText7 = "You did not enter a number";
                txtText8 = "You have not entered the unit price";
                txtText9 = "You have not entered the total";
                txtText10 = "You have not entered the weight";
                txtText11 = "You have not entered the delivery quantity";
                txtText13 = "Wrong Category or Date, Please check again";
                //txtText14 = "Do you want to edit this order?";
                txtText16 = "Brand code does not exist, please check again";
                //txtLuuTC = "Save successfully";
                // txtHoiXoa = "You may want to delete?";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "您尚未選擇產品類別";
                txtThongBao = "通知";
                txtText1 = "您還沒有輸入訂單號？";
                txtText2 = "您還沒有輸入您的訂單號？";
                txtText3 = "您還沒有選擇客戶代碼？";
                //txtText4 = "命令 :" + tb4.Text + "\n 保存成功";
                txtText5 = "命令 :" + tb4.Text + "\n 刪除成功！";
                //txtText6 = "此訂單無法刪除";
                txtText7 = "您沒有輸入號碼";
                txtText8 = "您還沒有輸入單價";
                txtText9 = "您尚未輸入總數";
                txtText10 = "您還沒有輸入體重";
                txtText11 = "您尚未輸入交貨數量";
                txtText13 = "錯誤的類別或日期，請再次檢查";
                //txtText14 = "您要編輯此訂單嗎？";
                txtText16 = "品牌代碼不存在，請重新檢查";
                //txtLuuTC = "保存成功";
                //txtHoiXoa = "你可能想刪除？";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }
        }
        #endregion
        #region f1 -> f12
        public void f1ToolStripMenuItem_Click(object sender, EventArgs e) // F1 Checking Data 
        {

        }
        public void setDatagridview()
        {
            BindingSource dataTable = (BindingSource)dataGridViewdonhang.DataSource;
            var dt = (DataTable)dataTable.DataSource;
            DataRow drToAdd = dt.NewRow();
            drToAdd["K_NO"] = tb1.Text;
            drToAdd["K_NAME"] = lbloaihang.Text;
            drToAdd["WS_DATE"] = this.tb2.Text;
            drToAdd["NR"] = this.tb3.Text;
            drToAdd["OR_NO"] = this.tb4.Text;
            drToAdd["C_NO"] = this.tb5.Text;
            drToAdd["C_NAME_C"] = this.tb6.Text;
            drToAdd["C_NAME_E"] = this.tb7.Text;
            drToAdd["B_NO"] = this.tb8.Text;
            drToAdd["BRAND"] = this.tb9.Text;
            drToAdd["T_NAME"] = this.tb10.Text;
            drToAdd["MODEL_C"] = this.tb11.Text;
            drToAdd["MODEL_E"] = this.tb12.Text;
            drToAdd["P_NO"] = this.tb13.Text;
            drToAdd["P_NAME_C"] = this.tb14.Text;
            drToAdd["P_NAME_E"] = this.tb15.Text;
            drToAdd["COLOR_C"] = this.tb16.Text;
            drToAdd["COLOR_E"] = this.tb17.Text;
            drToAdd["PATT_E"] = this.tb18.Text;
            drToAdd["PATT_C"] = this.tb19.Text;
            drToAdd["THICK"] = this.tb20.Text;
            drToAdd["QTY"] = this.tb21.Text;
            drToAdd["CURRENCY"] = this.tb22.Text;
            drToAdd["CLRCARD"] = this.tb23.Text;
            if (tb44.Text == "不計價")
            {
                drToAdd["PRICE"] = 0;
            }
            else
            {
                drToAdd["PRICE"] = this.tb24.Text;
            }
            drToAdd["PER_S"] = this.tb25.Text;
            drToAdd["GRADE"] = this.tb26.Text;
            drToAdd["ACCOUNT"] = this.tb27.Text;
            drToAdd["ACHI"] = this.tb28.Text;
            drToAdd["WS_DATE1"] = this.tb29.Text;
            drToAdd["SCHEDULE2"] = this.tb30.Text;
            drToAdd["WS_DATE3"] = this.tb31.Text;
            drToAdd["TOTAL"] = this.tb32.Text;
            drToAdd["WS_DATE_F"] = this.tb33.Text;
            drToAdd["PURCHASER"] = this.tb34.Text;
            drToAdd["ORD_WEG"] = this.tb35.Text;
            drToAdd["DEVSTAGE"] = this.tb36.Text;
            drToAdd["MK_PLACE"] = this.tb37.Text;
            drToAdd["SER_NO"] = this.tb38.Text;
            drToAdd["COMPOUNTS"] = this.tb39.Text;
            drToAdd["DESIGER"] = this.tb40.Text;
            drToAdd["RV_PLACE"] = this.tb41.Text;
            drToAdd["SEASON"] = this.tb42.Text;
            drToAdd["SALES"] = this.tb43.Text;
            drToAdd["REMARKS"] = this.tb44.Text;
            drToAdd["QTY_OUT"] = this.tb45.Text;
            drToAdd["OVER0"] = this.tb46.Text;
            drToAdd["ONOS"] = this.tb47.Text;
            drToAdd["USR_NAME"] = this.lbUserName.Text;
            dt.Rows.Add(drToAdd);

            dataGridViewdonhang.ClearSelection();
            //dataGridViewdonhang.FirstDisplayedScrollingRowIndex = 0;
            dataGridViewdonhang.Sort(dataGridViewdonhang.Columns["WS_DATE"], ListSortDirection.Descending);
            LoadSearch3(dt);
        }
        public void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Adding Data 
        {
            dataGridViewdonhang.AllowUserToAddRows = false;
            checkNofication();
            //khóa chức năng check
            f1ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Checked = true;

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            bt.Text = "" + txtThem + "";
            btok.Show();
            btdong.Show();

            tb1.Text = "";
            tb2.Text = DateTime.Now.ToString("yy/MM/dd");
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";

            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            tb9.Text = "";
            tb10.Text = "";

            tb11.Text = "";
            tb12.Text = "";
            tb13.Text = "";
            tb14.Text = "";
            tb15.Text = "";

            tb16.Text = "";
            tb17.Text = "";
            tb18.Text = "";
            tb19.Text = "";
            tb20.Text = "";

            tb21.Text = "0";
            tb22.Text = "";
            tb23.Text = "";
            tb24.Text = "0";
            tb25.Text = "";

            tb26.Text = "";
            tb27.Text = "";
            tb28.Text = "";
            tb29.Text = "";
            tb30.Text = "";

            tb31.Text = "";
            tb32.Text = "0";
            tb33.Text = "";
            tb34.Text = "";
            tb35.Text = "0";

            tb36.Text = "";
            tb37.Text = "";
            tb38.Text = "";
            tb39.Text = "";
            tb40.Text = "";

            tb41.Text = "";
            tb42.Text = "";
            tb43.Text = "";
            tb44.Text = "";
            tb45.Text = "0";

            tb46.Text = "N";
            tb47.Text = "";
            txtPWT.Text = "";
            //khóa NR
            //tb3.ReadOnly = true;
            lbloaihang.Text = "";
        }
        public void f3ToolStripMenuItem_Click(object sender, EventArgs e) // F3 Deleting Data 
        {
            checkNofication();
            //khóa chức năng check
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            f3ToolStripMenuItem.Checked = true;

            bt.Text = "" + txtXoa + "";
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        public void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Repairing Data 
        {
            checkNofication();
            //khóa chức năng check
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            f4ToolStripMenuItem.Checked = true;

            bt.Text = "" + txtDuyet + "";
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            //khóa NR
            //tb3.ReadOnly = true;
        }
        public class getDataBindingSource2AB
        {
            public static DataTable source;
        }
        public void f5ToolStripMenuItem_Click(object sender, EventArgs e) // F5 Searching Data 
        {
            f5ToolStripMenuItem.Checked = true;
            //getDataBindingSource2AB.source = datatable;
            Form2ABF5 frm = new Form2ABF5();
            frm.ShowDialog();
            string getWS_NO = Form2ABF5.getInfo.getWS_NO;
            string getNR = Form2ABF5.getInfo.getNR;
            if (getWS_NO != string.Empty)
            {
                LoadDataGriView();
            }
            else
            {
                btdong.PerformClick();
            }
        }
        public void f6ToolStripMenuItem_Click(object sender, EventArgs e) // F6 Coping Data 
        {
            checkNofication();
            //khóa chức năng check
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;

            f6ToolStripMenuItem.Checked = true;

            bt.Text = "COPY";
            btok.Show();
            btdong.Show();
            tb23.Text = "";

            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f11ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            tb23.Clear();
            if (tb44.Text == "不計價")
                tb24.Text = "0";
            //trả dữ liệu cũ
            tb45.Text = "0";
            tb46.Text = "N";
            tb29.Text = "";
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            getNR();
            tb2.Text = DateTime.Now.ToString("yy/MM/dd");
            //khóa NR
            //tb3.ReadOnly = true;
        }
        public void f7ToolStripMenuItem_Click(object sender, EventArgs e) // F7 Pringting Data 
        {
            f7ToolStripMenuItem.Checked = true;
            Form2ABF7 frm = new Form2ABF7();
            frm.ShowDialog();
        }
        public void f9ToolStripMenuItem_Click(object sender, EventArgs e) // F9 Selecting Data 
        {
            f9ToolStripMenuItem.Checked = true;
            btok.PerformClick();
        }
        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e) // Saving Data 
        {
            f10ToolStripMenuItem.Checked = true;
            btok.PerformClick();
        }
        private void f11ĐóngToolStripMenuItem_Click(object sender, EventArgs e) // F11 Closing  
        {
            checkNofication();

            f11ToolStripMenuItem.Checked = true;

            LoadDataGriView();
            BindingData(-1);
            // show_dltruyenve();

            btok.Hide();
            btdong.Hide();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = false;
            f11ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            bt.Text = "" + txtDuyet + "";
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) // F12 Closing App
        {
            Form2ABF5.index = 0;
            this.Close();
        }

        private void btdong_Click(object sender, EventArgs e) // Button Dong 
        {
            f2ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            
            Loadfirst2B();
            pageIndex = 0;
            LoadDataGriView();
            BindingData(-1);
        }
        private void btok_Click(object sender, EventArgs e) //Button Ok  
        {
            check();
            checkNofication();
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (checkExsist() == true)
                {
                    DialogResult dialog = MessageBox.Show("Đã tồn tại đơn hàng này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        addingData();
                        Loadfirst2B();
                    }
                }
                else
                {
                    addingData();
                    Loadfirst2B();
                }
            }
            if (f3ToolStripMenuItem.Checked == true)
            {
                DeletingData();
                Loadfirst2B();
            }
            if (f4ToolStripMenuItem.Checked == true)
            {
                RepairingData();
                Loadfirst2B();
            }
            if (f6ToolStripMenuItem.Checked == true)
            {
                if (checkExsist() == true)
                {
                    DialogResult dialog = MessageBox.Show("Đã tồn tại đơn hàng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        addingData();
                        Loadfirst2B();
                    }
                }
                else
                {
                    addingData();
                    Loadfirst2B();
                }
            }
        }

        #endregion
        void addingData() // Method Adding Data 
        {
            checkNofication();
            if (tb1.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("" + txtText + "");
                return;
            }
            else if (tb3.Text == "")
            {
                MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "");
                return;
            }
            else if (tb4.Text == "")
            {
                MessageBox.Show("" + txtText2 + "", "" + txtThongBao + "");
                return;
            }
            else if (tb5.Text == "")
            {
                MessageBox.Show("" + txtText3 + "", "" + txtThongBao + "");
                return;
            }
            else
            {
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    string st1 = "insert into ORDB(K_NO, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, C_NAME_E, B_NO, BRAND, T_NAME, MODEL_C, MODEL_E, P_NO, P_NAME_C, P_NAME_E, COLOR_C, COLOR_E, PATT_E, PATT_C, THICK, QTY," +
                    " CURRENCY, CLRCARD, PRICE, PER_S, GRADE, ACCOUNT, ACHI, WS_DATE1,SCHEDULE2, WS_DATE3, TOTAL, WS_DATE_F, PURCHASER, ORD_WEG, DEVSTAGE, MK_PLACE, SER_NO, COMPOUNTS, DESIGER, " +
                    "RV_PLACE, SEASON, SALES, REMARKS, QTY_OUT, OVER0, ONOS,MEMO01,QTY_OUT_T,QTY_ORD,OVER1,USR_NAME,ACT_MONTH,T_NO) values" +
                    "(@K_NO, @WS_DATE, @NR, @OR_NO, @C_NO, @C_NAME_C, @C_NAME_E, @B_NO, @BRAND, @T_NAME, @MODEL_C, @MODEL_E, @P_NO, @P_NAME_C, @P_NAME_E, @COLOR_C, @COLOR_E, @PATT_E, @PATT_C, @THICK, @QTY, " +
                    "@CURRENCY, @CLRCARD, @PRICE, @PER_S, @GRADE, @ACCOUNT, @ACHI, @WS_DATE1,@SCHEDULE2,@WS_DATE3, @TOTAL, @WS_DATE_F, @PURCHASER, @ORD_WEG, @DEVSTAGE,@MK_PLACE,@SER_NO, @COMPOUNTS," +
                    " @DESIGER, @RV_PLACE, @SEASON, @SALES, @REMARKS, @QTY_OUT, @OVER0,@ONOS,@MEMO01,@QTY_OUT_T,@QTY_ORD,@OVER1,@USR_NAME,@ACT_MONTH,@T_NO)";
                    SqlCommand cm = new SqlCommand(st1, con);
                    cm.Parameters.AddWithValue("@K_NO", tb1.SelectedItem.ToString());
                    cm.Parameters.AddWithValue("@WS_DATE", conn.formatstr1(a));
                    cm.Parameters.AddWithValue("@NR", tb3.Text);
                    cm.Parameters.AddWithValue("@OR_NO", tb4.Text);
                    cm.Parameters.AddWithValue("@C_NO", tb5.Text);

                    cm.Parameters.AddWithValue("@C_NAME_C", tb6.Text);
                    cm.Parameters.AddWithValue("@C_NAME_E", tb7.Text);
                    cm.Parameters.AddWithValue("@B_NO", tb8.Text);
                    cm.Parameters.AddWithValue("@BRAND", tb9.Text);
                    cm.Parameters.AddWithValue("@T_NAME", tb10.Text);

                    cm.Parameters.AddWithValue("@MODEL_C", tb11.Text);
                    cm.Parameters.AddWithValue("@MODEL_E", tb12.Text);
                    cm.Parameters.AddWithValue("@P_NO", tb13.Text);
                    cm.Parameters.AddWithValue("@P_NAME_C", tb14.Text);
                    cm.Parameters.AddWithValue("@P_NAME_E", tb15.Text);

                    cm.Parameters.AddWithValue("@COLOR_C", tb16.Text);
                    cm.Parameters.AddWithValue("@COLOR_E", tb17.Text);
                    cm.Parameters.AddWithValue("@PATT_E", tb18.Text);
                    cm.Parameters.AddWithValue("@PATT_C", tb19.Text);
                    cm.Parameters.AddWithValue("@THICK", tb20.Text);

                    cm.Parameters.AddWithValue("@QTY", double.Parse(tb21.Text));
                    cm.Parameters.AddWithValue("@CURRENCY", tb22.Text);
                    cm.Parameters.AddWithValue("@CLRCARD", tb23.Text);
                    if (tb44.Text == "不計價")
                    {
                        cm.Parameters.AddWithValue("@PRICE", 0);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@PRICE", double.Parse(tb24.Text));
                    }
                    cm.Parameters.AddWithValue("@PER_S", tb25.Text);

                    cm.Parameters.AddWithValue("@GRADE", tb26.Text);
                    cm.Parameters.AddWithValue("@ACCOUNT", tb27.Text);
                    cm.Parameters.AddWithValue("@ACHI", tb28.Text);
                    cm.Parameters.AddWithValue("@WS_DATE1", "");
                    cm.Parameters.AddWithValue("@SCHEDULE2", conn.formatstr1(c));
                    cm.Parameters.AddWithValue("@WS_DATE3", tb31.Text);

                    // cm.Parameters.AddWithValue("@", tb31.Text);
                    cm.Parameters.AddWithValue("@TOTAL", double.Parse(tb32.Text));
                    cm.Parameters.AddWithValue("@WS_DATE_F", conn.formatstr1(d));
                    cm.Parameters.AddWithValue("@PURCHASER", tb34.Text);
                    cm.Parameters.AddWithValue("@ORD_WEG", double.Parse(tb35.Text));

                    cm.Parameters.AddWithValue("@DEVSTAGE", tb36.Text);
                    cm.Parameters.AddWithValue("@MK_PLACE", tb37.Text);
                    cm.Parameters.AddWithValue("@SER_NO", tb38.Text);
                    cm.Parameters.AddWithValue("@COMPOUNTS", tb39.Text);
                    cm.Parameters.AddWithValue("@DESIGER", tb40.Text);

                    cm.Parameters.AddWithValue("@RV_PLACE", tb41.Text);
                    cm.Parameters.AddWithValue("@SEASON", tb42.Text);
                    cm.Parameters.AddWithValue("@SALES", tb43.Text);

                    cm.Parameters.AddWithValue("@REMARKS", tb44.Text);

                    cm.Parameters.AddWithValue("@QTY_OUT", float.Parse(tb45.Text));

                    cm.Parameters.AddWithValue("@OVER0", tb46.Text);
                    cm.Parameters.AddWithValue("@ONOS", tb47.Text);
                    cm.Parameters.AddWithValue("@MEMO01", txtPWT.Text);

                    cm.Parameters.AddWithValue("@QTY_OUT_T", 0);
                    cm.Parameters.AddWithValue("@QTY_ORD", 0);
                    cm.Parameters.AddWithValue("@OVER1", "N");
                    cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);
                    cm.Parameters.AddWithValue("@ACT_MONTH", "");
                    cm.Parameters.AddWithValue("@T_NO", "");
                    //load MAX

                    int count = cm.ExecuteNonQuery();
                    if (count > 0)
                    {
                        setDatagridview();
                    }
                    con.Close();
                    // LoadDataGriView();
                    //LoadAgainData();
                    //LoadSearch2();c
                    //Loadfirst2B();
                    //f2ToolStripMenuItem.PerformClick();
                    tb3.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadAgainData()
        {
            if (f5ToolStripMenuItem.Checked == true)
            {
                Form2ABF5.index = bindingsource.Position;
                pageIndex = 0;
                load();
                if (checknew == 0)
                {
                    pageIndex = 1;
                }
                Color_Data();
            }
            else
            {
                Form2ABF5.index = bindingsource.Position;
                pageIndex = 0;
                LoadDataGriView();
            }

        }
        void DeletingData() // Method Deleting 
        {
            checkNofication();
            try
            {
                string SQL2 = "DELETE ORDB WHERE K_NO= '" + tb1.SelectedItem.ToString() + "' AND NR='" + tb3.Text + "' AND C_NO='" + tb5.Text + "' AND WS_DATE = '" + conn.formatstr1(a) + "'";
                bool Del = conn.exedata(SQL2);
                if (Del == true)
                {
                    dataGridViewdonhang.Rows.RemoveAt(dataGridViewdonhang.CurrentRow.Index);
                }
                //LoadDataGriView();
                BindingData(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void RepairingData() // Method repairing 
        {
            checkNofication();
            con = new SqlConnection(st);
            con.Open();
            string st2 = "update ORDB set K_NO=@K_NO, WS_DATE=@WS_DATE, NR=@NR, OR_NO=@OR_NO, C_NO=@C_NO, C_NAME_C=@C_NAME_C, C_NAME_E=@C_NAME_E, B_NO=@B_NO, BRAND=@BRAND, T_NAME=@T_NAME, MODEL_C = @MODEL_C, MODEL_E=@MODEL_E, P_NO=@P_NO, P_NAME_C=@P_NAME_C, P_NAME_E=@P_NAME_E," +
               "COLOR_C=@COLOR_C, COLOR_E=@COLOR_E, PATT_E=@PATT_E, PATT_C=@PATT_C, THICK=@THICK, QTY=@QTY, CURRENCY=@CURRENCY, CLRCARD=@CLRCARD, PRICE=@PRICE, PER_S=@PER_S, GRADE=@GRADE, ACCOUNT=@ACCOUNT, ACHI=@ACHI, WS_DATE3=@WS_DATE3, TOTAL=@TOTAL, WS_DATE_F=@WS_DATE_F," +
               "PURCHASER=@PURCHASER, ORD_WEG=@ORD_WEG, DEVSTAGE=@DEVSTAGE, SCHEDULE2=@SCHEDULE2, SER_NO=@SER_NO, COMPOUNTS=@COMPOUNTS, DESIGER=@DESIGER, RV_PLACE=@RV_PLACE, SEASON=@SEASON, SALES=@SALES, REMARKS=@REMARKS, QTY_OUT=@QTY_OUT, OVER0=@OVER0, MK_PLACE=@MK_PLACE, MEMO01=@MEMO01," +
               "ONOS=@ONOS,USR_NAME = @USR_NAME, T_NO = @T_NO from ORDB where K_NO = @K_NO and WS_DATE = @WS_DATE and NR = @NR and C_NO = @C_NO";

            SqlCommand cm = new SqlCommand(st2, con);
            cm.Parameters.AddWithValue("@K_NO", tb1.SelectedItem.ToString());
            cm.Parameters.AddWithValue("@WS_DATE", conn.formatstr1(a));
            cm.Parameters.AddWithValue("@NR", tb3.Text);
            cm.Parameters.AddWithValue("@OR_NO", tb4.Text);
            cm.Parameters.AddWithValue("@C_NO", tb5.Text);

            cm.Parameters.AddWithValue("@C_NAME_C", tb6.Text);
            cm.Parameters.AddWithValue("@C_NAME_E", tb7.Text);
            cm.Parameters.AddWithValue("@B_NO", tb8.Text);
            cm.Parameters.AddWithValue("@BRAND", tb9.Text);
            cm.Parameters.AddWithValue("@T_NAME", tb10.Text);

            cm.Parameters.AddWithValue("@MODEL_C", tb11.Text);
            cm.Parameters.AddWithValue("@MODEL_E", tb12.Text);
            cm.Parameters.AddWithValue("@P_NO", tb13.Text);
            cm.Parameters.AddWithValue("@P_NAME_C", tb14.Text);
            cm.Parameters.AddWithValue("@P_NAME_E", tb15.Text);

            cm.Parameters.AddWithValue("@COLOR_C", tb16.Text);
            cm.Parameters.AddWithValue("@COLOR_E", tb17.Text);
            cm.Parameters.AddWithValue("@PATT_E", tb18.Text);
            cm.Parameters.AddWithValue("@PATT_C", tb19.Text);
            cm.Parameters.AddWithValue("@THICK", tb20.Text);

            cm.Parameters.AddWithValue("@QTY", double.Parse(tb21.Text));
            cm.Parameters.AddWithValue("@CURRENCY", tb22.Text);
            cm.Parameters.AddWithValue("@CLRCARD", tb23.Text);
            if (tb44.Text == "不計價")
            {
                cm.Parameters.AddWithValue("@PRICE", 0);
            }
            else
            {
                cm.Parameters.AddWithValue("@PRICE", double.Parse(tb24.Text));
            }
            cm.Parameters.AddWithValue("@PER_S", tb25.Text);

            cm.Parameters.AddWithValue("@GRADE", tb26.Text);
            cm.Parameters.AddWithValue("@ACCOUNT", tb27.Text);
            cm.Parameters.AddWithValue("@ACHI", tb28.Text);
            //cm.Parameters.AddWithValue("@WS_DATE1", );
            cm.Parameters.AddWithValue("@SCHEDULE2", conn.formatstr1(c));
            cm.Parameters.AddWithValue("@WS_DATE3", tb31.Text);

            // cm.Parameters.AddWithValue("@", tb31.Text);
            cm.Parameters.AddWithValue("@TOTAL", double.Parse(tb32.Text));
            cm.Parameters.AddWithValue("@WS_DATE_F", conn.formatstr1(d));
            cm.Parameters.AddWithValue("@PURCHASER", tb34.Text);
            cm.Parameters.AddWithValue("@ORD_WEG", double.Parse(tb35.Text));

            cm.Parameters.AddWithValue("@DEVSTAGE", tb36.Text);
            cm.Parameters.AddWithValue("@MK_PLACE", tb37.Text);
            cm.Parameters.AddWithValue("@SER_NO", tb38.Text);
            cm.Parameters.AddWithValue("@COMPOUNTS", tb39.Text);
            cm.Parameters.AddWithValue("@DESIGER", tb40.Text);

            cm.Parameters.AddWithValue("@RV_PLACE", tb41.Text);
            cm.Parameters.AddWithValue("@SEASON", tb42.Text);
            cm.Parameters.AddWithValue("@SALES", tb43.Text);
            cm.Parameters.AddWithValue("@REMARKS", tb44.Text);
            cm.Parameters.AddWithValue("@QTY_OUT", float.Parse(tb45.Text));

            cm.Parameters.AddWithValue("@OVER0", tb46.Text);
            cm.Parameters.AddWithValue("@ONOS", tb47.Text);
            cm.Parameters.AddWithValue("@MEMO01", txtPWT.Text);
            cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);
            // cm.Parameters.AddWithValue("@ACT_MONTH", "");
            cm.Parameters.AddWithValue("@T_NO", "");

            if (tb1.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("" + txtText + "");
                return;
            }
            else if (tb21.Text == string.Empty)
            {
                MessageBox.Show("" + txtText7 + "");
                return;
            }
            else if (tb24.Text == string.Empty)
            {
                MessageBox.Show("" + txtText8 + "");
                return;
            }
            else if (tb32.Text == string.Empty)
            {
                MessageBox.Show("" + txtText9 + "");
                return;
            }
            else if (tb35.Text == string.Empty)
            {
                MessageBox.Show("" + txtText10 + "");
                return;
            }
            else if (tb45.Text == string.Empty)
            {
                MessageBox.Show("" + txtText11 + "");
                return;
            }

            try
            {
                cm.ExecuteNonQuery();
                con.Close();
                LoadAgainData();
                //LoadDataGriView();
                //LoadSearch2();
                //LoadSearch2();
                tb3.ReadOnly = false;
                //BindingData();
                Color_Data();
                btok.Hide();
                btdong.Hide();

                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f9ToolStripMenuItem.Enabled = false;
                f10ToolStripMenuItem.Enabled = false;
                f11ToolStripMenuItem.Enabled = false;
                f12ToolStripMenuItem.Enabled = true;

                bt.Text = "" + txtDuyet + "";
                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void LoadSearch2()
        {
            if (datatable != null)
            {
                string searchValue = tb4.Text;
                string searchNR = tb3.Text;
                int rowIndex = 0;

                dataGridViewdonhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dataGridViewdonhang.Rows)
                    {
                        if (row.Cells["OR_NO"].Value.ToString().Equals(searchValue) && row.Cells["NR"].Value.ToString().Equals(searchNR))
                        {
                            rowIndex = row.Index;
                            dataGridViewdonhang.Rows[rowIndex].Selected = true;
                            dataGridViewdonhang.CurrentCell = dataGridViewdonhang.Rows[rowIndex].Cells["K_NAME"];
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                //conn.FormatDGV(dataGridViewdonhang, datatable);
                BindingData(-1);
                Color_Data();
            }
        }
        public void getmess(string str2)
        {
            tb40.Text = str2;
        }
        public void getmess3(string str1, string str2, string str3)
        {
            tb5.Text = str1;
            tb6.Text = str2;
            tb7.Text = str3;
        }
        private void txtkt_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtlb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchFns_Product2 frm = new FormSearchFns_Product2();
                frm.ShowDialog();
                tb26.Text = FormSearchFns_Product2.ID.ID_GNO;
            }
        }
        private void txtkt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchStaff4 fm = new FormSearchStaff4();
                fm.ShowDialog();
                tb27.Text = FormSearchStaff4.ID.S_NAME2;
            }
        }
        private void txtlb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchEfficiency frm = new FormSearchEfficiency();
                frm.ShowDialog();
                tb28.Text = FormSearchEfficiency.ID.M_NAME;
            }
        }
        private void txtmaumauyc_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtlb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FormSearchLeather2 frm = new FormSearchLeather2();
                frm.ShowDialog();
                tb37.Text = FormSearchLeather2.ID.M_NAME;
            }
        }
        private void txtchuy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchLeather2 fm2 = new FormSearchLeather2();
                fm2.ShowDialog();
                tb44.Text = FormSearchLeather2.ID.M_NAME;

                string memo = FormSearchLeather2.ID.M_NO;
                if (memo == "B0001" || memo == "B0002" || memo == "B0003" || memo == "B0004")
                {
                    tb24.Text = "0.00";
                }
            }
        }
        private void txtpnghiep_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchStaff4 fm = new FormSearchStaff4();
                fm.ShowDialog();
                tb43.Text = FormSearchStaff4.ID.S_NAME2;
            }
        }
        private void txtthietke_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchStaff4 fm = new FormSearchStaff4();
                fm.ShowDialog();
                tb40.Text = FormSearchStaff4.ID.S_NAME2;
            }
        }
        public string doiso(string st)
        {
            string st1 = "";
            if (st.Length == 1)
            {
                st1 = "00" + st;
            }
            else if (st.Length == 2)
            {
                st1 = "0" + st;
            }
            else st1 = st;
            return st1;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void tb3_MouseClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (conn.readdata("SELECT * FROM tbl_Type_New WHERE K_NO ='" + tb1.Text + "'").Rows.Count > 0)
                {
                    getNR();
                }
            }
        }
        void getNR()
        {
            checkNofication();
            if (tb1.Text == "" && tb2.Text == "")
            {
                MessageBox.Show("" + txtText13 + "", "" + txtThongBao + "");
            }
            else
            {
                // lấy giá trị combobox
                string combobox = tb1.SelectedItem.ToString().Trim();
                string Date = conn.formatstr1(tb2.Text);
                string SQL = "";
                if (combobox == "1" || combobox == "2")
                {
                    SQL = "SELECT MAX(NR) as NR FROM ORDB WHERE WS_DATE = '" + Date + "' AND K_NO in (1,2)";
                    DataTable datatable = conn.readdata(SQL);
                    if (datatable != null)
                    {
                        foreach (DataRow dr in datatable.Rows)
                        {
                            if (dr["NR"].ToString() != "")
                            {
                                int Result = int.Parse(dr["NR"].ToString());
                                Result++;
                                tb3.Text = Result.ToString("D" + 3);
                            }
                            else
                            {
                                tb3.Text = "001";
                            }
                        }
                    }
                    else
                    {
                        tb3.Text = "001";
                    }
                }
                else if (combobox == "3" || combobox == "4")
                {
                    SQL = "SELECT MAX(NR) as NR FROM ORDB WHERE WS_DATE = '" + Date + "' AND K_NO in (3,4)";
                    DataTable datatable = conn.readdata(SQL);
                    if (datatable != null)
                    {
                        foreach (DataRow dr in datatable.Rows)
                        {
                            if (dr["NR"].ToString() != "")
                            {
                                int Result = int.Parse(dr["NR"].ToString());
                                Result++;
                                tb3.Text = Result.ToString("D" + 3);
                            }
                            else
                            {
                                tb3.Text = "001";
                            }
                        }
                    }
                    else
                    {
                        tb3.Text = "001";
                    }
                }
                else if (combobox == "7")
                {
                    SQL = "SELECT MAX(NR) as NR FROM ORDB WHERE WS_DATE = '" + Date + "' AND K_NO in (7)";
                    DataTable datatable = conn.readdata(SQL);
                    if (datatable != null)
                    {
                        foreach (DataRow dr in datatable.Rows)
                        {
                            if (dr["NR"].ToString() != "")
                            {
                                int Result = int.Parse(dr["NR"].ToString());
                                Result++;
                                tb3.Text = Result.ToString("D" + 3);

                            }
                            else
                            {
                                tb3.Text = "001";
                            }
                        }
                    }
                    else
                    {
                        tb3.Text = "001";
                    }
                }
                else if (combobox == "6")
                {
                    SQL = "SELECT MAX(NR) as NR FROM ORDB WHERE WS_DATE = '" + Date + "' AND K_NO in (6)";
                    DataTable datatable = conn.readdata(SQL);
                    if (datatable != null)
                    {
                        foreach (DataRow dr in datatable.Rows)
                        {
                            if (dr["NR"].ToString() != "")
                            {
                                int Result = int.Parse(dr["NR"].ToString());
                                Result++;
                                tb3.Text = Result.ToString("D" + 3);

                            }
                            else
                            {
                                tb3.Text = "001";
                            }
                        }
                    }
                    else
                    {
                        tb3.Text = "001";
                    }
                }
                else if (combobox == "5")
                {
                    SQL = "SELECT MAX(NR) as NR FROM ORDB WHERE WS_DATE = '" + Date + "' AND K_NO in (5)";
                    DataTable datatable = conn.readdata(SQL);
                    if (datatable != null)
                    {
                        foreach (DataRow dr in datatable.Rows)
                        {
                            if (dr["NR"].ToString() != "")
                            {
                                int Result = int.Parse(dr["NR"].ToString());
                                Result++;
                                tb3.Text = Result.ToString("D" + 3);

                            }
                            else
                            {
                                tb3.Text = "001";
                            }
                        }
                    }
                    else
                    {
                        tb3.Text = "001";
                    }
                }
            }
        }
        private void tb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "";
            // sql1 = "SELECT "+CheckNgonNgu()+" as K_NAME FROM tbl_Type_New WHERE K_NO = '" + tb1.Text + "'";
            sql1 = "SELECT " + CheckNgonNgu() + " as K_NAME FROM tbl_Type_New WHERE K_NO = '" + tb1.Text + "'";
            DataTable datatable = conn.readdata(sql1);
            if (datatable != null)
            {
                foreach (DataRow dr in datatable.Rows)
                    lbloaihang.Text = dr["K_NAME"].ToString();
            }
            getNR();
        }
        void tong()
        {
            try
            {
                if (!string.IsNullOrEmpty(tb21.Text))
                {
                    double sl = Convert.ToDouble(tb21.Text.Trim());
                    double gia = Convert.ToDouble(tb24.Text.Trim());
                    double tong = (sl * gia);
                    tb32.Text = String.Format("{0:n}", tong);
                }
                else
                {
                    MessageBox.Show("Vui lòng không để trống");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tb24_TextChanged(object sender, EventArgs e) // Sum Don Hang 
        {
            if (f2ToolStripMenuItem.Checked == true && tb24.Text != "")
                tong();
            if (f6ToolStripMenuItem.Checked == true && tb24.Text != "")
                tong();
        }
        private void tb5_MouseDoubleClick(object sender, MouseEventArgs e) // get khach hàng khi thêm 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frm2CustSearch fr = new frm2CustSearch();
                fr.ShowDialog();
                tb5.Text = frm2CustSearch.ID.ID_CUST;
                tb6.Text = frm2CustSearch.ID.NAME_C;
                tb7.Text = frm2CustSearch.ID.NAME_E;
            }
            UpdateCountPriceAgain();
        }
        private void txtnhanhieu_MouseDoubleClick(object sender, MouseEventArgs e) // get nhan hieu 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                //FormSearchBrand fr = new FormSearchBrand();
                frm2BrandSearch fr = new frm2BrandSearch();
                fr.ShowDialog();
                tb8.Text = frm2BrandSearch.getInfo.ID_BRAND;
                tb9.Text = frm2BrandSearch.getInfo.BRAND;
                tb10.Text = frm2BrandSearch.getInfo.TRADE;
            }
            UpdateCountPriceAgain();
        }
        public void txtmalieu_MouseDoubleClick(object sender, MouseEventArgs e) // get Meterial 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchMaterial2 frm = new FormSearchMaterial2();
                frm.ShowDialog();
                tb13.Text = FormSearchMaterial2.ID.ID_P_NO;
                tb14.Text = FormSearchMaterial2.ID.P_NAME;
                tb15.Text = FormSearchMaterial2.ID.P_NAME1;
            }
            UpdateCountPriceAgain();
        }
        public void txtmau3_MouseDoubleClick(object sender, MouseEventArgs e) // get Patt 1 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frmSearchPatt frm = new frmSearchPatt();
                frm.ShowDialog();
                tb18.Text = frmSearchPatt.ID.PATT;
            }
        }
        public void txtpart_MouseDoubleClick(object sender, MouseEventArgs e) // get Patt 2 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frmSearchPatt frm = new frmSearchPatt();
                frm.ShowDialog();
                tb19.Text = frmSearchPatt.ID.PATT;
            }
        }
        private void txtdoday_MouseDoubleClick(object sender, MouseEventArgs e) // get thick 
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchThick2 frm = new FormSearchThick2();
                frm.ShowDialog();
                tb20.Text = FormSearchThick2.ID.ID_THICK;
            }
            UpdateCountPriceAgain();
        }
        private void tb22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string a = "";
            a = tb22.Text;
            if (a == "")
            {
                tb22.Text = "USD";
                tb22.Show();
                return;
            }
            if (a == "USD")
            {
                tb22.Text = "HKD";
                tb22.Show();
                return;
            }
            if (a == "HKD")
            {
                tb22.Text = "NTD";
                tb22.Show();
                return;
            }
            if (a == "NTD")
            {
                tb22.Text = "RMB";
                tb22.Show();
                return;
            }
            if (a == "RMB")
            {
                tb22.Text = "USD";
                tb22.Show();
                return;
            }
        }
        private void tb34_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                FormSearchStaff4 fm = new FormSearchStaff4();
                fm.ShowDialog();
                tb34.Text = FormSearchStaff4.ID.S_NAME2;
            }
        }
        private void tb20_TextChanged(object sender, EventArgs e)
        {
            UpdateCountPriceAgain();
        }
        private void tb21_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                tong();
                UpdateCountPriceAgain();
            }
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
        }
        // Event Enter Start 
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb2.Focus();
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb3.Focus();
        }
        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb2, tb4, sender, e);
        }
        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb3, tb5, sender, e);
        }
        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb6, sender, e);
        }
        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb5, tb7, sender, e);
        }
        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb8, sender, e);
        }
        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb7, tb9, sender, e);
        }
        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb8, tb10, sender, e);
        }
        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb9, tb11, sender, e);
        }
        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb10, tb12, sender, e);
        }
        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb11, tb13, sender, e);
        }
        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb12, tb14, sender, e);
        }
        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }
        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb14, txtPWT, sender, e);
        }
        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }
        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb16, tb18, sender, e);
        }
        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb17, tb19, sender, e);
        }
        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb18, tb20, sender, e);
        }
        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb19, tb21, sender, e);
        }
        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb20, tb22, sender, e);
        }
        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb21, tb23, sender, e);
        }
        private void tb23_KeyDown(object sender, KeyEventArgs e)
        {
            if (tb24.Enabled == true)
            {
                tab(tb22, tb24, sender, e);
            }
            else
            {
                tab(tb22, tb25, sender, e);
            }
        }
        private void tb24_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb23, tb25, sender, e);
        }
        private void tb25_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb24, tb26, sender, e);
        }
        private void tb26_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb25, tb27, sender, e);
        }
        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb26, tb28, sender, e);
        }
        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb27, tb29, sender, e);
        }
        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb28, tb30, sender, e);
        }
        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb29, tb31, sender, e);
        }
        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb30, tb32, sender, e);
        }
        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb31, tb33, sender, e);
        }
        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb32, tb34, sender, e);
        }
        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb33, tb35, sender, e);
        }
        private void tb35_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb34, tb36, sender, e);
        }
        private void tb36_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb35, tb37, sender, e);
        }
        private void tb37_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb36, tb38, sender, e);
        }
        private void tb38_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb37, tb39, sender, e);
        }
        private void tb39_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb38, tb40, sender, e);
        }
        private void tb40_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb39, tb41, sender, e);
        }
        private void tb41_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb40, tb42, sender, e);
        }
        private void tb42_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb41, tb43, sender, e);
        }
        private void tb43_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb42, tb44, sender, e);
        }
        private void tb44_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb43, tb45, sender, e);
        }
        private void tb45_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb44, tb46, sender, e);
        }
        private void tb46_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb45, tb47, sender, e);
        }
        private void tb47_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                tb1.Focus();
        }
        void CountPrice()
        {
            try
            {
                string SQL = "SELECT QUOB.PRICE,QUOH.VA_DATE, QUOH.VA_DATES, QUOB.AMOUNT FROM QUOB INNER JOIN QUOH ON QUOB.WS_NO = QUOH.WS_NO " +
                "WHERE QUOH.W_CHECK = 'Y' AND QUOH.C_NO = '" + tb5.Text + "'  AND (QUOB.MEMO1 = '" + tb10.Text + "' OR QUOB.MEMO1 = '" + tb9.Text + "')  AND QUOB.P_NO = '" + tb13.Text + "' AND P_NAME3 = '" + tb20.Text + "'  AND CAST('"+tb2.Text.Replace("/","")+"' AS DATE) BETWEEN CAST(QUOH.VA_DATES AS DATE) AND  CAST(QUOH.VA_DATE AS DATE)";
                DataTable dt = conn.readdata(SQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tb24.Text = dr["PRICE"].ToString();
                    }
                }
                else
                {
                    tb24.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tb24_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateCountPriceAgain();
        }
        private void tb5_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string SL = " select * from CUST where C_NO='" + tb5.Text + "'";
                DataTable dt = conn.readdata(SL);
                foreach (DataRow dr in dt.Rows)
                {
                    tb6.Text = dr["C_NAME2"].ToString();
                    tb7.Text = dr["C_NAME2_E"].ToString();
                }
            }
            UpdateCountPriceAgain();
        }
        private void txtPWT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                frm2QF5 fr1 = new frm2QF5();
                fr1.ShowDialog();

                String DL = frm2QF5.Get_PWT_2AB;
                if (DL != string.Empty)
                {
                    txtPWT.Text = DL;
                }
                else
                    txtPWT.Text = "";
            }
        }
        private void tb13_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                string SL = " select P_NO, P_NAME, P_NAME1 from PROD where P_NO = '" + tb13.Text + "'";
                DataTable dt = conn.readdata(SL);
                foreach (DataRow dr in dt.Rows)
                {
                    tb14.Text = dr["P_NAME"].ToString();
                    tb15.Text = dr["P_NAME1"].ToString();
                }
            }
            UpdateCountPriceAgain();
        }
        private void tb8_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                try
                {
                    if (tb8.Text != "")
                    {
                        string SL = "select B_NO, BRAND, TRADE from BRAND where B_NO ='" + tb8.Text + "'";
                        DataTable dt = conn.readdata(SL);
                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                tb9.Text = dr["BRAND"].ToString();
                                tb10.Text = dr["TRADE"].ToString();
                            }
                        }
                        else
                        {
                            checkNofication();
                            MessageBox.Show("" + txtText16 + "", "" + txtThongBao + "");
                            tb9.Text = "";
                            tb10.Text = "";
                        }
                    }
                    else
                    {
                        tb9.Text = "";
                        tb10.Text = "";
                    }
                }
                catch { }
            }
            UpdateCountPriceAgain();
        }
        public void UpdateCountPriceAgain()
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                CountPrice();
            }
        }
        
        private void dataGridViewdonhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridViewdonhang_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int display = dataGridViewdonhang.Rows.Count - dataGridViewdonhang.DisplayedRowCount(false);
                if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
                {
                    if (e.NewValue >= dataGridViewdonhang.Rows.Count - GetDisplayedRowsCount())
                    {
                        string str = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC) AS ROWID, tbl_Type_New.K_NO," + CheckNgonNgu() + " as K_NAME, ORDB.WS_DATE, ORDB.NR, ORDB.OR_NO, ORDB.C_NO, ORDB.C_NAME_C," +
                                           " ORDB.C_NAME_E, ORDB.B_NO,ORDB.BRAND, ORDB.T_NAME, ORDB.MODEL_C, ORDB.MODEL_E, ORDB.P_NO, ORDB.P_NAME_C, ORDB.P_NAME_E, ORDB.COLOR_C, " +
                                           "ORDB.COLOR_E,ORDB.PATT_E, ORDB.PATT_C, ORDB.THICK, ORDB.QTY, ORDB.CURRENCY, ORDB.CLRCARD, ORDB.PRICE, ORDB.PER_S, ORDB.GRADE, ORDB.ACCOUNT, " +
                                           "ORDB.ACHI,SUBSTRING(ORDB.WS_DATE1,3,6) as WS_DATE1,SUBSTRING(ORDB.SCHEDULE2,3,6) as SCHEDULE2,ORDB.WS_DATE3, ORDB.TOTAL, ORDB.WS_DATE_F, ORDB.PURCHASER, ORDB.ORD_WEG, ORDB.DEVSTAGE,ORDB.MK_PLACE, ORDB.SER_NO, " +
                                           "ORDB.COMPOUNTS, ORDB.DESIGER, ORDB.RV_PLACE, ORDB.SEASON, ORDB.SALES, ORDB.REMARKS, ORDB.QTY_OUT, ORDB.OVER0, ORDB.ONOS,ORDB.USR_NAME " +
                                           "FROM ORDB INNER JOIN tbl_Type_New ON ORDB.K_NO = tbl_Type_New.K_NO where 1=1 " + Form2ABF5.where + ") ORDB where 1=1 AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);

                        DataTable ds = new DataTable();
                        ds = conn.readdata(str);
                        foreach (DataRow dr in ds.Rows)
                        {
                            dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
                            dr["WS_DATE_F"] = conn.formatstr1(dr["WS_DATE_F"].ToString());
                            dr["WS_DATE1"] = conn.formatstr1(dr["WS_DATE1"].ToString());
                            dr["SCHEDULE2"] = conn.formatstr1(dr["SCHEDULE2"].ToString());
                        }
                        datatable.Merge(ds);
                        bindingsource.DataSource = datatable;
                        conn.FormatDGVbindingsource(dataGridViewdonhang, bindingsource);
                        dataGridViewdonhang.ClearSelection();
                        dataGridViewdonhang.FirstDisplayedScrollingRowIndex = display;
                        dataGridViewdonhang.CurrentCell = dataGridViewdonhang[dataGridViewdonhang.CurrentCell.ColumnIndex, display];
                        pageIndex++;
                        Color_Data();
                        BindingData(display);
                    }
                }
            }
        }
        private int GetDisplayedRowsCount()
        {
            int count = dataGridViewdonhang.Rows[dataGridViewdonhang.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridViewdonhang.Height / count;
            return count;
        }
        private void dataGridViewdonhang_SelectionChanged(object sender, EventArgs e)
        {
            //dataGridViewdonhang.ClearSelection();
        }
        private void txtPWT_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPWT, tb16, sender, e);
        }
        
        private void dataGridViewdonhang_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
        }
        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (tb1.Text == "1" || tb1.Text == "2" || tb1.Text == "3" || tb1.Text == "4" || tb1.Text == "7")
                {
                    string sql1 = "";
                    sql1 = "SELECT K_NAME_CN as K_NAME FROM tbl_Type_New WHERE K_NO = '" + tb1.Text + "' ";
                    // sql1 = "SELECT " + CheckNgonNgu() + " as K_NAME FROM tbl_Type_New WHERE K_NO = '" + tb1.Text + "' ";
                    DataTable datatable = conn.readdata(sql1);
                    if (datatable != null)
                        foreach (DataRow dr in datatable.Rows)
                            lbloaihang.Text = dr["K_NAME"].ToString();
                    if (!string.IsNullOrEmpty(tb1.Text))
                    {
                        if (conn.readdata("SELECT * FROM tbl_Type_New WHERE K_NO ='" + tb1.Text + "'").Rows.Count > 0)
                        {
                            tb1.SelectedIndex = tb1.FindString(tb1.Text);
                        }
                    }
                    getNR();
                }
            }
        }
        private void tb2_TextChanged_1(object sender, EventArgs e)
        {
            getNR();
        }
        private bool checkExsist()
        {
            try
            {
                string sql = "SELECT TOP 1 OR_NO FROM dbo.ORDB WHERE OR_NO ='" + tb4.Text + "' AND COLOR_C ='" + tb16.Text + "' AND COLOR_E ='" + tb17.Text + "' AND P_NO ='" + tb13.Text + "' AND QTY ='" + string.Format("{0:0}", tb21.Text) + "'";
                DataTable data = new DataTable();
                data = conn.readdata(sql);
                if (data.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        private void tb21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void tb1_MouseHover(object sender, EventArgs e)
        {
            Hover_Combobox();
        }
        private void Hover_Combobox()
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                if (DataProvider.LG.rdVietNam == true)
                {
                    toolStripStatusLabel4.Text = "1.Mẫu da bò,2.Mẫu da heo,3.Sản xuất da bò,4.Sản xuất da heo,5.Da Đài Loan,6.Da Khác,7.Da Dự tính";
                }
                if (DataProvider.LG.rdEnglish == true)
                {
                    toolStripStatusLabel4.Text = "1.Cow skin samples,2.Pig skin samples,3.Cow production leather,4.Pig production leather,5.Taiwan leather,6.Other leather,7.Intended leather";
                }
                if (DataProvider.LG.rdChina == true)
                {
                    toolStripStatusLabel4.Text = "1.牛皮样品,2.猪皮样品,3.牛皮制作,4.猪皮制作,5.台湾皮革,6.其他皮革,7.意向皮革";
                }
                if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
                {
                    toolStripStatusLabel4.Text = "1.Mẫu da bò,2.Mẫu da heo,3.Sản xuất da bò,4.Sản xuất da heo,5.Da Đài Loan,6.Da Khác,7.Da Dự tính";
                }
            }
            else
            {
                toolStripStatusLabel4.Text = "";
            }
        }
        private void Form2AB_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2ABF5.index = 0;
            Form2ABF5.where = "";
        }

        private void tb1_Click(object sender, EventArgs e)
        {
            if (DataProvider.LG.rdVietNam == true)
            {
                toolStripStatusLabel4.Text = "1.Mẫu da bò,2.Mẫu da heo,3.Sản xuất da bò,4.Sản xuất da heo,5.Da Đài Loan,6.Da Khác,7.Da Dự tính";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                toolStripStatusLabel4.Text = "1.Cow skin samples,2.Pig skin samples,3.Cow production leather,4.Pig production leather,5.Taiwan leather,6.Other leather,7.Intended leather";
            }
            if (DataProvider.LG.rdChina == true)
            {
                toolStripStatusLabel4.Text = "1.牛皮样品,2.猪皮样品,3.牛皮制作,4.猪皮制作,5.台湾皮革,6.其他皮革,7.意向皮革";
            }
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                toolStripStatusLabel4.Text = "1.Mẫu da bò,2.Mẫu da heo,3.Sản xuất da bò,4.Sản xuất da heo,5.Da Đài Loan,6.Da Khác,7.Da Dự tính";
            }
        }

        private void Form2AB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                f5ToolStripMenuItem.PerformClick();
            }    
        }

        private void dataGridViewdonhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                f5ToolStripMenuItem.PerformClick();
            }
        }

        private void tb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if (LibraryCalender.FromCalender.Flags)
                {
                    tb2.Text = FromCalender.getDate.ToString("yy/MM/dd");
                }
               
            }
        }
        private void tb29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if(LibraryCalender.FromCalender.Flags)
                    tb29.Text = FromCalender.getDate.ToString("yy/MM/dd");
            }
        }
        private void tb30_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if(LibraryCalender.FromCalender.Flags)
                    tb30.Text = FromCalender.getDate.ToString("yy/MM/dd");
            }
        }
        private void tb33_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if(LibraryCalender.FromCalender.Flags)
                    tb33.Text = FromCalender.getDate.ToString("yy/MM/dd");
            }
        }
        private void tb31_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true)
            {
                LibraryCalender.FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if(LibraryCalender.FromCalender.Flags)
                    tb31.Text = FromCalender.getDate.ToString("yy/MM/dd");
            }
        }
    }
}
