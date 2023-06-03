using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3DF7Sample : Form
    {
        DataProvider con = new DataProvider();
        public frm3DF7Sample()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void LoadDGV2()
        {
            string str1 = "SELECT TOP 100 WS_NO, WS_DATE, C_NAME, P_NAME FROM PRDMK1 ORDER BY WS_NO DESC";
            DataTable dt = con.readdata(str1);
            if(dt != null)
            {
                DGV2.DataSource = dt;
                con.DGV(DGV2);
            }
        }
        private void Searching()
        {
            string str2 = "";
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = "";
            if (con.Check_MaskedText(maskedTextBox1)== true)
            {
                t4 = con.formatstr2(maskedTextBox1.Text);
            }           
            string t5 = textBox5.Text;
            str2 = "SELECT WS_NO, WS_DATE, C_NAME, P_NAME, C_NO FROM PRDMK1 WHERE 1=1";
            if (t1 == "" && t2 == "" && t3 == "" && t4 == "" && t5 == "")
                str2 = str2 + "";
            if (t1 != "")
                str2 = str2 + " AND WS_NO LIKE '%" + t1 + "%'";
             if (t2 != "")
                str2 = str2 + " AND C_NO LIKE '%" + t2 + "%'";
             if (t3 != "")
                str2 = str2 + " AND C_NAME LIKE '%" + t3 + "%'";
             if (t4 != "")
                str2 = str2 + " AND WS_DATE = '" + t4 + "'";
             if (t5 != "")
                str2 = str2 + " AND P_NAME LIKE '%" + t5 + "%' ";
            str2 = str2 + " ORDER BY WS_NO DESC";
            DataTable dt = con.readdata(str2);
            if (dt != null)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString()); 
                }    
                DGV2.DataSource = dt;    
                con.DGV(DGV2);  
            }
           
        }

        public class getMaVB
        {
            public static string MaVB;
        }


        private void frm3DF7Sample_Load(object sender, EventArgs e)
        {
            LoadDGV2();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            getMaVB.MaVB = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getMaVB.MaVB = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void maskedTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            maskedTextBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Searching();
            }      
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
    }
}
