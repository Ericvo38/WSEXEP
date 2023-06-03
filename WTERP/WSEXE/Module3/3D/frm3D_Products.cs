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
    public partial class frm3D_Products : Form
    {
        DataProvider conn = new DataProvider();
        public static string WS_NO = string.Empty, Share_OR_NO = string.Empty, Share_NR = string.Empty;
        public static int row = -1;
        public frm3D_Products()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        public string getK_NO { get; set; }
        public string getC_NO2 { get; set; }
        public string getOR_NO { get; set; }
        public string getDate { get; set; }
        public string Get_NR { get; set; }

        public static string G_NO = frm3D.G_CNO;  
        
        private void frm3D_Product_Load(object sender, EventArgs e)
        {
            row = -1;
            textBox2.Focus();
            LoadDGV3();
        }

        #region Method Form
        void LoadDGV3()
        {
            string SQL3 = "SELECT TOP 1000 OR_NO,COLOR_C,COLOR_E,P_NAME_C,P_NAME_E, THICK,QTY,K_NO,WS_DATE,NR,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO FROM ORDB WHERE K_NO in ('1','2','7','8','6','9') AND (OVER0<>'Y' AND OVER1<>'Y')";
            if (!string.IsNullOrEmpty(frm3D.C_NO))
            {
                SQL3 = SQL3 + " AND C_NO = '" + frm3D.C_NO + "'";
            }
            SQL3 = SQL3 + " ORDER BY WS_DATE DESC";
            DataTable dt3 = new DataTable();
            dt3 = conn.readdata(SQL3);
            if (dt3 != null)
            {
                foreach (DataRow dr in dt3.Rows)
                    dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt3;
            DGV3.DataSource = bindingSource;
            conn.DGV1(DGV3);
        }
        void Search()
        {
            string SQL4 = "SELECT TOP 1000 OR_NO,COLOR_C,COLOR_E,P_NAME_C,P_NAME_E, THICK,QTY,K_NO,WS_DATE,NR,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO FROM ORDB WHERE 1=1";
            if (txtDate.Text == string.Empty && textBox2.Text == string.Empty && textBox3.Text == string.Empty && textBox4.Text == string.Empty && textBox5.Text == string.Empty && textBox6.Text == string.Empty && textBox7.Text == string.Empty)
                SQL4 = SQL4 + "";
            if (txtDate.Text != string.Empty && txtDate.MaskFull == true)
                SQL4 = SQL4 + " AND WS_DATE LIKE '%"+ txtDate.Text.Replace("/","") + "%' ";
            if (textBox2.Text != string.Empty)
                SQL4 = SQL4 + " AND OR_NO LIKE '%" + textBox2.Text + "%' ";
            if (textBox3.Text != string.Empty)
                SQL4 = SQL4 + " AND BRAND LIKE '%" + textBox3.Text + "%' ";
            if (textBox4.Text != string.Empty)
                SQL4 = SQL4 + " AND P_NAME_C LIKE '%" + textBox4.Text + "%' ";
            if (textBox5.Text != string.Empty)
                SQL4 = SQL4 + " AND P_NAME_E LIKE '%" + textBox5.Text + "%' ";
            if (textBox6.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_C LIKE '%" + textBox6.Text + "%' ";
            if (textBox7.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_E LIKE '%" + textBox7.Text + "%' ";
            if (!string.IsNullOrEmpty(frm3D.C_NO))
            {
                SQL4 = SQL4 + " AND C_NO = '" + frm3D.C_NO + "'";
            }
            SQL4 = SQL4 + " AND K_NO in ('1','2','7','6') ORDER BY WS_DATE DESC";
            DataTable dt3 = new DataTable();
            dt3 = conn.readdata(SQL4);
            if (dt3 != null)
            {
                foreach (DataRow dr in dt3.Rows)
                    dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt3;
            DGV3.DataSource = bindingSource;
            conn.DGV1(DGV3);
        }
        private string MessaErorr()
        {
            string Result = string.Empty;
            if (frmLogin.Lang_ID == 1) Result = "Vui lòng chọn dữ liệu!";
            if (frmLogin.Lang_ID == 2) Result = "Please select data!";
            if (frmLogin.Lang_ID == 3) Result = "請選擇資料!";
            return Result;
        }
        #endregion

        #region Event KeyDown TextBox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        #endregion

        #region Event DataGridView
        private void DGV3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if (row >= 0)
            {
                getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
                Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
                getDate = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
                getK_NO = DGV3.CurrentRow.Cells["K_NO"].Value.ToString();
                getC_NO2 = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
            }
        }
        private void DGV3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            if(row >= 0)
            {
                getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
                Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
                getDate = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
                getK_NO = DGV3.CurrentRow.Cells["K_NO"].Value.ToString();
                getC_NO2 = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
                this.Close();
            }
        }
        #endregion

        #region Event Button Actions Form
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (row>=0)
            {
                getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
                Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
                getDate = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
                getK_NO = DGV3.CurrentRow.Cells["K_NO"].Value.ToString();
                getC_NO2 = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show(MessaErorr(), conn.MessaTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
