using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Collections.Generic;

namespace WTERP
{
    public partial class FormSearchProgram : Form
    {
        DataProvider con = new DataProvider();
        public FormSearchProgram()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        private void FormSearchProgram_Load(object sender, EventArgs e)
        {
            Load_Data();
            con.DGV(dataProgram);
        }
        public void Load_Data()
        {
            string sql = "select WSPROGRAM, WSNAME, REPORT from PROGRAM Where WSPROGRAM !='' ";
            datatable = new DataTable();
            datatable = con.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataProgram.DataSource = bindingsource;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            string sql = "select WSPROGRAM, WSNAME, REPORT from PROGRAM WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND WSPROGRAM LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND WSNAME LIKE N'%" + tb2.Text + "%'";
            datatable = new DataTable();
            datatable = con.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataProgram.DataSource = bindingsource;
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb1.Focus();
            }
        }
        public class DT 
        {
            public static List<string> LV = new List<string>();
            public static List<string> LV1 = new List<string>();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            DT.LV.Clear();
            DT.LV1.Clear();
          for (int i = 0; i <= dataProgram.Rows.Count - 1; i++)
          {

                  bool checkedCell = Convert.ToBoolean(dataProgram.Rows[i].Cells[0].Value);
                  if (checkedCell == true)
                  {
                      DT.LV.Add(dataProgram.Rows[i].Cells[1].Value.ToString());
                      DT.LV1.Add(dataProgram.Rows[i].Cells[2].Value.ToString());
                  }       
          }
            this.Hide();
            this.Close();
        }
    }
}
