using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2NF7 : Form
    {
        DataProvider conn = new DataProvider();
        public frm2NF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class getSTR
        {
            public static string WS_NO;
            public static string C_NO;
            public static string EM;
            public static string WS_DATE;
        }
        private void frm2NF7_Load(object sender, EventArgs e)
        {
            txtWS_NO_S.Text = frm2N.getNR.WS_NO;
            txtWS_NO_E.Text = frm2N.getNR.WS_NO;
            txtWS_DATE_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtWS_DATE_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
        private void txtC_NO_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txtC_NO_S.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txtC_NO_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fm = new frm2CustSearch();
            fm.ShowDialog();
            txtC_NO_E.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void txtEM_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 fm = new FormSearchStaff4();
            fm.ShowDialog();
            txtEM_S.Text = FormSearchStaff4.ID.S_NAME2;
        }

        private void txtEM_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 fm = new FormSearchStaff4();
            fm.ShowDialog();
            txtEM_E.Text = FormSearchStaff4.ID.S_NAME2;
            
        }
        private void View()
        {
            if (txtWS_NO_S.Text != "" && txtWS_NO_E.Text != "")
                getSTR.WS_NO = "AND STOBC.WS_NO BETWEEN '"+ txtWS_NO_S.Text + "' AND '"+ txtWS_NO_E.Text + "'  ";
            
            else if(txtC_NO_S.Text != "" && txtC_NO_E.Text != "")
                getSTR.C_NO = "AND STOBC.C_NO BETWEEN '" +txtC_NO_S.Text + "' AND '" + txtC_NO_E.Text+ "'  ";

            else if (txtEM_S.Text != "" && txtEM_E.Text != "")
                getSTR.EM = "AND STOHC.USR_NAME BETWEEN '" + txtEM_S.Text + "' AND '" + txtEM_E.Text + "'  ";
            
            else if (txtWS_DATE_S.Text != "" && txtWS_DATE_E.Text != "")
                getSTR.WS_DATE = "AND STOBC.WS_DATE BETWEEN '" + txtWS_DATE_S.Text + "' AND '" + txtWS_DATE_E.Text + "'  ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            View();
            frm2NF7_Print fm = new frm2NF7_Print();
            fm.ShowDialog();
        }

        private void txtWS_NO_S_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtWS_DATE_E, txtWS_NO_E, sender, e);
        }

        private void txtWS_NO_E_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtWS_NO_S, txtC_NO_S, sender, e);
        }

        private void txtC_NO_S_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtWS_NO_E, txtC_NO_E, sender, e);
        }

        private void txtC_NO_E_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO_S, txtEM_S, sender, e);
        }

        private void txtEM_S_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO_E, txtEM_E, sender, e);
        }

        private void txtEM_E_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtEM_S, txtWS_DATE_S, sender, e);
        }

        private void txtWS_DATE_S_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtEM_E, txtWS_DATE_E, sender, e);
        }

        private void txtWS_DATE_E_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtWS_DATE_S, txtWS_NO_S, sender, e);
        }
    }
}
