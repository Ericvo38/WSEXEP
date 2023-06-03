using System;
using System.Deployment.Application;
using System.Windows.Forms;


namespace WTERP
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            TitleUpdate();
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment add = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                lblVersion.Text = "" + add.CurrentVersion.ToString();
            }
        }
        private void CheckUpdate()
        {
            UpdateCheckInfo info;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException ddde)
                {
                    
                    MessageBox.Show(Messa1() + ddde.Message, TitleMessage(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show(Messa2() + ide.Message, TitleMessage(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show(Messa3() + ioe.Message, TitleMessage(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (info.UpdateAvailable)
                {
                    if (MessageBox.Show(Messa6(), TitleMessage(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            DisabledForm();
                            Cursor.Current = Cursors.WaitCursor;
                            ad.Update();
                            EnabledForm();
                            Application.Restart();
                            Cursor.Current = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                else
                MessageBox.Show(Messa4(), TitleMessage(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(Messa5(), TitleMessage(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private string Messa1()
        {
            string Result = "The new version of the application can't be download at this time.\n\nPlease check your network connection or try again later. Error: ";
            if (DataProvider.LG.rdVietNam) Result = "Không thể tải xuống phiên bản mới của ứng dụng tại thời điểm này. \n\n nVui lòng kiểm tra kết nối mạng của bạn hoặc thử lại sau. \nLỗi: ";
            if (DataProvider.LG.rdEnglish) Result = "The new version of the application can't be download at this time.\n\nPlease check your network connection or try again later. Error: ";
            if (DataProvider.LG.rdChina) Result = "目前无法下载新版本的应用程序。\n\n请检查您的网络连接或稍后重试。 错误：";
            return Result;
        }
        private string Messa2()
        {
            string Result = "Can't check for a new Version of the application. The clickOnce deplopment is corrup. Please redeloy the application and try again. Error: ";
            if (DataProvider.LG.rdVietNam) Result = "Không thể kiểm tra Phiên bản mới của ứng dụng, Vui lòng triển khai ứng dụng và thử lại. \nLỗi:  ";
            if (DataProvider.LG.rdEnglish) Result = "Can't check for a new Version of the application. The clickOnce deplopment is corrup. Please redeloy the application and try again. Error:  ";
            if (DataProvider.LG.rdChina) Result = "无法检查应用程序的新版本。 clickOnce 部署已损坏。 请部署应用程序并重试。 错误： ";
            return Result;
        }
        private string Messa3()
        {
            string Result = "This application can't be updated. It's like not a ClickOnce Application. Error: ";
            if (DataProvider.LG.rdVietNam) Result = "Không thể cập nhật ứng dụng này. Nó giống như không phải là một lần nhấp vào ứng dụng. Lỗi:  ";
            if (DataProvider.LG.rdEnglish) Result = "This application can't be updated. It's like not a ClickOnce Application. Error:  ";
            if (DataProvider.LG.rdChina) Result = "无法更新此应用程序。 这就像不是 ClickOnce 应用程序。 错误： ";
            return Result;
        }
        private string Messa4()
        {
            string Result = "You are running the lastest version. ";
            if (DataProvider.LG.rdVietNam) Result = "Hiện tại chưa có bản cập nhật mới, phiên bản bạn đang chạy là phiên bản mới nhất. ";
            if (DataProvider.LG.rdEnglish) Result = "You are running the lastest version. ";
            if (DataProvider.LG.rdChina) Result = "您正在运行最新版本。 ";
            return Result;
        }
        private string Messa5()
        {
            string Result = "Please check your connection and try again!";
            if (DataProvider.LG.rdVietNam) Result = "Vui lòng kiểm tra lại đường truyền của bạn và thử lại! ";
            if (DataProvider.LG.rdEnglish) Result = "Please check your connection and try again! ";
            if (DataProvider.LG.rdChina) Result = "请检查您的连接并重试！ ";
            return Result;
        }
        private string Messa6()
        {
            string Result = "A newer version is available. would you like to update it now " ;
            if (DataProvider.LG.rdVietNam) Result = "Có một phiên bản mới hơn, bạn có muốn cập nhật nó ? ";
            if (DataProvider.LG.rdEnglish) Result = "A newer version is available. would you like to update it now ";
            if (DataProvider.LG.rdChina) Result = "有更新的版本可用。 你想现在更新吗 ";
            return Result;
        }
        private string TitleMessage()
        {
            string Result = "Notification";
            if (DataProvider.LG.rdVietNam) Result = "Thông Báo";
            if (DataProvider.LG.rdEnglish) Result = "Notification";
            if (DataProvider.LG.rdChina) Result = "通知";
            return Result;
        }
        private void TitleUpdate()
        {
            if (DataProvider.LG.rdVietNam) 
            {
                this.Text = "Cập nhật hệ thống ";
                label1.Text = "Phiên bản: ";
                btnCheckForUpdate.Text = "&Cập nhật";
                button1.Text = "&Thoát";
            }
            if (DataProvider.LG.rdEnglish) 
            {
                this.Text = "Update system ";
                label1.Text = "Version: ";
                btnCheckForUpdate.Text = "Update";
                button1.Text = "Close";
            }
            if (DataProvider.LG.rdChina) {
                this.Text = "更新系统";
                label1.Text = "版本：";
                btnCheckForUpdate.Text = "更新";
                button1.Text = "关闭";
            }
        }
        private void DisabledForm()
        {
            this.Enabled = false;
        }
        private void EnabledForm()
        {
            this.Enabled = true;
        }
        private void btnCheckForUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
