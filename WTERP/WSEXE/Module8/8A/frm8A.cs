using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form8A : Form
    {
        DataProvider DataProvider = new DataProvider();
        public Form8A()
        {
            this.ShowInTaskbar = false;
            DataProvider.choose_languege();
            InitializeComponent();
        }
      
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8AF5 f5 = new Form8AF5();
            f5.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult ccl = MessageBox.Show("Bạn Có muốn thoát chương trình không? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (ccl == DialogResult.OK)
                this.Close();
        }

        private void Form8A_Load(object sender, EventArgs e)
        {
            //phan quyền
            DataProvider.CheckLoad(menuStrip1);
            loadinfo();
            btok.Hide();
            btdong.Hide();
            DataProvider.DGV(dataF8A);
        }
        void loadinfo()
        {
            lbUserName.Text = DataProvider.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Chức Năng Này Chưa Được Phát Triển!");
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Không Có Dữ Liệu");
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Không Có Dữ Liệu");
        }

        private void f9CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    MessageBox.Show("Không Có Dữ Liệu");
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            btok.Hide();
            btdong.Hide();

            dataF8A.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataF8A.RowHeadersWidth = 40;
            dataF8A.EnableHeadersVisualStyles = false;
            dataF8A.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            dataF8A.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11F);
        }
    }
}
