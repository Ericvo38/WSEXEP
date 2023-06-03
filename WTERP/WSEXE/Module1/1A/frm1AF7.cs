using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form1AF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1AF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void Form1AF7_Load(object sender, EventArgs e)
        {
            getInfo();
            tb3T2.Text = "N";
            tb3T3.Text = "N";
            tb3T4.Text = "N";
            tb2T6.Text = "ZZZZZ";
            tb3T6.Text = "1";
   
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
            //btndateNow.Text = conn.getDateNow(); // get DateNow
        }
        public void load_rdTab1()
        {
            RD.rd1t1 = rd1t1.Checked;
            RD.rd2t1 = rd2t1.Checked;
            RD.rd3t1 = rd3t1.Checked;
            RD.rd4t1 = rd4t1.Checked;
        }
        public void load_rdTab2()
        {
            RD.rd1t2 = rd1t2.Checked;
            RD.rd2t2 = rd2t2.Checked;
            RD.rd3t2 = rd3t2.Checked;
            RD.rd4t2 = rd4t2.Checked;

            RD.rdin1t2 = rdin1t2.Checked;
            RD.rdin2t2 = rdin2t2.Checked;
        }
        public void load_rdTab3()
        {
            RD.rd1t3 = rd1t3.Checked;
            RD.rd2t3 = rd2t3.Checked;
            RD.rd3t3 = rd3t3.Checked;
            RD.rd3t4 = rd4t3.Checked;

            RD.rdHT1t3 = rdHt1t3.Checked;
            RD.rdHT2t3 = rdHt2t3.Checked;
        }
        public void load_rdTab4()
        {
            RD.rd1t4 = rd1t4.Checked;
            RD.rd2t4 = rd2t4.Checked;
            RD.rd3t4 = rd3t4.Checked;
            RD.rd4t4 = rd4t4.Checked;

            RD.rdpbt4 = rdph.Checked;
            RD.rdnhant4 = rdnhan.Checked;
            RD.rdhtt4 = rdht.Checked;
        }
        public void load_rdTab5()
        {
            RD.rdDlt5 = rdDL.Checked;
            RD.rdTQt5 = rdTQ.Checked;

        }
        public void load_rdTab6()
        {
            RD.rdin1t6 = rdinT6.Checked;
            RD.rdin2t6 = rdin2T6.Checked;
        }
    
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetData_tab1();
            GetData_tab2();
            GetData_tab3();
            GetData_tab4();
            GetData_tab5();
            GetData_tab6();
            GetData_tab7();

            load_rdTab1();
            load_rdTab2();
            load_rdTab3();
            load_rdTab4();
            load_rdTab5();
            load_rdTab6();

            if (tabControl1.SelectedIndex == 0)
            {
                Form1AF7_Tab1 fr1 = new Form1AF7_Tab1();
                fr1.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1AF7_Tab2 fr2 = new Form1AF7_Tab2();
                fr2.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Form1AF7_Tab3 fr3 = new Form1AF7_Tab3();
                fr3.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Form1AF7_Tab4 fr4 = new Form1AF7_Tab4();
                fr4.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Form1AF7_Tab5 fr5 = new Form1AF7_Tab5();
                fr5.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                Form1AF7_Tab6 fr6 = new Form1AF7_Tab6();
                fr6.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 6)
            {

                txtThongBao();
            }

        }
        public void txtThongBao()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                MessageBox.Show("Vui Lòng Liên Hệ Với Admin Để Xác Nhận Quyền Hạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                MessageBox.Show("Vui Lòng Liên Hệ Với Admin Để Xác Nhận Quyền Hạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                MessageBox.Show("Please Contact Admin To Confirm Authorization", "Nofication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (DataProvider.LG.rdChina == true)
            {
                MessageBox.Show("請聯繫管理員確認授權", "通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public class DL
        {
            public static string t1T1;
            public static string t2T1;
            public static string t3T1;

            public static string t1T2;
            public static string t2T2;
            public static string t3T2;

            public static string t1T3;
            public static string t2T3;
            public static string t3T3;

            public static string t1T4;
            public static string t2T4;
            public static string t3T4;

            public static string t1T5;
            public static string t2T5;

            public static string t1T6;
            public static string t2T6;
            public static string t3T6;

            public static string t1T7;
            public static string t2T7;
        }
        public class RD
        {
            public static bool rd1t1;
            public static bool rd2t1;
            public static bool rd3t1;
            public static bool rd4t1;

            public static bool rd1t2;
            public static bool rd2t2;
            public static bool rd3t2;
            public static bool rd4t2;

            public static bool rdin1t2;
            public static bool rdin2t2;

            public static bool rd1t3;
            public static bool rd2t3;
            public static bool rd3t3;
            public static bool rd4t3;

            public static bool rdHT1t3;
            public static bool rdHT2t3;

            public static bool rd1t4;
            public static bool rd2t4;
            public static bool rd3t4;
            public static bool rd4t4;

            public static bool rdpbt4;
            public static bool rdnhant4;
            public static bool rdhtt4;


            public static bool rdDlt5;
            public static bool rdTQt5;

            public static bool rdin1t6;
            public static bool rdin2t6;

        }
        public void GetData_tab1()
        {
            DL.t1T1 = tb1T1.Text;
            DL.t2T1 = tb2T1.Text;
            DL.t3T1 = tb3T1.Text;
        }
        public void GetData_tab2()
        {
            DL.t1T2 = tb1T2.Text;
            DL.t2T2 = tb2T2.Text;
            DL.t3T2 = tb3T2.Text;
        }
        public void GetData_tab3()
        {
            DL.t1T3 = tb1T3.Text;
            DL.t2T3 = tb2T3.Text;
            DL.t3T3 = tb3T3.Text;
        }

        public void GetData_tab4()
        {
            DL.t1T4 = tb1T4.Text;
            DL.t2T4 = tb2T4.Text;
            DL.t3T4 = tb3T4.Text;
        }

        public void GetData_tab5()
        {
            DL.t1T5 = tb1T5.Text;
            DL.t2T5 = tb2T5.Text;
        }

        public void GetData_tab6()
        {
            DL.t1T6 = tb1T6.Text;
            DL.t2T6 = tb2T6.Text;
            DL.t3T6 = tb3T6.Text;
        }

        public void GetData_tab7()
        {
            DL.t1T7 = tb1T7.Text;
            DL.t2T7 = tb2T7.Text;
         
        }

        private void tb1T1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void tb2T1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void tb1T2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb2T2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tb1T3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tb2T3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tb1T4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb2T4_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tb1T5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void tb2T5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tb1T6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb1T7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb2T7_TextChanged(object sender, EventArgs e)
        {
          
        }
        public void get_tb1T1()
        {
            tb1T1.Text = Form1AF5.DI.tx1_t1;
        }
        public void get_tb2T1()
        {
            tb2T1.Text = Form1AF5.DI.tx2_t1;
        }
        public void get_tb1T2()
        {
            tb1T2.Text = Form1AF5.DI.tx1_t2;
        }
        public void get_tb2T2()
        {
            tb2T2.Text = Form1AF5.DI.tx2_t2;
        }
        public void get_tb1T3()
        {
            tb1T3.Text = Form1AF5.DI.tx1_t3;
        }
        public void get_tb2T3()
        {
            tb2T3.Text = Form1AF5.DI.tx2_t3;
        }
        public void get_tb1T4()
        {
            tb1T4.Text = Form1AF5.DI.tx1_t4;
        }
        public void get_tb2T4()
        {
            tb2T4.Text = Form1AF5.DI.tx2_t4;
        }
        public void get_tb1T5()
        {
            tb1T5.Text = Form1AF5.DI.tx1_t5;
        }
        public void get_tb2T5()
        {
            tb2T5.Text = Form1AF5.DI.tx2_t5;
        }
        public void get_tb1T6()
        {
            tb1T6.Text = Form1AF5.DI.tx1_t6;
        }
        public void get_tb1T7()
        {
            tb1T7.Text = Form1AF5.DI.tx1_t7;
        }
        public void get_tb2T7()
        {
            tb2T7.Text = Form1AF5.DI.tx2_t7;
        }

        private void tb1T1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr1 = new Form1AF5();
            fr1.ShowDialog();
            get_tb1T1();
        }

        private void tb2T1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr2 = new Form1AF5();
            fr2.ShowDialog();
            get_tb2T1();
        }

        private void tb1T2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr3 = new Form1AF5();
            fr3.ShowDialog();
            get_tb1T2();
        }

        private void tb2T2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr4 = new Form1AF5();
            fr4.ShowDialog();
            get_tb2T2();
        }

        private void tb1T3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr5 = new Form1AF5();
            fr5.ShowDialog();
            get_tb1T3();
        }

        private void tb2T3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr6 = new Form1AF5();
            fr6.ShowDialog();
            get_tb2T3();
        }

        private void tb1T4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr7 = new Form1AF5();
            fr7.ShowDialog();
            get_tb1T4();
        }

        private void tb2T4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr8 = new Form1AF5();
            fr8.ShowDialog();
            get_tb2T4();
        }

        private void tb1T5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr9 = new Form1AF5();
            fr9.ShowDialog();
            get_tb1T5();
        }

        private void tb2T5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr10 = new Form1AF5();
            fr10.ShowDialog();
            get_tb2T5();
        }

        private void tb1T6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr11 = new Form1AF5();
            fr11.ShowDialog();
            get_tb1T6();
        }

        private void tb1T7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr12 = new Form1AF5();
            fr12.ShowDialog();
            get_tb1T7();
        }

        private void tb2T7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1AF5 fr13 = new Form1AF5();
            fr13.ShowDialog();
            get_tb2T7();
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetData_tab1();
            GetData_tab2();
            GetData_tab3();
            GetData_tab4();
            GetData_tab5();
            GetData_tab6();
            GetData_tab7();

            load_rdTab1();
            load_rdTab2();
            load_rdTab3();
            load_rdTab4();
            load_rdTab5();
            load_rdTab6();

            if (tabControl1.SelectedIndex == 0)
            {
                Form1AF7_Tab1 fr1 = new Form1AF7_Tab1();
                fr1.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1AF7_Tab2 fr2 = new Form1AF7_Tab2();
                fr2.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Form1AF7_Tab3 fr3 = new Form1AF7_Tab3();
                fr3.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Form1AF7_Tab4 fr4 = new Form1AF7_Tab4();
                fr4.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Form1AF7_Tab5 fr5 = new Form1AF7_Tab5();
                fr5.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                Form1AF7_Tab6 fr6 = new Form1AF7_Tab6();
                fr6.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                txtThongBao();
            }
        }
        //tab 1
        private void tb1T1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T1, tb2T1, sender, e);
        }
        private void tb2T1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T1, tb3T1, sender, e);
        }
        private void tb3T1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T1, button3, sender, e);
        }
        //
        //tab2
        private void tb1T2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T2, tb2T2, sender, e);
        }
        private void tb2T2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T2, tb3T2, sender, e);
        }
        private void tb3T2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T2, button3, sender, e);
        }
        //tab 3
        private void tb1T3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T3, tb2T3, sender, e);
        }
        private void tb2T3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T3, tb3T3, sender, e);
        }
        private void tb3T3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T3, button3, sender, e);
        }
        //tab4
        private void tb1T4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T4, tb2T4, sender, e);
        }
        private void tb2T4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T4, tb3T4, sender, e);
        }
        private void tb3T4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T4, button3, sender, e);
        }
        //tab 5
        private void tb1T5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T5, tb2T5, sender, e);
        }
        private void tb2T5_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T5, button3, sender, e);
        }
        //tab6
        private void tb1T6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T6, tb2T6, sender, e);
        }
        private void tb2T6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2T6, tb3T6, sender, e);
        }
        private void tb3T6_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb2T6, button3, sender, e);
        }
        //tab7
        private void tb1T7_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1T7,tb2T7, sender, e);
        }
        private void tb2T7_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb1T7, button3, sender, e);
        }
    }
}
