using LibraryCalender;
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
    public partial class frm2FF7 : Form
    {
        DataProvider con = new DataProvider();
        public frm2FF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        string a = "";
        public class Share_frm2FF7
        {
            public static string C_NO_S;
            public static string C_NO_E;
            public static string MONTH;
        }
        private void frm2FF7_Load(object sender, EventArgs e)
        {
            C_NO_S.Text =  frm2F.Share_2F.C_NO;
            C_NO_E.Text = frm2F.Share_2F.C_NO;
        }

        private void C_NO_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            C_NO_S.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void C_NO_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            C_NO_E.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void MONTH_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            MONTH.Text = FromCalender.getDate.ToString("yyyy/MM");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.Check_MaskedText(MONTH) == true)
            {
                a = con.formatstr1(a);
            }    
            Share_frm2FF7.C_NO_S = C_NO_S.Text;
            Share_frm2FF7.C_NO_E = C_NO_E.Text;
            Share_frm2FF7.MONTH = a;

            frm2FF7_Print fm = new frm2FF7_Print();
            fm.ShowDialog();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void C_NO_S_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(MONTH, C_NO_E, sender, e);
        }

        private void C_NO_E_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(C_NO_S, MONTH, sender, e);
        }

        private void MONTH_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(C_NO_E, C_NO_S, sender, e);
        }
    }
}
