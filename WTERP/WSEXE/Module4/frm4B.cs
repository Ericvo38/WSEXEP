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
    public partial class Form4B : Form
    {
        public Form4B()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider conn = new DataProvider();

        private void Form4B_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            Loaddt();
            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Checked= false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
            conn.DGV(DGV1);
            conn.DGV(DGV2);
            
        }
        public void Loaddt()
        {
            tb1.Text = "    /  /   ";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "N";
            cb7.Text = "";
            tb8.Text = "";
            tb9.Text = "";
            tb10.Text = "";
            tb11.Text = "    /  /   ";
            tb12.Text = "";
            tb13.Text = "";
            tb14.Text = "   /  ";
            tb15.Text = "";
            tb16.Text = "";
            tb17.Text = "";
            tb18.Text = "";
            tb19.Text = "";
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
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4BF5 frm = new Form4BF5();
            frm.ShowDialog();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f2ToolStripMenuItem.Checked = true;
            DateTime d1 = DateTime.Now;
            tb1.Text = d1.ToString("yyyy/MM/dd");
            tb2.Text = "1";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "N";
            cb7.Text = "";
            tb8.Text = "31.6";
            tb9.Text = "0.00";
            tb10.Text = "0.00";
            tb11.Text = "    /  /   ";
            tb12.Text = "";
            tb13.Text = "0";
            tb14.Text = "   /  ";
            tb15.Text = "0.00";
            tb16.Text = "0.00";
            tb17.Text = "";
            tb18.Text = "";
            tb19.Text = "";


            bt.Text = "SỬA";
            btok.Show();
            btdong.Show();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = false;
            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
            f7ToolStripMenuItem.Enabled = false;
            f9ToolStripMenuItem.Enabled = false;
            f10ToolStripMenuItem.Enabled = true;
            f12ToolStripMenuItem.Enabled = false;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Không Có Dữ Liệu!");
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Không Có Dữ Liệu!");
        }
        private void f9DuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Không Có Dữ Liệu!");
        }

        private void f10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Loaddt();
            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();

            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f9ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = false;
            btketthuc.Enabled = false;

            f1ToolStripMenuItem.Checked = false;
            f2ToolStripMenuItem.Checked = false;
            f3ToolStripMenuItem.Checked = false;
            f4ToolStripMenuItem.Checked = false;
            f5ToolStripMenuItem.Checked = false;
            f7ToolStripMenuItem.Checked = false;
            f9ToolStripMenuItem.Checked = false;
            f10ToolStripMenuItem.Checked = false;
            f12ToolStripMenuItem.Checked = false;
        }
        void tab(TextBox txtUp, TextBox txtDown, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtUp.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                txtDown.Focus();
            if (e.KeyCode == Keys.Left)
                txtUp.Focus();
            if (e.KeyCode == Keys.Right)
                txtDown.Focus();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb19, tb2, sender, e);
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb1, tb3, sender, e);
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb2, tb4, sender, e);
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb3, tb5, sender, e);
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb4, tb6, sender, e);
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb5, tb8, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb9, sender, e);
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb8, tb10, sender, e);
        }

        private void tb10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb9, tb11, sender, e);
        }

        private void tb11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb10, tb12, sender, e);
        }

        private void tb12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb11, tb13, sender, e);
        }

        private void tb13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb12, tb14, sender, e);
        }

        private void tb14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb15, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb14, tb16, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb16, tb18, sender, e);
        }

        private void tb18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb17, tb19, sender, e);
        }

        private void tb19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb18, tb1, sender, e);
        }
    }
}
