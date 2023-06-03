using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frmAddCust : Form
    {
        public frmAddCust()
        {
            InitializeComponent();
        }
        DataProvider conn = new DataProvider();
        BindingSource binding = new BindingSource();
        DataTable dataTable = new DataTable();
        string keyC_NO = "";
        string keyC_ANAME = "";
        string keyAddress = "";
        private void frmAddCust_Load(object sender, EventArgs e)
        {
            loadinfo();
            Loaddata();
        }
        void loadinfo()
        {
            lbUserName.Text = conn.getUser(frmLogin.ID_USER);
            lbNamePC.Text = System.Environment.MachineName;


            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
        }
        private void Loaddata()
        {
            try
            {
                if (!string.IsNullOrEmpty(frm3L.F_CNO))
                {
                    keyC_NO = frm3L.F_CNO;
                    keyC_ANAME = frm3L.F_CNAME;
                    keyAddress = frm3L.F_ADDRESS;
                }
                else if (!string.IsNullOrEmpty(frm3N.ID_CUST.ID_CUST_KH))
                {
                    keyC_NO = frm3N.ID_CUST.ID_CUST_KH;
                }
                else if (!string.IsNullOrEmpty(frm3O.DL3O.key_C_NO))
                {
                    keyC_NO = frm3O.DL3O.key_C_NO;
                }
                else if (!string.IsNullOrEmpty(frm3P.DL3P.Keyc_no))
                {
                    keyC_NO = frm3P.DL3P.Keyc_no;
                }
                if (!string.IsNullOrEmpty(keyC_NO))
                {
                    getData(keyC_NO);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }
        private void getData(string key)
        {            
            string sql = "SELECT B.C_NO,B.C_NAME,B.ADDRESS,B.PHONE,B.FAX,B.ATTN,B.HSCODE,B.TAXID,B.SHIPTO,B.SHIPMENT,B.DESTINATION,B.BillTo,B.TEL,B.ATTN_2,B.ADDRESS_2,B.Country,B.TermOfDelivery,B.Buyer,B.Buyer_Address,B.Consignee,B.Consignee_Address,B.Payment,B.FAX_2,isnull(cbTieuDe,'False') as cbTieuDe FROM dbo.CUST AS A INNER JOIN tblInfoCustomer AS B ON B.C_NO = A.C_NO WHERE A.C_NO = '" + key + "'";
            dataTable = conn.readdata(sql);
            if (dataTable.Rows.Count > 0)
            {
                binding.DataSource = dataTable;
                hienthiData();
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                return_null();
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;

            }
        }
        private void hienthiData()
        {
            txtMaKH.Text = currentRow["C_NO"].ToString();
            txtTenKH.Text = currentRow["C_NAME"].ToString();
            txtDC.Text = currentRow["ADDRESS"].ToString();
            txtSDT.Text = currentRow["PHONE"].ToString();
            txtFAX.Text = currentRow["FAX"].ToString();
            txtATTN.Text = currentRow["ATTN"].ToString();
            txtATTN.Text = currentRow["ATTN"].ToString();
            txtHSCODE.Text = currentRow["HSCODE"].ToString();
            txtTAXID.Text = currentRow["TAXID"].ToString();
            txtShipTO.Text = currentRow["SHIPTO"].ToString();
            txtShipMent.Text = currentRow["SHIPMENT"].ToString();
            txtDestination.Text = currentRow["DESTINATION"].ToString();
            txtBillTo.Text = currentRow["BillTo"].ToString();
            txtAddress.Text = currentRow["ADDRESS_2"].ToString();
            txtBillTo_TEL.Text = currentRow["TEL"].ToString();
            txtATTN_billto.Text = currentRow["ATTN_2"].ToString();
            txtCountry.Text = currentRow["Country"].ToString();
            txtTermOf.Text = currentRow["TermOfDelivery"].ToString();
            txtBuyer.Text = currentRow["Buyer"].ToString();
            txtAddressBuyer.Text = currentRow["Buyer_Address"].ToString();
            txtConsignee.Text = currentRow["Consignee"].ToString();
            txtAddressConsignee.Text = currentRow["Consignee_Address"].ToString();
            txtPayment.Text = currentRow["Payment"].ToString();
            txtFax_Bilto.Text = currentRow["FAX_2"].ToString();
            if (currentRow["cbTieuDe"].ToString() == "True")
            {
                cbTieuDe.Checked = true;
            }
            else
            {
                cbTieuDe.Checked = false;
            }    
           
         
        }
        private void return_null()
        {
            txtMaKH.Text = keyC_NO;
            txtTenKH.Text = keyC_ANAME;
            txtDC.Text = keyAddress;
            txtSDT.Text = "";
            txtFAX.Text = "";
            txtATTN.Text = "";
            txtHSCODE.Text = "";
            txtTAXID.Text = "";
            txtShipTO.Text = "";
            txtShipMent.Text = "";
            txtDestination.Text = "";
            txtBillTo.Text = "";
            txtBillTo_TEL.Text = "";
            txtATTN_billto.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtTermOf.Text = "";
            txtBuyer.Text = "";
            txtAddressBuyer.Text = "";
            txtConsignee.Text = "";
            txtAddressConsignee.Text = "";
            txtPayment.Text = "";
            txtFax_Bilto.Text = "";
        }
        private DataRow currentRow
        {
            get
            {
                int position = this.BindingContext[binding].Position;
                if (position > -1)
                {
                    return ((DataRowView)binding.Current).Row;
                }
                else
                {
                    return null;
                }
            }
        }
        public class getC_NO_Add_CUST
        {
            public static string getC_NO;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.checkExists("select top 1 C_NO From tblInfoCustomer where C_NO  = '" + txtMaKH.Text + "'") == true)
                {
                    MessageBox.Show("Khách hàng đã tồn tại !!!");
                }
                else
                {
                    string sql = "INSERT INTO dbo.tblInfoCustomer(C_NO,C_NAME,ADDRESS,PHONE,FAX,ATTN,HSCODE,TAXID,SHIPTO,SHIPMENT,DateAdd,Usr_name,DESTINATION,BillTo,TEL,ATTN_2,ADDRESS_2,Country,TermOfDelivery,Buyer,Buyer_Address,Consignee,Consignee_Address,Payment,FAX_2,cbTieuDe) " +
                "SELECT '" + txtMaKH.Text + "','" + txtTenKH.Text + "','" + txtDC.Text + "','" + txtSDT.Text + "','" + txtFAX.Text + "','" + txtATTN.Text + "','" + txtHSCODE.Text + "'," +
                "'" + txtTAXID.Text + "','" + txtShipTO.Text + "','" + txtShipMent.Text + "',GETDATE(),'" + lbUserName.Text + "','" + txtDestination.Text + "'," +
                "'" + txtBillTo.Text + "','" + txtBillTo_TEL.Text + "','" + txtATTN_billto.Text + "','" + txtAddress.Text + "','" + txtCountry.Text + "','" + txtTermOf.Text + "'" +
                ",'" + txtBuyer.Text + "','" + txtAddressBuyer.Text + "','" + txtConsignee.Text + "','" + txtAddressConsignee.Text + "','"+txtPayment.Text+"','"+txtFax_Bilto.Text+"','"+cbTieuDe.Checked.ToString()+"'";
                     bool check = conn.exedata(sql);
                    if (check == true)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getC_NO_Add_CUST.getC_NO = txtMaKH.Text;
                        Loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE dbo.tblInfoCustomer  set C_NO = '" + txtMaKH.Text + "',C_NAME = '" + txtTenKH.Text + "',ADDRESS = '" + txtDC.Text + "',PHONE='" + txtSDT.Text + "',FAX = '" + txtFAX.Text + "'," +
                              "ATTN = '" + txtATTN.Text + "',HSCODE = '" + txtHSCODE.Text + "',TAXID = '" + txtTAXID.Text + "'," +
                              "SHIPTO = '" + txtShipTO.Text + "',SHIPMENT = '" + txtShipMent.Text + "',DateAdd = GETDATE(),Usr_name = '" + lbUserName.Text + "',DESTINATION = '" + txtDestination.Text + "',BillTo = '" + txtBillTo.Text + "'," +
                              "TEL = '" + txtBillTo_TEL.Text + "',ATTN_2 = '" + txtATTN_billto.Text + "',ADDRESS_2 = '" + txtAddress.Text + "',Country = '" + txtCountry.Text + "',TermOfDelivery = '" + txtTermOf.Text + "'," +
                              "Buyer = '" + txtBuyer.Text + "',Buyer_Address = '" + txtAddressBuyer.Text + "',Consignee = '" + txtConsignee.Text + "',Consignee_Address = '" + txtAddressConsignee.Text + "',Payment = '"+txtPayment.Text+"',FAX_2 = '"+txtFax_Bilto.Text+"',cbTieuDe = '"+ cbTieuDe.Checked.ToString() + "'" +
                              "FROM tblInfoCustomer WHERE C_NO = '" + txtMaKH.Text + "'";
                bool check = conn.exedata(sql);
                if (check == true)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getC_NO_Add_CUST.getC_NO = txtMaKH.Text;
                    Loaddata();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    string sql = "DELETE FROM tblInfoCustomer WHERE C_NO = '" + txtMaKH.Text + "'";
                    bool check = conn.exedata(sql);
                    getC_NO_Add_CUST.getC_NO = txtMaKH.Text;
                    Loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            getC_NO_Add_CUST.getC_NO = txtMaKH.Text;
            this.Close();
            this.Hide();
        }
    }
}
