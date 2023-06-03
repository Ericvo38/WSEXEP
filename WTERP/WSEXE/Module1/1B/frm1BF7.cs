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
    public partial class Form1BF7 : Form
    {
        DataProvider data = new DataProvider();
        public Form1BF7()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        private void Form1BF7_Load(object sender, EventArgs e)
        {
            tb3t2.Text = "N";
            tb3t3.Text = "N";
            tb3t4.Text = "N";
            tb2t6.Text = "ZZZZZ";
            tb3t6.Text = "1";
        }
        private void tbxem_Click(object sender, EventArgs e)
        {
            Get_DLT1();
            Get_DLT2();
            Get_DLT3();
            Get_DLT4();
            Get_DLT5();
            Get_DLT6();
            Get_RDT1();
            Get_RDT2();
            Get_RDT3();
            Get_RDT4();
            Get_RDT6();

            if(tabControl1.SelectedIndex == 0)
            {
                Form1BF7_Tab1 fr1 = new Form1BF7_Tab1();
                fr1.ShowDialog();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(tabControl1.SelectedIndex == 3)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(tabControl1.SelectedIndex == 4)
            {
                Form1BF7_Tab5_1 fr2 = new Form1BF7_Tab5_1();
                fr2.ShowDialog();
            }
            else if(tabControl1.SelectedIndex == 5)
            {
                Form1BF7_Tab6 fr3 = new Form1BF7_Tab6();
                fr3.ShowDialog();
            }
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public class DL
        {
            public static string t1t1;
            public static string t2t1;
            public static string t3t1;

            public static string t1t2;
            public static string t2t2;
            public static string t3t2;

            public static string t1t3;
            public static string t2t3;
            public static string t3t3;

            public static string t1t4;
            public static string t2t4;
            public static string t3t4;

            public static string t1t5;
            public static string t2t5;

            public static string t1t6;
            public static string t2t6;
            public static string t3t6;
        }

        public class RD
        {
            public static bool r1t1;
            public static bool r2t1;

            public static bool r1t2;
            public static bool r2t2;
            public static bool r3t2;
            public static bool r4t2;

            public static bool rin1t2;
            public static bool rin2t2;

            public static bool r1t3;
            public static bool r2t3;
            public static bool r3t3;
            public static bool r4t3;

            public static bool rin1t3;
            public static bool rin2t3;

            public static bool r1t4;
            public static bool r2t4;
            public static bool r3t4;
            public static bool r4t4;

            public static bool rdpht4;
            public static bool rdnhant4;
            public static bool rdhtt4;

            public static bool r1t6;
            public static bool r2t6;

        }

        public void Get_DLT1()
        {
            DL.t1t1 = tb1t1.Text;
            DL.t2t1 = tb2t1.Text;
            DL.t3t1 = tb3t1.Text;
        }
        public void Get_DLT2()
        {
            DL.t1t2 = tb1t2.Text;
            DL.t2t2 = tb2t2.Text;
            DL.t3t2 = tb3t2.Text;
        }
        public void Get_DLT3()
        {
            DL.t1t3 = tb1t3.Text;
            DL.t2t3 = tb2t3.Text;
            DL.t3t3 = tb3t3.Text;
        }
        public void Get_DLT4()
        {
            DL.t1t4 = tb1t4.Text;
            DL.t2t4 = tb2t4.Text;
            DL.t3t4 = tb3t4.Text;
        }

        public void Get_DLT5()
        {
            DL.t1t5 = tb1t5.Text;
            DL.t2t5 = tb2t5.Text;

        }
        public void Get_DLT6()
        {
            DL.t1t6 = tb1t6.Text;
            DL.t2t6 = tb2t6.Text;
            DL.t3t6 = tb3t6.Text;
        }
        public void Get_RDT1()
        {
            RD.r1t1 = rd1t1.Checked;
            RD.r2t1 = rd2t1.Checked;
        }
        public void Get_RDT2()
        {
            RD.r1t2 = rd1t2.Checked;
            RD.r2t2 = rd2t2.Checked;
            RD.r3t2 = rd3t2.Checked;
            RD.r4t2 = rd4t2.Checked;

            RD.rin1t2 = rdin1t2.Checked;
            RD.rin2t2 = rdin2t2.Checked;
        }
        public void Get_RDT3()
        {
            RD.r1t3 = rdt3_1.Checked;
            RD.r2t3 = rdt3_2.Checked;
            RD.r3t3 = rdt3_3.Checked;
            RD.r4t4 = rdt3_4.Checked;

            RD.rin1t3 = rdt3_in1.Checked;
            RD.rin2t3 = rdt3_in2.Checked;
        }
        public void Get_RDT4()
        {
            RD.r1t4 = rdt4_1.Checked;
            RD.r2t4 = rdt4_2.Checked;
            RD.r3t4 = rdt4_3.Checked;
            RD.r4t4 = rdt4_4.Checked;

            RD.rdpht4 = rdpbt4.Checked;
            RD.rdnhant4 = rdnhant4.Checked;
            RD.rdhtt4 = rdpbt4.Checked;
        }
        public void Get_RDT6()
        {
            RD.r1t6 = rdt6_in1.Checked;
            RD.r2t6 = rdt6_in2.Checked;
        }
        private void tb1t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t1();
        }
        private void tb1t1_TextChanged(object sender, EventArgs e)
        {
          
        }


        private void tb2t1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t1();
        }

        private void tb1t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t2();
        }

        private void tb2t2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t2();
        }

        private void rd1t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t3();
        }

        private void rd2t3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t3();
        }


        private void tb1t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t4();
        }

        private void tb2t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t4();
        }

        private void tb1t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t5();
        }

        private void tb2t5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t5();
        }

        private void tb1t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb1t6();
        }

        private void tb2t6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1BF5 fr = new Form1BF5();
            fr.ShowDialog();
            Get_tb2t6();
        }
        public void Get_tb1t1()
        {
            tb1t1.Text = Form1BF5.GUI.Tx1;   
        }
        public void Get_tb2t1()
        {
            tb2t1.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb1t2()
        {
            tb1t2.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb2t2()
        {
            tb2t2.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb1t3()
        {
            tb1t3.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb2t3()
        {
            tb2t3.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb1t4()
        {
            tb1t4.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb2t4()
        {
            tb2t4.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb1t5()
        {
            tb1t5.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb2t5()
        {
            tb2t5.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb1t6()
        {
            tb1t6.Text = Form1BF5.GUI.Tx1;
        }
        public void Get_tb2t6()
        {
            tb2t6.Text = Form1BF5.GUI.Tx1;
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Get_DLT1();
            Get_DLT2();
            Get_DLT3();
            Get_DLT4();
            Get_DLT5();
            Get_DLT6();
            Get_RDT1();
            Get_RDT2();
            Get_RDT3();
            Get_RDT4();
            Get_RDT6();

            if (tabControl1.SelectedIndex == 0)
            {
                Form1BF7_Tab1 fr1 = new Form1BF7_Tab1();
                fr1.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                MessageBox.Show("Chức năng này đang được phát triển! \n Bạn vui lòng liên hệ Admin để đươc hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Form1BF7_Tab5_1 fr2 = new Form1BF7_Tab5_1();
                fr2.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                Form1BF7_Tab6 fr3 = new Form1BF7_Tab6();
                fr3.ShowDialog();
            }
        }
        //tab 1
        private void tb1t1_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t1,tb2t1, sender,e);
        }

        private void tb2t1_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t1, tb3t1, sender, e);
        }

        private void tb3t1_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t1,tbxem, sender, e);
        }
        //button
        private void tbxem_KeyDown(object sender, KeyEventArgs e)
        {
            tbxem.PerformClick();
        }
        //tab 2
        private void tb1t2_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t2, tb2t2, sender, e);
        }
        private void tb2t2_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t2, tb3t2, sender, e);
        }
        private void tb3t2_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t2, tbxem, sender, e);
        }
        //tab 3
        private void tb1t3_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t3, tb2t3, sender, e);
        }
        private void tb2t3_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t3, tb3t3, sender, e);
        }
        private void tb3t3_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t3, tbxem, sender, e);
        }
        //tab 4
        private void tb1t4_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t4, tb2t4, sender, e);
        }
        private void tb2t4_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t4, tb3t4, sender, e);
        }
        private void tb3t4_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t4, tbxem, sender, e);
        }
        //tab 5
        private void tb1t5_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t5, tb2t5, sender, e);
        }
        private void tb2t5_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t5, tbxem, sender, e);
        }
        //tab 6
        private void tb1t6_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t6, tb2t6, sender, e);
        }
        private void tb2t6_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(tb1t6, tb3t6, sender, e);
        }
        private void tb3t6_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab_Button(tb2t6, tbxem, sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
