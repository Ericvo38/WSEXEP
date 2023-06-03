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
using WTERP.WSEXE.Module3._3D;

namespace WTERP
{
    public partial class frm3DF7 : Form
    {
        DataProvider con = new DataProvider();
        public static string Share_SQL;
        public static int PrintType = 1;
        public frm3DF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }

        //public class getID
        //{
        //    public static string BD;
        //    public static string KT;
        //    public static string DATE1;
        //    public static string DATE2;
        //}

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Views()
        {
            if (rdB1.Checked)
            {
                PrintSample();
                FrmViewReport3D fm = new FrmViewReport3D();
                fm.ShowDialog();
            }
            else
            {
                PrintBarcode();
                frm3DF7Barcode fm = new frm3DF7Barcode();
                fm.ShowDialog();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Views();
        }

        private void frm3DF7_Load(object sender, EventArgs e)
        {
            txt1.Text = frm3D.send_dt.t1;
            txt2.Text = frm3D.send_dt.t1;
        }

        private void txt1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm3DF7Sample ope = new frm3DF7Sample();
            ope.ShowDialog();
            txt1.Text = frm3DF7Sample.getMaVB.MaVB;
            frm3DF7Sample.getMaVB.MaVB = "";
        }

        private void txt2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm3DF7Sample ope = new frm3DF7Sample();
            ope.ShowDialog();
            txt2.Text = frm3DF7Sample.getMaVB.MaVB;
            frm3DF7Sample.getMaVB.MaVB = "";
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

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt1, txt2, sender, e);
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt1, maskedTextBox1, sender, e);
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txt2, maskedTextBox2, sender, e);
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(maskedTextBox1, txt1, sender, e);
        }

        #region Method Form
        private void TypePrint()
        {
            if (rdB1.Checked) PrintType = 1;
            else PrintType = 2;
        }
        
        #endregion

        #region Print Sample Template
        private void PrintSample()
        {
            try
            {
                //string SQL = "SELECT WS_NO, OR_NO, WS_DATE, C_ANAME, ISNULL(COLOR_C, COLOR_E) AS COLOR_E, P_NAME,(P_NAME + ' - ' + P_WT + '('+ P_WTI + ')') AS P_NAME_NEW, MODEL_C, BQTY, CLRCARD, FOB_DATE, PRDMK1.P_NAME2, MEMO16, MEMO16,M_TOT, MEMO08 " +
                //"from PRDMK1 LEFT JOIN PROD_MATERIAL ON PRDMK1.MEMO19 = PROD_MATERIAL.P_WT WHERE 1=1";
                string SQL = "SELECT WS_NO, OR_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_ANAME, ISNULL(COLOR_C, COLOR_E) AS COLOR_E, P_NAME, MODEL_C, BQTY, CLRCARD, dbo.FormatString2(FOB_DATE) AS FOB_DATE, PRDMK1.P_NAME2, MEMO16, MEMO16,M_TOT, MEMO08 FROM PRDMK1 WHERE 1=1 ";
                if (!string.IsNullOrEmpty(txt1.Text)) SQL = SQL + " AND WS_NO >= '"+txt1.Text+"'";
                if (!string.IsNullOrEmpty(txt2.Text)) SQL = SQL + " AND WS_NO <= '" + txt2.Text + "'";
                if (maskedTextBox1.MaskCompleted) SQL = SQL + " AND WS_DATE >= '"+con.formatstr2(maskedTextBox1.Text)+"' ";
                if (maskedTextBox2.MaskCompleted) SQL = SQL + " AND WS_DATE <= '" + con.formatstr2(maskedTextBox2.Text) + "' ";
                Share_SQL = SQL +" ORDER BY WS_NO";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Print Barcode 
        private void PrintBarcode()
        {
            string SQL = "SELECT WS_NO from PRDMK1 WHERE 1=1";
            if (!string.IsNullOrEmpty(txt1.Text)) SQL = SQL + " AND WS_NO >= '"+txt1.Text+"' ";
            if (!string.IsNullOrEmpty(txt2.Text)) SQL = SQL + " AND WS_NO <= '"+txt2.Text+"' ";

            if (maskedTextBox1.MaskFull) SQL = " AND WS_DATE >= '"+ con.formatstr2(maskedTextBox1.Text)+ "' ";
            if (maskedTextBox2.MaskFull) SQL = " AND WS_DATE <= '"+ con.formatstr2(maskedTextBox2.Text)+ "' ";

            Share_SQL = SQL + " ORDER BY WS_NO ";
        }
        #endregion

        
    }
}
