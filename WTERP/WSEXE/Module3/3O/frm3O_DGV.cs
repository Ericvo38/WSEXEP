using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frm3O_DGV : Form
    {
        DataProvider conn = new DataProvider();
        string key = "";
        public frm3O_DGV()
        {
            InitializeComponent();
        }
        private void frm3O_DGV_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(frm3O.DL3O.key_C_NO))
            {
                key = frm3O.DL3O.key_C_NO;

            }
            else if (!string.IsNullOrEmpty(frm3N.C_NO_ID.C_NO_ID_NUMBER))
            {
                key = frm3N.C_NO_ID.C_NO_ID_NUMBER;
            }
            LoadDataView1();
            LoadDataView2();
            conn.DGV(DGV3);
        }
        private void LoadDataView1()
        {
            string sql = "SELECT TOP 500 OR_NO,COLOR_E + ' '+ P_NAME_E AS COLOR,THICK as P_NAME3,QTY as BQTY,Price as PRICE,TOTAL AS AMOUNT,K_NO FROM ORDB WHERE 1=1 AND C_NO = '" + key + "'";
            if (!string.IsNullOrEmpty(txtOR_NO.Text))
            {
                sql = sql + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDate1.Text) && txtDate1.MaskFull == true)
            {
                string date = conn.formatstr2(txtDate1.Text);
                sql = sql + " AND WS_DATE LIKE '%" + date.Substring(2,6) + "%'";
            }
            sql = sql + " ORDER BY WS_DATE DESC";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            DGV1.DataSource = data;
            conn.DGV(DGV1);
        }
        private void LoadDataView2()
        {
            string sql = "SELECT TOP 500 WS_NO FROM CARH WHERE 1=1 AND C_NO = '" + key + "'";
            if (!string.IsNullOrEmpty(txtWS_NO.Text))
            {
                sql = sql + " AND WS_NO like '%" + txtWS_NO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDate2.Text) && txtDate2.MaskFull == true)
            {
                sql = sql + " AND WS_DATE LIKE '%" + conn.formatstr2(txtDate2.Text) + "%'";
            }
            sql = sql + " ORDER BY WS_NO DESC";

            DataTable data = new DataTable();
            data = conn.readdata(sql);
            DGV2.DataSource = data;
            conn.DGV(DGV2);

            if (DGV2.Rows.Count > 0)
            {
                getDataGridView_CARB(DGV2.Rows[0].Cells["WS_NO"].Value.ToString());
            }
            else
            {
                getDataGridView_CARB("");
            }

        }
        private void getDataGridView_CARB(string key)
        {
            string sql2 = "SELECT OR_NO AS OR_NO2,COLOR +' '+ P_NAME1 AS COLOR2,P_NAME3 AS P_NAME3_2,MEMO,BQTY AS BQTY2,PRICE AS PRICE2,AMOUNT AS AMOUNT2,CASE WHEN REPLACE(MEMO,' ','') " +
                "LIKE '%折補' OR REPLACE(MEMO,' ','') LIKE '%預補' THEN 'True' ELSE 'False' END AS Calculated2,K_NO FROM CARB WHERE 1=1 AND WS_NO = '" + key + "' ORDER BY WS_DATE DESC";
            DataTable data = new DataTable();
            data = conn.readdata(sql2);
            DGV_CARB.DataSource = data;
            conn.DGV(DGV_CARB);
            Changed_Color(DGV_CARB);
        }
        private void Changed_Color(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["Calculated2"].Value.ToString()))
                {
                    if (row.Cells["Calculated2"].Value.ToString() == "True")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
        private void btnCapNhat_DGV1_Click(object sender, EventArgs e)
        {
            AddDataDGV();
        }
        private void AddDataDGV()
        {
            DataGridViewRow row;
            if (DGV3.Rows.Count > 0)
            {
                row = (DataGridViewRow)DGV3.Rows[0].Clone();
            }
            else
            {
                DGV3.AllowUserToAddRows = true;
                row = (DataGridViewRow)DGV3.Rows[0].Clone();
            }
            // xử lý cắt chuỗi
            row.Cells[0].Value = "0";
            row.Cells[1].Value = DGV1.CurrentRow.Cells["OR_NO"].Value.ToString();
            row.Cells[2].Value = DGV1.CurrentRow.Cells["COLOR"].Value.ToString();
            row.Cells[3].Value = DGV1.CurrentRow.Cells["P_NAME3"].Value.ToString();
            row.Cells[4].Value = DGV1.CurrentRow.Cells["BQTY"].Value.ToString();
            row.Cells[5].Value = DGV1.CurrentRow.Cells["PRICE"].Value.ToString();
            row.Cells[6].Value = DGV1.CurrentRow.Cells["AMOUNT"].Value.ToString();
            row.Cells[7].Value = "0";
            row.Cells[8].Value = "0";
            //xử lý checkbox
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                row.Cells[9].Value = "True";
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                row.Cells[9].Value = "False";
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            row.Cells[10].Value = "";
            row.Cells[11].Value = "";
            row.Cells[12].Value = DGV1.CurrentRow.Cells["K_NO"].Value.ToString();

            DGV3.Rows.Add(row);
            DGV1.CurrentRow.Cells[0].Value = false;
            DGV3.AllowUserToAddRows = false;
            // Changed_Color(DGV3);

        }
        private void AddDataDGV2()
        {
            DataGridViewRow row;
            if (DGV3.Rows.Count > 0)
            {
                row = (DataGridViewRow)DGV3.Rows[0].Clone();
            }
            else
            {
                DGV3.AllowUserToAddRows = true;
                row = (DataGridViewRow)DGV3.Rows[0].Clone();
            }
            for (int i = 0; i < DGV_CARB.Rows.Count; i++)
            {
                row = (DataGridViewRow)DGV3.Rows[0].Clone();
                row.Cells[0].Value = "0";
                row.Cells[1].Value = DGV_CARB.Rows[i].Cells["OR_NO2"].Value.ToString();
                row.Cells[2].Value = DGV_CARB.Rows[i].Cells["COLOR2"].Value.ToString();
                row.Cells[3].Value = DGV_CARB.Rows[i].Cells["P_NAME3_2"].Value.ToString();
                row.Cells[4].Value = DGV_CARB.Rows[i].Cells["BQTY2"].Value.ToString();
                row.Cells[5].Value = DGV_CARB.Rows[i].Cells["PRICE2"].Value.ToString();
                row.Cells[6].Value = DGV_CARB.Rows[i].Cells["AMOUNT2"].Value.ToString();
                row.Cells[7].Value = "0";
                row.Cells[8].Value = "0";

                if (DGV_CARB.Rows[i].Cells["Calculated2"].Value.ToString() == "True")
                {
                    row.Cells[9].Value = DGV_CARB.Rows[i].Cells["Calculated2"].Value.ToString();
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.Cells[9].Value = DGV_CARB.Rows[i].Cells["Calculated2"].Value.ToString();
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                row.Cells[10].Value = "";
                row.Cells[11].Value = "";
                row.Cells[12].Value = DGV_CARB.Rows[i].Cells["K_NO_1"].Value.ToString();

                DGV3.Rows.Add(row);
            }
            DGV3.AllowUserToAddRows = false;
        }
        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataView1();
            }
        }
        private void DGV3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                menu.Items.Add("Delete").Name = "Del";
                menu.Items.Add("Delete_All").Name = "Del_All";
                menu.Show(DGV3, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Del":
                    foreach (DataGridViewCell oneCell in DGV3.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            int key = oneCell.RowIndex;
                            DGV3.Rows.RemoveAt(oneCell.RowIndex);
                        }
                    }
                    break;
                case "Del_All":
                    DialogResult dr = MessageBox.Show("Bạn muốn xóa tất cả không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int rowCount = DGV3.Rows.Count;
                        for (int i = rowCount - 1; i >= 0; i--)
                        {
                            DGV3.Rows.Remove(DGV3.Rows[i]);
                        }
                    }
                    break;
            }
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataView2();
            }
        }

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataGridView_CARB(DGV2.CurrentRow.Cells["WS_NO"].Value.ToString());
        }

        private void btnCapNhat_DGV2_Click(object sender, EventArgs e)
        {
            AddDataDGV2();
        }
        private void CreateColumnDataTable(DataTable dt)
        {
            dt.Columns.Add("CNO");
            dt.Columns.Add("OR_NO");
            dt.Columns.Add("COLOR");
            dt.Columns.Add("P_NAME3");
            dt.Columns.Add("BQTY",typeof(double));
            dt.Columns.Add("PRICE", typeof(double));
            dt.Columns.Add("AMOUNT", typeof(double));
            dt.Columns.Add("NW", typeof(double));
            dt.Columns.Add("GW", typeof(double));
            dt.Columns.Add("Calculated");
            dt.Columns.Add("IRNNUMBER_LEFT");
            dt.Columns.Add("IRNNUMBER_RIGHT");
            dt.Columns.Add("NPL");
            dt.Columns.Add("CHECK_GROUP",typeof(bool));
            dt.Columns.Add("TOTAL_GW", typeof(double));
            dt.Columns.Add("K_NO");

            for (int i = 0; i < DGV3.Rows.Count; i++)
            {
                DataRow rows = dt.NewRow();
                rows["CNO"] = DGV3.Rows[i].Cells["CNO3"].Value.ToString();
                rows["OR_NO"] = DGV3.Rows[i].Cells["OR_NO3"].Value.ToString();
                rows["COLOR"] = DGV3.Rows[i].Cells["DESCRIPTION3"].Value.ToString();
                rows["P_NAME3"] = DGV3.Rows[i].Cells["THICK3"].Value.ToString();
                rows["BQTY"] = DGV3.Rows[i].Cells["QTY3"].Value.ToString();
                rows["PRICE"] = DGV3.Rows[i].Cells["PRICE3"].Value.ToString();
                rows["AMOUNT"] = DGV3.Rows[i].Cells["AMOUNT3"].Value.ToString();
                rows["NW"] = DGV3.Rows[i].Cells["NW3"].Value.ToString();
                rows["GW"] = DGV3.Rows[i].Cells["GW3"].Value.ToString();
                rows["Calculated"] = DGV3.Rows[i].Cells["Calturated3"].Value.ToString();
                rows["IRNNUMBER_LEFT"] = "";
                rows["IRNNUMBER_RIGHT"] = "";
                rows["NPL"] = "";
                rows["CHECK_GROUP"] = false;
                rows["TOTAL_GW"] = 0;
                rows["K_NO"] = DGV3.Rows[i].Cells["K_NO_3"].Value.ToString();
                dt.Rows.Add(rows);
            }
        }
        private void btnOke_Click(object sender, EventArgs e)
        {
            DataTable data2 = new DataTable();
            CreateColumnDataTable(data2);
            DL_3O.data = data2;

            this.Hide();
            this.Close();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public class DL_3O
        {
            public static DataTable data;
            public static string K_NO;
        }

        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                DGV1.CurrentRow.Cells[0].Value = true;
            }
        }

        private void DGV2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtDate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataView1();
            }    
            
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataView2();
            }
        }
        private void DGV3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV3.Rows.Count > 0)
            {
                float AMOUNT = 0;
                int Cur = int.Parse(DGV3.CurrentCell.ColumnIndex.ToString());
                if (Cur == 4 || Cur == 5)
                {
                    AMOUNT = float.Parse(DGV3.CurrentRow.Cells["QTY3"].Value.ToString()) * float.Parse(DGV3.CurrentRow.Cells["PRICE3"].Value.ToString());
                    //DGV1.CurrentRow.Cells["AMOUNT"].Value = AMOUNT;
                    DGV3.Rows[DGV3.CurrentRow.Index].Cells[6].Value = Math.Round(AMOUNT, 2);
                }
            }
        }
        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataGridView_CARB(DGV2.CurrentRow.Cells["WS_NO"].Value.ToString());
        }
    }
}
