using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frm3N_Report : Form
    {
        DataTable data1 = new DataTable();
        DataTable data2 = new DataTable();
        bool check;
        bool checkHS;
        public frm3N_Report()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm3N_Report_Load(object sender, EventArgs e)
        {
            // ShowFullScreen(tabControl1);

            check = frm3N.DL.checkBillto;
            checkHS = frm3N.DL.checkHSCODE;
            data1 = frm3N.DL.data1_TinhTien;
            data2 = frm3N.DL.data2_KhongTinhTien;

            if (check == false)
            {
                WSEXE.ReportView.Cr_Form3N_TinhTien cryRpt = new WSEXE.ReportView.Cr_Form3N_TinhTien();

                cryRpt.DataDefinition.FormulaFields["MESSRS"].Text = "'" + frm3N.DL.MESSRS + "'";
                cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt.DataDefinition.FormulaFields["ATTN"].Text = "'" + frm3N.DL.ATTN + "'";
                cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt.DataDefinition.FormulaFields["Shipped by"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'" + frm3N.DL.Address_2 + "'";
                cryRpt.DataDefinition.FormulaFields["From"].Text = "'" + frm3N.DL.From + "'";
                cryRpt.DataDefinition.FormulaFields["To"].Text = "'" + frm3N.DL.To + "'";
                cryRpt.DataDefinition.FormulaFields["ByAir"].Text = "'" + frm3N.DL.ByAir + "'";
                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";

                cryRpt.DataDefinition.FormulaFields["Date"].Text = "'" + frm3N.DL.Date.ToUpper() + "'";
                cryRpt.DataDefinition.FormulaFields["Invoice"].Text = "'" + frm3N.DL.Invoice + "'";

                if (checkHS == true)
                {
                    cryRpt.DataDefinition.FormulaFields["HSCODE"].Text = "'" + frm3N.DL.HSCODE + "'";
                    cryRpt.DataDefinition.FormulaFields["TAXID"].Text = "'" + frm3N.DL.TAXID + "'";
                }    
                else
                {
                    cryRpt.DataDefinition.FormulaFields["HSCODE"].Text = "''";
                    cryRpt.DataDefinition.FormulaFields["TAXID"].Text = "''";
                }    
                


                cryRpt.SetDataSource(data1);
                crystalReportViewer1.ReportSource = cryRpt;

                WSEXE.ReportView.Cr_Form3N_KoTinhTien cryRpt2 = new WSEXE.ReportView.Cr_Form3N_KoTinhTien();

                cryRpt2.DataDefinition.FormulaFields["MESSRS"].Text = "'" + frm3N.DL.MESSRS + "'";
                cryRpt2.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt2.DataDefinition.FormulaFields["ATTN"].Text = "'" + frm3N.DL.ATTN + "'";
                cryRpt2.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt2.DataDefinition.FormulaFields["Shipped by"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt2.DataDefinition.FormulaFields["Address_2"].Text = "'" + frm3N.DL.Address_2 + "'";
                cryRpt2.DataDefinition.FormulaFields["From"].Text = "'" + frm3N.DL.From + "'"; 
                cryRpt2.DataDefinition.FormulaFields["To"].Text = "'" + frm3N.DL.To + "'";
                cryRpt2.DataDefinition.FormulaFields["ByAir"].Text = "'" + frm3N.DL.ByAir + "'";
                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";

                cryRpt2.DataDefinition.FormulaFields["Date"].Text = "'" + frm3N.DL.Date.ToUpper() + "'";
                cryRpt2.DataDefinition.FormulaFields["Invoice"].Text = "'" + frm3N.DL.Invoice + "'";

                if (checkHS == true)
                {
                    cryRpt2.DataDefinition.FormulaFields["HSCODE"].Text = "'" + frm3N.DL.HSCODE + "'";
                    cryRpt2.DataDefinition.FormulaFields["TAXID"].Text = "'" + frm3N.DL.TAXID + "'";
                }
                else
                {
                    cryRpt2.DataDefinition.FormulaFields["HSCODE"].Text = "''";
                    cryRpt2.DataDefinition.FormulaFields["TAXID"].Text = "''";
                }

                cryRpt2.SetDataSource(data2);
                crystalReportViewer2.ReportSource = cryRpt2;

            }
            else if (check == true)
            {
                WSEXE.ReportView.Cr_Form3N_Billto_TinhTien cryRpt = new WSEXE.ReportView.Cr_Form3N_Billto_TinhTien();

                cryRpt.DataDefinition.FormulaFields["MESSRS"].Text = "'" + frm3N.DL.MESSRS + "'";
                cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt.DataDefinition.FormulaFields["ATTN"].Text = "'" + frm3N.DL.ATTN + "'";
                cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt.DataDefinition.FormulaFields["Shipped by"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt.DataDefinition.FormulaFields["Address_2"].Text = "'" + frm3N.DL.Address_2 + "'";
                cryRpt.DataDefinition.FormulaFields["From"].Text = "'" + frm3N.DL.From + "'";
                cryRpt.DataDefinition.FormulaFields["To"].Text = "'" + frm3N.DL.To + "'";
                cryRpt.DataDefinition.FormulaFields["ByAir"].Text = "'" + frm3N.DL.ByAir + "'";
                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";

                cryRpt.DataDefinition.FormulaFields["Date"].Text = "'" + frm3N.DL.Date.ToUpper() + "'";
                cryRpt.DataDefinition.FormulaFields["Invoice"].Text = "'" + frm3N.DL.Invoice + "'";

                cryRpt.DataDefinition.FormulaFields["Billto"].Text = "'" + frm3N.DL.Billto + "'";
                cryRpt.DataDefinition.FormulaFields["Address_3"].Text = "'" + frm3N.DL.Address_3 + "'";
                cryRpt.DataDefinition.FormulaFields["ATTN_2"].Text = "'" + frm3N.DL.ATTN_2 + "'";
                cryRpt.DataDefinition.FormulaFields["TEL_2"].Text = "'" + frm3N.DL.TEL_2 + "'";

                if (checkHS == true)
                {
                    cryRpt.DataDefinition.FormulaFields["HSCODE"].Text = "'" + frm3N.DL.HSCODE + "'";
                    cryRpt.DataDefinition.FormulaFields["TAXID"].Text = "'" + frm3N.DL.TAXID + "'";
                }
                else
                {
                    cryRpt.DataDefinition.FormulaFields["HSCODE"].Text = "''";
                    cryRpt.DataDefinition.FormulaFields["TAXID"].Text = "''";
                }

                cryRpt.SetDataSource(data1);
                crystalReportViewer1.ReportSource = cryRpt;

                WSEXE.ReportView.Cr_Form3N_Billto_KoTinhTien cryRpt2 = new WSEXE.ReportView.Cr_Form3N_Billto_KoTinhTien();

                cryRpt2.DataDefinition.FormulaFields["MESSRS"].Text = "'" + frm3N.DL.MESSRS + "'";
                cryRpt2.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt2.DataDefinition.FormulaFields["ATTN"].Text = "'" + frm3N.DL.ATTN + "'";
                cryRpt2.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt2.DataDefinition.FormulaFields["Shipped by"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt2.DataDefinition.FormulaFields["Address_2"].Text = "'" + frm3N.DL.Address_2 + "'";
                cryRpt2.DataDefinition.FormulaFields["From"].Text = "'" + frm3N.DL.From + "'";
                cryRpt2.DataDefinition.FormulaFields["To"].Text = "'" + frm3N.DL.To + "'";
                cryRpt2.DataDefinition.FormulaFields["ByAir"].Text = "'" + frm3N.DL.ByAir + "'";

                cryRpt2.DataDefinition.FormulaFields["Date"].Text = "'" + frm3N.DL.Date.ToUpper() + "'";
                cryRpt2.DataDefinition.FormulaFields["Invoice"].Text = "'" + frm3N.DL.Invoice + "'";
                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";

                cryRpt2.DataDefinition.FormulaFields["Billto"].Text = "'" + frm3N.DL.Billto + "'";
                cryRpt2.DataDefinition.FormulaFields["Address_3"].Text = "'" + frm3N.DL.Address_3 + "'";
                cryRpt2.DataDefinition.FormulaFields["ATTN_2"].Text = "'" + frm3N.DL.ATTN_2 + "'";
                cryRpt2.DataDefinition.FormulaFields["TEL_2"].Text = "'" + frm3N.DL.TEL_2 + "'";

                if (checkHS == true)
                {
                    cryRpt2.DataDefinition.FormulaFields["HSCODE"].Text = "'" + frm3N.DL.HSCODE + "'";
                    cryRpt2.DataDefinition.FormulaFields["TAXID"].Text = "'" + frm3N.DL.TAXID + "'";
                }
                else
                {
                    cryRpt2.DataDefinition.FormulaFields["HSCODE"].Text = "''";
                    cryRpt2.DataDefinition.FormulaFields["TAXID"].Text = "''";
                }

                cryRpt2.SetDataSource(data2);
                crystalReportViewer2.ReportSource = cryRpt2;
            }

        }
    }
}
