using System;
using System.Windows.Forms;
using WTERP.FormCenter;

namespace WTERP
{
    public partial class FormMainMenu : Form
    {
        DataProvider conn = new DataProvider();
        public FormMainMenu()
        {
            InitializeComponent();
        }
        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            lblDateHours.Text = CN.getDateNowE() + " - " + CN.getTimeNowE();
            setLanguage();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grBKinhDoanh_Click(object sender, EventArgs e)
        {
            frmWSEXE frmLogin = new frmWSEXE();
            frmLogin.ShowDialog();
        }
        private void button4_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Chức Năng đang phát triển!");
            //BackUpDatabase backUp = new BackUpDatabase();
            //backUp.ShowDialog();
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Language fr1 = new Language();
            fr1.Show();
            this.Hide();
        }
        public void setLanguage()
        {

                this.Text = "HOME";
                label1.Text = "FUNCTION";
                button1.Text = "Software updates";
                button2.Text = "Data recovery";
                label2.Text = "DISPLAY";
                button3.Text = "Language";
                button4.Text = "Theme";
                label3.Text = "INFORMATION";
                label6.Text = "- Contact 505";
                label7.Text = "- Group Trello";
                button5.Text = "Exit";
                label5.Text = "HOME";
                grBKinhDoanh.Text = "Business";
                grBBarcode.Text = "Barcode";
                grBThuMuaWeitai.Text = "Purchase (WEITAI)";
                grBThuMuaTaiYu.Text = "Purchase (TaiYu)";
                grBCongVu.Text = "Equipment - Repair";
                grBXuatNhapKhau.Text = "Import and Export";

            //}
            //if (Language.LG.rdChina == true)
            //{
            //    this.Text = "家";
            //    label1.Text = "功能";
            //    button1.Text = "軟件更新";
            //    button2.Text = "數據恢復";
            //    label2.Text = "展示";
            //    button3.Text = "語";
            //    button4.Text = "主題";
            //    label3.Text = "信息";
            //    label6.Text = "- 聯繫 505";
            //    label7.Text = "-組 Trello";
            //    button5.Text = "出口";
            //    label5.Text = "家";
            //    grBKinhDoanh.Text = "商業";
            //    grBBarcode.Text = "條碼";
            //    grBThuMuaWeitai.Text = "購買 (WEITAI)";
            //    grBThuMuaTaiYu.Text = "購買 (TaiYu)";
            //    grBCongVu.Text = "設備";
            //    grBXuatNhapKhau.Text = "進出口";
            //}
        }


        private void panel10_Click(object sender, EventArgs e)
        {
            frmWSEXE frm = new frmWSEXE();
            frm.Show();
        }

        private void panel11_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateHours.Text = CN.getDateNowE() + " - " + CN.getTimeNowE();
        }
    }
}
