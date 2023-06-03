using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form1AF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1AF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = conn.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
            //btndateNow.Text = conn.getDateNow(); // get DateNow
        }
        private void Form1AF5timkiemkhachhang_Load(object sender, EventArgs e)
        {

            loaddata_Form1AF5timkiemkhachhang();
            getInfo();
        }

        public class DI
        {
            public static string tx1_t1;
            public static string tx2_t1;

            public static string tx1_t2;
            public static string tx2_t2;

            public static string tx1_t3;
            public static string tx2_t3;

            public static string tx1_t4;
            public static string tx2_t4;

            public static string tx1_t5;
            public static string tx2_t5;

            public static string tx1_t6;

            public static string tx1_t7;
            public static string tx2_t7;

            public static BindingSource data;

        }
        public class DL
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;
            public static string t5;

            public static string t6;
            public static string t7;
            public static string t8;
            public static string t9;
            public static string t10;

            public static string t11;
            public static string t12;
            public static string t13;
            public static string t14;
            public static string t15;

            public static string t16;
            public static string t17;
            public static string t18;
            public static string t20;

            public static string t21;
            public static string t22;
            public static string t23;
            public static string t24;
            public static string t25;

            public static string t26;
            public static string t27;
            public static string t28;
            public static string t29;
            public static string c1;
            public static string t30;

            public static string t31;
            public static string t32;
            public static string t33;
            public static string t34;
            public static string t35;

            public static string t36;
            public static string t37;
            public static string t38;
            public static string t39;
            public static string t40;

            public static string t41;
            public static string t42;
            public static string t43;
            public static string t44;
            public static string t45;

            public static string t46;
            public static string t47;
            public static string t48;
            public static string t49;
            public static string t50;

            public static string t51;
            public static string t52;
            public static string t53;

            public static int index;

        }
        public void loaddata_Form1AF5timkiemkhachhang()
        {

            //con = new SqlConnection(st); // khoi tao co connection
            //con.Open();
            //cm = con.CreateCommand();
            //cm.CommandText = "select C_NO, C_NO1, C_NAME, C_ANAME, C_NAME_E, EMAIL, SPEAK, TEL1, FAX, ADR1, C_NAME1, C_ANAME1, C_NAME1_E, EMAIL1, SPEAK1, TEL2, FAX1, ADR2, C_NAME2, C_ANAME2, C_NAME2_E, EMAIL2, SPEAK2, TEL3, FAX2, ADR3, PAY_CON, RCV_DATE, DEFA_MONEY, S_NO, ACCOUNT, PAY_PLACE, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, " +
            //    "RNG01, FT01, RNG02, FT02, RNG03, FT03, RNG04, FT04, RNG05, FT05, ORDOUT, CAROUT, CTY_NO, CTY_NAME, BLIVE  from CUST order by C_NO DESC";
            //// co the su dung cm.ExecuteNonQuery();
            //datatable = new DataTable();
            //datatable.Load(cm.ExecuteReader());
            //// truyen ad vao table
            //con.Close();
            //bindingsource = new BindingSource();
            //bindingsource.DataSource = datatable;
            bindingsource = new BindingSource();
            bindingsource.DataSource = DI.data;
            datakh.DataSource = bindingsource;
            datakh.ClearSelection();
            //datakh.Rows[DL.index].Selected = true;
            //datakh.FirstDisplayedScrollingRowIndex = datakh.SelectedRows[DL.index].Index;
            datakh.CurrentCell = datakh.Rows[DL.index].Cells[0];
            datakh.MyDGV();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Search();

        }
        private void tbok_Click(object sender, EventArgs e)
        {
            DL.t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DL.t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO1"].Value.ToString();
            DL.t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME"].Value.ToString();
            DL.t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME"].Value.ToString();
            DL.t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME_E"].Value.ToString();

            DL.t6 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL"].Value.ToString();
            DL.t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK"].Value.ToString();
            DL.t8 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL1"].Value.ToString();
            DL.t9 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX"].Value.ToString();
            DL.t10 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR1"].Value.ToString();

            DL.t11 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME1"].Value.ToString();
            DL.t12 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME1"].Value.ToString();
            DL.t13 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME1_E"].Value.ToString();
            DL.t14 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL1"].Value.ToString();
            DL.t15 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK1"].Value.ToString();

            DL.t16 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL2"].Value.ToString();
            DL.t17 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX1"].Value.ToString();
            DL.t18 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR2"].Value.ToString();
            DL.t20 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME2"].Value.ToString();
            DL.t21 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME2"].Value.ToString();

            DL.t22 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME2_E"].Value.ToString();
            DL.t23 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL2"].Value.ToString();
            DL.t24 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK2"].Value.ToString();
            DL.t25 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL3"].Value.ToString();
            DL.t26 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX2"].Value.ToString();

            DL.t27 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR3"].Value.ToString();
            DL.t28 = datakh.Rows[datakh.CurrentRow.Index].Cells["PAY_CON"].Value.ToString();
            DL.t29 = datakh.Rows[datakh.CurrentRow.Index].Cells["RCV_DATE"].Value.ToString();
            DL.c1 = datakh.Rows[datakh.CurrentRow.Index].Cells["DEFA_MONEY"].Value.ToString();
            DL.t30 = datakh.Rows[datakh.CurrentRow.Index].Cells["S_NO"].Value.ToString();


            DL.t31 = datakh.Rows[datakh.CurrentRow.Index].Cells["ACCOUNT"].Value.ToString();

            DL.t32 = datakh.Rows[datakh.CurrentRow.Index].Cells["PAY_PLACE"].Value.ToString();
            DL.t33 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO1"].Value.ToString();
            DL.t34 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO2"].Value.ToString();
            DL.t35 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO3"].Value.ToString();
            DL.t36 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO4"].Value.ToString();

            DL.t37 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO5"].Value.ToString();
            DL.t38 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG01"].Value.ToString();
            DL.t39 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT01"].Value.ToString();
            DL.t40 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG02"].Value.ToString();
            DL.t41 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT02"].Value.ToString();

            DL.t42 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG03"].Value.ToString();
            DL.t43 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT03"].Value.ToString();
            DL.t44 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG04"].Value.ToString();
            DL.t45 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT04"].Value.ToString();
            DL.t46 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG05"].Value.ToString();

            DL.t47 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT05"].Value.ToString();
            DL.t48 = datakh.Rows[datakh.CurrentRow.Index].Cells["ORDOUT"].Value.ToString();
            DL.t49 = datakh.Rows[datakh.CurrentRow.Index].Cells["CAROUT"].Value.ToString();
            DL.t50 = datakh.Rows[datakh.CurrentRow.Index].Cells["CTY_NO"].Value.ToString();
            DL.t51 = datakh.Rows[datakh.CurrentRow.Index].Cells["CTY_NAME"].Value.ToString();
            DL.t52 = datakh.Rows[datakh.CurrentRow.Index].Cells["BLIVE"].Value.ToString();

            DI.tx1_t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t6 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.data = bindingsource;
            DL.index = datakh.CurrentRow.Index;
            this.Hide();
            this.Close();

        }

        private void datakh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DL.t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO1"].Value.ToString();
            DL.t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME"].Value.ToString();
            DL.t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME"].Value.ToString();
            DL.t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME_E"].Value.ToString();

            DL.t6 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL"].Value.ToString();
            DL.t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK"].Value.ToString();
            DL.t8 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL1"].Value.ToString();
            DL.t9 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX"].Value.ToString();
            DL.t10 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR1"].Value.ToString();

            DL.t11 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME1"].Value.ToString();
            DL.t12 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME1"].Value.ToString();
            DL.t13 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME1_E"].Value.ToString();
            DL.t14 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL1"].Value.ToString();
            DL.t15 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK1"].Value.ToString();

            DL.t16 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL2"].Value.ToString();
            DL.t17 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX1"].Value.ToString();
            DL.t18 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR2"].Value.ToString();
            DL.t20 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME2"].Value.ToString();
            DL.t21 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_ANAME2"].Value.ToString();

            DL.t22 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NAME2_E"].Value.ToString();
            DL.t23 = datakh.Rows[datakh.CurrentRow.Index].Cells["EMAIL2"].Value.ToString();
            DL.t24 = datakh.Rows[datakh.CurrentRow.Index].Cells["SPEAK2"].Value.ToString();
            DL.t25 = datakh.Rows[datakh.CurrentRow.Index].Cells["TEL3"].Value.ToString();
            DL.t26 = datakh.Rows[datakh.CurrentRow.Index].Cells["FAX2"].Value.ToString();

            DL.t27 = datakh.Rows[datakh.CurrentRow.Index].Cells["ADR3"].Value.ToString();
            DL.t28 = datakh.Rows[datakh.CurrentRow.Index].Cells["PAY_CON"].Value.ToString();
            DL.t29 = datakh.Rows[datakh.CurrentRow.Index].Cells["RCV_DATE"].Value.ToString();
            DL.c1 = datakh.Rows[datakh.CurrentRow.Index].Cells["DEFA_MONEY"].Value.ToString();
            DL.t30 = datakh.Rows[datakh.CurrentRow.Index].Cells["S_NO"].Value.ToString();

            DL.t31 = datakh.Rows[datakh.CurrentRow.Index].Cells["ACCOUNT"].Value.ToString();

            DL.t32 = datakh.Rows[datakh.CurrentRow.Index].Cells["PAY_PLACE"].Value.ToString();
            DL.t33 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO1"].Value.ToString();
            DL.t34 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO2"].Value.ToString();
            DL.t35 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO3"].Value.ToString();
            DL.t36 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO4"].Value.ToString();

            DL.t37 = datakh.Rows[datakh.CurrentRow.Index].Cells["MEMO5"].Value.ToString();
            DL.t38 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG01"].Value.ToString();
            DL.t39 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT01"].Value.ToString();
            DL.t40 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG02"].Value.ToString();
            DL.t41 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT02"].Value.ToString();

            DL.t42 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG03"].Value.ToString();
            DL.t43 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT03"].Value.ToString();
            DL.t44 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG04"].Value.ToString();
            DL.t45 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT04"].Value.ToString();
            DL.t46 = datakh.Rows[datakh.CurrentRow.Index].Cells["RNG05"].Value.ToString();

            DL.t47 = datakh.Rows[datakh.CurrentRow.Index].Cells["FT05"].Value.ToString();
            DL.t48 = datakh.Rows[datakh.CurrentRow.Index].Cells["ORDOUT"].Value.ToString();
            DL.t49 = datakh.Rows[datakh.CurrentRow.Index].Cells["CAROUT"].Value.ToString();
            DL.t50 = datakh.Rows[datakh.CurrentRow.Index].Cells["CTY_NO"].Value.ToString();
            DL.t51 = datakh.Rows[datakh.CurrentRow.Index].Cells["CTY_NAME"].Value.ToString();
            DL.t52 = datakh.Rows[datakh.CurrentRow.Index].Cells["BLIVE"].Value.ToString();

            DL.t53 = datakh.Rows[datakh.CurrentRow.Index].Cells["USR_NAME"].Value.ToString();

            DI.tx1_t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t1 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t2 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t3 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t4 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t5 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t6 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.tx1_t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DI.tx2_t7 = datakh.Rows[datakh.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            DI.data = bindingsource;
            DL.index = datakh.CurrentRow.Index;
            this.Hide();
            this.Close();

        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb2.Focus();
                tb2.SelectAll();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void Search()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter();

            string sql = "select C_NO, C_NO1, C_NAME, C_ANAME, C_NAME_E, EMAIL, SPEAK, TEL1, FAX, ADR1, C_NAME1, C_ANAME1, C_NAME1_E, EMAIL1, SPEAK1, TEL2, FAX1, ADR2, C_NAME2, C_ANAME2, C_NAME2_E, " +
                "EMAIL2, SPEAK2, TEL3, FAX2, ADR3, PAY_CON, RCV_DATE, DEFA_MONEY, S_NO, ACCOUNT, PAY_PLACE, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5,RNG01, FT01, RNG02, FT02, RNG03, FT03, RNG04, FT04, RNG05, " +
                "FT05, ORDOUT, CAROUT, CTY_NO, CTY_NAME, BLIVE,USR_NAME from dbo.CUST where 1=1";
            if (tb1.Text != "")
            {
                sql = sql + " AND C_NO LIKE N'%" + tb1.Text + "%'";
            }
            if (tb2.Text != "")
            {
                sql = sql + " AND C_NAME2 LIKE N'%" + tb2.Text + "%'";
            }
            con = new SqlConnection(st); // khoi tao co connection
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = sql;
            // co the su dung cm.ExecuteNonQuery();

            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            datakh.DataSource = bindingsource;
        }
    }
}