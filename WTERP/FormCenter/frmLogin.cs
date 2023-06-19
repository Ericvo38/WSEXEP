using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.AccessControl;

namespace WTERP
{
    public partial class frmLogin : Form
    {
        DataProvider con = new DataProvider();
        public static int Lang_ID = 1;
        public static string ID_USER, ID_NAME;
        public frmLogin()
        {
            con.choose_languege();
            InitializeComponent();
        }
        

        private void SetRememberUser(string USR)
        {
            string FileName = "LogName.Text";
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Log\\";
            var FullPath = filePath + FileName;
            if (File.Exists(FullPath))
            {
                File.Delete(FullPath);
            }
            using (var tw = new StreamWriter(FullPath, true))
            {
                tw.WriteLine(USR);
                tw.Close();
            }
        }
        private string GetRememberUser()
        {
            string FileName = "LogName.Text";
            string filePath = Environment.CurrentDirectory + "\\Log\\";
            string User = "";
            if (!File.Exists(filePath + FileName))
            {
                Directory.CreateDirectory(filePath);
            }
            else
            {
                StreamReader read = new StreamReader(filePath + FileName, true);
                User = read.ReadToEnd().Trim();
                read.Close();
            }
            return User;
        }
        public void SetLangdefaul(int ID_LANG)
        {
            string FileName = "Langdefaul.Text";
            string filePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Log\\";
            if (!File.Exists(filePath + FileName))
            {
                Directory.CreateDirectory(filePath);
                SetFolderPermission(filePath);
            }

            StreamWriter write = new StreamWriter(filePath + FileName);
            write.WriteLine(ID_LANG);
            write.Close();
        }
        public void SetFolderPermission(string folderPath)
        {
            var directoryInfo = new DirectoryInfo(folderPath);
            var directorySecurity = directoryInfo.GetAccessControl();
            var currentUserIdentity = WindowsIdentity.GetCurrent();
            var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                          FileSystemRights.ReadAndExecute,
                                                          InheritanceFlags.ObjectInherit |
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.None,
                                                          AccessControlType.Allow);

            directorySecurity.AddAccessRule(fileSystemRule);
            directoryInfo.SetAccessControl(directorySecurity);
        }
        
