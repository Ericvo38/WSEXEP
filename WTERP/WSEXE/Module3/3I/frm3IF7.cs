using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frm3IF7 : Form
    {
        DataProvider conn = new DataProvider();
        public frm3IF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btdong.PerformClick();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btxem.PerformClick();
        }

        private void frm3IF7_Load(object sender, EventArgs e)
        {
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public class RD
        {
            public static bool r1;
            public static bool r2;
            public static bool r3;
            public static bool r4;
            public static bool rp;
            public static bool ex;
        }
        public class DL
        {
            public static string D1;
            public static string D1_Tab3;
            public static string D2_Tab3;
            public static string D1_Tab5;
            public static string D1_Tab4;
            public static string D2;
        }

        private void btxem_Click(object sender, EventArgs e)
        {
            RD.r1 = rd1.Checked;
            RD.r2 = rd2.Checked;
            RD.r3 = rd3.Checked;
            RD.r4 = rd4.Checked;
            RD.rp = rdrp.Checked;
            RD.ex = rdex.Checked;
            DL.D1 = txtWS_DATE1.Text;
            DL.D2 = txtWS_DATE1.Text;
    
            if(tabControl1.SelectedIndex == 0)
            {
                View1();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                View2();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                View3();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                View4();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    View5();
                }    
               else
                {
                    MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void View1()
        {
            frm3IF7_Tab1 fr = new frm3IF7_Tab1();
            fr.s = txtWS_DATE1.Text;
            if(rd1.Checked == true)
            {
                fr.valuerdb = 1;
            }
            else
            {
                fr.valuerdb = 2;
            }
            fr.ShowDialog();
        }
        public void View2()
        {
            frm3IF7_Tab2 fr = new frm3IF7_Tab2();
            if (rdrp.Checked == true)
            {
                fr.type = 1;
                if (rd3.Checked == true)
                {
                    fr.valuerdb = 1;
                }
                else if (rd4.Checked == true)
                {
                    fr.valuerdb = 2;
                }
            }
            else
            {
                fr.type = 2;
            }
            fr.WS_NO = tb1.Text;
            fr.ShowDialog();
        }
        public void View3()
        {
            string a = "";
            string b = "";
            if (conn.Check_MaskedText(maskedTextBox1) == true)
            {
                a = conn.formatstr2(maskedTextBox1.Text);
            }
            if (conn.Check_MaskedText(maskedTextBox2) == true)
            {
                b = conn.formatstr2(maskedTextBox2.Text);
            }
            DL.D1_Tab3 = a;
            DL.D2_Tab3 = b;
            frm3IF7_Tab3 fr = new frm3IF7_Tab3();
            fr.ShowDialog();
        }
        private void View4()
        {
            DL.D1_Tab4 = tb4.Text;
            frm3IF7_Tab4 fr = new frm3IF7_Tab4();
            fr.ShowDialog();
        }
        private void View5()
        {
            DL.D1_Tab5 = textBox1.Text;
            frm3IF7_Tab5 frm3 = new frm3IF7_Tab5();
            frm3.ShowDialog();
        }
        private void txtWS_DATE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm3IF5 frm3 = new frm3IF5();
            frm3.ShowDialog();
            txtWS_DATE1.Text = frm3IF5.GetWS_NO;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            frm3IF5 frm3 = new frm3IF5();
            frm3.ShowDialog();
            textBox1.Text = frm3IF5.GetWS_NO;
        }

        private void maskedTextBox1_DoubleClick(object sender, EventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            maskedTextBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            //frmDateTime fm = new frmDateTime();
            //fm.ShowDialog();
            //maskedTextBox1.Text = frmDateTime.Date.ToString("yyyy/MM/dd");
        }

        private void maskedTextBox2_DoubleClick(object sender, EventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            maskedTextBox2.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
            //frmDateTime fm = new frmDateTime();
            //fm.ShowDialog();
            //maskedTextBox2.Text = frmDateTime.Date.ToString("yyyy/MM/dd");
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP_DOWN(maskedTextBox2, maskedTextBox2, sender, e);
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP_DOWN(maskedTextBox1, maskedTextBox1, sender, e);
        }

        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm3IF5 frm3 = new frm3IF5();
            frm3.ShowDialog();
            tb1.Text = frm3IF5.GetWS_NO;
        }
    }
}
