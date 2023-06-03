using LibraryCalender;
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
    public partial class Form1S : Form
    {
        DataProvider conn = new DataProvider();
        public Form1S()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btndateNow.Text = CN.getDateNow();
            btnTimeNow.Text = CN.getTimeNow();
        }

        private void Form1S_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            getInfo();
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
            conn.tab(textBox2, textBox4, sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox3, textBox5, sender, e);
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox4, textBox6, sender, e);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox5, textBox7, sender, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox6, textBox8, sender, e);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox7, textBox9, sender, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox8, textBox10, sender, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox9, textBox1, sender, e);
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            textBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
