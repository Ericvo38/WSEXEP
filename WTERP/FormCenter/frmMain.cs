using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class frmMain : Form
    {
        DataProvider conn = new DataProvider();
        public frmMain()
        {
            InitializeComponent();
            customizeDesing();
            getIP();
            getIDUS();
            btnSystem.Enabled = false;
            btnTool.Enabled = false;
            btnHelp.Enabled = false;
        }
        //Get Ip for Mainform 
        public void getIP()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void getIDUS()
        {
            string UID = frmLogin.ID_USER;
            lbID.Text = UID;
            DataProvider con = new DataProvider();
            lbUser.Text = con.getUser(UID); 
        }
        // of Submenu
        private void customizeDesing()
        {
            panelSystem.Visible = false;
            panelTool.Visible = false;
            panelHelp.Visible = false;
        }
        //Hide SubMenu
        private void hideSubMenu()
        {
            if (panelSystem.Visible == true)
                panelSystem.Visible = false;
            if (panelTool.Visible == true)
                panelTool.Visible = false;
            if (panelHelp.Visible == true)
                panelHelp.Visible = false;
        }
        // Show Submenu
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult clo = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (clo == DialogResult.OK)
            {
                conn.Closeconnect();
                this.Close();
            }
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSystem);
            MessageBox.Show("Chức Năng đang bị khóa, vui lòng Liên hệ quản lý !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void btnWSEXE_Click(object sender, EventArgs e)
        {
            frmWSEXE frbh = new frmWSEXE();
            this.Hide();
            frbh.ShowDialog();
            this.Close();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            showSubmenu(panelTool);
            MessageBox.Show("Chức Năng đang bị khóa, vui lòng Liên hệ quản lý !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            showSubmenu(panelHelp);
            MessageBox.Show("Chức Năng đang bị khóa, vui lòng Liên hệ quản lý !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //..
            // Coding
            //..
            hideSubMenu();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
          conn.Closeconnect();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
        }

        
    }
}
