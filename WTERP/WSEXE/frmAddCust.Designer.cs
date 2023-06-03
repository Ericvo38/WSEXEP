
namespace WTERP.WSEXE
{
    partial class frmAddCust
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddCust));
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbNamePC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUSR_NAME = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFAX = new System.Windows.Forms.TextBox();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtATTN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHSCODE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTAXID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtShipTO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShipMent = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTieuDe = new System.Windows.Forms.CheckBox();
            this.txtFax_Bilto = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTermOf = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAddressConsignee = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtConsignee = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAddressBuyer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBillTo_TEL = new System.Windows.Forms.TextBox();
            this.txtATTN_billto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBillTo = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaKH
            // 
            this.txtMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMaKH.Location = new System.Drawing.Point(174, 32);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(311, 30);
            this.txtMaKH.TabIndex = 0;
            this.txtMaKH.TextChanged += new System.EventHandler(this.txtMaKH_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbUserName,
            this.toolStripStatusLabel2,
            this.lbNamePC,
            this.toolStripStatusLabel3,
            this.lbIP,
            this.toolStripStatusLabel5,
            this.txtUSR_NAME});
            this.statusStrip1.Location = new System.Drawing.Point(0, 661);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1134, 26);
            this.statusStrip1.TabIndex = 286;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 20);
            this.toolStripStatusLabel1.Text = "Người Sử Dụng: ";
            // 
            // lbUserName
            // 
            this.lbUserName.ForeColor = System.Drawing.Color.Brown;
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(63, 20);
            this.lbUserName.Text = "XXXXXX";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(149, 20);
            this.toolStripStatusLabel2.Text = "    Computer Name: ";
            // 
            // lbNamePC
            // 
            this.lbNamePC.ForeColor = System.Drawing.Color.Brown;
            this.lbNamePC.Name = "lbNamePC";
            this.lbNamePC.Size = new System.Drawing.Size(72, 20);
            this.lbNamePC.Text = "xxxxxxxxx";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(84, 20);
            this.toolStripStatusLabel3.Text = "     IP Add: ";
            // 
            // lbIP
            // 
            this.lbIP.ForeColor = System.Drawing.Color.Brown;
            this.lbIP.Name = "lbIP";
            this.lbIP.Size = new System.Drawing.Size(116, 20);
            this.lbIP.Text = "xxx.xxx.xxxx.xxxx";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(135, 20);
            this.toolStripStatusLabel5.Text = "Được sửa đổi bởi : ";
            // 
            // txtUSR_NAME
            // 
            this.txtUSR_NAME.Name = "txtUSR_NAME";
            this.txtUSR_NAME.Size = new System.Drawing.Size(30, 20);
            this.txtUSR_NAME.Text = "xxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(491, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 288;
            this.label2.Text = "Tên Khách Hàng";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenKH.Location = new System.Drawing.Point(668, 35);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(442, 30);
            this.txtTenKH.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(45, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 290;
            this.label3.Text = "FAX";
            // 
            // txtFAX
            // 
            this.txtFAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFAX.Location = new System.Drawing.Point(119, 20);
            this.txtFAX.Name = "txtFAX";
            this.txtFAX.Size = new System.Drawing.Size(314, 30);
            this.txtFAX.TabIndex = 5;
            // 
            // txtDC
            // 
            this.txtDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDC.Location = new System.Drawing.Point(174, 71);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(936, 30);
            this.txtDC.TabIndex = 2;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl3.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl3.Location = new System.Drawing.Point(85, 74);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(76, 25);
            this.lbl3.TabIndex = 290;
            this.lbl3.Text = "Địa Chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(110, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 25);
            this.label5.TabIndex = 292;
            this.label5.Text = "TEL";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(175, 107);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(362, 30);
            this.txtSDT.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(543, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 294;
            this.label6.Text = "ATTN";
            // 
            // txtATTN
            // 
            this.txtATTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtATTN.Location = new System.Drawing.Point(615, 108);
            this.txtATTN.Name = "txtATTN";
            this.txtATTN.Size = new System.Drawing.Size(495, 30);
            this.txtATTN.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(449, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 296;
            this.label4.Text = "HS CODE";
            // 
            // txtHSCODE
            // 
            this.txtHSCODE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtHSCODE.Location = new System.Drawing.Point(589, 21);
            this.txtHSCODE.Name = "txtHSCODE";
            this.txtHSCODE.Size = new System.Drawing.Size(496, 30);
            this.txtHSCODE.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(30, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 298;
            this.label7.Text = "TAX ID";
            // 
            // txtTAXID
            // 
            this.txtTAXID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTAXID.Location = new System.Drawing.Point(123, 63);
            this.txtTAXID.Name = "txtTAXID";
            this.txtTAXID.Size = new System.Drawing.Size(310, 30);
            this.txtTAXID.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(23, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 25);
            this.label8.TabIndex = 300;
            this.label8.Text = "Ship To";
            // 
            // txtShipTO
            // 
            this.txtShipTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtShipTO.Location = new System.Drawing.Point(123, 101);
            this.txtShipTO.Name = "txtShipTO";
            this.txtShipTO.Size = new System.Drawing.Size(965, 30);
            this.txtShipTO.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(15, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 25);
            this.label9.TabIndex = 302;
            this.label9.Text = "Shipment";
            // 
            // txtShipMent
            // 
            this.txtShipMent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtShipMent.Location = new System.Drawing.Point(122, 137);
            this.txtShipMent.Name = "txtShipMent";
            this.txtShipMent.Size = new System.Drawing.Size(438, 30);
            this.txtShipMent.TabIndex = 10;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLuu.ForeColor = System.Drawing.Color.Brown;
            this.btnLuu.Location = new System.Drawing.Point(289, 609);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 37);
            this.btnLuu.TabIndex = 303;
            this.btnLuu.Text = "CẬP NHẬT";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHuy.ForeColor = System.Drawing.Color.Brown;
            this.btnHuy.Location = new System.Drawing.Point(804, 609);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(190, 37);
            this.btnHuy.TabIndex = 304;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Brown;
            this.btnThem.Location = new System.Drawing.Point(67, 609);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(144, 37);
            this.btnThem.TabIndex = 305;
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.ForeColor = System.Drawing.Color.Brown;
            this.btnXoa.Location = new System.Drawing.Point(553, 609);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(173, 37);
            this.btnXoa.TabIndex = 306;
            this.btnXoa.Text = "XÓA BỎ";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(438, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 25);
            this.label10.TabIndex = 308;
            this.label10.Text = "DESTINATION";
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDestination.Location = new System.Drawing.Point(589, 60);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(498, 30);
            this.txtDestination.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtPayment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtShipMent);
            this.groupBox1.Controls.Add(this.txtDestination);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHSCODE);
            this.groupBox1.Controls.Add(this.txtShipTO);
            this.groupBox1.Controls.Add(this.txtTAXID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFAX);
            this.groupBox1.Location = new System.Drawing.Point(17, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1093, 185);
            this.groupBox1.TabIndex = 309;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kinh Doanh";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label21.ForeColor = System.Drawing.Color.DarkRed;
            this.label21.Location = new System.Drawing.Point(567, 142);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 25);
            this.label21.TabIndex = 310;
            this.label21.Text = "Payment";
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPayment.Location = new System.Drawing.Point(672, 137);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(412, 30);
            this.txtPayment.TabIndex = 309;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTieuDe);
            this.groupBox2.Controls.Add(this.txtFax_Bilto);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtTermOf);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtCountry);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtAddressConsignee);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtConsignee);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtAddressBuyer);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtBuyer);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtBillTo_TEL);
            this.groupBox2.Controls.Add(this.txtATTN_billto);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtBillTo);
            this.groupBox2.Location = new System.Drawing.Point(17, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1093, 251);
            this.groupBox2.TabIndex = 310;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kế Toán Kinh Doanh";
            // 
            // cbTieuDe
            // 
            this.cbTieuDe.AutoSize = true;
            this.cbTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbTieuDe.Location = new System.Drawing.Point(11, 212);
            this.cbTieuDe.Name = "cbTieuDe";
            this.cbTieuDe.Size = new System.Drawing.Size(126, 24);
            this.cbTieuDe.TabIndex = 317;
            this.cbTieuDe.Text = "Loại Tiêu Đề";
            this.cbTieuDe.UseVisualStyleBackColor = true;
            // 
            // txtFax_Bilto
            // 
            this.txtFax_Bilto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFax_Bilto.Location = new System.Drawing.Point(826, 68);
            this.txtFax_Bilto.Name = "txtFax_Bilto";
            this.txtFax_Bilto.Size = new System.Drawing.Size(258, 30);
            this.txtFax_Bilto.TabIndex = 315;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label22.ForeColor = System.Drawing.Color.DarkRed;
            this.label22.Location = new System.Drawing.Point(757, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 25);
            this.label22.TabIndex = 316;
            this.label22.Text = "FAX: ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label19.ForeColor = System.Drawing.Color.DarkRed;
            this.label19.Location = new System.Drawing.Point(401, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 25);
            this.label19.TabIndex = 314;
            this.label19.Text = "Term Of Delivery";
            // 
            // txtTermOf
            // 
            this.txtTermOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTermOf.Location = new System.Drawing.Point(565, 107);
            this.txtTermOf.Name = "txtTermOf";
            this.txtTermOf.Size = new System.Drawing.Size(520, 30);
            this.txtTermOf.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label20.ForeColor = System.Drawing.Color.DarkRed;
            this.label20.Location = new System.Drawing.Point(27, 108);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 25);
            this.label20.TabIndex = 312;
            this.label20.Text = "Country";
            // 
            // txtCountry
            // 
            this.txtCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCountry.Location = new System.Drawing.Point(119, 104);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(275, 30);
            this.txtCountry.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label17.ForeColor = System.Drawing.Color.DarkRed;
            this.label17.Location = new System.Drawing.Point(401, 180);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 25);
            this.label17.TabIndex = 310;
            this.label17.Text = "Address";
            // 
            // txtAddressConsignee
            // 
            this.txtAddressConsignee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAddressConsignee.Location = new System.Drawing.Point(492, 180);
            this.txtAddressConsignee.Name = "txtAddressConsignee";
            this.txtAddressConsignee.Size = new System.Drawing.Size(593, 30);
            this.txtAddressConsignee.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label18.ForeColor = System.Drawing.Color.DarkRed;
            this.label18.Location = new System.Drawing.Point(6, 176);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 25);
            this.label18.TabIndex = 308;
            this.label18.Text = "Consignee";
            // 
            // txtConsignee
            // 
            this.txtConsignee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtConsignee.Location = new System.Drawing.Point(119, 176);
            this.txtConsignee.Name = "txtConsignee";
            this.txtConsignee.Size = new System.Drawing.Size(275, 30);
            this.txtConsignee.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(401, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 25);
            this.label13.TabIndex = 306;
            this.label13.Text = "Address";
            // 
            // txtAddressBuyer
            // 
            this.txtAddressBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAddressBuyer.Location = new System.Drawing.Point(492, 144);
            this.txtAddressBuyer.Name = "txtAddressBuyer";
            this.txtAddressBuyer.Size = new System.Drawing.Size(593, 30);
            this.txtAddressBuyer.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(41, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 25);
            this.label12.TabIndex = 304;
            this.label12.Text = "Buyer";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBuyer.Location = new System.Drawing.Point(119, 140);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(275, 30);
            this.txtBuyer.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(19, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 25);
            this.label11.TabIndex = 302;
            this.label11.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAddress.Location = new System.Drawing.Point(119, 68);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(631, 30);
            this.txtAddress.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(331, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 25);
            this.label14.TabIndex = 296;
            this.label14.Text = "TEL";
            // 
            // txtBillTo_TEL
            // 
            this.txtBillTo_TEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBillTo_TEL.Location = new System.Drawing.Point(386, 29);
            this.txtBillTo_TEL.Name = "txtBillTo_TEL";
            this.txtBillTo_TEL.Size = new System.Drawing.Size(292, 30);
            this.txtBillTo_TEL.TabIndex = 12;
            // 
            // txtATTN_billto
            // 
            this.txtATTN_billto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtATTN_billto.Location = new System.Drawing.Point(756, 28);
            this.txtATTN_billto.Name = "txtATTN_billto";
            this.txtATTN_billto.Size = new System.Drawing.Size(329, 30);
            this.txtATTN_billto.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label15.ForeColor = System.Drawing.Color.DarkRed;
            this.label15.Location = new System.Drawing.Point(684, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 25);
            this.label15.TabIndex = 298;
            this.label15.Text = "ATTN";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(6, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 25);
            this.label16.TabIndex = 290;
            this.label16.Text = "Bill to";
            // 
            // txtBillTo
            // 
            this.txtBillTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBillTo.Location = new System.Drawing.Point(66, 30);
            this.txtBillTo.Name = "txtBillTo";
            this.txtBillTo.Size = new System.Drawing.Size(259, 30);
            this.txtBillTo.TabIndex = 11;
            // 
            // frmAddCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1134, 687);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtATTN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtDC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaKH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddCust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập Nhật Thông Tin Khách Hàng";
            this.Load += new System.EventHandler(this.frmAddCust_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbNamePC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lbIP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel txtUSR_NAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFAX;
        private System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtATTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHSCODE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTAXID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtShipTO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtShipMent;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBillTo_TEL;
        private System.Windows.Forms.TextBox txtATTN_billto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBillTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAddressConsignee;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtConsignee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAddressBuyer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTermOf;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.TextBox txtFax_Bilto;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbTieuDe;
    }
}