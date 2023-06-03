using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE.FormSearch
{
    public partial class frmSearchMaterial1IDGV : Form
    {
        DataProvider con = new DataProvider();
        public static List<Productions> Produc = new List<Productions>();
        public static int Options = 0;
        public frmSearchMaterial1IDGV()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frmSearchMaterial1IDGV_Load(object sender, EventArgs e)
        {
            LoadData();
            Produc.Clear();
        }
        public void LoadData()
        {
            string SQL = "SELECT P_NO, P_NAME, UNIT,BUNIT , PRICE,COST,CUNIT,TRANS, QTYSTORE, P_NAME1, K_NO ,P_NAME2 FROM dbo.PROD WHERE 1=1";
            if (!string.IsNullOrEmpty(tb1.Text)) SQL = SQL + " AND P_NO LIKE N'%" + tb1.Text + "%' ";
            if (!string.IsNullOrEmpty(tb2.Text)) SQL = SQL + " AND P_NAME LIKE N'%" + tb2.Text + "%' ";
            if (!string.IsNullOrEmpty(tb3.Text)) SQL = SQL + " AND UNIT LIKE N'%" + tb3.Text + "%' ";
            if (!string.IsNullOrEmpty(tb4.Text)) SQL = SQL + " AND P_NAME1 LIKE N'%" + tb4.Text + "%' ";
            DataTable dt = con.readdata(SQL);
            dataGridViewlieu.DataSource = dt;
            con.DGV(dataGridViewlieu);
            dataGridViewlieu.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 16F, FontStyle.Bold);
            dataGridViewlieu.Columns[0].DefaultCellStyle.ForeColor = Color.Red;
            dataGridViewlieu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewlieu.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //if (Options == 1) dataGridViewlieu.Columns[0].Visible = false;
            //else if (Options == 2) dataGridViewlieu.Columns[0].Visible = true;
        }
        private void AddList()
        {
            if (dataGridViewlieu.Rows.Count < 0) return;
            for (int i = 0; i < dataGridViewlieu.Rows.Count; i++)
            {
                if (dataGridViewlieu.Rows[i].Cells[0].Value != null)
                {
                    Productions P = new Productions();
                    P.ID_P_NO = dataGridViewlieu.Rows[i].Cells["P_NO"].Value.ToString();
                    P.P_NAME = dataGridViewlieu.Rows[i].Cells["P_NAME"].Value.ToString();
                    P.P_NAME1 = dataGridViewlieu.Rows[i].Cells["P_NAME1"].Value.ToString();
                    P.K_NO = dataGridViewlieu.Rows[i].Cells["K_NO"].Value.ToString();
                    P.UNIT = dataGridViewlieu.Rows[i].Cells["UNIT"].Value.ToString();
                    P.BUNIT = dataGridViewlieu.Rows[i].Cells["BUNIT"].Value.ToString();
                    P.PRICE = dataGridViewlieu.Rows[i].Cells["PRICE"].Value.ToString();
                    P.COST = dataGridViewlieu.Rows[i].Cells["COST"].Value.ToString();
                    P.CUNIT = dataGridViewlieu.Rows[i].Cells["CUNIT"].Value.ToString();
                    P.TRANS = dataGridViewlieu.Rows[i].Cells["TRANS"].Value.ToString();
                    P.P_NAME2 = dataGridViewlieu.Rows[i].Cells["P_NAME2"].Value.ToString();
                    Produc.Add(P);

                    //Produc.Add(new Productions
                    //{
                    //    ID_P_NO = dataGridViewlieu.Rows[i].Cells["P_NO"].Value.ToString(),
                    //    P_NAME = dataGridViewlieu.Rows[i].Cells["P_NAME"].Value.ToString(),
                    //    P_NAME1 = dataGridViewlieu.Rows[i].Cells["P_NAME1"].Value.ToString(),
                    //    K_NO = dataGridViewlieu.Rows[i].Cells["K_NO"].Value.ToString(),
                    //    UNIT = dataGridViewlieu.Rows[i].Cells["UNIT"].Value.ToString(),
                    //    BUNIT = dataGridViewlieu.Rows[i].Cells["BUNIT"].Value.ToString(),
                    //    PRICE = dataGridViewlieu.Rows[i].Cells["PRICE"].Value.ToString(),
                    //    COST = dataGridViewlieu.Rows[i].Cells["COST"].Value.ToString(),
                    //    CUNIT = dataGridViewlieu.Rows[i].Cells["CUNIT"].Value.ToString(),
                    //    TRANS = dataGridViewlieu.Rows[i].Cells["TRANS"].Value.ToString(),
                    //    P_NAME2 = dataGridViewlieu.Rows[i].Cells["P_NAME2"].Value.ToString(),
                    //});
                }
            }
            if (Produc.Count <= 0)
            {
                if (frmLogin.Lang_ID == 1) MessageBox.Show("Vui lòng chọn sản phẩm !");
                else if (frmLogin.Lang_ID == 2) MessageBox.Show("Please choose a product !");
                else if (frmLogin.Lang_ID == 3) MessageBox.Show("请选择产品！");
                return;
            }
            else
            {
                this.Close();
            }
        }
        public class Productions
        {
            //public int NR { get; set; }
            public string ID_P_NO { get; set; }
            public string P_NAME { get; set; }
            public string P_NAME1 { get; set; }
            public string K_NO { get; set; }
            public string UNIT { get; set; }
            public string BUNIT { get; set; }
            public string PRICE { get; set; }
            public string COST { get; set; }
            public string CUNIT { get; set; }
            public string TRANS { get; set; }
            public string QTYSTORE { get; set; }
            public string P_NAME2 { get; set; }
            public string P_NAME3 { get; set; }
        }

        #region Button Actions Form
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Produc.Clear();
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            AddList();
        }
        #endregion

        #region Keydown Searching Data
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }
        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }
        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadData();
        }
        #endregion

        int Count = 0;
        private void dataGridViewlieu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Options == 1)
            {
                foreach (DataGridViewRow dr in dataGridViewlieu.Rows)
                {
                    dr.Cells[0].Value = null;
                }
                dataGridViewlieu.CurrentRow.Cells[0].Value = "v";
            }
            else if(Options == 2)
            {
                if (dataGridViewlieu.CurrentRow.Cells[0].Value == null)
                {
                    Count++;
                    dataGridViewlieu.CurrentRow.Cells[0].Value = Count;
                    dataGridViewlieu.Refresh();
                }
                else
                {
                    int tam = int.Parse(dataGridViewlieu.CurrentRow.Cells[0].Value.ToString());
                    dataGridViewlieu.CurrentRow.Cells[0].Value = null;
                    foreach (DataGridViewRow dr in dataGridViewlieu.Rows)
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
                    dataGridViewlieu.Refresh();
                    Count--;
                }
            }
        }
    }
}
