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
    public partial class frm2IF5 : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source = new BindingSource();
        public frm2IF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
            Searching();
            changeColor();
            con.DGV(DGV2);
        }
        public class getinfo
        {
           public static string where;
           public static int index;
        }
        private void Searching()
        {
            getinfo.where = "";
            string MaKH = txtMaKH.Text;
            string Date = "";
            string SoDH = txtNoHang.Text;
            string NhanHieu = txtNhanHieu.Text;
            string TenSPC = txtTenSPC.Text;
            string TenSPE = txtTenSPE.Text;
            string sql = "";
            if (con.Check_MaskedText(txtDateOR) == true)
            {
                Date = con.formatstr1(txtDateOR.Text);
            }
           
            if (MaKH == "" && Date == "" && SoDH == "" && NhanHieu == "" && TenSPC == "" && TenSPE == "")
            {
                getinfo.where = getinfo.where +  "";
            }
             if(MaKH != "")
            {
                getinfo.where = getinfo.where + " AND C_NO like '%" + MaKH + "%'";
            }
             if (Date != "")
            {
                getinfo.where = getinfo.where + " AND WS_DATE like '%" + Date + "%'";
            }
             if (SoDH != "")
            {
                getinfo.where = getinfo.where + " AND OR_NO like '%" + SoDH + "%'";
            }
             if (NhanHieu != "")
            {
                getinfo.where = getinfo.where + " AND BRAND like '%" + NhanHieu + "%'";
            }
             if (TenSPC != "")
            {
                getinfo.where = getinfo.where + " AND C_NAME_C like '%" + TenSPC + "%'";
            }
             if (TenSPE != "")
            {
                getinfo.where = getinfo.where + " AND C_NAME_E like '%" + TenSPE + "%'";
            }
             sql = "SELECT TOP 200" + CheckNgonNgu() + " as K_NAME,ORDBC.K_NO,WS_DATE,NR,OR_NO,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO,P_NAME_C,P_NAME_E,PATT_C,PATT_E,COLOR_C,COLOR_E,THICK,QTY,'' AS ONOS " +
              "FROM ORDBC INNER JOIN tbl_Type_NEW on ORDBC.K_NO = tbl_Type_NEW.K_NO Where 1=1" + getinfo.where;
            sql = sql + " ORDER BY WS_DATE DESC"; 
            DataTable dt = con.readdata(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
                source.DataSource = dt;
                DGV2.DataSource = source;
                changeColor();
                con.DGV(DGV2);
               
            }     
        }
        public string CheckNgonNgu()
        {
            string sql = "";
            if (DataProvider.LG.rdVietNam == true)
            {
                sql = "K_NAME";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                sql = "K_NAME_EN";
            }
            if (DataProvider.LG.rdChina == true)
            {
                sql = "K_NAME_CN";
            }
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                sql = "K_NAME";
            }
            return sql;
        }
        //to mau
        private void changeColor()
        {
            foreach (DataGridViewRow row in DGV2.Rows)
            {
                if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("1"))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("2"))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkCyan;
                }
                else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("3"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("4"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("7"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Indigo;
                }
                else if (Convert.ToInt32(row.Cells["K_NO"].Value) == Convert.ToInt32("6"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (DGV2.Rows.Count <= 0 )
            {
                getinfo.where = "";
                getinfo.index = 0;

            }
            else
            {
                getData();
            }    
            this.Close();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getData();
        }
        private void getData()
        {
            if (DGV2.Rows.Count > 0)
            {
                getinfo.index = DGV2.CurrentRow.Index;
            }    
            else
            {
                getinfo.index = 0;
            }    
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void txtDateOR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDateOR.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) 
            Searching();
        }
        private void txtDateOR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
        private void txtNoHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
        private void txtNhanHieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
        private void txtTenSPC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
        private void txtTenSPE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }
        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Searching();
        }

        private void frm2IF5_Load(object sender, EventArgs e)
        {

        }
    }
}
