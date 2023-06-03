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
    public partial class frm3E_Products : Form
    {
        DataProvider conn = new DataProvider();
        BindingSource source = new BindingSource();
        public frm3E_Products()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class getData3E
        {
            public static string getOR_NO;
            public static string getK_NO;
            public static string getC_NO;
            public static string Get_NR;
            public static string getDate;
            public static BindingSource data;
            public static int index;
        }
        void LoadDGV3()
        {
            string SQL3 = "SELECT NR,P_NO,OR_NO,COLOR_C,P_NAME_E,THICK,QTY,WS_DATE,K_NO,C_NO FROM ORDB WHERE K_NO IN ('3','4')";
            if (!string.IsNullOrEmpty(Form3E.GUI.getC_NO))
            {
                SQL3 = SQL3 + " AND C_NO = '" + Form3E.GUI.getC_NO + "'";
            }    
            SQL3 = SQL3 + "  ORDER BY WS_DATE DESC";
            DataTable dt3 = conn.readdata(SQL3);
            source.DataSource = dt3;
            DGV3.DataSource = source;
            this.DGV3.Columns["WS_DATE"].Visible = false;
            conn.DGV(DGV3);
        }
        void Search()
        {
            string a = "";
            if (conn.Check_MaskedText(textBox1) == true)
            {
                a = conn.formatstr1(textBox1.Text);
            }   
            string SQL4 = "SELECT NR,P_NO,OR_NO,COLOR_C,P_NAME_E,THICK,QTY,WS_DATE,K_NO,C_NO FROM ORDB WHERE 1=1";
            if (textBox1.Text == string.Empty && textBox2.Text == string.Empty && textBox3.Text == string.Empty && a == string.Empty && textBox5.Text == string.Empty && textBox6.Text == string.Empty && textBox7.Text == string.Empty)
                SQL4 = SQL4 + "";
            if (a != string.Empty)
                SQL4 = SQL4 + " AND WS_DATE LIKE '%"+ a + "%'";
            if (textBox2.Text != string.Empty)
                SQL4 = SQL4 + " AND OR_NO LIKE '%" + textBox2.Text + "%' ";
            if (textBox3.Text != string.Empty)
                SQL4 = SQL4 + " AND BRAND LIKE '%" + textBox3.Text + "%' ";
            if (textBox4.Text != "")
                SQL4 = SQL4 + " AND P_NAME_C LIKE '%" + textBox4.Text + "%' ";
            if (textBox5.Text != string.Empty)
                SQL4 = SQL4 + " AND P_NAME_E LIKE '%" + textBox5.Text + "%' ";
            if (textBox6.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_C LIKE '%" + textBox6.Text + "%' ";
            if (textBox7.Text != string.Empty)
                SQL4 = SQL4 + " AND COLOR_E LIKE '%" + textBox7.Text + "%' ";
            if (!string.IsNullOrEmpty(Form3E.GUI.getC_NO))
            {
                SQL4 = SQL4 + " AND C_NO = '" + Form3E.GUI.getC_NO + "'";
            }
            SQL4 = SQL4 + " AND K_NO IN('3','4') ORDER BY WS_DATE DESC";
            DataTable dt4 = conn.readdata(SQL4);
            source.DataSource = dt4;
            DGV3.DataSource = source;
            this.DGV3.Columns["WS_DATE"].Visible = false;
            conn.DGV(DGV3);
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
            getData3E.getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
            getData3E.getC_NO = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
            getData3E.Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
            getData3E.getK_NO = DGV3.CurrentRow.Cells["K_NO"].Value.ToString();
            getData3E.getDate = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
            getData3E.data = source;
            getData3E.index = DGV3.CurrentRow.Index;
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DGV3.RowCount > 0)
            {
                getData3E.getOR_NO = DGV3.CurrentRow.Cells["OR_NO"].Value.ToString();
                getData3E.getC_NO = DGV3.CurrentRow.Cells["C_NO"].Value.ToString();
                getData3E.Get_NR = DGV3.CurrentRow.Cells["NR"].Value.ToString();
                getData3E.getK_NO = DGV3.CurrentRow.Cells["K_NO"].Value.ToString();
                getData3E.getDate = DGV3.CurrentRow.Cells["WS_DATE"].Value.ToString();
                getData3E.data = source;
                getData3E.index = DGV3.CurrentRow.Index;
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

        private void frm3E_Products_Load(object sender, EventArgs e)
        {
            LoadDGV3();
            
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            textBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
