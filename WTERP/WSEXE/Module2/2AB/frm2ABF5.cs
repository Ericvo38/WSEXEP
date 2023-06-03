
using LibraryCalender;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form2ABF5 : Form
    {
        DataProvider connect = new DataProvider();
     
        public Form2AB f1 = new Form2AB();

        SqlConnection con;
        string st = CN.str;
        DataTable Tb = new DataTable();
        string sql;
        public static string where;
        public static int index = 0;
        public Form2ABF5()
        {
            this.ShowInTaskbar = false;
            connect.choose_languege();
            InitializeComponent();
            this.dataGridViewtkdonhang.MouseWheel += new MouseEventHandler(mousewheel);

        }
        private void mousewheel(object sender, MouseEventArgs e)
        {
            connect.Mousewheelscroll(dataGridViewtkdonhang, e);
        }
        private void Formtimkiemdonhang_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            loaddata_tkdonhang();
            Color_Data();
        }
        public void loaddata_tkdonhang()
        {

            connect.DGV1(dataGridViewtkdonhang);

            Search();
            dataGridViewtkdonhang.DataSource = Tb; // cho khung data bang 
            //dataGridViewtkdonhang.AllowUserToAddRows = true;
            this.Controls.Add(dataGridViewtkdonhang);
            getInfo.getWS_NO = "";
            getInfo.getMaKH = "";
            getInfo.getNR = "";
            getInfo.getDATE = "";
        }
        public string CheckNgonNgu()
        {
            string sql = "";
            if (DataProvider.LG.rdVietNam == true)
            {
                sql = "tbl_Type_New.K_NAME";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                sql = "tbl_Type_New.K_NAME_EN";
            }
            if (DataProvider.LG.rdChina == true)
            {
                sql = "tbl_Type_New.K_NAME_CN";
            }
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                sql = "tbl_Type_New.K_NAME";
            }
            return sql;
        }
        public class getInfo
        {
            public static string getWS_NO;
            public static string getMaKH;
            public static string getNR;
            public static string getDATE;
        }   
        private void bttk_Click(object sender, EventArgs e)
        {
            where = "";
            pageIndex = 0;
            Search();
        }
        public void Search()
        {
            sql = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC) AS ROWID, K_NO,(SELECT "+ CheckNgonNgu() + " FROM dbo.tbl_Type_New WHERE K_NO = ORDB.K_NO)  as K_NAME, ORDB.WS_DATE, ORDB.NR, ORDB.OR_NO, ORDB.C_NO, ORDB.C_NAME_C," +
                    " ORDB.C_NAME_E, ORDB.B_NO,ORDB.BRAND, ORDB.T_NAME, ORDB.MODEL_C, ORDB.MODEL_E, ORDB.P_NO, ORDB.P_NAME_C, ORDB.P_NAME_E, ORDB.COLOR_C, " +
                    " ORDB.COLOR_E,ORDB.PATT_E, ORDB.PATT_C, ORDB.THICK, ORDB.QTY, ORDB.CURRENCY, ORDB.CLRCARD, ORDB.PRICE, ORDB.PER_S, ORDB.GRADE, ORDB.ACCOUNT, " +
                    " ORDB.ACHI, ORDB.WS_DATE1,ORDB.SCHEDULE2,ORDB.WS_DATE3, ORDB.TOTAL, ORDB.WS_DATE_F, ORDB.PURCHASER, ORDB.ORD_WEG, ORDB.DEVSTAGE,ORDB.MK_PLACE, ORDB.SER_NO, " +
                    " ORDB.COMPOUNTS, ORDB.DESIGER, ORDB.RV_PLACE, ORDB.SEASON, ORDB.SALES, ORDB.REMARKS, ORDB.QTY_OUT, ORDB.OVER0, ORDB.ONOS " +
                    " FROM ORDB where 1 =1 "+ where;

            if ((txttkdonhang.Text == "") && (txttkkhachhang.Text == "") && (txttenkhA.Text == "") && (txttenkhH.Text == "") && (txtBRAND.Text == "") && (txtT_NAME.Text == "") && (txtlieuA.Text == "") && (txtlieuH.Text == "")
                && (txtnoidung.Text == "") && (dtngayxuongdon.Text == ""))
            {
                where = where + "";
            }
            if (!string.IsNullOrEmpty(txttkdonhang.Text))
            {
                where = where + " AND OR_NO LIKE N'%" + txttkdonhang.Text + "%' ";
            }    
            if (!string.IsNullOrEmpty(txttkkhachhang.Text))
            {
                where = where + " AND C_NO LIKE N'" + txttkkhachhang.Text + "%'";
            }    
            if (!string.IsNullOrEmpty(txttenkhH.Text))
            {
                where = where + " AND C_NAME_C LIKE N'%" + txttenkhH.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txttenkhA.Text))
            {
                where = where + " AND C_NAME_E LIKE N'%" + txttenkhA.Text + "%'";
            }

            if (!string.IsNullOrEmpty(txtBRAND.Text))
            {
                where = where + " AND Brand LIKE N'%" + txtBRAND.Text + "%'";
            }
               
            if (!string.IsNullOrEmpty(txtT_NAME.Text))
            {
                where = where + " AND T_NAME LIKE N'%" + txtT_NAME.Text + "%'";
            }    
               
            if (!string.IsNullOrEmpty(txtlieuH.Text))
            {
                where = where + " AND P_NAME_C LIKE N'%" + txtlieuH.Text + "%'";
            }    
                
            if (!string.IsNullOrEmpty(txtlieuA.Text))
            {
                where = where + " AND P_NAME_E LIKE N'%" + txtlieuA.Text + "%'";
            }    
               
            if (!string.IsNullOrEmpty(dtngayxuongdon.Text.Replace("/","").Replace(" ","")))
            {
                where = where + " AND WS_DATE LIKE '" + dtngayxuongdon.Text.Replace("/", "").Replace(" ", "") + "%'";
            }      
            if (!string.IsNullOrEmpty(txtnoidung.Text))
            {
                where = where + " AND RV_PLACE LIKE N'%" + txtnoidung.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtCOLOR.Text))
            {
                where = where + " AND COLOR_E LIKE N'%" + txtCOLOR.Text + "%'";
            }
            sql = sql + where + ") ORDB where 1=1 AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);

            Tb = connect.readdata(sql);
            foreach (DataRow dr in Tb.Rows)
            {
                dr["WS_DATE"] = connect.formatstr1(dr["WS_DATE"].ToString());
            }
            dataGridViewtkdonhang.DataSource = Tb;
            connect.DGV1(dataGridViewtkdonhang);
            Color_Data();

            pageIndex++;
        }
        public void Color_Data() // Loading Color DataGridView 
        {
            foreach (DataGridViewRow row in dataGridViewtkdonhang.Rows)
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
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewtkdonhang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getInfo.getWS_NO = dataGridViewtkdonhang.CurrentRow.Cells["OR_NO"].Value.ToString();
            getInfo.getMaKH = dataGridViewtkdonhang.CurrentRow.Cells["C_NO"].Value.ToString();
            getInfo.getNR = dataGridViewtkdonhang.CurrentRow.Cells["NR"].Value.ToString();
            getInfo.getDATE = connect.formatstr1(dataGridViewtkdonhang.CurrentRow.Cells["WS_DATE"].Value.ToString());
            index = dataGridViewtkdonhang.CurrentRow.Index;
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            getInfo.getWS_NO = dataGridViewtkdonhang.CurrentRow.Cells["OR_NO"].Value.ToString();
            getInfo.getMaKH = dataGridViewtkdonhang.CurrentRow.Cells["C_NO"].Value.ToString();
            getInfo.getDATE = connect.formatstr1(dataGridViewtkdonhang.CurrentRow.Cells["WS_DATE"].Value.ToString());
            index = dataGridViewtkdonhang.CurrentRow.Index;
            this.Close();
        }

        private void txttkkhachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txttkdonhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txttenkhH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txthinhthe1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txttenkhA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txtlieuH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void dtngayxuongdon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txtlieuA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }

        private void txtnoidung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }
        private void dtngayxuongdon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            dtngayxuongdon.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public static string Search1;

        private void txttkkhachhang_DoubleClick(object sender, EventArgs e)
        {
            frm2CustSearch frm2CustSearch1 = new frm2CustSearch();
            frm2CustSearch1.ShowDialog();
            txttkkhachhang.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void txtT_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }
        int pageIndex = 0;
        int PageSize = 300;
        private void dataGridViewtkdonhang_Scroll(object sender, ScrollEventArgs e)
        {

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                int display = dataGridViewtkdonhang.Rows.Count - dataGridViewtkdonhang.DisplayedRowCount(false);
                if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
                {
                    if (e.NewValue >= dataGridViewtkdonhang.Rows.Count - GetDisplayedRowsCount())
                    {
                        string str = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY WS_DATE DESC) AS ROWID, K_NO,(SELECT " + CheckNgonNgu() + " FROM dbo.tbl_Type_New WHERE K_NO = ORDB.K_NO)  as K_NAME, ORDB.WS_DATE, ORDB.NR, ORDB.OR_NO, ORDB.C_NO, ORDB.C_NAME_C," +
                                        " ORDB.C_NAME_E, ORDB.B_NO,ORDB.BRAND, ORDB.T_NAME, ORDB.MODEL_C, ORDB.MODEL_E, ORDB.P_NO, ORDB.P_NAME_C, ORDB.P_NAME_E, ORDB.COLOR_C, " +
                                        " ORDB.COLOR_E,ORDB.PATT_E, ORDB.PATT_C, ORDB.THICK, ORDB.QTY, ORDB.CURRENCY, ORDB.CLRCARD, ORDB.PRICE, ORDB.PER_S, ORDB.GRADE, ORDB.ACCOUNT, " +
                                        " ORDB.ACHI, ORDB.WS_DATE1,ORDB.SCHEDULE2,ORDB.WS_DATE3, ORDB.TOTAL, ORDB.WS_DATE_F, ORDB.PURCHASER, ORDB.ORD_WEG, ORDB.DEVSTAGE,ORDB.MK_PLACE, ORDB.SER_NO, " +
                                        " ORDB.COMPOUNTS, ORDB.DESIGER, ORDB.RV_PLACE, ORDB.SEASON, ORDB.SALES, ORDB.REMARKS, ORDB.QTY_OUT, ORDB.OVER0, ORDB.ONOS " +
                                        " FROM ORDB where 1 =1 " + where + ") a where 1=1 AND ROWID between " + ((pageIndex * PageSize) + 1) + " and " + ((pageIndex + 1) * PageSize);

                        DataTable ds = new DataTable();
                        ds = connect.readdata(str);
                        foreach (DataRow dr in ds.Rows)
                        {
                            dr["WS_DATE"] = connect.formatstr1(dr["WS_DATE"].ToString());
                            dr["WS_DATE_F"] = connect.formatstr2(dr["WS_DATE_F"].ToString());
                            dr["WS_DATE1"] = connect.formatstr2(dr["WS_DATE1"].ToString());
                            dr["SCHEDULE2"] = connect.formatstr2(dr["SCHEDULE2"].ToString());
                        }
                        Tb.Merge(ds);
                        dataGridViewtkdonhang.DataSource = Tb;
                        connect.DGV1(dataGridViewtkdonhang);
                        Color_Data();
                        int index1 = dataGridViewtkdonhang.CurrentRow.Index;
                        dataGridViewtkdonhang.ClearSelection();
                        dataGridViewtkdonhang.FirstDisplayedScrollingRowIndex = display;
                        if (display > index1)
                        {
                            dataGridViewtkdonhang.CurrentCell = dataGridViewtkdonhang[dataGridViewtkdonhang.CurrentCell.ColumnIndex, display];
                        }
                        else
                        {
                            dataGridViewtkdonhang.CurrentCell = dataGridViewtkdonhang[dataGridViewtkdonhang.CurrentCell.ColumnIndex, index1];
                        }
                        pageIndex++;
                    }
                }
            }
        }
        private int GetDisplayedRowsCount()
        {
            int count = dataGridViewtkdonhang.Rows[dataGridViewtkdonhang.FirstDisplayedScrollingRowIndex].Height;
            count = dataGridViewtkdonhang.Height / count;
            return count;
        }
        private void txtCOLOR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pageIndex = 0;
                where = "";
                Search();
            }
        }
    }   
}
