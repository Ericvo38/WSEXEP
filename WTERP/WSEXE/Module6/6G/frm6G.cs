using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form6G : Form
    {
        DataProvider conn = new DataProvider();
        public Form6G()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
       

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btcd.PerformClick();
        }

        private void Form6G_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C fr = new FormSearchPROD1C();
            fr.ShowDialog();
            string dl = FormSearchPROD1C.ID.P_NO;
            if (dl != "")
                tb1.Text = dl;
            else
                tb1.Text = "";
        }

        private void tb2_Click(object sender, EventArgs e)
        {
            string SQL = "select P_NO, K_NO from PROD1C WHERE P_NO='"+tb1.Text+"'";
            DataTable dt = conn.readdata(SQL);
            string s1 = tb1.Text.Trim();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (s1 == dr["P_NO"].ToString())
                    {
                        tb2.Text = dr["K_NO"].ToString();
                        tb3.Text = dr["K_NO"].ToString();
                        tb4.Text = dr["P_NO"].ToString();
                    }
                    break;
                }
            }
            catch
            {

            }


        }

        private void tbdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btcd_Click(object sender, EventArgs e)
        {
            string s1 = tb3.Text.Trim();
            string s2 = tb4.Text.Substring(0,2);
            string SQL = "select P_NO from PROD1C WHERE P_NO='" + tb4.Text + "'";
            DataTable dt = conn.readdata(SQL);
            string s4 = tb4.Text.Trim();

            if (s1.ToString() != s2.ToString())
            {
                MessageBox.Show("Số Hạng Mục Không trùng", "Thông Báo", MessageBoxButtons.OK);
                tb4.Text = "";
            }
            else
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (s4 == dr["P_NO"].ToString())
                        {
                            MessageBox.Show("Số Vật Liệu Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK);
                            tb4.Text = "";
                           
                        }     
                       
                    }

                    if(tb4.Text != "")
                    {
                        string st1 = "update dbo.PROD1C set K_NO = '" + tb3.Text + "',P_NO='" + tb4.Text + "' where P_NO = '" + tb1.Text + "'";
                        bool kq = conn.exedata(st1);
                        if (kq == true)
                        {
                            MessageBox.Show("Chuyển Đổi Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tb1.Text = "";
                            tb2.Text = "";
                            tb3.Text = "";
                            tb4.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Xảy Ra Sự Cố", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tb1.Text = "";
                            tb2.Text = "";
                            tb3.Text = "";
                            tb4.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Số Vật Liệu", "Thông Báo", MessageBoxButtons.OK);
                        tb4.Text = "";
                    }

            
                }
                catch
                {

                }
            }
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            string dl = FormSeachKIND.DL.K_NO;
            if (dl != "")
                tb3.Text = dl;
            else
                tb3.Text = "";
        }
    }
}
