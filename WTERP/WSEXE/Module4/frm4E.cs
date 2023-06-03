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
    public partial class Form4E : Form
    {
        DataProvider conn = new DataProvider();
        public Form4E()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4EF5 frm = new Form4EF5();
            frm.ShowDialog();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
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
            tab(tb22, tb2, sender, e);
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
            tab(tb5, tb7, sender, e);
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb6, tb8, sender, e);
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb7, tb9, sender, e);
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
            tab(tb12, tb13, sender, e);
        }

        private void tb15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb13, tb16, sender, e);
        }

        private void tb16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb15, tb17, sender, e);
        }

        private void tb17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb16, tb20, sender, e);
        }

        private void tb20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb17, tb21, sender, e);
        }

        private void tb21_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb20, tb22, sender, e);
        }

        private void tb22_KeyDown(object sender, KeyEventArgs e)
        {
            tab(tb21, tb1, sender, e);
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Nay Chưa Được Phát Triển!");
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không Có Dữ Liệu!");
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không Có Dữ Liệu!");
        }

        private void f6DuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không Có Dữ Liệu!");
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btok.PerformClick();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Form4E_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            bt.Text = "NÚT DUYỆT";
            f1ToolStripMenuItem.Enabled = false;
            f2ToolStripMenuItem.Enabled = true;
            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
            f6DuyệtToolStripMenuItem.Enabled = true;
            f7ToolStripMenuItem.Enabled = true;
            f10ToolStripMenuItem.Enabled = false;
            f12ToolStripMenuItem.Enabled = true;

            btok.Hide();
            btdong.Hide();

            btdau.Enabled = false;
            btsau.Enabled = false;
            bttruoc.Enabled = false;
            btketthuc.Enabled = false;
            conn.DGV(DGV1);
            conn.DGV(DVG2);
            conn.DGV(DVG3);
        }
    }
}
