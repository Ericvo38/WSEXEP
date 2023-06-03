using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using WTERP.WSEXE.FormSearch;
using System.Drawing;
using System.Linq;
using LibraryCalender;

namespace WTERP
{
    public partial class Form1I : Form
    {
        DataProvider conn = new DataProvider();
        BindingSource source = new BindingSource();
        int Function = 0;
        DataTable dtDGV;
        public static string Where;
        public Form1I()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
            tb3.LostFocus += new EventHandler(this.tb3_LostFocus);
        }
        private void tb3_LostFocus(object sender, EventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true)
            {
                checkNofication();
                if (conn.checkExists("SELECT WS_NO FROM QUOH WHERE WS_NO = '" + tb3.Text + "' ") == true)
                {
                    MessageBox.Show("" + txtText9 + "", "" + txtThongBao + "");
                    tb3.Focus();
                }
            }
        }
        
        string a = "";
        string b = "";
        string c = "";
        public static string Get_WS_NO;

        #region Load Data 
        private void Form1Iqlbaogiakhachhang_Load(object sender, EventArgs e) // Load main Form 
        {
            getInfo();
            Where = string.Empty;
            LoadFirst();
        }
        private void LoadFirst()
        {
            Function = 0;
            conn.CheckLoad(menuStrip1);
            checkNofication();

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            bt.ButtonViews(0);
            btok.Hide();
            btdong.Hide();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
            tb3.Enabled = true;

            LoadData();
            LoadDGV1();
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            lbUserName.Text = frmLogin.ID_NAME; // Get name User
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
            btndateNow.Text = conn.getDateNow(); // get getDateNow
        }
        public void LoadData() // Load Textbox First 
        {
            string SQL = "SELECT TOP 1000 * FROM QUOH Where 1=1 " + Where + " ORDER BY WS_DATE DESC";
            DataTable dt = conn.readdata(SQL);
            source.DataSource = dt;
            ShowRecord();
        }
        private DataRow currenRow
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
        private void ShowRecord() // Show texbox 
        {
            tb1.Text = conn.formatstr2(currenRow["WS_DATE"].ToString());
            tb2.Text = currenRow["WS_KIND"].ToString();
            tb3.Text = currenRow["WS_NO"].ToString();
            tb4.Text = currenRow["PAY_PLACE"].ToString();
            tb5.Text = currenRow["C_NO"].ToString();

            tb6.Text = currenRow["C_NAME"].ToString();
            tb7.Text = "";
            tb8.Text = currenRow["C_NAME"].ToString();
            tb9.Text = currenRow["SPEAK"].ToString();
            tb10.Text = currenRow["SPEAK_CC"].ToString();

            tb11.Text = currenRow["FAX"].ToString();
            tb12.Text = currenRow["W_FROM"].ToString();
            tb13.Text = currenRow["W_CC"].ToString();
            tb14.Text = currenRow["W_CHECK"].ToString();
            //tb15.Text = currenRow["SH_NO"].ToString();

            tb16.Text = conn.formatstr2(currenRow["VA_DATES"].ToString());
            tb17.Text = conn.formatstr2(currenRow["VA_DATE"].ToString());
            tb18.Text = currenRow["PS01"].ToString();
            tb19.Text = currenRow["PS02"].ToString();
            tb20.Text = currenRow["PS03"].ToString();

            tb21.Text = currenRow["MEMO1"].ToString();
            tb22.Text = currenRow["MEMO2"].ToString();
            tb23.Text = currenRow["MEMO3"].ToString();
            tb24.Text = currenRow["MEMO4"].ToString();
            tb25.Text = currenRow["MEMO5"].ToString();

            tb26.Text = currenRow["MEMO6"].ToString();
            tb27.Text = currenRow["MEMO7"].ToString();
            tb28.Text = currenRow["MEMO8"].ToString();
            tb29.Text = currenRow["MEMO9"].ToString();
            tb30.Text = currenRow["MEMO10"].ToString();

            tb31.Text = currenRow["MEMO11"].ToString();
            tb32.Text = currenRow["MEMO12"].ToString();
            tb33.Text = currenRow["MEMO13"].ToString();
            tb34.Text = currenRow["MEMO14"].ToString();
            tb35.Text = currenRow["MEMO15"].ToString();

            tb36.Text = currenRow["MEMO16"].ToString();
            tb37.Text = currenRow["MEMO17"].ToString();
            tb38.Text = currenRow["MEMO18"].ToString();
            tb39.Text = currenRow["MEMO19"].ToString();
            tb40.Text = currenRow["PAY_COND"].ToString();

            tb41.Text = currenRow["MEMO20"].ToString();
            tb42.Text = currenRow["MEMO101"].ToString();
            tb43.Text = currenRow["MEMO102"].ToString();
            tb44.Text = currenRow["MEMO103"].ToString();
            tb45.Text = currenRow["MEMO104"].ToString();

            tb46.Text = currenRow["MEMO105"].ToString();
            tb47.Text = currenRow["MEMO106"].ToString();
            tb48.Text = currenRow["MEMO107"].ToString();
            tb49.Text = currenRow["MEMO108"].ToString();
            tb50.Text = currenRow["MEMO109"].ToString();

            tb51.Text = currenRow["MEMO110"].ToString();
            tb52.Text = currenRow["MEMO201"].ToString();
            tb53.Text = currenRow["MEMO202"].ToString();
            tb54.Text = currenRow["MEMO203"].ToString();
            tb55.Text = currenRow["MEMO204"].ToString();

            tb56.Text = currenRow["MEMO205"].ToString();
            tb57.Text = currenRow["MEMO206"].ToString();
            tb58.Text = currenRow["MEMO207"].ToString();
            tb59.Text = currenRow["MEMO208"].ToString();
            tb60.Text = currenRow["MEMO209"].ToString();

            tb61.Text = currenRow["MEMO301"].ToString();
            tb62.Text = currenRow["MEMO302"].ToString();
            tb63.Text = currenRow["MEMO303"].ToString();
            tb64.Text = currenRow["MEMO304"].ToString();
            tb65.Text = currenRow["MEMO305"].ToString();

            tb66.Text = currenRow["MEMO306"].ToString();
            tb67.Text = currenRow["MEMO307"].ToString();
            tb68.Text = currenRow["MEMO308"].ToString();
            tb69.Text = currenRow["MEMO309"].ToString();
            tb70.Text = currenRow["MEMO310"].ToString();

            lblEditBy.Text = currenRow["USR_NAME"].ToString();
        }
        public void LoadDGV1() // Load DatagridView 
        {
            string SQL = "SELECT NR, P_NO, P_NAME1, MEMO2, P_NAME3, PRICE_C, PRICE, MEMO1, AVGCQ, MEMO, UPDATEKIND,PBT01,PBT02,PBT03,PBT04,P_NAME,UNIT,BUNIT,CUNIT,TRANS,K_NO FROM QUOB WHERE WS_NO ='" + tb3.Text + "'";
            dtDGV = conn.readdata(SQL);
            DGV1.DataSource = dtDGV;
            conn.DGV1(DGV1);
            this.DGV1.Columns["dataGridViewTextBoxColumn3"].Frozen = true;
        }

        #region button dau_truoc_sau_ketthuc
        private void btdau_Click(object sender, EventArgs e) // MoveFirst 
        {
            source.MoveFirst();

            ShowRecord();
            LoadDGV1();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        private void bttruoc_Click(object sender, EventArgs e) //MovePrevious 
        {
            try
            {
                source.MovePrevious();
                ShowRecord();
                LoadDGV1();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        private void btsau_Click(object sender, EventArgs e) //MoveNext 
        {
            try
            {
                source.MoveNext();
                ShowRecord();
                LoadDGV1();

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;
            }
            catch (Exception)
            {

            }
        }
        private void btketthuc_Click(object sender, EventArgs e) //MoveLast 
        {
            source.MoveLast();
            ShowRecord();
            LoadDGV1();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        #endregion

        #endregion

        #region ToolStripMenuItem
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function = 1;
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e) // F2 Adding Quotation 
        {
            Function = 1;

            checkNofication();
            TextAdd();
            LoadDGV1();
            btok.Show();
            btdong.Show();
            bt.ButtonViews(1);

            CheckStripMenuItem();


        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e) // F3 Deleting Quotation 
        {
            Function = 3;

            checkNofication();
            bt.ButtonViews(2);
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = true;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e) // F4 Repairing Quotation 
        {
            Function = 4;

            checkNofication();
            bt.ButtonViews(3);
            btok.Show();
            btdong.Show();
            tb3.Enabled = false;

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = true;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e) // F5 Searching Quotation 
        {
            Function = 5;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = true;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            Form1IF5 fr = new Form1IF5();

            fr.UpdataEventHandler += Fr_UpdataEventHandler;
            fr.ShowDialog();
            LoadData();
            source.Position = source.Find("WS_NO", Form1IF5.getBaoGia.WS_NO);
            ShowRecord();
            tb3.Text = Form1IF5.getBaoGia.WS_NO;
            LoadDGV1();
            conn.DGV1(DGV1);
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e) // F6 Coppy Quotation 
        {
            Function = 6;

            f6ToolStripMenuItem.Checked = true;
            datagridcoppy = (DataTable)(DGV1.DataSource);
            checkNofication();
            Text1 = tb3.Text;
            Form1IF6 fm = new Form1IF6();
            fm.ShowDialog();

            tb1.Text = Form1IF6.Date;
            tb2.Text = Form1IF6.type;
            tb3.Text = Form1IF6.Baogia;
            tb14.Text = "N";
            bt.ButtonViews(6);
            btok.Show();
            btdong.Show();

            string a = tb5.Text;
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
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = true;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e) // F7 Printing Quotation 
        {
            Function = 7;

            Get_WS_NO = tb3.Text;
            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = true;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            Form1IF7 fr = new Form1IF7();
            fr.ShowDialog();

        }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e) //F5 Check Quotation
        {
            Function = 9;

            bt.ButtonViews(9);
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = true;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            tb14.Text = "Y";
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e) // Saving 
        {
            Function = 10;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = true;
            f12ToolStripMenuItem.Checked = false;

            btok.PerformClick();
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e) // Close App 
        {
            this.Close();
        }
        #endregion

        #region xxxxx
        
        public void CheckStripMenuItem()
        {
            f1ToolStripMenuItem.Enabled = true;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            f1ToolStripMenuItem.Checked = false;

            f2ToolStripMenuItem.Checked = true;

            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        private void TextAdd()
        {
            this.tb1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.tb2.Text = "V";
            this.tb3.Text = "";
            this.tb4.Text = "";
            this.tb5.Text = "";

            this.tb6.Text = "";
            this.tb7.Text = "";
            this.tb8.Text = "";
            this.tb9.Text = "";
            this.tb10.Text = "";

            this.tb11.Text = "";
            this.tb12.Text = "";
            this.tb13.Text = "";
            this.tb14.Text = "N";
            this.tb14.Enabled = false;
            // this.tb15.Text = "";

            this.tb16.Text = "";
            this.tb17.Text = "";
            this.tb18.Text = "";
            this.tb19.Text = "";
            this.tb20.Text = "";

            this.tb21.Text = "";
            this.tb22.Text = "";
            this.tb23.Text = "";
            this.tb24.Text = "";
            this.tb25.Text = "";

            this.tb26.Text = "";
            this.tb27.Text = "";
            this.tb28.Text = "";
            this.tb29.Text = "";
            this.tb30.Text = "";

            this.tb31.Text = "";
            this.tb32.Text = "";
            this.tb33.Text = "";
            this.tb34.Text = "";
            this.tb35.Text = "";

            this.tb36.Text = "";
            this.tb37.Text = "";
            this.tb38.Text = "";
            this.tb39.Text = "";
            this.tb40.Text = "";

            this.tb41.Text = "NO:TD-QR-01";
            this.tb42.Text = "thanh lý chuyển xưởng:chấp hành theo quy định hải quan";
            this.tb43.Text = "轉廠核銷：按海關規定執行";
            this.tb44.Text = "";
            this.tb45.Text = "";

            this.tb46.Text = "nhân viên báo quan:Nguyễn Ngọc Thuỷ";
            this.tb47.Text = "報關員：阮玉水";
            this.tb48.Text = "tên hàng:da bò(cow split leather)";
            this.tb49.Text = "品名：牛皮(牛榔皮，反毛皮)";
            this.tb50.Text = "Mã số hàng hóa:41079900";

            this.tb51.Text = "商品編號：41079900";
            this.tb52.Text = "địa điểm thanh tóan:HK";
            this.tb53.Text = "付款地點:香港";
            this.tb54.Text = "trả tiền bằng付款幣別：USD";
            this.tb55.Text = "Hình thức thanh toán: mỗi tháng";

            this.tb56.Text = "";
            this.tb57.Text = "";
            this.tb58.Text = "";
            this.tb59.Text = "";
            this.tb60.Text = "";

            this.tb61.Text = "địa điểm khai phát:VN/TWN";
            this.tb62.Text = "開發地點：越南/台灣";
            this.tb63.Text = "Địa điển giao hàng:việt Nam";
            this.tb64.Text = "交貨地點：越南";
            this.tb65.Text = "người liên lạc của quý công ty";

            this.tb66.Text = "貴司聯絡人：";
            this.tb67.Text = "Nhân viên báo quan: ";
            this.tb68.Text = "報關員：";
            this.tb69.Text = "";
            this.tb70.Text = "";
        }
       
        private void Fr_UpdataEventHandler(object sender, Form1IF5.UpdateEventArgs args)
        {
            //tb3.Text = Form1IF5.getBaoGia.dsfdf;
        }

        public static string Text1;
        DataTable datagridcoppy = new DataTable();
        
        #endregion

        #region Change language
        //txtThongBao
        string txtThongBao = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtNodata = "";
        string txtText6 = "";
        string txtText9 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdEnglish == true)
            {
                txtThongBao = "Nofication";
                txtText2 = "Quote Removed :" + tb3.Text + "\n Failed";
                txtText3 = "You have not entered the order number";
                txtText4 = "You have not entered the customer number";
                txtText6 = "No quote has been selected yet";
                txtText9 = "This price list already exists, Please check again!";               
                txtNodata = "No data";
            }
            else if (DataProvider.LG.rdChina == true)
            {
                txtThongBao = "通知";
                txtText2 = "引用 :" + tb3.Text + "\n 刪除失敗";
                txtText3 = "您還沒有輸入訂單號";
                txtText4 = "您尚未輸入客戶編號";
                txtText6 = "尚未選擇任何報價";
                txtText9 = "此價目表已存在，請再次查看！";               
                txtNodata = "沒有數據";
            }
            else if(DataProvider.LG.rdVietNam == true)
            {
                txtThongBao = "Thông Báo";
                txtText2 = "Báo giá :" + tb3.Text + "\n Xóa không Thành công";
                txtText3 = "Bạn chưa nhập mã số đơn hàng";
                txtText4 = "Bạn chưa nhập số khách hàng";
                txtText6 = "Chưa chọn số báo giá";
                txtText9 = "Bảng giá này đã tồn tại, Vui lòng kiểm tra lại !";
                txtNodata = "Không có dữ liệu";
            }
            else
            {
                txtThongBao = "Thông Báo";
                txtText2 = "Báo giá :" + tb3.Text + "\n Xóa không Thành công";
                txtText3 = "Bạn chưa nhập mã số đơn hàng";
                txtText4 = "Bạn chưa nhập số khách hàng";
                txtText6 = "Chưa chọn số báo giá";
                txtText9 = "Bảng giá này đã tồn tại, Vui lòng kiểm tra lại !";
                txtNodata = "Không có dữ liệu";
            }
        }
        #endregion

        private void btok_Click(object sender, EventArgs e) // button Ok 
        {
            checkNofication();
            check();
            if (f2ToolStripMenuItem.Checked == true)
            {
                if (conn.checkExists("SELECT WS_NO FROM QUOH WHERE WS_NO = '" + tb3.Text + "' ") == true)
                {
                    MessageBox.Show("" + txtText9 + "", "" + txtThongBao + "");
                }
                else
                {
                    if (string.IsNullOrEmpty(tb5.Text))
                    {
                        MessageBox.Show("" + txtText4 + "", "" + txtThongBao + "");
                    }
                    else
                    {
                        conn.OpentTransaction();
                        check();
                        Add_Data();
                        Add_DGV();
                        CheckStripMenuItem();
                        TextAdd();
                    }
                }
            }
            else if (f3ToolStripMenuItem.Checked == true)
            {
                Delete_data();
                LoadData();
                LoadDGV1();
                LoadFirst();
            }
            else if (f4ToolStripMenuItem.Checked == true)
            {
                check();
                conn.OpentTransaction();
                DeleteDGV();
                Repair_Data();
                Add_DGV();
                LoadData();
                LoadDGV1();
                LoadFirst();
                tb3.ReadOnly = false;
            }
            else if (f9ToolStripMenuItem.Checked == true)
            {
                CheckQuotation();
                LoadFirst();
            }
            else if (f6ToolStripMenuItem.Checked == true)
            {
                conn.OpentTransaction();
                check();
                Add_Data();
                Add_DGV();
                LoadData();
                LoadDGV1();
                LoadFirst();
                f6ToolStripMenuItem.Checked = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e) //getTimeNow 
        {
            btnTimeNow.Text = CN.getTimeNow();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            LoadFirst();
        }
        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if (FromCalender.Flags)
                    tb1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        private void tb3_TextChanged(object sender, EventArgs e)
        {
            if (f6ToolStripMenuItem.Checked == true)
            {
                DGV1.DataSource = datagridcoppy;
            }
        }
        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                if (tb4.Text == "")
                    tb4.Text = "台灣";
                else if (tb4.Text == "台灣")
                    tb4.Text = "香港";
                else if (tb4.Text == "香港")
                    tb4.Text = "大陸";
                else if (tb4.Text == "大陸")
                    tb4.Text = "越南";
                else if (tb4.Text == "越南")
                    tb4.Text = "台灣";
            }
        }
        private void tb5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                frm2CustSearch fm = new frm2CustSearch();
                fm.ShowDialog();
                tb5.Text = frm2CustSearch.ID.ID_CUST;
                tb6.Text = frm2CustSearch.ID.C_ANAME2;
                tb8.Text = frm2CustSearch.ID.C_ANAME2;
                tb40.Text = frm2CustSearch.ID.PAY_CON;
                tb7.Text = frm2CustSearch.ID.DEFA_MONEY;
            }
        }
        private void tb5_TextChanged(object sender, EventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                string sql = "SELECT C_NO, C_NAME2, C_NAME2_E, C_ANAME2,ADR3,DEFA_MONEY,PAY_CON FROM  CUST WHERE 1=1 and  C_NO = '" + tb5.Text + "'";
                DataTable dt1 = new DataTable();
                dt1 = conn.readdata(sql);

                if (dt1.Rows.Count > 0)
                {
                    tb5.Text = dt1.Rows[0]["C_NO"].ToString();
                    tb6.Text = dt1.Rows[0]["C_ANAME2"].ToString();
                    tb8.Text = dt1.Rows[0]["C_ANAME2"].ToString();
                    tb40.Text = dt1.Rows[0]["PAY_CON"].ToString();
                    tb7.Text = dt1.Rows[0]["DEFA_MONEY"].ToString();
                }

            }
        }
        private void tb16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if(FromCalender.Flags)
                    tb16.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
        private void tb17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                FromCalender fm = new FromCalender();
                fm.ShowDialog();
                if (FromCalender.Flags)
                    tb17.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            }
        }
    
        void CheckQuo()
        {
            checkNofication();

            string SQL = "SELECT WS_NO FROM QUOH WHERE WS_NO = '" + tb3.Text + "' ";
            string ID = "WS_NO";
            string Result = conn.ID(SQL, ID);
            if (Result == tb3.Text)
            {
                MessageBox.Show("" + txtText9 + "", "" + txtThongBao + "");
                //tb3.Clear();
            }
        }
        #region keydown Textbox
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                txtDown.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtUp.Focus();
            }
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb2, sender, e);
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb1, tb3, sender, e);
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
            conn.tab_Combobox(tb5, tb7, sender, e);
        }
        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb8.Focus();
            }
        }
        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb9, sender, e);
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
            tab(tb12, tb15, sender, e);

        }
        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }
        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb14, tb16, sender, e);
        }
        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb15, tb17, sender, e);
        }
        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb16, tb18, sender, e);
        }
        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb17, tb19, sender, e);
        }
        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb18, tb20, sender, e);
        }
        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb19, tb1, sender, e);
        }

        //Trang 2
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
            tab(tb26, tb28, sender, e);
        }
        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb27, tb29, sender, e);
        }
        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb28, tb30, sender, e);
        }
        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb29, tb31, sender, e);
        }
        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb30, tb32, sender, e);
        }
        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb31, tb33, sender, e);
        }
        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb32, tb34, sender, e);
        }
        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb33, tb21, sender, e);
        }

        // TabPage 3
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
            tab(tb38, tb35, sender, e);
        }

        //TabPage 4
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
            tab(tb46, tb48, sender, e);
        }
        private void tb48_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb47, tb49, sender, e);
        }
        private void tb49_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb48, tb50, sender, e);
        }
        private void tb50_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb49, tb51, sender, e);
        }
        private void tb51_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb50, tb52, sender, e);
        }
        private void tb52_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb51, tb53, sender, e);
        }
        private void tb53_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb52, tb54, sender, e);
        }
        private void tb54_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb53, tb55, sender, e);
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
            tab(tb56, tb58, sender, e);
        }
        private void tb58_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb57, tb59, sender, e);
        }
        private void tb59_KeyDown(object sender, KeyEventArgs e)
        {

            tab(tb58, tb60, sender, e);
        }
        private void tb60_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb59, tb61, sender, e);
        }
        private void tb61_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb60, tb62, sender, e);
        }
        private void tb62_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb61, tb63, sender, e);
        }
        private void tb63_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb62, tb64, sender, e);
        }
        private void tb64_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb63, tb65, sender, e);
        }
        private void tb65_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb64, tb66, sender, e);
        }
        private void tb66_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb65, tb67, sender, e);
        }
        private void tb67_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb66, tb68, sender, e);
        }
        private void tb68_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb67, tb69, sender, e);
        }
        private void tb69_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb68, tb70, sender, e);
        }
        private void tb70_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb69, tb40, sender, e);
        }     
        #endregion

        void check()
        {
            if (conn.Check_MaskedText(tb1) == true)
            {
                a = tb1.Text;
            }
            if (conn.Check_MaskedText(tb16) == true)
            {
                b = tb16.Text;
            }
            if (conn.Check_MaskedText(tb17) == true)
            {
                c = tb17.Text;
            }
        }
        string STT = "";
        string SOSP = "";
        string TENSP = "";
        string DODAY = "";
        string PATT = "";
        #region Menu Strip
        private void InsertItem(int NR)
        {
            if (Row < 0) return;
            foreach (DataRow dr in dtDGV.Rows)
            {
                int Temp;
                int.TryParse(dr["NR"].ToString(), out Temp);
                if (Temp > NR)
                {
                    Temp++;
                    dr["NR"] = Temp.ToString("D" + 3);
                }
            }
            dtDGV.Rows.Add((NR + 1).ToString("D" + 3), "", "", "", "", "", null, "", null, "", "", "", "", "", "", "", "", "","", null, "");
            dtDGV.AcceptChanges();
            dtDGV.DefaultView.Sort = "NR ASC";
            DGV1.DataSource = dtDGV;
        }
        private void DeleteItem(int NR)
        {
            if (Row < 0) return;
            foreach (DataRow dr in dtDGV.Rows)
            {
                int Temp;
                int.TryParse(dr["NR"].ToString(), out Temp);

                if (Temp == NR+1)
                {
                    dr.Delete();
                }
                else if(Temp > NR)
                {
                    Temp--;
                    dr["NR"] = Temp.ToString("D" + 3);
                }
            }
            dtDGV.AcceptChanges();
            dtDGV.DefaultView.Sort = "NR ASC";
            DGV1.DataSource = dtDGV;
        }
        #endregion                
        void Add_Data()
        {
            decimal sumPRICE = 0;
            for (int i = 0; i < DGV1.Rows.Count; ++i)
            {
                sumPRICE += Convert.ToDecimal(DGV1.Rows[i].Cells[6].Value);
            }
            bool check;
            checkNofication();
            string st1 = "INSERT INTO QUOH (WS_NO,WS_KIND,WS_DATE,C_NO,C_NAME,C_ANAME," +
                        "S_NO,ADDR,METHOD,PAY_COND,TOT,TAX,DISCOUNT,TOTAL,COST,PROFIT,WS_DATE_S,WS_DATE_E," +
                        "MEMO1,MEMO2,MEMO3,MEMO4,MEMO5,MEMO6,MEMO7,MEMO8,MEMO9,MEMO10,MEMO11,MEMO12,MEMO13," +
                        "MEMO14,M_TRAN,M_TRAN_R,USR_NAME,PAY_PLACE,SPEAK,FAX,SPEAK_CC,PS01,PS02,PS03,MEMO101," +
                        "MEMO102,MEMO103,MEMO104,MEMO105,MEMO106,MEMO107,MEMO108,MEMO109,MEMO110,MEMO201,MEMO202," +
                        "MEMO203,MEMO204,MEMO205,MEMO206,MEMO207,MEMO208,MEMO209,MEMO210,MEMO15,MEMO16,MEMO17," +
                        "MEMO18,MEMO19,MEMO20,W_FROM,W_CC,W_CHECK,VC_NAME,MEMO301,MEMO302,MEMO303,MEMO304,MEMO305," +
                        "MEMO306,MEMO307,MEMO308,MEMO309,MEMO310,VA_DATE,VA_DATES) " +
                        "VALUES(N'" + tb3.Text + "', N'" + tb2.Text + "', N'" + conn.formatstr2(a) + "', N'" + tb5.Text + "', N'" + tb6.Text + "', N'" + conn.CutString(tb8) + "', N'', N'', N'', N'" + tb40.Text + "'," +
                        "" + sumPRICE + ", 0, 0, " + sumPRICE + ", 0, " + sumPRICE + ", N'', N'', N'" + tb21.Text + "', N'" + tb22.Text + "', N'" + tb23.Text + "'," +
                        " N'" + tb24.Text + "', N'" + tb25.Text + "', N'" + tb26.Text + "', N'" + tb27.Text + "', N'" + tb28.Text + "'," +
                        " N'" + tb29.Text + "', N'" + tb30.Text + "', N'" + tb31.Text + "', N'" + tb32.Text + "', N'" + tb33.Text + "', N'" + tb34.Text + "', N'" + tb7.Text + "'," +
                        "0, N'" + lbUserName.Text + "', N'', N'" + tb9.Text + "', N'" + tb11.Text + "', N'" + tb10.Text + "'," +
                        " N'" + tb18.Text + "', N'" + tb19.Text + "', N'" + tb20.Text + "', N'" + tb42.Text + "'," +
                        "N'" + tb43.Text + "', N'" + tb44.Text + "', N'" + tb45.Text + "', N'" + tb46.Text + "'," +
                        "N'" + tb47.Text + "', N'" + tb48.Text + "', N'" + tb49.Text + "', N'" + tb50.Text + "'," +
                        "N'" + tb51.Text + "', N'" + tb52.Text + "', N'" + tb53.Text + "', N'" + tb54.Text + "', N'" + tb55.Text + "', N'" + tb56.Text + "', N'" + tb57.Text + "', N'" + tb58.Text + "'," +
                        "N'" + tb59.Text + "', N'" + tb60.Text + "', N'" + tb71.Text + "', N'" + tb35.Text + "'," +
                        " N'" + tb36.Text + "', N'" + tb37.Text + "', N'" + tb38.Text + "', N'" + tb39.Text + "'," +
                        " N'" + tb41.Text + "', N'" + tb12.Text + "', N'" + tb13.Text + "', N'" + tb14.Text + "', N'" + tb6.Text + "', N'" + tb61.Text + "'," +
                        "N'" + tb62.Text + "', N'" + tb63.Text + "', N'" + tb64.Text + "', N'" + tb65.Text + "', N'" + tb66.Text + "'," +
                        "N'" + tb67.Text + "', N'" + tb68.Text + "', N'" + tb69.Text + "', N'" + tb70.Text + "', N'" + tb17.Text.Replace("/", "").Replace(" ", "").Replace(" ", "") + "', N'" + tb16.Text.Replace("/", "").Replace(" ", "") + "')";
            if (tb3.Text == string.Empty)
            {
                MessageBox.Show("" + txtText3 + "");
                return;
            }
            else if (tb5.Text == string.Empty)
            {
                MessageBox.Show("" + txtText4 + "");
                return;
            }
            try
            {
                check = conn.ExecuteTransaction(st1);
                if (check == false)
                {
                    conn.CloseTransaction(false);
                }
            }
            catch (Exception ex)
            {
                conn.CloseTransaction(false);
                MessageBox.Show(ex.Message);
            }
        }
        void Add_DGV()
        {
            for (int i = 0; i < DGV1.RowCount; i++)
            {
                var STT = DGV1.Rows[i].Cells[0].Value;
                var SOSP = DGV1.Rows[i].Cells[1].Value;
                var TENSP = DGV1.Rows[i].Cells[2].Value;
                var TSKT = DGV1.Rows[i].Cells[3].Value;
                var DODAY = DGV1.Rows[i].Cells[4].Value;
                var TIENTE = DGV1.Rows[i].Cells[5].Value;
                var DONGIA = DGV1.Rows[i].Cells[6].Value;
                var NHANHIEU = DGV1.Rows[i].Cells[7].Value;
                var TLSDTB = DGV1.Rows[i].Cells[8].Value;
                var NHANXET = DGV1.Rows[i].Cells[9].Value;
                var K_NO = DGV1.Rows[i].Cells[10].Value;
                var QC = DGV1.Rows[i].Cells[12].Value;
                var SKIN_SIZE = DGV1.Rows[i].Cells[14].Value;
                var SOFTNESS = DGV1.Rows[i].Cells[13].Value;
                var COLOR_N = DGV1.Rows[i].Cells[11].Value;

                var amount = (1 * decimal.Parse(DONGIA.ToString()));
                string SQL = "INSERT INTO QUOB (WS_NO,NR,WS_DATE,C_NO,P_NO,P_NAME," +
                            "P_NAME1,P_NAME2,P_NAME3,UNIT,QTY,BQTY,BUNIT,CUNIT,TRANS," +
                            "PRICE,PRICE_C,PRICE_F,COST,AMOUNT,AMOUNT_F,MEMO,NW,GW," +
                            "CUF,MEMO1,MEMO2,MEMO3,MEMO4,K_NO,AVGCQ,PBT01,PBT02,PBT03,PBT04)" +
                            "VALUES(N'" + tb3.Text + "', N'" + STT + "', N'" + conn.formatstr2(tb1.Text) + "', N'" + tb5.Text + "', N'" + SOSP + "'," +
                            "N'" + DGV1.Rows[i].Cells[15].Value + "', N'" + TENSP + "', N'', N'" + DODAY +
                            "', N'" + DGV1.Rows[i].Cells[16].Value + "', 0, 1, N'" + DGV1.Rows[i].Cells[17].Value + "'," +
                            "N'" + DGV1.Rows[i].Cells[18].Value + "', N'" + DGV1.Rows[i].Cells[19].Value +
                            "', " + DONGIA + ", N'" + TIENTE + "', 0, 0, '" + amount + "', 0, N'" + NHANXET +
                            "', 0, 0, 0, N'" + NHANHIEU + "', N'" + TSKT + "', N'', N''," +
                            "N'" + DGV1.Rows[i].Cells[20].Value + "', " + TLSDTB + ", N'" + COLOR_N +
                            "', N'" + QC + "', N'" + SOFTNESS + "', N'" + SKIN_SIZE + "')";
                bool insertDATA = conn.ExecuteTransaction(SQL);
                if (insertDATA == false)
                {
                    conn.CloseTransaction(false);
                    return;
                }
            }
            conn.CloseTransaction(true);
        }
        void Delete_data() // Delete Quotation 
        {
            try
            {
                if (tb3.Text != null)
                {
                    //string SQL = "DELETE  FROM QUOH WHERE WS_NO = '"+tb3.Text+"' ";
                    string SQL = "DelQuotation @WS_NO = '" + tb3.Text + "' ";
                    bool del = conn.exedata(SQL);
                }
                else
                    MessageBox.Show("" + txtText6 + "", "" + txtThongBao + "");

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
        void Repair_Data()
        {
            int sumPRICE = 0;
            for (int i = 0; i < DGV1.Rows.Count; ++i)
            {
                sumPRICE += Convert.ToInt32(DGV1.Rows[i].Cells[6].Value);
            }
            checkNofication();
            bool check;
            string st1 = "UPDATE QUOH SET " +
                        "WS_NO = '" + tb3.Text + "',WS_KIND = '" + tb2.Text + "',WS_DATE = '" + conn.formatstr2(a) + "',C_NO = '" + tb5.Text +
                        "',C_NAME = N'" + tb6.Text + "',S_NO = N'',ADDR = N''," +
                        "METHOD = N'',PAY_COND = '" + tb40.Text + "',TOT = " + sumPRICE + ",TAX = 0,DISCOUNT = 0,TOTAL = " + sumPRICE + ",COST =0," +
                        "PROFIT = " + sumPRICE + ",WS_DATE_S = N'',WS_DATE_E = N'',MEMO1 = N'" + tb21.Text + "',MEMO2 = N'" + tb22.Text + "',MEMO3 = N'" + tb23.Text + "'," +
                        "MEMO4 = N'" + tb24.Text + "',MEMO5 = N'" + tb25.Text + "',MEMO6 = N'" + tb26.Text + "',MEMO7 = N'" + tb27.Text +
                        "',MEMO8 = N'" + tb28.Text + "',MEMO9 = N'" + tb29.Text + "',MEMO10 = N'" + tb30.Text + "'," +
                        "MEMO11 = N'" + tb31.Text + "',MEMO12 = N'" + tb32.Text + "',MEMO13 = N'" + tb33.Text +
                        "',MEMO14 = N'" + tb34.Text + "',M_TRAN = '" + tb7.Text + "',M_TRAN_R = 0,USR_NAME = '" + lbUserName.Text + "'," +
                        "PAY_PLACE = '" + tb4.Text + "',SPEAK = '" + tb9.Text + "',FAX = '" + tb11.Text +
                        "',SPEAK_CC = '" + tb10.Text + "',PS01 = '" + tb18.Text + "',PS02 = '" + tb19.Text + "',PS03 = '" + tb20.Text + "',MEMO101 = N'" + tb42.Text + "'," +
                        "MEMO102 = N'" + tb43.Text + "',MEMO103 = N'" + tb44.Text + "',MEMO104 = N'" + tb45.Text +
                        "',MEMO105 = N'" + tb46.Text + "',MEMO106 = N'" + tb47.Text + "',MEMO107 = N'" + tb48.Text + "',MEMO108 = N'" + tb49.Text + "'," +
                        "MEMO109 = N'" + tb50.Text + "',MEMO110 = '" + tb51.Text + "',MEMO201 = N'" + tb52.Text +
                        "',MEMO202 = N'" + tb53.Text + "',MEMO203 = N'" + tb54.Text + "',MEMO204 = N'" + tb55.Text + "',MEMO205 =N'" + tb56.Text + "'," +
                        "MEMO206 = N'" + tb57.Text + "',MEMO207 = N'" + tb58.Text + "',MEMO208 = N'" + tb59.Text +
                        "',MEMO209 = N'" + tb60.Text + "',MEMO210 = N'" + tb71.Text + "',MEMO15 = N'" + tb35.Text + "',MEMO16 = N'" + tb36.Text + "'," +
                        "MEMO17 = N'" + tb37.Text + "',MEMO18 = N'" + tb38.Text + "',MEMO19 = N'" + tb39.Text +
                        "',MEMO20 = N'" + tb41.Text + "',W_FROM = N'" + tb12.Text + "',W_CC = N'" + tb13.Text + "',W_CHECK = '" + tb14.Text + "',VC_NAME = N'" + tb6.Text + "'," +
                        "MEMO301 = N'" + tb61.Text + "',MEMO302 = N'" + tb62.Text + "',MEMO303 = N'" + tb63.Text +
                        "',MEMO304 = N'" + tb64.Text + "',MEMO305 = N'" + tb65.Text + "',MEMO306 = N'" + tb66.Text + "',MEMO307 = N'" + tb67.Text + "'," +
                        "MEMO308 = N'" + tb68.Text + "',MEMO309 = N'" + tb69.Text + "',MEMO310 = N'" + tb70.Text + "',VA_DATE = '" + conn.formatstr2(c) + "',VA_DATES = '" + conn.formatstr2(b) + "'" +
                        "WHERE WS_NO = '" + tb3.Text + "'";

            if (tb3.Text == string.Empty)
            {
                MessageBox.Show("" + txtText3 + "");
                return;
            }
            else if (tb5.Text == string.Empty)
            {
                MessageBox.Show("" + txtText4 + "");
                return;
            }
            try
            {
                check = conn.ExecuteTransaction(st1);
                if (check == false)
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
        }
        void CheckQuotation() // Check Quotation 
        {
            checkNofication();
            try
            {
                string SQL = "UPDATE QUOH SET W_CHECK = 'Y' WHERE WS_NO = '" + tb3.Text + "' ";
                bool checkgia = conn.exedata(SQL);
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }

        }
        int Row = -1;
        private void AddingItem()
        {
            frmSearchMaterial1IDGV fm = new frmSearchMaterial1IDGV();
            fm.ShowDialog();
            if (frmSearchMaterial1IDGV.Produc.Count > 0)
            {
                int NR1 = Row + 1;
                foreach (var item in frmSearchMaterial1IDGV.Produc)
                {
                    if(frmSearchMaterial1IDGV.Options == 1)
                    {
                        foreach(DataRow dr in dtDGV.Rows)
                        {
                            int Temp;
                            int.TryParse(dr["NR"].ToString(), out Temp);
                            if(Temp == NR1)
                            {
                                dr["P_NO"] = item.ID_P_NO;
                                dr["P_NAME1"] = item.P_NAME1;
                                dr["MEMO2"] = "";
                                dr["P_NAME3"] = "";
                                dr["PRICE_C"] = "";
                                dr["PRICE"] = "0.000";
                                dr["MEMO1"] = "";
                                dr["AVGCQ"] = "0";
                                dr["MEMO"] = "";
                                dr["UPDATEKIND"] = "";
                                dr["PBT01"] = "";
                                dr["PBT02"] = "";
                                dr["PBT03"] = "";
                                dr["PBT04"] = "";
                                dr["P_NAME"] = item.P_NAME;
                                dr["BUNIT"] = item.BUNIT;
                                dr["CUNIT"] = item.CUNIT;
                                dr["TRANS"] = item.TRANS;
                                dr["K_NO"] = item.K_NO;
                                dr["UNIT"] = item.UNIT;
                            }
                        }
                    }
                    else
                    {
                        STT = (DGV1.Rows.Count+1).ToString("D" + 3);
                        SOSP = item.ID_P_NO;
                        TENSP = item.P_NAME1;
                        DataRow drToAdd = dtDGV.NewRow();

                        drToAdd["NR"] = STT;
                        drToAdd["P_NO"] = SOSP;
                        drToAdd["P_NAME1"] = TENSP;
                        drToAdd["MEMO2"] = "";
                        drToAdd["P_NAME3"] = "";
                        drToAdd["PRICE_C"] = "";
                        drToAdd["PRICE"] = "0.000";
                        drToAdd["MEMO1"] = "";
                        drToAdd["AVGCQ"] = "0";
                        drToAdd["MEMO"] = "";
                        drToAdd["UPDATEKIND"] = "";
                        drToAdd["PBT01"] = "";
                        drToAdd["PBT02"] = "";
                        drToAdd["PBT03"] = "";
                        drToAdd["PBT04"] = "";
                        drToAdd["P_NAME"] = item.P_NAME;
                        drToAdd["BUNIT"] = item.BUNIT;
                        drToAdd["CUNIT"] = item.CUNIT;
                        drToAdd["TRANS"] = item.TRANS;
                        drToAdd["K_NO"] = item.K_NO;
                        drToAdd["UNIT"] = item.UNIT;

                        dtDGV.Rows.Add(drToAdd);
                        NR1++;
                    }
                }
            }
            DGV1.DataSource = dtDGV;
        }
        public void DeleteDGV()
        {
            bool check;
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                string sql = "DELETE QUOB WHERE WS_NO=N'" + tb3.Text + "'";
                check = conn.ExecuteTransaction(sql);
                if (check == false)
                {
                    conn.CloseTransaction(false);
                    return;
                }
            }
        }    
        private void ReturnP_NO()
        {
            string sql = "SELECT TOP 1 P_NAME1 FROM PROD WHERE P_NO = '" + DGV1.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "'";
            DataTable dataTable = conn.readdata(sql);
            foreach (DataRow item in dataTable.Rows)
            {
                if (!string.IsNullOrEmpty(item["P_NAME1"].ToString()))
                {
                    DGV1.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value = item["P_NAME1"].ToString();
                }
                else
                {
                    DGV1.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value = "";
                }
            }

        }

        
        private void ItemAdd_Click(object sender, EventArgs e)
        {
            DGV1.AllowUserToAddRows = true;
            DGV1.CurrentCell = DGV1.Rows[DGV1.Rows.Count - 1].Cells[1];
            DGV1.Rows[DGV1.Rows.Count - 1].Cells[0].Value = (DGV1.Rows.Count).ToString("D" + 3);
            DGV1.AllowUserToAddRows = false;
        }
        private void ItemInsert_Click(object sender, EventArgs e)
        {
            InsertItem(Row);
        }
        private void ItemDelete_Click(object sender, EventArgs e)
        {
            DeleteItem(Row);
        }
        private void ItemImport_Click(object sender, EventArgs e)
        {
            frmSearchMaterial1IDGV.Options = 2;
            AddingItem();
        }
        private void ItemSave_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }
        private void ItemCancel_Click(object sender, EventArgs e)
        {
            LoadFirst();
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Row = e.RowIndex;
            if (Function == 2 || Function == 4 || Function == 6)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 5)
                {
                    object TT = this.DGV1[5, DGV1.CurrentRow.Index].Value.ToString();

                    if (TT.ToString() == "")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "USD";
                    else if (TT.ToString() == "USD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "HKD";
                    else if (TT.ToString() == "HKD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "NTD";
                    else if (TT.ToString() == "NTD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "RMB";
                    else if (TT.ToString() == "RMB")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "USD";
                    TT = "";
                }
            }
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb3.Text))
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 1 || Cur == 2)
                {
                    frmSearchMaterial1IDGV.Options = 1;
                    AddingItem();
                }
                if (Cur == 3)
                {
                    frmSearchPatt fm = new frmSearchPatt();
                    fm.ShowDialog();
                    PATT = frmSearchPatt.ID.PATT;
                    this.DGV1[3, DGV1.CurrentRow.Index].Value = PATT;
                }
                if (Cur == 4)
                {
                    FormSearchThick2 fm = new FormSearchThick2();
                    fm.ShowDialog();
                    DODAY = FormSearchThick2.ID.ID_THICK;
                    this.DGV1[4, DGV1.CurrentRow.Index].Value = DODAY;
                }
                if (Cur == 5)
                {
                    object TT = this.DGV1[5, DGV1.CurrentRow.Index].Value.ToString();

                    if (TT.ToString() == "")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "USD";
                    else if (TT.ToString() == "USD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "HKD";
                    else if (TT.ToString() == "HKD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "NTD";
                    else if (TT.ToString() == "NTD")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "RMB";
                    else if (TT.ToString() == "RMB")
                        this.DGV1[5, DGV1.CurrentRow.Index].Value = "USD";

                    TT = "";
                }
                if (Cur == 7)
                {
                    FormSearchBrand fm1 = new FormSearchBrand();
                    fm1.ShowDialog();
                    string S1 = FormSearchBrand.ID.BRAND;
                    this.DGV1[7, DGV1.CurrentRow.Index].Value = S1;
                }
                if (Cur == 9)
                {
                    FormSearchLeather2 fm2 = new FormSearchLeather2();
                    fm2.ShowDialog();
                    string M1 = FormSearchLeather2.ID.M_NAME;
                    this.DGV1[9, DGV1.CurrentRow.Index].Value = M1;
                }
                if (Cur == 10)
                {
                    object TT = this.DGV1[10, DGV1.CurrentRow.Index].Value.ToString();

                    if (TT.ToString() == "")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "1";
                    else if (TT.ToString() == "1")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "2";
                    else if (TT.ToString() == "2")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "3";
                    else if (TT.ToString() == "3")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "4";
                    else if (TT.ToString() == "4")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "7";
                    else if (TT.ToString() == "7")
                        this.DGV1[10, DGV1.CurrentRow.Index].Value = "1";

                    TT = "";
                }
            }
            else
            {
                tb3.Focus();
                MessageBox.Show("" + txtText6 + "", "" + txtThongBao + "");
            }

        }
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Function == 2 || Function == 3 || Function == 4 || Function == 6)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.contextMenuStrip1.Show(this.DGV1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
        private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Function == 2 || Function == 4 || Function == 6)
            {
                if (e.ColumnIndex == 1)
                {
                    ReturnP_NO();
                }
            }
        }

    }
}
