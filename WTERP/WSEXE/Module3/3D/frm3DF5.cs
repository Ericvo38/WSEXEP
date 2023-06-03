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
    public partial class frm3DF5 : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source = new BindingSource();
        string where = "";
        public frm3DF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void LoadDGV3()
        {
            string SQL1 = "SELECT TOP 500 WS_DATE, WS_NO, OR_NO, C_NO,C_NAME,C_ANAME, P_NAME, FOB_DATE, BQTY, MEMO08, MEMO11, MEMO12, MEMO13, CLRCARD, MODEL_C,P_NAME1, P_NAME2, COLOR_C, MEMO14, MEMO15, MEMO16, PG_NO, M_TOT, USR_NAME, MEMO19 FROM PRDMK1 WHERE 1=1 " + frm3D.Where + " ORDER BY WS_NO DESC";
            DataTable dt = con.readdata(SQL1);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());    
            }
            source.DataSource = dt;
            DGV3.DataSource = source;
            datagribviewHide();
            con.DGV(DGV3);
        }
        private void datagribviewHide()
        {
            this.DGV3.Columns["C_NO"].Visible = false;
            this.DGV3.Columns["C_ANAME"].Visible = false;
            this.DGV3.Columns["P_NAME"].Visible = false;
            this.DGV3.Columns["FOB_DATE"].Visible = false;
            this.DGV3.Columns["BQTY"].Visible = false;
            this.DGV3.Columns["MEMO08"].Visible = false;
            this.DGV3.Columns["MEMO11"].Visible = false;
            this.DGV3.Columns["MEMO12"].Visible = false;
            this.DGV3.Columns["MEMO13"].Visible = false;
            this.DGV3.Columns["MEMO13"].Visible = false;
            this.DGV3.Columns["CLRCARD"].Visible = false;
            this.DGV3.Columns["MODEL_C"].Visible = false;
            this.DGV3.Columns["COLOR_C"].Visible = false;
            this.DGV3.Columns["MEMO14"].Visible = false;
            this.DGV3.Columns["MEMO15"].Visible = false;
            this.DGV3.Columns["MEMO16"].Visible = false;
            this.DGV3.Columns["PG_NO"].Visible = false;
            this.DGV3.Columns["M_TOT"].Visible = false;
            this.DGV3.Columns["USR_NAME"].Visible = false;
            this.DGV3.Columns["MEMO19"].Visible = false;
            this.DGV3.Columns["P_NAME2"].Visible = false;
        }
        public static string Where = string.Empty;
        public static int IndexRow;
        private void SearchData()
        {
            try
            {
                Where = string.Empty;
                string SQL = "SELECT TOP 200 dbo.FormatString2(WS_DATE) AS WS_DATE, WS_NO, OR_NO, C_NO,C_NAME,C_ANAME, P_NAME, FOB_DATE, BQTY, MEMO08, MEMO11, MEMO12, MEMO13, CLRCARD, MODEL_C,P_NAME1, P_NAME2, COLOR_C, MEMO14, MEMO15, MEMO16, PG_NO, M_TOT, USR_NAME, MEMO19 FROM PRDMK1 WHERE 1=1 ";
                if (!string.IsNullOrEmpty(textBox1.Text)) Where = Where + " AND WS_NO LIKE '%" + textBox1.Text + "%'";
                if (!string.IsNullOrEmpty(textBox2.Text)) Where = Where + " AND C_NO LIKE '%" + textBox2.Text + "%'";
                if (!string.IsNullOrEmpty(textBox3.Text)) Where = Where + " AND C_NAME LIKE '%" + textBox3.Text + "%'";
                if(txtDate1.MaskCompleted) Where = Where + " AND C_NAME LIKE '%" +txtDate1.Text.Replace("/", string.Empty).Trim()+ "%'";
                if (!string.IsNullOrEmpty(textBox5.Text)) Where = Where + " AND OR_NO LIKE '%" + textBox5.Text + "%'";
                SQL = SQL + Where + " ORDER BY WS_DATE DESC";
                DataTable dt = con.readdata(SQL);
                source.DataSource = dt;
                DGV3.DataSource = source;
                datagribviewHide();
                con.DGV(DGV3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Searching1()
        {
            string str2 = "SELECT TOP 200 dbo.FormatString2(WS_DATE) AS WS_DATE, WS_NO, OR_NO, C_NO,C_NAME,C_ANAME, P_NAME, FOB_DATE, BQTY, MEMO08, MEMO11, MEMO12, MEMO13, CLRCARD, MODEL_C,P_NAME1, P_NAME2, COLOR_C, MEMO14, MEMO15, MEMO16, PG_NO, M_TOT, USR_NAME, MEMO19 FROM PRDMK1 WHERE 1=1";
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = txtDate1.Text.Replace("/", string.Empty).Trim();
            //MessageBox.Show(t4);
            string t5 = textBox5.Text;

            if (t1 == "" && t2 == "" && t3 == "" && t4 == "" && t5 == "")
            {
                where = "";
                str2 = str2 + "";
            }    
            
            if (t1 != "")
            {
                where = where + " AND WS_NO LIKE '%" + t1 + "%'";
                str2 = str2 + " AND WS_NO LIKE '%" + t1 + "%' ";
            }    
               
            if (t2 != "")
            {
                where = where + " AND C_NO LIKE '%" + t2 + "%'";
                str2 = str2 + " AND C_NO LIKE '%" + t2 + "%' ";
            }    
               
            if (t3 != "")
            {
                where = where + " AND C_NAME LIKE '%" + t3 + "%'";
                str2 = str2 + " AND C_NAME LIKE '%" + t3 + "%' ";
            }    
            if (t4 != "")
            {
                where = where + " AND WS_DATE LIKE '" + t4 + "%'";
                str2 = str2 + " AND WS_DATE LIKE '" + t4 + "%'";
            }  
            if (t5 != "")
            {
                where = where + " AND OR_NO LIKE '%" + t5 + "%'";
                str2 = str2 + " AND OR_NO LIKE '%" + t5 + "%'";
            }    
            str2 = str2 + " ORDER BY WS_DATE DESC";

            DataTable dt = con.readdata(str2);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
               
            }
            source.DataSource = dt;
            DGV3.DataSource = source;
            datagribviewHide();
            con.DGV(DGV3);
           
        }

        private void frm3DF5_Load(object sender, EventArgs e)
        {
            LoadDGV3();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DGV3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm3D.Where = Where;
            frm3D.Share_WSNO = DGV3.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        #region Event Form
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                SearchData();
        }
        private void txtDate1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }
        private void txtDate1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            txtDate1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }
        #endregion

        private void DGV3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm3D.Where = Where;
            frm3D.Share_WSNO = DGV3.CurrentRow.Cells["WS_NO"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(frm3D.Share_WSNO))
            {
                MessageBox.Show("Please select Data", "Message");
            }
            else
                this.Close();
        }
    }
}
