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
    public partial class frm3N_TRONGNUOC : Form
    {
        DataTable data1 = new DataTable();
        //bool check;
        public frm3N_TRONGNUOC()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm3N_Report_Load(object sender, EventArgs e)
        {
            data1 = frm3N.DL.dataTrongNuoc;
           
                //invoice
                WSEXE.ReportView.cr_Form3N_TrongNuoc_Invoice cryRpt = new WSEXE.ReportView.cr_Form3N_TrongNuoc_Invoice();

                cryRpt.DataDefinition.FormulaFields["INVOICE"].Text = "'" + frm3N.DL.Invoice + "'";
                cryRpt.DataDefinition.FormulaFields["C_NAME"].Text = "'" + frm3N.DL.MESSRS + "'"; 
                cryRpt.DataDefinition.FormulaFields["DATE"].Text = "'" + frm3N.DL.Date + "'";
                cryRpt.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";
                cryRpt.DataDefinition.FormulaFields["SHIPPEDBY"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt.DataDefinition.FormulaFields["ADDRESS_2"].Text = "'" + frm3N.DL.Address_2 + "'";
                cryRpt.DataDefinition.FormulaFields["PAYMENT"].Text = "'" + frm3N.DL.PayMent + "'";

                cryRpt.DataDefinition.FormulaFields["TERM_OF"].Text = "'" + frm3N.DL.DELIVERY + "'";
                cryRpt.DataDefinition.FormulaFields["COUNTRY"].Text = "'" + frm3N.DL.Country + "'";

                cryRpt.DataDefinition.FormulaFields["TO"].Text = "'" + frm3N.DL.To + "'";
                cryRpt.DataDefinition.FormulaFields["FROM"].Text = "'" + frm3N.DL.From + "'";


                cryRpt.SetDataSource(data1);
                crystalReportViewer1.ReportSource = cryRpt;
                //  //packing list

                WSEXE.ReportView.cr_Form3N_TrongNuoc_PackingList cryRpt2 = new WSEXE.ReportView.cr_Form3N_TrongNuoc_PackingList();

                cryRpt2.DataDefinition.FormulaFields["INVOICE"].Text = "'" + frm3N.DL.Invoice + "'";
                cryRpt2.DataDefinition.FormulaFields["C_NAME"].Text = "'" + frm3N.DL.MESSRS + "'";
                cryRpt2.DataDefinition.FormulaFields["DATE"].Text = "'" + frm3N.DL.Date + "'";
                cryRpt2.DataDefinition.FormulaFields["ADDRESS"].Text = "'" + frm3N.DL.ADDRESS + "'";
                cryRpt2.DataDefinition.FormulaFields["TEL"].Text = "'" + frm3N.DL.TEL + "'";
                cryRpt2.DataDefinition.FormulaFields["FAX"].Text = "'" + frm3N.DL.FAX + "'";
                cryRpt2.DataDefinition.FormulaFields["SHIPPEDBY"].Text = "'" + frm3N.DL.Shippedby + "'";
                cryRpt2.DataDefinition.FormulaFields["ADDRESS_2"].Text = "'" + frm3N.DL.Address_2 + "'";

                cryRpt2.DataDefinition.FormulaFields["TO"].Text = "'" + frm3N.DL.To + "'";
               
                cryRpt2.SetDataSource(data1);
                crystalReportViewer2.ReportSource = cryRpt2;
        }
    }
}
