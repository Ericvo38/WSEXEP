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
    public partial class frm3N_TRONGNUOC_BILLTO : Form
    {
        DataTable data1 = new DataTable();
        public frm3N_TRONGNUOC_BILLTO()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm3N_Report_Load(object sender, EventArgs e)
        {
            data1 = frm3N.DL.dataTrongNuoc;
           
            //invoice
            WSEXE.ReportView.cr_Form3N_TrongNuoc_Invoice_Billto cryRpt = new WSEXE.ReportView.cr_Form3N_TrongNuoc_Invoice_Billto();

            cryRpt.DataDefinition.FormulaFields["INVOICE"].Text = "'" + frm3N.DL.Invoice + "'";
            cryRpt.DataDefinition.FormulaFields["DATE"].Text = "'" + frm3N.DL.Date + "'";

            cryRpt.DataDefinition.FormulaFields["Billto"].Text = "'" + frm3N.DL.Billto + "'";
            cryRpt.DataDefinition.FormulaFields["Address_3"].Text = "'" + frm3N.DL.Address_3 + "'";
            cryRpt.DataDefinition.FormulaFields["TEL_2"].Text = "'" + frm3N.DL.TEL_2 + "'";
            cryRpt.DataDefinition.FormulaFields["FAX_2"].Text = "'" + frm3N.DL.FAX_2 + "'";

            cryRpt.DataDefinition.FormulaFields["C_NAME"].Text = "'" + frm3N.DL.MESSRS + "'";
            cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
            cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
            cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";
            cryRpt.DataDefinition.FormulaFields["SHIPPEDBY"].Text = "'" + frm3N.DL.Shippedby + "'";
            cryRpt.DataDefinition.FormulaFields["ADDRESS_2"].Text = "'" + frm3N.DL.Address_2 + "'";

            cryRpt.DataDefinition.FormulaFields["HS_CODE"].Text = "'" + frm3N.DL.HSCODE + "'";
            cryRpt.DataDefinition.FormulaFields["COUNTRY"].Text = "'" + frm3N.DL.Country + "'";

            cryRpt.DataDefinition.FormulaFields["TO"].Text = "'" + frm3N.DL.To + "'";
            cryRpt.DataDefinition.FormulaFields["FROM"].Text = "'" + frm3N.DL.From + "'";
            cryRpt.DataDefinition.FormulaFields["PHANTRAM"].Text = "'" + frm3N.DL.PhanTram + "'";

            if (int.Parse(frm3N.DL.TYPE) == 1 || int.Parse(frm3N.DL.TYPE) == 3)
            {
                cryRpt.DataDefinition.FormulaFields["TYPE"].Text = "'" + "Cow" + "'";
            }
            else
            {
                cryRpt.DataDefinition.FormulaFields["TYPE"].Text = "'" + "Pig" + "'";
            }
            


            cryRpt.SetDataSource(data1);
            crystalReportViewer1.ReportSource = cryRpt;
        }
    }
}
