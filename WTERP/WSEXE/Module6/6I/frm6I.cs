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
    public partial class Form6I : Form
    {
        DataProvider DataProvider = new DataProvider();
        public Form6I()
        {
            this.ShowInTaskbar = false;
            DataProvider.choose_languege();
            InitializeComponent();
        }
      
        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            string dl = FormSeachKIND.DL.K_NO;
            if (dl != "")
                tb1.Text = dl;
            else
                tb1.Text = "";

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

        private void tb2_Click(object sender, EventArgs e)
        {
            if (tb1.Text != "")
                tb2.Text = tb1.Text;
            else tb2.Text = "";
        }

        private void tb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            string dl = FormSeachKIND.DL.K_NO;
            if (dl != "")
                tb2.Text = dl;
            else
                tb2.Text = "";
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C fr1 = new FormSearchPROD1C();
            fr1.ShowDialog();
            string dl = FormSearchPROD1C.ID.P_NO;
            if (dl != "")
                tb3.Text = dl;
            else
                tb3.Text = "";

        }

        private void tb4_Click(object sender, EventArgs e)
        {
            if (tb3.Text != "")
                tb4.Text = tb3.Text;
            else tb4.Text = "";
        }

        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C fr1 = new FormSearchPROD1C();
            fr1.ShowDialog();
            string dl = FormSearchPROD1C.ID.P_NO;
            if (dl != "")
                tb4.Text = dl;
            else
                tb4.Text = "";

        }

    
        private void tb6_Click(object sender, EventArgs e)
        {
            if (tb5.Text != "")
                tb6.Text = tb5.Text;
            else tb6.Text = "";
        }

        private void tb6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr2 = new Form1BF5();
            fr2.ShowDialog();
            string dl = Form1BF5.SEND_FORM6I.f1;
            if (dl != "")
                tb6.Text = dl;
            else
                tb6.Text = "";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Chức Năng Này Đang Được Phát Triển. \n Bạn Vùi Lòng Liên Hệ Admin Để Được Hướng Dẫn.", "Thông Báo", MessageBoxButtons.OK);
        }

        private void bt3_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Chức Năng Này Đang Được Phát Triển. \n Bạn Vùi Lòng Liên Hệ Admin Để Được Hướng Dẫn.", "Thông Báo", MessageBoxButtons.OK);
        }

        private void tb5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr2 = new Form1BF5();
            fr2.ShowDialog();
            string dl = Form1BF5.SEND_FORM6I.f1;
            if (dl != "")
                tb5.Text = dl;
            else
                tb5.Text = "";
        }
        private void Form6I_Load(object sender, EventArgs e)
        {
            loadinfo();
        }
    }
}
