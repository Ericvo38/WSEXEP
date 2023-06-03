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
    public partial class Form6H : Form
    {
        DataProvider conn = new DataProvider();
        public Form6H()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
      
        private void Form6H_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
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
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btdong.PerformClick();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btcd.PerformClick();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btcd_Click(object sender, EventArgs e)
        {
            getData();
            
        }
        private void getData()
        {
            try
            {
                string key1 = tb1.Text + tb2.Text;
                string key2 = tb1.Text + tb3.Text;
                if (conn.checkExists("SELECT TOP 1 WS_NO FROM CARH WHERE WS_NO IN ('" + key1 + "','" + key2 + "')") == true)
                {
                    MessageBox.Show("Số không chính xác !! vui lòng thử lại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int number1 = int.Parse(tb2.Text.Trim().Substring(3,6));
                    int number2 = int.Parse(tb3.Text.Trim().Substring(3,6));
                    if (number1 > number2)
                    {
                        MessageBox.Show("Số bắt đầu không thể lớn hơn số kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string key = tb2.Text.Trim().Substring(0, 3);
                        for (int i = number1; i <= number2; i++)
                        {
                            string CC = tb1.Text + key + COVER(i);
                            string st1 = "Insert into dbo.CARH (WS_NO, USR_NAME) " +
                                "SELECT '" + CC + "','" + lbUserName.Text + "'";
                            conn.exedata(st1);
                        }
                        this.Close();
                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string COVER(int i)
        {
            string AA = i.ToString();
            string BB = "";
            if (AA.Length == 1)
            {
                BB = "00000" + AA;
            }
            else if (AA.Length == 2)
            {
                BB = "0000" + AA;
            }
            else if (AA.Length == 3)
            {
                BB = "000" + AA;
            }
            else if (AA.Length == 4)
            {
                BB = "00" + AA;
            }
            else if (AA.Length == 5)
            {
                BB = "0" + AA;
            }
            else if (AA.Length == 6)
            {
                BB = AA;
            }
            return BB;
        }

        private void textBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachUSRH fr = new FormSeachUSRH();
            fr.ShowDialog();
            string dl = FormSeachUSRH.DL.USER_NAME;
            if (dl != "")
                tb4.Text = dl;
            else
                tb4.Text = "";
        }
       
        private void tb1_Validating(object sender, CancelEventArgs e)
        {
            if(tb1.Text == "A")
            {
                e.Cancel = false;
                errorProvider1.SetError(tb1, null);
            }
            else if (tb1.Text == "B")
            {
                e.Cancel = false;
                errorProvider1.SetError(tb1, null);
            }    
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(tb1, "Chỉ được nhập A hoặc B");
            }    
        }
    }
}
