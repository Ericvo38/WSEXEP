using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form1A : Form
    {
        public Form1A()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataTable tb = new DataTable();
        BindingSource bindingsource;
        DataProvider conn = new DataProvider();
        private void Formkhachhang2_Load(object sender, EventArgs e)
        {
            getInfo();
            Loaddata();
            hienthidata();
            LoadFunctionFisrt();
        }
        private void LoadFunctionFisrt()
        {
            btok.Hide();
            btdong.Hide();

            conn.CheckLoad(menuStrip1);

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        public void Loaddata()
        {
            string sql = "select C_NO, C_NO1, C_NAME, C_ANAME, C_NAME_E, EMAIL, SPEAK, TEL1, FAX, ADR1, C_NAME1, C_ANAME1, C_NAME1_E, EMAIL1, SPEAK1, TEL2, FAX1, ADR2, C_NAME2, C_ANAME2, C_NAME2_E, EMAIL2, SPEAK2, TEL3, FAX2, ADR3, " +
                "PAY_CON, RCV_DATE, DEFA_MONEY, S_NO, ACCOUNT, PAY_PLACE, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, " +
                "RNG01, FT01, RNG02, FT02, RNG03, FT03, RNG04, FT04, RNG05, FT05, ORDOUT, CAROUT, CTY_NO, CTY_NAME, BLIVE,USR_NAME from CUST";
            // co the su dung cm.ExecuteNonQuery();
            tb = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = tb;
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
            lbUserName.Text = conn.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
            btndateNow.Text = conn.getDateNow(); // get DateNow
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
        public void hienthidata()
        {
            this.txtC_NO.Text = currentRow["C_NO"].ToString();
            this.txtC_NO1.Text = currentRow["C_NO1"].ToString();
            this.txtC_NAME.Text = currentRow["C_NAME"].ToString();
            this.txtC_ANAME.Text = currentRow["C_ANAME"].ToString();
            this.txtC_NAME_E.Text = currentRow["C_NAME_E"].ToString();

            this.txtEMAIL.Text = currentRow["EMAIL"].ToString();
            this.txtSPEAK.Text = currentRow["SPEAK"].ToString();
            this.txtTEL1.Text = currentRow["TEL1"].ToString();
            this.txtFAX.Text = currentRow["FAX"].ToString();
            this.txtADR1.Text = currentRow["ADR1"].ToString();

            this.txtC_NAME1.Text = currentRow["C_NAME1"].ToString();
            this.txtC_ANAME1.Text = currentRow["C_ANAME1"].ToString();
            this.txtC_NAME1_E.Text = currentRow["C_NAME1_E"].ToString();
            this.txtEMAIL1.Text = currentRow["EMAIL1"].ToString();
            this.txtSPEAK1.Text = currentRow["SPEAK1"].ToString();

            this.txtTEL2.Text = currentRow["TEL2"].ToString();
            this.txtFAX1.Text = currentRow["FAX1"].ToString();
            this.ttxtADR2.Text = currentRow["ADR2"].ToString();
            this.txtC_NAME2.Text = currentRow["C_NAME2"].ToString();
            this.txtC_ANAME2.Text = currentRow["C_ANAME2"].ToString();

            this.txtC_NAME2_E.Text = currentRow["C_NAME2_E"].ToString();
            this.txtEMAIL2.Text = currentRow["EMAIL2"].ToString();
            this.txtSPEAK2.Text = currentRow["SPEAK2"].ToString();
            this.txtTEL3.Text = currentRow["TEL3"].ToString();
            this.txtFAX2.Text = currentRow["FAX2"].ToString();

            this.txtADR3.Text = currentRow["ADR3"].ToString();
            this.txtPAY_CON.Text = currentRow["PAY_CON"].ToString();
            this.txtRCV_DATE.Text = currentRow["RCV_DATE"].ToString();
            this.txtDEFA_MOMEY.Text = currentRow["DEFA_MONEY"].ToString();

            this.txtS_NO.Text = currentRow["S_NO"].ToString();
            this.txtACCOUNT.Text = currentRow["ACCOUNT"].ToString();
            this.txtPAY_PLACE.Text = currentRow["PAY_PLACE"].ToString();
            this.txtMEMO1.Text = currentRow["MEMO1"].ToString();
            this.txtMEMO2.Text = currentRow["MEMO2"].ToString();
            this.txtMEMO3.Text = currentRow["MEMO3"].ToString();

            this.txtMEMO4.Text = currentRow["MEMO4"].ToString();
            this.txtMEMO5.Text = currentRow["MEMO5"].ToString();
            this.txtRNG01.Text = currentRow["RNG01"].ToString();
            this.txtFT01.Text = currentRow["FT01"].ToString();
            this.txtRNG02.Text = currentRow["RNG02"].ToString();
            this.txtFT02.Text = currentRow["FT02"].ToString();

            this.txtNRG03.Text = currentRow["RNG03"].ToString();
            this.txtFT03.Text = currentRow["FT03"].ToString();
            this.txtRNG04.Text = currentRow["RNG04"].ToString();
            this.txtFT04.Text = currentRow["FT04"].ToString();
            this.txtRNG05.Text = currentRow["RNG05"].ToString();

            this.txtFT05.Text = currentRow["FT05"].ToString();
            this.txtORDOUT.Text = currentRow["ORDOUT"].ToString();
            this.txtCAROUT.Text = currentRow["CAROUT"].ToString();
            this.txtCTY_NO.Text = currentRow["CTY_NO"].ToString();
            this.txtCTY_NAME.Text = currentRow["CTY_NAME"].ToString();
            this.txtBLIVE.Text = currentRow["BLIVE"].ToString();
            this.lblEditBy.Text = currentRow["USR_NAME"].ToString();
        }
        private void btdau_Click(object sender, EventArgs e)
        {

            bindingsource.MoveFirst();
            hienthidata();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingsource.MovePrevious();
            hienthidata();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingsource.MoveNext();
            hienthidata();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingsource.MoveLast();
            hienthidata();
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }
        public void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1AF5 fr = new Form1AF5();
            Form1AF5.DI.data = bindingsource;
            Form1AF5.DL.index = bindingsource.Position;
            fr.ShowDialog();

            string dl1 = Form1AF5.DL.t1;
            if (dl1 != string.Empty)
                Get_DLF5();
            if (txtC_NO.Text == string.Empty)
            {
                Loaddata();
                hienthidata();
            }
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = true;
            btok.Show();
            btdong.Show();
            string txt = "";

            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                bt.Text = "THÊM";
                txt = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                bt.Text = "THÊM";
                txt = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                bt.Text = "ADD";
                txt = "No data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                bt.Text = "更多的";
                txt = "沒有數據";
            }

            string a = txtC_NO.Text;
            if (a == "")
            {
                MessageBox.Show("" + txt + "");
                return;
            }
            this.txtC_NO.Text = "";
            this.txtC_NO1.Text = "";
            this.txtC_NAME.Text = "";
            this.txtC_ANAME.Text = "";
            this.txtC_NAME_E.Text = "";

            this.txtEMAIL.Text = "";
            this.txtSPEAK.Text = "";
            this.txtTEL1.Text = "";
            this.txtFAX.Text = "";
            this.txtADR1.Text = "";

            this.txtC_NAME1.Text = "";
            this.txtC_ANAME1.Text = "";
            this.txtC_NAME1_E.Text = "";
            this.txtEMAIL1.Text = "";
            this.txtSPEAK1.Text = "";

            this.txtTEL2.Text = "";
            this.txtFAX1.Text = "";
            this.ttxtADR2.Text = "";
            this.txtC_NAME2.Text = "";
            this.txtC_ANAME2.Text = "";

            this.txtC_NAME2_E.Text = "";
            this.txtEMAIL2.Text = "";
            this.txtSPEAK2.Text = "";
            this.txtTEL3.Text = "";
            this.txtFAX2.Text = "";

            this.txtADR3.Text = "";
            this.txtPAY_CON.Text = "";
            this.txtRCV_DATE.Text = "";
            this.txtDEFA_MOMEY.Text = "";
            this.txt1.Text = "";


            this.txtS_NO.Text = "";

            this.txtACCOUNT.Text = "";
            this.txtPAY_PLACE.Text = "";
            this.txtMEMO1.Text = "";
            this.txtMEMO2.Text = "";
            this.txtMEMO3.Text = "";

            this.txtMEMO4.Text = "";
            this.txtRNG01.Text = "0";
            this.txtFT01.Text = "0";
            this.txtRNG02.Text = "0";
            this.txtFT02.Text = "0";

            this.txtNRG03.Text = "0";
            this.txtFT03.Text = "0";
            this.txtRNG04.Text = "0";
            this.txtFT04.Text = "0";
            this.txtRNG05.Text = "0";

            this.txtFT05.Text = "0";
            this.txtORDOUT.Text = "";
            this.txtCAROUT.Text = "";
            this.txtCTY_NO.Text = "";
            this.txtCTY_NAME.Text = "";
            this.txtBLIVE.Text = "0.0";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;


            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4ToolStripMenuItem.Checked = true;
            //bt.Text = "SỬA";
            btok.Show();
            btdong.Show();
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                bt.Text = "SỬA";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                bt.Text = "SỬA";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                bt.Text = "EDIT";
            }
            if (DataProvider.LG.rdChina == true)
            {
                bt.Text = "使固定";
            }
            this.txtC_NO.Enabled = true;
            this.txtC_NO1.Enabled = true;
            this.txtC_NAME.Enabled = true;
            this.txtC_ANAME.Enabled = true;
            this.txtC_NAME_E.Enabled = true;

            this.txtEMAIL.Enabled = true;
            this.txtSPEAK.Enabled = true;
            this.txtTEL1.Enabled = true;
            this.txtFAX.Enabled = true;
            this.txtADR1.Enabled = true;

            this.txtC_NAME1.Enabled = true;
            this.txtC_ANAME1.Enabled = true;
            this.txtC_NAME1_E.Enabled = true;
            this.txtEMAIL1.Enabled = true;
            this.txtSPEAK1.Enabled = true;

            this.txtTEL2.Enabled = true;
            this.txtFAX1.Enabled = true;
            this.ttxtADR2.Enabled = true;
            this.txtC_NAME2.Enabled = true;
            this.txtC_ANAME2.Enabled = true;

            this.txtC_NAME2_E.Enabled = true;
            this.txtEMAIL2.Enabled = true;
            this.txtSPEAK2.Enabled = true;
            this.txtTEL3.Enabled = true;
            this.txtFAX2.Enabled = true;

            this.txtADR3.Enabled = true;
            this.txtPAY_CON.Enabled = true;
            this.txtRCV_DATE.Enabled = true;
            this.txtDEFA_MOMEY.Enabled = true;
            this.txt1.Enabled = true;


            this.txtS_NO.Enabled = true;

            this.txtACCOUNT.Enabled = true;
            this.txtPAY_PLACE.Enabled = true;
            this.txtMEMO1.Enabled = true;
            this.txtMEMO2.Enabled = true;
            this.txtMEMO3.Enabled = true;

            this.txtMEMO4.Enabled = true;
            this.txtRNG01.Enabled = true;
            this.txtFT01.Enabled = true;
            this.txtRNG02.Enabled = true;
            this.txtFT02.Enabled = true;

            this.txtNRG03.Enabled = true;
            this.txtFT03.Enabled = true;
            this.txtRNG04.Enabled = true;
            this.txtFT04.Enabled = true;
            this.txtRNG05.Enabled = true;

            this.txtFT05.Enabled = true;
            this.txtORDOUT.Enabled = true;
            this.txtCAROUT.Enabled = true;
            this.txtCTY_NO.Enabled = true;
            this.txtCTY_NAME.Enabled = true;
            this.txtBLIVE.Enabled = true;


            this.txtMEMO4.Text = "";
            if (txtRNG01.Text == "")
                this.txtRNG01.Text = "0";
            if (txtFT01.Text == "")
                this.txtFT01.Text = "0";
            if (txtRNG02.Text == "")
                this.txtRNG02.Text = "0";
            if (txtFT02.Text == "")
                this.txtFT02.Text = "0";
            if (txtNRG03.Text == "")
                this.txtNRG03.Text = "0";
            if (txtFT03.Text == "")
                this.txtFT03.Text = "0";
            if (txtRNG04.Text == "")
                this.txtRNG04.Text = "0";
            if (txtFT04.Text == "")
                this.txtFT04.Text = "0";
            if (txtRNG05.Text == "")
                this.txtRNG05.Text = "0";
            if (txtFT05.Text == "")
                this.txtFT05.Text = "0";
            if (txtBLIVE.Text == "")
                this.txtBLIVE.Text = "0";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            //DialogResult dr = MessageBox.Show("Bạn không thể sửa số khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //if (dr == DialogResult.OK)
            //{
            txtC_NO.Enabled = false;
            //}
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string txtThongBao = "";
            string noTxt = "";
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                bt.Text = "COPY";
                // txtThongBao = "Thông Báo";
                noTxt = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                bt.Text = "COPY";
                // txtThongBao = "Thông Báo";
                noTxt = "Không có dữ liệu";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                bt.Text = "COPY";
                // txtThongBao = "Nofication";
                noTxt = "No Data";
            }
            if (DataProvider.LG.rdChina == true)
            {
                bt.Text = "複製";
                // txtThongBao = "通知";
                noTxt = "沒有數據";
            }
            f6ToolStripMenuItem.Checked = true;


            btok.Show();
            btdong.Show();

            string a = txtC_NO.Text;
            if (a == "")
            {
                MessageBox.Show("" + noTxt + "");
                return;
            }
            this.txtC_NO.Enabled = true;
            this.txtC_NO1.Enabled = true;
            this.txtC_NAME.Enabled = true;
            this.txtC_ANAME.Enabled = true;
            this.txtC_NAME_E.Enabled = true;

            this.txtEMAIL.Enabled = true;
            this.txtSPEAK.Enabled = true;
            this.txtTEL1.Enabled = true;
            this.txtFAX.Enabled = true;
            this.txtADR1.Enabled = true;

            this.txtC_NAME1.Enabled = true;
            this.txtC_ANAME1.Enabled = true;
            this.txtC_NAME1_E.Enabled = true;
            this.txtEMAIL1.Enabled = true;
            this.txtSPEAK1.Enabled = true;

            this.txtTEL2.Enabled = true;
            this.txtFAX1.Enabled = true;
            this.ttxtADR2.Enabled = true;
            this.txtC_NAME2.Enabled = true;
            this.txtC_ANAME2.Enabled = true;

            this.txtC_NAME2_E.Enabled = true;
            this.txtEMAIL2.Enabled = true;
            this.txtSPEAK2.Enabled = true;
            this.txtTEL3.Enabled = true;
            this.txtFAX2.Enabled = true;

            this.txtADR3.Enabled = true;
            this.txtPAY_CON.Enabled = true;
            this.txtRCV_DATE.Enabled = true;
            this.txtDEFA_MOMEY.Enabled = true;
            this.txt1.Enabled = true;

            this.txtS_NO.Enabled = true;

            this.txtACCOUNT.Enabled = true;
            this.txtPAY_PLACE.Enabled = true;
            this.txtMEMO1.Enabled = true;
            this.txtMEMO2.Enabled = true;
            this.txtMEMO3.Enabled = true;

            this.txtMEMO4.Enabled = true;
            this.txtRNG01.Enabled = true;
            this.txtFT01.Enabled = true;
            this.txtRNG02.Enabled = true;
            this.txtFT02.Enabled = true;

            this.txtNRG03.Enabled = true;
            this.txtFT03.Enabled = true;
            this.txtRNG04.Enabled = true;
            this.txtFT04.Enabled = true;
            this.txtRNG05.Enabled = true;

            this.txtFT05.Enabled = true;
            this.txtORDOUT.Enabled = true;
            this.txtCAROUT.Enabled = true;
            this.txtCTY_NO.Enabled = true;
            this.txtCTY_NAME.Enabled = true;
            this.txtBLIVE.Enabled = true;
            if (txtBLIVE.Text == "")
                txtBLIVE.Text = "0";

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            txtC_NO.Text = "";
            txtC_NO1.Text = "";
            txtC_NAME_E.Text = "";
            txtC_NAME1_E.Text = "";
            txtC_NAME2_E.Text = "";

        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                bt.Text = "XÓA";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                bt.Text = "XÓA";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                bt.Text = "DELETE";
            }
            if (DataProvider.LG.rdChina == true)
            {
                bt.Text = "刪除";
            }
            f3ToolStripMenuItem.Checked = true;
            btok.Show();
            btdong.Show();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f6ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f8ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1AF7 fr = new Form1AF7();
            fr.ShowDialog();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Loaddata();
            hienthidata();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                bt.Text = "NÚT DUYỆT";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                bt.Text = "NÚT DUYỆT";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                bt.Text = "Browsing Button";
            }
            if (DataProvider.LG.rdChina == true)
            {
                bt.Text = "瀏覽按鈕";
            }
            //bt.Text = "NÚT DUYỆT";
            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();


            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        #region Change Language
        string txtText = "";
        string txtText1 = "";
        string txtText2 = "";
        string txtText3 = "";
        string txtText4 = "";
        string txtDuyet = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText = "Mã Khách Hàng Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtText1 = "Bạn chưa nhập mã số khách hàng";
                txtText2 = "Bạn chưa chọn hệ thống tiền tệ";
                txtText3 = "Bạn chưa nhập số hoặc là %";
                txtText4 = "Bạn chưa nhập tỉ lệ hiệu quả";
                txtDuyet = "NÚT DUYỆT";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Mã Khách Hàng Đã Tồn Tại \n Bạn Vui Lòng Nhấn OK, [Đóng] và Thao Tác Lại Nhé";
                txtText1 = "Bạn chưa nhập mã số khách hàng";
                txtText2 = "Bạn chưa chọn hệ thống tiền tệ";
                txtText3 = "Bạn chưa nhập số hoặc là %";
                txtText4 = "Bạn chưa nhập tỉ lệ hiệu quả";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "Customer Code Exists \n Please Click OK, [Close] and Re-Action";
                txtText1 = "You have not entered the customer code";
                txtText2 = "You have not selected a currency system";
                txtText3 = "You have not entered a number or %";
                txtText4 = "You have not entered the effective ratio";
                txtDuyet = "Browsing Button";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "客戶ID已存在\n請點擊確定，[關閉]並重新工作";
                txtText1 = "您還沒有輸入客戶代碼";
                txtText2 = "您還沒有選擇貨";
                txtText3 = "您沒有輸入數字或%";
                txtText4 = "您尚未輸入有效比例";
                txtDuyet = "瀏覽按鈕";
            }

        }
        #endregion
        private void addData()
        {
            string a = txtC_NO.Text;
            string SQL = "select C_NO from Cust WHERE C_NO = '" + a + "'";
            DataTable dt = conn.readdata(SQL);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(txtText);
            }
            else
            {
                string st1 = "insert into dbo.CUST(C_NO, C_NO1, C_NAME, C_ANAME, C_NAME_E, EMAIL, SPEAK, TEL1, FAX, ADR1, C_NAME1, C_ANAME1," +
                    " C_NAME1_E, EMAIL1, SPEAK1, TEL2, FAX1, ADR2, C_NAME2, C_ANAME2, C_NAME2_E, EMAIL2, SPEAK2, TEL3, FAX2, ADR3, PAY_CON," +
                    " RCV_DATE, DEFA_MONEY, S_NO, ACCOUNT, PAY_PLACE, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, " +
                " RNG01, FT01, RNG02, FT02, RNG03, FT03, RNG04, FT04, RNG05, FT05, ORDOUT, CAROUT, CTY_NO, CTY_NAME, BLIVE,USR_NAME)" +
                " Select SUBSTRING(N'" + txtC_NO.Text + "',0,10), SUBSTRING(N'" + txtC_NO1.Text + "',0,10), SUBSTRING(N'" + txtC_NAME.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME.Text + "',0,20)," +
                " SUBSTRING(N'" + txtC_NAME_E.Text + "',0,50), SUBSTRING(N'" + txtEMAIL.Text + "',0,60)," +
                " SUBSTRING(N'" + txtSPEAK.Text + "',0,20), SUBSTRING(N'" + txtTEL1.Text + "',0,20), SUBSTRING(N'" + txtFAX.Text + "',0,20)," +
                " SUBSTRING(N'" + txtADR1.Text + "',0,60), SUBSTRING(N'" + txtC_NAME1.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME1.Text + "',0,20)," +
                " SUBSTRING(N'" + txtC_NAME1_E.Text + "',0,50), SUBSTRING(N'" + txtEMAIL1.Text + "',0,60), SUBSTRING(N'" + txtSPEAK1.Text + "',0,20)," +
                " SUBSTRING(N'" + txtTEL2.Text + "',0,20), SUBSTRING(N'" + txtFAX1.Text + "',0,20), SUBSTRING(N'" + ttxtADR2.Text + "',0,60)," +
                " SUBSTRING(N'" + txtC_NAME2.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME2.Text + "',0,20), SUBSTRING(N'" + txtC_NAME2_E.Text + "',0,50)," +
                " SUBSTRING(N'" + txtEMAIL2.Text + "',0,60), SUBSTRING(N'" + txtSPEAK2.Text + "',0,20), SUBSTRING(N'" + txtTEL3.Text + "',0,20)," +
                " SUBSTRING(N'" + txtFAX2.Text + "',0,20), SUBSTRING(N'" + txtADR3.Text + "',0,60), SUBSTRING(N'" + txtPAY_CON.Text + "',0,20)," +
                " SUBSTRING(N'" + txtRCV_DATE.Text + "',1,2), SUBSTRING(N'" + txtDEFA_MOMEY.SelectedItem.ToString() + "',0,4), SUBSTRING(N'" + txtS_NO.Text + "',0,5)," +
                " SUBSTRING(N'" + txtACCOUNT.Text + "',0,20), SUBSTRING(N'" + txtPAY_PLACE.Text + "',0,20), SUBSTRING(N'" + txtMEMO1.Text + "',0,60)," +
                " SUBSTRING(N'" + txtMEMO2.Text + "',0,60), SUBSTRING(N'" + txtMEMO3.Text + "',0,60), SUBSTRING(N'" + txtMEMO4.Text + "',0,60)," +
                " SUBSTRING(N'" + txtMEMO5.Text + "',0,60), " + float.Parse(txtRNG01.Text) + ", " + float.Parse(txtFT01.Text) + "," +
                " " + float.Parse(txtRNG02.Text) + ", " + float.Parse(txtFT02.Text) + ", " + float.Parse(txtNRG03.Text) + "," +
                " " + float.Parse(txtFT03.Text) + ", " + float.Parse(txtRNG04.Text) + ", " + float.Parse(txtFT04.Text) + "," +
                " " + float.Parse(txtRNG05.Text) + ", " + float.Parse(txtFT05.Text) + ", SUBSTRING('" + txtORDOUT.Text + "',0,1)," +
                " SUBSTRING(N'" + txtCAROUT.Text + "',0,1), SUBSTRING(N'" + txtCTY_NO.Text + "',0,10), SUBSTRING(N'" + txtCTY_NAME.Text + "',0,50)," +
                " " + float.Parse(txtBLIVE.Text) + ",'" + lbUserName.Text + "' ";

                if (txtC_NO.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText1 + "");
                    return;
                }
                else if (txtDEFA_MOMEY.SelectedItem.ToString() == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (txtRNG01.Text == string.Empty || txtFT01.Text == string.Empty || txtRNG02.Text == string.Empty || txtFT02.Text == string.Empty ||
                    txtNRG03.Text == string.Empty || txtNRG03.Text == string.Empty || txtRNG04.Text == string.Empty || txtFT04.Text == string.Empty || txtRNG05.Text == string.Empty
                    || txtFT05.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (txtBLIVE.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                bool check = conn.exedata(st1);

                //Loaddata();
                //hienthidata();

                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f8ToolStripMenuItem.Enabled = false;
                f10ToolStripMenuItem.Enabled = true;
                if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
                {
                    bt.Text = "NÚT DUYỆT";
                }
                if (DataProvider.LG.rdVietNam == true)
                {
                    bt.Text = "NÚT DUYỆT";
                }
                if (DataProvider.LG.rdEnglish == true)
                {
                    bt.Text = "Browsing Button";
                }
                if (DataProvider.LG.rdChina == true)
                {
                    bt.Text = "瀏覽按鈕";
                }

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                btok.Hide();
                btdong.Hide();

                f2ToolStripMenuItem.Checked = false;
                f3ToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f6ToolStripMenuItem.Checked = false;
            }
        }
        private void DeleteData()
        {
            string sokhachhang = txtC_NO.Text;
            string txt = "";
            if (sokhachhang == "")
            {
                if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
                {
                    txt = "Không có dữ liệu";
                }
                if (DataProvider.LG.rdVietNam == true)
                {
                    txt = "Không có dữ liệu";
                }
                if (DataProvider.LG.rdEnglish == true)
                {
                    txt = "No data";
                }
                if (DataProvider.LG.rdChina == true)
                {
                    txt = "沒有數據";
                }
                MessageBox.Show("" + txt + "");
                return;
            }
            string sql = "delete from CUST where C_NO ='" + sokhachhang + "'";
            bool check = conn.exedata(sql);
            Loaddata();
            hienthidata();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;
        }
        private void UpdateData()
        {
            string st1 = "update dbo.CUST set  C_NO =SUBSTRING(N'" + txtC_NO.Text + "',0,10), C_NO1 =SUBSTRING(N'" + txtC_NO1.Text + "',0,10), C_NAME =SUBSTRING(N'" + txtC_NAME.Text + "',0,50)," +
                        " C_ANAME=SUBSTRING(N'" + txtC_ANAME.Text + "',0,20), C_NAME_E=SUBSTRING(N'" + txtC_NAME_E.Text + "',0,50), EMAIL=SUBSTRING(N'" + txtEMAIL.Text + "',0,60)," +
                        " SPEAK=SUBSTRING(N'" + txtSPEAK.Text + "',0,20), TEL1=SUBSTRING(N'" + txtTEL1.Text + "',0,20), FAX=SUBSTRING(N'" + txtFAX.Text + "',0,20)," +
                        " ADR1=SUBSTRING('" + txtADR1.Text + "',0,60), C_NAME1=SUBSTRING(N'" + txtC_NAME1.Text + "',0,50), C_ANAME1=SUBSTRING(N'" + txtC_ANAME1.Text + "',0,20)," +
                        " C_NAME1_E=SUBSTRING(N'" + txtC_NAME1_E.Text + "',0,50), EMAIL1=SUBSTRING(N'" + txtEMAIL1.Text + "',0,60), SPEAK1=SUBSTRING(N'" + txtSPEAK1.Text + "',0,20)," +
                        " TEL2=SUBSTRING(N'" + txtTEL2.Text + "',0,20), FAX1=SUBSTRING(N'" + txtFAX1.Text + "',0,20), ADR2=SUBSTRING(N'" + ttxtADR2.Text + "',0,60)," +
                        " C_NAME2=SUBSTRING(N'" + txtC_NAME2.Text + "',0,50), C_ANAME2=SUBSTRING(N'" + txtC_ANAME2.Text + "',0,20)," +
                        " C_NAME2_E=SUBSTRING(N'" + txtC_NAME2_E.Text + "',0,50), EMAIL2=SUBSTRING('" + txtEMAIL2.Text + "',0,60)," +
                        " SPEAK2=SUBSTRING(N'" + txtSPEAK2.Text + "',0,20), TEL3=SUBSTRING(N'" + txtTEL3.Text + "',0,20), FAX2=SUBSTRING(N'" + txtFAX2.Text + "',0,20)," +
                        " ADR3=SUBSTRING(N'" + txtADR3.Text + "',0,60), PAY_CON=SUBSTRING(N'" + txtPAY_CON.Text + "',0,20), RCV_DATE=SUBSTRING(N'" + txtRCV_DATE.Text + "',1,2)," +
                        " DEFA_MONEY=SUBSTRING(N'" + txtDEFA_MOMEY.SelectedItem.ToString() + "',0,4), S_NO=SUBSTRING(N'" + txtS_NO.Text + "',0,5), ACCOUNT=SUBSTRING(N'" + txtACCOUNT.Text + "',0,20)," +
                        " PAY_PLACE=SUBSTRING(N'" + txtPAY_PLACE.Text + "',0,20), MEMO1=SUBSTRING(N'" + txtMEMO1.Text + "',0,60), MEMO2=SUBSTRING(N'" + txtMEMO2.Text + "',0,60)," +
                        " MEMO3=SUBSTRING(N'" + txtMEMO3.Text + "',0,60), MEMO4=SUBSTRING(N'" + txtMEMO4.Text + "',0,60), MEMO5=SUBSTRING(N'" + txtMEMO5.Text + "',0,60)," +
                        "  RNG01=" + float.Parse(txtRNG01.Text) + ", FT01=" + float.Parse(txtFT01.Text) + ", RNG02=" + float.Parse(txtRNG02.Text) + "," +
                        " FT02=" + float.Parse(txtFT02.Text) + ", RNG03=" + float.Parse(txtNRG03.Text) + ", FT03=" + float.Parse(txtFT03.Text) + "," +
                        " RNG04=" + float.Parse(txtRNG04.Text) + ", FT04=" + float.Parse(txtFT04.Text) + ", RNG05=" + float.Parse(txtRNG05.Text) + "," +
                        " FT05=" + float.Parse(txtFT05.Text) + ", ORDOUT=SUBSTRING('" + txtORDOUT.Text + "',0,1), CAROUT=SUBSTRING(N'" + txtCAROUT.Text + "',0,1)," +
                        " CTY_NO=SUBSTRING(N'" + txtCTY_NO.Text + "',0,10), CTY_NAME=SUBSTRING(N'" + txtCTY_NAME.Text + "',0,50)," +
                        " BLIVE=" + float.Parse(txtBLIVE.Text) + ",USR_NAME = '" + lbUserName.Text + "' where C_NO = N'" + txtC_NO.Text + "'";

            if (txtC_NO.Text == string.Empty)
            {
                MessageBox.Show("" + txtText1 + "");
                return;
            }
            else if (txtDEFA_MOMEY.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("" + txtText2 + "");
                return;
            }
            else if (txtRNG01.Text == string.Empty || txtFT01.Text == string.Empty || txtRNG02.Text == string.Empty || txtFT02.Text == string.Empty ||
                txtNRG03.Text == string.Empty || txtNRG03.Text == string.Empty || txtRNG04.Text == string.Empty || txtFT04.Text == string.Empty || txtRNG05.Text == string.Empty
                || txtFT05.Text == string.Empty)
            {
                MessageBox.Show("" + txtText3 + "");
                return;
            }
            else if (txtBLIVE.Text == string.Empty)
            {
                MessageBox.Show("" + txtText4 + "");
                return;
            }
            bool ckeck = conn.exedata(st1);

            //Loaddata();
            //hienthidata();
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f8ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;

            bt.Text = "" + txtDuyet + "";

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;

            btok.Hide();
            btdong.Hide();

            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f6ToolStripMenuItem.Checked = false;

            //trả lại lock
            txtC_NO.Enabled = true;
        }
        private void CopyData()
        {
            string a = txtC_NO.Text;
            string SQL = "select C_NO from Cust WHERE C_NO = '" + a + "'";
            DataTable dt = conn.readdata(SQL);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(txtText);
            }
            else
            {
                string st1 = "insert into dbo.CUST(C_NO, C_NO1, C_NAME, C_ANAME, C_NAME_E, EMAIL, SPEAK, TEL1, FAX, ADR1, C_NAME1, C_ANAME1," +
                    " C_NAME1_E, EMAIL1, SPEAK1, TEL2, FAX1, ADR2, C_NAME2, C_ANAME2, C_NAME2_E, EMAIL2, SPEAK2, TEL3, FAX2, ADR3, PAY_CON," +
                    " RCV_DATE, DEFA_MONEY, S_NO, ACCOUNT, PAY_PLACE, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, " +
                " RNG01, FT01, RNG02, FT02, RNG03, FT03, RNG04, FT04, RNG05, FT05, ORDOUT, CAROUT, CTY_NO, CTY_NAME, BLIVE,USR_NAME)" +
                " Select SUBSTRING(N'" + txtC_NO.Text + "',0,10), SUBSTRING(N'" + txtC_NO1.Text + "',0,10), SUBSTRING(N'" + txtC_NAME.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME.Text + "',0,20)," +
                " SUBSTRING(N'" + txtC_NAME_E.Text + "',0,50), SUBSTRING(N'" + txtEMAIL.Text + "',0,60)," +
                " SUBSTRING(N'" + txtSPEAK.Text + "',0,20), SUBSTRING(N'" + txtTEL1.Text + "',0,20), SUBSTRING(N'" + txtFAX.Text + "',0,20)," +
                " SUBSTRING(N'" + txtADR1.Text + "',0,60), SUBSTRING(N'" + txtC_NAME1.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME1.Text + "',0,20)," +
                " SUBSTRING(N'" + txtC_NAME1_E.Text + "',0,50), SUBSTRING('" + txtEMAIL1.Text + "',0,60), SUBSTRING('" + txtSPEAK1.Text + "',0,20)," +
                " SUBSTRING(N'" + txtTEL2.Text + "',0,20), SUBSTRING(N'" + txtFAX1.Text + "',0,20), SUBSTRING(N'" + ttxtADR2.Text + "',0,60)," +
                " SUBSTRING(N'" + txtC_NAME2.Text + "',0,50), SUBSTRING(N'" + txtC_ANAME2.Text + "',0,20), SUBSTRING(N'" + txtC_NAME2_E.Text + "',0,50)," +
                " SUBSTRING(N'" + txtEMAIL2.Text + "',0,60), SUBSTRING(N'" + txtSPEAK2.Text + "',0,20), SUBSTRING(N'" + txtTEL3.Text + "',0,20)," +
                " SUBSTRING(N'" + txtFAX2.Text + "',0,20), SUBSTRING(N'" + txtADR3.Text + "',0,60), SUBSTRING(N'" + txtPAY_CON.Text + "',0,20)," +
                " SUBSTRING('" + txtRCV_DATE.Text + "',1,2), SUBSTRING(N'" + txtDEFA_MOMEY.SelectedItem.ToString() + "',0,4), SUBSTRING(N'" + txtS_NO.Text + "',0,5)," +
                " SUBSTRING(N'" + txtACCOUNT.Text + "',0,20), SUBSTRING(N'" + txtPAY_PLACE.Text + "',0,20), SUBSTRING(N'" + txtMEMO1.Text + "',0,60)," +
                " SUBSTRING(N'" + txtMEMO2.Text + "',0,60), SUBSTRING(N'" + txtMEMO3.Text + "',0,60), SUBSTRING(N'" + txtMEMO4.Text + "',0,60)," +
                " SUBSTRING(N'" + txtMEMO5.Text + "',0,60), " + float.Parse(txtRNG01.Text) + ", " + float.Parse(txtFT01.Text) + "," +
                " " + float.Parse(txtRNG02.Text) + ", " + float.Parse(txtFT02.Text) + ", " + float.Parse(txtNRG03.Text) + "," +
                " " + float.Parse(txtFT03.Text) + ", " + float.Parse(txtRNG04.Text) + ", " + float.Parse(txtFT04.Text) + "," +
                " " + float.Parse(txtRNG05.Text) + ", " + float.Parse(txtFT05.Text) + ", SUBSTRING('" + txtORDOUT.Text + "',0,1)," +
                " SUBSTRING(N'" + txtCAROUT.Text + "',0,1), SUBSTRING(N'" + txtCTY_NO.Text + "',0,10), SUBSTRING(N'" + txtCTY_NAME.Text + "',0,50)," +
                " " + float.Parse(txtBLIVE.Text) + ",'" + lbUserName.Text + "' ";
                bool check = conn.exedata(st1);

                if (txtC_NO.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText1 + "");
                    return;
                }
                else if (txtDEFA_MOMEY.SelectedItem.ToString() == string.Empty)
                {
                    MessageBox.Show("" + txtText2 + "");
                    return;
                }
                else if (txtRNG01.Text == string.Empty || txtFT01.Text == string.Empty || txtRNG02.Text == string.Empty || txtFT02.Text == string.Empty ||
                    txtNRG03.Text == string.Empty || txtNRG03.Text == string.Empty || txtRNG04.Text == string.Empty || txtFT04.Text == string.Empty || txtRNG05.Text == string.Empty
                    || txtFT05.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText3 + "");
                    return;
                }
                else if (txtBLIVE.Text == string.Empty)
                {
                    MessageBox.Show("" + txtText4 + "");
                    return;
                }

                Loaddata();
                hienthidata();
                f1ToolStripMenuItem.Enabled = false;
                f2ToolStripMenuItem.Enabled = true;
                f3ToolStripMenuItem.Enabled = true;
                f4ToolStripMenuItem.Enabled = true;
                f5ToolStripMenuItem.Enabled = true;
                f6ToolStripMenuItem.Enabled = true;
                f7ToolStripMenuItem.Enabled = true;
                f8ToolStripMenuItem.Enabled = false;
                f10ToolStripMenuItem.Enabled = true;
                bt.Text = "" + txtDuyet + "";

                btdau.Enabled = true;
                bttruoc.Enabled = true;
                btsau.Enabled = true;
                btketthuc.Enabled = true;

                btok.Hide();
                btdong.Hide();

                f2ToolStripMenuItem.Checked = false;
                f3ToolStripMenuItem.Checked = false;
                f4ToolStripMenuItem.Checked = false;
                f6ToolStripMenuItem.Checked = false;
            }
        }
        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                checkNofication();
                string st = CN.str;
                SqlConnection con = new SqlConnection(st);
                if (f2ToolStripMenuItem.Checked == true)
                {
                    addData();
                }
                else if (f3ToolStripMenuItem.Checked == true)
                {
                    DeleteData();
                }
                else if (f4ToolStripMenuItem.Checked == true)
                {
                    UpdateData();
                }
                else if (f6ToolStripMenuItem.Checked == true)
                {
                    CopyData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        public void Get_DLF5()
        {
            bindingsource = new BindingSource();
            bindingsource.DataSource = Form1AF5.DI.data;
            //bindingsource.ResetBindings(false);
            bindingsource.Position = Form1AF5.DL.index;

            this.txtC_NO.Text = Form1AF5.DL.t1;
            this.txtC_NO1.Text = Form1AF5.DL.t2;
            this.txtC_NAME.Text = Form1AF5.DL.t3;
            this.txtC_ANAME.Text = Form1AF5.DL.t4;
            this.txtC_NAME_E.Text = Form1AF5.DL.t5;

            this.txtEMAIL.Text = Form1AF5.DL.t6;
            this.txtSPEAK.Text = Form1AF5.DL.t7;
            this.txtTEL1.Text = Form1AF5.DL.t8;
            this.txtFAX.Text = Form1AF5.DL.t9;
            this.txtADR1.Text = Form1AF5.DL.t10;

            this.txtC_NAME1.Text = Form1AF5.DL.t11;
            this.txtC_ANAME1.Text = Form1AF5.DL.t12;
            this.txtC_NAME1_E.Text = Form1AF5.DL.t13;
            this.txtEMAIL1.Text = Form1AF5.DL.t14;
            this.txtSPEAK1.Text = Form1AF5.DL.t15;

            this.txtTEL2.Text = Form1AF5.DL.t16;
            this.txtFAX1.Text = Form1AF5.DL.t17;
            this.ttxtADR2.Text = Form1AF5.DL.t18;
            this.txtC_NAME2.Text = Form1AF5.DL.t20;
            this.txtC_ANAME2.Text = Form1AF5.DL.t21;

            this.txtC_NAME2_E.Text = Form1AF5.DL.t22;
            this.txtEMAIL2.Text = Form1AF5.DL.t23;
            this.txtSPEAK2.Text = Form1AF5.DL.t24;
            this.txtTEL3.Text = Form1AF5.DL.t25;
            this.txtFAX2.Text = Form1AF5.DL.t26;

            this.txtADR3.Text = Form1AF5.DL.t27;
            this.txtPAY_CON.Text = Form1AF5.DL.t28;
            this.txtRCV_DATE.Text = Form1AF5.DL.t29;
            this.txtDEFA_MOMEY.Text = Form1AF5.DL.c1;
            // this.txt1.Text = Form1AF5.DL.t30;

            this.txtS_NO.Text = Form1AF5.DL.t30;
            this.txtACCOUNT.Text = Form1AF5.DL.t31;
            this.txtPAY_PLACE.Text = Form1AF5.DL.t32;
            this.txtMEMO1.Text = Form1AF5.DL.t33;
            this.txtMEMO2.Text = Form1AF5.DL.t34;
            this.txtMEMO3.Text = Form1AF5.DL.t35;

            this.txtMEMO4.Text = Form1AF5.DL.t36;
            this.txtMEMO5.Text = Form1AF5.DL.t37;
            this.txtRNG01.Text = Form1AF5.DL.t38;
            this.txtFT01.Text = Form1AF5.DL.t39;
            this.txtRNG02.Text = Form1AF5.DL.t40;
            this.txtFT02.Text = Form1AF5.DL.t41;

            this.txtNRG03.Text = Form1AF5.DL.t42;
            this.txtFT03.Text = Form1AF5.DL.t43;
            this.txtRNG04.Text = Form1AF5.DL.t44;
            this.txtFT04.Text = Form1AF5.DL.t45;
            this.txtRNG05.Text = Form1AF5.DL.t46;

            this.txtFT05.Text = Form1AF5.DL.t47;
            this.txtORDOUT.Text = Form1AF5.DL.t48;
            this.txtCAROUT.Text = Form1AF5.DL.t49;
            this.txtCTY_NO.Text = Form1AF5.DL.t50;
            this.txtCTY_NAME.Text = Form1AF5.DL.t51;
            this.txtBLIVE.Text = Form1AF5.DL.t52;

            this.lblEditBy.Text = Form1AF5.DL.t53;

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
            tab(txtC_NO1, txtBLIVE, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME, txtC_NO, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_ANAME, txtC_NO1, sender, e);
        }
        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME_E, txtC_NAME, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtEMAIL, txtC_ANAME, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtSPEAK, txtC_NAME_E, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTEL1, txtEMAIL, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFAX, txtSPEAK, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtADR1, txtTEL1, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME1, txtFAX, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_ANAME1, txtADR1, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME1_E, txtC_NAME1, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {

            tab(txtEMAIL1, txtC_ANAME1, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtSPEAK1, txtC_NAME1_E, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTEL2, txtEMAIL1, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFAX1, txtSPEAK1, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(ttxtADR2, txtTEL2, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME2, txtFAX1, sender, e);
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_ANAME2, ttxtADR2, sender, e);
        }

        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NAME2_E, txtC_NAME2, sender, e);
        }

        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtEMAIL2, txtC_ANAME2, sender, e);
        }

        private void tb23_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtSPEAK2, txtC_NAME2_E, sender, e);
        }

        private void tb24_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtTEL3, txtEMAIL2, sender, e);
        }
        private void tb25_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFAX2, txtSPEAK2, sender, e);
        }
        private void tb26_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtADR3, txtTEL3, sender, e);
        }
        private void tb27_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtC_NO, txtFAX2, sender, e);
        }
        private void tb28_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtRCV_DATE, txtPAY_CON, sender, e);
        }
        private void tb29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDEFA_MOMEY.Focus();
            }
        }

        private void cb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt1.Focus();
            }
        }

        private void tb30_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtS_NO, txtRCV_DATE, sender, e);
        }

        private void tb31_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtACCOUNT, txt1, sender, e);
        }

        private void tb32_KeyDown(object sender, KeyEventArgs e)
        {

            tab(txtPAY_PLACE, txtS_NO, sender, e);
        }

        private void tb33_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO1, txtACCOUNT, sender, e);
        }

        private void tb34_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO2, txtPAY_PLACE, sender, e);
        }

        private void tb35_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO3, txtMEMO1, sender, e);
        }

        private void tb36_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO4, txtMEMO2, sender, e);
        }

        private void tb37_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtMEMO5, txtMEMO3, sender, e);
        }

        private void tb38_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFT01, txtMEMO4, sender, e);
        }

        private void tb39_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtRNG02, txtRNG01, sender, e);
        }

        private void tb40_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFT02, txtFT01, sender, e);
        }
        private void tb41_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtNRG03, txtRNG02, sender, e);
        }

        private void tb42_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFT03, txtFT02, sender, e);
        }

        private void tb43_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtRNG04, txtNRG03, sender, e);
        }

        private void tb44_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFT04, txtFT03, sender, e);
        }

        private void tb45_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtRNG05, txtRNG04, sender, e);
        }

        private void tb46_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtFT05, txtFT04, sender, e);
        }

        private void tb47_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtORDOUT, txtRNG05, sender, e);
        }
        private void tb48_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCAROUT, txtFT05, sender, e);
        }

        private void tb49_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtPAY_CON, txtORDOUT, sender, e);
        }

        private void tb50_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCTY_NAME, txtCAROUT, sender, e);
        }

        private void tb51_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtBLIVE, txtCTY_NO, sender, e);
        }

        private void tb52_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtCTY_NO, txtCTY_NAME, sender, e);
        }

        private void tb17_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimeNow_Click(object sender, EventArgs e)
        {

        }

        private void txtADR3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDEFA_MOMEY_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMEMO5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(txtRNG01, txtMEMO4, sender, e);
        }

        private void txtCTY_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f2ToolStripMenuItem.Checked == true || f4ToolStripMenuItem.Checked == true || f6ToolStripMenuItem.Checked == true)
            {
                FrmSearchMEMO1 frm = new FrmSearchMEMO1();
                frm.ShowDialog();
                txtCTY_NO.Text = FrmSearchMEMO1.ID.M_ID;
                txtCTY_NAME.Text = FrmSearchMEMO1.ID.M_NAME;
            }
        }
    }
}
