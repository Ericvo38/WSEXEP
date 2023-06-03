using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using WTERP.WSEXE.ReportView;
using System.Reflection;
using System.Drawing.Imaging;
using System.IO;

namespace WTERP
{
    public partial class frm3DF7Barcode : Form
    {
        DataProvider con = new DataProvider();
        public frm3DF7Barcode()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string textBoxBarWidth = "";
        string textBoxAspectRatio = "";

        public class ListBarcode
        {
            public string WS_NO { get; set; }
            public byte[] Barcode { get; set; }
        }
        List<ListBarcode> Lists = new List<ListBarcode>();

        private void frm3DF7Barcode_Load(object sender, EventArgs e)
        {
            DataTable dt = con.readdata(frm3DF7.Share_SQL);
            LoadBarcode(dt,750, 350);          
            //LoadBarcode(dt, 850, 450);
            cr_Barcode_Form3DF71 rp = new cr_Barcode_Form3DF71();
            rp.SetDataSource(Lists);
            crystalReportViewer1.ReportSource = rp;
        }
        private void LoadBarcode(DataTable dt, int Widht, int Hight)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
            try
            {
                if (type != BarcodeLib.TYPE.UNSPECIFIED)//230215-020
                {
                    try
                    {
                        barcode.BarWidth = textBoxBarWidth.Trim().Length < 1 ? null : (int?)Convert.ToInt32(textBoxBarWidth.Trim());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to parse BarWidth: " + ex.Message, ex);
                    }
                    try
                    {
                        barcode.AspectRatio = textBoxAspectRatio.Trim().Length < 1 ? null : (double?)Convert.ToDouble(textBoxAspectRatio.Trim());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to parse AspectRatio: " + ex.Message, ex);
                    }
                    barcode.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);
                    barcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                    Image image;
                    foreach (DataRow item in dt.Rows)
                    {
                        image = barcode.Encode(type, item["WS_NO"].ToString().Trim(), Color.Black, Color.White, Widht, Hight);
                        byte[] ba = imageToByteArray(image);
                        Lists.Add(new ListBarcode() { WS_NO = item["WS_NO"].ToString(), Barcode = ba });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
