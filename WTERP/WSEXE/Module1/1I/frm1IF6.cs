using LibraryCalender;
using System;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1IF6 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1IF6()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public static string Date;
        public static string type;
        public static string Baogia;
        //public static string Text;
        private void label1_Click(object sender, EventArgs e)
        {

        }
        string a = "";
        void check()
        {
           
            if (conn.Check_MaskedText(txtDate) == true)
            {
                a = txtDate.Text;
            }
        }
        private void Form1IF6_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void txtDate_Click(object sender, EventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        string txtText9 = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtText9 = "Bảng giá này đã tồn tại, Vui lòng kiểm tra lại !";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText9 = "Bảng giá này đã tồn tại, Vui lòng kiểm tra lại !";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText9 = "This price list already exists, Please check again!";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText9 = "此價目表已存在，請再次查看！";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check();
            checkNofication();
            string SQL = "SELECT WS_NO FROM QUOH WHERE WS_NO = '" + txtBaoGia.Text + "' ";
            string ID = "WS_NO";
            string Result = conn.ID(SQL, ID);
            if (Result == txtBaoGia.Text)
            {
                MessageBox.Show("" + txtText9 + "");
                return;
            }
            if (a != "" && txtLoai.Text != "" && txtBaoGia.Text != "")
            {
                Date = a;
                type = txtLoai.Text;
                Baogia = txtBaoGia.Text;
                Text = Form1I.Text1;
                this.Close();
            }
            else
            {
                if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
                {
                    MessageBox.Show("Dữ liệu không được để trống ?", "Thông Báo");
                    txtBaoGia.Focus();
                }    
               else if (DataProvider.LG.rdVietNam == true)
                {
                    MessageBox.Show("Dữ liệu không được để trống ?", "Thông Báo");
                    txtBaoGia.Focus();
                }
                else if (DataProvider.LG.rdEnglish == true)
                {
                    MessageBox.Show("Data cannot be blank?", "Nofication");
                    txtBaoGia.Focus();
                }
                else if (DataProvider.LG.rdChina == true)
                {
                    MessageBox.Show("數據不能為空？", "通知");
                    txtBaoGia.Focus();
                }   
                
                
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtLoai_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtDate, txtBaoGia, sender, e);
        }

        private void txtBaoGia_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(txtLoai, button1, sender, e);
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }    
        }
        private void txtDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtDate, txtLoai, sender, e);
        }
    }
}
