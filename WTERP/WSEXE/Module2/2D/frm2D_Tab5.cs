using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WTERP.WSEXE.ReportView;

namespace WTERP.WSEXE
{
    public partial class frm2D_Tab5 : Form
    {
        DataProvider conn = new DataProvider();
        public frm2D_Tab5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        //tao dữ liệu
        string tb1t5 = "";
        string tb2t5 = "";
        string tb3t5 = "";
        string tb4t5 = "";
        string tb5t5 = "";

        bool rdmau;
        bool rdsanxuat;
        bool rd1t5;
        bool rd2t5;
        bool rd3t5;
        string SQL = "";
        void getData()
        {
            tb1t5 = conn.formatstr1(Form2D.Tab5.tb1t5);
            tb2t5 = conn.formatstr1(Form2D.Tab5.tb2t5);
            tb3t5 = Form2D.Tab5.tb3t5;
            tb4t5 = Form2D.Tab5.tb4t5;
            tb5t5 = Form2D.Tab5.tb5t5;

            rdmau = Form2D.Tab5.rdmau;
            rdsanxuat = Form2D.Tab5.rdsanxuat;
            rd1t5 = Form2D.Tab5.rd1t5;
            rd2t5 = Form2D.Tab5.rd2t5;
            rd3t5 = Form2D.Tab5.rd3t5;

        }
        private void frm2D_Tab5_Load(object sender, EventArgs e)
        {
            getData();
            ProcesTab5();
            DataTable dt = conn.readdata(SQL);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["WS_DATE1"] = conn.formatstr2(dr["WS_DATE1"].ToString());
                    dr["WS_DATE"] = conn.formatstr1(dr["WS_DATE"].ToString());
                }
            }
            cr_Form2DF7_Tab5 rp = new cr_Form2DF7_Tab5();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
        void ProcesTab5()
        {
            SQL = "SELECT CUST.C_ANAME2,ORDB.WS_DATE,ORDB.COlOR_E + ' ' + P_NAME_E as COLOR_E,ORDB.WS_DATE + '-' + ORDB.NR as NR,ORDB.OR_NO,ORDB.T_NAME,ORDB.THICK,ORDB.QTY,ORDB.WS_DATE1,ORDB.QTY_OUT,(ORDB.QTY - ORDB.QTY_OUT) as QTY from ORDB inner join CUST ON CUST.C_NO = ORDB.C_NO where 1=1";
            if (tb1t5 == "" && tb2t5 == "" && tb3t5 == "" && tb4t5 == "" && tb5t5 == "")
            {
                SQL = SQL + "";
            }
            if (tb1t5 != "" || tb2t5 != "")
            {
                if (tb1t5 != "" && tb2t5 == "")
                {
                    SQL = SQL + " AND WS_DATE between '" + tb1t5 + "' AND (SELECT TOP 1 WS_DATE from ORDB ORDER BY WS_DATE DESC)";
                }
                else if (tb1t5 == "" && tb2t5 != "")
                {
                    SQL = SQL + " AND ORDB.WS_DATE between (SELECT TOP 1 ORDB.WS_DATE from ORDB ORDER BY ORDB.WS_DATE DESC) AND '" + tb2t5 + "' ";
                }
                else if (tb1t5 != "" || tb2t5 != "")
                {
                    SQL = SQL + " AND ORDB.WS_DATE between '" + tb1t5 + "' AND '" + tb2t5 + "'";
                }
            }
            if (tb3t5 != "" || tb4t5 != "")
            {
                if (tb3t5 != "" && tb4t5 == "")
                {
                    SQL = SQL + " AND ORDB.C_NO between '" + tb3t5 + "' AND (SELECT TOP 1 C_NO from ORDB ORDER BY ORDB.C_NO DESC)";
                }
                else if (tb3t5 == "" && tb4t5 != "")
                {
                    SQL = SQL + " AND ORDB.C_NO between (SELECT TOP 1 C_NO from ORDB ORDER BY ORDB.C_NO ASC) AND '" + tb4t5 + "'  ";
                }
                else if (tb3t5 != "" || tb4t5 != "")
                {
                    SQL = SQL + " AND ORDB.WS_DATE between '" + tb3t5 + "' AND '" + tb4t5 + "'";
                }
            }
            if (tb5t5 != "")
            {
                SQL = SQL + " AND ORDB.B_NO = '" + tb5t5 + "'";
            }
            if (rdmau == true)
            {
                SQL = SQL + " AND QTY != 0  and QTY_OUT = 0 and ORDB.CLRCARD != '' and OVER0 = 'N' ";
                if (rd1t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (1,2)";
                }
                if (rd2t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (1)";
                }
                if (rd3t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (2)";
                }
            }
            if (rdsanxuat == true)
            {
                SQL = SQL + " AND QTY != 0  and QTY_OUT = 0 and OVER0 = 'N'";
                if (rd1t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (3,4)";
                }
                if (rd2t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (3)";
                }
                if (rd3t5 == true)
                {
                    SQL = SQL + " AND ORDB.K_NO in (4)";
                }
            }
            //còn combobox của cái chưa biết
            //luôn +
            SQL = SQL + " ORDER BY ORDB.C_NO ASC, ORDB.NR ASC";
        }
    }
}
