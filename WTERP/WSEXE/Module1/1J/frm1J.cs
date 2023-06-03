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
    public partial class Form1J : Form
    {
        DataProvider conn = new DataProvider();
        public Form1J()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //string a = "";
        private void Form1Jquanlythongtingiaca_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            btdau.Enabled = false;
            bttruoc.Enabled = false;
            getInfo();
            button2.Hide();
            button3.Hide();
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
            btndateNow.Text = conn.getDateNow(); // get DateNow
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
            tab(textBox4, textBox6, sender, e);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox5, textBox7, sender, e);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox6, textBox8, sender, e);
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox8, textBox10, sender, e);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox9, textBox11, sender, e);
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox10, textBox12, sender, e);
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox11, textBox13, sender, e);
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox12, textBox14, sender, e);
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox13, textBox15, sender, e);
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox14, textBox16, sender, e);
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox15, textBox17, sender, e);
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox16, textBox18, sender, e);
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox17, textBox19, sender, e);
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox18, textBox20, sender, e);
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox19, textBox22, sender, e);
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                textBox20.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                comboBox1.Focus();
            if (e.KeyCode == Keys.Left)
                textBox20.Focus();
            if (e.KeyCode == Keys.Right)
                comboBox1.Focus();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox22, textBox21, sender, e);
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                comboBox1.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                textBox23.Focus();
            if (e.KeyCode == Keys.Left)
                comboBox1.Focus();
            if (e.KeyCode == Keys.Right)
                textBox23.Focus();
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox21, textBox24, sender, e);
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox23, textBox25, sender, e);
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox24, textBox1, sender, e);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1, textBox2, sender, e);
        }
        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            tab(textBox7, textBox9, sender, e);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            conn.tab_UP(textBox1,textBox2,sender,e);
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            textBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
