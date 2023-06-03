
namespace WTERP
{
    partial class FrmSearchORDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearchORDB));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOR_NO = new System.Windows.Forms.TextBox();
            this.txtC_NO = new System.Windows.Forms.TextBox();
            this.txtCOLOR = new System.Windows.Forms.TextBox();
            this.txtP_NO = new System.Windows.Forms.TextBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.Column13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OR_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME_E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THICK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRAND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.bttk = new System.Windows.Forms.Button();
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
            // txtOR_NO
            // 
            resources.ApplyResources(this.txtOR_NO, "txtOR_NO");
            this.txtOR_NO.Name = "txtOR_NO";
            this.txtOR_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOR_NO_KeyDown);
            // 
            // txtC_NO
            // 
            resources.ApplyResources(this.txtC_NO, "txtC_NO");
            this.txtC_NO.Name = "txtC_NO";
            this.txtC_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtC_NO_KeyDown);
            // 
            // txtCOLOR
            // 
            resources.ApplyResources(this.txtCOLOR, "txtCOLOR");
            this.txtCOLOR.Name = "txtCOLOR";
            this.txtCOLOR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCOLOR_KeyDown);
            // 
            // txtP_NO
            // 
            resources.ApplyResources(this.txtP_NO, "txtP_NO");
            this.txtP_NO.Name = "txtP_NO";
            this.txtP_NO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP_NO_KeyDown);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column13,
            this.OR_NO,
            this.C_NO,
            this.COLOR_E,
            this.COLOR_C,
            this.P_NO,
            this.P_NAME_E,
            this.THICK,
            this.K_NAME,
            this.BRAND,
            this.QTY,
            this.PRICE,
            this.TOTAL});
            resources.ApplyResources(this.DGV1, "DGV1");
            this.DGV1.Name = "DGV1";
            this.DGV1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV1_CellMouseDoubleClick);
            this.DGV1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellValueChanged);
            // 
            // Column13
            // 
            resources.ApplyResources(this.Column13, "Column13");
            this.Column13.Name = "Column13";
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OR_NO
            // 
            this.OR_NO.DataPropertyName = "OR_NO";
            resources.ApplyResources(this.OR_NO, "OR_NO");
            this.OR_NO.Name = "OR_NO";
            // 
            // C_NO
            // 
            this.C_NO.DataPropertyName = "C_NO";
            resources.ApplyResources(this.C_NO, "C_NO");
            this.C_NO.Name = "C_NO";
            // 
            // COLOR_E
            // 
            this.COLOR_E.DataPropertyName = "COLOR_E";
            resources.ApplyResources(this.COLOR_E, "COLOR_E");
            this.COLOR_E.Name = "COLOR_E";
            // 
            // COLOR_C
            // 
            this.COLOR_C.DataPropertyName = "COLOR_C";
            resources.ApplyResources(this.COLOR_C, "COLOR_C");
            this.COLOR_C.Name = "COLOR_C";
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            // 
            // P_NAME_E
            // 
            this.P_NAME_E.DataPropertyName = "P_NAME_E";
            resources.ApplyResources(this.P_NAME_E, "P_NAME_E");
            this.P_NAME_E.Name = "P_NAME_E";
            // 
            // THICK
            // 
            this.THICK.DataPropertyName = "THICK";
            resources.ApplyResources(this.THICK, "THICK");
            this.THICK.Name = "THICK";
            // 
            // K_NAME
            // 
            this.K_NAME.DataPropertyName = "K_NAME";
            resources.ApplyResources(this.K_NAME, "K_NAME");
            this.K_NAME.Name = "K_NAME";
            // 
            // BRAND
            // 
            this.BRAND.DataPropertyName = "BRAND";
            resources.ApplyResources(this.BRAND, "BRAND");
            this.BRAND.Name = "BRAND";
            this.BRAND.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            resources.ApplyResources(this.QTY, "QTY");
            this.QTY.Name = "QTY";
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            resources.ApplyResources(this.TOTAL, "TOTAL");
            this.TOTAL.Name = "TOTAL";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btdong
            // 
            resources.ApplyResources(this.btdong, "btdong");
            this.btdong.Name = "btdong";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // bttk
            // 
            resources.ApplyResources(this.bttk, "bttk");
            this.bttk.Name = "bttk";
            this.bttk.UseVisualStyleBackColor = true;
            this.bttk.Click += new System.EventHandler(this.bttk_Click);
            // 
            // FrmSearchORDB
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.btdong);
            this.Controls.Add(this.bttk);
            this.Controls.Add(this.txtCOLOR);
            this.Controls.Add(this.txtP_NO);
            this.Controls.Add(this.txtC_NO);
            this.Controls.Add(this.txtOR_NO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSearchORDB";
            this.Load += new System.EventHandler(this.FrmSearchORDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOR_NO;
        private System.Windows.Forms.TextBox txtC_NO;
        private System.Windows.Forms.TextBox txtCOLOR;
        private System.Windows.Forms.TextBox txtP_NO;
        private System.Windows.Forms.Button bttk;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn OR_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME_E;
        private System.Windows.Forms.DataGridViewTextBoxColumn THICK;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRAND;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
    }
}