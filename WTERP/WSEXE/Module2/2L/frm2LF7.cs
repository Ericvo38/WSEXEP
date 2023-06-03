using LibraryCalender;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frm2LF7 : Form
    {
        DataProvider con = new DataProvider();
        public frm2LF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
            
        }
        public string txtWS_DATE = "";
        public string txtWS_DATE1_S_Tab1 = "";
        public string txtWS_DATE1_E_tab1 = "";
        #region Mouse click
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 sr = new FormSearchStaff4();
            sr.ShowDialog();
            txtSALES1.Text = FormSearchStaff4.ID.S_NAME2;
        }

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C frcl = new FormSearchPROD1C();
            frcl.ShowDialog();
            txtBanDau.Text = FormSearchPROD1C.ID.P_NO;
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C frcl = new FormSearchPROD1C();
            frcl.ShowDialog();
            txtKetThuc.Text = FormSearchPROD1C.ID.P_NO;
        }
        private void textBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 sr = new FormSearchStaff4();
            sr.ShowDialog();
            txtNHKinhdoanh.Text = FormSearchStaff4.ID.S_NAME2;
        }

        private void textBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2BrandSearch br1 = new frm2BrandSearch();
            br1.ShowDialog();
            txtNHTHBandau.Text = frm2BrandSearch.getInfo.ID_BRAND;
            frm2BrandSearch.getInfo.ID_BRAND = "";
        }

        private void txtNHTHKetThuc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2BrandSearch br1 = new frm2BrandSearch();
            br1.ShowDialog();
            txtNHTHKetThuc.Text = frm2BrandSearch.getInfo.ID_BRAND;
            frm2BrandSearch.getInfo.ID_BRAND = "";
        }

        private void textBox12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch ct = new frm2CustSearch();
            ct.ShowDialog();
            txtTbMaKhBD.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void txtTbMaKHKT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch ct = new frm2CustSearch();
            ct.ShowDialog();
            txtTbMaKHKT.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txtTBMaNguyenLBD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C frcl = new FormSearchPROD1C();
            frcl.ShowDialog();
            txtTBMaNguyenLBD.Text = FormSearchPROD1C.ID.P_NO;
        }
        private void txtTbMaNguyenLKT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchPROD1C frcl = new FormSearchPROD1C();
            frcl.ShowDialog();
            txtTbMaNguyenLKT.Text = FormSearchPROD1C.ID.P_NO;
        }
        private void txtTbThuongBD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2BrandSearch br = new frm2BrandSearch();
            br.ShowDialog();
            txtTbThuongBD.Text = frm2BrandSearch.getInfo.ID_BRAND;
        }

        private void txtTbThuongKT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2BrandSearch br = new frm2BrandSearch();
            br.ShowDialog();
            txtTbThuongKT.Text = frm2BrandSearch.getInfo.ID_BRAND;
        }

        private void textBox14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmSearchMEMO1 ar = new FrmSearchMEMO1();
            ar.ShowDialog();
            txtKVKV.Text = FrmSearchMEMO1.ID.M_ID;
        }

        private void txtTHKD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchStaff4 sr = new FormSearchStaff4();
            sr.ShowDialog();
            txtTHKD.Text = FormSearchStaff4.ID.S_NAME2;
        }
        #endregion
        #region Change language
        //txtThongBao
        string txtNgayThang = "";
        string txtThongBao = "";
        public void checkNofication()
        {
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                txtNgayThang = "Vui lòng nhập ngày tháng";
                txtThongBao = "Thông Báo";
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                txtNgayThang = "Vui lòng nhập ngày tháng";
                txtThongBao = "Thông Báo";
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                txtNgayThang = "Please enter the date";
                txtThongBao = "Nofication";
            }
            if (DataProvider.LG.rdChina == true)
            {
                txtNgayThang = "請輸入日期";
                txtThongBao = "通知";
            }
        }
        #endregion
        private void frm2LF7_Load(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                getData();
                if (txtWS_DATE != "")
                {  
                    ProcessTab1();
                }
                else
                {
                    checkNofication();
                    MessageBox.Show(""+txtNgayThang+"", ""+txtThongBao+"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }              
            else if (tabControl1.SelectedIndex == 1)
            {
                ProcessTab2(); 
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                ProcessTab3();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                ProcessTab4();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                ProcessTab5();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                ProcessTab7();
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                ProcessTab7();
            }

        }
        public void ProcessTab1()
        {
            if (rbtEXCEL1.Checked == true)
            {
                Export_Excel1();
            }
            else if (rbtHangMau1.Checked == true || rbtHangSX1.Checked == true)
            {
                frm2LF7_Tab1 frm = new frm2LF7_Tab1();
                frm.ShowDialog();
            }    
            
        }
        private void ProcessTab2()
        {
           // MessageBox.Show("Chức năng này đang phát triển!");
        }
        private void ProcessTab3()
        {
          //  MessageBox.Show("Chức năng này đang phát triển!");
        }
        private void ProcessTab4()
        {
          //  MessageBox.Show("Chức năng này đang phát triển!");
        }
        private void ProcessTab5()
        {
          //  MessageBox.Show("Chức năng này đang phát triển!");
        }
        private void ProcessTab6()
        {
           // MessageBox.Show("Chức năng này đang phát triển!");
        }
        private void ProcessTab7()
        {
           // MessageBox.Show("Chức năng này đang phát triển!");
        }


        private void txtWS_DATE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frmDateTime1 = new FromCalender();
            frmDateTime1.ShowDialog();
            txtWS_DATE1.Text = FromCalender.getDate.ToString("yy/MM");
        }
      
        public void check()
        {
            if (con.Check_MaskedText(txtWS_DATE1) == true)
            {
                txtWS_DATE = con.formatstr1(txtWS_DATE1.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE1_S) == true)
            {
                txtWS_DATE1_S_Tab1 = con.formatstr1(txtWS_DATE1_S.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE1_E) == true)
            {
                txtWS_DATE1_E_tab1 = con.formatstr1(txtWS_DATE1_E.Text);
            }
        }
        public class getDL
        {
            public static string txtWS_DATE1;
            public static bool rdExcel1;
            public static bool rdMau1;
            public static bool rdSanXuat1;
        }

        public void getData()
        {
            check();
            getDL.txtWS_DATE1 = txtWS_DATE;
            getDL.rdExcel1 = rbtEXCEL1.Checked;
            getDL.rdMau1 = rbtHangMau1.Checked;
            getDL.rdSanXuat1 = rbtHangSX1.Checked;
        }
        #region Export
        public void Export_Excel1()
        {
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            Range Row_TieuDe = worksheet.get_Range("A2", "R2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            Range Row_3 = worksheet.get_Range("A3", "A3");
            Row_3.Font.Name = "Times New Roman";
            Row_3.Font.Size = 18;


            Range Row_4 = worksheet.get_Range("L3", "L3");
            Row_4.Font.Name = "Times New Roman";
            Row_4.Font.Size = 18;

            //Header
            Range row_header = worksheet.get_Range("A4", "R5");
            row_header.Font.Size = 12;
            row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


            Range item1 = worksheet.get_Range("A4", "A5");
            //item1.Merge();
            item1.Font.Name = "Times New Roman";
            item1.Font.Size = 12;
            item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            item1.VerticalAlignment = XlVAlign.xlVAlignCenter;

            //Auto Size
            worksheet.Columns.AutoFit();
            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }
        private static void releaseObject(object obj) // Clear COM Memory  
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
        #endregion

        private void txtWS_DATE1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtWS_DATE1_E, txtSALES1, sender, e);
        }

        private void txtSALES1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE1, txtWS_DATE1_S, sender, e);
        }

        private void txtWS_DATE1_S_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtSALES1, txtWS_DATE1_E, sender, e);
        }

        private void txtWS_DATE1_E_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE1_S, txtWS_DATE1, sender, e);
        }
    }
}
