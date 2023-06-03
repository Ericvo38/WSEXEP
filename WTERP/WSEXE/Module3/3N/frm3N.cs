using CrystalDecisions.CrystalReports.Engine;
using LibraryCalender;
using System.Collections.Generic;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static WTERP.WSEXE.Report;
using static WTERP.WSEXE.frm3O_DGV;
using COMExcel = Microsoft.Office.Interop.Excel;
using WTERP.WSEXE.ReportView;

namespace WTERP.WSEXE
{
    public partial class frm3N : Form
    {
        DataProvider conn = new DataProvider();
        DataTable data = new DataTable();
        public static double HANG_SO = 0.0929;
        string month = "";
        string day = "";
        string year = "";

        string TAX_ID = "";
        string HS_CODE = "";
        string TERM_OF = "";
        string Payment = "";
        string FAX_2 = "";

        //group
        string Buyer = "";
        string Address_Consignee = "";
        string Consignee = "";
        string Address_Buyer = "";
        //key chung
        string key_Border = "H";
        string key_Country = "";
        string date_add = "";
        bool checkTieuDe = false;
        string Title_1 = "";
        string Title_2 = "";
        public frm3N()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void frm3N_Load(object sender, EventArgs e)
        {
            conn.CheckLoad(menuStrip1);
            loadinfo();
            loadfirst();

            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;

            

            groupBox3.Visible = true;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            //group 4
            cbTachPO.Visible = false;
            cbcheckgroup.Visible = false;

            DGV1.Columns["CHECK_GROUP"].Visible = false;
            DGV1.Columns["TOTAL_GW"].Visible = false;

            Visible_DGV(DGV1, false);

            setColumn();
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void loadfirst()
        {
            txtC_NO.Focus();
            txtPhanTram.Visible = false;
            TurnOnTurnOffcbBill(false);
            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,HIEP PHUOC TOWN,NHON TRACH DISTRICT,DONG NAI PROVINCE,VIET NAM.";
            txtFr.Text = "VIET NAM";
            txtTo.Text = "INDONESIA";
            //txtFr.Text = lbUserName.Text;
            conn.DGV1(DGV1);
        }
        private void cbBillto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBillto.Checked == true)
            {
                TurnOnTurnOffcbBill(true);
                if (rdTrongNuoc.Checked == true)
                {
                    checkINVOICE(false);
                }
                else
                {
                    checkINVOICE(false);
                }    
            }
            else
            {
                TurnOnTurnOffcbBill(false);
                if (rdTrongNuoc.Checked == true)
                {
                    checkINVOICE(true);
                }
                else
                {
                    checkINVOICE(false);
                }    
            }
        }
        private void TurnOnTurnOffcbBill(bool check)
        {
            txtBillto.Visible = check;
            txtATTN_Billto.Visible = check;
            txtAddress_billto.Visible = check;
            txtTEL_Billto.Visible = check;

            label6.Visible = check;
            label12.Visible = check;
            label13.Visible = check;
            label20.Visible = check;
            
            if (rdTrongNuoc.Checked == true)
            {
                txtPhanTram.Visible = check;
            }    
        }
        private string ReturnPhanTram(string key_PT)
        {
            string key = "";
            if (!string.IsNullOrEmpty(txtPhanTram.Text))
            {
                key = txtPhanTram.Text;
            }
            else
            {
                key = "0";
            }
            return key;
         }
        public class C_NO
        {
            public static string C_NO_ID;
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;

        }
        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                if (conn.checkExists("select * from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'") == true)
                {
                    string sql = "select *,isnull(cbTieuDe,'False') as cbTieuDe_New from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'";
                    DataTable dt1 = conn.readdata(sql);
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME"].ToString();
                        txtADR.Text = dr["ADDRESS"].ToString();
                        txtTEL.Text = dr["PHONE"].ToString();
                        txtATTN.Text = dr["ATTN"].ToString();
                        txtBillto.Text = dr["BillTo"].ToString();
                        txtTEL_Billto.Text = dr["TEL"].ToString();
                        txtATTN_Billto.Text = dr["ATTN_2"].ToString();
                        txtAddress_billto.Text = dr["ADDRESS_2"].ToString();
                        txtFAX.Text = dr["FAX"].ToString();
                        TAX_ID = dr["TAXID"].ToString();
                        HS_CODE = dr["HSCODE"].ToString();
                        key_Country = dr["Country"].ToString();
                        TERM_OF = dr["TermOfDelivery"].ToString();
                        Buyer = dr["Buyer"].ToString();
                        Address_Buyer = dr["Buyer_Address"].ToString();
                        Consignee = dr["Consignee"].ToString();
                        Address_Consignee = dr["Consignee_Address"].ToString();
                        Payment = dr["Payment"].ToString();
                        FAX_2 = dr["FAX_2"].ToString();
                        if (dr["cbTieuDe_New"].ToString() == "True")
                        {
                            checkTieuDe = true;
                        }    

                    }
                }
                else
                {
                    string SQL1 = "select C_NO, C_NAME, ADR3 from CUST where C_NO = '" + txtC_NO.Text + "'";
                    DataTable dt1 = conn.readdata(SQL1);
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME"].ToString();
                        txtADR.Text = dr["ADR3"].ToString();
                        txtTEL.Text = "";
                        txtBillto.Text = "";
                        txtTEL_Billto.Text = "";
                        txtATTN_Billto.Text = "";
                        txtAddress_billto.Text = "";
                        TAX_ID = "";
                        HS_CODE = "";
                    }
                }
            }
            else
            {
                txtC_NO.Text = "";
                txtC_NAME.Text = "";
                txtADR.Text = "";
                txtTEL.Text = "";
                txtATTN.Text = "";
                txtBillto.Text = "";
                txtTEL_Billto.Text = "";
                txtATTN_Billto.Text = "";
                txtAddress_billto.Text = "";
                TAX_ID = "";
                HS_CODE = "";
            }
        }
        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                btxemtruoc.PerformClick();
            }    
            else
            {
                MessageBox.Show("Mã Khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
           
        }

        int dem = 0;
        private void ClickInsertDataGridview()
        {
            try
            {
                C_NO_ID.C_NO_ID_NUMBER = txtC_NO.Text;
                frm3O_DGV fr = new frm3O_DGV();
                fr.ShowDialog();
                if (dem == 0)
                {
                    if (DL_3O.data != null)
                    {
                        data = DL_3O.data;
                        getDataINR_LEFT_RIGHT(data);
                        Load_DGV(data);
                        dem++;

                    }
                }
                else
                {
                    if (DL_3O.data != null)
                    {
                        DataTable data1 = new DataTable();
                        data1 = DL_3O.data;
                        getDataINR_LEFT_RIGHT(data1);
                        Load_DGV2(data1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setColumn()
        {
            string sql = "SELECT OR_NO,COLOR +' '+ P_NAME1 AS COLOR,P_NAME3,BQTY,PRICE,AMOUNT,CASE WHEN REPLACE(MEMO,' ','') LIKE '%折補' OR REPLACE(MEMO,' ','') " +
                "LIKE '%預補' THEN 'True' ELSE 'False' END AS Calculated,0 as NW,0 as GW,0 as CNO,'' as IRNNUMBER_LEFT,'' as IRNNUMBER_RIGHT,cast ('0' as bit) as CHECK_GROUP,0 as TOTAL_GW FROM CARB WHERE 2<1";
            data = conn.readdata(sql);
        }
        public void Load_DGV(DataTable dataTable)
        {
            DGV1.DataSource = dataTable;
            conn.DGV(DGV1);
            Changed_Color2(DGV1);

        }

        private void getDataINR_LEFT_RIGHT(DataTable dataTable)
        {

            foreach (DataRow item in dataTable.Rows)
            {
                string sql = "SELECT * FROM dbo.SplitString('" + item["OR_NO"].ToString() + "','/')";
                DataTable datanew = new DataTable();
                datanew = conn.readdata(sql);
                if (datanew.Rows.Count > 0)
                {
                    foreach (DataRow item2 in datanew.Rows)
                    {
                        item["IRNNUMBER_LEFT"] = item2["Items"].ToString();
                        item["IRNNUMBER_RIGHT"] = item2["Items2"].ToString();
                    }
                }
                else
                {
                    item["IRNNUMBER_LEFT"] = item["OR_NO"].ToString();
                    item["IRNNUMBER_RIGHT"] = "";
                }
            }

        }

        public void Load_DGV2(DataTable dataTable)
        {
            data = (DataTable)DGV1.DataSource;
            data.Merge(dataTable);
            DGV1.DataSource = data;
            conn.DGV(DGV1);
            Changed_Color2(DGV1);
        }
        private void Changed_Color2(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["Calculated"].Value.ToString()))
                {
                    if (row.Cells["Calculated"].Value.ToString() == "True")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void Changed_Color(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["Calculated"].Value.ToString()))
                {
                    if (row.Cells["Calculated"].Value.ToString() == "True")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                int position_xy_mouse_row = DGV1.HitTest(e.X, e.Y).RowIndex;
                menu.Items.Add("Insert").Name = "Insert";
                menu.Items.Add("Edit").Name = "Edit";
                menu.Items.Add("Del").Name = "Del";

                menu.Show(DGV1, new Point(e.X, e.Y));
                menu.ItemClicked += Menu_ItemClicked;
            }
        }
        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToString())
            {
                case "Insert":
                    try
                    {
                        if (!string.IsNullOrEmpty(txtC_NO.Text))
                        {
                            ClickInsertDataGridview();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập mã khách hàng");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Del":
                    foreach (DataGridViewCell oneCell in DGV1.SelectedCells)
                    {
                        if (oneCell.Selected)
                        {
                            int key = oneCell.RowIndex;
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            // data.Rows.RemoveAt(key);
                        }
                    }
                    break;
            }
        }
        public class DL
        {
            public static DataTable data1_TinhTien;
            public static DataTable data2_KhongTinhTien;
            public static string MESSRS;
            public static string ADDRESS;
            public static string ATTN;
            public static string TEL;
            public static string Shippedby;
            public static string Address_2;
            public static string From;
            public static string ByAir;
            public static string Date;
            public static string Invoice;
            public static string Billto;
            public static string Address_3;
            public static string ATTN_2;
            public static string TEL_2;
            public static string HSCODE;
            public static string TAXID;
            public static string FAX;
            public static string FAX_2;
            public static string PayMent;
            public static string DELIVERY;
            public static string Country;
            public static string To;
            public static string PhanTram;
            public static string TYPE;

            public static bool checkBillto;
            public static bool checkHSCODE;

            public static DataTable dataTrongNuoc;

        }
        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            getReturnTitle(checkTieuDe);
            getDatedaymonyear();

            data = (DataTable)DGV1.DataSource;

            if (rdInvoice.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        if (cbBillto.Checked == false)
                        {
                            ReportDocument cryRpt = new ReportDocument();
                            if (cbRutGon.Checked == false)
                            {
                                cryRpt = new Cr_Form3N();
                                cryRpt.DataDefinition.FormulaFields["MESSRS"].Text = "'" + Title_1 + " " + txtC_NAME.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'ADDRESS: " + txtADR.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ATTN"].Text = "'ATTN: " + txtATTN.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'TEL: " + txtTEL.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["Shipped by"].Text = "'Shipped by: " + txtShip.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'Address: " + txtAd.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["From"].Text = "'FROM: " + txtFr.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["To"].Text = "'TO: " + txtTo.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ByAir"].Text = "'" + txtByAir.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'FAX : " + txtFAX.Text + "'";

                                cryRpt.DataDefinition.FormulaFields["Date"].Text = "'DATE : " + date_add + "'";
                                cryRpt.DataDefinition.FormulaFields["Invoice"].Text = "'INVOICE#: " + txtInvoice.Text + "'";
                            }
                            else
                            {
                                cryRpt = new Cr_Form3N_RutGon();
                                cryRpt.DataDefinition.FormulaFields["MESSRS"].Text = "'" + Title_1 + " " + txtC_NAME.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'ADDRESS: " + txtADR.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ATTN"].Text = "'ATTN: " + txtATTN.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'TEL: " + txtTEL.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["From"].Text = "'FROM: " + txtFr.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["ByAir"].Text = "'" + txtByAir.Text + "'";
                                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'FAX : " + txtFAX.Text + "'";

                                cryRpt.DataDefinition.FormulaFields["Date"].Text = "'DATE : " + date_add + "'";
                                cryRpt.DataDefinition.FormulaFields["Invoice"].Text = "'INVOICE#: " + txtInvoice.Text + "'";
                            }    
                            

                            CuaChiTramNho(cryRpt);

                            cryRpt.SetDataSource(data);
                            ShareReport.repo = cryRpt;
                            Report frm = new Report();
                            frm.ShowDialog();
                        }
                        else if (cbBillto.Checked == true)
                        {
                            ReportDocument cryRpt = new Cr_Form3N_Billto();
                            cryRpt.DataDefinition.FormulaFields["MESSRS"].Text = "'"+Title_1+" " + txtC_NAME.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'ADDRESS: " + txtADR.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["ATTN"].Text = "'ATTN: " + txtATTN.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'TEL: " + txtTEL.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["Shipped by"].Text = "'Shipped by: " + txtShip.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'Address: " + txtAd.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["From"].Text = "'FROM: " + txtFr.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["To"].Text = "'TO: " + txtTo.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["ByAir"].Text = "'" + txtByAir.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'FAX : " + txtFAX.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["Date"].Text = "'DATE : " + date_add + "'";
                            cryRpt.DataDefinition.FormulaFields["Invoice"].Text = "'INVOICE#: " + txtInvoice.Text + "'";

                            cryRpt.DataDefinition.FormulaFields["Billto"].Text = "'" + Title_2 + " " + txtBillto.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["Address_3"].Text = "'Address: " + txtAddress_billto.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["ATTN_2"].Text = "'ATTN: " + txtATTN_Billto.Text + "'";
                            cryRpt.DataDefinition.FormulaFields["TEL_2"].Text = "'TEL: " + txtTEL_Billto.Text + "'";
                            CuaChiTramNho(cryRpt);

                            cryRpt.SetDataSource(data);
                            ShareReport.repo = cryRpt;
                            Report frm = new Report();
                            frm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    DL.data1_TinhTien = null;
                    DL.data2_KhongTinhTien = null;
                    int bien1 = 0;
                    int bien2 = 0;
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "True")
                        {
                            bien1++;
                        }
                        else if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "False")
                        {
                            bien2++;
                        }
                    }
                    if (bien1 > 0)
                    {
                        DL.data2_KhongTinhTien = data.AsEnumerable().Where(x => x.Field<string>("Calculated").ToString() == "True").CopyToDataTable();
                    }
                    if (bien2 > 0)
                    {
                        DL.data1_TinhTien = data.AsEnumerable().Where(x => x.Field<string>("Calculated").ToString() == "False").CopyToDataTable();
                    }
                    DL.MESSRS = ""+Title_1+"" + txtC_NAME.Text + "";
                    DL.ADDRESS = "ADDRESS: " + txtADR.Text + ""; ;
                    DL.ATTN = "ATTN: " + txtATTN.Text + "";
                    DL.TEL = "TEL: " + txtTEL.Text + "";
                    DL.Shippedby = "Shipped by: " + txtShip.Text + "";
                    DL.Address_2 = "Address: " + txtAd.Text + "";
                    DL.From = "FROM: " + txtFr.Text + "";
                    DL.To = "To: " + txtTo.Text + "";
                    DL.ByAir = "" + txtByAir.Text + "";
                    DL.Date = "DATE : " + date_add + "";
                    DL.Invoice = "INVOICE#: " + txtInvoice.Text + "";
                    DL.Billto = "" + Title_2 + "" + txtBillto.Text + "";
                    DL.Address_3 = "Address: " + txtAddress_billto.Text + "";
                    DL.ATTN_2 = "ATTN: " + txtATTN_Billto.Text + "";
                    DL.TEL_2 = "TEL: " + txtTEL_Billto.Text + "";
                    DL.FAX = "FAX: " + txtFAX.Text + "";
                    DL.HSCODE = "HSCODE: " + HS_CODE + "";
                    DL.TAXID = "TAXID: " + TAX_ID + "";
                    
                    DL.checkBillto = cbBillto.Checked;
                    DL.checkHSCODE = checkHSCODE.Checked;

                    frm3N_Report form1 = new frm3N_Report();
                    form1.ShowDialog();
                }
                else if (rdTrongNuoc.Checked == true)
                {
                    if (cbBillto.Checked == false)
                    {
                        getDataINVOICE_PACKLIST_TRONGNUOC();
                        frm3N_TRONGNUOC form1 = new frm3N_TRONGNUOC();
                        form1.ShowDialog();
                    }   
                    else
                    {
                      getDataINVOICE_PACKLIST_TRONGNUOC_BILLTO();
                      frm3N_TRONGNUOC_BILLTO form1 = new frm3N_TRONGNUOC_BILLTO();
                      form1.ShowDialog();
                    }    
                    
                }
            }
            else if (rdPacking.Checked == true)
            {
                if (cbTachPO.Checked == false)
                {
                    ReportDocument cryRpt = new Cr_Form3O_1();
                    getDataParamter(cryRpt);
                    cryRpt.DataDefinition.FormulaFields["TermOf"].Text = "'" + TERM_OF + "'";
                    cryRpt.SetDataSource(data);
                    ShareReport.repo = cryRpt;
                    Report frm = new Report();
                    frm.ShowDialog();
                }
                else
                {
                    ReportDocument cryRpt = new Cr_Form3O_2();
                    getDataParamter(cryRpt);
                    cryRpt.SetDataSource(data);
                    ShareReport.repo = cryRpt;
                    Report frm = new Report();
                    frm.ShowDialog();
                }
            }
        }
        private void getDataINVOICE_PACKLIST_TRONGNUOC()
        {
            // h làm
            DL.dataTrongNuoc = data;
           
                // chuyền paramter
                DL.Invoice = "INVOICE NO: " + txtInvoice.Text + "";
                DL.Date = "DATE : " + date_add + "";
                DL.MESSRS = "For account and risk of Messrs : " + txtC_NAME.Text + "";
                DL.ADDRESS = "ADDRESS: " + txtADR.Text + "";
                DL.TEL = "TEL: " + txtTEL.Text + "";
                DL.FAX = "FAX: " + txtFAX.Text + "";
                DL.Shippedby = "Shipped by: " + txtShip.Text + "";
                DL.Address_2 = "Address: " + txtAd.Text + "";
                DL.PayMent = "Payment : " + Payment + "";
                DL.DELIVERY = "Delivery of term : " + TERM_OF + "";
                DL.Country = "Country of Origin : " + key_Country + "";
                DL.To = "TO : " + txtTo.Text + "";
                DL.From = "FROM: " + txtFr.Text + "";
        }
        private void getDataINVOICE_PACKLIST_TRONGNUOC_BILLTO()
        {
            // h làm
            DL.dataTrongNuoc = data;

            // chuyền paramter
            DL.Invoice = "INVOICE NO: " + txtInvoice.Text + "";
            DL.Date = "DATE : " + date_add + "";
            DL.Billto = "SOLD TO : " + txtBillto.Text + "";
            DL.Address_3 = "Address : " + txtAddress_billto.Text + "";
            DL.TEL_2 = "TEL : " + txtTEL_Billto.Text + "";
            DL.FAX_2 = "TEL : " + FAX_2 + "";
            DL.MESSRS = "SHIP TO: " + txtC_NAME.Text + "";
            DL.ADDRESS = "ADDRESS: " + txtADR.Text + "";
            DL.TEL = "TEL: " + txtTEL.Text + "";
            DL.FAX = "FAX: " + txtFAX.Text + "";
            DL.Shippedby = "Shipped by: " + txtShip.Text + "";
            DL.Address_2 = "Address: " + txtAd.Text + "";
            DL.HSCODE = "" + HS_CODE + "";
            DL.Country = "" + key_Country + "";
            DL.To = "TO : " + txtTo.Text + "";
            DL.From = "FROM: " + txtFr.Text + "";

            if (!string.IsNullOrEmpty(txtPhanTram.Text) && conn.IsNumber(txtPhanTram.Text) && float.Parse(txtPhanTram.Text) >= 0 && float.Parse(txtPhanTram.Text) <= 100)
            {
                DL.PhanTram = "" + txtPhanTram.Text + "";
            }
            else
            {
                DL.PhanTram = "";
            }
            if (DGV1.Rows.Count > 0)
            {
                DL.TYPE = DGV1.Rows[0].Cells["K_NO"].Value.ToString();
            }    
        }
        private void getDataParamter(ReportDocument cryRpt)
        {
            cryRpt.DataDefinition.FormulaFields["INVOICE"].Text = "'INVOICE NO: " + txtInvoice.Text + "'";
            cryRpt.DataDefinition.FormulaFields["C_NAME"].Text = "'For account and risk of Messrs: " + txtC_NAME.Text + "'";
            cryRpt.DataDefinition.FormulaFields["DATE"].Text = "'DATE: " + date_add + "'";
            cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'Address: " + txtADR.Text + "'";
            cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'TEL: " + txtTEL.Text + "'";
            cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'FAX: " + txtFAX.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Shippedby"].Text = "'Shipped by: " + txtFr.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'Address:" + txtAd.Text + "'";
            cryRpt.DataDefinition.FormulaFields["FROM"].Text = "'" + txtFr.Text + "'";
            cryRpt.DataDefinition.FormulaFields["TO"].Text = "'" + txtTo.Text + "'";

            float Cno = 0, Qty = 0, NW = 0, GW = 0;

            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                Cno += float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString());
                Qty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                NW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                GW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
            }
            cryRpt.DataDefinition.FormulaFields["TOTAL_CNO"].Text = "'" + Cno.ToString() + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_QTY"].Text = "'" + string.Format(Qty.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_NW"].Text = "'" + string.Format(NW.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_GW"].Text = "'" + string.Format(GW.ToString(), "#,##0.00") + "'";

        }
        private void CuaChiTramNho(ReportDocument cryRpt)
        {
            if (checkHSCODE.Checked == true)
            {
                cryRpt.DataDefinition.FormulaFields["TAXID"].Text = "'TAXID: " + TAX_ID + "'";
                cryRpt.DataDefinition.FormulaFields["HSCODE"].Text = "'HSCODE: " + HS_CODE + "'";
            }
        }
        private void getDatedaymonyear()
        {
            if (!string.IsNullOrEmpty(txtDate.Text) && txtDate.MaskFull == true)
            {
                string sql = "EXEC getDate_3N '" + conn.formatstr2(txtDate.Text) + "'";
                DataTable getdate = new DataTable();
                getdate = conn.readdata(sql);
                date_add = getdate.Rows[0]["DATE"].ToString();
            }
            else
            {
                month = "";
                day = "";
                year = "";
            }
        }
        private void checkExport()
        {
            getReturnTitle(checkTieuDe);
            getDatedaymonyear();
            //invoice
            if (rdInvoice.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    if (cbBillto.Checked == false)
                    {
                        //test
                        string workbookPath = conn.LinkTemplate + "Sample_KD_NuocNgoai.xls";
                        string filePath = conn.LinkTemplate_SAVE + "Sample_KD_NuocNgoai.xls";
                        xuatExcel_Invoice_NuocNgoai(workbookPath, filePath);
                    }
                    else
                    {
                        string workbookPath = conn.LinkTemplate + "Sample_KD_Billto_NuocNgoai.xls";
                        string filePath = conn.LinkTemplate_SAVE + "Sample_KD_Billto_NuocNgoai.xls";
                        Export_Excel_BillTo_NuocNgoai(workbookPath, filePath);

                    }
                }
                else if (radioButton2.Checked == true)
                {
                    if (cbBillto.Checked == false)
                    {
                        string workbookPath = conn.LinkTemplate + "Sample_KD_NuocNgoai_ChiTiet.xls";
                        string filePath = conn.LinkTemplate_SAVE + "Sample_KD_NuocNgoai_ChiTiet.xls";
                        xuatExcel_Invoice_NuocNgoai_Chitiet(workbookPath, filePath);
                    }
                    else
                    {
                        string workbookPath = conn.LinkTemplate + "Sample_KD_Billto_NuocNgoai_ChiTiet.xls";
                        string filePath = conn.LinkTemplate_SAVE + "Sample_KD_Billto_NuocNgoai_ChiTiet.xls";
                        Export_Excel_BillTo_NuocNgoai_Chitiet(workbookPath, filePath);
                    }
                }
                else
                {
                    if (cbBillto.Checked == false)
                    {
                        string workbookPath = conn.LinkTemplate + "Sample_KD_TrongNuoc.xls";
                        string filePath = conn.LinkTemplate_SAVE + "Sample_KD_TrongNuoc.xls";
                        Export_Excel_TrongNuoc(workbookPath, filePath);
                    }
                    else
                    {
                      //h làm nè ~~
                      string workbookPath = conn.LinkTemplate + "Sample_KD_Billto_TrongNuoc.xls";
                      string filePath = conn.LinkTemplate_SAVE + "Sample_KD_Billto_TrongNuoc.xls";
                      Export_Excel_BillTo_TrongNuoc(workbookPath, filePath);
                    }

                }
            }
            else if (rdPacking.Checked == true)
            {
                if (cbTachPO.Checked == false && cbcheckgroup.Checked == false)
                {
                    string workbookPath = conn.LinkTemplate + "Template_xuatExcel_PackingList_Type_1.xls";
                    string filePath = conn.LinkTemplate_SAVE + "Template_xuatExcel_PackingList_Type_1.xls";
                    xuatExcel_PackingList1(workbookPath, filePath);
                }
                else if (cbTachPO.Checked == true && cbcheckgroup.Checked == false)
                {
                    string workbookPath = conn.LinkTemplate + "Template_xuatExcel_PackingList_Type_2.xls";
                    string filePath = conn.LinkTemplate_SAVE + "Template_xuatExcel_PackingList_Type_2.xls";
                    xuatExcel_PackingList2(workbookPath, filePath);
                }
                else if (cbTachPO.Checked == false && cbcheckgroup.Checked == true)
                {
                    string workbookPath = conn.LinkTemplate + "PACKING_LIST_GROUP.xls";
                    string filePath = conn.LinkTemplate_SAVE + "PACKING_LIST_GROUP.xls";
                    xuatExcel_Group(workbookPath, filePath);
                }

            }
        }

        private void getReturnTitle(bool checkTieuDe)
        {
            if (checkTieuDe == true)
            {
                 Title_1 = "SHIP TO :";
                 Title_2 = "BUYER :";
            }    
            else
            {
                Title_1 = "MESSRS :";
                Title_2 = "BILL TO :";
            }    
        }

        private void Export_Excel_BillTo_TrongNuoc(string workbookPath, string filePath)
        {
            string key = "";
            if (DGV1.Rows.Count > 0)
            {
                key = DGV1.Rows[0].Cells["K_NO"].Value.ToString();
            }
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                    #region Worksheets1------------
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];
                    if (int.Parse(key) == 1 || int.Parse(key) == 3)
                    {
                        COMExcel.Range DESC = IV.get_Range("B14", "B14");
                        DESC.Merge();
                        DESC.WrapText = true;
                        DESC.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESC.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESC.Value2 = "DESCRIPTION \n Cow leather finished product";
                    }   
                    else
                    {
                        COMExcel.Range DESC = IV.get_Range("B14", "B14");
                        DESC.Merge();
                        DESC.WrapText = true;
                        DESC.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESC.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESC.Value2 = "DESCRIPTION \n Pig leather finished product";
                    }
                   
                    COMExcel.Range INVOICE = IV.get_Range("A4", "A4");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE NO:" + txtInvoice.Text;

                    COMExcel.Range DATE = IV.get_Range("E4", "E4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = date_add;

                    COMExcel.Range SLOD_TO = IV.get_Range("A5", "H5");
                    SLOD_TO.Merge();
                    SLOD_TO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SLOD_TO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SLOD_TO.Value2 = "SOLD TO :" + txtBillto.Text;

                    COMExcel.Range Add = IV.get_Range("A6", "H6");
                    Add.Merge();
                    Add.WrapText = true;
                    Add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Add.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Add.Value2 = "Address :" + txtAddress_billto.Text;
                    Add.Rows.AutoFit();


                    COMExcel.Range TEL_FAX_Billto = IV.get_Range("A7", "A7");
                    TEL_FAX_Billto.Merge();
                    TEL_FAX_Billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL_FAX_Billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL_FAX_Billto.Value2 = "TEL :" + txtTEL_Billto.Text + "       " + "FAX : " + FAX_2;

                    COMExcel.Range C_NAME = IV.get_Range("A8", "A8");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = "SHIP TO :" + txtC_NAME.Text;

                    COMExcel.Range ARD3 = IV.get_Range("A9", "H9");
                    ARD3.Merge();
                    ARD3.WrapText = true;
                    ARD3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3.Value2 = "Address : " + txtADR.Text;

                    COMExcel.Range TEL = IV.get_Range("A10", "A10");
                    TEL.Merge();
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Value2 = "TEL : " + txtTEL.Text + "       " + "FAX: " + txtFAX.Text;

                    COMExcel.Range SHIPADD = IV.get_Range("A11", "A11");
                    SHIPADD.Merge();
                    SHIPADD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIPADD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIPADD.Value2 = "Shipped by : " + txtShip.Text;

                    COMExcel.Range ARD3ADD = IV.get_Range("A12", "H12");
                    ARD3ADD.Merge();
                    ARD3ADD.WrapText = true;
                    ARD3ADD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3ADD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3ADD.Value2 = "Address : " + txtAd.Text;
                    ARD3ADD.Rows.AutoFit();


                    COMExcel.Range From = IV.get_Range("A13", "A13");
                    From.Merge();
                    From.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    From.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    From.Value2 = "FROM : " + txtFr.Text;

                    COMExcel.Range To = IV.get_Range("C13", "C13");
                    To.Merge();
                    To.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    To.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    To.Value2 = "TO : " + txtTo.Text;

                    int a = 15;
                    float sumQty = 0;
                    float sumAmount = 0;


                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        OR_NO.WrapText = true;
                        OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.Font.Size = 8;
                        OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.WrapText = true;
                        COLOR.Font.Size = 8;
                        COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                        //row 20
                        COMExcel.Range HSCODE = IV.get_Range("C" + a, "C" + a);
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.WrapText = true;
                        HSCODE.Font.Size = 8;
                        HSCODE.Value2 = HS_CODE;

                        //row 20
                        COMExcel.Range COUNTRY = IV.get_Range("D" + a, "D" + a);
                        COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COUNTRY.WrapText = true;
                        COUNTRY.Font.Size = 8;
                        COUNTRY.Value2 = key_Country;

                        //row 20
                        COMExcel.Range THICK = IV.get_Range("E" + a, "E" + a);
                        THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.Font.Size = 8;
                        THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        //Quantity
                        COMExcel.Range BQTY = IV.get_Range("F" + a, "F" + a);
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Size = 8;
                        BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                        //price
                        COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                        PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.Font.Size = 8;
                        PRICE.NumberFormat = "[$USD] #,##0.00";
                        PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                        //total
                        COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                        AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AMOUNT.Font.Size = 8;
                        AMOUNT.NumberFormat = "[$USD] #,##0.00";
                        AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                        sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                        a++;
                    }
                    IV.get_Range("A" + (a - 1) + "", "H" + (a - 1) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;

                    COMExcel.Range T1 = IV.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1.Font.Bold = true;
                    T1.Font.Size = 10;
                    T1.Value2 = "TOTAL";

                    COMExcel.Range T2 = IV.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2.Font.Bold = true;
                    T2.Font.Size = 10;
                    T2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3 = IV.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3.Font.Bold = true;
                    T3.Font.Size = 10;
                    T3.NumberFormat = "[$USD] #,##0.00";
                    T3.Value2 = Math.Round(sumAmount, 2).ToString();

                    if (!string.IsNullOrEmpty(txtPhanTram.Text) && conn.IsNumber(txtPhanTram.Text) && float.Parse(txtPhanTram.Text) >= 0 && float.Parse(txtPhanTram.Text) <= 100)
                    {
                        COMExcel.Range TITLE2 = IV.get_Range("C" + (a + 1) + "", "G" + (a + 1) + "");
                        TITLE2.Merge();
                        TITLE2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                        TITLE2.Font.Size = 10;
                        TITLE2.Value2 = "Sample materials les then 200sf " + ReturnPhanTram(txtPhanTram.Text) + "%";

                        COMExcel.Range SUMPHANTRAM = IV.get_Range("H" + (a + 1) + "", "H" + (a + 1) + "");
                        SUMPHANTRAM.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SUMPHANTRAM.Font.Bold = true;
                        SUMPHANTRAM.Font.Size = 10;
                        SUMPHANTRAM.NumberFormat = "[$USD] #,##0.00";
                        SUMPHANTRAM.Value2 = sumAmount * float.Parse(ReturnPhanTram(txtPhanTram.Text)) / 100;

                        IV.get_Range("C" + (a + 1) + "", "H" + (a + 1) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;

                        COMExcel.Range TOTALF = IV.get_Range("H" + (a + 2) + "", "H" + (a + 2) + "");
                        TOTALF.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTALF.Font.Bold = true;
                        TOTALF.Font.Size = 10;
                        TOTALF.NumberFormat = "[$USD] #,##0.00";
                        TOTALF.Value2 = sumAmount - (sumAmount * float.Parse(ReturnPhanTram(txtPhanTram.Text)) / 100);
                    }    
                    else
                    {
                        a = a - 2;
                    }    
                    //row 24
                    COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100.Font.Size = 10;
                    A100.Cells.Font.FontStyle = "新細明體";
                    A100.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7.WrapText = false;
                    A7.Font.Size = 10;
                    A7.Cells.Font.FontStyle = "新細明體";
                    A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8.WrapText = false;
                    A8.Font.Size = 10;
                    A8.Cells.Font.FontStyle = "新細明體";
                    A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9.WrapText = false;
                    A9.Font.Size = 10;
                    A9.Cells.Font.FontStyle = "新細明體";
                    A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank.Font.Size = 10;
                    bank.Cells.Font.FontStyle = "新細明體";
                    bank.Value2 = "BANK NAME: ";

                    COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10.Font.Size = 10;
                    A10.Cells.Font.FontStyle = "新細明體";
                    A10.WrapText = false;
                    A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount.Font.Size = 10;
                    Acount.Cells.Font.FontStyle = "新細明體";
                    Acount.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11.Font.Size = 10;
                    A11.Cells.Font.FontStyle = "新細明體";
                    A11.WrapText = false;
                    A11.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift.Font.Size = 10;
                    Swift.Cells.Font.FontStyle = "新細明體";
                    Swift.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12.Font.Size = 10;
                    A12.Cells.Font.FontStyle = "新細明體";
                    A12.WrapText = false;
                    A12.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress.Font.Size = 10;
                    bankAddress.Cells.Font.FontStyle = "新細明體";
                    bankAddress.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13.Font.Size = 10;
                    A13.Cells.Font.FontStyle = "新細明體";
                    A13.WrapText = false;
                    A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14.Font.Size = 10;
                    A14.Cells.Font.FontStyle = "新細明體";
                    A14.WrapText = false;
                    A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15 = IV.get_Range("D" + (a + 11) + "", "G" + (a + 11) + "");
                    A15.Font.Size = 12;
                    A15.Cells.Font.FontStyle = "新細明體";
                    A15.Merge();
                    A15.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    #endregion


                    app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);

                }
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        private void Export_Excel_TrongNuoc(string workbookPath, string filePath)
        {
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    //1
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];
                    #region TAB 1

                    COMExcel.Range INVOICE = IV.get_Range("A4", "A4");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE NO :" + txtInvoice.Text;

                    COMExcel.Range DATE = IV.get_Range("F4", "F4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = "DATE :" + date_add;

                    COMExcel.Range C_NAME = IV.get_Range("A5", "A5");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = "For account and risk of Messrs : " + txtC_NAME.Text;

                    COMExcel.Range ADR = IV.get_Range("A6", "H6");
                    ADR.Merge();
                    ADR.WrapText = true;
                    ADR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ADR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ADR.Value2 = "Address: " + txtC_NAME.Text;

                    COMExcel.Range TEL = IV.get_Range("A7", "A7");
                    TEL.Merge();
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Value2 = "TEL: " + txtC_NAME.Text;

                    COMExcel.Range FAX = IV.get_Range("D7", "D7");
                    FAX.Merge();
                    FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FAX.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FAX.Value2 = "FAX: " + txtFAX.Text;

                    COMExcel.Range Ship = IV.get_Range("A8", "A8");
                    Ship.Merge();
                    Ship.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Ship.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Ship.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range Address = IV.get_Range("A9", "H9");
                    Address.Merge();
                    Address.WrapText = true;
                    Address.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Address.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Address.Value2 = "Address : " + txtAd.Text;

                    COMExcel.Range payment = IV.get_Range("A10", "A10");
                    payment.Merge();
                    payment.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    payment.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    payment.Value2 = "Payment: " + Payment;

                    COMExcel.Range Delivery = IV.get_Range("C10", "C10");
                    Delivery.Merge();
                    Delivery.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Delivery.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Delivery.Value2 = "Delivery of term: " + TERM_OF;

                    COMExcel.Range Country = IV.get_Range("D10", "D10");
                    Country.Merge();
                    Country.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Country.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Country.Value2 = "Country of Origin : " + key_Country;

                    COMExcel.Range To = IV.get_Range("A11", "A11");
                    To.Merge();
                    To.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    To.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    To.Value2 = "To : " + txtTo.Text;

                    COMExcel.Range From = IV.get_Range("D11", "D11");
                    From.Merge();
                    From.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    From.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    From.Value2 = "From : " + txtFr.Text;

                    int a = 14;
                    float sumQty = 0;
                    float sumQty_2 = 0;
                    float sumAmount = 0;

                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (rdTachPO_INVOICE.Checked == true)
                        {
                            COMExcel.Range C_NO_LEFT = IV.get_Range("A" + a, "A" + a);
                            C_NO_LEFT.Merge();
                            C_NO_LEFT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_LEFT.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_LEFT.Font.Size = 9;
                            C_NO_LEFT.Value2 = DGV1.Rows[i].Cells["IRNNUMBER_LEFT"].Value.ToString();

                            COMExcel.Range C_NO_RIGHT = IV.get_Range("B" + a, "B" + a);
                            C_NO_RIGHT.Merge();
                            C_NO_RIGHT.Font.Size = 9;
                            C_NO_RIGHT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_RIGHT.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_RIGHT.Value2 = DGV1.Rows[i].Cells["IRNNUMBER_RIGHT"].Value.ToString();
                        }    
                        else
                        {
                            COMExcel.Range C_NO_LEFT = IV.get_Range("A" + a, "B" + a);
                            C_NO_LEFT.Merge();
                            C_NO_LEFT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_LEFT.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            C_NO_LEFT.Font.Size = 9;
                            C_NO_LEFT.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();
                        }    
                        COMExcel.Range DESCRIPTION = IV.get_Range("C" + a, "C" + a);
                        DESCRIPTION.Merge();
                        DESCRIPTION.Font.Size = 9;
                        DESCRIPTION.WrapText = true;
                        DESCRIPTION.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESCRIPTION.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        DESCRIPTION.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                        COMExcel.Range P_NAME3 = IV.get_Range("D" + a, "D" + a);
                        P_NAME3.Merge();
                        P_NAME3.Font.Size = 9;
                        P_NAME3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        COMExcel.Range BQTY = IV.get_Range("E" + a, "E" + a);
                        BQTY.Merge();
                        BQTY.Font.Size = 10;
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.NumberFormat = "#,##0.00";
                        BQTY.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();

                        COMExcel.Range BQTY_2 = IV.get_Range("F" + a, "F" + a);
                        BQTY_2.Merge();
                        BQTY_2.Font.Size = 10;
                        BQTY_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY_2.NumberFormat = "#,##0.00";
                        BQTY_2.Value2 = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * HANG_SO;
                        double number = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * HANG_SO;

                        COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                        PRICE.Merge();
                        PRICE.Font.Size = 10;
                        PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.NumberFormat = "[$USD] #,##0.00";
                        PRICE.Value2 = DGV1.Rows[i].Cells["PRICE"].Value.ToString();

                        COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                        AMOUNT.Merge();
                        AMOUNT.Font.Size = 10;
                        AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AMOUNT.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AMOUNT.NumberFormat = "#,##0.00";
                        AMOUNT.Value2 = DGV1.Rows[i].Cells["AMOUNT"].Value.ToString();

                        sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumQty_2 += float.Parse(number.ToString());
                        sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());

                        a++;
                    }
                    
                    IV.get_Range("A" + (a - 1) + "", "H" + (a - 1) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;

                    COMExcel.Range TITLE = IV.get_Range("C" + (a), "C" + (a));
                    TITLE.Merge();
                    TITLE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TITLE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TITLE.Value2 = "TOTAL";

                    COMExcel.Range SUMQTY = IV.get_Range("E" + (a), "E" + (a));
                    SUMQTY.Merge();
                    SUMQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SUMQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SUMQTY.NumberFormat = "#,##0.00";
                    SUMQTY.Value2 = sumQty.ToString();

                    COMExcel.Range SUMQTY_2 = IV.get_Range("F" + (a), "F" + (a));
                    SUMQTY_2.Merge();
                    SUMQTY_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SUMQTY_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SUMQTY_2.NumberFormat = "#,##0.00";
                    SUMQTY_2.Value2 = sumQty_2.ToString();

                    COMExcel.Range sumAmount_2 = IV.get_Range("H" + (a), "H" + (a));
                    sumAmount_2.Merge();
                    sumAmount_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    sumAmount_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    sumAmount_2.NumberFormat = "[$USD] #,##0.00";
                    sumAmount_2.Value2 = sumAmount.ToString();


                    COMExcel.Range TITLE_2 = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                    TITLE_2.Merge();
                    TITLE_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TITLE_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TITLE_2.Value2 = "PAYMENT FOR GOODS";


                    COMExcel.Range TITLE_3 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    TITLE_3.Merge();
                    TITLE_3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TITLE_3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TITLE_3.Value2 = "TOTAL : ";


                    COMExcel.Range TITLE_4 = IV.get_Range("E" + (a + 5), "H" + (a + 5));
                    TITLE_4.Merge();
                    TITLE_4.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TITLE_4.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TITLE_4.Value2 = "TOPPING INTERNATIONAL CO., LTD";
                    #endregion

                    /// tab 2
                    COMExcel.Worksheet IV_2 = (COMExcel.Worksheet)book.Worksheets[2];
                    app.Visible = true;

                    

                   // app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void xuatExcel_Group(string workbookPath, string filePath)
        {

            if (conn.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    File.Copy(workbookPath, filePath, true);
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file excel");
                    return;
                }
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range INVOICE2 = IV.get_Range("A4", "C4");
                INVOICE2.Merge();
                INVOICE2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                INVOICE2.Font.Size = 11;
                INVOICE2.Cells.Font.FontStyle = "Times New Roman";
                INVOICE2.Value2 = "INVOICE : " + txtInvoice.Text;

                COMExcel.Range DATE = IV.get_Range("D4", "H4");
                DATE.Merge();
                DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                DATE.Font.Size = 11;
                DATE.Cells.Font.FontStyle = "Times New Roman";
                DATE.Value2 = "DATE: " + date_add;

                COMExcel.Range Tiltle = IV.get_Range("A5", "A5");
                Tiltle.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Tiltle.Font.Size = 11;
                Tiltle.Cells.Font.FontStyle = "新細明體";
                Tiltle.Value2 = "Seller/Shipper/Exporter:";

                COMExcel.Range CTY = IV.get_Range("A6", "A6");
                CTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                CTY.Font.Size = 11;
                CTY.Cells.Font.FontStyle = "新細明體";
                CTY.Value2 = txtShip.Text.ToUpper();

                COMExcel.Range CTY_Add = IV.get_Range("A7", "A7");
                CTY_Add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                CTY_Add.Font.Size = 11;
                CTY_Add.Cells.Font.FontStyle = "新細明體";
                CTY_Add.Value2 = txtAd.Text.ToUpper();

                COMExcel.Range TEL = IV.get_Range("A8", "C8");
                TEL.Merge();
                TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                TEL.Font.Size = 11;
                TEL.Cells.Font.FontStyle = "新細明體";
                TEL.Value2 = "TEL :" + txtTEL.Text + "";

                COMExcel.Range FAX = IV.get_Range("D8", "G8");
                FAX.Merge();
                FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                FAX.Font.Size = 11;
                FAX.Cells.Font.FontStyle = "新細明體";
                FAX.Value2 = "FAX :" + txtFAX.Text + "";

                COMExcel.Range BUY = IV.get_Range("A9", "A9");
                BUY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                BUY.Font.Size = 11;
                BUY.Cells.Font.FontStyle = "新細明體";
                BUY.Value2 = "Buyer: ";

                COMExcel.Range BUYER = IV.get_Range("A10", "A10");
                BUYER.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                BUYER.Font.Size = 11;
                BUYER.Cells.Font.FontStyle = "新細明體";
                BUYER.Value2 = Buyer.ToUpper();

                COMExcel.Range BUYER_Add = IV.get_Range("A11", "H11");
                BUYER_Add.Merge();
                BUYER_Add.WrapText = true;
                BUYER_Add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                BUYER_Add.Font.Size = 11;
                BUYER_Add.Cells.Font.FontStyle = "新細明體";
                BUYER_Add.Value2 = Address_Buyer.ToUpper();

                COMExcel.Range Con = IV.get_Range("A12", "A12");
                Con.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Con.Font.Size = 11;
                Con.Cells.Font.FontStyle = "新細明體";
                Con.Value2 = "Consignee: ";

                COMExcel.Range Consignee2 = IV.get_Range("A13", "A13");
                Consignee2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Consignee2.Font.Size = 11;
                Consignee2.Cells.Font.FontStyle = "新細明體";
                Consignee2.Value2 = Consignee.ToUpper();

                COMExcel.Range Consignee_add = IV.get_Range("A14", "H14");
                Consignee_add.Merge();
                Consignee_add.WrapText = true;
                Consignee_add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                Consignee_add.Font.Size = 11;
                Consignee_add.Cells.Font.FontStyle = "新細明體";
                Consignee_add.Value2 = Address_Consignee.ToUpper();


                COMExcel.Range ATTN = IV.get_Range("A15", "B15");
                ATTN.Merge();
                ATTN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                ATTN.Font.Size = 11;
                ATTN.Cells.Font.FontStyle = "新細明體";
                ATTN.Value2 = "ATTN : " + txtATTN.Text + "";

                COMExcel.Range FROM = IV.get_Range("C15", "E15");
                FROM.Merge();
                FROM.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                FROM.Font.Size = 11;
                FROM.Cells.Font.FontStyle = "新細明體";
                FROM.Value2 = "FROM : " + txtFr.Text.ToUpper() + "";

                COMExcel.Range TO = IV.get_Range("F15", "H15");
                TO.Merge();
                TO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                TO.Font.Size = 11;
                TO.Cells.Font.FontStyle = "新細明體";
                TO.Value2 = "TO : " + txtTo.Text.ToUpper() + "";

                //tao biến
                int a = 18;
                float sumQTY = 0;
                float sumQTYm2 = 0;
                float sumNW = 0;
                float sumGW = 0;
                double sumM2 = 0;
                float CNOTOTAL = 0;
                //part 2 
                float sumQTY_2 = 0;
                float sumQTYm2_2 = 0;
                float sumNW_2 = 0;
                float sumGW_2 = 0;
                float CNOTOTAL_2 = 0;

                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    if (DGV1.Rows[i].Cells["CHECK_GROUP"].Value.ToString() == "True")
                    {
                        COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                        CNO.Merge();
                        CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        CNO.Font.Size = 10;
                        CNO.Cells.Font.FontStyle = "新細明體";
                        CNO.Value2 = DGV1.Rows[i].Cells["CNO"].Value.ToString();

                        COMExcel.Range INVOICE = IV.get_Range("B" + a, "B" + a);
                        INVOICE.Merge();
                        INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        INVOICE.Font.Size = 8;
                        INVOICE.Cells.Font.FontStyle = "新細明體";
                        INVOICE.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                        COMExcel.Range COLOR = IV.get_Range("C" + a, "C" + a);
                        COLOR.Merge();
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.Font.Size = 8;
                        COLOR.Cells.Font.FontStyle = "新細明體";
                        COLOR.WrapText = true;
                        COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                        COMExcel.Range P_NAME3 = IV.get_Range("D" + a, "D" + a);
                        P_NAME3.Merge();
                        P_NAME3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.Font.Size = 8;
                        P_NAME3.Cells.Font.FontStyle = "新細明體";
                        P_NAME3.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        COMExcel.Range BQTY = IV.get_Range("E" + a, "E" + a);
                        BQTY.Merge();
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Size = 8;
                        BQTY.Cells.Font.FontStyle = "新細明體";
                        BQTY.NumberFormat = "#,##0.00";
                        BQTY.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();

                        COMExcel.Range BQTY_M2 = IV.get_Range("F" + a, "F" + a);
                        BQTY_M2.Merge();
                        BQTY_M2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY_M2.Font.Size = 10;
                        BQTY_M2.Cells.Font.FontStyle = "新細明體";
                        BQTY_M2.NumberFormat = "#,##0.00";
                        BQTY_M2.Value2 = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * HANG_SO;

                        sumM2 = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * HANG_SO;

                        COMExcel.Range NW = IV.get_Range("G" + a, "G" + a);
                        NW.Merge();
                        NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        NW.Font.Size = 10;
                        NW.Cells.Font.FontStyle = "新細明體";
                        NW.NumberFormat = "#,##0.00";
                        NW.Value2 = DGV1.Rows[i].Cells["NW"].Value.ToString();

                        COMExcel.Range GW = IV.get_Range("H" + a, "H" + a);
                        GW.Merge();
                        GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        GW.Font.Size = 10;
                        GW.Cells.Font.FontStyle = "新細明體";
                        GW.NumberFormat = "#,##0.00";
                        GW.Value2 = DGV1.Rows[i].Cells["GW"].Value.ToString();

                        COMExcel.Range WEIGHTOF = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                        WEIGHTOF.Merge();
                        WEIGHTOF.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        WEIGHTOF.Font.Size = 10;
                        WEIGHTOF.Cells.Font.FontStyle = "新細明體";
                        WEIGHTOF.Font.Bold = true;
                        WEIGHTOF.Value2 = "WEIGHT OF PALLETIZE:";

                        COMExcel.Range TOTAL_2 = IV.get_Range("C" + (a + 2), "C" + (a + 2));
                        TOTAL_2.Merge();
                        TOTAL_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTAL_2.Font.Size = 10;
                        TOTAL_2.Cells.Font.FontStyle = "新細明體";
                        TOTAL_2.Font.Bold = true;
                        TOTAL_2.Value2 = "TOTAL:";

                        COMExcel.Range TOTAL_QTY = IV.get_Range("E" + (a + 2), "E" + (a + 2));
                        TOTAL_QTY.Merge();
                        TOTAL_QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTAL_QTY.Font.Size = 10;
                        TOTAL_QTY.Cells.Font.FontStyle = "新細明體";
                        TOTAL_QTY.NumberFormat = "#,##0.00";
                        TOTAL_QTY.Value2 = "=SUM(E" + a + ":E" + (a) + ")";

                        COMExcel.Range TOTAL_QTYm2 = IV.get_Range("F" + (a + 2), "F" + (a + 2));
                        TOTAL_QTYm2.Merge();
                        TOTAL_QTYm2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTAL_QTYm2.Font.Size = 10;
                        TOTAL_QTYm2.Cells.Font.FontStyle = "新細明體";
                        TOTAL_QTYm2.Font.Bold = true;
                        TOTAL_QTYm2.NumberFormat = "#,##0.00";
                        TOTAL_QTYm2.Value2 = "=SUM(F" + a + ":F" + (a) + ")";

                        COMExcel.Range NWTOAL = IV.get_Range("G" + (a + 2), "G" + (a + 2));
                        NWTOAL.Merge();
                        NWTOAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        NWTOAL.Font.Size = 10;
                        NWTOAL.Cells.Font.FontStyle = "新細明體";
                        NWTOAL.Font.Bold = true;
                        NWTOAL.NumberFormat = "#,##0.00";
                        NWTOAL.Value2 = "=SUM(G" + a + ":G" + (a) + ")";

                        COMExcel.Range GWTOTAL = IV.get_Range("H" + (a + 2), "H" + (a + 2));
                        GWTOTAL.Merge();
                        GWTOTAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        GWTOTAL.Font.Size = 10;
                        GWTOTAL.Cells.Font.FontStyle = "新細明體";
                        GWTOTAL.Font.Bold = true;
                        GWTOTAL.NumberFormat = "#,##0.00";
                        GWTOTAL.Value2 = DGV1.Rows[i].Cells["TOTAL_GW"].Value.ToString();

                        COMExcel.Range TOTAL_WEIGHT = IV.get_Range("H" + (a + 1), "H" + (a + 1));
                        TOTAL_WEIGHT.Merge();
                        TOTAL_WEIGHT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTAL_WEIGHT.Font.Size = 10;
                        TOTAL_WEIGHT.Cells.Font.FontStyle = "新細明體";
                        TOTAL_WEIGHT.NumberFormat = "#,##0.00";
                        TOTAL_WEIGHT.Value2 = "=(H" + (a + 2) + "-H" + (a) + ")";

                        sumQTY += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumQTYm2 += float.Parse(string.Format(sumM2.ToString(), "#,##0.00"));
                        sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                        sumGW += float.Parse(DGV1.Rows[i].Cells["TOTAL_GW"].Value.ToString());
                        CNOTOTAL += float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString());

                        IV.get_Range("A" + (a + 2) + "", "H" + (a + 2) + "").Cells.BorderAround();
                        a = a + 3;
                    }
                }
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    if (DGV1.Rows[i].Cells["CHECK_GROUP"].Value.ToString() == "False")
                    {
                        COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                        CNO.Merge();
                        CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        CNO.Font.Size = 10;
                        CNO.Cells.Font.FontStyle = "新細明體";
                        CNO.Value2 = DGV1.Rows[i].Cells["CNO"].Value.ToString();

                        COMExcel.Range INVOICE = IV.get_Range("B" + a, "B" + a);
                        INVOICE.Merge();
                        INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        INVOICE.Font.Size = 8;
                        INVOICE.Cells.Font.FontStyle = "新細明體";
                        INVOICE.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                        COMExcel.Range COLOR = IV.get_Range("C" + a, "C" + a);
                        COLOR.Merge();
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.Font.Size = 8;
                        COLOR.Cells.Font.FontStyle = "新細明體";
                        COLOR.WrapText = true;
                        COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                        COMExcel.Range P_NAME3 = IV.get_Range("D" + a, "D" + a);
                        P_NAME3.Merge();
                        P_NAME3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        P_NAME3.Font.Size = 8;
                        P_NAME3.Cells.Font.FontStyle = "新細明體";
                        P_NAME3.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        COMExcel.Range BQTY = IV.get_Range("E" + a, "E" + a);
                        BQTY.Merge();
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Size = 8;
                        BQTY.Cells.Font.FontStyle = "新細明體";
                        BQTY.NumberFormat = "#,##0.00";
                        BQTY.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();

                        COMExcel.Range BQTY_M2 = IV.get_Range("F" + a, "F" + a);
                        BQTY_M2.Merge();
                        BQTY_M2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY_M2.Font.Size = 10;
                        BQTY_M2.Cells.Font.FontStyle = "新細明體";
                        BQTY_M2.NumberFormat = "#,##0.00";
                        BQTY_M2.Value2 = float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * HANG_SO;

                        COMExcel.Range GW = IV.get_Range("H" + a, "H" + a);
                        GW.Merge();
                        GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        GW.Font.Size = 10;
                        GW.Cells.Font.FontStyle = "新細明體";
                        GW.NumberFormat = "#,##0.00";
                        GW.Value2 = DGV1.Rows[i].Cells["GW"].Value.ToString();

                        COMExcel.Range NW = IV.get_Range("G" + a, "G" + a);
                        NW.Merge();
                        NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        NW.Font.Size = 10;
                        NW.Cells.Font.FontStyle = "新細明體";
                        NW.NumberFormat = "#,##0.00";
                        NW.Value2 = "=H" + a + "-A" + a + "*0.1";

                        double so = 0.1;
                        sumQTY_2 += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumQTYm2_2 += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) * float.Parse(HANG_SO.ToString());
                        sumNW_2 += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString()) - float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString()) * float.Parse(so.ToString());
                        sumGW_2 += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                        CNOTOTAL_2 += float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString());
                        a++;
                    }
                }

                IV.get_Range("A" + (a) + "", "H" + (a) + "").Cells.BorderAround();

                COMExcel.Range TOTALCNO_Titel = IV.get_Range("A" + (a), "A" + (a));
                TOTALCNO_Titel.Merge();
                TOTALCNO_Titel.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTALCNO_Titel.Font.Size = 10;
                TOTALCNO_Titel.Cells.Font.FontStyle = "新細明體";
                TOTALCNO_Titel.Font.Bold = true;
                TOTALCNO_Titel.NumberFormat = "0";
                TOTALCNO_Titel.Value2 = CNOTOTAL + CNOTOTAL_2;

                COMExcel.Range TOTAL = IV.get_Range("C" + (a), "C" + (a));
                TOTAL.Merge();
                TOTAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL.Font.Size = 10;
                TOTAL.Cells.Font.FontStyle = "新細明體";
                TOTAL.Value2 = "TOTAL: ";

                COMExcel.Range TOTALQTY_Titel = IV.get_Range("E" + (a), "E" + (a));
                TOTALQTY_Titel.Merge();
                TOTALQTY_Titel.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTALQTY_Titel.Font.Size = 10;
                TOTALQTY_Titel.Cells.Font.FontStyle = "新細明體";
                TOTALQTY_Titel.Font.Bold = true;
                TOTALQTY_Titel.NumberFormat = "#,##0.00";
                TOTALQTY_Titel.Value2 = Math.Round(sumQTY + sumQTY_2, 2);

                COMExcel.Range TOTALQTYm2_Titel = IV.get_Range("F" + (a), "F" + (a));
                TOTALQTYm2_Titel.Merge();
                TOTALQTYm2_Titel.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTALQTYm2_Titel.Font.Size = 10;
                TOTALQTYm2_Titel.Cells.Font.FontStyle = "新細明體";
                TOTALQTYm2_Titel.Font.Bold = true;
                TOTALQTYm2_Titel.NumberFormat = "#,##0.00";
                TOTALQTYm2_Titel.Value2 = Math.Round(sumQTYm2 + sumQTYm2_2, 2);

                COMExcel.Range TOTALNw_Titel = IV.get_Range("G" + (a), "G" + (a));
                TOTALNw_Titel.Merge();
                TOTALNw_Titel.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTALNw_Titel.Font.Size = 10;
                TOTALNw_Titel.Cells.Font.FontStyle = "新細明體";
                TOTALNw_Titel.Font.Bold = true;
                TOTALNw_Titel.NumberFormat = "#,##0.00";
                TOTALNw_Titel.Value2 = Math.Round(sumNW + sumNW_2, 2);

                COMExcel.Range TOTALgw_Titel = IV.get_Range("H" + (a), "H" + (a));
                TOTALgw_Titel.Merge();
                TOTALgw_Titel.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTALgw_Titel.Font.Size = 10;
                TOTALgw_Titel.Cells.Font.FontStyle = "新細明體";
                TOTALgw_Titel.Font.Bold = true;
                TOTALgw_Titel.NumberFormat = "#,##0.00";
                TOTALgw_Titel.Value2 = Math.Round(sumGW + sumGW_2, 2);

                COMExcel.Range TOTAL_SUM = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                TOTAL_SUM.Font.Bold = true;
                TOTAL_SUM.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                TOTAL_SUM.Font.Size = 12;
                TOTAL_SUM.Cells.Font.FontStyle = "新細明體";
                TOTAL_SUM.Value2 = "TOTAL " + CNOTOTAL.ToString() + " PACKAGES & " + CNOTOTAL_2.ToString() + " ROLLS";

                COMExcel.Range NW_TOTAL = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                NW_TOTAL.Font.Bold = true;
                NW_TOTAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                NW_TOTAL.Font.Size = 12;
                NW_TOTAL.Cells.Font.FontStyle = "新細明體";
                NW_TOTAL.Value2 = "N.W = " + Math.Round(sumNW + sumNW_2, 2).ToString() + " KGS";

                COMExcel.Range GW_TOTAL = IV.get_Range("A" + (a + 4), "A" + (a + 4));
                GW_TOTAL.Font.Bold = true;
                GW_TOTAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                GW_TOTAL.Font.Size = 12;
                GW_TOTAL.Cells.Font.FontStyle = "新細明體";
                GW_TOTAL.Value2 = "G.W = " + Math.Round(sumGW + sumGW_2, 2).ToString() + " KGS";

                COMExcel.Range TITTEL = IV.get_Range("D" + (a + 5), "H" + (a + 5));
                TITTEL.Merge();
                TITTEL.Font.Bold = true;
                TITTEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TITTEL.Font.Size = 12;
                TITTEL.Cells.Font.FontStyle = "新細明體";
                TITTEL.Font.Bold = true;
                TITTEL.Value2 = "WEI TAI VIETNAM LEATHER CO., LTD";

                app.Visible = true;
                app.Quit();
                conn.releaseObject(book);
                conn.releaseObject(app);
            }

        }
        private void xuatExcel_PackingList1(string workbookPath, string filePath)
        {
            if (conn.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    File.Copy(workbookPath, filePath, true);
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file excel");
                    return;
                }
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                #region Worksheets1------------
                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

             
                COMExcel.Range INVOICE = IV.get_Range("A5", "E5");
                INVOICE.Merge();
                INVOICE.Value2 = "INVOICE NO: " + txtInvoice.Text.ToUpper();

                COMExcel.Range DATE = IV.get_Range("F5", "H5");
                DATE.Merge();
                DATE.Value2 = "DATE: " + date_add.ToUpper();

                COMExcel.Range C_NAME = IV.get_Range("A6", "H6");
                C_NAME.Merge();
                C_NAME.Value2 = "For account and risk of Mesrs: " + txtC_NAME.Text.ToUpper();

                COMExcel.Range ADR = IV.get_Range("A7", "H8");
                ADR.Merge();
                ADR.WrapText = true;
                ADR.Value2 = "Address: " + txtADR.Text.ToUpper();

                COMExcel.Range TEL = IV.get_Range("A9", "C9");
                TEL.Merge();
                TEL.Value2 = "TEL: " + txtTEL.Text;

                COMExcel.Range FAX = IV.get_Range("E9", "H9");
                FAX.Merge();
                FAX.Value2 = "FAX: " + txtFAX.Text;

                COMExcel.Range Shipby = IV.get_Range("A10", "H10");
                Shipby.Merge();
                Shipby.Value2 = "Shipped by: " + txtShip.Text.ToUpper();

                COMExcel.Range Address = IV.get_Range("A11", "H11");
                Address.WrapText = true;
                Address.Merge();
                Address.Value2 = "Address: " + txtAd.Text.ToUpper();

                COMExcel.Range Temp = IV.get_Range("A12", "H12");
                Temp.Merge();
                Temp.Value2 = "Term of delivery: " + TERM_OF.ToUpper();

                COMExcel.Range to = IV.get_Range("A13", "C13");
                to.Merge();
                to.Value2 = "TO : " + txtTo.Text.ToUpper();

                COMExcel.Range FROM = IV.get_Range("E13", "H13");
                FROM.Merge();
                FROM.Value2 = "FROM : " + txtFr.Text.ToUpper();

                int a = 16;
                double sumQTY = 0;
                double sumNW = 0;
                double sumGW = 0;
                double NO = 0;
                double sumM2 = 0;

                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                    CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.Merge();
                    CNO.Value2 = DGV1.Rows[i].Cells["CNO"].Value.ToString();

                    COMExcel.Range OR_NO = IV.get_Range("B" + a, "B" + a);
                    OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.Merge();
                    OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                    COMExcel.Range DESCRIPTION = IV.get_Range("C" + a, "C" + a);
                    DESCRIPTION.Merge();
                    DESCRIPTION.WrapText = true;
                    DESCRIPTION.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                    COMExcel.Range THICKNESS = IV.get_Range("D" + a, "D" + a);
                    THICKNESS.Merge();
                    THICKNESS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                    COMExcel.Range QTY = IV.get_Range("E" + a, "E" + a);
                    QTY.Merge();
                    QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.NumberFormat = "#,##0.00";
                    QTY.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();

                    COMExcel.Range NPL2 = IV.get_Range("F" + a, "F" + a);
                    NPL2.Merge();
                    NPL2.NumberFormat = "#,##0.00";
                    NPL2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL2.Value2 = Math.Round(HANG_SO * double.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);


                    COMExcel.Range NW = IV.get_Range("G" + a, "G" + a);
                    NW.Merge();
                    NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW.NumberFormat = "#,##0.00";
                    NW.Value2 = DGV1.Rows[i].Cells["NW"].Value.ToString();

                    COMExcel.Range GW = IV.get_Range("H" + a, "H" + a);
                    GW.Merge();
                    GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW.NumberFormat = "#,##0.00";
                    GW.Value2 = DGV1.Rows[i].Cells["GW"].Value.ToString();

                    sumM2 += (HANG_SO * float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()));
                    sumQTY += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                    sumGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                    NO += float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString());

                    a++;
                }

                COMExcel.Range SUMNO = IV.get_Range("A" + a, "A" + a);
                SUMNO.Merge();
                SUMNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                SUMNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                SUMNO.Value2 = NO;

                COMExcel.Range sumQTY_2 = IV.get_Range("E" + a, "E" + a);
                sumQTY_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumQTY_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumQTY_2.Merge();
                sumQTY_2.NumberFormat = "#,##0.00";
                sumQTY_2.Value2 = sumQTY;

                COMExcel.Range NPL = IV.get_Range("F" + a, "F" + a);
                NPL.Merge();
                NPL.NumberFormat = "#,##0.00";
                NPL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                NPL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                NPL.Value2 = Math.Round(sumM2,2);

                COMExcel.Range sumNW_2 = IV.get_Range("G" + a, "G" + a);
                sumNW_2.Merge();
                sumNW_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumNW_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumNW_2.NumberFormat = "#,##0.00";
                sumNW_2.Value2 = Math.Round(sumNW, 2);

                COMExcel.Range sumGW_2 = IV.get_Range("H" + a, "H" + a);
                sumGW_2.Merge();
                sumGW_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumGW_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumGW_2.NumberFormat = "#,##0.00";
                sumGW_2.Value2 = Math.Round(sumGW, 2);

                IV.get_Range("A" + a, "H" + a).Cells.BorderAround();

                COMExcel.Range TOTAL = IV.get_Range("A" + (a + 2), "H" + (a + 2));
                TOTAL.Merge();
                TOTAL.Font.Name = "Times New Roman";
                TOTAL.Value2 = "TOTAL: " + Math.Round(sumQTY, 2).ToString() + " ROLLS";

                COMExcel.Range NW_TOTAL = IV.get_Range("A" + (a + 3), "H" + (a + 3));
                NW_TOTAL.Merge();
                NW_TOTAL.Font.Name = "Times New Roman";
                NW_TOTAL.Value2 = "N.W: " + Math.Round(sumNW, 2).ToString() + " KGS";

                COMExcel.Range GW_TOTAL = IV.get_Range("A" + (a + 4), "H" + (a + 4));
                GW_TOTAL.Merge();
                GW_TOTAL.Font.Name = "Times New Roman";
                GW_TOTAL.Value2 = "G.W: " + Math.Round(sumGW,2).ToString() + " KGS";

                COMExcel.Range TILTE = IV.get_Range("D" + (a + 6), "H" + (a + 6));
                TILTE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TILTE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TILTE.Merge();
                TILTE.Font.Name = "Times New Roman";
                TILTE.Value2 = "WEITAI VIET NAM LEARTHER CO.,LTD";

                //check open excel
                app.Visible = true;
                app.Quit();
                conn.releaseObject(book);
                conn.releaseObject(app);

                #endregion
            }
        }
        private void xuatExcel_PackingList2(string workbookPath, string filePath)
        {
            if (conn.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    File.Copy(workbookPath, filePath, true);
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file excel");
                    return;
                }
                //1
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;
                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                #region Worksheets1------------
                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range INVOICE = IV.get_Range("A5", "E5");
                INVOICE.Merge();
                INVOICE.Value2 = "INVOICE NO: " + txtInvoice.Text.ToUpper();

                COMExcel.Range DATE = IV.get_Range("F5", "H5");
                DATE.Merge();
                DATE.Value2 = "DATE: " + date_add.ToUpper();

                COMExcel.Range C_NAME = IV.get_Range("A6", "H6");
                C_NAME.Merge();
                C_NAME.Value2 = "For account and risk of Mesrs: " + txtC_NAME.Text.ToUpper();

                COMExcel.Range ADR = IV.get_Range("A7", "H8");
                ADR.Merge();
                ADR.WrapText = true;
                ADR.Value2 = "Address: " + txtADR.Text.ToUpper();

                COMExcel.Range TEL = IV.get_Range("A9", "C9");
                TEL.Merge();
                TEL.Value2 = "TEL: " + txtTEL.Text;

                COMExcel.Range FAX = IV.get_Range("E9", "H9");
                FAX.Merge();
                FAX.Value2 = "FAX: " + txtFAX.Text;

                COMExcel.Range Shipby = IV.get_Range("A10", "H10");
                Shipby.Merge();
                Shipby.Value2 = "Shipped by: " + txtShip.Text.ToUpper();

                COMExcel.Range Address = IV.get_Range("A11", "H11");
                Address.WrapText = true;
                Address.Merge();
                Address.Value2 = "Address: " + txtAd.Text.ToUpper();

                COMExcel.Range to = IV.get_Range("A12", "C12");
                to.Merge();
                to.Value2 = "TO : " + txtTo.Text.ToUpper();

                COMExcel.Range FROM = IV.get_Range("E12", "H12");
                FROM.Merge();
                FROM.Value2 = "FROM : " + txtFr.Text.ToUpper();

                int a = 15;
                float sumQTY = 0;
                float sumNW = 0;
                float sumGW = 0;
                float NO = 0;
                string key1 = "", key2 = "";
                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                    CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.Merge();
                    CNO.Value2 = DGV1.Rows[i].Cells["CNO"].Value.ToString();

                    //xuwr ly catws chuooi
                    string sql = "SELECT * FROM dbo.SplitString('" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "','/')";
                    DataTable data2 = new DataTable();
                    data2 = conn.readdata(sql);
                    if (data2.Rows.Count > 0)
                    {
                        key1 = data2.Rows[0]["Items"].ToString();
                        key2 = data2.Rows[0]["Items2"].ToString();
                    }
                    else
                    {
                        key1 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();
                        key2 = "";
                    }
                    COMExcel.Range OR_NO = IV.get_Range("B" + a, "B" + a);
                    OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.Merge();
                    OR_NO.Value2 = key1;

                    COMExcel.Range DESCRIPTION = IV.get_Range("C" + a, "C" + a);
                    DESCRIPTION.Merge();
                    DESCRIPTION.WrapText = true;
                    DESCRIPTION.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                    COMExcel.Range NPL = IV.get_Range("D" + a, "D" + a);
                    NPL.Merge();
                    NPL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.Value2 = key2;

                    COMExcel.Range THICKNESS = IV.get_Range("E" + a, "E" + a);
                    THICKNESS.Merge();
                    THICKNESS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                    COMExcel.Range QTY = IV.get_Range("F" + a, "F" + a);
                    QTY.Merge();
                    QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.NumberFormat = "#,##0.00";
                    QTY.Value2 = DGV1.Rows[i].Cells["BQTY"].Value.ToString();

                    COMExcel.Range NW = IV.get_Range("G" + a, "G" + a);
                    NW.Merge();
                    NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NW.NumberFormat = "#,##0.00";
                    NW.Value2 = DGV1.Rows[i].Cells["NW"].Value.ToString();

                    COMExcel.Range GW = IV.get_Range("H" + a, "H" + a);
                    GW.Merge();
                    GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    GW.NumberFormat = "#,##0.00";
                    GW.Value2 = DGV1.Rows[i].Cells["GW"].Value.ToString();

                    sumQTY += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                    sumGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                    NO += float.Parse(DGV1.Rows[i].Cells["CNO"].Value.ToString());

                    a++;
                }

                COMExcel.Range SUMNO = IV.get_Range("A" + a, "A" + a);
                SUMNO.Merge();
                SUMNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                SUMNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                SUMNO.Value2 = NO;

                COMExcel.Range sumQTY_2 = IV.get_Range("F" + a, "F" + a);
                sumQTY_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumQTY_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumQTY_2.Merge();
                sumQTY_2.NumberFormat = "#,##0.00";
                sumQTY_2.Value2 = sumQTY;

                COMExcel.Range sumNW_2 = IV.get_Range("G" + a, "G" + a);
                sumNW_2.Merge();
                sumNW_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumNW_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumNW_2.NumberFormat = "#,##0.00";
                sumNW_2.Value2 = sumNW;

                COMExcel.Range sumGW_2 = IV.get_Range("H" + a, "H" + a);
                sumGW_2.Merge();
                sumGW_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumGW_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                sumGW_2.NumberFormat = "#,##0.00";
                sumGW_2.Value2 = sumGW;

                IV.get_Range("A" + a, "H" + a).Cells.BorderAround();

                COMExcel.Range TOTAL = IV.get_Range("A" + (a + 2), "H" + (a + 2));
                TOTAL.Merge();
                TOTAL.Font.Name = "Times New Roman";
                TOTAL.Value2 = "TOTAL: " + string.Format(sumQTY.ToString(), "#,##0.00") + " ROLLS";

                COMExcel.Range NW_TOTAL = IV.get_Range("A" + (a + 3), "H" + (a + 3));
                NW_TOTAL.Merge();
                NW_TOTAL.Font.Name = "Times New Roman";
                NW_TOTAL.Value2 = "N.W: " + string.Format(sumNW.ToString(), "#,##0.00") + " KGS";

                COMExcel.Range GW_TOTAL = IV.get_Range("A" + (a + 4), "H" + (a + 4));
                GW_TOTAL.Merge();
                GW_TOTAL.Font.Name = "Times New Roman";
                GW_TOTAL.Value2 = "G.W: " + string.Format(sumGW.ToString(), "#,##0.00") + " KGS";

                COMExcel.Range TILTE = IV.get_Range("D" + (a + 6), "H" + (a + 6));
                TILTE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TILTE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TILTE.Merge();
                TILTE.Font.Name = "Times New Roman";
                TILTE.Value2 = "WEITAI VIET NAM LEARTHER CO.,LTD";

                //check open excel
                app.Visible = true;
                app.Quit();
                conn.releaseObject(book);
                conn.releaseObject(app);

                #endregion
            }
        }
        private void xuatExcel_Invoice_NuocNgoai(string workbookPath, string filePath)
        {
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    //1
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                    #region Worksheets1------------
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    COMExcel.Range C_NAME = IV.get_Range("A4", "D4");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3 = IV.get_Range("A5", "D6");
                    ARD3.Merge();
                    ARD3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3.WrapText = true;
                    ARD3.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE = IV.get_Range("F4", "H4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = date_add;

                    COMExcel.Range INVOICE = IV.get_Range("E5", "H5");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE#: " + txtInvoice.Text;

                    COMExcel.Range BYair = IV.get_Range("E6", "F6");
                    BYair.Merge();
                    BYair.Font.Bold = true;
                    BYair.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair.Value2 = txtByAir.Text;

                    //chị trâm nhỏ
                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAX ID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "D7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV.get_Range("A8", "D8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN = IV.get_Range("A9", "H9");
                    ATTN.Merge();
                    ATTN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN.Value2 = "ATTN: " + txtATTN.Text;

                    COMExcel.Range TEL = IV.get_Range("A10", "D10");
                    TEL.Merge();
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range FAX = IV.get_Range("E10", "H10");
                    FAX.Merge();
                    FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FAX.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FAX.Value2 = "FAX: " + txtFAX.Text;

                    if (cbRutGon.Checked == false)
                    {
                        COMExcel.Range SHIP = IV.get_Range("A11", "H11");
                        SHIP.Merge();
                        SHIP.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        SHIP.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SHIP.Value2 = "Shipped by: " + txtShip.Text;

                        COMExcel.Range AD = IV.get_Range("A12", "H12");
                        AD.Merge();
                        AD.WrapText = true;
                        AD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        AD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AD.Value2 = "Address: " + txtAd.Text;
                        AD.RowHeight = 30;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV.get_Range("A11", "H11");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV.get_Range("A12", "H12");
                        HSCODE.EntireRow.Hidden = true;
                    }    
                    COMExcel.Range FROMTAB1 = IV.get_Range("A13", "C13");
                    FROMTAB1.Merge();
                    FROMTAB1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1.Value2 = "From: " + txtFr.Text;

                    if (cbRutGon.Checked == false)
                    {
                        COMExcel.Range TOTAB = IV.get_Range("E13", "H13");
                        TOTAB.Merge();
                        TOTAB.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TOTAB.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TOTAB.Value2 = "To: " + txtTo.Text;
                    }   
                    
                    COMExcel.Range K_NAME = IV.get_Range("A16", "A16");
                    K_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME.Font.Bold = true;
                    K_NAME.Merge();
                    K_NAME.Value2 = "COW SPLIT LEATHER";

                    int a = 17;
                    float sumQty = 0;
                    float sumAmount = 0;

                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        OR_NO.WrapText = true;
                        OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.Font.Size = 8;
                        OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.WrapText = true;
                        COLOR.Rows.AutoFit();
                        COLOR.Font.Size = 8;
                        COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();


                        if (txtCheckCountry.Checked == true)
                        {
                            //row 20
                            COMExcel.Range HSCODE = IV.get_Range("C" + a, "C" + a);
                            HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            HSCODE.WrapText = true;
                            HSCODE.Font.Size = 8;
                            HSCODE.Value2 = HS_CODE;

                            //row 20
                            COMExcel.Range COUNTRY = IV.get_Range("D" + a, "D" + a);
                            COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COUNTRY.WrapText = true;
                            COUNTRY.Font.Size = 8;
                            COUNTRY.Value2 = key_Country;

                        }
                        //row 20
                        COMExcel.Range THICK = IV.get_Range("E" + a, "E" + a);
                        THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.Font.Size = 8;
                        THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        //Quantity
                        COMExcel.Range BQTY = IV.get_Range("F" + a, "F" + a);
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Size = 8;
                        BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                        //price
                        COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                        PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.Font.Size = 8;
                        PRICE.NumberFormat = "[$USD] #,##0.00";
                        PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                        //total
                        COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                        AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AMOUNT.Font.Size = 8;
                        AMOUNT.NumberFormat = "[$USD] #,##0.00";
                        AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                        sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                        a++;
                    }

                    COMExcel.Range T1 = IV.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1.Font.Bold = true;
                    T1.Font.Size = 10;
                    T1.Value2 = "TOTAL";

                    COMExcel.Range T2 = IV.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2.Font.Bold = true;
                    T2.Font.Size = 10;
                    T2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3 = IV.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3.Font.Bold = true;
                    T3.Font.Size = 10;
                    T3.NumberFormat = "[$USD] #,##0.00";
                    T3.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    if (cbRutGon.Checked == false)
                    {
                        COMExcel.Range A5 = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                        A5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        A5.Font.Size = 10;
                        A5.Cells.Font.FontStyle = "新細明體";
                        A5.Value2 = "FOB HCM";
                    }
                    else
                    {
                        a = a - 1;
                    }    
                    COMExcel.Range A6 = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                    A6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A6.Font.Size = 10;
                    A6.Cells.Font.FontStyle = "新細明體";
                    A6.Value2 = "PAYMENT FOR GOODS ";
                    //row 24
                    COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100.Font.Size = 10;
                    A100.Cells.Font.FontStyle = "新細明體";
                    A100.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7.WrapText = false;
                    A7.Font.Size = 10;
                    A7.Cells.Font.FontStyle = "新細明體";
                    A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8.WrapText = false;
                    A8.Font.Size = 10;
                    A8.Cells.Font.FontStyle = "新細明體";
                    A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9.WrapText = false;
                    A9.Font.Size = 10;
                    A9.Cells.Font.FontStyle = "新細明體";
                    A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank.Font.Size = 10;
                    bank.Cells.Font.FontStyle = "新細明體";
                    bank.Value2 = "BANK NAME: ";

                    COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10.Font.Size = 10;
                    A10.Cells.Font.FontStyle = "新細明體";
                    A10.WrapText = false;
                    A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount.Font.Size = 10;
                    Acount.Cells.Font.FontStyle = "新細明體";
                    Acount.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11.Font.Size = 10;
                    A11.Cells.Font.FontStyle = "新細明體";
                    A11.WrapText = false;
                    A11.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift.Font.Size = 10;
                    Swift.Cells.Font.FontStyle = "新細明體";
                    Swift.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12.Font.Size = 10;
                    A12.Cells.Font.FontStyle = "新細明體";
                    A12.WrapText = false;
                    A12.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress.Font.Size = 10;
                    bankAddress.Cells.Font.FontStyle = "新細明體";
                    bankAddress.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13.Font.Size = 10;
                    A13.Cells.Font.FontStyle = "新細明體";
                    A13.WrapText = false;
                    A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14.Font.Size = 10;
                    A14.Cells.Font.FontStyle = "新細明體";
                    A14.WrapText = false;
                    A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15 = IV.get_Range("D" + (a + 11) + "", "F" + (a + 11) + "");
                    A15.Font.Size = 10;
                    A15.Cells.Font.FontStyle = "新細明體";
                    A15.Merge();
                    A15.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    #endregion

                    //2
                    if (txtCheckCountry.Checked == false)
                    {
                        IV.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;

                        COMExcel.Range A16 = IV.get_Range("C" + (a + 11) + "", "E" + (a + 11) + "");
                        A16.Font.Size = 10;
                        A16.Cells.Font.FontStyle = "新細明體";
                        A16.Merge();
                        A16.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    }
                    app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);
                }
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        private void xuatExcel_Invoice_NuocNgoai_Chitiet(string workbookPath, string filePath)
        {
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    //1
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                    
                    #region Worksheets1------------
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    COMExcel.Range C_NAME = IV.get_Range("A4", "D4");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3 = IV.get_Range("A5", "D6");
                    ARD3.Merge();
                    ARD3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3.WrapText = true;
                    ARD3.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE = IV.get_Range("F4", "H4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = date_add;

                    COMExcel.Range INVOICE = IV.get_Range("E5", "H5");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE#: " + txtInvoice.Text;

                    COMExcel.Range BYair = IV.get_Range("E6", "H6");
                    BYair.Merge();
                    BYair.Font.Bold = true;
                    BYair.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair.Value2 = txtByAir.Text;

                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAXID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN = IV.get_Range("A9", "H9");
                    ATTN.Merge();
                    ATTN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN.Value2 = "ATTN: " + txtATTN.Text;

                    COMExcel.Range TEL = IV.get_Range("A10", "H10");
                    TEL.Merge();
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range FAX = IV.get_Range("E10", "H10");
                    FAX.Merge();
                    FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FAX.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FAX.Value2 = "FAX: " + txtFAX.Text;

                    COMExcel.Range SHIP = IV.get_Range("A11", "H11");
                    SHIP.Merge();
                    SHIP.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIP.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIP.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range AD = IV.get_Range("A12", "H12");
                    AD.Merge();
                    AD.WrapText = true;
                    AD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    AD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AD.Value2 = "Address: " + txtAd.Text;
                    AD.RowHeight = 30;

                    COMExcel.Range FROMTAB1 = IV.get_Range("A13", "C13");
                    FROMTAB1.Merge();
                    FROMTAB1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1.Value2 = "From: " + txtFr.Text;

                    COMExcel.Range ToTabv = IV.get_Range("E13", "H13");
                    ToTabv.Merge();
                    ToTabv.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ToTabv.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ToTabv.Value2 = "To: " + txtTo.Text;

                    COMExcel.Range K_NAME = IV.get_Range("A16", "A16");
                    K_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME.Font.Bold = true;
                    K_NAME.Merge();
                    K_NAME.Value2 = "COW SPLIT LEATHER";

                    int a = 17;
                    float sumQty = 0;
                    float sumAmount = 0;

                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "False")
                        {
                            //row 16
                            COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                            OR_NO.WrapText = true;
                            OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.Font.Size = 8;
                            OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                            //row 20
                            COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);
                            COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.WrapText = true;
                            COLOR.Font.Size = 8;
                            COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                            if (txtCheckCountry.Checked == true)
                            {
                                //row 20
                                COMExcel.Range HSCODE = IV.get_Range("C" + a, "C" + a);
                                HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.WrapText = true;
                                HSCODE.Font.Size = 8;
                                HSCODE.Value2 = HS_CODE;

                                //row 20
                                COMExcel.Range COUNTRY = IV.get_Range("D" + a, "D" + a);
                                COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.WrapText = true;
                                COUNTRY.Font.Size = 8;
                                COUNTRY.Value2 = key_Country;
                            }
                            //row 20
                            COMExcel.Range THICK = IV.get_Range("E" + a, "E" + a);
                            THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.Font.Size = 8;
                            THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                            //Quantity
                            COMExcel.Range BQTY = IV.get_Range("F" + a, "F" + a);
                            BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.Font.Size = 8;
                            BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                            //price
                            COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                            PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.Font.Size = 8;
                            PRICE.NumberFormat = "[$USD] #,##0.00";
                            PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                            //total
                            COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                            AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            AMOUNT.Font.Size = 8;
                            AMOUNT.NumberFormat = "[$USD] #,##0.00";
                            AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                            sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                            sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                            a++;
                        }
                    }
                    COMExcel.Range T1 = IV.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1.Font.Bold = true;
                    T1.Font.Size = 10;
                    T1.Value2 = "TOTAL";

                    COMExcel.Range T2 = IV.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2.Font.Bold = true;
                    T2.Font.Size = 10;
                    T2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3 = IV.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3.Font.Bold = true;
                    T3.Font.Size = 10;
                    T3.NumberFormat = "[$USD] #,##0.00";
                    T3.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    COMExcel.Range A5 = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                    A5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    A5.Font.Size = 10;
                    A5.Cells.Font.FontStyle = "新細明體";
                    A5.Value2 = "FOB HCM";

                    COMExcel.Range A6 = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                    A6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A6.Font.Size = 10;
                    A6.Cells.Font.FontStyle = "新細明體";
                    A6.Value2 = "PAYMENT FOR GOODS ";
                    //row 24
                    COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100.Font.Size = 10;
                    A100.Cells.Font.FontStyle = "新細明體";
                    A100.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7.WrapText = false;
                    A7.Font.Size = 10;
                    A7.Cells.Font.FontStyle = "新細明體";
                    A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8.WrapText = false;
                    A8.Font.Size = 10;
                    A8.Cells.Font.FontStyle = "新細明體";
                    A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9.WrapText = false;
                    A9.Font.Size = 10;
                    A9.Cells.Font.FontStyle = "新細明體";
                    A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank.Font.Size = 10;
                    bank.Cells.Font.FontStyle = "新細明體";
                    bank.Value2 = "BANK NAME: ";

                    COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10.Font.Size = 10;
                    A10.Cells.Font.FontStyle = "新細明體";
                    A10.WrapText = false;
                    A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount.Font.Size = 10;
                    Acount.Cells.Font.FontStyle = "新細明體";
                    Acount.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11.Font.Size = 10;
                    A11.Cells.Font.FontStyle = "新細明體";
                    A11.WrapText = false;
                    A11.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift.Font.Size = 10;
                    Swift.Cells.Font.FontStyle = "新細明體";
                    Swift.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12.Font.Size = 10;
                    A12.Cells.Font.FontStyle = "新細明體";
                    A12.WrapText = false;
                    A12.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress.Font.Size = 10;
                    bankAddress.Cells.Font.FontStyle = "新細明體";
                    bankAddress.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13.Font.Size = 10;
                    A13.Cells.Font.FontStyle = "新細明體";
                    A13.WrapText = false;
                    A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14.Font.Size = 10;
                    A14.Cells.Font.FontStyle = "新細明體";
                    A14.WrapText = false;
                    A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15 = IV.get_Range("D" + (a + 11) + "", "F" + (a + 11) + "");
                    A15.Font.Size = 10;
                    A15.Cells.Font.FontStyle = "新細明體";
                    A15.Merge();
                    A15.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                    IV.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    if (txtCheckCountry.Checked == false)
                    {
                        IV.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;

                        COMExcel.Range A16 = IV.get_Range("C" + (a + 11) + "", "E" + (a + 11) + "");
                        A16.Font.Size = 10;
                        A16.Cells.Font.FontStyle = "新細明體";
                        A16.Merge();
                        A16.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    }

                    #endregion

                    //2
                    COMExcel.Worksheet IV_2 = (COMExcel.Worksheet)book.Worksheets[2];

                    COMExcel.Range C_NAME_2 = IV_2.get_Range("A4", "D4");
                    C_NAME_2.Merge();
                    C_NAME_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME_2.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3_2 = IV_2.get_Range("A5", "D6");
                    ARD3_2.Merge();
                    ARD3_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3_2.WrapText = true;
                    ARD3_2.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE_2 = IV_2.get_Range("F4", "H4");
                    DATE_2.Merge();
                    DATE_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE_2.Value2 = date_add;

                    COMExcel.Range INVOICE_3 = IV_2.get_Range("E5", "H5");
                    INVOICE_3.Merge();
                    INVOICE_3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE_3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE_3.Value2 = "INVOICE#: " + txtInvoice.Text;

                    COMExcel.Range BYair_2 = IV_2.get_Range("E6", "H6");
                    BYair_2.Merge();
                    BYair_2.Font.Bold = true;
                    BYair_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair_2.Value2 = txtByAir.Text;

                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV_2.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAXID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV_2.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV_2.get_Range("A7", "H7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV_2.get_Range("A8", "H8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN_2 = IV_2.get_Range("A9", "H9");
                    ATTN_2.Merge();
                    ATTN_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN_2.Value2 = "ATTN: " + txtATTN.Text;

                    COMExcel.Range TEL_2 = IV_2.get_Range("A10", "D10");
                    TEL_2.Merge();
                    TEL_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL_2.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range SHIP_2 = IV_2.get_Range("A11", "H11");
                    SHIP_2.Merge();
                    SHIP_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIP_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIP_2.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range AD_2 = IV_2.get_Range("A12", "H12");
                    AD_2.Merge();
                    AD_2.WrapText = true;
                    AD_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    AD_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AD_2.Value2 = "Address: " + txtAd.Text;
                    AD_2.RowHeight = 30;

                    COMExcel.Range FROMTAB1_2 = IV_2.get_Range("A13", "C13");
                    FROMTAB1_2.Merge();
                    FROMTAB1_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1_2.Value2 = "From: " + txtFr.Text;

                    COMExcel.Range FROMTAB = IV_2.get_Range("E13", "H13");
                    FROMTAB.Merge();
                    FROMTAB.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB.Value2 = "To: " + txtTo.Text;

                    COMExcel.Range K_NAME_2 = IV_2.get_Range("A16", "A16");
                    K_NAME_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME_2.Font.Bold = true;
                    K_NAME_2.Merge();
                    K_NAME_2.Value2 = "COW SPLIT LEATHER";

                    a = 17;
                    sumQty = 0;
                    sumAmount = 0;
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "True")
                        {
                            //row 16
                            COMExcel.Range OR_NO = IV_2.get_Range("A" + a, "A" + a);
                            OR_NO.WrapText = true;
                            OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.Font.Size = 8;
                            OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                            //row 20
                            COMExcel.Range COLOR = IV_2.get_Range("B" + a, "B" + a);
                            COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.WrapText = true;
                            COLOR.Font.Size = 8;
                            COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();


                            if (txtCheckCountry.Checked == true)
                            {
                                //row 20
                                COMExcel.Range HSCODE = IV_2.get_Range("C" + a, "C" + a);
                                HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.WrapText = true;
                                HSCODE.Font.Size = 8;
                                HSCODE.Value2 = HS_CODE;

                                //row 20
                                COMExcel.Range COUNTRY = IV_2.get_Range("D" + a, "D" + a);
                                COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.WrapText = true;
                                COUNTRY.Font.Size = 8;
                                COUNTRY.Value2 = key_Country;

                            }
                            //row 20
                            COMExcel.Range THICK = IV_2.get_Range("E" + a, "E" + a);
                            THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.Font.Size = 8;
                            THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                            //Quantity
                            COMExcel.Range BQTY = IV_2.get_Range("F" + a, "F" + a);
                            BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.Font.Size = 8;
                            BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                            //price
                            COMExcel.Range PRICE = IV_2.get_Range("G" + a, "G" + a);
                            PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.Font.Size = 8;
                            PRICE.NumberFormat = "[$USD] #,##0.00";
                            PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                            //total
                            COMExcel.Range AMOUNT = IV_2.get_Range("H" + a, "H" + a);
                            AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            AMOUNT.Font.Size = 8;
                            AMOUNT.NumberFormat = "[$USD] #,##0.00";
                            AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                            sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                            sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                            a++;
                        }
                    }
                    COMExcel.Range T1_1 = IV_2.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1_1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1_1.Font.Bold = true;
                    T1_1.Font.Size = 10;
                    T1_1.Value2 = "TOTAL";

                    COMExcel.Range T2_1 = IV_2.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2_1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2_1.Font.Bold = true;
                    T2_1.Font.Size = 10;
                    T2_1.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3_2 = IV_2.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3_2.Font.Bold = true;
                    T3_2.Font.Size = 10;
                    T3_2.NumberFormat = "[$USD] #,##0.00";
                    T3_2.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV_2.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;

                    COMExcel.Range T1_2 = IV_2.get_Range("B" + (a + 1) + "", "B" + (a + 1) + "");
                    T1_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1_2.Font.Bold = true;
                    T1_2.Font.Size = 10;
                    T1_2.Value2 = "FOC MATERIAL";

                    COMExcel.Range T3_3 = IV_2.get_Range("H" + (a + 1) + "", "H" + (a + 1) + "");
                    T3_3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3_3.Font.Bold = true;
                    T3_3.Font.Size = 10;
                    T3_3.NumberFormat = "[$USD] #,##0.00";
                    T3_3.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV_2.get_Range("B" + (a + 1) + "", "" + key_Border + "" + (a + 1) + "").Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = 2d;

                    COMExcel.Range T1_3 = IV_2.get_Range("B" + (a + 2) + "", "B" + (a + 2) + "");
                    T1_3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1_3.Font.Bold = true;
                    T1_3.Font.Size = 10;
                    T1_3.Value2 = "SUB TOTAL";


                    COMExcel.Range T3_5 = IV_2.get_Range("H" + (a + 2) + "", "H" + (a + 2) + "");
                    T3_5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3_5.Font.Bold = true;
                    T3_5.Font.Size = 10;
                    T3_5.NumberFormat = "[$USD] #,##0.00";
                    T3_5.Value2 = "=H" + a + "- H" + (a + 1) + "";

                    if (txtCheckCountry.Checked == false)
                    {
                        IV_2.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV_2.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV_2.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV_2.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;
                    }

                    app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);
                }
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        private void Export_Excel_BillTo_NuocNgoai(string workbookPath, string filePath)
        {
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);
                   
                    #region Worksheets1------------
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    COMExcel.Range C_NAME = IV.get_Range("A4", "D4");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3 = IV.get_Range("A5", "D6");
                    ARD3.Merge();
                    ARD3.WrapText = true;
                    ARD3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE = IV.get_Range("F4", "H4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = date_add;

                    COMExcel.Range INVOICE = IV.get_Range("E5", "H5");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE#:" + txtInvoice.Text;

                    COMExcel.Range BYair = IV.get_Range("E6", "H6");
                    BYair.Merge();
                    BYair.Font.Bold = true;
                    BYair.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair.Value2 = txtByAir.Text;

                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAXID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN = IV.get_Range("A9", "H9");
                    ATTN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN.Merge();
                    ATTN.Value2 = "ATTN:" + txtATTN.Text;

                    COMExcel.Range TEL = IV.get_Range("A10", "D10");
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Merge();
                    TEL.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range FAX = IV.get_Range("E10", "H10");
                    FAX.Merge();
                    FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FAX.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FAX.Value2 = "FAX: " + txtFAX.Text;

                    COMExcel.Range Billto = IV.get_Range("A11", "H11");
                    Billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Billto.Merge();
                    Billto.Value2 = Title_2 + txtBillto.Text;

                    COMExcel.Range add = IV.get_Range("A12", "H12");
                    add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    add.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    add.Merge();
                    add.Value2 = "Address: " + txtAddress_billto.Text;

                    COMExcel.Range ATTN_billto = IV.get_Range("A13", "H13");
                    ATTN_billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN_billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN_billto.Merge();
                    ATTN_billto.Value2 = "ATTN: " + txtATTN_Billto.Text;

                    COMExcel.Range Tel_billto = IV.get_Range("A14", "H14");
                    Tel_billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Tel_billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Tel_billto.Merge();
                    Tel_billto.Value2 = "TEL: " + txtTEL_Billto.Text;

                    COMExcel.Range SHIP = IV.get_Range("A15", "H15");
                    SHIP.Merge();
                    SHIP.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIP.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIP.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range AD = IV.get_Range("A16", "H16");
                    AD.Merge();
                    AD.WrapText = true;
                    AD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    AD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AD.Value2 = "Address: " + txtAd.Text;
                    AD.RowHeight = 30;

                    COMExcel.Range FROMTAB1 = IV.get_Range("A17", "C17");
                    FROMTAB1.Merge();
                    FROMTAB1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1.Value2 = "From: " + txtFr.Text;

                    COMExcel.Range TOTAB = IV.get_Range("E17", "F17");
                    TOTAB.Merge();
                    TOTAB.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TOTAB.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TOTAB.Value2 = "To: " + txtTo.Text;

                    COMExcel.Range K_NAME = IV.get_Range("A20", "A20");
                    K_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME.Font.Bold = true;
                    K_NAME.Merge();
                    K_NAME.Value2 = "COW SPLIT LEATHER";


                    int a = 21;
                    float sumQty = 0;
                    float sumAmount = 0;


                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        OR_NO.WrapText = true;
                        OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        OR_NO.Font.Size = 8;
                        OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);
                        COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLOR.WrapText = true;
                        COLOR.Font.Size = 8;
                        COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                        if (txtCheckCountry.Checked == true)
                        {
                            //row 20
                            COMExcel.Range HSCODE = IV.get_Range("C" + a, "C" + a);
                            HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            HSCODE.WrapText = true;
                            HSCODE.Font.Size = 8;
                            HSCODE.Value2 = HS_CODE;

                            //row 20
                            COMExcel.Range COUNTRY = IV.get_Range("D" + a, "D" + a);
                            COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COUNTRY.WrapText = true;
                            COUNTRY.Font.Size = 8;
                            COUNTRY.Value2 = key_Country;


                        }
                        //row 20
                        COMExcel.Range THICK = IV.get_Range("E" + a, "E" + a);
                        THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        THICK.Font.Size = 8;
                        THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                        //Quantity
                        COMExcel.Range BQTY = IV.get_Range("F" + a, "F" + a);
                        BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        BQTY.Font.Size = 8;
                        BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                        //price
                        COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                        PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        PRICE.Font.Size = 8;
                        PRICE.NumberFormat = "[$USD] #,##0.00";
                        PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                        //total
                        COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                        AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        AMOUNT.Font.Size = 8;
                        AMOUNT.NumberFormat = "[$USD] #,##0.00";
                        AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                        sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                        sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                        a++;
                    }
                    COMExcel.Range T1 = IV.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1.Font.Bold = true;
                    T1.Font.Size = 10;
                    T1.Value2 = "TOTAL";

                    COMExcel.Range T2 = IV.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2.Font.Bold = true;
                    T2.Font.Size = 10;
                    T2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3 = IV.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3.Font.Bold = true;
                    T3.Font.Size = 10;
                    T3.NumberFormat = "[$USD] #,##0.00";
                    T3.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    COMExcel.Range A5 = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                    A5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    A5.Font.Size = 10;
                    A5.Cells.Font.FontStyle = "新細明體";
                    A5.Value2 = "FOB HCM";

                    COMExcel.Range A6 = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                    A6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A6.Font.Size = 10;
                    A6.Cells.Font.FontStyle = "新細明體";
                    A6.Value2 = "PAYMENT FOR GOODS ";
                    //row 24
                    COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100.Font.Size = 10;
                    A100.Cells.Font.FontStyle = "新細明體";
                    A100.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7.WrapText = false;
                    A7.Font.Size = 10;
                    A7.Cells.Font.FontStyle = "新細明體";
                    A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8.WrapText = false;
                    A8.Font.Size = 10;
                    A8.Cells.Font.FontStyle = "新細明體";
                    A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9.WrapText = false;
                    A9.Font.Size = 10;
                    A9.Cells.Font.FontStyle = "新細明體";
                    A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank.Font.Size = 10;
                    bank.Cells.Font.FontStyle = "新細明體";
                    bank.Value2 = "BANK NAME: ";

                    COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10.Font.Size = 10;
                    A10.Cells.Font.FontStyle = "新細明體";
                    A10.WrapText = false;
                    A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount.Font.Size = 10;
                    Acount.Cells.Font.FontStyle = "新細明體";
                    Acount.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11.Font.Size = 10;
                    A11.Cells.Font.FontStyle = "新細明體";
                    A11.WrapText = false;
                    A11.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift.Font.Size = 10;
                    Swift.Cells.Font.FontStyle = "新細明體";
                    Swift.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12.Font.Size = 10;
                    A12.Cells.Font.FontStyle = "新細明體";
                    A12.WrapText = false;
                    A12.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress.Font.Size = 10;
                    bankAddress.Cells.Font.FontStyle = "新細明體";
                    bankAddress.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13.Font.Size = 10;
                    A13.Cells.Font.FontStyle = "新細明體";
                    A13.WrapText = false;
                    A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14.Font.Size = 10;
                    A14.Cells.Font.FontStyle = "新細明體";
                    A14.WrapText = false;
                    A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15 = IV.get_Range("D" + (a + 11) + "", "F" + (a + 11) + "");
                    A15.Font.Size = 12;
                    A15.Cells.Font.FontStyle = "新細明體";
                    A15.Merge();
                    A15.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    #endregion

                    if (txtCheckCountry.Checked == false)
                    {
                        IV.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;

                        COMExcel.Range A16 = IV.get_Range("C" + (a + 11) + "", "E" + (a + 11) + "");
                        A16.Font.Size = 10;
                        A16.Cells.Font.FontStyle = "新細明體";
                        A16.Merge();
                        A16.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    }

                    app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);

                }


            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
        private void Export_Excel_BillTo_NuocNgoai_Chitiet(string workbookPath, string filePath)
        {
            try
            {
                if (conn.CheckFileOpen(filePath))
                {
                    MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                    }
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        File.Copy(workbookPath, filePath, true);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa lưu file excel");
                        return;
                    }
                    COMExcel.Application app = new COMExcel.Application();
                    object valueMissing = System.Reflection.Missing.Value;
                    COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                    false, valueMissing, valueMissing, valueMissing, valueMissing,
                    COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                    valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                    #region Worksheets1------------


                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    COMExcel.Range C_NAME = IV.get_Range("A4", "D4");
                    C_NAME.Merge();
                    C_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3 = IV.get_Range("A5", "D6");
                    ARD3.Merge();
                    ARD3.WrapText = true;
                    ARD3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE = IV.get_Range("F4", "H4");
                    DATE.Merge();
                    DATE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE.Value2 = date_add;

                    COMExcel.Range INVOICE = IV.get_Range("E5", "H5");
                    INVOICE.Merge();
                    INVOICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE.Value2 = "INVOICE#:" + txtInvoice.Text;

                    COMExcel.Range BYair = IV.get_Range("E6", "H6");
                    BYair.Merge();
                    BYair.Font.Bold = true;
                    BYair.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair.Value2 = txtByAir.Text;

                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAXID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV.get_Range("A7", "H7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV.get_Range("A8", "H8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN = IV.get_Range("A9", "H9");
                    ATTN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN.Merge();
                    ATTN.Value2 = "ATTN:" + txtATTN.Text;

                    COMExcel.Range TEL = IV.get_Range("A10", "H10");
                    TEL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL.Merge();
                    TEL.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range FAX = IV.get_Range("E10", "H10");
                    FAX.Merge();
                    FAX.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FAX.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FAX.Value2 = "FAX: " + txtFAX.Text;

                    COMExcel.Range Billto = IV.get_Range("A11", "H11");
                    Billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Billto.Merge();
                    Billto.Value2 = Title_2 + txtBillto.Text;

                    COMExcel.Range add = IV.get_Range("A12", "H12");
                    add.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    add.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    add.Merge();
                    add.Value2 = "Address: " + txtAddress_billto.Text;

                    COMExcel.Range ATTN_billto = IV.get_Range("A13", "H13");
                    ATTN_billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN_billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN_billto.Merge();
                    ATTN_billto.Value2 = "ATTN: " + txtATTN_Billto.Text;

                    COMExcel.Range Tel_billto = IV.get_Range("A14", "H14");
                    Tel_billto.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Tel_billto.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Tel_billto.Merge();
                    Tel_billto.Value2 = "TEL: " + txtTEL_Billto.Text;

                    COMExcel.Range SHIP = IV.get_Range("A15", "H15");
                    SHIP.Merge();
                    SHIP.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIP.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIP.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range AD = IV.get_Range("A16", "H16");
                    AD.Merge();
                    AD.WrapText = true;
                    AD.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    AD.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AD.Value2 = "Address: " + txtAd.Text;
                    AD.RowHeight = 30;

                    COMExcel.Range FROMTAB1 = IV.get_Range("A17", "C17");
                    FROMTAB1.Merge();
                    FROMTAB1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1.Value2 = "From: " + txtFr.Text;

                    COMExcel.Range To = IV.get_Range("E17", "H17");
                    To.Merge();
                    To.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    To.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    To.Value2 = "To: " + txtTo.Text;

                    COMExcel.Range K_NAME = IV.get_Range("A20", "A20");
                    K_NAME.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME.Font.Bold = true;
                    K_NAME.Merge();
                    K_NAME.Value2 = "COW SPLIT LEATHER";

                    int a = 21;
                    float sumQty = 0;
                    float sumAmount = 0;

                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "False")
                        {
                            //row 16
                            COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                            OR_NO.WrapText = true;
                            OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.Font.Size = 8;
                            OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                            //row 20
                            COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);
                            COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.WrapText = true;
                            COLOR.Font.Size = 8;
                            COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                            if (txtCheckCountry.Checked == true)
                            {
                                //row 20
                                COMExcel.Range HSCODE = IV.get_Range("C" + a, "C" + a);
                                HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.WrapText = true;
                                HSCODE.Font.Size = 8;
                                HSCODE.Value2 = HS_CODE;

                                //row 20
                                COMExcel.Range COUNTRY = IV.get_Range("D" + a, "D" + a);
                                COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.WrapText = true;
                                COUNTRY.Font.Size = 8;
                                COUNTRY.Value2 = key_Country;
                            }
                            //row 20
                            COMExcel.Range THICK = IV.get_Range("E" + a, "E" + a);
                            THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.Font.Size = 8;
                            THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                            //Quantity
                            COMExcel.Range BQTY = IV.get_Range("F" + a, "F" + a);
                            BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.Font.Size = 8;
                            BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                            //price
                            COMExcel.Range PRICE = IV.get_Range("G" + a, "G" + a);
                            PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.Font.Size = 8;
                            PRICE.NumberFormat = "[$USD] #,##0.00";
                            PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                            //total
                            COMExcel.Range AMOUNT = IV.get_Range("H" + a, "H" + a);
                            AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            AMOUNT.Font.Size = 8;
                            AMOUNT.NumberFormat = "[$USD] #,##0.00";
                            AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                            sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                            sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                            a++;
                        }

                    }
                    COMExcel.Range T1 = IV.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1.Font.Bold = true;
                    T1.Font.Size = 10;
                    T1.Value2 = "TOTAL";

                    COMExcel.Range T2 = IV.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2.Font.Bold = true;
                    T2.Font.Size = 10;
                    T2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3 = IV.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3.Font.Bold = true;
                    T3.Font.Size = 10;
                    T3.NumberFormat = "[$USD] #,##0.00";
                    T3.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    COMExcel.Range A5 = IV.get_Range("A" + (a + 1), "A" + (a + 1));
                    A5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    A5.Font.Size = 10;
                    A5.Cells.Font.FontStyle = "新細明體";
                    A5.Value2 = "FOB HCM";

                    COMExcel.Range A6 = IV.get_Range("A" + (a + 2), "A" + (a + 2));
                    A6.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A6.Font.Size = 10;
                    A6.Cells.Font.FontStyle = "新細明體";
                    A6.Value2 = "PAYMENT FOR GOODS ";
                    //row 24
                    COMExcel.Range A100 = IV.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100.Font.Size = 10;
                    A100.Cells.Font.FontStyle = "新細明體";
                    A100.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7 = IV.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7.WrapText = false;
                    A7.Font.Size = 10;
                    A7.Cells.Font.FontStyle = "新細明體";
                    A7.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8 = IV.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8.WrapText = false;
                    A8.Font.Size = 10;
                    A8.Cells.Font.FontStyle = "新細明體";
                    A8.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9 = IV.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9.WrapText = false;
                    A9.Font.Size = 10;
                    A9.Cells.Font.FontStyle = "新細明體";
                    A9.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank = IV.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank.Font.Size = 10;
                    bank.Cells.Font.FontStyle = "新細明體";
                    bank.Value2 = "BANK NAME: ";

                    COMExcel.Range A10 = IV.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10.Font.Size = 10;
                    A10.Cells.Font.FontStyle = "新細明體";
                    A10.WrapText = false;
                    A10.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount = IV.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount.Font.Size = 10;
                    Acount.Cells.Font.FontStyle = "新細明體";
                    Acount.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11 = IV.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11.Font.Size = 10;
                    A11.Cells.Font.FontStyle = "新細明體";
                    A11.WrapText = false;
                    A11.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift = IV.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift.Font.Size = 10;
                    Swift.Cells.Font.FontStyle = "新細明體";
                    Swift.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12 = IV.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12.Font.Size = 10;
                    A12.Cells.Font.FontStyle = "新細明體";
                    A12.WrapText = false;
                    A12.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress = IV.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress.Font.Size = 10;
                    bankAddress.Cells.Font.FontStyle = "新細明體";
                    bankAddress.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13 = IV.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13.Font.Size = 10;
                    A13.Cells.Font.FontStyle = "新細明體";
                    A13.WrapText = false;
                    A13.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14 = IV.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14.Font.Size = 10;
                    A14.Cells.Font.FontStyle = "新細明體";
                    A14.WrapText = false;
                    A14.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15 = IV.get_Range("D" + (a + 11) + "", "F" + (a + 11) + "");
                    A15.Font.Size = 10;
                    A15.Cells.Font.FontStyle = "新細明體";
                    A15.Merge();
                    A15.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                    if (txtCheckCountry.Checked == false)
                    {
                        IV.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;

                        COMExcel.Range A16 = IV.get_Range("C" + (a + 11) + "", "E" + (a + 11) + "");
                        A16.Font.Size = 10;
                        A16.Cells.Font.FontStyle = "新細明體";
                        A16.Merge();
                        A16.Value2 = "TOPPING INTERNATIONAL CO.,LTD";
                    }


                    #endregion

                    // 2
                    COMExcel.Worksheet IV_2 = (COMExcel.Worksheet)book.Worksheets[2];

                    COMExcel.Range C_NAME_2 = IV_2.get_Range("A4", "D4");
                    C_NAME_2.Merge();
                    C_NAME_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    C_NAME_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    C_NAME_2.Value2 = Title_1 + txtC_NAME.Text;

                    COMExcel.Range ARD3_2 = IV_2.get_Range("A5", "D6");
                    ARD3_2.Merge();
                    ARD3_2.WrapText = true;
                    ARD3_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ARD3_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ARD3_2.Value2 = "ADDRESS: " + txtADR.Text;

                    COMExcel.Range DATE_2 = IV_2.get_Range("F4", "H4");
                    DATE_2.Merge();
                    DATE_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    DATE_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DATE_2.Value2 = date_add;

                    COMExcel.Range INVOICE_2 = IV_2.get_Range("E5", "H5");
                    INVOICE_2.Merge();
                    INVOICE_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    INVOICE_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    INVOICE_2.Value2 = "INVOICE#:" + txtInvoice.Text;

                    COMExcel.Range BYair_2 = IV_2.get_Range("E6", "H6");
                    BYair_2.Merge();
                    BYair_2.Font.Bold = true;
                    BYair_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    BYair_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    BYair_2.Value2 = txtByAir.Text;

                    if (checkHSCODE.Checked == true)
                    {
                        COMExcel.Range TAXID = IV_2.get_Range("A7", "H7");
                        TAXID.Merge();
                        TAXID.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        TAXID.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        TAXID.Value2 = "TAXID: " + TAX_ID;

                        COMExcel.Range HSCODE = IV_2.get_Range("A8", "H8");
                        HSCODE.Merge();
                        HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                        HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        HSCODE.Value2 = "HSCODE: " + HS_CODE;
                    }
                    else
                    {
                        COMExcel.Range TAXID = IV_2.get_Range("A7", "H7");
                        TAXID.EntireRow.Hidden = true;
                        COMExcel.Range HSCODE = IV_2.get_Range("A8", "H8");
                        HSCODE.EntireRow.Hidden = true;
                    }

                    COMExcel.Range ATTN_2 = IV_2.get_Range("A9", "H9");
                    ATTN_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN_2.Merge();
                    ATTN_2.Value2 = "ATTN:" + txtATTN.Text;

                    COMExcel.Range TEL_2 = IV_2.get_Range("A10", "H10");
                    TEL_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    TEL_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    TEL_2.Merge();
                    TEL_2.Value2 = "TEL: " + txtTEL.Text;

                    COMExcel.Range Billto_2 = IV_2.get_Range("A11", "H11");
                    Billto_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Billto_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Billto_2.Merge();
                    Billto_2.Value2 = Title_2 + txtBillto.Text;

                    COMExcel.Range add_2 = IV_2.get_Range("A12", "H12");
                    add_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    add_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    add_2.Merge();
                    add_2.Value2 = "Address: " + txtAddress_billto.Text;

                    COMExcel.Range ATTN_billto_2 = IV_2.get_Range("A13", "H13");
                    ATTN_billto_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    ATTN_billto_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    ATTN_billto_2.Merge();
                    ATTN_billto_2.Value2 = "ATTN: " + txtATTN_Billto.Text;

                    COMExcel.Range Tel_billto_2 = IV_2.get_Range("A14", "H14");
                    Tel_billto_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Tel_billto_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Tel_billto_2.Merge();
                    Tel_billto_2.Value2 = "TEL: " + txtTEL_Billto.Text;

                    COMExcel.Range SHIP_2 = IV_2.get_Range("A15", "H15");
                    SHIP_2.Merge();
                    SHIP_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    SHIP_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    SHIP_2.Value2 = "Shipped by: " + txtShip.Text;

                    COMExcel.Range AD_2 = IV_2.get_Range("A16", "H16");
                    AD_2.Merge();
                    AD_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    AD_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    AD_2.Value2 = "Address: " + txtAd.Text;

                    COMExcel.Range FROMTAB1_2 = IV_2.get_Range("A17", "C17");
                    FROMTAB1_2.Merge();
                    FROMTAB1_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    FROMTAB1_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    FROMTAB1_2.Value2 = "From: " + txtFr.Text;

                    COMExcel.Range Totab = IV_2.get_Range("E17", "H17");
                    Totab.Merge();
                    Totab.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    Totab.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Totab.Value2 = "To: " + txtTo.Text;

                    COMExcel.Range K_NAME_2 = IV_2.get_Range("A20", "A20");
                    K_NAME_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    K_NAME_2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    K_NAME_2.Font.Bold = true;
                    K_NAME_2.Merge();
                    K_NAME_2.Value2 = "COW SPLIT LEATHER";

                    a = 21;
                    sumQty = 0;
                    sumAmount = 0;


                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        if (DGV1.Rows[i].Cells["Calculated"].Value.ToString() == "True")
                        {
                            //row 16
                            COMExcel.Range OR_NO = IV_2.get_Range("A" + a, "A" + a);
                            OR_NO.WrapText = true;
                            OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            OR_NO.Font.Size = 8;
                            OR_NO.Value2 = DGV1.Rows[i].Cells["OR_NO"].Value.ToString();

                            //row 20
                            COMExcel.Range COLOR = IV_2.get_Range("B" + a, "B" + a);
                            COLOR.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            COLOR.WrapText = true;
                            COLOR.Font.Size = 8;
                            COLOR.Value2 = DGV1.Rows[i].Cells["COLOR"].Value.ToString();

                            if (txtCheckCountry.Checked == true)
                            {
                                //row 20
                                COMExcel.Range HSCODE = IV_2.get_Range("C" + a, "C" + a);
                                HSCODE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                HSCODE.WrapText = true;
                                HSCODE.Font.Size = 8;
                                HSCODE.Value2 = HS_CODE;

                                //row 20
                                COMExcel.Range COUNTRY = IV_2.get_Range("D" + a, "D" + a);
                                COUNTRY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                                COUNTRY.WrapText = true;
                                COUNTRY.Font.Size = 8;
                                COUNTRY.Value2 = key_Country;
                            }

                            //row 20
                            COMExcel.Range THICK = IV_2.get_Range("E" + a, "E" + a);
                            THICK.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            THICK.Font.Size = 8;
                            THICK.Value2 = DGV1.Rows[i].Cells["P_NAME3"].Value.ToString();

                            //Quantity
                            COMExcel.Range BQTY = IV_2.get_Range("F" + a, "F" + a);
                            BQTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            BQTY.Font.Size = 8;
                            BQTY.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()), 2);

                            //price
                            COMExcel.Range PRICE = IV_2.get_Range("G" + a, "G" + a);
                            PRICE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            PRICE.Font.Size = 8;
                            PRICE.NumberFormat = "[$USD] #,##0.00";
                            PRICE.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()), 2).ToString();
                            //total
                            COMExcel.Range AMOUNT = IV_2.get_Range("H" + a, "H" + a);
                            AMOUNT.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            AMOUNT.Font.Size = 8;
                            AMOUNT.NumberFormat = "[$USD] #,##0.00";
                            AMOUNT.Value2 = Math.Round(float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()), 2).ToString();

                            sumQty += float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                            sumAmount += float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                            a++;
                        }
                    }
                    COMExcel.Range T1_2 = IV_2.get_Range("B" + (a) + "", "B" + (a) + "");
                    T1_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T1_2.Font.Bold = true;
                    T1_2.Font.Size = 10;
                    T1_2.Value2 = "TOTAL";

                    COMExcel.Range T2_2 = IV_2.get_Range("F" + (a) + "", "F" + (a) + "");
                    T2_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T2_2.Font.Bold = true;
                    T2_2.Font.Size = 10;
                    T2_2.Value2 = Math.Round(sumQty, 2).ToString();

                    COMExcel.Range T3_2 = IV_2.get_Range("H" + (a) + "", "H" + (a) + "");
                    T3_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    T3_2.Font.Bold = true;
                    T3_2.Font.Size = 10;
                    T3_2.NumberFormat = "[$USD] #,##0.00";
                    T3_2.Value2 = Math.Round(sumAmount, 2).ToString();

                    IV_2.get_Range("A" + (a) + "", "" + key_Border + "" + (a) + "").Cells.BorderAround();

                    COMExcel.Range A5_2 = IV_2.get_Range("A" + (a + 1), "A" + (a + 1));
                    A5_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    A5_2.Font.Size = 10;
                    A5_2.Cells.Font.FontStyle = "新細明體";
                    A5_2.Value2 = "FOB HCM";

                    COMExcel.Range A5_3 = IV_2.get_Range("H" + (a + 1), "H" + (a + 1));
                    A5_3.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    A5_3.Font.Size = 10;
                    A5_3.Cells.Font.FontStyle = "新細明體";
                    A5_3.Value2 = "FOC";

                    COMExcel.Range A6_2 = IV_2.get_Range("A" + (a + 2), "A" + (a + 2));
                    A6_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A6_2.Font.Size = 10;
                    A6_2.Cells.Font.FontStyle = "新細明體";
                    A6_2.Value2 = "PAYMENT FOR GOODS ";
                    //row 24
                    COMExcel.Range A100_2 = IV_2.get_Range("A" + (a + 3), "A" + (a + 3));
                    A100_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    A100_2.Font.Size = 10;
                    A100_2.Cells.Font.FontStyle = "新細明體";
                    A100_2.Value2 = "BENEFICIAY: ";

                    COMExcel.Range A7_2 = IV_2.get_Range("B" + (a + 3) + "", "B" + (a + 3) + "");
                    A7_2.WrapText = false;
                    A7_2.Font.Size = 10;
                    A7_2.Cells.Font.FontStyle = "新細明體";
                    A7_2.Value2 = "TOPPING INTERNATIONAL  CO.,LTD ";

                    //row 25
                    COMExcel.Range A8_2 = IV_2.get_Range("B" + (a + 4) + "", "B" + (a + 4) + "");
                    A8_2.WrapText = false;
                    A8_2.Font.Size = 10;
                    A8_2.Cells.Font.FontStyle = "新細明體";
                    A8_2.Value2 = "NO.102,ZHENFU RD.,EAST DIST.,TAICHUNG CITY 40147,TAIWAN (R.O.C.) ";

                    COMExcel.Range A9_2 = IV_2.get_Range("B" + (a + 5) + "", "B" + (a + 5) + "");
                    A9_2.WrapText = false;
                    A9_2.Font.Size = 10;
                    A9_2.Cells.Font.FontStyle = "新細明體";
                    A9_2.Value2 = "TEL:886-4-22116696  FAX:886-4-22116683 ";
                    //row26

                    COMExcel.Range bank_2 = IV_2.get_Range("A" + (a + 6), "A" + (a + 6));
                    bank_2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                    bank_2.Font.Size = 10;
                    bank_2.Cells.Font.FontStyle = "新細明體";
                    bank_2.Value2 = "BANK NAME: ";

                    COMExcel.Range A10_2 = IV_2.get_Range("B" + (a + 6) + "", "B" + (a + 6) + "");
                    A10_2.Font.Size = 10;
                    A10_2.Cells.Font.FontStyle = "新細明體";
                    A10_2.WrapText = false;
                    A10_2.Value2 = "MEGA INTERNATIONAL COMMERCIAL BANK CO.,LTD. HONG KONG BRANCH";
                    //row 27

                    COMExcel.Range Acount_2 = IV_2.get_Range("A" + (a + 7), "A" + (a + 7));
                    Acount_2.Font.Size = 10;
                    Acount_2.Cells.Font.FontStyle = "新細明體";
                    Acount_2.Value2 = "ACCOUNT NO: ";

                    COMExcel.Range A11_2 = IV_2.get_Range("B" + (a + 7) + "", "B" + (a + 7) + "");
                    A11_2.Font.Size = 10;
                    A11_2.Cells.Font.FontStyle = "新細明體";
                    A11_2.WrapText = false;
                    A11_2.Value2 = "965-11-003037";

                    //row 28
                    COMExcel.Range Swift_2 = IV_2.get_Range("A" + (a + 8), "A" + (a + 8));
                    Swift_2.Font.Size = 10;
                    Swift_2.Cells.Font.FontStyle = "新細明體";
                    Swift_2.Value2 = "SWIFT CODE: ";

                    COMExcel.Range A12_2 = IV_2.get_Range("B" + (a + 8) + "", "B" + (a + 8) + "");
                    A12_2.Font.Size = 10;
                    A12_2.Cells.Font.FontStyle = "新細明體";
                    A12_2.WrapText = false;
                    A12_2.Value2 = "ICBCHKHH";
                    //row 29
                    COMExcel.Range bankAddress_2 = IV_2.get_Range("A" + (a + 9), "A" + (a + 9));
                    bankAddress_2.Font.Size = 10;
                    bankAddress_2.Cells.Font.FontStyle = "新細明體";
                    bankAddress_2.Value2 = "BANK ADDRESS: ";

                    COMExcel.Range A13_2 = IV_2.get_Range("B" + (a + 9) + "", "B" + (a + 9) + "");
                    A13_2.Font.Size = 10;
                    A13_2.Cells.Font.FontStyle = "新細明體";
                    A13_2.WrapText = false;
                    A13_2.Value2 = "SUITE 2201,22/F,PRUDENTIAL TOWER THE GATEWAY,HARBOUR CITY,";

                    COMExcel.Range A14_2 = IV_2.get_Range("B" + (a + 10) + "", "B" + (a + 10) + "");
                    A14_2.Font.Size = 10;
                    A14_2.Cells.Font.FontStyle = "新細明體";
                    A14_2.WrapText = false;
                    A14_2.Value2 = "21 CANTON ROAD,TSIMSHATSUI,KOWLOON,HONG KONG";

                    COMExcel.Range A15_2 = IV_2.get_Range("D" + (a + 11) + "", "F" + (a + 11) + "");
                    A15_2.Font.Size = 10;
                    A15_2.Cells.Font.FontStyle = "新細明體";
                    A15_2.Merge();
                    A15_2.Value2 = "TOPPING INTERNATIONAL CO.,LTD";

                    if (txtCheckCountry.Checked == false)
                    {
                        IV_2.Columns["C:D"].Delete();
                        //row 16
                        COMExcel.Range OR_NO = IV_2.get_Range("A" + a, "A" + a);
                        //row 20
                        COMExcel.Range COLOR = IV_2.get_Range("B" + a, "B" + a);

                        COMExcel.Range AMOUNT = IV_2.get_Range("F" + a, "F" + a);

                        OR_NO.EntireColumn.ColumnWidth = 17;
                        COLOR.EntireColumn.ColumnWidth = 36;
                        AMOUNT.EntireColumn.ColumnWidth = 14;
                    }


                    app.Visible = true;
                    app.Quit();
                    conn.releaseObject(book);
                    conn.releaseObject(app);

                }


            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
      
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                ID_CUST.ID_CUST_KH = txtC_NO.Text;
                frmAddCust frmAddCust = new frmAddCust();
                frmAddCust.ShowDialog();
                txtC_NO.Text = "";
                string DL = frmAddCust.getC_NO_Add_CUST.getC_NO;
                if (DL != string.Empty)
                {
                    txtC_NO.Text = DL;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");
            }
        }
        public class ID_CUST
        {
            public static string ID_CUST_KH;
        }
        public class C_NO_ID
        {
            public static string C_NO_ID_NUMBER;
        }
        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
        private string getDate()
        {
            string txtDate_New = "";
            if (conn.Check_MaskedText(txtDate) == true)
            {
                txtDate_New = conn.formatstr2(txtDate.Text);
            }
            else
            {
                txtDate_New = "";
            }
            return txtDate_New;
        }
        private string FormatCheckBox(CheckBox checkBox)
        {
            if (checkBox.Checked == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private string FormatRadio(RadioButton checkBox)
        {
            if (checkBox.Checked == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void addData()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtInvoice.Text))
                {
                    if (conn.checkExists("SELECT TOP 1 INVOICE FROM tblHistoryInvoice_KTKD WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
                    {
                        MessageBox.Show("Mã INVOICE đã tồn tại!, vui lòng kiểm tra lại!");
                    }
                    else
                    {
                        if (DGV1.Rows.Count > 0)
                        {
                            DialogResult dialog = MessageBox.Show("Bạn muốn lưu mã Invoice " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialog == DialogResult.OK)
                            {
                                string sql = "INSERT INTO dbo.tblHistoryInvoice_KTKD(DATECREATE,INVOICE,C_NO,USER_NAME,BYAIR,checkBillTo,checkHSCODE,checkCountry,TO_SHIP,FROM_SHIP,PHANTRAM,checkINVOICE,checkPackingList,checkTong,checkChitiet,checkTrongNuoc,checkRutGon,checkTachPO,checkGroup,checkInvoice_Cut) " +
                                    "SELECT '" + getDate() + "','" + txtInvoice.Text + "','" + txtC_NO.Text + "','" + lbUserName.Text + "','" + txtByAir.Text + "'," +
                                    "'" + FormatCheckBox(cbBillto) + "','" + FormatCheckBox(checkHSCODE) + "','" + FormatCheckBox(txtCheckCountry) + "','"+txtTo.Text+"','"+txtFr.Text+"','"+txtPhanTram.Text+ "','"+ FormatRadio(rdInvoice)+ "','" + FormatRadio(rdPacking) + "','" + FormatRadio(radioButton1) + "','" + FormatRadio(radioButton2) + "','" + FormatRadio(rdTrongNuoc) + "'," +
                                    "'" + FormatCheckBox(cbRutGon) + "','" + FormatCheckBox(cbTachPO) + "','" + FormatCheckBox(cbcheckgroup) + "','" + FormatCheckBox(rdTachPO_INVOICE) + "'";
                                bool a = conn.exedata(sql);
                                if (a == true)
                                {
                                    AddDataGribView();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu để lưu");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã Invoice không thể trống");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Mã Invoice " + txtInvoice.Text + " đã tồn tại!!");
            }
        }
        private void AddDataGribView()
        {
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                string sql = "INSERT INTO dbo.tblDescription_HistoryInvoice_KTKD(INVOICE,OR_NO,DESCRIPTION,THICKNESS,QTY,PRICE,TOTAL,CALTULATED,NW,GW,CNO,IRNNUMBER_LEFT,IRNNUMBER_RIGHT,CHECK_GROUP,TOTAL_GROUP,K_NO) " +
                "SELECT '" + txtInvoice.Text + "','" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "','" + DGV1.Rows[i].Cells["COLOR"].Value.ToString() + "'" +
                ",'" + DGV1.Rows[i].Cells["P_NAME3"].Value.ToString() + "'" + ",'" + float.Parse(DGV1.Rows[i].Cells["BQTY"].Value.ToString()) + "'" +
                ",'" + float.Parse(DGV1.Rows[i].Cells["PRICE"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString()) + "','" + Boolean.Parse(DGV1.Rows[i].Cells["Calculated"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString()) + "'" +
                ",'" + float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString()) + "','" + DGV1.Rows[i].Cells["CNO"].Value.ToString() + "','" + DGV1.Rows[i].Cells["IRNNUMBER_LEFT"].Value.ToString() + "','" + DGV1.Rows[i].Cells["IRNNUMBER_RIGHT"].Value.ToString() + "'" +
                ",'" + DGV1.Rows[i].Cells["CHECK_GROUP"].Value.ToString() + "','" + DGV1.Rows[i].Cells["TOTAL_GW"].Value.ToString() + "','" + DGV1.Rows[i].Cells["K_NO"].Value.ToString() + "'";
                bool a = conn.exedata(sql);
            }
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addData();
        }
        private void DeleteData()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtInvoice.Text))
                {
                    DialogResult dialog = MessageBox.Show("Bạn muốn xóa mã Invoice " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        string sql = "DELETE FROM tblHistoryInvoice_KTKD WHERE INVOICE = '" + txtInvoice.Text + "'";
                        bool a = conn.exedata(sql);
                        if (a == true)
                        {
                            DeleteDatagribview();
                            f8ToolStripMenuItem.PerformClick();
                            if (DGV1.Rows.Count <= 0)
                            {
                                setDataNull();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã Invoice không thể trống");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setDataNull()
        {
            txtC_NO.Text = "";
            txtByAir.Text = "";
            txtDate.Text = "";
            txtInvoice.Text = "";
            txtC_NAME.Text = "";
            txtADR.Text = "";
            txtATTN.Text = "";
            txtTEL.Text = "";
            txtATTN_Billto.Text = "";
            txtBillto.Text = "";
            txtAddress_billto.Text = "";
            txtTEL_Billto.Text = "";
            txtFAX.Text = "";
            txtFr.Text = "";
            txtTo.Text = "";
            txtPhanTram.Text = "";
            TAX_ID = "";
            HS_CODE = "";
            TERM_OF = "";
            key_Country = "";
            Buyer = "";
            Address_Buyer = "";
            Consignee = "";
            Address_Consignee = "";
            txtTEL_Billto.Text = "";

            checkHSCODE.Checked = false;
            cbBillto.Checked = false;
            txtCheckCountry.Checked = false;
            rdTachPO_INVOICE.Checked = false;
            cbcheckgroup.Checked = false;
            cbTachPO.Checked = false;  
        }
        private void DeleteDatagribview()
        {
            string sql = "DELETE FROM tblDescription_HistoryInvoice_KTKD WHERE INVOICE = '" + txtInvoice.Text + "'";
            bool a = conn.exedata(sql);
        }
        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkExport();
        }
        private void UpdateData()
        {
            try
            {
                txtInvoice.ReadOnly = true;
                if (!string.IsNullOrEmpty(txtInvoice.Text))
                {
                    if (DGV1.Rows.Count > 0)
                    {
                        DialogResult dialog = MessageBox.Show("Bạn muốn sửa Invoice " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialog == DialogResult.OK)
                        {
                            string sql = "UPDATE tblHistoryInvoice_KTKD SET DATECREATE = '" + getDate() + "',INVOICE = '" + txtInvoice.Text + "',C_NO = '" + txtC_NO.Text + "',USER_NAME = '" + lbUserName.Text + "'," +
                                "BYAIR = '" + txtByAir.Text + "',checkBillTo = '" + FormatCheckBox(cbBillto) + "',checkHSCODE = '" + FormatCheckBox(checkHSCODE) + "',checkCountry = '" + FormatCheckBox(txtCheckCountry) + "',TO_SHIP = '"+txtTo.Text+"',FROM_SHIP = '"+txtFr.Text+"',PHANTRAM = '"+txtPhanTram.Text+ "',checkINVOICE = '"+FormatRadio(rdInvoice)+ "',checkPackingList = '" + FormatRadio(rdPacking) + "',checkTong = '" + FormatRadio(radioButton1) + "',checkChitiet = '" + FormatRadio(radioButton2) + "'," +
                                "checkTrongNuoc = '" + FormatRadio(rdTrongNuoc) + "',checkRutGon = '" + FormatCheckBox(cbRutGon) + "',checkTachPO = '" + FormatCheckBox(cbTachPO) + "',checkGroup = '" + FormatCheckBox(cbcheckgroup) + "',checkInvoice_Cut = '" + FormatCheckBox(rdTachPO_INVOICE) + "'" +
                                " FROM tblHistoryInvoice_KTKD WHERE INVOICE = '" + txtInvoice.Text + "'";
                            bool a = conn.exedata(sql);
                            if (a == true)
                            {
                                UpdateDataGribView();
                                LoadData(txtInvoice.Text);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để sửa");
                    }
                }
                else
                {
                    MessageBox.Show("Mã Invoice không thể trống");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateDataGribView()
        {
            try
            {
                if (checkExsits(txtInvoice.Text) == true)
                {
                    DeleteDatagribview();
                    AddDataGribView();
                }
                else
                {
                    AddDataGribView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkExsits(string t)
        {
            string sql = "SELECT TOP 1 * FROM tblHistoryInvoice_KTKD where INVOICE = '" + t + "'";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3NF6 frm3NF6 = new frm3NF6();
            frm3NF6.ShowDialog();
            LoadData(frm3NF6.DL3NF6.INVOICE);

            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;

            txtInvoice.ReadOnly = true;
        }
        private void LoadData(string invoice)
        {
            try
            {
                string sql = "SELECT DATECREATE,INVOICE,tblHistoryInvoice_KTKD.C_NO,USER_NAME,BYAIR,ISNULL(checkBillTo,'0') AS checkBillTo,ISNULL(checkHSCODE,'0') AS checkHSCODE,ISNULL(checkCountry,'0') AS checkCountry,TO_SHIP," +
                    "FROM_SHIP,C_NAME,ADDRESS,PHONE,ATTN,HSCODE,TAXID,BillTo,TEL,ATTN_2,ADDRESS_2,Country,TermOfDelivery,Buyer,Buyer_Address,Consignee,Consignee_Address,PHANTRAM,ISNULL(checkINVOICE,'0') AS checkINVOICE,ISNULL(checkPackingList,'0') AS checkPackingList,ISNULL(checkTong,'0') AS checkTong," +
                    "ISNULL(checkChitiet,'0') AS checkChitiet,ISNULL(checkTrongNuoc,'0') AS checkTrongNuoc,ISNULL(checkRutGon,'0') AS checkRutGon," +
                    "ISNULL(checkTachPO,'0') AS checkTachPO,ISNULL(checkGroup,'0') AS checkGroup,isnull(checkInvoice_Cut,'0') as checkInvoice_Cut FROM tblHistoryInvoice_KTKD INNER JOIN dbo.tblInfoCustomer ON tblInfoCustomer.C_NO = tblHistoryInvoice_KTKD.C_NO WHERE INVOICE = '" + invoice + "'";
                DataTable data1 = new DataTable();
                data1 = conn.readdata(sql);
                foreach (DataRow item in data1.Rows)
                {
                    txtC_NO.Text = item["C_NO"].ToString();
                    txtC_NAME.Text = item["C_NAME"].ToString();
                    txtATTN.Text = item["ATTN"].ToString();
                    txtADR.Text = item["ADDRESS"].ToString();
                    txtTEL.Text = item["PHONE"].ToString();
                    txtByAir.Text = item["BYAIR"].ToString();
                    txtDate.Text = item["DATECREATE"].ToString();
                    txtInvoice.Text = item["INVOICE"].ToString();
                    txtBillto.Text = item["BillTo"].ToString();
                    txtAddress_billto.Text = item["ADDRESS_2"].ToString();
                    txtATTN_Billto.Text = item["ATTN_2"].ToString();
                    txtTEL_Billto.Text = item["TEL"].ToString();
                    txtTo.Text = item["TO_SHIP"].ToString();
                    txtFr.Text = item["FROM_SHIP"].ToString();
                    txtPhanTram.Text = item["PHANTRAM"].ToString();
                    HS_CODE = item["HSCODE"].ToString();
                    TAX_ID = item["TAXID"].ToString();
                    key_Country = item["Country"].ToString();
                    TERM_OF = item["TermOfDelivery"].ToString();
                    Buyer = item["Buyer"].ToString();
                    Address_Buyer = item["Buyer_Address"].ToString();
                    Consignee = item["Consignee"].ToString();
                    Address_Consignee = item["Consignee_Address"].ToString();

                    txtUSR_NAME.Text = item["USER_NAME"].ToString();
                }
                //new
                //checkINVOICE,checkPackingList,checkTong,checkChitiet,checkTrongNuoc,checkRutGon,checkTachPO,checkGroup
                setCheckCb(data1, "checkBillTo",cbBillto);
                setCheckCb(data1, "checkHSCODE", checkHSCODE);
                setCheckCb(data1, "checkCountry", txtCheckCountry);
                setCheckCb(data1, "checkRutGon", cbRutGon);
                setCheckCb(data1, "checkTachPO", cbTachPO);
                setCheckCb(data1, "checkGroup", cbcheckgroup);
                setCheckCb(data1, "checkInvoice_Cut", rdTachPO_INVOICE);
                //radio
                setCheckRadio(data1, "checkINVOICE", rdInvoice);
                setCheckRadio(data1, "checkPackingList", rdPacking);
                setCheckRadio(data1, "checkTong", radioButton1);
                setCheckRadio(data1, "checkChitiet", radioButton2);
                setCheckRadio(data1, "checkTrongNuoc", rdTrongNuoc);


                string sql2 = "SELECT OR_NO,DESCRIPTION AS COLOR,THICKNESS as P_NAME3,QTY AS BQTY,PRICE as PRICE,TOTAL AS AMOUNT,CASE WHEN ISNULL(CALTULATED,'0') = 0 THEN 'False' ELSE 'True' END  as Calculated,isnull(NW,0) as NW," +
                    "isnull(GW,0) as GW,isnull(CNO,0) as CNO,IRNNUMBER_LEFT,IRNNUMBER_RIGHT,CASE WHEN ISNULL(CHECK_GROUP,'0') = 0 THEN 'False' ELSE 'True' end as CHECK_GROUP,isnull(TOTAL_GROUP,'0') as TOTAL_GW,isnull(K_NO,1) K_NO FROM dbo.tblDescription_HistoryInvoice_KTKD WHERE INVOICE = '" + invoice + "'";
                data = conn.readdata(sql2);
                getDataINR_LEFT_RIGHT(data);
                DGV1.DataSource = data;
                conn.DGV(DGV1);
                Changed_Color(DGV1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setCheckCb(DataTable data,string keyColumn,CheckBox check)
        {
            foreach (DataRow item in data.Rows)
            {
                if (item[keyColumn].ToString() == "True")
                {
                    check.Checked = true;
                }
                else
                {
                    check.Checked = false;
                }
            }
        }
        private void setCheckRadio(DataTable data, string keyColumn, RadioButton check)
        {
            foreach (DataRow item in data.Rows)
            {
                if (item[keyColumn].ToString() == "True")
                {
                    check.Checked = true;
                }
                else
                {
                    check.Checked = false;
                }
            }
        }
        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Enabled = true;

            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;

            setDataNull();
            LoadData(txtInvoice.Text);
            conn.DGV(DGV1);
            Changed_Color(DGV1);

            txtC_NO.Focus();

            txtInvoice.ReadOnly = false;
        }

        private void rdInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdInvoice.Checked == true)
            {
                groupBox3.Visible = true;
                radioButton1.Checked = true;
                rdTachPO_INVOICE.Visible = true;
                cbRutGon.Visible = true;

                radioButton2.Checked = false;

                cbcheckgroup.Checked = false;
                cbTachPO.Checked = false;
                cbRutGon.Checked = false;

                cbcheckgroup.Visible = false;
                cbTachPO.Visible = false;

                Visible_DGV(DGV1, false);
            }
        }

        private void rdPacking_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPacking.Checked == true)
            {
                groupBox3.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                cbcheckgroup.Checked = false;
                cbTachPO.Checked = false;
                cbRutGon.Checked = false;

                cbTachPO.Visible = true;
                cbcheckgroup.Visible = true;
                cbRutGon.Visible = false;

                rdTachPO_INVOICE.Visible = false;

                Visible_DGV(DGV1, true);

            }
        }
        private void Visible_DGV(DataGridView dataGrid, bool check)
        {
            dataGrid.Columns["CNO"].Visible = check;
            dataGrid.Columns["NW"].Visible = check;
            dataGrid.Columns["GW"].Visible = check;
        }

        private void cbTachPO_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTachPO.Checked == true)
            {
                cbcheckgroup.Checked = false;
            }
        }
        private void cbcheckgroup_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcheckgroup.Checked == true)
            {
                cbTachPO.Checked = false; 
                DGV1.Columns["PRICE"].Visible = false;
                DGV1.Columns["AMOUNT"].Visible = false;

                //TRUE
                DGV1.Columns["CHECK_GROUP"].Visible = true;
                DGV1.Columns["TOTAL_GW"].Visible = true;

            }
            else
            {
                DGV1.Columns["PRICE"].Visible = true;
                DGV1.Columns["AMOUNT"].Visible = true;
                //False
                DGV1.Columns["CHECK_GROUP"].Visible = false;
                DGV1.Columns["TOTAL_GW"].Visible = false;

            }
        }
        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
                float AMOUNT = 0;
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 3 || Cur == 4)
                {
                    AMOUNT = float.Parse(DGV1.CurrentRow.Cells["BQTY"].Value.ToString()) * float.Parse(DGV1.CurrentRow.Cells["PRICE"].Value.ToString());
                    //DGV1.CurrentRow.Cells["AMOUNT"].Value = AMOUNT;
                    DGV1.Rows[DGV1.CurrentRow.Index].Cells["AMOUNT"].Value = Math.Round(AMOUNT, 2);
                }
                if (Cur == 12)
                {
                    if (DGV1.CurrentRow.Cells["CHECK_GROUP"].Value.ToString() == "True")
                    {
                        DGV1.CurrentRow.Cells["CNO"].Value = "1";
                    }
                    else
                    {
                        DGV1.CurrentRow.Cells["CNO"].Value = "0";
                    }
                }
                if (Cur == 8)
                {
                    if (rdPacking.Checked == true)
                    {
                        DGV1.CurrentRow.Cells["NW"].Value = float.Parse(DGV1.CurrentRow.Cells["GW"].Value.ToString());
                    }    
                }
                if (Cur == 7)
                {
                    if (rdPacking.Checked == true && cbcheckgroup.Checked == true)
                    {
                        DGV1.CurrentRow.Cells["GW"].Value = float.Parse(DGV1.CurrentRow.Cells["NW"].Value.ToString());
                    }
                }
            }
        }
        private void rdTrongNuoc_CheckedChanged(object sender, EventArgs e)
        {  
           checkINVOICE(false);
            txtFr.Text = "";
            txtTo.Text = "";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkINVOICE(false);
          
        }
        private void getDataToFrom()
        {
            if (string.IsNullOrEmpty(txtFr.Text))
            {

                txtFr.Text = "VIET NAM";
                
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {

                txtTo.Text = "VIET NAM";
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkINVOICE(false);
            getDataToFrom();
        }
        private void checkINVOICE(bool a)
        {
            if (rdInvoice.Checked == true)
            {
                this.DGV1.Columns["NW"].Visible = a;
                this.DGV1.Columns["GW"].Visible = a;
                this.DGV1.Columns["CNO"].Visible = a;

                if (cbBillto.Checked == true && rdTrongNuoc.Checked == true)
                {
                    txtPhanTram.Visible = true;
                }
                else
                {
                    txtPhanTram.Visible = false;
                }
            }
         }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO, txtInvoice, sender, e);
        }
        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NO, txtByAir, sender, e);
        }
        private void txtByAir_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(txtInvoice, txtDate, sender, e);
        }
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtByAir, txtC_NAME, sender, e);
        }
        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(txtDate, txtADR, sender, e);
        }
        private void txtADR_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtC_NAME, txtATTN, sender, e);
        }
        private void txtATTN_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtADR, txtTEL, sender, e);
        }
        private void txtTEL_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtATTN, txtFAX, sender, e);
        }
        private void txtFAX_KeyDown(object sender, KeyEventArgs e) 
        {
            if (cbBillto.Checked == true)
            {
                conn.tab(txtTEL, txtATTN_Billto, sender, e);
            }
            else
            {
                conn.tab(txtFAX, txtShip, sender, e);
            }
        }
        private void txtATTN_Billto_KeyDown(object sender, KeyEventArgs e)
        {
                conn.tab(txtFAX, txtTEL_Billto, sender, e);
        }
        private void txtTEL_Billto_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtATTN_Billto, txtBillto, sender, e);
        }
        private void txtBillto_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtTEL_Billto, txtAddress_billto, sender, e);
        }
        private void txtAddress_billto_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtBillto, txtShip, sender, e);
        }
        private void txtShip_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtAddress_billto, txtFr, sender, e);
        }
        private void txtFr_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtShip, txtAd, sender, e);
        }
        private void txtAd_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtFr, txtTo, sender, e);
        }
        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtAd, txtC_NO, sender, e);
        }
    }
}
