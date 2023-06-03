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
    public partial class frm3F_Products : Form
    {
        DataProvider conn = new DataProvider();
        public frm3F_Products()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public static string getOR_NO;
        public static string Get_NR;
        public static string Get_C_NO;
        public static string Get_C_NAME_C;
        public static string Get_P_NAME;
        public static string Get_THICK;
        public static string Get_QTY;
        public static string Get_T_NAME;
        public static string Get_COLOR_C;
        public static string Get_WS_DATE;
        public static string Get_WS_DATE1;

        string Get_CNO = frm3F.MaKH;
        private void frm3D_Product_Load(object sender, EventArgs e)
        {
            LoadDGV3();
        }
        void LoadDGV3()
        {
            string SQL3;
            if (!string.IsNullOrEmpty(Get_CNO))
            {
                SQL3 = "SELECT TOP 500 OR_NO,COLOR_C,COLOR_E,P_NAME_C,P_NAME_E, THICK,QTY,K_NO,WS_DATE,NR,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO,T_NAME,WS_DATE1 FROM ORDB WHERE C_NO = '" + Get_CNO + "' ORDER BY WS_DATE DESC";
            }
            else
            {
                SQL3 = "SELECT TOP 500 OR_NO,COLOR_C,COLOR_E,P_NAME_C,P_NAME_E, THICK,QTY,K_NO,WS_DATE,NR,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO,T_NAME,WS_DATE1 FROM ORDB ORDER BY WS_DATE DESC";
            }
            DataTable dt3 = conn.readdata(SQL3);
            foreach (DataRow dr in dt3.Rows)
                dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
            conn.FormatDGV(DGV3, dt3);
        }
        void Search()
        {
            string a = "";
            if (conn.Check_MaskedText(textBox1) == true)
            {
                a = conn.formatstr2(textBox1.Text);
            }   
            string SQL4 = "SELECT OR_NO,COLOR_C,COLOR_E,P_NAME_C,P_NAME_E, THICK,QTY,K_NO,WS_DATE,NR,C_NO,C_NAME_C,C_NAME_E,BRAND,MODEL_C,MODEL_E,P_NO,T_NAME,WS_DATE1 FROM ORDB";
            if (textBox1.Text == string.Empty && textBox2.Text == string.Empty && textBox3.Text == string.Empty && a == string.Empty && textBox5.Text == string.Empty && textBox6.Text == string.Empty && textBox7.Text == string.Empty)
                SQL4 = SQL4 + "";
            if (textBox1.Text != string.Empty)
                SQL4 = SQL4 + " AND WS_DATE LIKE '%"+ textBox1.Text + "%' ";
            if (textBox2.Text != string.Empty)
                SQL4 = SQL4 + " AND OR_NO LIKE '%" + textBox2.Text + "%' ";
            if (textBox3.Text != string.Empty)
                SQL4 = SQL4 + " AND BRAND LIKE '%" + textBox3.Text + "%' ";
            if (a != "")
                SQL4 = SQL4 + " AND P_NAME_C LIKE '%" + a + "%' ";
            if (textBox5.Text != string.Empty)
                SQL4 = SQL4 + " AND P_NAME_E LIKE '%" + textBox5.Text + "%' ";
            if (textBox6.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_C LIKE '%" + textBox6.Text + "%' ";
            if (textBox7.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_E LIKE '%" + textBox7.Text + "%' ";

            SQL4 = SQL4 + " ORDER BY WS_DATE DESC";
            DataTable dt4 = conn.readdata(SQL4);
            if(dt4 != null)
            {
                foreach (DataRow dr in dt4.Rows)
                    dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
                conn.FormatDGV(DGV3, dt4);
            }
        }

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

        private void DGV3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
            Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
            Get_C_NO = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
            Get_C_NAME_C = DGV3.CurrentRow.Cells["C_NAME_C"].Value.ToString();
            Get_P_NAME = DGV3.CurrentRow.Cells["C_NAME_E"].Value.ToString() + DGV3.CurrentRow.Cells["P_NAME_E"].Value.ToString();
            Get_THICK = DGV3.CurrentRow.Cells["THICK"].Value.ToString();
            Get_QTY = DGV3.CurrentRow.Cells["QTY"].Value.ToString();
            Get_T_NAME = DGV3.CurrentRow.Cells["T_NAME"].Value.ToString();
            Get_COLOR_C = DGV3.CurrentRow.Cells["COLOR_C"].Value.ToString();
           Get_WS_DATE1 = DGV3.CurrentRow.Cells["WS_DATE1"].Value.ToString();
                Get_WS_DATE = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DGV3.RowCount > 0)
            {
                getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
                Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
                Get_C_NO = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
                Get_C_NAME_C = DGV3.CurrentRow.Cells["C_NAME_C"].Value.ToString();
                Get_P_NAME = DGV3.CurrentRow.Cells["C_NAME_E"].Value.ToString() + DGV3.CurrentRow.Cells["P_NAME_E"].Value.ToString();
                Get_THICK = DGV3.CurrentRow.Cells["THICK"].Value.ToString();
                Get_QTY = DGV3.CurrentRow.Cells["QTY"].Value.ToString();
                Get_T_NAME = DGV3.CurrentRow.Cells["T_NAME"].Value.ToString();
                Get_COLOR_C = DGV3.CurrentRow.Cells["COLOR_C"].Value.ToString();
                Get_WS_DATE1 = DGV3.CurrentRow.Cells["WS_DATE1"].Value.ToString();
                Get_WS_DATE = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy công lệnh, Vui lòng nhập từ khóa tìm kiếm!\n Kết thúc bấm nút THOÁT để kết thúc tìm kiếm", "thông Báo");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            textBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
