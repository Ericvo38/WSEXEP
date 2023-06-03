using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module3._3D
{
    public partial class FrmChoiceType : Form
    {
        public FrmChoiceType()
        {
            InitializeComponent();
        }

        private void FrmChoiceType_Load(object sender, EventArgs e)
        {
            LoadLanguage();
            frm3D.Share_Type = string.Empty;
        }
        private void LoadLanguage()
        {
            if(frmLogin.Lang_ID == 1)
            {
                this.Text = "Chọn lựa loại sản phẩm";
                btnS.Text = "&S  Hàng mẫu";
                btnL.Text = "&L  Hàng sản xuất";
                btnLOI.Text = "&L&O&I  Hàng dự tính";
                btnD.Text = "&D  Triển lãm, phát triển";
                btnWT.Text = "&W&T  Nhà máy Weitai";
            }
            else if (frmLogin.Lang_ID == 2)
            {
                this.Text = "Select product type";
                btnS.Text = "&S  Sample";
                btnL.Text = "&L  Productions";
                btnLOI.Text = "&L&O&I  Ready-made";
                btnD.Text = "&D  Exhibition, development";
                btnWT.Text = "&W&T  Weitai Factory";
            }
            else if(frmLogin.Lang_ID == 3)
            {
                this.Text = "選擇產品類型";
                btnS.Text = "&S   樣品";
                btnL.Text = "&L   量產";
                btnLOI.Text = "&L&O&I   預做";
                btnD.Text = "&D   開發 展覽";
                btnWT.Text = "&W&T   本廠皮胚";
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            frm3D.Share_Type = "S";
            this.Close();
            
        }
        private void btnL_Click(object sender, EventArgs e)
        {
            frm3D.Share_Type = "L";
            this.Close();
        }
        private void btnLOI_Click(object sender, EventArgs e)
        {
            frm3D.Share_Type = "LOI";
            this.Close();
        }
        private void btnD_Click(object sender, EventArgs e)
        {
            frm3D.Share_Type = "D";
            this.Close();
        }
        private void btnWT_Click(object sender, EventArgs e)
        {
            frm3D.Share_Type = "WT";
            this.Close();
        }
    }
}
