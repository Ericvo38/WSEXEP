using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form6F : Form
    {
        DataProvider conn = new DataProvider();
        public Form6F()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void Form6F_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btcd.PerformClick();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            string dl = frm2CustSearch.ID.ID_CUST;
            if (dl != "")
                tb1.Text = dl;
            else
                tb1.Text = "";
        }

        private void btcd_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = "select C_NO from CUST WHERE C_NO = '" + tb1.Text + "'";
                DataTable dt = conn.readdata(SQL);
                if (dt.Rows.Count > 0)
                {
                    if (tb2.Text == "")
                    {
                        MessageBox.Show("Dữ Liệu Trống!", "Thông Báo");
                    }
                    else
                    {
                        string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE') AND COLUMN_NAME = 'C_NO'";
                        DataTable data = new DataTable();
                        data = conn.readdata(sql);
                        foreach (DataRow item in data.Rows)
                        {
                            string st1 = "update " + item["TABLE_NAME"].ToString() + " set C_NO = '" + tb2.Text + "' where C_NO = '" + tb1.Text + "'";
                            conn.exedata(st1);
                        }
                        tb1.Text = "";
                        tb2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
