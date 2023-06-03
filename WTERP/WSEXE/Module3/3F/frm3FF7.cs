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

namespace WTERP.WSEXE
{
    public partial class frm3FF7 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable DataTable;
        public frm3FF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
            //Load();
        }
        private void LoadSource()
        {
            textBox1.Text = frm3F.WS_NO;
            textBox2.Text = frm3F.WS_NO;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(textBox1, textBox2, sender, e);
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox1, maskedTextBox1, sender, e);
        }
        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(textBox2, maskedTextBox2, sender, e);
        }
        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(maskedTextBox1, textBox1, sender, e);
        }
        string Date1;
        string Date2;
        public void Test_MaskedText()
        {
            if (conn.Check_MaskedText(maskedTextBox1) == true)
                Date1 = maskedTextBox1.Text;
            if (conn.Check_MaskedText(maskedTextBox1) == true)
                Date2 = maskedTextBox1.Text;
        }
        public static DataTable DataTable1;
        private void button1_Click(object sender, EventArgs e)
        {
            view1();
            frm3FF7_Tab1 frm3FF7_Tab1 = new frm3FF7_Tab1();
            frm3FF7_Tab1.ShowDialog();
        }
        private void view1()
        {
            try
            {
                Test_MaskedText();
                string sql = "SELECT * FROM PRDMK3 WHERE 1=1";
                if (textBox1.Text == "" && textBox2.Text == "" && conn.formatstr2(Date1) == "" && conn.formatstr2(Date2) == "")
                {
                    sql = sql + "";
                }
                else if (textBox1.Text != "" || textBox2.Text != "")
                {
                    if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        sql = sql + " AND WS_NO BETWEEN (SELECT TOP 1 WS_NO FROM dbo.PRDMK3 ORDER BY WS_NO ASC) AND '" + textBox2.Text + "'";
                    }
                    else if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        sql = sql + " AND WS_NO BETWEEN '" + textBox1.Text + "' AND (SELECT TOP 1 WS_NO FROM dbo.PRDMK3 ORDER BY WS_NO DESC)";
                    }
                    else
                    {
                        sql = sql + " AND WS_NO BETWEEN '" + textBox1.Text + "' AND '" + textBox2.Text + "'";
                    }
                }
                else if (conn.formatstr2(Date1) != "" || conn.formatstr2(Date2) != "")
                {
                    if (conn.formatstr2(Date1) == "" && conn.formatstr2(Date2) != "")
                    {
                        sql = sql + " AND WS_NO BETWEEN (SELECT TOP 1 WS_DATE FROM dbo.PRDMK3 ORDER BY WS_DATE ASC) AND '" + conn.formatstr2(Date2) + "'";
                    }
                    else if (conn.formatstr2(Date1) != "" && conn.formatstr2(Date2) == "")
                    {
                        sql = sql + " AND WS_NO BETWEEN '" + conn.formatstr2(Date1) + "' AND (SELECT TOP 1 WS_NO FROM dbo.PRDMK3 ORDER BY WS_DATE DESC)";
                    }
                    else
                    {
                        sql = sql + " AND WS_NO BETWEEN '" + conn.formatstr2(Date1) + "' AND '" + conn.formatstr2(Date2) + "'";
                    }
                }
                else
                {
                    sql = sql + " AND WS_NO BETWEEN '" + textBox1.Text + "' AND " + textBox2.Text + " AND WS_NO BETWEEN " + conn.formatstr2(Date1) + " AND " + conn.formatstr2(Date2) + "";
                }
                DataTable = new DataTable();
                DataTable = conn.readdata(sql);
                //truyen du lieu
                DataTable1 = DataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void getInfo()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER;
            lbUserName.Text = conn.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
        }

        private void frm3FF7_Load(object sender, EventArgs e)
        {
            LoadSource();
        }

        private void maskedTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            maskedTextBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void maskedTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            maskedTextBox2.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
            
