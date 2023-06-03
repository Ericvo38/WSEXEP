using LibraryCalender;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WTERP.WSEXE;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm3Q : Form
    {
        // DataGridViewGrouper grouper;
        DataProvider data = new DataProvider();
        public static double HANG_SO = 0.0929;
        public frm3Q()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        private void load()
        {
            con.CheckLoad(menuStrip1);
            loadinfo();
            loadfirst();
            con.DGV(DGV1);
        }
        private void loadfirst()
        {
            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,DONG NAI PROVINCE,VIET NAM.";
            txtFr.Text = lbUserName.Text;
            //textBox3.Text = lbUserName.Text;

            this.DGV1.Columns["V_TheTich"].Visible = false;
            this.DGV1.Columns["CNO_STT"].Visible = false;
            this.DGV1.Columns["lstPackage"].Visible = false;
            this.DGV1.Columns["Number"].Visible = false;

            string sql = "SELECT MAX(INVOICE) as MAX_INVOICE FROM tblHistoryInvoice";
            DataTable dataTable = new DataTable();
            dataTable = con.readdata(sql);
            // lblInvoice.Text = dataTable.Rows[0]["MAX_INVOICE"].ToString();
        }

        void loadinfo()
        {
            lbUserName.Text = con.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                data.CreateMenuStrip(e, DGV1, Mouse_Click);
            }
        }
        private void Mouse_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    AddItemToDataDrid();
                    break;
                case "Delele":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            int NR = 1;
                            for (int i = 0; i < DGV1.Rows.Count; i++)
                            {
                                DGV1["NR", i].Value = NR.ToString("D" + 3);
                                NR++;
                            }
                        }
                    }
                    break;
            }
        }

        private void AddItemToDataDrid()
        {
            frmSearchCARB_Packing frm = new frmSearchCARB_Packing();
            frm.ShowDialog();
            if(frmSearchCARB_Packing.Listitems.Count > 0)
            {
                DataTable dataTable = (DataTable)DGV1.DataSource;
                foreach (var item in frmSearchCARB_Packing.Listitems)
                {
                    string[] arrListStr = item.OR_NO.Split('/');
                    for (int i = 0; i < int.Parse(item.Number); i++)
                    {
                        dataTable.Rows.Add(arrListStr[0], arrListStr[1], item.COLOR + item.P_NAME1,item.P_NAME3,"SF",0,0,0,0,1);
                    }
                }
            }
        }
    }
}
