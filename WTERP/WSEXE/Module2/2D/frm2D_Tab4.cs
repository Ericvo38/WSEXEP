using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE.ReportView;

namespace WTERP
{
    public partial class Form2D_Tab4 : Form
    {
        DataProvider con = new DataProvider();
        public Form2D_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form2D_Tab4_Load(object sender, EventArgs e)
        {
            Creat_PRDM();
            Creat_CA_GI();
            string C_NO1 = Form2D.Tab4.t1;
            string C_NO2 = Form2D.Tab4.t2;
            string WS_DATE1 = con.formatstr1(Form2D.Tab4.t3);
            string WS_DATE2 = con.formatstr1(Form2D.Tab4.t4);
            string OR_NO1 = Form2D.Tab4.t5;
            string OR_NO2 = Form2D.Tab4.t6;
            string COLOR_C = Form2D.Tab4.t7;
            string COLOR_E = Form2D.Tab4.t8;
            string P_NAME1 = Form2D.Tab4.t9;

            string WS_DATE1_1 = Form2D.Tab4.t10;
            string WS_DATE1_2 = Form2D.Tab4.t11;

            bool rd4_1 = Form2D.Tab4.rd4_1;
            bool rd4_2 = Form2D.Tab4.rd4_2;
            bool rd4_3 = Form2D.Tab4.rd4_3;

            string Nr = Form2D.Tab4.t12;
            string Nr1 = Form2D.Tab4.t13;
            string BRAND = Form2D.Tab4.t15;
            string T_NAME = Form2D.Tab4.t16;

           

            string STQ3 = "SELECT dbo.FormatString1(ORDB.WS_DATE) AS WS_DATE, ORDB.NR, ORDB.MODEL_E,ORDB.C_NO, ORDB.T_NAME, ORDB.OR_NO, PATT_C, CA_GI.COLOR_C, ORDB.COLOR_E,(ORDB.COLOR_C + ORDB.COLOR_E) AS COLOR," +
                " ORDB.THICK, ORDB.P_NAME_E, ORDB.PRICE, ORDB.OVER0, dbo.FormatString2(ORDB.WS_DATE1) AS WS_DATE1, ORDB.CLRCARD, ORDB.QTY, ISNULL(PRDM.WS_NO,ORDB.WS_DATE + '-'+ '0'+ORDB.NR) WS_NO,CASE WHEN PRDM.C_NAME = '' THEN CUST.C_NAME ELSE PRDM.C_NAME END AS C_NAME, " +
                " dbo.FormatString2(CA_GI.WS_DATE) AS WS_DATE, CA_GI.WS_NO, isnull(CA_GI.BQTY,0) as BQTY, CA_GI.MEMO, CA_GI.OVER0, '' AS TOTAL,REMARKS FROM ORDB " +
                " lEFT JOIN PRDM ON ORDB.OR_NO = PRDM.OR_NO AND ORDB.NR = PRDM.NR " +
                " LEFT JOIN dbo.CUST ON CUST.C_NO = ORDB.C_NO " +
                "LEFT JOIN CA_GI ON ORDB.OR_NO = CA_GI.OR_NO AND ORDB.NR = CA_GI.OR_NR WHERE 1=1";

            if (C_NO1 == "" && C_NO2 == "" && WS_DATE1 == "" && WS_DATE2 == "" && OR_NO1 == "" && OR_NO2 == "" && COLOR_C == "" && COLOR_E == "" && P_NAME1 == "")
            {
                STQ3 = STQ3 + "";
            }
            if (C_NO1 != "")
                STQ3 = STQ3 + " AND ORDB.C_NO >= '" + C_NO1 + "'";

            if (C_NO2 != "")
                STQ3 = STQ3 + " AND ORDB.C_NO <= '" + C_NO2 + "'";

            if (WS_DATE1 != "")
                STQ3 = STQ3 + " AND ORDB.WS_DATE >= '" + WS_DATE1 + "'";

            if (WS_DATE2 != "")
                STQ3 = STQ3 + " AND ORDB.WS_DATE <= '" + WS_DATE2 + "'";

            if (OR_NO1 != "")
                STQ3 = STQ3 + " AND ORDB.OR_NO >= '" + OR_NO1 + "'";

            if (OR_NO2 != "")
                STQ3 = STQ3 + " AND ORDB.OR_NO <= '" + OR_NO2 + "'";

            if (COLOR_C != "")
                STQ3 = STQ3 + " AND ORDB.COLOR_C LIKE '%" + COLOR_C + "%'";

            if (COLOR_E != "")
                STQ3 = STQ3 + " AND ORDB.COLOR_E LIKE '%" + COLOR_E + "%'";

            if (P_NAME1 != "")
                STQ3 = STQ3 + " AND ORDB.P_NAME_E LIKE '%" + P_NAME1 + "%'";

            if (Nr != "")
                STQ3 = STQ3 + " AND ORDB.NR >= '" + Nr + "'";

            if (Nr1 != "")
                STQ3 = STQ3 + " AND ORDB.NR <= '" + Nr1 + "'";

            if (BRAND != "")
                STQ3 = STQ3 + " AND ORDB.BRAND LIKE '%" + BRAND + "%'";

            if (T_NAME != "")
                STQ3 = STQ3 + " AND ORDB.T_NAME LIKE '%" + T_NAME + "%'";

            if (WS_DATE1_1 != "")
                STQ3 = STQ3 + " AND ORDB.WS_DATE1 >= '" + WS_DATE1_1 + "'";

            if (WS_DATE1_2 != "")
                STQ3 = STQ3 + " AND ORDB.WS_DATE1 <= '" + WS_DATE1_2 + "'";

            if (rd4_2 == true)
            {
                STQ3 = STQ3 + " AND ORDB.K_NO IN (1,3)";
            }
            if (rd4_3 == true)
            {
                STQ3 = STQ3 + " AND ORDB.K_NO IN (2,4)";
            }

            STQ3 = STQ3 + "  ORDER BY ORDB.OR_NO,ORDB.WS_DATE,PRDM.WS_NO,CA_GI.WS_DATE";
            DataTable dt = con.readdata(STQ3);

            string TS = "TV";
            string CV = "CV";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            //    dr["WS_DATE1"] = con.formatstr2(dr["WS_DATE1"].ToString());
            //    dr["WS_DATE2"] = con.formatstr2(dr["WS_DATE2"].ToString());
            //}

            foreach (DataRow dr in dt.Rows)
            {
                string BB = dr["WS_NO1"].ToString();
                string CC = dr["WS_NO1"].ToString();


                int FirstChr_CV = CC.IndexOf(CV);
                int FirstChr = BB.IndexOf(TS);

                if (FirstChr != -1 || FirstChr_CV != -1)
                {
                    dr["BQTY"] = (-(float.Parse(dr["BQTY"].ToString()))).ToString();
                }

            }


            for (int i = 0; i <= dt.Rows.Count - 2; i++)
            {
                for (int j = i + 1; j <= dt.Rows.Count - 1; j++)
                {

                    string AA = dt.Rows[i]["WS_NO"].ToString();
                    string AB = dt.Rows[j]["WS_NO"].ToString();
                    //string OVER = dt.Rows[j]["OVER01"].ToString();

                    if (!AA.Equals("") && !AB.Equals(""))
                    {
                        if (AA == AB)
                        {
                            string AC = dt.Rows[i]["TOTAL"].ToString();
                            string AD = dt.Rows[j]["TOTAL"].ToString();
                            if (AC == string.Empty)
                            {
                                dt.Rows[i]["TOTAL"] = dt.Rows[i]["BQTY"];
                            }
                            if (AD == string.Empty)
                            {
                                dt.Rows[j]["TOTAL"] = float.Parse(dt.Rows[j]["BQTY"].ToString());
                            }
                        }
                    }

                }

            }

            int x = 0;
            for (int i = x + 1; i <= dt.Rows.Count - 1; i++)
            {

                string COLOR_C_X = dt.Rows[x]["COLOR_C"].ToString();
                string COLOR_C_I = dt.Rows[i]["COLOR_C"].ToString();

                string WS_NO = dt.Rows[x]["WS_NO"].ToString();
                if (WS_NO == dt.Rows[i]["WS_NO"].ToString())
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["TOTAL"].ToString()))
                    {
                        dt.Rows[i]["TOTAL"] = Math.Round(float.Parse((COLOR_C_X == "作廢" ? "0" : dt.Rows[x]["TOTAL"].ToString())) + float.Parse((COLOR_C_I == "作廢" ? "0" : dt.Rows[i]["TOTAL"].ToString())), 2);
                    }
                    x++;
                }
                else if (WS_NO == dt.Rows[i]["WS_NO"].ToString())
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i - 1]["TOTAL"].ToString()))
                    {
                        dt.Rows[i]["TOTAL"] = float.Parse(dt.Rows[i - 1]["TOTAL"].ToString());
                    }
                    x++;
                }
                else if (dt.Rows[i]["WS_NO"].ToString() == null)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["TOTAL"].ToString()))
                    {
                        dt.Rows[i]["TOTAL"] = float.Parse(dt.Rows[i]["TOTAL"].ToString());
                    }
                    x++;
                }
                else { x++; }

            }
            foreach (DataRow dr in dt.Rows)
            {
                string BB = dr["WS_NO1"].ToString();
                string OVER = dr["OVER01"].ToString();
                if (BB != string.Empty)
                {
                    string BC = BB.Substring(0, 2);
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TOTAL"].ToString() == "")
                    dr["TOTAL"] = dr["BQTY"].ToString();

                if (string.IsNullOrEmpty(dr["WS_NO"].ToString()))
                    dr["WS_NO"] = dr["OR_NO"].ToString();
            }


            Cr_F2D_Tab4 crp = new Cr_F2D_Tab4();
            crp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crp;
            //this.crystalReportViewer1.ShowPrintButton = false;

        }
        public void Creat_PRDM()
        {
            string SQL = "SELECT top 1 * FROM PRDM";
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = con.readdata(SQL);
            if (dataTable != null)
            {
                string SQL_Delete = "DROP TABLE PRDM";
                con.exedata(SQL_Delete);
            }
            string STQ1 = "SELECT * INTO PRDM FROM (SELECT OR_NO, NR, WS_NO, C_NAME,MEMO03 FROM PRDMK1 UNION ALL SELECT OR_NO, NR, WS_NO, C_NAME,MEMO03 FROM PRDMK2) LU ";
            con.readdata(STQ1);
        }
        public void Creat_CA_GI()
        {
            string SQL = "SELECT top 1 * FROM CA_GI";
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = con.readdata(SQL);
            if (dataTable != null)
            {
                string SQL_Delete = "DROP TABLE CA_GI";
                con.exedata(SQL_Delete);
            }
            string STQ2 = "SELECT * INTO CA_GI FROM (SELECT CARB.OR_NO, OR_NR,CARB. WS_DATE, CARB.WS_NO, BQTY, MEMO, CARB.OVER0,CARH.OR_NO AS COLOR_C FROM CARB,dbo.CARH WHERE CARH.WS_NO = CARB.WS_NO UNION ALL SELECT OR_NO, OR_NR, WS_DATE, WS_NO, BQTY, MEMO, OVER0,'' AS COLOR_C  FROM GIBB) LU";
            con.readdata(STQ2);
        }
    }
}
