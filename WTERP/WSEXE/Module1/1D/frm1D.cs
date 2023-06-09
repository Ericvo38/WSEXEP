﻿using LibraryCalender;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1D : Form
    {
        DataProvider data = new DataProvider();
        public Form1D()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;

        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        DataProvider conN = new DataProvider();
        //check
        string a = "";
        string b = "";
        string c = "";
        string d = "";
        string f = "";
        string g = "";
        string h = "";
        string i = "";
        string j = "";
        string k = "";
        string l = "";
        string m = "";
        #region Change Language
        //txtThongBao
        string txtThongBao = "";
        string txtText = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        string txtThem = "";
        string txtSua = "";
        string txtXoa = "";
        string txtNodata = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Bạn chưa chọn tiền tệ";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Số Sản Phẩm Với 16 Ký Tự";
                txtText2 = "Bạn chưa nhập danh mục sản phẩm";
                txtText3 = "Bạn chưa nhập mã số sản phẩm ";
                txtText4 = "Mã Số Sản Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Bạn chưa chọn tiền tệ";
                txtThongBao = "Thông Báo";
                txtText1 = "Bạn Cần Thay Đổi Mã Số Sản Phẩm Với 16 Ký Tự";
                txtText2 = "Bạn chưa nhập danh mục sản phẩm";
                txtText3 = "Bạn chưa nhập mã số sản phẩm ";
                txtText4 = "Mã Số Sản Phẩm Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtDuyet = "NÚT DUYỆT";
                txtThem = "THÊM";
                txtSua = "SỬA";
                txtXoa = "XÓA";
                txtNodata = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "You have not selected a currency";
                txtThongBao = "Nofication";
                txtText1 = "You Need To Change Product Code With 16 Characters";
                txtText2 = "You have not entered the product category";
                txtText3 = "You have not entered the product number";
                txtText4 = "Product Code Existing \n Please Click OK, [Close] and Re-Operate";
                txtDuyet = "Browsing Button";
                txtThem = "ADD";
                txtSua = "UPDATE";
                txtXoa = "DELETE";
                txtNodata = "No data";
            }

            if (DataProvider.LG.rdChina == true)
            {
                txtText = "您尚未選擇貨幣”";
                txtThongBao = "通知";
                txtText1 = "您需要更改 16 個字符的產品代碼";
                txtText2 = "您尚未輸入產品類別";
                txtText3 = "您尚未輸入產品編號";
                txtText4 = "產品代碼已存在 \n 請單擊確定，[關閉] 並重新操作";
                txtDuyet = "瀏覽按鈕";
                txtThem = "更多的";
                txtSua = "擦除";
                txtXoa = "刪除";
                txtNodata = "沒有數據";
            }

        }
        #endregion
        private void Form1DQuanlydulieudoanhnghiep_Load(object sender, EventArgs e)
        {
            data.CheckLoad(menuStrip1);
            checkNofication();
            load_tb5();
            LoadData();
            hienthi();
            Show_tb5();

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";
            dataviewtb5.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

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
            lbUserName.Text = conN.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        public void LoadData()
        {
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select TOP 300 PROD1C.K_NO, KIND1C.K_NAME, C_NO, K_NO_O, DEPT, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3, UNIT, TRANS, BUNIT, CUNIT, PRICE, QDATE, M_TRAN, W_CHECK, QTYSTORE, QTYSAF, P_WEG, QTYSTORE_B, QTYSTORE_BB, BASEDATE, INDATE, OUTDATE, PLACE, MEMO1, MEMO2, MEMO3, MEMO4, PRICE1, PRICE2, PRICE4, " +
                " QTY01, PRICE5, PRICE6, PRICE7, PRICE8, PRICE3, DKIND, QDATE1, QDATE2, QDATE4, QDATE5, QDATE6, QDATE7, QDATE8, QDATE3, COST, COST_AVG, COST_NEW,PROD1C.USR_NAME from dbo.PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO Order by PROD1C.P_NO ASC";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
        }
        public DataRow currentRow
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
        public void hienthi()
        {
            tb1.Text = currentRow["K_NO"].ToString();
            tb2.Text = currentRow["K_NAME"].ToString();
            tb3.Text = currentRow["C_NO"].ToString();
            tb4.Text = currentRow["K_NO_O"].ToString();
            //tb5.Text = currentRow[""].ToString();

            tb6.Text = currentRow["DEPT"].ToString();
            tb7.Text = currentRow["P_NO"].ToString();
            tb8.Text = currentRow["P_NAME"].ToString();
            tb9.Text = currentRow["P_NAME1"].ToString();
            tb10.Text = currentRow["P_NAME2"].ToString();

            tb11.Text = currentRow["P_NAME3"].ToString();
            tb12.Text = currentRow["UNIT"].ToString();
            tb13.Text = currentRow["TRANS"].ToString();
            tb14.Text = currentRow["BUNIT"].ToString();
            tb15.Text = currentRow["CUNIT"].ToString();

            //tb16.Text = currentRow[""].ToString();
            string price = String.Format("{0:0.0}", currentRow["PRICE"]);

            tb17.Text = price;
            tb18.Text = conN.formatstr2(currentRow["QDATE"].ToString());
            cb19.Text = currentRow["M_TRAN"].ToString();
            tb20.Text = currentRow["W_CHECK"].ToString();

            tb21.Text = currentRow["QTYSTORE"].ToString();
            tb22.Text = currentRow["QTYSAF"].ToString();
            tb23.Text = currentRow["P_WEG"].ToString();
            tb24.Text = currentRow["QTYSTORE_B"].ToString();
            if (tb27.Text != "" && tb17.Text != "")
            {
                tb25.Text = (float.Parse(currentRow["QTYSTORE"].ToString()) * float.Parse(currentRow["PRICE"].ToString())).ToString();
            }
            else
            {
                tb25.Text = "";
            }
            tb26.Text = currentRow["QTYSTORE_BB"].ToString();
            tb27.Text = currentRow["QTYSTORE"].ToString();
            tb28.Text = conN.formatstr2(currentRow["BASEDATE"].ToString());
            tb29.Text = conN.formatstr2(currentRow["INDATE"].ToString());
            tb30.Text = currentRow["PLACE"].ToString();

            tb31.Text = conN.formatstr2(currentRow["OUTDATE"].ToString());
            tb32.Text = currentRow["MEMO1"].ToString();
            tb33.Text = currentRow["MEMO2"].ToString();
            tb34.Text = currentRow["MEMO3"].ToString();
            tb35.Text = currentRow["MEMO4"].ToString();

            tb36.Text = String.Format("{0:0.0}", currentRow["PRICE1"]);
            tb37.Text = String.Format("{0:0.0}", currentRow["PRICE2"]);
            tb38.Text = String.Format("{0:0.0}", currentRow["PRICE4"]);
            tb39.Text = String.Format("{0:0.0}", currentRow["QTY01"]);
            tb40.Text = String.Format("{0:0.0}", currentRow["PRICE5"]);

            tb41.Text = String.Format("{0:0.0}", currentRow["PRICE6"]);
            tb42.Text = String.Format("{0:0.0}", currentRow["PRICE7"]);
            tb43.Text = String.Format("{0:0.0}", currentRow["PRICE8"]);
            tb44.Text = String.Format("{0:0.0}", currentRow["PRICE3"]);
            tb45.Text = currentRow["DKIND"].ToString();

            tb46.Text = conN.formatstr2(currentRow["QDATE1"].ToString());
            tb47.Text = conN.formatstr2(currentRow["QDATE2"].ToString());
            tb48.Text = conN.formatstr2(currentRow["QDATE4"].ToString());
            tb49.Text = conN.formatstr2(currentRow["QDATE5"].ToString());
            tb50.Text = conN.formatstr2(currentRow["QDATE6"].ToString());

            tb51.Text = conN.formatstr2(currentRow["QDATE7"].ToString());
            tb52.Text = conN.formatstr2(currentRow["QDATE8"].ToString());
            tb53.Text = conN.formatstr2(currentRow["QDATE3"].ToString());
            tb54.Text = currentRow["COST"].ToString();
            tb55.Text = currentRow["COST_NEW"].ToString();

            tb56.Text = currentRow["COST_AVG"].ToString();
            if (tb55.Text != "" && tb59.Text != "")
            {
                tb57.Text = tb25.Text = (float.Parse(currentRow["COST_NEW"].ToString()) * float.Parse(currentRow["QTYSTORE"].ToString())).ToString();
            }
            else
            {
                tb57.Text = "";
            }
            tb58.Text = "0";
            tb59.Text = "0";

            lblEditBy.Text = currentRow["USR_NAME"].ToString();


        }
        private void btdau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveFirst();
            hienthi();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            bindingsource.MovePrevious();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            bindingsource.MoveNext();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }


        private void btketthuc_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();
            hienthi();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        public void load_tb5()
        {
            try
            {
                DataTable dt = new DataTable();
                con = new SqlConnection(st); // khoi tao co connection
                con.Open();
                cm = con.CreateCommand();
                cm.CommandText = "select K_NO, K_NAME from KIND1C";
                // co the su dung cm.ExecuteNonQuery();
                datatable = new DataTable();
                datatable.Load(cm.ExecuteReader());
                con.Close();
                bindingsource = new BindingSource();
                bindingsource.DataSource = datatable;
                dataviewtb5.DataSource = bindingsource;
            }
            catch
            {

            }

        }

        public void Show_tb5()
        {
            try
            {
                if (tb4.Text != string.Empty)
                {
                    for (int i = 0; i >= dataviewtb5.Rows.Count; i++)
                    {
                        if (tb4.Text == dataviewtb5.Rows[i].Cells["K_NO"].ToString())
                        {
                            tb5.Text = dataviewtb5.Rows[i].Cells["K_NAME"].ToString();
                            tb5.Show();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f2ToolStripMenuItem.Checked = true;
            bt.Text = "" + txtThem + "";

            btok.Show();
            btdong.Show();

            tb1.Text = "";
            tb2.Text = "";
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
            tb13.Text = "0";
            tb14.Text = "";
            tb15.Text = "";

            tb16.Text = "";
            tb17.Text = "0";
            tb18.Text = "";
            cb19.Text = "";
            tb20.Text = "";

            tb21.Text = "0";
            tb22.Text = "0";
            tb23.Text = "0";
            tb24.Text = "0";
            tb25.Text = "";

            tb26.Text = "0";
            tb27.Text = "";

            tb30.Text = "";

            tb32.Text = "";
            tb33.Text = "";
            tb34.Text = "";
            tb35.Text = "";

            tb36.Text = "0";
            tb37.Text = "0";
            tb38.Text = "0";
            tb39.Text = "0";
            tb40.Text = "0";

            tb41.Text = "0";
            tb42.Text = "0";
            tb43.Text = "0";
            tb44.Text = "0";
            tb45.Text = "";

            tb46.Text = "";
            tb47.Text = "";
            tb48.Text = "";
            tb49.Text = "";
            tb50.Text = "";

            tb51.Text = "";
            tb52.Text = "";
            tb53.Text = "";
            tb54.Text = "0";
            tb55.Text = "0";

            tb56.Text = "0";
            tb57.Text = "";
            tb58.Text = "0";
            tb59.Text = "";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;

            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
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
            bt.Text = "" + txtSua + "";

            btok.Show();
            btdong.Show();

            tb1.Enabled = true;
            tb2.Enabled = true;
            tb3.Enabled = true;
            tb4.Enabled = true;
            tb5.Enabled = true;

            tb6.Enabled = true;
            tb7.Enabled = true;
            tb8.Enabled = true;
            tb9.Enabled = true;
            tb10.Enabled = true;

            tb11.Enabled = true;
            tb12.Enabled = true;
            tb13.Enabled = true;
            tb14.Enabled = true;
            tb15.Enabled = true;

            tb16.Enabled = true;
            tb17.Enabled = true;
            tb18.Enabled = true;
            cb19.Enabled = true;
            tb20.Enabled = true;

            tb21.Enabled = true;
            tb22.Enabled = true;
            tb23.Enabled = true;
            tb24.Enabled = true;
            tb25.Enabled = true;

            tb26.Enabled = true;
            tb27.Enabled = true;
            tb28.Enabled = true;
            tb39.Enabled = true;
            tb30.Enabled = true;

            tb31.Enabled = true;
            tb32.Enabled = true;
            tb33.Enabled = true;
            tb34.Enabled = true;
            tb35.Enabled = true;

            tb36.Enabled = true;
            tb37.Enabled = true;
            tb38.Enabled = true;
            tb39.Enabled = true;
            tb40.Enabled = true;

            tb41.Enabled = true;
            tb42.Enabled = true;
            tb43.Enabled = true;
            tb44.Enabled = true;
            tb45.Enabled = true;

            tb46.Enabled = true;
            tb47.Enabled = true;
            tb48.Enabled = true;
            tb49.Enabled = true;
            tb50.Enabled = true;

            tb51.Enabled = true;
            tb52.Enabled = true;
            tb53.Enabled = true;
            tb54.Enabled = true;
            tb55.Enabled = true;

            tb56.Enabled = true;
            tb57.Enabled = true;
            tb58.Enabled = true;
            tb59.Enabled = true;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
            //khóa mã
            DialogResult dr = MessageBox.Show("Bạn không thể sửa số sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                tb7.Enabled = false;
            }
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1DF5 fr = new Form1DF5();
            fr.ShowDialog();

            string dl1 = Form1DF5.DL.t1;
            if (dl1 != string.Empty)
                Get_DL();

            if (tb1.Text == "")
            {
                LoadData();
                hienthi();
            }

        }
        public void Get_DL()
        {
            tb1.Text = Form1DF5.DL.t1;
            tb2.Text = Form1DF5.DL.t2;
            tb3.Text = Form1DF5.DL.t3;
            tb4.Text = Form1DF5.DL.t4;
            //tb5.Text = Form1DF5.DL.t2;

            tb6.Text = Form1DF5.DL.t6;
            tb7.Text = Form1DF5.DL.t7;
            tb8.Text = Form1DF5.DL.t8;
            tb9.Text = Form1DF5.DL.t9;
            tb10.Text = Form1DF5.DL.t10;

            tb11.Text = Form1DF5.DL.t11;
            tb12.Text = Form1DF5.DL.t12;
            tb13.Text = Form1DF5.DL.t13;
            tb14.Text = Form1DF5.DL.t14;
            tb15.Text = Form1DF5.DL.t15;

            //tb16.Text = Form1DF5.DL.t2;
            tb17.Text = Form1DF5.DL.t17;
            tb18.Text = Form1DF5.DL.t18;
            cb19.Text = Form1DF5.DL.t19;
            tb20.Text = Form1DF5.DL.t20;

            tb21.Text = Form1DF5.DL.t21;
            tb22.Text = Form1DF5.DL.t22;
            tb23.Text = Form1DF5.DL.t23;
            tb24.Text = Form1DF5.DL.t24;
            if (tb27.Text != "" && tb17.Text != "")
            {
                tb25.Text = (float.Parse(Form1DF5.DL.t21) * float.Parse(Form1DF5.DL.t17)).ToString();
            }
            else
            {
                tb25.Text = "";
            }
            tb25.Text = Form1DF5.DL.t25;

            tb26.Text = Form1DF5.DL.t26;
            tb27.Text = Form1DF5.DL.t27;
            tb28.Text = Form1DF5.DL.t28;
            tb39.Text = Form1DF5.DL.t29;
            tb30.Text = Form1DF5.DL.t30;

            tb31.Text = Form1DF5.DL.t31;
            tb32.Text = Form1DF5.DL.t32;
            tb33.Text = Form1DF5.DL.t33;
            tb34.Text = Form1DF5.DL.t34;
            tb35.Text = Form1DF5.DL.t35;

            tb36.Text = Form1DF5.DL.t36;
            tb37.Text = Form1DF5.DL.t37;
            tb38.Text = Form1DF5.DL.t38;
            tb39.Text = Form1DF5.DL.t39;
            tb40.Text = Form1DF5.DL.t40;

            tb41.Text = Form1DF5.DL.t41;
            tb42.Text = Form1DF5.DL.t42;
            tb43.Text = Form1DF5.DL.t43;
            tb44.Text = Form1DF5.DL.t44;
            //tb45.Text = Form1DF5.DL.t2;

            tb46.Text = Form1DF5.DL.t46;
            tb47.Text = Form1DF5.DL.t47;
            tb48.Text = Form1DF5.DL.t48;
            tb49.Text = Form1DF5.DL.t49;
            tb50.Text = Form1DF5.DL.t50;

            tb51.Text = Form1DF5.DL.t51;
            tb52.Text = Form1DF5.DL.t52;
            tb53.Text = Form1DF5.DL.t53;
            tb54.Text = Form1DF5.DL.t54;
            tb55.Text = Form1DF5.DL.t55;

            tb56.Text = Form1DF5.DL.t56;
            if (tb55.Text != "" && tb59.Text != "")
            {
                tb57.Text = (float.Parse(Form1DF5.DL.t55) * float.Parse(Form1DF5.DL.t59)).ToString();
            }
            else
            {
                tb57.Text = "";
            }
            tb58.Text = Form1DF5.DL.t58;
            tb59.Text = Form1DF5.DL.t59;

            lblEditBy.Text = Form1DF5.DL.t60;

        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            f6ToolStripMenuItem.Checked = true;
            MessageBox.Show("" + txtText1 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bt.Text = "COPY";
            string a = tb1.Text;
            if (a == "")
            {
                MessageBox.Show("" + txtNodata + "");
                return;
            }
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
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1DF7 fr = new Form1DF7();
            fr.ShowDialog();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f11LoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkNofication();
            LoadData();
            hienthi();

            btok.Hide();
            btdong.Hide();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "" + txtDuyet + "";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            checkNofication();
            check();
            if (f2ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.PROD1C(K_NO, C_NO, K_NO_O, DEPT, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3, UNIT, TRANS, BUNIT, CUNIT, PRICE, QDATE, M_TRAN, W_CHECK, QTYSTORE, QTYSAF, P_WEG, QTYSTORE_B, QTYSTORE_BB, BASEDATE, INDATE, PLACE, OUTDATE, MEMO1, MEMO2, MEMO3, MEMO4, PRICE1, PRICE2, PRICE4, QTY01, PRICE5, PRICE6, PRICE7, PRICE8, PRICE3, DKIND, QDATE1, QDATE2, QDATE4, QDATE5, QDATE6, QDATE7, QDATE8, QDATE3, COST, COST_NEW, COST_AVG,USR_NAME ) " +
                    "values(@K_NO, @C_NO, @K_NO_O, @DEPT, @P_NO, @P_NAME, @P_NAME1, @P_NAME2, @P_NAME3, @UNIT, @TRANS, @BUNIT, @CUNIT, @PRICE, @QDATE, @M_TRAN, @W_CHECK, @QTYSTORE, @QTYSAF, @P_WEG, @QTYSTORE_B, @QTYSTORE_BB, @BASEDATE, @INDATE, @PLACE, @OUTDATE, @MEMO1, @MEMO2, @MEMO3, @MEMO4, @PRICE1, @PRICE2, @PRICE4, @QTY01, @PRICE5, @PRICE6, @PRICE7, @PRICE8, @PRICE3, @DKIND, @QDATE1, @QDATE2, @QDATE4, @QDATE5, @QDATE6, @QDATE7, @QDATE8, @QDATE3, @COST, @COST_NEW, @COST_AVG,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                //cm.Parameters.AddWithValue("@", tb2.Text);
                cm.Parameters.AddWithValue("@C_NO", tb3.Text);
                cm.Parameters.AddWithValue("@K_NO_O", tb4.Text);
                //cm.Parameters.AddWithValue("@", tb5.Text);

                cm.Parameters.AddWithValue("@DEPT", tb6.Text);
                cm.Parameters.AddWithValue("@P_NO", tb7.Text);
                cm.Parameters.AddWithValue("@P_NAME", tb8.Text);
                cm.Parameters.AddWithValue("@P_NAME1", tb9.Text);
                cm.Parameters.AddWithValue("@P_NAME2", tb10.Text);

                cm.Parameters.AddWithValue("@P_NAME3", tb11.Text);
                cm.Parameters.AddWithValue("@UNIT", tb12.Text);
                cm.Parameters.AddWithValue("@TRANS", float.Parse(tb13.Text));
                cm.Parameters.AddWithValue("@BUNIT", tb14.Text);
                cm.Parameters.AddWithValue("@CUNIT", tb15.Text);

                //cm.Parameters.AddWithValue("@", tb16.Text);
                cm.Parameters.AddWithValue("@PRICE", float.Parse(tb17.Text));
                cm.Parameters.AddWithValue("@QDATE", conN.formatstr2(a));
                cm.Parameters.AddWithValue("@M_TRAN", cb19.SelectedItem.ToString());
                cm.Parameters.AddWithValue("@W_CHECK", tb20.Text);

                cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb21.Text));
                cm.Parameters.AddWithValue("@QTYSAF", float.Parse(tb22.Text));
                cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb23.Text));
                cm.Parameters.AddWithValue("@QTYSTORE_B", float.Parse(tb24.Text));
                //cm.Parameters.AddWithValue("@", tb25.Text);


                cm.Parameters.AddWithValue("@QTYSTORE_BB", float.Parse(tb26.Text));
                //cm.Parameters.AddWithValue("@", tb27.Text);
                cm.Parameters.AddWithValue("@BASEDATE", conN.formatstr2(b));
                cm.Parameters.AddWithValue("@INDATE", conN.formatstr2(c));
                cm.Parameters.AddWithValue("@PLACE", tb30.Text);

                cm.Parameters.AddWithValue("@OUTDATE", conN.formatstr2(d));
                cm.Parameters.AddWithValue("@MEMO1", tb32.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb33.Text);
                cm.Parameters.AddWithValue("@MEMO3", tb34.Text);
                cm.Parameters.AddWithValue("@MEMO4", tb35.Text);

                cm.Parameters.AddWithValue("@PRICE1", float.Parse(tb36.Text));
                cm.Parameters.AddWithValue("@PRICE2", float.Parse(tb37.Text));
                cm.Parameters.AddWithValue("@PRICE4", float.Parse(tb38.Text));
                cm.Parameters.AddWithValue("@QTY01", float.Parse(tb39.Text));
                cm.Parameters.AddWithValue("@PRICE5", float.Parse(tb40.Text));

                cm.Parameters.AddWithValue("@PRICE6", float.Parse(tb41.Text));
                cm.Parameters.AddWithValue("@PRICE7", float.Parse(tb42.Text));
                cm.Parameters.AddWithValue("@PRICE8", float.Parse(tb43.Text));
                cm.Parameters.AddWithValue("@PRICE3", float.Parse(tb44.Text));
                cm.Parameters.AddWithValue("@DKIND", tb45.Text);
                //string a, b, c, d, f, g, h, i, j, k, l, m;
                cm.Parameters.AddWithValue("@QDATE1", conN.formatstr2(f));
                cm.Parameters.AddWithValue("@QDATE2", conN.formatstr2(g));
                cm.Parameters.AddWithValue("@QDATE4", conN.formatstr2(h));
                cm.Parameters.AddWithValue("@QDATE5", conN.formatstr2(i));
                cm.Parameters.AddWithValue("@QDATE6", conN.formatstr2(j));

                cm.Parameters.AddWithValue("@QDATE7", conN.formatstr2(k));
                cm.Parameters.AddWithValue("@QDATE8", conN.formatstr2(l));
                cm.Parameters.AddWithValue("@QDATE3", conN.formatstr2(m));
                cm.Parameters.AddWithValue("@COST", float.Parse(tb54.Text));
                cm.Parameters.AddWithValue("@COST_NEW", float.Parse(tb55.Text));

                cm.Parameters.AddWithValue("@COST_AVG", float.Parse(tb56.Text));
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);


                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb7.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (cb19.Text == string.Empty)
                {

                    MessageBox.Show("" + txtText + "");
                    return;
                }

                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                    hienthi();

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f9ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                string ma = tb7.Text;
                if (ma == "")
                {
                    MessageBox.Show("" + txtNodata + "");
                    return;
                }
                try
                {
                    con = new SqlConnection(st);
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandText = "delete from PROD1C where P_NO ='" + ma + "'";
                    cm.ExecuteNonQuery();
                    con.Close();

                    LoadData();
                    hienthi();

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f9ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;

                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                con = new SqlConnection(st);
                con.Open();
                string st1 = "update dbo.PROD1C set K_NO=@K_NO, C_NO=@C_NO, K_NO_O=@K_NO_O, DEPT=@DEPT, P_NO=@P_NO, P_NAME=@P_NAME, P_NAME1=@P_NAME1, P_NAME2=@P_NAME2, P_NAME3=@P_NAME3, UNIT=@UNIT, TRANS=@TRANS, BUNIT=@BUNIT, CUNIT=@CUNIT, PRICE=@PRICE, QDATE=@QDATE, M_TRAN=@M_TRAN, W_CHECK=@W_CHECK, QTYSTORE=@QTYSTORE, QTYSAF=@QTYSAF, P_WEG=@P_WEG, QTYSTORE_B=@QTYSTORE_B, BASEDATE=@BASEDATE, INDATE=@INDATE, PLACE=@PLACE, OUTDATE=@OUTDATE," +
                    "MEMO1=@MEMO1, MEMO2=@MEMO2, MEMO3=@MEMO3, MEMO4=@MEMO4, PRICE1=@PRICE1, PRICE2=@PRICE2, PRICE4=@PRICE4, QTY01=@QTY01, PRICE5=@PRICE5, PRICE6=@PRICE6, PRICE7=@PRICE7, PRICE8=@PRICE8, PRICE3=@PRICE3, DKIND=@DKIND, QDATE1=@QDATE1, QDATE2=@QDATE2, QDATE4=@QDATE4, QDATE5=@QDATE5, QDATE6=@QDATE6, QDATE7=@QDATE7, QDATE8=@QDATE8, QDATE3=@QDATE3, COST=@COST, COST_NEW=@COST_NEW, COST_AVG=@COST_AVG,USR_NAME = @USR_NAME where P_NO = @P_NO";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                //cm.Parameters.AddWithValue("@", tb2.Text);
                cm.Parameters.AddWithValue("@C_NO", tb3.Text);
                cm.Parameters.AddWithValue("@K_NO_O", tb4.Text);
                //cm.Parameters.AddWithValue("@", tb5.Text);

                cm.Parameters.AddWithValue("@DEPT", tb6.Text);
                cm.Parameters.AddWithValue("@P_NO", tb7.Text);
                cm.Parameters.AddWithValue("@P_NAME", tb8.Text);
                cm.Parameters.AddWithValue("@P_NAME1", tb9.Text);
                cm.Parameters.AddWithValue("@P_NAME2", tb10.Text);

                cm.Parameters.AddWithValue("@P_NAME3", tb11.Text);
                cm.Parameters.AddWithValue("@UNIT", tb12.Text);
                cm.Parameters.AddWithValue("@TRANS", float.Parse(tb13.Text));
                cm.Parameters.AddWithValue("@BUNIT", tb14.Text);
                cm.Parameters.AddWithValue("@CUNIT", tb15.Text);

                //cm.Parameters.AddWithValue("@", tb16.Text);
                cm.Parameters.AddWithValue("@PRICE", float.Parse(tb17.Text));
                cm.Parameters.AddWithValue("@QDATE", conN.formatstr2(a));
                cm.Parameters.AddWithValue("@M_TRAN", cb19.SelectedItem.ToString());
                cm.Parameters.AddWithValue("@W_CHECK", tb20.Text);

                cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb21.Text));
                cm.Parameters.AddWithValue("@QTYSAF", float.Parse(tb22.Text));
                cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb23.Text));
                cm.Parameters.AddWithValue("@QTYSTORE_B", float.Parse(tb24.Text));
                //cm.Parameters.AddWithValue("@", tb25.Text);


                cm.Parameters.AddWithValue("@QTYSTORE_BB", float.Parse(tb26.Text));
                //cm.Parameters.AddWithValue("@", tb27.Text);
                cm.Parameters.AddWithValue("@BASEDATE", conN.formatstr2(b));
                cm.Parameters.AddWithValue("@INDATE", conN.formatstr2(c));
                cm.Parameters.AddWithValue("@PLACE", tb30.Text);

                cm.Parameters.AddWithValue("@OUTDATE", conN.formatstr2(d));
                cm.Parameters.AddWithValue("@MEMO1", tb32.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb33.Text);
                cm.Parameters.AddWithValue("@MEMO3", tb34.Text);
                cm.Parameters.AddWithValue("@MEMO4", tb35.Text);

                cm.Parameters.AddWithValue("@PRICE1", float.Parse(tb36.Text));
                cm.Parameters.AddWithValue("@PRICE2", float.Parse(tb37.Text));
                cm.Parameters.AddWithValue("@PRICE4", float.Parse(tb38.Text));
                cm.Parameters.AddWithValue("@QTY01", float.Parse(tb39.Text));
                cm.Parameters.AddWithValue("@PRICE5", float.Parse(tb40.Text));

                cm.Parameters.AddWithValue("@PRICE6", float.Parse(tb41.Text));
                cm.Parameters.AddWithValue("@PRICE7", float.Parse(tb42.Text));
                cm.Parameters.AddWithValue("@PRICE8", float.Parse(tb43.Text));
                cm.Parameters.AddWithValue("@PRICE3", float.Parse(tb44.Text));
                cm.Parameters.AddWithValue("@DKIND", tb45.Text);
                //string a, b, c, d, f, g, h, i, j, k, l, m;
                cm.Parameters.AddWithValue("@QDATE1", conN.formatstr2(f));
                cm.Parameters.AddWithValue("@QDATE2", conN.formatstr2(g));
                cm.Parameters.AddWithValue("@QDATE4", conN.formatstr2(h));
                cm.Parameters.AddWithValue("@QDATE5", conN.formatstr2(i));
                cm.Parameters.AddWithValue("@QDATE6", conN.formatstr2(j));

                cm.Parameters.AddWithValue("@QDATE7", conN.formatstr2(k));
                cm.Parameters.AddWithValue("@QDATE8", conN.formatstr2(l));
                cm.Parameters.AddWithValue("@QDATE3", conN.formatstr2(m));
                cm.Parameters.AddWithValue("@COST", float.Parse(tb54.Text));
                cm.Parameters.AddWithValue("@COST_NEW", float.Parse(tb55.Text));

                cm.Parameters.AddWithValue("@COST_AVG", float.Parse(tb56.Text));
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);

                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb7.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (cb19.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText + "");
                    return;
                }
                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                    hienthi();

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f9ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;
                    //mở khóa
                    tb7.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {

                check();
                string SQL = "select P_NO from PROD1C";
                DataTable dt = conN.readdata(SQL);

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (a.ToString() == dr["P_NO"].ToString())
                        {
                            DialogResult er = MessageBox.Show("" + txtText4 + "", "" + txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            if (er == DialogResult.OK)
                                tb7.Focus();
                        }
                    }
                }
                catch
                {

                }

                con = new SqlConnection(st);
                con.Open();
                string st1 = "insert into dbo.PROD1C(K_NO, C_NO, K_NO_O, DEPT, P_NO, P_NAME, P_NAME1, P_NAME2, P_NAME3, UNIT, TRANS, BUNIT, CUNIT, PRICE, QDATE, M_TRAN, W_CHECK, QTYSTORE, QTYSAF, P_WEG, QTYSTORE_B, QTYSTORE_BB, BASEDATE, INDATE, PLACE, OUTDATE, MEMO1, MEMO2, MEMO3, MEMO4, PRICE1, PRICE2, PRICE4, QTY01, PRICE5, PRICE6, PRICE7, PRICE8, PRICE3, DKIND, QDATE1, QDATE2, QDATE4, QDATE5, QDATE6, QDATE7, QDATE8, QDATE3, COST, COST_NEW, COST_AVG,USR_NAME ) " +
                     "values(@K_NO, @C_NO, @K_NO_O, @DEPT, @P_NO, @P_NAME, @P_NAME1, @P_NAME2, @P_NAME3, @UNIT, @TRANS, @BUNIT, @CUNIT, @PRICE, @QDATE, @M_TRAN, @W_CHECK, @QTYSTORE, @QTYSAF, @P_WEG, @QTYSTORE_B, @QTYSTORE_BB, @BASEDATE, @INDATE, @PLACE, @OUTDATE, @MEMO1, @MEMO2, @MEMO3, @MEMO4, @PRICE1, @PRICE2, @PRICE4, @QTY01, @PRICE5, @PRICE6, @PRICE7, @PRICE8, @PRICE3, @DKIND, @QDATE1, @QDATE2, @QDATE4, @QDATE5, @QDATE6, @QDATE7, @QDATE8, @QDATE3, @COST, @COST_NEW, @COST_AVG,@USR_NAME)";
                SqlCommand cm = new SqlCommand(st1, con);

                cm.Parameters.AddWithValue("@K_NO", tb1.Text);
                //cm.Parameters.AddWithValue("@", tb2.Text);
                cm.Parameters.AddWithValue("@C_NO", tb3.Text);
                cm.Parameters.AddWithValue("@K_NO_O", tb4.Text);
                //cm.Parameters.AddWithValue("@", tb5.Text);

                cm.Parameters.AddWithValue("@DEPT", tb6.Text);
                cm.Parameters.AddWithValue("@P_NO", tb7.Text);
                cm.Parameters.AddWithValue("@P_NAME", tb8.Text);
                cm.Parameters.AddWithValue("@P_NAME1", tb9.Text);
                cm.Parameters.AddWithValue("@P_NAME2", tb10.Text);

                cm.Parameters.AddWithValue("@P_NAME3", tb11.Text);
                cm.Parameters.AddWithValue("@UNIT", tb12.Text);
                cm.Parameters.AddWithValue("@TRANS", float.Parse(tb13.Text));
                cm.Parameters.AddWithValue("@BUNIT", tb14.Text);
                cm.Parameters.AddWithValue("@CUNIT", tb15.Text);

                //cm.Parameters.AddWithValue("@", tb16.Text);
                cm.Parameters.AddWithValue("@PRICE", float.Parse(tb17.Text));
                cm.Parameters.AddWithValue("@QDATE", conN.formatstr2(a));
                cm.Parameters.AddWithValue("@M_TRAN", cb19.SelectedItem.ToString());
                cm.Parameters.AddWithValue("@W_CHECK", tb20.Text);

                cm.Parameters.AddWithValue("@QTYSTORE", float.Parse(tb21.Text));
                cm.Parameters.AddWithValue("@QTYSAF", float.Parse(tb22.Text));
                cm.Parameters.AddWithValue("@P_WEG", float.Parse(tb23.Text));
                cm.Parameters.AddWithValue("@QTYSTORE_B", float.Parse(tb24.Text));
                //cm.Parameters.AddWithValue("@", tb25.Text);


                cm.Parameters.AddWithValue("@QTYSTORE_BB", float.Parse(tb26.Text));
                //cm.Parameters.AddWithValue("@", tb27.Text);
                cm.Parameters.AddWithValue("@BASEDATE", conN.formatstr2(b));
                cm.Parameters.AddWithValue("@INDATE", conN.formatstr2(c));
                cm.Parameters.AddWithValue("@PLACE", tb30.Text);

                cm.Parameters.AddWithValue("@OUTDATE", conN.formatstr2(d));
                cm.Parameters.AddWithValue("@MEMO1", tb32.Text);
                cm.Parameters.AddWithValue("@MEMO2", tb33.Text);
                cm.Parameters.AddWithValue("@MEMO3", tb34.Text);
                cm.Parameters.AddWithValue("@MEMO4", tb35.Text);

                cm.Parameters.AddWithValue("@PRICE1", float.Parse(tb36.Text));
                cm.Parameters.AddWithValue("@PRICE2", float.Parse(tb37.Text));
                cm.Parameters.AddWithValue("@PRICE4", float.Parse(tb38.Text));
                cm.Parameters.AddWithValue("@QTY01", float.Parse(tb39.Text));
                cm.Parameters.AddWithValue("@PRICE5", float.Parse(tb40.Text));

                cm.Parameters.AddWithValue("@PRICE6", float.Parse(tb41.Text));
                cm.Parameters.AddWithValue("@PRICE7", float.Parse(tb42.Text));
                cm.Parameters.AddWithValue("@PRICE8", float.Parse(tb43.Text));
                cm.Parameters.AddWithValue("@PRICE3", float.Parse(tb44.Text));
                cm.Parameters.AddWithValue("@DKIND", tb45.Text);
                //string a, b, c, d, f, g, h, i, j, k, l, m;
                cm.Parameters.AddWithValue("@QDATE1", conN.formatstr2(f));
                cm.Parameters.AddWithValue("@QDATE2", conN.formatstr2(g));
                cm.Parameters.AddWithValue("@QDATE4", conN.formatstr2(h));
                cm.Parameters.AddWithValue("@QDATE5", conN.formatstr2(i));
                cm.Parameters.AddWithValue("@QDATE6", conN.formatstr2(j));

                cm.Parameters.AddWithValue("@QDATE7", conN.formatstr2(k));
                cm.Parameters.AddWithValue("@QDATE8", conN.formatstr2(l));
                cm.Parameters.AddWithValue("@QDATE3", conN.formatstr2(m));
                cm.Parameters.AddWithValue("@COST", float.Parse(tb54.Text));
                cm.Parameters.AddWithValue("@COST_NEW", float.Parse(tb55.Text));

                cm.Parameters.AddWithValue("@COST_AVG", float.Parse(tb56.Text));
                cm.Parameters.AddWithValue("@USR_NAME", lbUserName.Text);


                if (tb1.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (tb7.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (cb19.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText + "");
                    return;
                }
                try
                {

                    cm.ExecuteNonQuery();
                    con.Close();
                    LoadData();
                    hienthi();

                    btok.Hide();
                    btdong.Hide();

                    f1ToolStripMenuItem.Enabled = false;
                    f2ToolStripMenuItem.Enabled = true;
                    f3ToolStripMenuItem.Enabled = true;
                    f4ToolStripMenuItem.Enabled = true;
                    f5ToolStripMenuItem.Enabled = true;
                    f6ToolStripMenuItem.Enabled = true;
                    f7ToolStripMenuItem.Enabled = true;
                    f9ToolStripMenuItem.Enabled = true;
                    f10ToolStripMenuItem.Enabled = false;
                    f12ToolStripMenuItem.Enabled = true;

                    btdau.Enabled = true;
                    bttruoc.Enabled = true;
                    btsau.Enabled = true;
                    btketthuc.Enabled = true;
                    bt.Text = "" + txtDuyet + "";

                    f2ToolStripMenuItem.Checked = false;
                    f3ToolStripMenuItem.Checked = false;
                    f4ToolStripMenuItem.Checked = false;
                    f6ToolStripMenuItem.Checked = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            LoadData();
            hienthi();
            btok.Hide();
            btdong.Hide();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            bt.Text = "NÚT DUYỆT";

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }


        public string change2(string st)
        {
            string str1 = "";
            string sc1, sc2, sc3;
            try
            {
                if (st.ToString() != string.Empty)
                {
                    sc1 = st.Substring(0, 4);
                    sc2 = st.Substring(st.Length - 2, 2);
                    sc3 = st.Substring(5, 2);
                    str1 = sc1 + sc3 + sc2;
                }
                else str1 = "";

            }
            catch
            {

            }
            return str1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        private void tb4_TextChanged_1(object sender, EventArgs e)
        {
            if (tb4.Text != "")
            {
                string S = "SELECT K_NAME FROM KIND1C WHERE K_NO = '" + tb4.Text + "'";
                DataTable dt = conN.readdata(S);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tb5.Text = dr["K_NAME"].ToString();
                    }
                }
            }
            else
                tb5.Text = "";
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

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb59, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb4, sender, e);
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
            tab(tb14, tb16, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {

            conN.tab_DOWN(tb16, tb18, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cb19.Focus();
            }
        }

        private void cb19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb20.Focus();
            }
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP(tb18, tb21, sender, e);
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
            tab(tb22, tb24, sender, e);
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
            conN.tab_DOWN(tb26, tb28, sender, e);
        }

        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_DOWN(tb27, tb29, sender, e);
        }

        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP(tb28, tb30, sender, e);
        }

        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb29, tb31, sender, e);
        }

        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb30, tb1, sender, e);
        }

        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP(tb31, tb33, sender, e);
        }

        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb32, tb34, sender, e);
        }

        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb33, tb35, sender, e);
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
            conN.tab_DOWN(tb44, tb46, sender, e);
        }

        private void tb46_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_DOWN(tb45, tb47, sender, e);
        }

        private void tb47_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb46, tb48, sender, e);
        }

        private void tb48_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb47, tb49, sender, e);
        }

        private void tb49_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb48, tb50, sender, e);
        }

        private void tb50_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb49, tb51, sender, e);
        }

        private void tb51_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb50, tb52, sender, e);
        }

        private void tb52_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP_DOWN(tb51, tb53, sender, e);
        }
        private void tb53_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP(tb52, tb32, sender, e);
        }
        private void tb54_KeyDown(object sender, KeyEventArgs e)
        {
            conN.tab_UP(tb53, tb55, sender, e);
        }

        private void tb55_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb54, tb56, sender, e);
        }

        private void tb56_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb55, tb57, sender, e);
        }

        private void tb57_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb56, tb54, sender, e);
        }
        private void tb58_KeyDown(object sender, KeyEventArgs e)
        {

            tab(tb58, tb59, sender, e);
        }
        private void tb59_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb59, tb58, sender, e);
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSeachKIND fr = new FormSeachKIND();
                fr.ShowDialog();
            }


            string dl1 = FormSeachKIND.DL.K_NO;
            if (dl1 != string.Empty)
                Get_tb1();

            if (tb1.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }

        }
        public void Get_tb1()
        {
            tb1.Text = FormSeachKIND.DL.K_NO;
            tb2.Text = FormSeachKIND.DL.K_NAME;

        }

        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSeachKIND fr = new FormSeachKIND();
                fr.ShowDialog();
            }

            string dl1 = FormSeachKIND.DL.K_NO;
            if (dl1 != string.Empty)
                Get_tb4();

            if (tb4.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }

        public void Get_tb4()
        {
            tb4.Text = FormSeachKIND.DL.K_NO;
            tb5.Text = FormSeachKIND.DL.K_NAME;
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                Form1BF5 fr = new Form1BF5();
                fr.ShowDialog();
            }

            string dl1 = Form1BF5.Form1D_DL.c1;
            if (dl1 != string.Empty)
                Get_tb3();

            if (tb3.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }
        public void Get_tb3()
        {
            tb3.Text = Form1BF5.Form1D_DL.c1;
        }

        private void tb6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                Form1BF5 fr = new Form1BF5();
                fr.ShowDialog();
            }

            string dl1 = Form1BF5.Form1D_DL.c1;
            if (dl1 != string.Empty)
                Get_tb3();

            if (tb6.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }
        public void Get_tb6()
        {
            tb6.Text = Form1BF5.Form1D_DL.c1;
        }

        private void tb32_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();
                tb32.Text = FormSearchLeather2.ID.M_NAME;

                if (tb32.Text == string.Empty)
                {
                    LoadData();
                    hienthi();
                }
            }
        }
        private void tb33_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();
                tb33.Text = FormSearchLeather2.ID.M_NAME;
            }
            if (tb33.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }

        private void tb34_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();
                tb34.Text = FormSearchLeather2.ID.M_NAME;
            }
            if (tb34.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }
        private void tb35_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((f2ToolStripMenuItem.Checked == true) || (f4ToolStripMenuItem.Checked == true) || (f6ToolStripMenuItem.Checked == true))
            {
                FormSearchLeather2 fr = new FormSearchLeather2();
                fr.ShowDialog();
                tb35.Text = FormSearchLeather2.ID.M_NAME;
            }

            if (tb35.Text == string.Empty)
            {
                LoadData();
                hienthi();
            }
        }

        private void tb25_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                tb25.Text = (float.Parse(tb17.Text) * float.Parse(tb21.Text)).ToString();
            }
        }

        private void tb27_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                tb27.Text = tb17.Text;
            }
        }

        private void tb57_Click(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                tb57.Text = (float.Parse(tb17.Text) * float.Parse(tb54.Text)).ToString();
            }
        }
        void check()
        {
            if (conN.Check_MaskedText(tb18) == true)
            {
                a = tb18.Text;
            }
            if (conN.Check_MaskedText(tb28) == true)
            {
                b = tb21.Text;
            }
            if (conN.Check_MaskedText(tb29) == true)
            {
                c = tb29.Text;
            }
            if (conN.Check_MaskedText(tb31) == true)
            {
                d = tb31.Text;
            }
            if (conN.Check_MaskedText(tb46) == true)
            {
                f = tb46.Text;
            }
            if (conN.Check_MaskedText(tb47) == true)
            {
                g = tb47.Text;
            }
            if (conN.Check_MaskedText(tb48) == true)
            {
                h = tb48.Text;
            }
            if (conN.Check_MaskedText(tb49) == true)
            {
                i = tb49.Text;
            }
            if (conN.Check_MaskedText(tb50) == true)
            {
                j = tb50.Text;
            }
            if (conN.Check_MaskedText(tb51) == true)
            {
                k = tb51.Text;
            }
            if (conN.Check_MaskedText(tb52) == true)
            {
                l = tb52.Text;
            }
            if (conN.Check_MaskedText(tb53) == true)
            {
                m = tb53.Text;
            }
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tb18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb18.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb28_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb28.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb29.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb31_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb31.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb46_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb46.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb47_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb47.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb48_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb48.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb49_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb49.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb50_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb50.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb51_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb51.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb52_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb52.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void tb53_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb53.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
