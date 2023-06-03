using CrystalDecisions.CrystalReports.Engine;
using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WTERP.WSEXE;
using WTERP.WSEXE.ReportView;
using static WTERP.WSEXE.Report;

namespace WTERP
{
    public partial class Form1IF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1IF7()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test_Check();
            Get_DL();
            if (tabControl1.SelectedIndex == 0)
            {
                if (rdLg1.Checked == true)
                {
                    Load_view1();
                }
                else if (rdLg2.Checked == true)
                {
                    Load_view2();
                }
            }
            else
            {
                tab2();
            }

            //} 
        }
        public void tab2()
        {
            //chưa xử lý được
            string sql = "SELECT QUOB.*,QUOH.C_NAME FROM QUOB,QUOH WHERE QUOH.WS_NO=QUOB.WS_NO AND W_CHECK='Y'";
            if (!string.IsNullOrEmpty(txtDATE.Text))
            {
                sql = sql + " AND QUOB.WS_DATE>='" + txtDATE.Text.Replace("/", "") + "'";
            }
            if (!string.IsNullOrEmpty(txtDATE_E.Text))
            {
                sql = sql + " AND QUOB.WS_DATE<='" + txtDATE_E.Text.Replace("/", "") + "'";
            }
            sql = sql + " ORDER BY QUOB.C_NO,QUOB.P_NO,QUOB.WS_DATE";

            DataTable data1 = conn.readdata(sql);
            ReportDocument cryRpt = new Cr_Form1IF7_Tab2();
            cryRpt.SetDataSource(data1);
            cryRpt.Subreports["Sub"].SetDataSource(data1);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        public class RD
        {
            public static bool R1;
            public static bool R2;
            public static bool R3;
            public static bool R4;
            public static bool R5;
            public static bool R6;
            public static bool R7;
            public static bool R8;
            public static bool rdN;
        }
        public class DL
        {
            public static string S1;
        }
        public void Test_Check()
        {
            RD.R1 = rd1.Checked;
            RD.R2 = rd2.Checked;
            RD.R3 = rd3.Checked;
            RD.R4 = rd4.Checked;
            RD.R5 = rd5.Checked;
            RD.R6 = rd6.Checked;
            RD.R7 = rd7.Checked;
            RD.R8 = rd8.Checked;
            RD.rdN = rdN.Checked;
        }
        public void Get_DL()
        {
            DL.S1 = txtWS_NO.Text;
        }
        public void Load_view1()
        {
            if (rdY.Checked == true)
            {
                if (rdAV_No.Checked == true)
                {
                    frm1IF7_Tab1_1 fr = new frm1IF7_Tab1_1();
                    fr.ShowDialog();
                }
                else if (rdAV_yes.Checked == true)
                {
                    frm1IF7_Tab1_2 fr = new frm1IF7_Tab1_2();
                    fr.ShowDialog();
                }
            }
            else if (rdN.Checked == true)
            {
                if (rdAV_No.Checked == true)
                {
                    frm1IF7_Tab1_3 fr = new frm1IF7_Tab1_3();
                    fr.ShowDialog();
                }
                else if (rdAV_yes.Checked == true)
                {
                    frm1IF7_Tab1_4 fr = new frm1IF7_Tab1_4();
                    fr.ShowDialog();
                }
            }
        }
        public void Load_view2()
        {
            if (rdAV_No.Checked == true)
            {
                frm1IF7_Tab1_21 fr = new frm1IF7_Tab1_21();
                fr.ShowDialog();

            }
            else if (rdAV_yes.Checked == true)
            {
                frm1IF7_Tab1_22 fr = new frm1IF7_Tab1_22();
                fr.ShowDialog();
            }
        }

        private void Form1IF7_Load(object sender, EventArgs e)
        {
            txtWS_NO.Text = Form1I.Get_WS_NO;
            rdLg1.Checked = true;
            rdAV_No.Checked = true;
            rdY.Checked = true;
            rd4.Checked = true;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btDong.PerformClick();
        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btxem.PerformClick();
        }

        private void txtWS_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm1IF7_FWS_NO fr = new frm1IF7_FWS_NO();
            fr.ShowDialog();
            string DL = frm1IF7_FWS_NO.Get_WS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO.Text = DL;

            }
            else
                txtWS_NO.Text = "";
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_Button(txtWS_NO, btxem, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO, txtC_NO_E, sender, e);
        }

        private void txtC_NO_E_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO, tctBrand, sender, e);
        }

        private void tctBrand_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(txtC_NO_E, txtDATE, sender, e);
        }

        private void txtDATE_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tctBrand, txtDATE_E, sender, e);
        }

        private void txtDATE_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btxem.Focus();
            }
        }
        private void btxem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btxem.PerformClick();
            }
        }

        private void txtDATE_MouseClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtDATE.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtDATE_E_MouseClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtDATE_E.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
