using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1CF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1CF7()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1CF7_Load(object sender, EventArgs e)
        {
       
        }

        private void tb3t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb3t1();
        }

        private void tb4t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb4t1();
        }

        private void tb7t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearhWH fr = new FormSearhWH();
            fr.ShowDialog();
            Load_tb7t1();
        }

        private void tb8t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearhWH fr = new FormSearhWH();
            fr.ShowDialog();
            Load_tb8t1();
        }

        private void tb1t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Load_tb1t2();
        }

        private void tb2t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeachKIND fr = new FormSeachKIND();
            fr.ShowDialog();
            Load_tb2t2();
        }

        private void tb3t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb3t2();
        }

        private void tb4t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb4t2();
        }

        private void tb3t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb3t3();
        }

        private void tb4t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1CF5 fr = new Form1CF5();
            fr.ShowDialog();
            Load_tb4t3();
        }
        public void Load_tb3t1()
        {
            tb3t1.Text = Form1CF5.DL.T1;
        }
        public void Load_tb4t1()
        {
            tb4t1.Text = Form1CF5.DL.T1;
        }
        public void Load_tb3t2()
        {
            tb3t2.Text = Form1CF5.DL.T1;
        }
        public void Load_tb4t2()
        {
            tb4t2.Text = Form1CF5.DL.T1;
        }
        public void Load_tb3t3()
        {
            tb3t3.Text = Form1CF5.DL.T1;
        }
        public void Load_tb4t3()
        {
            tb4t3.Text = Form1CF5.DL.T1;
        }

        public void Load_tb7t1()
        {
            tb7t1.Text = FormSearhWH.DL.t1;
        }
        public void Load_tb8t1()
        {
            tb8t1.Text = FormSearhWH.DL.t1;
        }
        public void Load_tb1t2()
        {
            tb1t2.Text = FormSeachKIND.DL.K_NO;
        }
        public void Load_tb2t2()
        {
            tb2t2.Text = FormSeachKIND.DL.K_NO;
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public class GUI
        {
            public static string t1t1;
            public static string t2t1;
            public static string t3t1;
            public static string t4t1;
            public static string t5t1;
            public static string t6t1;
            public static string t7t1;
            public static string t8t1;

            public static string t1t2;
            public static string t2t2;
            public static string t3t2;
            public static string t4t2;

            public static string t1t3;
            public static string t2t3;
            public static string t3t3;
            public static string t4t3;
            public static string t5t3;
            public static string t6t3;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Gui_Tab1();
            Gui_Tab2();
            Gui_Tab3();

            if (tabControl1.SelectedIndex == 0)
            {
                Form1CF7_Tab1 fr = new Form1CF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1CF7_Tab2 fr = new Form1CF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức Năng Nay Đang Được Phát Triển \n Bạn Vui Lòng Liên Hệ Admin Để Được Hướng Dẫn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
        }
        public void Gui_Tab1()
        {
            GUI.t1t1 = tb1t1.Text;
            GUI.t2t1 = tb2t1.Text;
            GUI.t3t1 = tb3t1.Text;
            GUI.t4t1 = tb4t1.Text;
            GUI.t5t1 = tb5t1.Text;
            GUI.t6t1 = tb6t1.Text;
            GUI.t7t1 = tb7t1.Text;
            GUI.t8t1 = tb8t1.Text;
        }

        public void Gui_Tab2()
        {
            GUI.t1t2 = tb1t2.Text;
            GUI.t2t2 = tb2t2.Text;
            GUI.t3t2 = tb3t2.Text;
            GUI.t4t2 = tb4t2.Text;
        }

        public void Gui_Tab3()
        {
            GUI.t1t3 = tb1t3.Text;
            GUI.t2t3 = tb2t3.Text;
            GUI.t3t3 = tb3t3.Text;
            GUI.t4t3 = tb4t3.Text;
            GUI.t5t3 = tb5t3.Text;
            GUI.t6t3 = tb6t3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gui_Tab1();
            Gui_Tab2();
            Gui_Tab3();

            if (tabControl1.SelectedIndex == 0)
            {
                Form1CF7_Tab1 fr = new Form1CF7_Tab1();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Form1CF7_Tab2 fr = new Form1CF7_Tab2();
                fr.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức Năng Nay Đang Được Phát Triển \n Bạn Vui Lòng Liên Hệ Admin Để Được Hướng Dẫn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //tab 1
        private void tb1t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t1, tb2t1, sender, e);
        }
        private void tb2t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t1, tb3t1, sender, e);
        }
        private void tb7t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb6t1, tb8t1, sender, e);
        }
        private void tb6t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb5t1, tb7t1, sender, e);
        }
        private void tb4t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t1, tb5t1, sender, e);
        }
        private void tb3t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t1, tb4t1, sender, e);
        }
        private void tb5t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4t1, tb6t1, sender, e);
        }
        private void tb8t1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb3t1, button3, sender, e);
        }
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }    
        }
        //tab 2
        private void tb1t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t2, tb2t2, sender, e);
        }

        private void tb2t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t2, tb3t2, sender, e);
        }

        private void tb3t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t2, tb4t2, sender, e);
        }

        private void tb4t2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb3t2, button3, sender, e);
        }
        //tab 3
        private void tb1t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t3, tb2t3, sender, e);
        }
        private void tb2t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb1t3, tb3t3, sender, e);
        }
        private void tb3t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb2t3, tb4t3, sender, e);
        }

        private void tb4t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb3t3, tb5t3, sender, e);
        }

        private void tb5t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(tb4t3, tb6t3, sender, e);
        }
        private void tb6t3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(tb5t3,button3, sender, e);
        }
    }
}
