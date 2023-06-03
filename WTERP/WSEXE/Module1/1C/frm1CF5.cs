using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WTERP
{
    public partial class Form1CF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1CF5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        BindingSource bindingsource = new BindingSource();
        DataTable datatable = new DataTable();

        private void Form1CF5timkiemdulieusanpham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {

            datatable = Form1C.getDataTable1C.data;
            bindingsource.DataSource = datatable;
            Data1CF5.DataSource = bindingsource;
            conn.DGV1(Data1CF5);

        }
        public class ID
        {
            public static string I1;
            public static string I2;
            public static string I3;
            public static string I4;
            public static string I5;

            public static string I6;
            public static string I7;
            public static string I8;
            public static string I9;
            public static string I10;

            public static string I11;
            //public static string tx12;
            public static string I13;
            public static string I14;
            public static string I15;

            public static string I16;
            public static string I17;
            public static string I18;
            //public static string tx19;
            public static string I20;

            public static string I21;
            public static string I22;
            public static string I23;
            public static string I24;
            public static string I25;

            public static string I26;
            public static string I27;
            public static string I28;
            public static string I29;
            public static string I30;

            public static string I31;
            public static string I32;
            public static string I33;
            public static string I34;
            public static string I35;

            public static string I36;
            public static string I37;
            public static string I38;
            public static string I39;
            public static string I40;

            public static string I41;
            public static string I42;

            public static DataTable datatable1CF5;
            public static int index;

        }
        public class DL
        {
            public static string T1;
        }
        public class GUI_FORM1E
        {
            public static string t1;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            //table
            ID.datatable1CF5 = datatable;
            this.Close();
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            Search();
        }

        public class GUI_FORM2D
        {
            public static string T2;
        }
        private void btok_Click(object sender, EventArgs e)
        {
            ID.I1 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I2 = Data1CF5.CurrentRow.Cells["K_NAME"].Value.ToString();
            ID.I3 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            ID.I4 = Data1CF5.CurrentRow.Cells["P_NAME"].Value.ToString();
            ID.I5 = Data1CF5.CurrentRow.Cells["P_NAME1"].Value.ToString();

            ID.I6 = Data1CF5.CurrentRow.Cells["P_NAME3"].Value.ToString();
            ID.I7 = Data1CF5.CurrentRow.Cells["P_NAME2"].Value.ToString();
            ID.I8 = Data1CF5.CurrentRow.Cells["UNIT"].Value.ToString();
            ID.I9 = Data1CF5.CurrentRow.Cells["TRANS"].Value.ToString();
            ID.I10 = Data1CF5.CurrentRow.Cells["BUNIT"].Value.ToString();

            ID.I11 = Data1CF5.CurrentRow.Cells["CUNIT"].Value.ToString();
            //ID.I12 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I13 = Data1CF5.CurrentRow.Cells["PRICE"].Value.ToString();
            ID.I14 = Data1CF5.CurrentRow.Cells["P_WEG"].Value.ToString();
            ID.I15 = Data1CF5.CurrentRow.Cells["QTYKG"].Value.ToString();

            ID.I16 = Data1CF5.CurrentRow.Cells["QTYSTORE"].Value.ToString();
            ID.I17 = Data1CF5.CurrentRow.Cells["QTYPIC"].Value.ToString();
            ID.I18 = Data1CF5.CurrentRow.Cells["BASEDATE"].Value.ToString();
            //ID.I19 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I20 = Data1CF5.CurrentRow.Cells["QTYFT"].Value.ToString();

            ID.I21 = Data1CF5.CurrentRow.Cells["INDATE"].Value.ToString();
            ID.I22 = Data1CF5.CurrentRow.Cells["QTYORD"].Value.ToString();
            ID.I23 = Data1CF5.CurrentRow.Cells["OUTDATE"].Value.ToString();
            ID.I24 = Data1CF5.CurrentRow.Cells["QTYBAT"].Value.ToString();
            //ID.I19 = Data1CF5.CurrentRow.Cells[""].Value.ToString();
            ID.I25 = Data1CF5.CurrentRow.Cells["QTYPROD"].Value.ToString();

            ID.I26 = Data1CF5.CurrentRow.Cells["MEMO1"].Value.ToString();
            ID.I27 = Data1CF5.CurrentRow.Cells["MEMO2"].Value.ToString();
            ID.I28 = Data1CF5.CurrentRow.Cells["MEMO3"].Value.ToString();
            ID.I29 = Data1CF5.CurrentRow.Cells["MEMO4"].Value.ToString();

            ID.I40 = Data1CF5.CurrentRow.Cells["COST"].Value.ToString();
            ID.I41 = Data1CF5.CurrentRow.Cells["COST_NEW"].Value.ToString();
            ID.I42 = Data1CF5.CurrentRow.Cells["COST_AVG"].Value.ToString();

            ID.I30 = Data1CF5.CurrentRow.Cells["PM_DATE"].Value.ToString();
            ID.I31 = Data1CF5.CurrentRow.Cells["TN_DATE"].Value.ToString();
            ID.I32 = Data1CF5.CurrentRow.Cells["DY_DATE"].Value.ToString();
            ID.I33 = Data1CF5.CurrentRow.Cells["GD_DATE"].Value.ToString();
            ID.I34 = Data1CF5.CurrentRow.Cells["TN_DATE1"].Value.ToString();
            ID.I35 = Data1CF5.CurrentRow.Cells["DY_DATE1"].Value.ToString();

            ID.I36 = Data1CF5.CurrentRow.Cells["GD_DATE1"].Value.ToString();
            ID.I37 = Data1CF5.CurrentRow.Cells["PT_DATE"].Value.ToString();
            ID.I38 = Data1CF5.CurrentRow.Cells["PT_FT"].Value.ToString();
            ID.I39 = Data1CF5.CurrentRow.Cells["PK_DATE"].Value.ToString();
            //table
            ID.datatable1CF5 = datatable;
            ID.index = bindingsource.Position;
            DL.T1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();

            GUI_FORM1E.t1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            GUI_FORM2D.T2 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }

        private void Data1CF5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID.I1 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I2 = Data1CF5.CurrentRow.Cells["K_NAME"].Value.ToString();
            ID.I3 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            ID.I4 = Data1CF5.CurrentRow.Cells["P_NAME"].Value.ToString();
            ID.I5 = Data1CF5.CurrentRow.Cells["P_NAME1"].Value.ToString();

            ID.I6 = Data1CF5.CurrentRow.Cells["P_NAME3"].Value.ToString();
            ID.I7 = Data1CF5.CurrentRow.Cells["P_NAME2"].Value.ToString();
            ID.I8 = Data1CF5.CurrentRow.Cells["UNIT"].Value.ToString();
            ID.I9 = Data1CF5.CurrentRow.Cells["TRANS"].Value.ToString();
            ID.I10 = Data1CF5.CurrentRow.Cells["BUNIT"].Value.ToString();

            ID.I11 = Data1CF5.CurrentRow.Cells["CUNIT"].Value.ToString();
            //ID.I12 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I13 = Data1CF5.CurrentRow.Cells["PRICE"].Value.ToString();
            ID.I14 = Data1CF5.CurrentRow.Cells["P_WEG"].Value.ToString();
            ID.I15 = Data1CF5.CurrentRow.Cells["QTYKG"].Value.ToString();

            ID.I16 = Data1CF5.CurrentRow.Cells["QTYSTORE"].Value.ToString();
            ID.I17 = Data1CF5.CurrentRow.Cells["QTYPIC"].Value.ToString();
            ID.I18 = Data1CF5.CurrentRow.Cells["BASEDATE"].Value.ToString();
            //ID.I19 = Data1CF5.CurrentRow.Cells["K_NO"].Value.ToString();
            ID.I20 = Data1CF5.CurrentRow.Cells["QTYFT"].Value.ToString();

            ID.I21 = Data1CF5.CurrentRow.Cells["INDATE"].Value.ToString();
            ID.I22 = Data1CF5.CurrentRow.Cells["QTYORD"].Value.ToString();
            ID.I23 = Data1CF5.CurrentRow.Cells["OUTDATE"].Value.ToString();
            ID.I24 = Data1CF5.CurrentRow.Cells["QTYBAT"].Value.ToString();
            //ID.I19 = Data1CF5.CurrentRow.Cells[""].Value.ToString();
            ID.I25 = Data1CF5.CurrentRow.Cells["QTYPROD"].Value.ToString();

            ID.I26 = Data1CF5.CurrentRow.Cells["MEMO1"].Value.ToString();
            ID.I27 = Data1CF5.CurrentRow.Cells["MEMO2"].Value.ToString();
            ID.I28 = Data1CF5.CurrentRow.Cells["MEMO3"].Value.ToString();
            ID.I29 = Data1CF5.CurrentRow.Cells["MEMO4"].Value.ToString();

            ID.I40 = Data1CF5.CurrentRow.Cells["COST"].Value.ToString();
            ID.I41 = Data1CF5.CurrentRow.Cells["COST_NEW"].Value.ToString();
            ID.I42 = Data1CF5.CurrentRow.Cells["COST_AVG"].Value.ToString();

            ID.I30 = Data1CF5.CurrentRow.Cells["PM_DATE"].Value.ToString();
            ID.I31 = Data1CF5.CurrentRow.Cells["TN_DATE"].Value.ToString();
            ID.I32 = Data1CF5.CurrentRow.Cells["DY_DATE"].Value.ToString();
            ID.I33 = Data1CF5.CurrentRow.Cells["GD_DATE"].Value.ToString();
            ID.I34 = Data1CF5.CurrentRow.Cells["TN_DATE1"].Value.ToString();
            ID.I35 = Data1CF5.CurrentRow.Cells["DY_DATE1"].Value.ToString();

            ID.I36 = Data1CF5.CurrentRow.Cells["GD_DATE1"].Value.ToString();
            ID.I37 = Data1CF5.CurrentRow.Cells["PT_DATE"].Value.ToString();
            ID.I38 = Data1CF5.CurrentRow.Cells["PT_FT"].Value.ToString();
            ID.I39 = Data1CF5.CurrentRow.Cells["PK_DATE"].Value.ToString();
            //table
            ID.datatable1CF5 = datatable;
            ID.index = bindingsource.Position;
            DL.T1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();

            GUI_FORM1E.t1 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();
            GUI_FORM2D.T2 = Data1CF5.CurrentRow.Cells["P_NO"].Value.ToString();

            this.Hide();
            this.Close();
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
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb1.Focus();
            }
        }
        public void Search()
        {

            string sql;
            sql = "Select PROD.K_NO, KIND.K_NAME, P_NO, P_NAME, P_NAME1, P_NAME3, P_NAME2, UNIT, TRANS, BUNIT, CUNIT, PRICE, P_WEG, QTYKG, QTYSTORE, QTYPIC, BASEDATE, QTYFT, INDATE, QTYORD, OUTDATE, QTYBAT," +
                " QTYPROD, MEMO1, MEMO2, MEMO3, MEMO4, COST, COST_NEW, COST_AVG, PM_DATE, TN_DATE, DY_DATE, GD_DATE, TN_DATE1, DY_DATE1, GD_DATE1, PT_DATE, PT_FT, PK_DATE,PROD.USR_NAME from PROD full outer join KIND on PROD.K_NO = KIND.K_NO WHERE 1=1";

            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND P_NO LIKE N'" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NAME3 LIKE N'" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND P_NAME LIKE N'" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME1  LIKE N'" + tb4.Text + "%'";
            datatable = conn.readdata(sql);
            bindingsource.DataSource = datatable;
            Data1CF5.DataSource = bindingsource;
        }
    }
}
