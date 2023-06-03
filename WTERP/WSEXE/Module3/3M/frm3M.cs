using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP.WSEXE
{
    public partial class frm3M : Form
    {
        DataProvider conn = new DataProvider();
        int key;
        string key_start = "B";
        string key_end = "CG";
        int buocdem = 7;
        public frm3M()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void frm3M_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.ToString("yyyy");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getK_NO();
            if (radioButton1.Checked == true)
            {
                string workbookPath = conn.LinkTemplate + "WEITAI_SALES_VOLUME_SUMARRY.xls";
                string filePath = conn.LinkTemplate_SAVE + "WEITAI_SALES_VOLUME_SUMARRY.xls";
                BaoCaoSo1(workbookPath, filePath);
            }
            else if (radioButton2.Checked == true)
            {
                string workbookPath = conn.LinkTemplate + "COMPENRATION_DETAILS.xls";
                string filePath = conn.LinkTemplate_SAVE + "COMPENRATION_DETAILS.xls";
                BaoCaoSo2(workbookPath, filePath);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void getK_NO()
        {
            if (radioButton4.Checked == true)
            {
                key = 3;
            }
            else if (radioButton3.Checked == true)
            {
                key = 4;
            }
        }
        private void BaoCaoSo1(string workbookPath,string filePath)
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
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    app.Visible = true;

                    //hang sx
                    COMExcel.Range Year = IV.get_Range("A1", "D1");
                    Year.Merge();
                    Year.Font.Bold = true;
                    Year.Font.Size = 16;
                    Year.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Year.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Year.Value2 = txtYear.Text;

                    string sql = "EXEC Export_Sales_Volume_Sumary '" + txtYear.Text + "','" + txtP_NAME_START.Text + "','" + txtP_NAME_END.Text + "'," + key + "";
                    DataTable data = new DataTable();
                    data = conn.readdata(sql);
                    int rows = 3;

                    string[] key_SampleallBrands = { "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" };

                    if (data.Rows.Count > 0)
                    {
                        foreach (DataRow item in data.Rows)
                        {
                            COMExcel.Range MTRL = IV.get_Range("B" + (rows), "B" + (rows));
                            MTRL.Value2 = item["BRAND"].ToString();

                            COMExcel.Range THICK = IV.get_Range("C" + (rows), "C" + (rows));
                            THICK.Value2 = item["P_NAME3"].ToString();

                            int stt_1 = 0;
                            for (int i = 0; i < key_SampleallBrands.Length; i++)
                            {
                                stt_1 = i + 1;
                                // truyền dữ liệu
                                COMExcel.Range T1 = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows), "" + key_SampleallBrands[i] + "" + (rows));
                                T1.NumberFormat = "#,##0.00";
                                T1.Value2 = item["T" + stt_1 + ""].ToString();

                            }
                            COMExcel.Range SUBTOTAL = IV.get_Range("D" + (rows), "D" + (rows));
                            SUBTOTAL.NumberFormat = "#,##0.00";
                            SUBTOTAL.Value2 = "=SUM(E" + rows + ":P" + rows + ")";

                            rows++;
                        }
                        COMExcel.Range Border = IV.get_Range("B3", "P" + (rows - 1));
                        conn.BorderAround(Border);

                        COMExcel.Range Total_SF = IV.get_Range("C" + (rows), "C" + (rows));
                        Total_SF.Font.Bold = true;
                        Total_SF.Value2 = "TOTAL SF";

                        for (int i = 0; i < key_SampleallBrands.Length; i++)
                        {
                            COMExcel.Range SubtotaL2 = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows), "" + key_SampleallBrands[i] + "" + (rows));
                            SubtotaL2.NumberFormat = "#,##0.00";
                            SubtotaL2.Value2 = "=SUM(" + key_SampleallBrands[i] + "2" + ":" + "" + key_SampleallBrands[i] + "" + (rows - 1) + ")";
                        }
                        COMExcel.Range Total_SF_sum = IV.get_Range("D" + (rows), "D" + (rows));
                        Total_SF_sum.NumberFormat = "#,##0.00";
                        Total_SF_sum.Value2 = "=SUM(E" + (rows) + ":P" + (rows) + ")";
                        Total_SF_sum.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Orange);

                        COMExcel.Range Total_Revenue = IV.get_Range("C" + (rows + 1), "C" + (rows + 1));
                        Total_Revenue.Font.Bold = true;
                        Total_Revenue.Value2 = "Total Revenue $";

                        int b = 0;
                        for (int i = 0; i < key_SampleallBrands.Length; i++)
                        {
                            b = i + 1;
                            COMExcel.Range SubtotaL2 = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows), "" + key_SampleallBrands[i] + "" + (rows));
                            SubtotaL2.NumberFormat = "#,##0.00";
                            SubtotaL2.Value2 = "=SUM(" + key_SampleallBrands[i] + "2" + ":" + "" + key_SampleallBrands[i] + "" + (rows - 1) + ")";

                            foreach (DataRow item2 in data.Rows)
                            {
                                COMExcel.Range Total_Revenue_T1 = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows + 1), "" + key_SampleallBrands[i] + "" + (rows + 1));
                                Total_Revenue_T1.NumberFormat = "#,##0.00";
                                Total_Revenue_T1.Value2 = item2["T" + b + "_TOTAL"].ToString();
                            }
                        }
                        COMExcel.Range Total_Revenue_sum = IV.get_Range("D" + (rows + 1), "D" + (rows + 1));
                        Total_Revenue_sum.NumberFormat = "#,##0.00";
                        Total_Revenue_sum.Value2 = "=SUM(E" + (rows + 1) + ":P" + (rows + 1) + ")";
                        Total_Revenue_sum.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Orange);

                        COMExcel.Range Border2 = IV.get_Range("C" + (rows), "P" + (rows + 1));
                        conn.BorderAround(Border2);

                        string[] Month = { "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" };
                        string[] keysword = { "Avg.", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                        for (int i = 0; i < Month.Length; i++)
                        {
                            COMExcel.Range ROWSample1 = IV.get_Range("" + Month[i] + "" + (rows + 3), "" + Month[i] + "" + (rows + 3));
                            ROWSample1.Font.Bold = true;
                            ROWSample1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            ROWSample1.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                            ROWSample1.Value2 = keysword[i];
                        }
                        COMExcel.Range Border3 = IV.get_Range("D" + (rows + 3), "P" + (rows + 3));
                        conn.BorderAround(Border3);
                        Border3.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gray);

                        COMExcel.Range SampleallBrands = IV.get_Range("B" + (rows + 4), "B" + (rows + 6));
                        SampleallBrands.Merge();
                        SampleallBrands.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SampleallBrands.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SampleallBrands.Value2 = "Sample/ all brands";

                        COMExcel.Range SampleallBrands1 = IV.get_Range("C" + (rows + 4), "C" + (rows + 4));
                        SampleallBrands1.Value2 = "Total shippment/SF";

                        COMExcel.Range SampleallBrands2 = IV.get_Range("C" + (rows + 5), "C" + (rows + 5));
                        SampleallBrands2.Value2 = "Total Capacity/SF";

                        COMExcel.Range SampleallBrands3 = IV.get_Range("C" + (rows + 6), "C" + (rows + 6));
                        SampleallBrands3.Value2 = "Fill rate";

                        // hang sx
                        COMExcel.Range SampleallProduction = IV.get_Range("B" + (rows + 8), "B" + (rows + 10));
                        SampleallProduction.Merge();
                        SampleallProduction.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SampleallProduction.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        SampleallProduction.Value2 = "Production/ all brands";

                        COMExcel.Range SampleallBrands1_Production = IV.get_Range("C" + (rows + 8), "C" + (rows + 8));
                        SampleallBrands1_Production.Value2 = "Total shippment/SF";

                        COMExcel.Range SampleallBrands2_Production = IV.get_Range("C" + (rows + 9), "C" + (rows + 9));
                        SampleallBrands2_Production.Value2 = "Total Capacity/SF";

                        COMExcel.Range SampleallBrands3_Production = IV.get_Range("C" + (rows + 10), "C" + (rows + 10));
                        SampleallBrands3_Production.Value2 = "Fill rate";

                        DataTable dataTable = new DataTable();
                        //dataTable = conn.readdata("EXEC Export_Sales_Volume_Sumary_Continue '" + txtYear.Text + "','" + txtP_NAME_START.Text + "','" + txtP_NAME_END.Text + "'," + key + "");
                        dataTable = conn.readdata("EXEC Export_Sales_Volume_Sumary_Continue '" + txtYear.Text + "'");

                        DataTable dataTableSX = new DataTable();
                        // dataTableSX = conn.readdata("EXEC Export_Sales_Volume_Sumary_Continue_2 '" + txtYear.Text + "','" + txtP_NAME_START.Text + "','" + txtP_NAME_END.Text + "'," + key + "");

                        dataTableSX = conn.readdata("EXEC Export_Sales_Volume_Sumary_Continue_2 '" + txtYear.Text + "'");
                        // truyền dữ liệu
                        int stt = 0;
                        for (int i = 0; i < key_SampleallBrands.Length; i++)
                        {
                            stt = i + 1;
                            COMExcel.Range SampleallBrands_T1 = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows + 4), "" + key_SampleallBrands[i] + "" + (rows + 4));
                            SampleallBrands_T1.NumberFormat = "#,##0.00";
                            SampleallBrands_T1.Value2 = dataTable.Rows[0]["T" + stt + ""].ToString();

                            COMExcel.Range SampleallBrands_T1_Production = IV.get_Range("" + key_SampleallBrands[i] + "" + (rows + 8), "" + key_SampleallBrands[i] + "" + (rows + 8));
                            SampleallBrands_T1_Production.NumberFormat = "#,##0.00";
                            SampleallBrands_T1_Production.Value2 = dataTableSX.Rows[0]["T" + stt + ""].ToString();
                        }
                        COMExcel.Range SampleallBrands1_agv = IV.get_Range("D" + (rows + 4), "D" + (rows + 4));
                        SampleallBrands1_agv.NumberFormat = "#,##0.00";
                        SampleallBrands1_agv.Value2 = "=AVERAGE(E" + (rows + 4) + ":P" + (rows + 4) + ")";

                        COMExcel.Range SampleallBrands1_agv_Production = IV.get_Range("D" + (rows + 8), "D" + (rows + 8));
                        SampleallBrands1_agv_Production.NumberFormat = "#,##0.00";
                        SampleallBrands1_agv_Production.Value2 = "=AVERAGE(E" + (rows + 8) + ":P" + (rows + 8) + ")";

                        for (int i = 0; i < Month.Length; i++)
                        {
                            //dong thu 2
                            // truyền dữ liệu
                            COMExcel.Range SampleallBrands_T1_row2 = IV.get_Range("" + Month[i] + "" + (rows + 5), "" + Month[i] + "" + (rows + 5));
                            SampleallBrands_T1_row2.NumberFormat = "#,##0.00";
                            SampleallBrands_T1_row2.Value2 = "90000";

                            //dong thu 2
                            // truyền dữ liệu
                            COMExcel.Range SampleallBrands_T1_row2_Production = IV.get_Range("" + Month[i] + "" + (rows + 9), "" + Month[i] + "" + (rows + 9));
                            SampleallBrands_T1_row2_Production.NumberFormat = "#,##0.00";
                            SampleallBrands_T1_row2_Production.Value2 = "5000000";

                            COMExcel.Range SampleallBrands_T1_row3 = IV.get_Range("" + Month[i] + "" + (rows + 6), "" + Month[i] + "" + (rows + 6));
                            SampleallBrands_T1_row3.NumberFormat = "#,##0.00%";
                            SampleallBrands_T1_row3.Value2 = "=" + Month[i] + "" + (rows + 4) + " / " + Month[i] + "" + (rows + 5) + "";

                            //dong thu 3
                            // truyền dữ liệu
                            COMExcel.Range SampleallBrands_T1_row3_Production = IV.get_Range("" + Month[i] + "" + (rows + 10), "" + Month[i] + "" + (rows + 10));
                            SampleallBrands_T1_row3_Production.NumberFormat = "#,##0.00%";
                            SampleallBrands_T1_row3_Production.Value2 = "=" + Month[i] + "" + (rows + 8) + " / " + Month[i] + "" + (rows + 9) + "";
                        }
                        COMExcel.Range Border4 = IV.get_Range("B" + (rows + 4), "P" + (rows + 6));
                        conn.BorderAround(Border4);

                        COMExcel.Range Border4_Production = IV.get_Range("B" + (rows + 8), "P" + (rows + 10));
                        conn.BorderAround(Border4_Production);

                        IV.Columns.AutoFit();

                        app.Quit();
                        conn.releaseObject(book);
                        conn.releaseObject(app);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BaoCaoSo2(string workbookPath, string filePath)
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
                    COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                    app.Visible = true;

                    //hang sx
                    COMExcel.Range Year = IV.get_Range("B1", "G1");
                    Year.Merge();
                    Year.Font.Bold = true;
                    Year.Font.Size = 20;
                    Year.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Year.VerticalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    Year.Value2 = txtYear.Text;


                    string sql = "EXEC Export_Sales_Volume_Sumary_Year '" + txtYear.Text + "','" + txtP_NAME_START.Text + "','" + txtP_NAME_END.Text + "'," + key + "";
                    DataTable data = new DataTable();
                    data = conn.readdata(sql);
                    int rows = 4;
                    if (data.Rows.Count > 0)
                    {
                        DataTable table = new DataTable();
                        table = conn.readdata("EXEC [sp_ColumnExcelList] '" + key_start + "','" + key_end + "'");
                        foreach (DataRow item in data.Rows)
                        {
                            COMExcel.Range MTRL = IV.get_Range("A" + (rows), "A" + (rows));
                            MTRL.Value2 = item["BRAND"].ToString();

                            int number = 1;
                            for (int i = 0; i < table.Rows.Count; i = i + buocdem)
                            {
                                COMExcel.Range T1 = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                                T1.NumberFormat = "#,##0.00";
                                T1.Value2 = item["T" + number + "_XUAT"].ToString();
                                number++;
                            }
                            int number2 = 1;
                            for (int i = 1; i < table.Rows.Count; i = i + buocdem)
                            {
                                COMExcel.Range T1 = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                                T1.NumberFormat = "#,##0.00";
                                T1.Value2 = item["T" + number2 + "_BU"].ToString();
                                number2++;
                            }
                            int number3 = 1;
                            for (int i = 2; i < table.Rows.Count; i = i + buocdem)
                            {
                                COMExcel.Range T1 = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                                T1.NumberFormat = "#,##0.00";
                                T1.Value2 = item["T" + number3 + "_TRA"].ToString();
                                number3++;
                            }
                            //tính tỉ lệ
                            int number_4 = 1;
                            for (int i = 4; i < table.Rows.Count; i = i + buocdem)
                            {

                                // tỉ lệ hang bù
                                COMExcel.Range T1_Tile = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                                if (float.Parse(item["T" + number_4 + "_XUAT"].ToString()) == 0)
                                {
                                    T1_Tile.Value2 = "0.00%";
                                }
                                else
                                {
                                    float num = float.Parse(item["T" + number_4 + "_BU"].ToString()) / float.Parse(item["T" + number_4 + "_XUAT"].ToString()) * 100;
                                    T1_Tile.Value2 = Math.Round(num, 2).ToString() + "%";

                                }
                                number_4++;
                            }
                            int number_5 = 1;
                            for (int i = 5; i < table.Rows.Count; i = i + buocdem)
                            {

                                // tỉ lệ hang tra
                                COMExcel.Range T1_Tile = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                                if (float.Parse(item["T" + number_5 + "_XUAT"].ToString()) == 0)
                                {
                                    T1_Tile.Value2 = "0.00%";
                                }
                                else
                                {
                                    float num = float.Parse(item["T" + number_5 + "_TRA"].ToString()) / float.Parse(item["T" + number_5 + "_XUAT"].ToString()) * 100;
                                    T1_Tile.Value2 = Math.Round(num, 2).ToString() + "%";
                                }
                                number_5++;
                            }
                            rows++;
                        }
                        COMExcel.Range Border = IV.get_Range("A4", "CG" + (rows - 1));
                        conn.BorderAround(Border);

                        COMExcel.Range Total_SF = IV.get_Range("A" + (rows), "A" + (rows));
                        Total_SF.Font.Bold = true;
                        Total_SF.Value2 = "TOTAL SF";
                        //tổng
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            COMExcel.Range SubtotaL2 = IV.get_Range("" + table.Rows[i]["ColumnName"].ToString() + "" + (rows), "" + table.Rows[i]["ColumnName"].ToString() + "" + (rows));
                            SubtotaL2.NumberFormat = "#,##0.00";
                            SubtotaL2.Value2 = "=SUM(" + table.Rows[i]["ColumnName"].ToString() + "4:" + table.Rows[i]["ColumnName"].ToString() + "" + (rows - 1) + ")";
                        }

                        IV.Columns.AutoFit();

                        app.Quit();
                        conn.releaseObject(book);
                        conn.releaseObject(app);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }

        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtP_NAME_START_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand frm = new FormSearchBrand();
            frm.ShowDialog();
            txtP_NAME_START.Text = FormSearchBrand.ID.TRADE;
        }
        private void txtP_NAME_END_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand frm = new FormSearchBrand();
            frm.ShowDialog();
            txtP_NAME_END.Text = FormSearchBrand.ID.TRADE;
        }
        private void txtP_NAME_START_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
