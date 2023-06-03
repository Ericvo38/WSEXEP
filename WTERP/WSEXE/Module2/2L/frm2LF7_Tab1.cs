using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace WTERP.WSEXE
{
    public partial class frm2LF7_Tab1 : Form
    {
        DataProvider conn = new DataProvider();
        public frm2LF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        bool rdExcel1;
        bool rdMau1;
        bool rdSanXuat1;
        string txtWS_DATE1;
        string SQL = "";
        private void frm2LF7_Tab1_Load(object sender, EventArgs e)
        {
            setData();
            getReport();
        }
        public void getReport()
        { 
          if (rdMau1 == true)
          {
               SQL = "SELECT '" + txtWS_DATE1 + "' as DATE,WS_DATE,C_NO + C_Name_E as C_NO,C_Name_E,OR_NO,T_NAME,MODEL_E,P_NAME_E + P_NAME_C as P_NAME_E,COLOR_E,THICK,QTY from ORDB where K_NO in (1,2) order by C_NO ASC";
          }
            if (rdSanXuat1 == true)
          {
               SQL = "SELECT '" + txtWS_DATE1 + "' as DATE,WS_DATE,C_NO + C_Name_E as C_NO,C_Name_E,OR_NO,T_NAME,MODEL_E,P_NAME_E + P_NAME_C as P_NAME_E,COLOR_E,THICK,QTY from ORDB where K_NO in (3,4) order by C_NO ASC";
          }
            DataTable dataTable = conn.readdata(SQL);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                dataRow["DATE"] = conn.formatstr1(dataRow["DATE"].ToString());
                dataRow["DATE"] = conn.formatstr1(dataRow["DATE"].ToString());
            }
            WSEXE.ReportView.cr_frm2LF7_Tab1 rpt = new WSEXE.ReportView.cr_frm2LF7_Tab1();
            rpt.SetDataSource(dataTable);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void setData()
        {
            rdExcel1 = frm2LF7.getDL.rdExcel1;
            rdMau1 = frm2LF7.getDL.rdMau1;
            rdSanXuat1 = frm2LF7.getDL.rdSanXuat1;
            txtWS_DATE1 = frm2LF7.getDL.txtWS_DATE1;
        }
    }
}
