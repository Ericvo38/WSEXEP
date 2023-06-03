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
    public partial class frm3FF5 : Form
    {
        DataProvider conn = new DataProvider();
        BindingSource source;
        DataTable dataTable;
        public frm3FF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class get3FF5
        {
            public static BindingSource getWS_NO;
            public static string getC_NO;
            public static bool check;
        }
        string MaKH3F = frm3F.MaKH;
        private void frm3FF5_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (!string.IsNullOrEmpty(MaKH3F))
            {
                string sql = "SELECT * FROM dbo.PRDMK3 WHERE C_NO = '" + MaKH3F + "' order by WS_NO DESC";
                dataTable = new DataTable();
                dataTable = conn.readdata(sql);
                foreach(DataRow dataRow in dataTable.Rows)
                {
                    dataRow["WS_DATE"] = conn.formatstr2(dataRow["WS_DATE"].ToString());
                }
                source = new BindingSource();
                source.DataSource = dataTable;
                DGV2.DataSource = source;
            }
            conn.DGV(DGV2);
        }
        private void Search()
        {
            string sql = "";
            sql = "SELECT * FROM dbo.PRDMK3 WHERE 1=1";
            if (txtSoVB.Text != "")
            {
                sql = sql + " AND WS_NO like '%" + txtSoVB.Text + "%'";
            }
            if (txtMaKH.Text != "")
            {
                sql = sql + " AND C_NO like '%" + txtMaKH.Text + "%'";
            }
            if (txtNgayLap.Text != "")
            {
                sql = sql + " AND WS_DATE like '%" + conn.formatstr2(txtNgayLap.Text) + "%'";
            }
            if (txtTenKH.Text != "")
            {
                sql = sql + " AND C_NAME like '%" + txtTenKH.Text + "%'";
            }
            sql = sql + "order by WS_NO DESC";
            dataTable = conn.readdata(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["WS_DATE"] = conn.formatstr2(dataRow["WS_DATE"].ToString());
            }
            source = new BindingSource();
            source.DataSource = dataTable;
            DGV2.DataSource = source;
            conn.DGV(DGV2);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            get3FF5.check = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {   
            get3FF5.getWS_NO = source;
            get3FF5.getC_NO = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            get3FF5.getWS_NO = source;
            get3FF5.getC_NO = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void frm3FF5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                get3FF5.getWS_NO = source;
                get3FF5.getC_NO = DGV2.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }    
        }

        private void txtSoVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }    
        }
        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
        private void txtNgayLap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
