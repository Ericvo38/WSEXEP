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

namespace WTERP
{
    public partial class frm2NF5 : Form
    {
        DataProvider con = new DataProvider();
        public frm2NF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
            LoadDGVS();
        }
        public class getID
        {
            public static string ID;
        }

        //Searching 
        private void search()
        {
            string NgayKS = "";
            if (con.Check_MaskedText(txtngayKS) == true)
            {
                 NgayKS = con.formatstr2(txtngayKS.Text);
            }    
            string SoVB = txtsoVB.Text;
            string str1 = "SELECT WS_NO, WS_DATE, USR_NAME, UPDATEKIND FROM STOHC WHERE 1=1";
            if ((SoVB == "") && (NgayKS == ""))
            {
                str1 = str1 + "";
            }
            else if(SoVB != "")
                str1 = str1 + " AND WS_NO LIKE N'%" + SoVB + "%'";
            else if(NgayKS != "")
                str1 = str1 + " AND WS_DATE LIKE N'%" + NgayKS + "%'";
            DataTable dt = con.readdata(str1);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            }
            DGV2.DataSource = dt;
            con.DGV(DGV2);
        }
        //Load DaTaGridview
        private void LoadDGVS()
        {
            string S_SQL = "SELECT WS_NO, WS_DATE, USR_NAME, UPDATEKIND FROM STOHC";
            DataTable dt = con.readdata(S_SQL);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            }
            DGV2.DataSource = dt;
            con.DGV(DGV2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void DGV2_DoubleClick(object sender, EventArgs e)
        {
            getID.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            getID.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void txtngayKS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtngayKS.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtsoVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }    
            
        }

        private void txtngayKS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
    }
}

