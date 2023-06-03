using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using LibraryCalender;

namespace WTERP
{
    public partial class Form3EF7 : Form
    {

        DataProvider conn = new DataProvider();
        public static string SQL_Share;
        public Form3EF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
         
        }
        
        #region Method Form
        private void View()
        {
            if (radio_mau.Checked == true)
            {
                Load_report();
                //Form3EF7Report fm = new Form3EF7Report();
                WSEXE.Module3._3E.FrmViewProduct3E fm = new WSEXE.Module3._3E.FrmViewProduct3E();
                fm.ShowDialog();
            }
            else if (radio_barcode.Checked == true)
            {
                Load_Barcode();
                Form3EF7_Barcode fr = new Form3EF7_Barcode();
                fr.ShowDialog();
            }
            else if (rdMau_New.Checked == true)
            {
                //Load_Newreport();
                //frm3EF7_mau_new fr = new frm3EF7_mau_new();
                //fr.ShowDialog();
            }
        }
        private void Load_report()
        {
            try
            {
                //string SQL = "SELECT WS_NO, OR_NO, WS_DATE, C_NAME, P_NAME,(P_NAME + ' - ' + P_WT + '('+ P_WTI + ')') AS P_NAME_NEW, MEMO01, BQTY, MEMO02, FOB_DATE, MEMO03, MEMO05, MEMO04, MEMO06, MEMO08, USR_NAME FROM PRDMK2 WHERE 1=1";
                string SQL = "SELECT WS_NO, OR_NO, WS_DATE, C_NAME, P_NAME,(P_NAME + ' - ' + P_WT + '('+ P_WTI + ')') AS P_NAME_NEW, MEMO01, BQTY, MEMO02, dbo.FormatString2(FOB_DATE) AS FOB_DATE, MEMO03, MEMO05, MEMO04, MEMO06, MEMO08, USR_NAME from PRDMK2 LEFT JOIN PROD_MATERIAL ON PRDMK2.MEMO07 = PROD_MATERIAL.P_WT WHERE 1=1";

                if (!string.IsNullOrEmpty(tb1.Text)) SQL = SQL + " AND WS_NO >= '" + tb1.Text+"' ";
                if (!string.IsNullOrEmpty(tb2.Text)) SQL = SQL + " AND WS_NO <= '" + tb2.Text + "' ";

                if (tb3.MaskCompleted) SQL = SQL + " AND WS_DATE >= '"+conn.formatstr2(tb3.Text)+ "' ";
                if (tb4.MaskCompleted) SQL = SQL + " AND WS_DATE >= '"+conn.formatstr2(tb4.Text)+ "' ";

                SQL_Share = SQL + " ORDER BY WS_NO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Load_Barcode()
        {
            try
            {
                string SQL = "SELECT WS_NO FROM PRDMK2 WHERE 1=1";

                if (!string.IsNullOrEmpty(tb1.Text)) SQL = SQL + " AND WS_NO >= '" + tb1.Text + "' ";
                if (!string.IsNullOrEmpty(tb2.Text)) SQL = SQL + " AND WS_NO <= '" + tb2.Text + "' ";

                if (tb3.MaskCompleted) SQL = SQL + " AND WS_DATE >= '" + conn.formatstr2(tb3.Text) + "' ";
                if (tb4.MaskCompleted) SQL = SQL + " AND WS_DATE >= '" + conn.formatstr2(tb4.Text) + "' ";

                SQL_Share = SQL + " ORDER BY WS_NO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Load_Newreport()
        {
            try
            {
                string SQL = "SELECT WS_NO, OR_NO, WS_DATE, C_NAME, C_ANAME, P_NAME, P_C AS P_NAME_NEW, MEMO01, BQTY, MEMO02, FOB_DATE, MEMO03, MEMO05, MEMO04, MEMO06, MEMO08, USR_NAME " +
                             "from PRDMK2 LEFT JOIN PROD_MATERIAL ON PRDMK2.MEMO07 = PROD_MATERIAL.P_WT WHERE 1=1";

                if (!string.IsNullOrEmpty(tb1.Text)) SQL = SQL + " AND WS_NO >= '" + tb1.Text + "' ";
                if (!string.IsNullOrEmpty(tb2.Text)) SQL = SQL + " AND WS_NO <= '" + tb2.Text + "' ";

                if (tb3.MaskCompleted) SQL = SQL + " AND WS_DATE >= '" + conn.formatstr2(tb3.Text) + "' ";
                if (tb4.MaskCompleted) SQL = SQL + " AND WS_DATE >= '" + conn.formatstr2(tb4.Text) + "' ";

                SQL_Share = SQL + " ORDER BY WS_NO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Button Action Form
        private void button3_Click(object sender, EventArgs e)
        {
           View();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        #endregion

        #region MenuStrip
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //F1
            Form3EF5 fr = new Form3EF5();
            fr.ShowDialog();

            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {

                tb1.Text = Form3EF5.getInfo.WS_NO;
                tb2.Text = Form3EF5.getInfo.WS_NO;
            }
            else
            {
                tb1.Text = "";
                tb2.Text = "";
            }
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //F4
            this.Hide();
            this.Close();
        }
        #endregion

        #region Event Form
        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr = new Form3EF5();
            fr.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                tb1.Text = Form3EF5.getInfo.WS_NO;
            }
            else
            {
                tb1.Text = "";
            }
        }
        private void tb2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr = new Form3EF5();
            fr.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                tb2.Text = Form3EF5.getInfo.WS_NO;
            }
            else
            {
                tb2.Text = "";
            }
        }

        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            tb3.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            tb4.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
       
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb4, tb2, sender, e);
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb1, tb3, sender, e);
        }
        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(tb2, tb4, sender, e);
        }
        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(tb3, tb1, sender, e);
        }

        #endregion
    }
}
