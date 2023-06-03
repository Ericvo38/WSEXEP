using CrystalDecisions.CrystalReports.Engine;
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
using WTERP.WSEXE.ReportView;
using static WTERP.WSEXE.Report;

namespace WTERP
{
    public partial class frm2CF7 : Form
    {
        DataProvider data = new DataProvider();
        public frm2CF7()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }

        private void frm2CF7_Load(object sender, EventArgs e)
        {
            txtSoLH_S.Text = frm2C_1.F2c.sodonhang;
            txtSoLH_E.Text = frm2C_1.F2c.sodonhang;    
            txtSoLH_S.ReadOnly = true;
            txtSoLH_E.ReadOnly = true;
        }

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtInDonGia.Text == "N")
                txtInDonGia.Text = "Y";
           else if (txtInDonGia.Text == "Y")
                txtInDonGia.Text = "N";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UID = frmLogin.ID_USER; // get ID User 
                string sql = "SELECT CARB.WS_NO,CARB.WS_DATE,CARH.MEMO1,CARH.MEMO2,CARH.MEMO3,CARH.MEMO4,CARH.MEMO5,CARH.MEMO6,CARH.MEMO7,CARH.MEMO8,CARH.USR_NAME,CAST(CARB.PCS AS NVARCHAR(max)) + '件 ' + CAST(CARB.QPCS AS NVARCHAR(max)) + 'PCS ' + CAST(CAST(CARB.QTY  AS DECIMAL(20, 2))AS NVARCHAR(max)) + ' KG' AS MEMO " +
                    "" + XulyCheckPrice(txtInDonGia) + " FROM dbo.CARB INNER JOIN dbo.CARH ON CARH.WS_NO = CARB.WS_NO WHERE 1=1 AND CARB.WS_NO " +
                    "BETWEEN '" + txtSoLH_S.Text + "' AND '" + txtSoLH_E.Text + "' AND USR_NAME = '" + data.getUser(UID) + "'";
                DataTable dataTable = new DataTable();
                dataTable = data.readdata(sql);

                string sql2 = "SELECT CARB.WS_NO,CARB.WS_DATE,CARH.C_NAME,CARB.OR_NO" + XuLyRadioButton() + ", CARB.P_NAME3,CAST(CARB.BQTY  AS DECIMAL(20, 2)) AS BQTY,PRICE," +
                    "AMOUNT,CARH.MEMO1,CARH.MEMO2,CARH.MEMO3,CARH.MEMO4,CARH.MEMO5,CARH.MEMO6,CARH.MEMO7,CARH.MEMO8,CARH.USR_NAME,CAST(CARB.PCS AS NVARCHAR(max)) + '件 ' + CAST(CARB.QPCS AS NVARCHAR(max)) + 'PCS ' + CAST(CAST(CARB.QTY  AS DECIMAL(20, 2))AS NVARCHAR(max)) + ' KG' AS MEMO " +
                    "" + XulyCheckPrice(txtInDonGia) + " FROM dbo.CARB INNER JOIN dbo.CARH ON CARH.WS_NO = CARB.WS_NO WHERE 1=1 AND CARB.WS_NO " +
                    "BETWEEN '" + txtSoLH_S.Text + "' AND '" + txtSoLH_E.Text + "' AND USR_NAME = '" + data.getUser(UID) + "'";
                DataTable dataTable2 = new DataTable();
                dataTable2 = data.readdata(sql2);

                foreach (DataRow item in dataTable.Rows)
                {
                    item["WS_DATE"] = data.formatstr2(item["WS_DATE"].ToString());
                }
                if (!string.IsNullOrEmpty(txtSoLH_S.Text) && txtSoLH_S.Text.Substring(0,1) == "A")
                {
                    ReportDocument cryRpt = new Cr_Form_2CF7_Long();
                    cryRpt.SetDataSource(dataTable2);
                    ShareReport.repo = cryRpt;
                    Report frm = new Report();
                    frm.ShowDialog();
                }
                else
                {
                    ReportDocument cryRpt = new Cr_Form_2CF7();
                    cryRpt.Subreports["Sub_Report_2CF7"].SetDataSource(dataTable2);
                    cryRpt.SetDataSource(dataTable);
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

        private string XuLyRadioButton()
        {
            string key = "";
            //xử lý định dạng báo cáo
            if (radioButton1.Checked == true)
            {
                key = ","+ XuLyRadioButton2() + " +' '+ P_NAME + ' '+ CARB.C_OR_NO AS COLOR";
            }
            else if(radioButton2.Checked == true)
            {
                key = "," + XuLyRadioButton2() + " +' '+ P_NAME1 + ' '+ CARB.C_OR_NO AS COLOR";
            }
            else if(radioButton3.Checked == true)
            {
                key = "," + XuLyRadioButton2() + " +' '+ P_NAME + ' '+ CARB.C_OR_NO AS COLOR";
            }
            else if(radioButton4.Checked == true)
            {
                key = "," + XuLyRadioButton2() + " +' '+ P_NAME1 + ' '+ CARB.C_OR_NO AS COLOR";
            }
            else
            {
                key = ",'' as COLOR";
            }    
            return key;
        }
        private string XuLyRadioButton2()
        {
            string key = "";
            //xử lý màu sắc
            if (radioButton8.Checked == true)
            {
                key = "COLOR";
            }
            else if (radioButton6.Checked == true)
            {
                key = "COLOR_C";
            }
            else if (radioButton7.Checked == true)
            {
                key = "COLOR + ' ' + COLOR_C";
            }
            return key;
        }
        private string XulyCheckPrice(TextBox text)
        {
            string key;
            if (text.Text == "Y")
            {
                key = ",'TRUE' as keyCheckInGia";
            }
            else
            {
                key = ",'FALSE' as keyCheckInGia";
            }
            return key;
        }

        private void txtSoLH_S_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(txtSoLH_E, txtSoLH_E, sender, e);
        }

        private void txtSoLH_E_KeyDown(object sender, KeyEventArgs e)
        {
            data.tab(txtSoLH_S, txtSoLH_S, sender, e);
        }

        private void txtSoLH_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5_search frm2 = new frm2CF5_search();
            frm2.ShowDialog();
            txtSoLH_S.Text = frm2CF5_search.DL.GetWS_NO;
        }
        private void txtSoLH_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CF5_search frm2 = new frm2CF5_search();
            frm2.ShowDialog();
            txtSoLH_E.Text = frm2CF5_search.DL.GetWS_NO;
        }

        private void txtPOCongViec_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtPOCongViec.Text == "N")
                txtPOCongViec.Text = "Y";
            else if (txtPOCongViec.Text == "Y")
                txtPOCongViec.Text = "N";
        }
    }
}
