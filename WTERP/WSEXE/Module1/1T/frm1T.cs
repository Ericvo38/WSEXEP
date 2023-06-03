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
    public partial class Form1T : Form
    {
        DataProvider conn = new DataProvider();
        public Form1T()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = conn.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        private void Form1T_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            getInfo();
            btdau.Enabled = false;
            bttruoc.Enabled = false;
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1, textBox2, sender, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1, textBox3, sender, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox2, textBox4, sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox3, textBox5, sender, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox4, textBox11, sender, e);
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox11, textBox7, sender, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox6, textBox8, sender, e);
        }


        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox7, textBox9, sender, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox8, textBox10, sender, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox9, textBox10, sender, e);
        }
        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox5, textBox6, sender, e);
        }
    }


}
