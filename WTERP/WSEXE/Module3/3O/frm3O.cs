using CrystalDecisions.CrystalReports.Engine;
using LibraryCalender;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WTERP.WSEXE;
using WTERP.WSEXE.ReportView;
using static WTERP.WSEXE.Report;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm3O : Form
    {
        DataTable dt = new DataTable();
        DataProvider con = new DataProvider();
        // date 
        string month = "";
        string day = "";
        string year = "";
        string date_add = "";

        public static double HANG_SO = 0.0929;
        public frm3O()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        public class DL3O
        {
            public static string key_C_NO;
        }

        private void load()
        {
            con.CheckLoad(menuStrip1);
            loadinfo();
            loadfirst();
            con.DGV(DGV1);

            f3ToolStripMenuItem.Enabled = true;
            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;

            txtInvoice.ReadOnly = false;
        }
        private void loadfirst()
        {
            txtShip.Text = "WEI TAI VIET NAM LEATHER CO.,LTD ON BEHALF OF TOPPING CO.,LTD.";
            txtAd.Text = "NHON TRACH III INDUSTRIAL ZONE,DONG NAI PROVINCE,VIET NAM.";
            txtFr.Text = "WEITAI";

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
        private void frm3O_Load(object sender, EventArgs e)
        {
            load();
        }

        private void ClickInsertDataGridview()
        {
            try
            {
                DL3O.key_C_NO = txtC_NO.Text;
                frm3O_DGV frm3O_DGV = new frm3O_DGV();
                frm3O_DGV.ShowDialog();
                if (dt.Rows.Count > 0)
                {
                    DataTable dt_new = new DataTable();
                    dt_new = frm3O_DGV.DL_3O.data;
                    dt.Merge(dt_new);
                }
                else
                {
                    dt = frm3O_DGV.DL_3O.data;
                }
                DGV1.DataSource = dt;
                con.DGV(DGV1);
            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
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
                            int key = oneCell.RowIndex;
                            DGV1.Rows.RemoveAt(oneCell.RowIndex);
                            // data.Rows.RemoveAt(key);
                        }
                    }
                    break;
            }
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
                        txtTermofdelivery.Text = "";
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
                txtTermofdelivery.Text = "";

            }
        }
        private void btxemtruoc_Click(object sender, EventArgs e)
        {
            getDatedaymonyear();

            if (cbTachTen.Checked == false)
            {
                ReportDocument cryRpt = new Cr_Form3O_1();
                getDataParamter(cryRpt);
                cryRpt.DataDefinition.FormulaFields["TermOf"].Text = "'" + txtTermofdelivery.Text + "'";
                cryRpt.SetDataSource(dt);
                ShareReport.repo = cryRpt;
                Report frm = new Report();
                frm.ShowDialog();
            }
            else
            {
                ReportDocument cryRpt = new Cr_Form3O_2();
                getDataParamter(cryRpt);
                cryRpt.SetDataSource(dt);
                ShareReport.repo = cryRpt;
                Report frm = new Report();
                frm.ShowDialog();
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
                Cno += float.Parse(DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString());
                Qty += float.Parse(DGV1.Rows[i].Cells["Qty"].Value.ToString());
                NW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                GW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
            }
            cryRpt.DataDefinition.FormulaFields["TOTAL_CNO"].Text = "'" + Cno.ToString() + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_QTY"].Text = "'" + string.Format(Qty.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_NW"].Text = "'" + string.Format(NW.ToString(), "#,##0.00") + "'";
            cryRpt.DataDefinition.FormulaFields["TOTAL_GW"].Text = "'" + string.Format(GW.ToString(), "#,##0.00") + "'";

        }
        private void checkExport()
        {
            getDatedaymonyear();
            if (cbTachTen.Checked == false)
            {
                string workbookPath = con.LinkTemplate + "Template_xuatExcel_PackingList_Type_1.xls";
                string filePath = con.LinkTemplate_SAVE + "Template_xuatExcel_PackingList_Type_1.xls";
                xuatExcel_PackingList1(workbookPath, filePath);
            }
            else
            {
                string workbookPath = con.LinkTemplate + "Template_xuatExcel_PackingList_Type_2.xls";
                string filePath = con.LinkTemplate_SAVE + "Template_xuatExcel_PackingList_Type_2.xls";
                xuatExcel_PackingList2(workbookPath, filePath);
            }
        }
        private void xuatExcel_PackingList1(string workbookPath, string filePath)
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
                ADR.Value2 = "TEL: " + txtADR.Text.ToUpper();

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
                Temp.Value2 = "Term of delivery: " + txtTermofdelivery.Text.ToUpper();

                COMExcel.Range to = IV.get_Range("A13", "C13");
                to.Merge();
                to.Value2 = "TO : " + txtTo.Text.ToUpper();

                COMExcel.Range FROM = IV.get_Range("E13", "H13");
                FROM.Merge();
                FROM.Value2 = "FROM : " + txtFr.Text.ToUpper();

                int a = 16;
                float sumQTY = 0;
                float sumNW = 0;
                float sumGW = 0;
                float NO = 0;

                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                    CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.Merge();
                    CNO.Value2 = DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString();

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
                    DESCRIPTION.Value2 = DGV1.Rows[i].Cells["DESCRIPTION"].Value.ToString();

                    COMExcel.Range NPL = IV.get_Range("D" + a, "D" + a);
                    NPL.Merge();
                    NPL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.Value2 = (string.IsNullOrEmpty(DGV1.Rows[i].Cells["NPL"].Value.ToString()) ? "" : DGV1.Rows[i].Cells["NPL"].Value.ToString());

                    COMExcel.Range THICKNESS = IV.get_Range("E" + a, "E" + a);
                    THICKNESS.Merge();
                    THICKNESS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.Value2 = DGV1.Rows[i].Cells["THICKNESS"].Value.ToString();

                    COMExcel.Range QTY = IV.get_Range("F" + a, "F" + a);
                    QTY.Merge();
                    QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.NumberFormat = "#,##0.00";
                    QTY.Value2 = DGV1.Rows[i].Cells["QTY"].Value.ToString();

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

                    sumQTY += float.Parse(DGV1.Rows[i].Cells["QTY"].Value.ToString());
                    sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                    sumGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                    NO += float.Parse(DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString());

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
                con.releaseObject(book);
                con.releaseObject(app);

                #endregion
            }
        }
        private void xuatExcel_PackingList2(string workbookPath, string filePath)
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

                for (int i = 0; i < DGV1.Rows.Count; i++)
                {
                    COMExcel.Range CNO = IV.get_Range("A" + a, "A" + a);
                    CNO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    CNO.Merge();
                    CNO.Value2 = DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString();

                    COMExcel.Range OR_NO = IV.get_Range("B" + a, "B" + a);
                    OR_NO.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    OR_NO.Merge();
                    OR_NO.Value2 = DGV1.Rows[i].Cells["IRNNUMBER_LEFT"].Value.ToString();

                    COMExcel.Range DESCRIPTION = IV.get_Range("C" + a, "C" + a);
                    DESCRIPTION.Merge();
                    DESCRIPTION.WrapText = true;
                    DESCRIPTION.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    DESCRIPTION.Value2 = DGV1.Rows[i].Cells["DESCRIPTION"].Value.ToString();

                    COMExcel.Range NPL = IV.get_Range("D" + a, "D" + a);
                    NPL.Merge();
                    NPL.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    NPL.Value2 = DGV1.Rows[i].Cells["IRNNUMBER_RIGHT"].Value.ToString();

                    COMExcel.Range THICKNESS = IV.get_Range("E" + a, "E" + a);
                    THICKNESS.Merge();
                    THICKNESS.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    THICKNESS.Value2 = DGV1.Rows[i].Cells["THICKNESS"].Value.ToString();

                    COMExcel.Range QTY = IV.get_Range("F" + a, "F" + a);
                    QTY.Merge();
                    QTY.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    QTY.NumberFormat = "#,##0.00";
                    QTY.Value2 = DGV1.Rows[i].Cells["QTY"].Value.ToString();

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

                    sumQTY += float.Parse(DGV1.Rows[i].Cells["QTY"].Value.ToString());
                    sumNW += float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString());
                    sumGW += float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString());
                    NO += float.Parse(DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString());

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
                con.releaseObject(book);
                con.releaseObject(app);

                #endregion
            }
        }

        private void cbTachTen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTachTen.Checked == true)
            {
                this.DGV1.Columns["NPL"].Visible = false;
            }
            else
            {
                this.DGV1.Columns["NPL"].Visible = true;
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
        private void f1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                DL3O.key_C_NO = txtC_NO.Text;
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
            if (con.checkExists("SELECT TOP 1 * FROM tblPackingList_Type1 WHERE INVOICE = '" + txtInvoice.Text + "'") == true)
            {
                MessageBox.Show("Mã Invoice này đã có không thể thêm");
            }
            else
            {
                addData();
            }
        }
        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3ToolStripMenuItem.Enabled = true;

            f4ToolStripMenuItem.Enabled = false;
            f5ToolStripMenuItem.Enabled = false;

            setDataNull();
            string sql2 = "SELECT * FROM tblDescription_PackingList_Type1 WHERE INVOICE = '" + txtInvoice.Text + "'";
            dt = con.readdata(sql2);
            DGV1.DataSource = dt;
            con.DGV(DGV1);

            txtC_NO.Focus();
        }

        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void f6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm3OF6 frm = new frm3OF6();
            frm.ShowDialog();
            LoadData(frm3OF6.DL3OF6.INVOICE);

            f3ToolStripMenuItem.Enabled = false;
            f4ToolStripMenuItem.Enabled = true;
            f5ToolStripMenuItem.Enabled = true;

            txtInvoice.ReadOnly = true;
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
            txtTermofdelivery.Text = "";
            cbTachTen.Checked = false;
            //datagridview
        }

        private void f7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkExport();
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
                            string sql = "INSERT INTO dbo.tblPackingList_Type1(DATECREATE,INVOICE,C_NO,USER_NAME,TermOfDelivery,checkCutName,To_Name)" +
                                "SELECT '" + getDate() + "','" + txtInvoice.Text + "','" + txtC_NO.Text + "','" + lbUserName.Text + "','" + txtTermofdelivery.Text + "'," +
                                "'" + FormatCheckBox(cbTachTen) + "','" + txtTo.Text + "'";
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
                string sql = "INSERT INTO dbo.tblDescription_PackingList_Type1(INVOICE,CNO,OR_NO,DESCRIPTION,THICKNESS,QTY,NW,GW,NPL,IRNNUMBER_LEFT,IRNNUMBER_RIGHT)" +
                "SELECT '" + txtInvoice.Text + "','" + DGV1.Rows[i].Cells["NO_NUMBER"].Value.ToString() + "','" + DGV1.Rows[i].Cells["OR_NO"].Value.ToString() + "','" + DGV1.Rows[i].Cells["DESCRIPTION"].Value.ToString() + "'" +
                ",'" + DGV1.Rows[i].Cells["THICKNESS"].Value.ToString() + "'" + ",'" + float.Parse(DGV1.Rows[i].Cells["QTY"].Value.ToString()) + "'" +
                ",'" + float.Parse(DGV1.Rows[i].Cells["NW"].Value.ToString()) + "','" + float.Parse(DGV1.Rows[i].Cells["GW"].Value.ToString()) + "','" + DGV1.Rows[i].Cells["NPL"].Value.ToString() + "','" + DGV1.Rows[i].Cells["IRNNUMBER_LEFT"].Value.ToString() + "'," +
                "'" + DGV1.Rows[i].Cells["IRNNUMBER_RIGHT"].Value.ToString() + "'";
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
                        string sql = "DELETE FROM tblPackingList_Type1 WHERE INVOICE = '" + txtInvoice.Text + "'";
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
            string sql = "DELETE FROM tblDescription_PackingList_Type1 WHERE INVOICE = '" + txtInvoice.Text + "'";
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
                            string sql = "UPDATE tblPackingList_Type1 SET DATECREATE = '" + getDate() + "',INVOICE = '" + txtInvoice.Text + "',C_NO = '" + txtC_NO.Text + "',USER_NAME = '" + lbUserName.Text + "'," +
                                "TermOfDelivery = '" + txtTermofdelivery.Text + "',checkCutName = '" + FormatCheckBox(cbTachTen) + "',To_Name = '" + txtTo.Text + "'" +
                                " FROM tblPackingList_Type1 WHERE INVOICE = '" + txtInvoice.Text + "'";
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
        private bool checkExsits(string t)
        {
            string sql = "SELECT TOP 1 * FROM tblPackingList_Type1 where INVOICE = '" + t + "'";
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
                string sql = "SELECT A.*,B.C_NAME,B.ADDRESS,B.PHONE,B.FAX FROM tblPackingList_Type1 AS A INNER JOIN dbo.tblInfoCustomer AS B ON B.C_NO = A.C_NO WHERE A.INVOICE = '" + invoice + "'";
                DataTable data1 = new DataTable();
                data1 = con.readdata(sql);
                foreach (DataRow item in data1.Rows)
                {
                    txtC_NO.Text = item["C_NO"].ToString();
                    txtC_NAME.Text = item["C_NAME"].ToString();
                    txtADR.Text = item["ADDRESS"].ToString();
                    txtTEL.Text = item["PHONE"].ToString();
                    txtFAX.Text = item["FAX"].ToString();
                    txtTermofdelivery.Text = item["TermOfDelivery"].ToString();
                    txtDate.Text = item["DATECREATE"].ToString();
                    txtInvoice.Text = item["INVOICE"].ToString();
                    txtTo.Text = item["To_Name"].ToString();
                    txtUSR_NAME.Text = item["USER_NAME"].ToString();

                    if (item["checkCutName"].ToString() == "True")
                    {
                        cbTachTen.Checked = true;
                    }
                    else
                    {
                        cbTachTen.Checked = false;
                    }
                }
                string sql2 = "SELECT CNO,OR_NO,DESCRIPTION,THICKNESS as THICK,QTY,NW,GW,NPL,IRNNUMBER_LEFT,IRNNUMBER_RIGHT FROM dbo.tblDescription_PackingList_Type1 WHERE INVOICE = '" + invoice + "'";
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
    }
}