        int dem = 0;
        string txtThongBao = "";
        string txtText = "";
        string txtText_Thoat = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = con.getID(txtUser.Text.Trim(), txtPassWord.Text.Trim());
            settxtThongBao();
            if (ID_USER != "")
            {
                if (checkBoxremem.Checked) SetRememberUser(txtUser.Text);
                Lang_ID = SetLangID();
                frmWSEXE frm = new frmWSEXE();
                this.Enabled = false;
                frm.ShowDialog();
                this.Enabled = true;

            }
            else
            {
                dem++;
                MessageBox.Show(""+ txtText + "", ""+ txtThongBao + "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Clear();
                txtPassWord.Focus();
                if (dem == 3)
                {
                    this.Close();
                }    
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            settxtThongBao();
            DialogResult clo = MessageBox.Show(""+ txtText_Thoat + "", ""+ txtThongBao + "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (clo == DialogResult.OK)
            {
                con.Closeconnect();
                this.Close();
            }
        }
        
        void getNameID()
        {
            if(txtUser.Text != "")
            {
                string str = "Select USER_ID,NAME FROM USRH WHERE USER_ID ='" + txtUser.Text + "'";
                DataTable dt1 = con.readdata(str);
                foreach (DataRow dr in dt1.Rows)
                {
                    lblName.Text = "User: " + dr["NAME"].ToString();
                    txtUser.Text = dr["USER_ID"].ToString();
                    ID_NAME = dr["NAME"].ToString();
                }
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Closeconnect();
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)//GetLangdefaul()
        {
            txtUser.Text = GetRememberUser();
            LoadCombobox();
            Lang_ID = SetLangID();
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment add = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                lblUpdate.Text = " " + add.CurrentVersion.ToString();
            }
        }
        private void txtPassWord_Click(object sender, EventArgs e)
        {
            getNameID();
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                txtPassWord.Focus();
                getNameID();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
                lblName.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
  
        private void picEye_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = (char)0;
            picEye.Visible = false;
            picLockEye.Visible = true;
        }

        private void picLockEye_Click(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '*';
            picEye.Visible = true;
            picLockEye.Visible = false;
        }
        private void picLockEye_MouseHover(object sender, EventArgs e)
        {

        }

        private void picEye_MouseHover(object sender, EventArgs e)
        {

        }
        public void settxtThongBao()
        {
            
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdChina == false && DataProvider.LG.rdEnglish == false)
            {
                txtText = "Tài khoảng và mật khẩu không đúng Lần : " + dem;
                txtThongBao = "Thông Báo";
                txtText_Thoat = "Bạn có muốn thoát chương trình không ?";
            } 
            if (DataProvider.LG.rdVietNam == true)
            {
                txtText = "Tài khoảng và mật khẩu không đúng Lần : " + dem ;
                txtThongBao = "Thông Báo";
                txtText_Thoat = "Bạn có muốn thoát chương trình không ?";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtText = "Username and password are incorrect : " + dem;
                txtThongBao = "Nofication";
                txtText_Thoat = "Do you want to exit the program?";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtText = "用戶名和密碼不正確 : " + dem;
                txtThongBao = "通知";
                txtText_Thoat = "您要退出程序嗎？";
            }
        }
        private void lblUpdate_Click(object sender, EventArgs e)
        {
            frmUpdate fm = new frmUpdate();
            this.Enabled = false;
            fm.ShowDialog();
            this.Enabled = true;
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            //Language fm = new Language();
            //this.Enabled = false;
            //fm.ShowDialog();
            //this.Enabled = true;
            frmUpdate fm = new frmUpdate();
            this.Enabled = false;
            fm.ShowDialog();
            this.Enabled = true;
        }
        #region Move Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void pnMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pnlLogin_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        #endregion
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLangdefaul(comboBox1.SelectedIndex);
            LoadLang(comboBox1.SelectedIndex);
            LoadCombobox();
        }
        private void LoadLang(int ID)
        {
            if(ID == 0)
            {
                label1.Text = "Đăng Nhập";
                checkBoxremem.Text = "Nhớ tên đăng nhập";
                btnLogin.Text = "Đăng nhập";
                button1.Text = "Thoát";
                lblUpdate.Text = "Cập nhật";
                blLanguage.Text = "Chọn ngôn ngữ:";
                comboBox1.Text = "Việt Nam";
            }
            else if(ID == 1)
            {
                label1.Text = "Login System";
                checkBoxremem.Text = "Remember me";
                btnLogin.Text = "Login";
                button1.Text = "Cancel";
                lblUpdate.Text = "Update"; 
                blLanguage.Text = "Choose a language:";
                comboBox1.Text = "English";
            }
            else if(ID == 2)
            {
                label1.Text = "登录系统";
                checkBoxremem.Text = "记住账号";
                btnLogin.Text = "登录";
                button1.Text = "取消";
                lblUpdate.Text = "更新";
                blLanguage.Text = "选择语言：";
                comboBox1.Text = "中文";
            }
            else
            {
                label1.Text = "Đăng Nhập";
                checkBoxremem.Text = "Nhớ tên đăng nhập";
                btnLogin.Text = "Đăng nhập";
                button1.Text = "Thoát";
                lblUpdate.Text = "Cập nhật";
                blLanguage.Text = "Chọn ngôn ngữ:";
                comboBox1.Text = "Việt Nam";
            }
        }
        private void LoadCombobox()
        {
            if (con.GetLangdefaul() == 0)
            {
                comboBox1.Text = "Tiếng việt";
            }
            if (con.GetLangdefaul() == 1)
            {
                comboBox1.Text = "English";
            }
            if (con.GetLangdefaul() == 2)
            {
                comboBox1.Text = "中文";
            }
        }
        private int SetLangID()
        {
            int Result = 1;
            if (comboBox1.SelectedIndex == 0) Result = 1;
            if (comboBox1.SelectedIndex == 1) Result = 2;
            if (comboBox1.SelectedIndex == 2) Result = 3;

            return Result;
        }
    }
}
