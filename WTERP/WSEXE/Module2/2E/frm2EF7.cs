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
    public partial class frm2EF7 : Form
    {
        DataProvider con = new DataProvider();
        public frm2EF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2EF7_Load(object sender, EventArgs e)
        {
            txtWS_NO.Text = Form2E.txtWS_NO;
            txtWS_NO1.Text = Form2E.txtWS_NO;
            txtIn.Text = "Y";
        }
       
        private void txt1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2EF7_TX1 fr1 = new frm2EF7_TX1();
            fr1.ShowDialog();

            string DL = frm2EF7_TX1.DT.txt1;
            if (DL != string.Empty)
                txt1.Text = DL;
            else
                txt1.Text = "";
        }

        private void txt2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2EF7_TX1 fr1 = new frm2EF7_TX1();
            fr1.ShowDialog();

            string DL = frm2EF7_TX1.DT.txt2;
            if (DL != string.Empty)
                txt2.Text = DL;
            else
                txt2.Text = "";
        }

        private void txtDate1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtDate2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtC_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            string DL = frm2CustSearch.ID.ID_CUST;

            if (DL != string.Empty)
                txtC_NO1.Text = DL;
            else
                txtC_NO1.Text = "";
        }

        private void txtC_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
                txtC_NO2.Text = DL;
            else
                txtC_NO2.Text = "";
        }
        private void txtWS_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            G_TAB1.txWS_NO1 = txtWS_NO.Text;
            frm2EF7_TX1 fr1 = new frm2EF7_TX1();
            fr1.ShowDialog();

            string DL = frm2EF7_TX1.DT.txWS_NO_1;
            if (DL != string.Empty)
                txtWS_NO1.Text = DL;
            else
                txtWS_NO1.Text = "";
        }

        private void txtWS_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            G_TAB1.txWS_NO1 = txtWS_NO.Text;
            frm2EF7_TX1 fr1 = new frm2EF7_TX1();
            fr1.ShowDialog();

            string DL = frm2EF7_TX1.DT.txWS_NO;
            if (DL != string.Empty)
                txtWS_NO.Text = DL;
            else
                txtWS_NO.Text = "";
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btxemtruoc.PerformClick();
        }

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
           if(tabControl1.SelectedIndex == 0)
           {
                Tab1();
           }
           else if(tabControl1.SelectedIndex == 1)
           {
                Tab2();
            }
        }

        public class G_TAB1
        {
            public static string txWS_NO1;
            public static string txWS_NO2;
            public static string T;
        }
        public void Tab1()
        {
            G_TAB1.txWS_NO1 = txtWS_NO.Text;
            G_TAB1.txWS_NO2 = txtWS_NO1.Text;
            G_TAB1.T = txtIn.Text;
            if(rdMK.Checked == true)
            {
                frm2EF7_Tab1_1 fr = new frm2EF7_Tab1_1();
                fr.ShowDialog();
            }
            else if (rdK.Checked == true)
            {
                frm2EF7_Tab1_2 fr1 = new frm2EF7_Tab1_2();
                fr1.ShowDialog();
            }
        }
        public class G_TAB2
        {
            public static string txWNO1;
            public static string txWNO2;
            public static string txDate1;
            public static string txDate2;
            public static string txCNO1;
            public static string txCNO2;

        }
        string a = "";
        string b = "";
        public void check()
        {
            if (con.Check_MaskedText(txtDate1) == true)
            {
                a = con.formatstr2(txtDate1.Text);
            }
            if (con.Check_MaskedText(txtDate2) == true)
            {
                b = con.formatstr2(txtDate2.Text);
            }
        }
        public void Tab2()
        {
            check();
            G_TAB2.txWNO1 = txt1.Text;
            G_TAB2.txWNO2 = txt2.Text;
            G_TAB2.txDate1 = a;
            G_TAB2.txDate2 = b;
            G_TAB2.txCNO1 = txtC_NO1.Text;
            G_TAB2.txCNO2 = txtC_NO2.Text;

            //if(rdAll.Checked == true)
            //{
            //    frm2EF7_Tab2_1 fr = new frm2EF7_Tab2_1();
            //    fr.ShowDialog();
            //}
            //else if (rdB.Checked == true)
            //{
            //    frm2EF7_Tab2_1 fr = new frm2EF7_Tab2_1();
            //    fr.ShowDialog();
            //}
            //else if (rdC.Checked == true)
            //{
            //    frm2EF7_Tab2_1 fr = new frm2EF7_Tab2_1();
            //    fr.ShowDialog();
            //}
            //else if(rdT.Checked == true)
            //{
            //    string SQL = "SELECT WS_NO, WS_KIND FROM GIBH WHERE WS_NO = '"+txt1.Text+"'";
            //    DataTable dts = con.readdata(SQL);
            //    string BC = "";
            //    string BB = txt1.Text.Substring(0, 1);
            //    foreach (DataRow dr in dts.Rows) 
            //    {
            //        BC = dr["WS_KIND"].ToString();
            //    }

            //    if(BC == BB)
            //    {
            //        frm2EF7_Tab2_2 fr1 = new frm2EF7_Tab2_2();
            //        fr1.ShowDialog();
            //    }
            //    else
            //    {
            //        frm2EF7_Tab2_1 fr = new frm2EF7_Tab2_1();
            //        fr.ShowDialog();
            //    }
            //}
            string where1 = "";
            if (rdC.Checked == true)
            {
                where1 = where1 + " AND GIBH.WS_KIND='C'";
            }else if(rdT.Checked == true)
            {
                where1 = where1 + " AND GIBH.WS_KIND='T'";
            }
            else if (rdB.Checked == true)
            {
                where1 = where1 + " AND GIBH.WS_KIND='B'";
            }

            if(!string.IsNullOrEmpty(txt1.Text))
            {
                where1 = where1 + " AND GIBH.WS_NO>='"+ txt1.Text +"'";
            }
            if(!string.IsNullOrEmpty(txt2.Text))
            {
                where1 = where1 + " AND GIBH.WS_NO<='"+ txt2.Text+"'";
            }
            if(!string.IsNullOrEmpty(txtC_NO1.Text))
            {
                where1 = where1 + " AND GIBH.C_NO>='" + txtC_NO1 .Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO2.Text))
            {
                where1 = where1 + " AND GIBH.C_NO<='"+ txtC_NO2.Text+"'";
            }
            if (!string.IsNullOrEmpty(txtDate1.Text))
            {
                where1 = where1 + " AND GIBH.WS_date>='"+txtDate1.Text.Replace("/","")+"'";
            }
            if (!string.IsNullOrEmpty(txtDate2.Text))
            {
                where1 = where1 + " AND GIBH.WS_date<='" + txtDate2.Text.Replace("/", "") + "'";
            }

            string report = "SELECT a.WS_DATE,GIBB.WS_NO,C_ANAME,GIBB.OR_NO,P_NAME,COLOR,BQTY,a.PRICE,AMOUNT" +
                            " FROM GIBH, GIBB"+
                            " JOIN ORDB a ON a.OR_NO = GIBB.OR_NO AND a.NR = GIBB.OR_NR"+
                            " WHERE GIBH.WS_NO = GIBB.WS_NO" + where1 +
                            " ORDER BY GIBH.C_NO,GIBH.WS_DATE";
            System.Data.DataTable dt = con.readdata(report);
            ReportDocument cryRpt = new cr_Form2EF7_Tab2();
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtWS_NO1, txtWS_NO1, sender, e);
        }

        private void txtWS_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtWS_NO, txtWS_NO, sender, e);
        }

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO2, txt1, sender, e);
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt1, txtDate1, sender, e);
        }

        private void txtDate1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt2, txtDate2, sender, e);
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate1, txtC_NO1, sender, e);
        }

        private void txtC_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2, txtC_NO2, sender, e);
        }

        private void txtC_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO1, txtC_NO2, sender, e);
        }
    }
}
