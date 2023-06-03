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
    public partial class frm2MF5 : Form
    {
        DataProvider con = new DataProvider();
        public frm2MF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2MF5_Load(object sender, EventArgs e)
        {
            loadfirst();
        }
        public class getID_C
        {
            public static string ID;
            public static string Wheres;
            public static string Index ="";
        }

        private void loadfirst()
        {
            string sqlstr = "SELECT TOP 30 WS_NO, WS_DATE, C_NO, C_ANAME, UPDATEKIND FROM RCVH where 1=1 " + getID_C.Wheres+" ORDER BY WS_NO DESC";
            DataTable dt1 = con.readdata(sqlstr);
            if (dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                DGV2.DataSource = dt1;
            }
            con.DGV(DGV2);
        }
        private void searching() // Tìm kiếm 
        {
            getID_C.Wheres = "";
            string soVB = txtsoVB.Text.Trim();
            string maKH = txtmaKH.Text.Trim();
            string ngayLap = con.formatstr2(txtngayLap.Text.Trim());
            string sqlstr = "SELECT WS_NO, WS_DATE, C_NO, C_ANAME, UPDATEKIND FROM RCVH WHERE 1=1";
            if ((soVB == "") && (maKH == "") && (ngayLap == ""))
            {
                sqlstr = sqlstr + "";
            }
            else if (soVB != "")
            {
                sqlstr = sqlstr + " AND WS_NO LIKE N'%" + soVB + "%'";
                getID_C.Wheres = getID_C.Wheres + " AND WS_NO LIKE N'%" + soVB + "%'";
            }
            else if (maKH != "")
            {
                sqlstr = sqlstr + " AND C_NO LIKE N'%" + maKH + "%'";
                getID_C.Wheres = getID_C.Wheres + " AND C_NO LIKE N'%" + maKH + "%'";
            }
            else if (ngayLap != "")
            {
                sqlstr = sqlstr + " AND WS_DATE LIKE N'%" + ngayLap + "%'";
                getID_C.Wheres = getID_C.Wheres + " AND WS_DATE LIKE N'%" + ngayLap + "%'";
            }

            sqlstr = sqlstr + " ORDER BY WS_NO DESC";
            DataTable dt = con.readdata(sqlstr);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                DGV2.DataSource = dt;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getID_C.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            getID_C.Index = DGV2.CurrentRow.Index.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getID_C.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            getID_C.Index = DGV2.CurrentRow.Index.ToString();
            this.Close();
        }

        private void txtsoVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching();
            }
        }

        private void txtngayLap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching();
            }
        }

        private void txtmaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching();
            }
        }
    }
}
