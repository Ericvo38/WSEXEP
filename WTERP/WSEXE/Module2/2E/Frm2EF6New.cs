using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2E
{
    public partial class Frm2EF6New : Form
    {
        DataProvider connect = new DataProvider();
        public static List<Product> Products; 
        public Frm2EF6New()
        {
            InitializeComponent();
        }

        private void Frm2EF6New_Load(object sender, EventArgs e)
        {
            Products = new List<Product>();
            LoadData();
            txtOR_NO.Select();
            txtOR_NO.Focus();
        }
        public void LoadData()
        {
            try
            {
                string SQL = "SELECT Top 100 NR, OR_NO,C_NO,C_NAME_E, COLOR_E,dbo.FormatString1(WS_DATE) AS WS_DATE,P_NAME_E,THICK,QTY,P_NO,K_NO,PATT_C,PATT_E,MODEL_E FROM ORDB WHERE  C_NO ='"+txtWS_DATE.Text+"' ORDER BY WS_DATE DESC, NR DESC, OR_NO DESC";
                DataTable dt = connect.readdata(SQL);
                DGV1.DataSource = dt;
                DGV1.DataGridViewFormat();
                DGV1.Columns["Check"].DefaultCellStyle.Format = "#,##0";
                DGV1.Columns["Check"].DefaultCellStyle.Font = new Font("Tahoma", 16F, FontStyle.Bold);
                DGV1.Columns["Check"].DefaultCellStyle.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Search()
        {
            string SQL1 = "SELECT NR, OR_NO,C_NO,C_NAME_E, COLOR_E,dbo.FormatString1(WS_DATE) AS WS_DATE,P_NAME_E,THICK,QTY,P_NO,K_NO,PATT_C,PATT_E,MODEL_E FROM ORDB WHERE 1=1";
            if (!string.IsNullOrEmpty(txtP_NO.Text)) SQL1 = SQL1 + " AND P_NO LIKE '%" + txtP_NO.Text + "%'";
            if (!string.IsNullOrEmpty(txtOR_NO.Text)) SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%'";
            if (!string.IsNullOrEmpty(txtTHICK.Text)) SQL1 = SQL1 + " AND THICK LIKE '%" + txtTHICK.Text + "%'";
            if (!string.IsNullOrEmpty(txtP_NAME_C.Text)) SQL1 = SQL1 + " AND P_NAME_C LIKE '%" + txtP_NAME_C.Text + "%'";
            if (!string.IsNullOrEmpty(txtP_NAME_E.Text)) SQL1 = SQL1 + " AND P_NAME_E LIKE '%" + txtP_NAME_E.Text + "%'";
            if (!string.IsNullOrEmpty(txtCOLOR_C.Text)) SQL1 = SQL1 + " AND COLOR_C LIKE '%" + txtCOLOR_C.Text + "%'";
            if (!string.IsNullOrEmpty(txtC_NO.Text)) SQL1 = SQL1 + " AND C_NO = '" + txtC_NO.Text + "'";
            if (txtWS_DATE.MaskCompleted) SQL1 = SQL1 + " AND WS_DATE LIKE '%" + txtWS_DATE.Text.Replace("/", "") + "%' ";

            SQL1 = SQL1 + " ORDER BY WS_DATE DESC, NR DESC";

            DataTable dt1 = connect.readdata(SQL1);
            DGV1.DataSource = dt1;
            DGV1.DataGridViewFormat();
            
        }
        int Count = 0;
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGV1.CurrentRow.Cells[0].Value == null)
            {
                Count++;
                DGV1.CurrentRow.Cells[0].Value = Count;
                DGV1.Refresh();
            }
            else
            {
                int tam = int.Parse(DGV1.CurrentRow.Cells[0].Value.ToString());
                DGV1.CurrentRow.Cells[0].Value = null;
                foreach (DataGridViewRow dr in DGV1.Rows)
                {
                    if (dr.Cells[0].Value != null)
                    {
                        string cellValue = dr.Cells[0].Value.ToString();
                        int tam2;
                        int.TryParse(cellValue, out tam2);
                        if (tam2 > tam)
                        {
                            tam2--;
                            dr.Cells[0].Value = tam2;
                        }
                    }
                }
                DGV1.Refresh();
                Count--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV1.Rows.Count <= 0) return;
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    if (DGV1.Rows[i].Cells[0].Value != null)
                    {
                        Products.Add(new Product
                        {
                            //WS_DATE = connect.formatstr1(DGV1.Rows[i].Cells["WS_DATE"].Value.ToString()),
                            WS_DATE = DGV1.Rows[i].Cells["WS_DATE"].Value.ToString(),
                            K_NO = DGV1.Rows[i].Cells["K_NO"].Value.ToString(),
                            C_NO = DGV1.Rows[i].Cells["C_NO"].Value.ToString(),
                            NR = DGV1.Rows[i].Cells["NR"].Value.ToString(),
                        });
                    }
                }

                if (Products.Count > 0)
                {
                    this.Close();
                }
                else
                {
                    if (frmLogin.Lang_ID == 1) throw new Exception("Vui lòng chọn đơn hàng !");
                    else if(frmLogin.Lang_ID == 2) throw new Exception("Please select order !");
                    else if(frmLogin.Lang_ID == 4) throw new Exception("请选择指令 ！");
                    else throw new Exception("Vui lòng chọn đơn hàng !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public class Product
        {
            public string WS_DATE { get; set; }
            public string NR { get; set; }
            public string C_NO { get; set; }
            public string K_NO { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products.Clear();
            this.Close();
        }

        #region Enter Search
        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtP_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtP_NAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtCOLOR_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtCOLOR_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }
        #endregion
    }
}
