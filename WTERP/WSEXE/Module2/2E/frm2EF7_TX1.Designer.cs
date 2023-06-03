
namespace WTERP
{
    partial class frm2EF7_TX1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm2EF7_TX1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWS_NO = new System.Windows.Forms.TextBox();
            this.txtC_NO = new System.Windows.Forms.TextBox();
            this.txtC_NAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INV_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATESE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWS_DATE = new System.Windows.Forms.MaskedTextBox();
            this.tbdong = new System.Windows.Forms.Button();
            this.btok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // txtWS_NO
            // 
            resources.ApplyResources(this.txtWS_NO, "txtWS_NO");
            this.txtWS_NO.Name = "txtWS_NO";
            this.txtWS_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWS_NO_KeyDown);
            // 
            // txtC_NO
            // 
            resources.ApplyResources(this.txtC_NO, "txtC_NO");
            this.txtC_NO.Name = "txtC_NO";
            this.txtC_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_NO_KeyDown);
            // 
            // txtC_NAME
            // 
            resources.ApplyResources(this.txtC_NAME, "txtC_NAME");
            this.txtC_NAME.Name = "txtC_NAME";
            this.txtC_NAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_NAME_KeyDown);
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
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
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
            this.OR_NO,
            this.S_NO,
            this.INV_NO,
            this.DATESE});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            // 
            // S_NO
            // 
            this.S_NO.DataPropertyName = "S_NO";
            resources.ApplyResources(this.S_NO, "S_NO");
            this.S_NO.Name = "S_NO";
            // 
            // INV_NO
            // 
            this.INV_NO.DataPropertyName = "INV_NO";
            resources.ApplyResources(this.INV_NO, "INV_NO");
            this.INV_NO.Name = "INV_NO";
            // 
            // DATESE
            // 
            this.DATESE.DataPropertyName = "DATESE";
            resources.ApplyResources(this.DATESE, "DATESE");
            this.DATESE.Name = "DATESE";
            // 
            // txtWS_DATE
            // 
            resources.ApplyResources(this.txtWS_DATE, "txtWS_DATE");
            this.txtWS_DATE.Name = "txtWS_DATE";
            this.txtWS_DATE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWS_DATE_KeyDown);
            // 
            // tbdong
            // 
            resources.ApplyResources(this.tbdong, "tbdong");
            this.tbdong.Name = "tbdong";
            this.tbdong.UseVisualStyleBackColor = true;
            this.tbdong.Click += new System.EventHandler(this.tbdong_Click);
            // 
            // btok
            // 
            resources.ApplyResources(this.btok, "btok");
            this.btok.Name = "btok";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // frm2EF7_TX1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtWS_DATE);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.tbdong);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.txtC_NAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtC_NO);
            this.Controls.Add(this.txtWS_NO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm2EF7_TX1";
            this.Load += new System.EventHandler(this.frm2EF7_TX1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWS_NO;
        private System.Windows.Forms.TextBox txtC_NO;
        private System.Windows.Forms.TextBox txtC_NAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btok;
        private System.Windows.Forms.Button tbdong;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.MaskedTextBox txtWS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WS_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INV_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATESE;
    }
}