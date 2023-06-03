using System;
using System.Data;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2CustSearch : Form
    {
        DataProvider con = new DataProvider();
        public frm2CustSearch()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();

        }
        public class ID
        {
            public static string ID_CUST;
            public static string NAME_C;
            public static string NAME_E;
            public static string C_ANAME2;
            public static string ADR3;

            public static string DEFA_MONEY;
            public static string PAY_CON;
        }
        // Tim Kiem
        private void searching()
        {
            string MaKH = txtmaKH.Text;
            string TenKH = txttenKH.Text;

            string sql;
            sql = "SELECT C_NO, C_NAME2, C_NAME2_E, C_ANAME2,ADR3,DEFA_MONEY,PAY_CON FROM  CUST WHERE 1=1";
            if ((MaKH == "") && (TenKH == ""))
            {
                sql = sql + "";
            }

            if (MaKH != "")
                sql = sql + " AND C_NO LIKE N'%" + MaKH + "%'";
            if (TenKH != "")
                sql = sql + " AND C_NAME2 LIKE N'%" + TenKH + "%'";
            DataTable dt = con.readdata(sql);
            DGV2.DataSource = dt;
            con.DGV(DGV2);


        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ID.ID_CUST = DGV2.CurrentRow.Cells["C_NO"].Value.ToString();
            ID.NAME_C = DGV2.CurrentRow.Cells["C_NAME2"].Value.ToString();
            ID.NAME_E = DGV2.CurrentRow.Cells["C_NAME2_E"].Value.ToString();
            ID.C_ANAME2 = DGV2.CurrentRow.Cells["C_ANAME2"].Value.ToString();
            ID.ADR3 = DGV2.CurrentRow.Cells["ADR3"].Value.ToString();
            ID.PAY_CON = DGV2.CurrentRow.Cells["PAY_CON"].Value.ToString();
            ID.DEFA_MONEY = DGV2.CurrentRow.Cells["DEFA_MONEY"].Value.ToString();

            this.Close();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            con.Closeconnect();
            this.Close();
        }

        private void frm2CustSearch_Load(object sender, EventArgs e)
        {
            string str2 = "SELECT C_NO, C_NAME2,C_NAME2_E, C_ANAME2,ADR3,DEFA_MONEY,PAY_CON FROM CUST";
            DataTable dt = con.readdata(str2);
            DGV2.DataSource = dt;
            con.DGV(DGV2);
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void txtmaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching();
            }
        }

        private void txttenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searching();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}