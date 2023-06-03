using CrystalDecisions.CrystalReports.Engine;
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
using WTERP.WSEXE.ReportView;
using static WTERP.WSEXE.Report;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm3P : Form
    {
        DataProvider conn = new DataProvider();
        public static double HANG_SO = 0.0929;
        string day = "", month = "", year = "", date_add = "";
        DataTable dt = new DataTable();
        public frm3P()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        private void load()
        {
            con.CheckLoad(menuStrip1);
            loadinfo();
            loadfirst();
            LoadDataGribView();

            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;
        }

        private void LoadDataGribView()
        {
            string SQL1 = "SELECT OR_NO,OR_NO as MTLCODE,COLOR_E + ' ' + P_NAME_E AS DESCRIPTION,THICK as WIDTH,'SF' as UNIT, '0' as QUANTITY_1,'0' as QUANTITY_2,'0' as NW,'0' as GW, '1' as PACKAGE FROM ORDB WHERE OR_NO = '' AND NR= ''";
            DataTable dt2 = conn.readdata(SQL1);
            DGV1.DataSource = dt2;
            con.DGV(DGV1);
        }

        private void loadfirst()
        {
            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,DONG NAI PROVINCE,VIET NAM.";
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
                            MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                        }
                    }
                    break;
            }
        }
        private void ClickInsertDataGridview()
        {
            try
            {
                string PO_1 = "";
                string PO_2 = "";
                DL3P.Keyc_no = txtC_NO.Text;
                frm3P_DGV frm = new frm3P_DGV();
                frm.ShowDialog();

                foreach (var item in frm3P_DGV.LV)
                {
                    for (int i = 0; i < int.Parse(item.Rows_Number); i++)
                    {
                        string SQL1 = "SELECT OR_NO,COLOR_E + ' ' + P_NAME_E AS DESCRIPTION,THICK as WIDTH,'SF' as UNIT, '0' as QUANTITY_1,'0' as QUANTITY_2,'0' as NW,'0' as GW, '1' as PACKAGE FROM ORDB WHERE OR_NO = '" + item.OR_NO + "' AND NR= '" + item.NR + "'";
                        DataTable dt2 = conn.readdata(SQL1);
                        if (dt2.Rows.Count > 0)
                        {
                            dt = (DataTable)DGV1.DataSource;
                            foreach (DataRow dr in dt2.Rows)
                            {
                                string sql = "SELECT * FROM dbo.SplitString('" + dr["OR_NO"].ToString() + "','/')";
                                DataTable table = conn.readdata(sql);
                                if (table.Rows.Count > 0)
                                {
                                    PO_1 = table.Rows[0]["Items"].ToString();
                                    PO_2 = table.Rows[0]["Items2"].ToString();
                                }  
                                else
                                {
                                    PO_1 = dr["OR_NO"].ToString();
                                }
                                if (i < 1)
                                {
                                    dt.Rows.Add(PO_1, PO_2, dr["DESCRIPTION"].ToString(), dr["WIDTH"].ToString(), dr["UNIT"].ToString(), dr["QUANTITY_1"].ToString(), dr["QUANTITY_2"].ToString(), dr["NW"].ToString(), dr["GW"].ToString(), dr["PACKAGE"].ToString());
                                }
                                else
                                {
                                    dt.Rows.Add("'''", "'''", "'''", "'''", "'''", dr["QUANTITY_1"].ToString(), dr["QUANTITY_2"].ToString(), dr["NW"].ToString(), dr["GW"].ToString(), dr["PACKAGE"].ToString());
                                }

                            }
                        }
                    }

                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }
        public class DL3P
        {
            public static string Keyc_no;
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm3P_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btdong.PerformClick();
        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDataNull();
        }
        private void setDataNull()
        {
            txtC_NO.Text = "";
            txtDate.Text = "";
            txtInvoice.Text = "";
            txtC_NAME.Text = "";
            txtADR.Text = "";
            txtTEL.Text = "";
            txtFAX.Text = "";
            txtBuyer.Text = "";
            LoadDataGribView();
        }

        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }

        private void txtC_NO_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                if (con.checkExists("select * from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'") == true)
                {
                    string sql = "select * from tblInfoCustomer where C_NO = '" + txtC_NO.Text + "'";
                    DataTable dt1 = con.readdata(sql);
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME"].ToString();
                        txtADR.Text = dr["ADDRESS"].ToString();
                        txtTEL.Text = dr["PHONE"].ToString();
                        txtFAX.Text = dr["FAX"].ToString();

                    }
                }
                else
                {
                    string SQL1 = "select C_NO, C_NAME, ADR3,TEL1,FAX2 from CUST where C_NO = '" + txtC_NO.Text + "'";
                    DataTable dt1 = con.readdata(SQL1);
                    foreach (DataRow dr in dt1.Rows)
                    {
                        txtC_NO.Text = dr["C_NO"].ToString();
                        txtC_NAME.Text = dr["C_NAME"].ToString();
                        txtADR.Text = dr["ADR3"].ToString();
                        txtTEL.Text = dr["TEL1"].ToString();
                        txtFAX.Text = dr["FAX2"].ToString();
                    }
                }
            }
            else
            {
                txtC_NO.Text = "";
                txtC_NAME.Text = "";
                txtADR.Text = "";
                txtTEL.Text = "";
                txtFAX.Text = "";

            }
        }

        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                DL3P.Keyc_no = txtC_NO.Text;
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

        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            xuatCrytalReport();
        }

        private void xuatCrytalReport()
        {
            getDatedaymonyear();
            ReportDocument cryRpt = new Cr_Form3P();
            getDataParamter(cryRpt);
            cryRpt.SetDataSource(dt);
            ShareReport.repo = cryRpt;
            Report frm = new Report();
            frm.ShowDialog();
        }
        private void getDataParamter(ReportDocument cryRpt)
        {
            cryRpt.DataDefinition.FormulaFields["INVOICE"].Text = "'INVOICE NO: " + txtInvoice.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Consignee"].Text = "'Consignee: " + txtC_NAME.Text + "'";
            cryRpt.DataDefinition.FormulaFields["DATE"].Text = "'DATE: " + date_add + "'";
            cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'Address: " + txtADR.Text + "'";
            cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'TEL: " + txtTEL.Text + "'";
            cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'FAX: " + txtFAX.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Shippedby"].Text = "'Shipped by: " + txtShip.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'Address:" + txtAd.Text + "'";
            cryRpt.DataDefinition.FormulaFields["Buyer"].Text = "'Buyer:" + txtBuyer.Text + "'";
            float Cno = 0, SUMQTY1 = 0, SUMQTY2 = 0, SUMNW = 0, SUMGW = 0;
            for (int i = 0; i < DGV1.Rows.Count; i++)
            {
                Cno += float.Parse(DGV1.Rows[i].Cells["PACKAGE"].Value.ToString());
                SUMQTY1 += float.Parse(DGV1.Rows[i].Cells["QUANTITY_1"].Value.ToString());
                SUMQTY2 += float.Parse(DGV1.Rows[i].Cells["QUANTITY_2"].Value.ToString());
                SUMNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                SUMGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
            }
            cryRpt.DataDefinition.FormulaFields["SUM"].Text = "'" + string.Format(Cno.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["SUMQTY1"].Text = "'" + string.Format(SUMQTY1.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["SUMQTY2"].Text = "'" + string.Format(SUMQTY2.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["SUMNW"].Text = "'" + string.Format(SUMNW.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["SUMGW"].Text = "'" + string.Format(SUMGW.ToString(), "#,##0.00") + "'";

        }
        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3P_F6 frm3P_F = new frm3P_F6();
            frm3P_F.ShowDialog();
            LoadData(frm3P_F6.DL3PF6.INVOICE);


            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;
        }

        private void f5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void f4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (con.checkExists("SELECT TOP 1 * FROM tblPackingList_Type2 WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
            {
                MessageBox.Show("Mã Invoice này đã có không thể thêm");
            }
            else
            {
                addData();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getDatedaymonyear();
            string workbookPath = con.LinkTemplate + "Template_xuatExcel_PackingList_TypeDouble.xls";
            string filePath = con.LinkTemplate_SAVE + "Template_xuatExcel_PackingList_TypeDouble.xls";
            xuatExcel_PackingList(workbookPath, filePath);

        }

        private void xuatExcel_PackingList(string workbookPath, string filePath)
        {
            if (con.CheckFileOpen(filePath))
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
                    System.IO.Directory.CreateDirectory(con.LinkTemplate_SAVE);
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

                app.Visible = true;

                COMExcel.Range INVOICE = IV.get_Range("A4", "C4");
                INVOICE.Merge();
                INVOICE.Value2 = "INVOICE NO: " + txtInvoice.Text.ToUpper();

                COMExcel.Range DATE = IV.get_Range("F4", "J4");
                DATE.Merge();
                DATE.Value2 = "DATE: " + date_add.ToUpper();

                COMExcel.Range Buyer = IV.get_Range("A5", "J5");
                Buyer.Merge();
                Buyer.Value2 = "Buyer: " + lbl.Text.ToUpper();

                COMExcel.Range C_NAME = IV.get_Range("A6", "J6");
                C_NAME.Merge();
                C_NAME.Value2 = "Consignee: " + txtC_NAME.Text.ToUpper();

                COMExcel.Range Address = IV.get_Range("A7", "J7");
                Address.Merge();
                Address.WrapText = true;
                Address.Rows.AutoFit();
                Address.Value2 = "Address: " + txtADR.Text.ToUpper();

                COMExcel.Range TEL = IV.get_Range("A8", "C8");
                TEL.Merge();
                TEL.Value2 = "TEL: " + txtTEL.Text.ToUpper();

                COMExcel.Range FAX = IV.get_Range("F8", "J8");
                FAX.Merge();
                FAX.Value2 = "FAX: " + txtFAX.Text.ToUpper();

                COMExcel.Range Shipp = IV.get_Range("A9", "J9");
                Shipp.Merge();
                Shipp.Value2 = "Shipped by: " + txtShip.Text.ToUpper();

                COMExcel.Range add = IV.get_Range("A10", "J10");
                add.Merge();
                add.WrapText = true;
                add.Rows.AutoFit();
                add.Value2 = "Address: " + txtAd.Text.ToUpper();

                int a = 13;
                float sumQTY1 = 0;
                float sumQTY2 = 0;
                float sumNW = 0;
                float sumGW = 0;
                float sumPackage = 0;
                int column = 0;
                int b = 0;
                string sql = "EXEC dbo.sp_ColumnExcelList @CharFrom = 'A',@CharTo = 'J'";
                DataTable data = conn.readdata(sql);
                foreach (DataRow item in data.Rows)
                {
                    for (int i = 0; i < DGV1.Rows.Count; i++)
                    {
                        COMExcel.Range COLUMN = IV.get_Range("" + item["ColumnName"].ToString() + "" + a, "" + item["ColumnName"].ToString() + "" + a);
                        COLUMN.Merge();
                        if (item["ColumnName"].ToString() == "C")
                        {
                            COLUMN.WrapText = true;
                        }
                        COLUMN.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLUMN.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        COLUMN.Value2 = DGV1.Rows[i].Cells[column].Value.ToString();
                        COLUMN.Font.Size = 10;
                        a++;
                        b = a;
                        if (item["ColumnName"].ToString() == "F")
                        {
                            sumQTY1 += float.Parse(DGV1.Rows[i].Cells["QUANTITY_1"].Value.ToString());
                        }
                        if (item["ColumnName"].ToString() == "G")
                        {
                            sumQTY2 += float.Parse(DGV1.Rows[i].Cells["QUANTITY_2"].Value.ToString());
                        }
                        if (item["ColumnName"].ToString() == "H")
                        {
                            sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                        }
                        if (item["ColumnName"].ToString() == "I")
                        {
                            sumGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                        }
                        if (item["ColumnName"].ToString() == "J")
                        {
                            sumPackage += float.Parse(DGV1.Rows[i].Cells["PACKAGE"].Value.ToString());
                        }
                    }
                    a = 13;
                    column++;
                }
                COMExcel.Range BORDER = IV.get_Range("A" + a, "J" + (b - 1));
                conn.BorderAround(BORDER);

                //TOTAL
                COMExcel.Range TOTAL = IV.get_Range("C" + (b), "C" + (b));
                TOTAL.Merge();
                TOTAL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL.Font.Bold = true;
                TOTAL.Value2 = "TOTAL : ";

                COMExcel.Range TOTAL_QTY1 = IV.get_Range("F" + (b), "F" + (b));
                TOTAL_QTY1.Merge();
                TOTAL_QTY1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_QTY1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_QTY1.Font.Bold = true;
                TOTAL_QTY1.NumberFormat = "#,##0.00";
                TOTAL_QTY1.Value2 = sumQTY1;

                COMExcel.Range TOTAL_QTY2 = IV.get_Range("G" + (b), "G" + (b));
                TOTAL_QTY2.Merge();
                TOTAL_QTY2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_QTY2.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_QTY2.Font.Bold = true;
                TOTAL_QTY2.NumberFormat = "#,##0.00";
                TOTAL_QTY2.Value2 = sumQTY2;

                COMExcel.Range TOTAL_NW = IV.get_Range("H" + (b), "H" + (b));
                TOTAL_NW.Merge();
                TOTAL_NW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_NW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_NW.Font.Bold = true;
                TOTAL_NW.NumberFormat = "#,##0.00";
                TOTAL_NW.Value2 = sumNW;

                COMExcel.Range TOTAL_GW = IV.get_Range("I" + (b), "I" + (b));
                TOTAL_GW.Merge();
                TOTAL_GW.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_GW.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_GW.Font.Bold = true;
                TOTAL_GW.NumberFormat = "#,##0.00";
                TOTAL_GW.Value2 = sumGW;

                COMExcel.Range TOTAL_PACKAGE = IV.get_Range("J" + (b), "J" + (b));
                TOTAL_PACKAGE.Merge();
                TOTAL_PACKAGE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_PACKAGE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TOTAL_PACKAGE.Font.Bold = true;
                TOTAL_PACKAGE.NumberFormat = "#,##0.00";
                TOTAL_PACKAGE.Value2 = sumPackage;
                //check open excel

                COMExcel.Range TOTAL_ALl_PACKAGE = IV.get_Range("A" + (b + 1), "C" + (b + 1));
                TOTAL_ALl_PACKAGE.Merge();
                TOTAL_ALl_PACKAGE.Font.Size = 14;
                TOTAL_ALl_PACKAGE.NumberFormat = "#,##0.00";
                TOTAL_ALl_PACKAGE.Value2 = "TOTAL: " + sumPackage + " ROLLS";

                COMExcel.Range TOTAL_ALl_NW = IV.get_Range("A" + (b + 2), "C" + (b + 2));
                TOTAL_ALl_NW.Merge();
                TOTAL_ALl_NW.Font.Size = 14;
                TOTAL_ALl_NW.NumberFormat = "#,##0.00";
                TOTAL_ALl_NW.Value2 = "N.W = " + sumNW + " KGS";

                COMExcel.Range TOTAL_ALl_GW = IV.get_Range("A" + (b + 3), "C" + (b + 3));
                TOTAL_ALl_GW.Merge();
                TOTAL_ALl_GW.Font.Size = 14;
                TOTAL_ALl_GW.NumberFormat = "#,##0.00";
                TOTAL_ALl_GW.Value2 = "G.W = " + sumGW + " KGS";

                COMExcel.Range TITLE = IV.get_Range("F" + (b + 4), "J" + (b + 4));
                TITLE.Merge();
                TITLE.Font.Size = 14;
                TITLE.Font.Bold = true;
                TITLE.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TITLE.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                TITLE.Value2 = "WEITAI VIETNAM LEATHER CO., LTD";

                app.Quit();
                con.releaseObject(book);
                con.releaseObject(app);
            }
        }
        private void getDatedaymonyear()
        {
            if (!string.IsNullOrEmpty(txtDate.Text) && txtDate.MaskFull == true)
            {
                string sql = "EXEC getDate_3N '" + con.formatstr2(txtDate.Text) + "'";
                DataTable getdate = new DataTable();
                getdate = con.readdata(sql);
                date_add = getdate.Rows[0]["DATE"].ToString();
            }
            else
            {
                month = "";
                day = "";
                year = "";
            }
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void addData()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtInvoice.Text))
                {
                    if (DGV1.Rows.Count > 0)
                    {

                        DialogResult dialog = MessageBox.Show("Bạn muốn lưu mã Invoice " + txtInvoice.Text + " này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialog == DialogResult.OK)
                        {
                            string sql = "INSERT INTO dbo.tblPackingList_Type2(DATECREATE,INVOICE,C_NO,USER_NAME,BUYER)" +
                                "SELECT '" + getDate() + "','" + txtInvoice.Text + "','" + txtC_NO.Text + "','" + lbUserName.Text + "','" + txtBuyer.Text + "'";

                            bool a = con.exedata(sql);
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
                string sql = "";
                if (DGV1.Rows[i].Cells["OR_NO"].Value.ToString() == "'''")
                {
                    sql = "INSERT INTO tblDescription_PackingList_Type2(INVOICE,OR_NO,MTLCODE,DESCRIPTION,WIDTH,UNIT,QTY_1,QTY_2,NW,GW,PACKAGE)" +
               " SELECT '" + txtInvoice.Text + "','''''''','''''''','''''''','''''''','''''''','" + float.Parse(DGV1.Rows[i].Cells["QUANTITY_1"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["QUANTITY_2"].Value.ToString()) + "'" +
               ",'" + float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["PACKAGE"].Value.ToString()) + "'";
                }
                else
                {
                    sql = "INSERT INTO tblDescription_PackingList_Type2(INVOICE,OR_NO,MTLCODE,DESCRIPTION,WIDTH,UNIT,QTY_1,QTY_2,NW,GW,PACKAGE)" +
                 " SELECT '" + txtInvoice.Text + "','" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "','" + DGV1.Rows[i].Cells["MTLCODE"].Value.ToString() + "','" + DGV1.Rows[i].Cells["DESCRIPTION"].Value.ToString() + "'" +
                 ",'" + DGV1.Rows[i].Cells["WIDTH"].Value.ToString() + "'" + ",'" + DGV1.Rows[i].Cells["UNIT"].Value.ToString() + "'" + ",'" + float.Parse(DGV1.Rows[i].Cells["QUANTITY_1"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["QUANTITY_2"].Value.ToString()) + "'" +
                 ",'" + float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["PACKAGE"].Value.ToString()) + "'";
                }
                bool a = con.exedata(sql);
            }
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
                        string sql = "DELETE FROM tblPackingList_Type2 WHERE INVOICE = '" + txtInvoice.Text + "'";
                        bool a = con.exedata(sql);
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
        private void DeleteDatagribview()
        {
            string sql = "DELETE FROM tblDescription_PackingList_Type2 WHERE INVOICE = '" + txtInvoice.Text + "'";
            bool a = con.exedata(sql);
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
                            string sql = "UPDATE tblPackingList_Type2 SET DATECREATE = '" + getDate() + "',INVOICE = '" + txtInvoice.Text + "',C_NO = '" + txtC_NO.Text + "',USER_NAME = '" + lbUserName.Text + "',BUYER = '" + txtBuyer.Text + "' FROM tblPackingList_Type2 WHERE INVOICE = '" + txtInvoice.Text + "'";
                            bool a = con.exedata(sql);
                            if (a == true)
                            {
                                UpdateDataGribView();
                                LoadData(txtInvoice.Text);
                                txtInvoice.ReadOnly = false;
                            }
                        }
                        else
                        {
                            txtInvoice.ReadOnly = false;
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

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btxemtruoc.PerformClick();
        }

        private bool checkExsits(string t)
        {
            string sql = "SELECT TOP 1 * FROM tblPackingList_Type2 where INVOICE = '" + t + "'";
            DataTable data = new DataTable();
            data = con.readdata(sql);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void LoadData(string invoice)
        {
            try
            {
                string sql = "SELECT A.*,B.C_NAME,B.ADDRESS,B.PHONE,B.FAX FROM tblPackingList_Type2 AS A INNER JOIN dbo.tblInfoCustomer AS B ON B.C_NO = A.C_NO WHERE A.INVOICE = '" + invoice + "'";
                DataTable data1 = new DataTable();
                data1 = con.readdata(sql);
                foreach (DataRow item in data1.Rows)
                {
                    txtC_NO.Text = item["C_NO"].ToString();
                    txtC_NAME.Text = item["C_NAME"].ToString();
                    txtADR.Text = item["ADDRESS"].ToString();
                    txtTEL.Text = item["PHONE"].ToString();
                    txtFAX.Text = item["FAX"].ToString();
                    txtDate.Text = item["DATECREATE"].ToString();
                    txtInvoice.Text = item["INVOICE"].ToString();
                    txtUSR_NAME.Text = item["USER_NAME"].ToString();
                    txtBuyer.Text = item["BUYER"].ToString();
                }
                string sql2 = "SELECT OR_NO,MTLCODE,DESCRIPTION,WIDTH,UNIT,QTY_1 AS QUANTITY_1,QTY_2 AS QUANTITY_2,NW,GW,PACKAGE FROM dbo.tblDescription_PackingList_Type2 WHERE INVOICE = '" + invoice + "'";
                dt = con.readdata(sql2);
                DGV1.DataSource = dt;
                con.DGV(DGV1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string getDate()
        {
            string txtDate_New = "";
            if (con.Check_MaskedText(txtDate) == true)
            {
                txtDate_New = con.formatstr2(txtDate.Text);
            }
            else
            {
                txtDate_New = "";
            }
            return txtDate_New;
        }
    }
}
