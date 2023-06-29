using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2D
{
    public partial class FrmViewsReport : Form
    {
        DataProvider connect = new DataProvider();
        public FrmViewsReport()
        {
            InitializeComponent();
        }

        private void FrmViewsReport_Load(object sender, EventArgs e)
        {
            if(Form2D.Tab_Select == 4)
            {
                DataTable dt = connect.readdata(Form2D.Share_SQL);
                dt.Columns.Add("Type", typeof(System.Int16));

                foreach (DataRow dr in dt.Rows)
                {
                    string s = string.Empty;
                    if (!string.IsNullOrEmpty(dr["WS_NO1"].ToString())) s = dr["WS_NO1"].ToString().Trim().Substring(0, 1);
                    if (s.Equals("T"))
                    {
                        dr["Type"] = 1;
                        dr["BQTY"] = (-(float.Parse(dr["BQTY"].ToString()))).ToString();
                    }
                    else if (s.Equals("C"))
                    {
                        dr["Type"] = 2;
                        dr["BQTY"] = (-(float.Parse(dr["BQTY"].ToString()))).ToString();
                    }
                    else
                    {
                        dr["Type"] = 0;
                    }
                }
                //sfdsddddđ
                for (int i = 0; i <= dt.Rows.Count - 2; i++)
                {
                    for (int j = i + 1; j <= dt.Rows.Count - 1; j++)
                    {
                        string AA = dt.Rows[i]["WS_NO"].ToString();
                        string AB = dt.Rows[j]["WS_NO"].ToString();
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




                reportViewer1.View(dt, "Form2D_Tab4", "WTERP.WSEXE.Module2._2D.ReportView.Report_Tab4.rdlc");
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
