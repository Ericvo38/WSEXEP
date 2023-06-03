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
using System.Net;
using System.Net.Sockets;

namespace WTERP
{
    public partial class Form8C : Form
    {
        public Form8C()
        {
            this.ShowInTaskbar = false;
            dataProvider.choose_languege();
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;

        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        DataProvider dataProvider = new DataProvider();
        private void Form8C_Load(object sender, EventArgs e)
        {
            //data phân quyền
            dataProvider.CheckLoad(menuStrip1);
            Load_Data();
            Show_Data();

            tb1.Enabled = false;
            tb2.Enabled = false;

            bt.Text = "NÚT DUYỆT";
            btok.Hide();
            btdong.Hide();
            dataProvider.DGV(dataF8C);

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }
        public void Load_Data()
        {
            loadinfo();
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = " SELECT M_NO, M_NAME FROM MEMO1";
            datatable = new DataTable();
            datatable.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataF8C.DataSource = bindingsource;
        }
        void loadinfo()
        {
            lbUserName.Text = dataProvider.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        public void Show_Data()
        {
            tb1.Text = dataF8C.Rows[0].Cells["M_NO"].Value.ToString();
            tb2.Text = dataF8C.Rows[0].Cells["M_NAME"].Value.ToString();
        }
        public void Show_Data_click()
        {
            this.tb1.Text = dataF8C.Rows[dataF8C.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataF8C.Rows[dataF8C.CurrentRow.Index].Cells[1].Value.ToString();
        }
        private void dataF8C_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb1.Text = dataF8C.Rows[dataF8C.CurrentRow.Index].Cells[0].Value.ToString();
            this.tb2.Text = dataF8C.Rows[dataF8C.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void btdau_Click(object sender, EventArgs e)
        {
            dataF8C.ClearSelection();
            dataF8C.Rows[0].Selected = true;
            bindingsource.DataSource = datatable;
            dataF8C.DataSource = bindingsource;
            bindingsource.MoveFirst();

            Show_Data_click();

            btdau.Enabled = false;
            bttruoc.Enabled = false;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void bttruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataF8C.CurrentRow.Index;
                if (dataF8C.Rows.Count > IndexNow)
                {
                    dataF8C.Rows[IndexNow - 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataF8C.DataSource = bindingsource;
                bindingsource.MovePrevious();
            }
            catch (Exception)
            {

            }

            Show_Data_click();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btsau_Click(object sender, EventArgs e)
        {
            try
            {
                int IndexNow = dataF8C.CurrentRow.Index;
                if (dataF8C.Rows.Count > IndexNow)
                {
                    dataF8C.Rows[IndexNow + 1].Selected = true;
                }

                bindingsource.DataSource = datatable;
                dataF8C.DataSource = bindingsource;
                bindingsource.MoveNext();
            }
            catch (Exception)
            {

            }

            Show_Data_click();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = true;
            btketthuc.Enabled = true;
        }

        private void btketthuc_Click(object sender, EventArgs e)
        {
            dataF8C.ClearSelection();
            int so = dataF8C.Rows.Count - 1;
            dataF8C.Rows[so - 1].Selected = true;
            bindingsource.DataSource = datatable;
            dataF8C.DataSource = bindingsource;
            bindingsource.MoveLast();

            Show_Data_click();

            btdau.Enabled = true;
            bttruoc.Enabled = true;
            btsau.Enabled = false;
            btketthuc.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnTimeNow.Text = CN.getTimeNow();
            btndateNow.Text = CN.getDateNow();
        }

        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
