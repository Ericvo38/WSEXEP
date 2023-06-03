using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2CF6 : Form
    {
        DataProvider con = new DataProvider();
        public frm2CF6()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();

        }

        public static List<DL2C_F6> LV = new List<DL2C_F6>();
        string MaKH = frm2C_1.F2c.MaKH;
        private void frm2CF6_Load(object sender, EventArgs e)
        {
            LV.Clear();

            Load_data();
            tb1.Select();
            tb1.Focus();
            txtCustNo.Text = MaKH;
            txtCustNo.ReadOnly = true;
        }

        public void Load_data()
        {
            string SQL = "SELECT TOP 1000 OR_NO,COLOR_C, COLOR_E, P_NAME_C, P_NAME_E, THICK, QTY,K_NO,WS_DATE, NR, C_NO, C_NAME_C, C_NAME_E,BRAND, MODEL_C, MODEL_E, P_NO, PATT_C, PATT_E,PRICE  FROM ORDB WHERE C_NO = '" + MaKH + "' ORDER BY WS_DATE DESC";
            DataTable dt = con.readdata(SQL);
            foreach (DataRow dr in dt.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }
        public void Search()
        {
            string SQL1 = "SELECT TOP 1000 OR_NO,COLOR_C, COLOR_E, P_NAME_C, P_NAME_E, THICK, QTY,K_NO,WS_DATE, NR, C_NO, C_NAME_C, C_NAME_E,BRAND, MODEL_C, MODEL_E, P_NO, PATT_C, PATT_E,PRICE FROM ORDB WHERE C_NO = '" + MaKH + "'";

            if (tb1.Text != "" && tb1.MaskFull == true)
                SQL1 = SQL1 + " AND WS_DATE LIKE '%" + con.formatstr1(tb1.Text) + "%' ";
            if (txtSoDH.Text != "")
                SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtSoDH.Text + "%' ";
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                SQL1 = SQL1 + " AND brand LIKE '%"+textBox3.Text+"%'";
            }
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                SQL1 = SQL1 + " AND P_NAME_C LIKE '%"+ textBox4.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtNameP_E.Text))
            {
                SQL1 = SQL1 + " AND P_NAME_E LIKE '%" + txtNameP_E.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtColor_C.Text))
            {
                SQL1 = SQL1 + " AND COLOR_C LIKE '%"+ txtColor_C.Text+ "%'";
            }
            if (!string.IsNullOrEmpty(txtColor_E.Text))
            {
                SQL1 = SQL1 + " AND COLOR_E LIKE '%" + txtColor_E.Text + "%'";
            }
            SQL1 = SQL1 + " ORDER BY WS_DATE DESC";

            DataTable dt1 = con.readdata(SQL1);
            foreach (DataRow dr in dt1.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt1;
            con.DGV(DGV1);

            if (LV.Count > 0)
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    foreach (var item1 in LV)
                    {
                        if (item.Cells["OR_NO"].Value.ToString() == item1.OR_NO && item.Cells["NR"].Value.ToString() == item1.NR && item.Cells["K_NO"].Value.ToString() == item1.K_NO)
                        {
                            item.SetValues(true);
                        }
                    }
                }
            }
        }
       
        public class DL2C_F6
        {
            public string OR_NO { get; set; }
            public string NR { get; set; }
            public string K_NO { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void txtSoDH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab_UP(tb1, textBox3, sender, e);
            }    
            
        }
        private void tb1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb1.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }
       

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab_UP(tb1, txtSoDH, sender, e);
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab(txtSoDH, textBox4, sender, e);
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab(textBox3, txtNameP_E, sender, e);
            }
        }

        private void txtNameP_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab(textBox4, txtColor_C, sender, e);
            }
        }

        private void txtColor_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab(txtNameP_E, txtColor_E, sender, e);
            }
        }

        private void txtColor_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab(txtColor_C, txtCustNo, sender, e);
            }
        }

        private void txtCustNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                con.tab_DOWN(txtColor_E, tb1, sender, e);
            }
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                reomveToList(DGV1.CurrentRow.Index);
            }
            else
            {
                addToList(DGV1.CurrentRow.Index);
            }
        }
        private void reomveToList(int cur)
        {
            var itemToRemove = LV.Single(r => r.OR_NO == DGV1.Rows[cur].Cells["OR_NO"].Value.ToString() && r.NR == DGV1.Rows[cur].Cells["NR"].Value.ToString() && r.K_NO == DGV1.Rows[cur].Cells["K_NO"].Value.ToString());
            LV.Remove(itemToRemove);
            DGV1.CurrentRow.Cells[0].Value = false;
        }
        private void addToList(int cur)
        {
            if (double.Parse(DGV1.CurrentRow.Cells["PRICE"].Value.ToString()) <= 0)
            {
                MessageBox.Show("Không thể chọn vì đơn giá bằng 0!!, vui lòng chọn lại","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            } 
            else
            {
                LV.Add(new DL2C_F6
                {
                    OR_NO = DGV1.Rows[cur].Cells["OR_NO"].Value.ToString(),
                    NR = DGV1.Rows[cur].Cells["NR"].Value.ToString(),
                    K_NO = DGV1.Rows[cur].Cells["K_NO"].Value.ToString(),
                });
                DGV1.CurrentRow.Cells[0].Value = true;
            }    
           
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 0)
                {
                    if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
                    {
                        reomveToList(DGV1.CurrentRow.Index);
                        DGV1.CurrentRow.Cells[0].Value = false;
                    }
                    else
                    {
                        addToList(DGV1.CurrentRow.Index);
                        DGV1.CurrentRow.Cells[0].Value = true;

                    }
                }
            }
        }
    }
}
