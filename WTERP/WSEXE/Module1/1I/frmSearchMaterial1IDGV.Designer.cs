
namespace WTERP.WSEXE.FormSearch
{
    partial class frmSearchMaterial1IDGV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMaterial1IDGV));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tb4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.dataGridViewlieu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTYSTORE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_NAME2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlieu)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tb4
            // 
            resources.ApplyResources(this.tb4, "tb4");
            this.tb4.Name = "tb4";
            this.tb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb4_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Name = "label4";
            // 
            // tb3
            // 
            resources.ApplyResources(this.tb3, "tb3");
            this.tb3.Name = "tb3";
            this.tb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb3_KeyDown);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Name = "label3";
            // 
            // tb2
            // 
            resources.ApplyResources(this.tb2, "tb2");
            this.tb2.Name = "tb2";
            this.tb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb2_KeyDown);
            // 
            // tb1
            // 
            resources.ApplyResources(this.tb1, "tb1");
            this.tb1.Name = "tb1";
            this.tb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb1_KeyDown);
            // 
            // dataGridViewlieu
            // 
            this.dataGridViewlieu.AllowUserToAddRows = false;
            this.dataGridViewlieu.AllowUserToDeleteRows = false;
            this.dataGridViewlieu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewlieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewlieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.P_NAME1,
            this.P_NAME,
            this.UNIT,
            this.QTYSTORE,
            this.K_NO,
            this.P_NO,
            this.PRICE,
            this.COST,
            this.BUNIT,
            this.CUNIT,
            this.TRANS,
            this.P_NAME2});
            resources.ApplyResources(this.dataGridViewlieu, "dataGridViewlieu");
            this.dataGridViewlieu.Name = "dataGridViewlieu";
            this.dataGridViewlieu.ReadOnly = true;
            this.dataGridViewlieu.RowTemplate.Height = 24;
            this.dataGridViewlieu.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewlieu_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 76.14214F;
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // P_NAME1
            // 
            this.P_NAME1.DataPropertyName = "P_NAME1";
            this.P_NAME1.FillWeight = 105.9645F;
            resources.ApplyResources(this.P_NAME1, "P_NAME1");
            this.P_NAME1.Name = "P_NAME1";
            this.P_NAME1.ReadOnly = true;
            // 
            // P_NAME
            // 
            this.P_NAME.DataPropertyName = "P_NAME";
            this.P_NAME.FillWeight = 105.9645F;
            resources.ApplyResources(this.P_NAME, "P_NAME");
            this.P_NAME.Name = "P_NAME";
            this.P_NAME.ReadOnly = true;
            // 
            // UNIT
            // 
            this.UNIT.DataPropertyName = "UNIT";
            this.UNIT.FillWeight = 105.9645F;
            resources.ApplyResources(this.UNIT, "UNIT");
            this.UNIT.Name = "UNIT";
            this.UNIT.ReadOnly = true;
            // 
            // QTYSTORE
            // 
            this.QTYSTORE.DataPropertyName = "QTYSTORE";
            this.QTYSTORE.FillWeight = 105.9645F;
            resources.ApplyResources(this.QTYSTORE, "QTYSTORE");
            this.QTYSTORE.Name = "QTYSTORE";
            this.QTYSTORE.ReadOnly = true;
            // 
            // K_NO
            // 
            this.K_NO.DataPropertyName = "K_NO";
            resources.ApplyResources(this.K_NO, "K_NO");
            this.K_NO.Name = "K_NO";
            this.K_NO.ReadOnly = true;
            // 
            // P_NO
            // 
            this.P_NO.DataPropertyName = "P_NO";
            resources.ApplyResources(this.P_NO, "P_NO");
            this.P_NO.Name = "P_NO";
            this.P_NO.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.DataPropertyName = "PRICE";
            resources.ApplyResources(this.PRICE, "PRICE");
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            // 
            // COST
            // 
            this.COST.DataPropertyName = "COST";
            resources.ApplyResources(this.COST, "COST");
            this.COST.Name = "COST";
            this.COST.ReadOnly = true;
            // 
            // BUNIT
            // 
            this.BUNIT.DataPropertyName = "BUNIT";
            resources.ApplyResources(this.BUNIT, "BUNIT");
            this.BUNIT.Name = "BUNIT";
            this.BUNIT.ReadOnly = true;
            // 
            // CUNIT
            // 
            this.CUNIT.DataPropertyName = "CUNIT";
            resources.ApplyResources(this.CUNIT, "CUNIT");
            this.CUNIT.Name = "CUNIT";
            this.CUNIT.ReadOnly = true;
            // 
            // TRANS
            // 
            this.TRANS.DataPropertyName = "TRANS";
            resources.ApplyResources(this.TRANS, "TRANS");
            this.TRANS.Name = "TRANS";
            this.TRANS.ReadOnly = true;
            // 
            // P_NAME2
            // 
            this.P_NAME2.DataPropertyName = "P_NAME2";
            resources.ApplyResources(this.P_NAME2, "P_NAME2");
            this.P_NAME2.Name = "P_NAME2";
            this.P_NAME2.ReadOnly = true;
            // 
            // frmSearchMaterial1IDGV
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewlieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tb4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchMaterial1IDGV";
            this.Load += new System.EventHandler(this.frmSearchMaterial1IDGV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tb4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.DataGridView dataGridViewlieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTYSTORE;
        private System.Windows.Forms.DataGridViewTextBoxColumn K_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COST;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANS;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_NAME2;
    }
}