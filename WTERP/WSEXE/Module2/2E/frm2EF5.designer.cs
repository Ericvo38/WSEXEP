
namespace WTERP
{
    partial class frm2EF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2EF5));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.WS_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WS_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCV_MON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NRCV_MON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            this.NR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb4 = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // DGV1
            // 
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WS_NO,
            this.WS_DATE,
            this.C_NO,
            this.C_NAME,
            this.TOTAL,
            this.TAX,
            this.DISCOUNT,
            this.TOT,
            this.RCV_MON,
            this.NRCV_MON});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellClick);
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            // 
            // WS_NO
            // 
            this.WS_NO.DataPropertyName = "WS_NO";
            resources.ApplyResources(this.WS_NO, "WS_NO");
            this.WS_NO.Name = "WS_NO";
            // 
            // WS_DATE
            // 
            this.WS_DATE.DataPropertyName = "WS_DATE";
            resources.ApplyResources(this.WS_DATE, "WS_DATE");
            this.WS_DATE.Name = "WS_DATE";
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            // 
            // C_NAME
            // 
            this.C_NAME.DataPropertyName = "C_NAME";
            resources.ApplyResources(this.C_NAME, "C_NAME");
            this.C_NAME.Name = "C_NAME";
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            resources.ApplyResources(this.TOTAL, "TOTAL");
            this.TOTAL.Name = "TOTAL";
            // 
            // TAX
            // 
            this.TAX.DataPropertyName = "TAX";
            resources.ApplyResources(this.TAX, "TAX");
            this.TAX.Name = "TAX";
            // 
            // DISCOUNT
            // 
            this.DISCOUNT.DataPropertyName = "DISCOUNT";
            resources.ApplyResources(this.DISCOUNT, "DISCOUNT");
            this.DISCOUNT.Name = "DISCOUNT";
            // 
            // TOT
            // 
            this.TOT.DataPropertyName = "TOT";
            resources.ApplyResources(this.TOT, "TOT");
            this.TOT.Name = "TOT";
            // 
            // RCV_MON
            // 
            this.RCV_MON.DataPropertyName = "RCV_MON";
            resources.ApplyResources(this.RCV_MON, "RCV_MON");
            this.RCV_MON.Name = "RCV_MON";
            // 
            // NRCV_MON
            // 
            this.NRCV_MON.DataPropertyName = "NRCV_MON";
            resources.ApplyResources(this.NRCV_MON, "NRCV_MON");
            this.NRCV_MON.Name = "NRCV_MON";
            // 
            // DGV2
            // 
            this.DGV2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NR,
            this.P_NO,
            this.P_NAME,
            this.BQTY,
            this.UNIT,
            this.PRICE,
            this.AMOUNT,
            this.COST,
            this.MEMO});
            resources.ApplyResources(this.DGV2, "DGV2");
            this.DGV2.Name = "DGV2";
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // NR
            // 
            this.NR.DataPropertyName = "NR";
            resources.ApplyResources(this.NR, "NR");
            this.NR.Name = "NR";
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            // 
            // P_NAME
            // 
            this.P_NAME.DataPropertyName = "P_NAME";
            resources.ApplyResources(this.P_NAME, "P_NAME");
            this.P_NAME.Name = "P_NAME";
            // 
            // BQTY
            // 
            this.BQTY.DataPropertyName = "BQTY";
            resources.ApplyResources(this.BQTY, "BQTY");
            this.BQTY.Name = "BQTY";
            // 
            // UNIT
            // 
            this.UNIT.DataPropertyName = "UNIT";
            resources.ApplyResources(this.UNIT, "UNIT");
            this.UNIT.Name = "UNIT";
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            resources.ApplyResources(this.AMOUNT, "AMOUNT");
            this.AMOUNT.Name = "AMOUNT";
            // 
            // COST
            // 
            this.COST.DataPropertyName = "COST";
            resources.ApplyResources(this.COST, "COST");
            this.COST.Name = "COST";
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            resources.ApplyResources(this.MEMO, "MEMO");
            this.MEMO.Name = "MEMO";
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            this.tb4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tb4_MouseDoubleClick);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm2EF5
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2EF5";
            this.Load += new System.EventHandler(this.frm2EF5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridView DGV2;
        private System.Windows.Forms.MaskedTextBox tb4;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RCV_MON;
        private System.Windows.Forms.DataGridViewTextBoxColumn NRCV_MON;
        private System.Windows.Forms.DataGridViewTextBoxColumn NR;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}