
namespace WTERP
{
    partial class frm2CF5_search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2CF5_search));
            this.txtSoVB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.WS_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCV_MON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRCV_MON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV3 = new System.Windows.Forms.DataGridView();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoVB
            // 
            resources.ApplyResources(this.txtSoVB, "txtSoVB");
            this.txtSoVB.Name = "txtSoVB";
            this.txtSoVB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoVB_KeyDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // txtMaKH
            // 
            resources.ApplyResources(this.txtMaKH, "txtMaKH");
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaKH_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // txtTenKH
            // 
            resources.ApplyResources(this.txtTenKH, "txtTenKH");
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenKH_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_NO,
            this.WS_DATE,
            this.C_NO,
            this.C_NAME,
            this.TOT,
            this.TAX,
            this.DISCOUNT,
            this.RCV_MON,
            this.TOTAL,
            this.NRCV_MON});
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellClick);
            this.DGV2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellDoubleClick);
            // 
            // WS_NO
            // 
            this.WS_NO.DataPropertyName = "WS_NO";
            resources.ApplyResources(this.WS_NO, "WS_NO");
            this.WS_NO.Name = "WS_NO";
            this.WS_NO.ReadOnly = true;
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            this.WS_DATE.ReadOnly = true;
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            this.C_NO.ReadOnly = true;
            // 
            // C_NAME
            // 
            this.C_NAME.DataPropertyName = "C_NAME";
            resources.ApplyResources(this.C_NAME, "C_NAME");
            this.C_NAME.Name = "C_NAME";
            this.C_NAME.ReadOnly = true;
            // 
            // TOT
            // 
            this.TOT.DataPropertyName = "TOT";
            resources.ApplyResources(this.TOT, "TOT");
            this.TOT.Name = "TOT";
            this.TOT.ReadOnly = true;
            // 
            // TAX
            // 
            this.TAX.DataPropertyName = "TAX";
            resources.ApplyResources(this.TAX, "TAX");
            this.TAX.Name = "TAX";
            this.TAX.ReadOnly = true;
            // 
            // DISCOUNT
            // 
            this.DISCOUNT.DataPropertyName = "DISCOUNT";
            resources.ApplyResources(this.DISCOUNT, "DISCOUNT");
            this.DISCOUNT.Name = "DISCOUNT";
            this.DISCOUNT.ReadOnly = true;
            // 
            // RCV_MON
            // 
            this.RCV_MON.DataPropertyName = "RCV_MON";
            resources.ApplyResources(this.RCV_MON, "RCV_MON");
            this.RCV_MON.Name = "RCV_MON";
            this.RCV_MON.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            resources.ApplyResources(this.TOTAL, "TOTAL");
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // NRCV_MON
            // 
            this.NRCV_MON.DataPropertyName = "NRCV_MON";
            resources.ApplyResources(this.NRCV_MON, "NRCV_MON");
            this.NRCV_MON.Name = "NRCV_MON";
            this.NRCV_MON.ReadOnly = true;
            // 
            // DGV3
            // 
            this.DGV3.AllowUserToAddRows = false;
            this.DGV3.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.DGV3, "DGV3");
            this.DGV3.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NR,
            this.P_NO,
            this.P_NAME,
            this.BQTY,
            this.UNIT,
            this.PRICE,
            this.AMOUNT,
            this.COST,
            this.MEMO});
            this.DGV3.Name = "DGV3";
            this.DGV3.ReadOnly = true;
            // 
            // NR
            // 
            this.NR.DataPropertyName = "NR";
            resources.ApplyResources(this.NR, "NR");
            this.NR.Name = "NR";
            this.NR.ReadOnly = true;
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            this.P_NO.ReadOnly = true;
            // 
            // P_NAME
            // 
            this.P_NAME.DataPropertyName = "P_NAME";
            resources.ApplyResources(this.P_NAME, "P_NAME");
            this.P_NAME.Name = "P_NAME";
            this.P_NAME.ReadOnly = true;
            // 
            // BQTY
            // 
            this.BQTY.DataPropertyName = "BQTY";
            resources.ApplyResources(this.BQTY, "BQTY");
            this.BQTY.Name = "BQTY";
            this.BQTY.ReadOnly = true;
            // 
            // UNIT
            // 
            this.UNIT.DataPropertyName = "UNIT";
            resources.ApplyResources(this.UNIT, "UNIT");
            this.UNIT.Name = "UNIT";
            this.UNIT.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            resources.ApplyResources(this.AMOUNT, "AMOUNT");
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.ReadOnly = true;
            // 
            // COST
            // 
            this.COST.DataPropertyName = "COST";
            resources.ApplyResources(this.COST, "COST");
            this.COST.Name = "COST";
            this.COST.ReadOnly = true;
            // 
            // MEMO
            // 
            this.MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MEMO.DataPropertyName = "MEMO";
            resources.ApplyResources(this.MEMO, "MEMO");
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            // 
            // maskedTextBox1
            // 
            resources.ApplyResources(this.maskedTextBox1, "maskedTextBox1");
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            this.maskedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            this.maskedTextBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox1_MouseDoubleClick);
            // 
            // btnThoat
            // 
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frm2CF5_search
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.DGV3);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.txtSoVB);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2CF5_search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm2CF5_FormClosing);
            this.Load += new System.EventHandler(this.frm2CF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtSoVB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.DataGridView DGV3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RCV_MON;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRCV_MON;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}