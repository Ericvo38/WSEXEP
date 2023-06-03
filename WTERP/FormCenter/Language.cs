using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
        
namespace WTERP
{
    public partial class Language : Form
    {
        DataProvider conn = new DataProvider();
        public Language()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        string txtThongBao = "";
        string txtThongBao1 = "";
        private void Langues_Load(object sender, EventArgs e)
        {
            check();
            progressBar1.Visible = false;
        }
        public void check()
        {
            string User = frmLogin.ID_USER;
            string sql = "SELECT LANGUAGE FROM USRH WHERE USER_ID = '" + User + "'";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["LANGUAGE"].ToString() == "1")
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                    txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
                    rdVN.Text = "Tiếng Việt";
                    rdENL.Text = "Tiếng Anh";
                    rdCH.Text = "Tiếng Trung";
                    this.Text = "Thay Đổi Ngôn Ngữ";
                    groupBox11.Text = "Ngôn Ngữ";
                    button1.Text = "Đồng Ý";
                    rdVN.Checked = true;
                }
                else if (dataRow["LANGUAGE"].ToString() == "2")
                {
                    txtThongBao = "Language Switch Successfully";
                    txtThongBao1 = "Language Switch Failed";
                    rdVN.Text = "Vietnamese";
                    rdENL.Text = "English";
                    rdCH.Text = "Chinese";
                    this.Text = "Change Language";
                    groupBox11.Text = "Language";
                    button1.Text = "OK";
                    rdENL.Checked = true;
                }
                else if (dataRow["LANGUAGE"].ToString() == "3")
                {
                    txtThongBao = "語言切換成功";
                    txtThongBao1 = "語言切換失敗";
                    rdVN.Text = "越南語";
                    rdENL.Text = "英語";
                    rdCH.Text = "中文";
                    this.Text = "改變語言";
                    groupBox11.Text = "語";
                    button1.Text = "同意";
                    rdCH.Checked = true;
                }
                else
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                    txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
                    rdVN.Text = "Tiếng Việt";
                    rdENL.Text = "Tiếng Anh";
                    rdCH.Text = "Tiếng Trung";
                    this.Text = "Thay Đổi Ngôn Ngữ";
                    groupBox11.Text = "Ngôn Ngữ";
                    button1.Text = "Đồng Ý";
                    rdVN.Checked = true;
                }
            }
        }
        private void CaluculateAll(System.Windows.Forms.ProgressBar progressBar)
        {
            progressBar1.Visible = true;
            progressBar.Maximum = 30;
            progressBar.Step = 1;

            for (int j = 0; j <= 30; j++)
            {
                double pow = Math.Pow(j, j); //Calculation
                progressBar.PerformStep();
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string User = frmLogin.ID_USER;
            string check = "";
            try
            {
                if (txtThongBao.ToString() == "")
                {
                    txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
                }
                if (rdVN.Checked == true)
                {
                    check = "1";
                }
                else if (rdENL.Checked == true)
                {
                    check = "2";
                }
                else if (rdCH.Checked == true)
                {
                    check = "3";
                }
                string sql = "UPDATE USRH set LANGUAGE = '" + check + "' from USRH where USER_ID = '" + User + "'";
                bool kiemtra = conn.exedata(sql);
                if (kiemtra == true)
                {
                    CaluculateAll(progressBar1);
                    DialogResult dialog = MessageBox.Show(txtThongBao,"",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (dialog == DialogResult.Yes)
                    {
                        Application.Restart();
                    }    
                }
                else
                {
                    CaluculateAll(progressBar1);
                    MessageBox.Show(txtThongBao1);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }
        private void rdVN_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "Chuyển Đổi Ngôn Ngữ Thành Công";
            txtThongBao1 = "Chuyển Đổi Ngôn Ngữ Thất Bại";
            rdVN.Text = "Tiếng Việt";
            rdENL.Text = "Tiếng Anh";
            rdCH.Text = "Tiếng Trung";
            this.Text = "Thay Đổi Ngôn Ngữ";
            groupBox11.Text = "Ngôn Ngữ";
            button1.Text = "Đồng Ý";
        }
        private void rdENL_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "Language Switch Successfully";
            txtThongBao1 = "Language Switch Failed";
            rdVN.Text = "Vietnamese";
            rdENL.Text = "English";
            rdCH.Text = "Chinese";
            this.Text = "Change Language";
            groupBox11.Text = "Language";
            button1.Text = "OK";
        }
        private void rdCH_CheckedChanged(object sender, EventArgs e)
        {
            txtThongBao = "語言切換成功";
            txtThongBao1 = "語言切換失敗";
            rdVN.Text = "越南語";
            rdENL.Text = "英語";
            rdCH.Text = "中文";
            this.Text = "改變語言";
            groupBox11.Text = "語";
            button1.Text = "同意";
        }
    }
}
